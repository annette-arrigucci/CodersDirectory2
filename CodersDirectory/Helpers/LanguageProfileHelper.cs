using CodersDirectory.Data;
using System.Collections.Generic;
using System.Linq;
using CodersDirectory.Models;
using System;

namespace CodersDirectory.Helpers
{
    public class LanguageProfileHelper
    {
        private readonly ApplicationDbContext _context;
        private const int MAX_LANG_ID = 17;

        public LanguageProfileHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        //add language in database 
        public void AddLanguage(string langName)
        {
            var newLang = new Language { Name = langName };
            _context.Languages.Add(newLang);
            _context.SaveChanges();
        }


        //given a profile ID, return a list of all the language IDs associated with it
        public List<int> GetListOfLanguageIds(int profileId)
        {
            var result = from p in _context.LanguageProfiles
                                 where p.ProfileId == profileId
                                 select p.LanguageId;
            return result.ToList();
        }

        //given a list of language Ids, return whether any of the IDs is not one of the original list of 17 constants
        public bool ListContainsOtherLanguage(List<int> languageIds)
        {
            foreach(var id in languageIds)
            {
                if(id > MAX_LANG_ID)
                {
                    return true;
                }
            }
            return false;
        }

        //given a list of IDs, return the language that is "other" - does not have ID 1-16
        public Language GetOtherLanguage(List<int> languageIds)
        {
            Language lang = null;
            foreach (var id in languageIds)
            {
                if (id > MAX_LANG_ID)
                {
                   var result = from i in _context.Languages
                                where i.Id == id
                                select i;
                    lang = result.FirstOrDefault();
                }
            }
            return lang;
        }

        //given an ID number, return name and ID
        public Language GetLanguage(int languageId)
        {
            Language otherLang = null;
            var result = from i in _context.Languages
                         where i.Id == languageId
                         select i;
            otherLang = result.FirstOrDefault();
            return otherLang;
        }

        //given an ID number, return name of language
        public string GetLanguageName(int languageId)
        {
            string otherLangName = null;
            var result = from i in _context.Languages
                         where i.Id == languageId
                         select i.Name;
            otherLangName = result.FirstOrDefault();
            return otherLangName;
        }

        //given a language name, return its ID or null
        public int? GetLanguageId(string langName)
        {
            Language otherLang = null;
            var result = from i in _context.Languages
                         where i.Name == langName
                         select i;
            if (!result.Any())
            {
                return null;
            }
            else
            {
                otherLang = result.FirstOrDefault();
            }
            return otherLang.Id;
        }

        public List<string> GetNamesOfLanguagesForProfile(int profileId)
        {
            //get list of language IDs for profile
            var langList = GetListOfLanguageIds(profileId);
            List<string> langStringList = new List<string>();
            foreach(var l in langList)
            {
                langStringList.Add(GetLanguageName(l));
            }
            return langStringList;
        }

        //compare two lists
        //if the items on the new list are not included on the previous one, return a list of those items
        public List<int> GetListOfLangIdsToAdd(List<int> oldList, List<int> newList)
        {
            List<int> idsToAdd = new List<int>();
            //if the ID is not in the old list, add it to the new list
            foreach(var s in newList) {
                //make sure it is not a 0 - this signifies "other" and is handled elsewhere
                //s should not be a value above the "common language" values of 1-17 because "other values" are signified with 0
                //the "other" language situation is handled elsewhere
                if(s > 0)
                {
                    if (!(oldList.Contains(s)))
                    {
                        idsToAdd.Add(s);
                    }
                }
            }
            return idsToAdd;
        }

        //compare two lists
        //if the items on the old list are not selected in the new list, return a list of those items
        public List<int> GetListOfLangIdsToRemove(List<int> oldList, List<int> newList)
        {
            List<int> idsToRemove = new List<int>();
            //if the ID is not in the old list, add it to the new list
            foreach(var s in oldList)
            {
                //s should not be a  0 because it is getting these values from the database
                //make sure it is one of the common languages(id numbers 1 - 17) - the "other" language situation is handled elsewhere
                if (s < MAX_LANG_ID)
                {
                    if (!(newList.Contains(s)))
                    {
                        idsToRemove.Add(s);
                    }
                }
            }
            return idsToRemove;
        }

        //add a language profile
        public void AddLangProfile(int profileId, int langIdToAdd)
        {
            _context.LanguageProfiles.Add(new LanguageProfile { ProfileId = profileId, LanguageId = langIdToAdd });
            _context.SaveChanges();
        }

        public void AddLangProfiles(int profileId, List<int> listToAdd)
        {
            foreach (var p in listToAdd)
            {
                _context.LanguageProfiles.Add(new LanguageProfile { ProfileId = profileId, LanguageId = p });
                _context.SaveChanges();
            }
        }

        public void RemoveLangProfile(int profileId, int languageId)
        {
            //this doesn't seem to be working
            //going to try to divide this into two steps
            var langsForProfileResult = from m in _context.LanguageProfiles
                         where m.ProfileId == profileId
                         select m;
            //of the user's lang profiles, find the one with this languageId
            var langsForProfile = langsForProfileResult.ToList();
            var langProfRemove = from r in langsForProfile
                               where r.LanguageId == languageId
                               select r;
            var recordToRemove = langProfRemove.FirstOrDefault();
            if(recordToRemove != null)
            {
                _context.LanguageProfiles.Remove(recordToRemove);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Record cannot be removed for language ID" + languageId);
            }
        }

        public void RemoveLangProfiles(int profileId, List<int> listToRemove)
        {
            foreach(var p in listToRemove){
                var result = from m in _context.LanguageProfiles
                             where m.LanguageId == p && m.ProfileId == profileId
                             select m;
                var recordToRemove = result.FirstOrDefault();
                _context.LanguageProfiles.Remove(recordToRemove);
                _context.SaveChanges();
            }
        }

        public void RemoveLanguage(int idToRemove)
        {
            var result = from m in _context.Languages
                         where m.Id == idToRemove
                         select m;
            var recordToRemove = result.FirstOrDefault();
            _context.Languages.Remove(recordToRemove);
            _context.SaveChanges();
        }
    }
}
