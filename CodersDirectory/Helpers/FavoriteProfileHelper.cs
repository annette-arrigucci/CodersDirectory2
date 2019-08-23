using CodersDirectory.Data;
using System.Collections.Generic;
using System.Linq;
using CodersDirectory.Models;
using System;
using Microsoft.AspNetCore.Identity;

namespace CodersDirectory.Helpers
{
    public class FavoriteProfileHelper
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> userManager;

        public FavoriteProfileHelper(ApplicationDbContext context, UserManager<ApplicationUser> usrMgr)
        {
            _context = context;
            userManager = usrMgr;
        }

        //method isProfileInFavoritesList
        //given two profile IDs, find if the profile being viewed is in the current user's favorite profiles list
        public bool IsProfileInFavoritesList(int currentUserProfile, int profileBeingViewed)
        {
            var result = from p in _context.FavoriteProfiles
                         where p.ProfileId == currentUserProfile && p.FavoriteId == profileBeingViewed
                         select p;
            var foundResult = result.FirstOrDefault();
            if(foundResult != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //get the current user's profile ID
        public int? GetProfileID(string userId)
        {
            var result = from p in _context.Profiles
                         where p.UserId == userId
                         select p;
            var foundResult = result.FirstOrDefault();
            if (foundResult != null)
            {
                return foundResult.Id;
            }
            else
            {
                return null;
            }
        }

        //add the profile being used to the favorite list for the current user's profile
        public bool AddUserProfileToFavoritesList(int? currentUserProfile, int? profileBeingViewed)
        {
            if(currentUserProfile == null || profileBeingViewed == null)
            {
                return false;
            }
            else
            {
                _context.FavoriteProfiles.Add(new FavoriteProfile { ProfileId = (int)currentUserProfile, FavoriteId = (int)profileBeingViewed });
                _context.SaveChanges();
                return true;
            }
        }

        //remove the profile being viewed from the favorite list for the current user's profile
        public bool RemoveUserProfileFromFavoritesList(int? currentUserProfile, int? profileBeingViewed)
        {
            if (currentUserProfile == null || profileBeingViewed == null)
            {
                return false;
            }

            var result = from p in _context.FavoriteProfiles
                         where p.ProfileId == currentUserProfile && p.FavoriteId == profileBeingViewed
                         select p;
            var foundResult = result.FirstOrDefault();

            if(foundResult == null)
            {
                return false;
            }

            else
            {
                _context.FavoriteProfiles.Remove(foundResult);
                _context.SaveChanges();
                return true;
            }
        }

        public List<Profile> GetFavoriteProfiles(int profileId)
        {
            //get favorite profiles, make sure the profiles are in published status
            var favProfilesResult = from p in _context.FavoriteProfiles
                                    where p.ProfileId == profileId
                                    select p.FavoriteId;

            List<Profile> favProfs = new List<Profile>();
            //check for null
            if (favProfilesResult != null)
            {
                //get the profiles from the database
                List<int> favProfIds = favProfilesResult.ToList();
                foreach(var f in favProfIds)
                {
                    var profResult = _context.Profiles.FirstOrDefault(m => m.Id == f);
                    //make sure the favorite profile is published
                    if(profResult != null && profResult.IsPublished == true)
                    {
                        favProfs.Add(profResult);
                    }  
                }
            }
            return favProfs;
        }
    }
}
