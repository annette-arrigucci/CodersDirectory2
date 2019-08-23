using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodersDirectory.Data;
using CodersDirectory.Models;
using CodersDirectory.Models.ProfileViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using CodersDirectory.Helpers;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Authorization;
using CodersDirectory.Services;

namespace CodersDirectory.Controllers
{
    [Authorize]
    public class ProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> userManager;
        private readonly IHostingEnvironment _environment;
        private readonly IEmailSender _emailSender;
        private const int MAX_LANG_ID = 17;

        public ProfilesController(ApplicationDbContext context, UserManager<ApplicationUser> usrMgr, IEmailSender emailSender, IHostingEnvironment env)
        {
            _context = context;
            _environment = env;
            _emailSender = emailSender;
            userManager = usrMgr;
        }

        // GET: Profiles
        public async Task<IActionResult> Index()
        {
            ProfileIndexViewModel profIndexViewModel = new ProfileIndexViewModel();

            //get the user Id
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userId = userManager.GetUserId(currentUser);

            var user = await userManager.FindByIdAsync(userId);

            //check if user has verified email
            profIndexViewModel.EmailVerified = user.EmailConfirmed;

            //check if user has already created a profile
            FavoriteProfileHelper favProfHelper = new FavoriteProfileHelper(_context, userManager);
            int? userProfileId = favProfHelper.GetProfileID(userId);

            if(userProfileId == null)
            {
                profIndexViewModel.ProfileCreated = false;
            }
            else
            {
                profIndexViewModel.ProfileCreated = true;
            }

            // get announcements, list of recently added profiles, list of user favorite profiles
            Announcement announce = _context.Announcements.FirstOrDefault();

            profIndexViewModel.Announcement = announce.Body;

            if (User.IsInRole("ApprovedUser") || User.IsInRole("Admins"))
            {
                //get a list of published profiles created in the last week
                var recentlyCreatedResult = from p in _context.Profiles
                                            where p.Created.AddDays(7.0) > DateTime.Now && p.IsPublished == true
                                            select new { p.Id, p.FirstName, p.LastName, p.City, p.State, p.Country };

                //get a list of published profiles updated in the last week
                var recentlyUpdatedResult = from p in _context.Profiles
                                            where p.Updated != null && p.Updated.Value.AddDays(7.0) > DateTime.Now && p.IsPublished == true
                                            select new { p.Id, p.FirstName, p.LastName, p.City, p.State, p.Country, p.Updated };

                //merge the two lists
                var recentlyCreatedList = recentlyCreatedResult.ToList();

                //create a new master list
                List<ProfileSummaryViewModel> recentList = new List<ProfileSummaryViewModel>();

                LanguageProfileHelper langProfHelper = new LanguageProfileHelper(_context);
                foreach (var r in recentlyCreatedList)
                {
                    ProfileSummaryViewModel profSum = new ProfileSummaryViewModel();
                    profSum.Id = r.Id;
                    profSum.Name = r.FirstName + " " + r.LastName;
                    profSum.City = r.City;
                    profSum.State = r.State;
                    profSum.Country = r.Country;

                    //get list of languages
                    List<string> langList = langProfHelper.GetNamesOfLanguagesForProfile(r.Id);

                    //put this list of strings into the format of a single string
                    string langString = "";

                    int counter = 0;
                    //add comma after string if not last element in list
                    foreach (var l in langList)
                    {
                        langString = langString + l;
                        if (counter != langList.Count - 1)
                        {
                            langString = langString + ", ";
                        }
                        counter++;
                    }
                    profSum.Languages = langString;
                    recentList.Add(profSum);
                }

                var recentlyCreatedIds = recentlyCreatedList.Select(p => p.Id);
                //if an element of the recently updated result is not contained in the recently created list, add it
                var recentlyUpdatedList = recentlyUpdatedResult.ToList();
                foreach (var m in recentlyUpdatedList)
                {
                    if (!recentlyCreatedIds.Contains(m.Id))
                    {
                        ProfileSummaryViewModel profileSum = new ProfileSummaryViewModel();
                        profileSum.Id = m.Id;
                        profileSum.Name = m.FirstName + " " + m.LastName;
                        profileSum.City = m.City;
                        profileSum.State = m.State;
                        profileSum.Country = m.Country;

                        //get list of languages
                        List<string> langList = langProfHelper.GetNamesOfLanguagesForProfile(m.Id);

                        //put this list of strings into the format of a single string
                        string langString = "";

                        int counter = 0;
                        //add comma after string if not last element in list
                        foreach (var l in langList)
                        {
                            langString = langString + l;
                            if (counter != langList.Count - 1)
                            {
                                langString = langString + ", ";
                            }
                            counter++;
                        }
                        profileSum.Languages = langString;
                        recentList.Add(profileSum);
                    }
                }
                profIndexViewModel.RecentProfiles = recentList;

                List<ProfileSummaryViewModel> favSumProfiles = new List<ProfileSummaryViewModel>();

                //if the user has a profile, make a list of summaries of the user's favorite profiles
                if (profIndexViewModel.ProfileCreated == true)
                {
                    List<Profile> favProfiles = favProfHelper.GetFavoriteProfiles((int)userProfileId);
                    foreach (var s in favProfiles)
                    {
                        ProfileSummaryViewModel profileFavSum = new ProfileSummaryViewModel();
                        profileFavSum.Id = s.Id;
                        profileFavSum.Name = s.FirstName + " " + s.LastName;
                        profileFavSum.City = s.City;
                        profileFavSum.State = s.State;
                        profileFavSum.Country = s.Country;

                        //get list of languages
                        List<string> langList = langProfHelper.GetNamesOfLanguagesForProfile(s.Id);

                        //put this list of strings into the format of a single string
                        string langString = "";

                        int counter = 0;
                        //add comma after string if not last element in list
                        foreach (var l in langList)
                        {
                            langString = langString + l;
                            if (counter != langList.Count - 1)
                            {
                                langString = langString + ", ";
                            }
                            counter++;
                        }
                        profileFavSum.Languages = langString;
                        favSumProfiles.Add(profileFavSum);
                    }                   
                }
                profIndexViewModel.FavoriteProfiles = favSumProfiles;
            }
            return View(profIndexViewModel);
        }

        //GET: Profiles/MyProfile
        //show profile of currently logged-in user
        public async Task<IActionResult> MyProfile()
        {
            //get the user Id
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userId = userManager.GetUserId(currentUser);

            //check if user has already created a profile
            FavoriteProfileHelper favProfHelper = new FavoriteProfileHelper(_context, userManager);
            int? userProfileId = favProfHelper.GetProfileID(userId);

            if(userProfileId == null)
            {
                return NotFound();
            }
            else
            {
                //find the profile
                Profile userProfile = _context.Profiles.FirstOrDefault(p => p.Id == userProfileId);
                if(userProfile == null)
                {
                    return NotFound();
                }
                //check if the profile is in draft mode
                if (userProfile.IsPublished == false)
                {
                    //redirect to the Profile Draft Mode notice
                    return View("ProfileDraftMode");
                }
                //otherwise show the user the published profile
                return RedirectToAction("Details", new { id = userProfileId });
            }
        }

        // GET: Profiles/Details/5
        [Authorize(Roles ="Admins,ApprovedUser")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles
                .Include(p => p.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }
            else
            {
                //admin can view a profile that is not published
                //other roles cannot
                if(!User.IsInRole("Admins") && profile.IsPublished == false)
                {
                    return NotFound();
                }
                else
                {
                    //load a view model
                    //if profile is found, load a ProfileViewModel with data from the profile
                    var profDetailsViewModel = new ProfileDetailsViewModel();
                    profDetailsViewModel.Id = profile.Id;
                    profDetailsViewModel.FirstName = profile.FirstName;
                    profDetailsViewModel.LastName = profile.LastName;
                    profDetailsViewModel.PhotoUrl = profile.PhotoUrl;
                    profDetailsViewModel.ContactEmail = profile.ContactEmail;
                    profDetailsViewModel.LinkedInUrl = profile.LinkedInUrl;
                    profDetailsViewModel.GitHubUrl = profile.GitHubUrl;
                    profDetailsViewModel.WebsiteUrl = profile.WebsiteUrl;

                    string locString = null;
                    if(profile.City != null)
                    {
                        locString += profile.City;
                        if (profile.State != null)
                        {
                            locString += ", " + profile.State;
                            if(profile.Country != null)
                            {
                                locString += ", " + profile.Country;
                            }
                        }
                        else
                        {
                            if(profile.Country != null)
                            {
                                locString += ", " + profile.Country;
                            }
                        }
                    }
                    if(profile.City == null)
                    {
                        if(profile.State != null)
                        {
                            locString += profile.State;
                            if(profile.Country != null)
                            {
                                locString += ", " + profile.Country;
                            }
                        }
                        else
                        {
                            if(profile.Country != null)
                            {
                                locString += profile.Country;
                            }
                        }
                    }


                    profDetailsViewModel.LocationString = locString;

                    profDetailsViewModel.About = profile.About;
                    profDetailsViewModel.Goal = profile.Goal;
                    profDetailsViewModel.Resources = profile.Resources;
                    //now get the names of the languages associated with this profile
                    var langProfHelper = new LanguageProfileHelper(_context);
                    //get IDs associated with this profile
                    List<int> langIds = langProfHelper.GetListOfLanguageIds(profile.Id);
                    //for each ID, add the string name to the list
                    List<string> langNames = new List<string>();
                    foreach(var m in langIds)
                    {
                        string langName = langProfHelper.GetLanguageName(m);
                        langNames.Add(langName);
                    }
                    profDetailsViewModel.LanguageNames = langNames;

                    //get whether this profile is in the current user's favorites
                    FavoriteProfileHelper favProfHelper = new FavoriteProfileHelper(_context, userManager);
                    
                    //get current user
                    System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                    var userId = userManager.GetUserId(currentUser);

                    //find current user's profile ID
                    int? userProfileId = favProfHelper.GetProfileID(userId);

                    //user should have a profile ID if they can access this page
                    profDetailsViewModel.ProfileInUserFavorites = favProfHelper.IsProfileInFavoritesList((int)userProfileId, profile.Id);

                    return View(profDetailsViewModel);
                }
            }
        }
        [HttpPost]
        public IActionResult AddProfileToFavorites(int id)
        {
            //get the current user
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userId = userManager.GetUserId(currentUser);

            //add a new entry to add this profile to the current user's profile's favorites
            FavoriteProfileHelper favProfHelper = new FavoriteProfileHelper(_context, userManager);
            int? currentProfile = favProfHelper.GetProfileID(userId);
            if(currentProfile == null)
            {
                return View("Error");
            }

            bool updateOk = favProfHelper.AddUserProfileToFavoritesList(currentProfile, id);

            //if update is not successful, show an error
            if(updateOk == false)
            {
                return View("Error");
            }
            //otherwise, refresh the Details view
            else
            {
                return RedirectToAction("Details", new { id });
            }
        }

        [HttpPost]
        public IActionResult RemoveProfileFromFavorites(int id)
        {
            //get the current user
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userId = userManager.GetUserId(currentUser);

            //find the entry to delete
            FavoriteProfileHelper favProfHelper = new FavoriteProfileHelper(_context, userManager);
            int? currentProfile = favProfHelper.GetProfileID(userId);
            if (currentProfile == null)
            {
                return View("Error");
            }

            bool updateOk = favProfHelper.RemoveUserProfileFromFavoritesList(currentProfile, id);

            //if update is not successful, show an error
            if (updateOk == false)
            {
                return View("Error");
            }
            //otherwise, refresh the Details view
            else
            {
                return RedirectToAction("Details", new { id });
            }
        }

        //GET: Profiles/Search
        //display search view
        [Authorize(Roles = "Admins,ApprovedUser")]
        public IActionResult Search()
        {
            ProfileSearchViewModel model = new ProfileSearchViewModel();
            model.Languages = _context.Languages.ToList();
            return View(model);
        }

        //POST: Profiles/Search
        //take in search criteria and return search results view
        [HttpPost]
        [Authorize(Roles = "Admins,ApprovedUser")]
        public IActionResult Search(ProfileSearchViewModel model)
        {
            //create a list of profile summaries that will be passed to Search Results view
            List<ProfileSummaryViewModel> profileSummaries = new List<ProfileSummaryViewModel>();

            //search for profiles that match search criteria
            //if the user has selected a search by language, first search for all profile IDs that match that language
            //in language profiles table
            if (model.SelectedLanguageId != null)
            {
                var langProfileResults = _context.LanguageProfiles.Where(o => o.LanguageId == model.SelectedLanguageId).Select(o => o.ProfileId);
                List<int> langProfileList = langProfileResults.ToList();

                //if this is null, return null profileSummaries list
                if (langProfileResults == null)
                {
                    return View("SearchResults", profileSummaries);
                }
                else
                {
                    //build a list of profiles associated with the selected language that are published
                    List<Profile> profilesMatchLanguage = new List<Profile>();

                    foreach (var l in langProfileList)
                    {
                        var result = _context.Profiles.Where(p => p.Id == l && p.IsPublished == true).FirstOrDefault();
                        if (result != null)
                        {
                            profilesMatchLanguage.Add(result);
                        }
                    }

                    //from matching profiles, transform profiles into new ProfileSummaryViewModel objects that include:
                    //profile ID
                    //full name
                    //city
                    //state
                    //country

                    var matchingProfiles = profilesMatchLanguage.Select(e => new ProfileSummaryViewModel
                                           {
                                                Id = e.Id,
                                                Name = e.FirstName + " " + e.LastName,
                                                City = e.City,
                                                State = e.State,
                                                Country = e.Country
                                            });

                    if(model.Name != null)
                    {
                        //put profile name and name parameter for search into lowercase
                        matchingProfiles = matchingProfiles.Where(u => u.Name.ToLower().Contains(model.Name.ToLower()));
                    }
                    if(model.City != null)
                    {
                        //put profile city and city parameter for search into lowercase
                        matchingProfiles = matchingProfiles.Where(u => u.City.ToLower().Contains(model.City.ToLower()));
                    }
                    if(model.State != null)
                    {
                        matchingProfiles = matchingProfiles.Where(u => u.State.Contains(model.State));
                    }
                    if (model.Country != null)
                    {
                        matchingProfiles = matchingProfiles.Where(u => u.Country.Contains(model.Country));
                    }
                    if (matchingProfiles == null)
                    {
                        return View("SearchResults", matchingProfiles.ToList());
                    }
                    else
                    {
                        //call method to add languages to ProfileSummaryViewModel objects
                        var sumProfiles = AddLanguagesToSummaryProfiles(matchingProfiles.ToList());
                        return View("SearchResults", sumProfiles);
                    }
                }
            }
            //if the language parameter was not selected as a search criteria, do a search with the other parameters
            else
            {
                //first get all profiles that were published
                var publishedProfiles = _context.Profiles.Where(p => p.IsPublished == true);

                //transform profiles into new ProfileSummaryViewModel objects that include:
                //profile ID
                //full name
                //city
                //state
                //country
                var matchingProfiles = publishedProfiles.Select(e => new ProfileSummaryViewModel
                {
                    Id = e.Id,
                    Name = e.FirstName + " " + e.LastName,
                    City = e.City,
                    State = e.State,
                    Country = e.Country
                });

                if (model.Name != null)
                {
                    //put profile name and name parameter for search into lowercase
                    matchingProfiles = matchingProfiles.Where(u => u.Name.ToLower().Contains(model.Name.ToLower()));
                }
                if (model.City != null)
                {
                    //put profile city and city parameter for search into lowercase
                    matchingProfiles = matchingProfiles.Where(u => u.City.ToLower().Contains(model.City.ToLower()));
                }
                if (model.State != null)
                {
                    matchingProfiles = matchingProfiles.Where(u => u.State.Contains(model.State));
                }
                if (model.Country != null)
                {
                    matchingProfiles = matchingProfiles.Where(u => u.Country.Contains(model.Country));
                }
                if (matchingProfiles == null)
                {
                    return View("SearchResults", matchingProfiles.ToList());
                }
                else
                {
                    var sumProfiles = AddLanguagesToSummaryProfiles(matchingProfiles.ToList());
                    return View("SearchResults", sumProfiles);
                }
            }
        }

        //GET: Profiles/SearchResults
        [Authorize(Roles = "Admins,ApprovedUser")]
        public IActionResult SearchResults(List<ProfileSummaryViewModel> matchingProfiles)
        {
            return View(matchingProfiles);
        }

        // GET: Profiles/Create
        [Authorize(Roles ="NewUser, ApprovedUser, Admins")]
        public async Task<IActionResult> Create()
        {
            //find user
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }
            var userId = user.Id;
            //check if this user already has a profile
            //if a result is found, redirect to an error page
            if (_context.Profiles.Where(p => p.UserId == userId).Count() > 0)
            {
                return View("Error");
            }
            else
            {
                var myModel = new ProfileViewModel();
                var languageSelectList = CreateLanguageList();
                myModel.Languages = languageSelectList;
                myModel.IsPublished = false;
                return View(myModel);
            }
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfileViewModel model, IFormFile ImageFile)
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {  //check the file name to make sure its an image                 
                var ext = Path.GetExtension(ImageFile.FileName).ToLower();
                if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".gif" && ext != ".bmp")
                    ModelState.AddModelError("PhotoUrl", "Invalid Format");

                //make sure the file name is less than 100 characters
                if(ImageFile.FileName.Length >= 100)
                {
                    ModelState.AddModelError("PhotoUrl", "File name too long");
                }

                //make sure the file is less than 2MB
                if (ImageFile.Length > 2000000)
                {
                    ModelState.AddModelError("PhotoUrl", "File must be less than 2MB");
                }
            }
            if (ModelState.IsValid)
            {
                Profile profile = new Profile();

                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                var id = userManager.GetUserId(currentUser);
                profile.UserId = id;

                profile.FirstName = model.FirstName;
                profile.LastName = model.LastName;

                if (ImageFile != null)
                {
                    //trim extension on filename
                    var trimFileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                    //get unique identifier for file name
                    Random rnd = new Random();
                    var uniqueFileId = Convert.ToString(rnd.Next(100000, 1000000));
                    var fileExtension = Path.GetExtension(ImageFile.FileName);
                    var newFileName = trimFileName + "_" + uniqueFileId + fileExtension;
                    //get absolute path for file save
                    var absPath = Path.Combine(_environment.WebRootPath, "ImageUploads", newFileName);
                    //relative path to store in folder in database
                    profile.PhotoUrl = "/ImageUploads/" + newFileName;
                    using(FileStream fs = new FileStream(absPath, FileMode.Create))
                    {
                        ImageFile.CopyTo(fs);
                    }
                }
                profile.ContactEmail = model.ContactEmail;
                profile.LinkedInUrl = model.LinkedInUrl;
                profile.GitHubUrl = model.GitHubUrl;
                profile.WebsiteUrl = model.WebsiteUrl;
                profile.City = model.City;
                profile.State = model.State;
                profile.Country = model.Country;
                profile.About = model.About;
                profile.Goal = model.Goal;
                profile.Resources = model.Resources;

                profile.Created = DateTimeOffset.Now;

                //new profiles are automatically in draft mode
                profile.IsPublished = false;

                _context.Profiles.Add(profile);
                _context.SaveChanges();

                //find the Profile Id for the profile that was just created
                var currentProf = _context.Profiles.FirstOrDefault(x => x.UserId == id);
                var profId = currentProf.Id;
                foreach (var lang in model.Languages)
                {
                    if (lang.IsSelected == true)
                    {
                        //if this is the "Other" option
                        if (lang.Name == "Other")
                        {
                            //if the language is not in the table, add it
                            LanguageProfileHelper langProfHelper = new LanguageProfileHelper(_context);
                            int? newLangId = langProfHelper.GetLanguageId(model.OtherLanguage);
                            if (newLangId == null)
                            {
                                langProfHelper.AddLanguage(model.OtherLanguage);
                                newLangId = (int)langProfHelper.GetLanguageId(model.OtherLanguage);
                            }
                            langProfHelper.AddLangProfile(profId, (int)newLangId);
                        }
                        else
                        {
                            //create a new entry in LanguageProfiles database
                            var langProfile = new LanguageProfile { ProfileId = profId, LanguageId = lang.Id };
                            _context.LanguageProfiles.Add(langProfile);
                            _context.SaveChanges();
                        }
                    }
                }

                //add notification for admin here - profile was submitted
                var user = await userManager.GetUserAsync(User);
                if (user == null)
                {
                    throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
                }

                var email = user.Email;
                var name = profile.FirstName + " " + profile.LastName;
                await _emailSender.SendEmailAsync("annette.arrigucci@gmail.com", "New User", "A new user has submitted a profile to the Coders Directory. View the profile for " + name + " in the Coders Directory dashboard to approve it.");

                return View("ProfileSubmitted");
            }
            return View(model);
        }

        //GET: Profiles/EditMyProfile
        //edit profile of currently logged-in user
        [Authorize(Roles = "Admins,ApprovedUser")]
        public async Task<IActionResult> EditMyProfile()
        {
            //get the user Id
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userId = userManager.GetUserId(currentUser);

            //check if user has a profile
            FavoriteProfileHelper favProfHelper = new FavoriteProfileHelper(_context, userManager);
            int? userProfileId = favProfHelper.GetProfileID(userId);

            if (userProfileId == null)
            {
                return NotFound();
            }
            else
            {
                return RedirectToAction("Edit", new { id = userProfileId });
            }
        }

        // GET: Profiles/Edit/5
        [Authorize(Roles = "Admins,ApprovedUser")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles.SingleOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }

            //get the current user
            //if the user's ID does not match the user ID for the profile, redirect to error page
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userId = userManager.GetUserId(currentUser);
            if(profile.UserId != userId)
            {
                return View("Error");
            }

            //load a ProfileViewModel with data from the profile
            var profViewModel = new ProfileEditViewModel();
            profViewModel.Id = profile.Id;
            profViewModel.FirstName = profile.FirstName;
            profViewModel.LastName = profile.LastName;
            profViewModel.PhotoUrl = profile.PhotoUrl;
            profViewModel.ContactEmail = profile.ContactEmail;
            profViewModel.LinkedInUrl = profile.LinkedInUrl;
            profViewModel.GitHubUrl = profile.GitHubUrl;
            profViewModel.WebsiteUrl = profile.WebsiteUrl;
            profViewModel.City = profile.City;
            profViewModel.State = profile.State;
            profViewModel.Country = profile.Country;
            profViewModel.About = profile.About;
            profViewModel.Goal = profile.Goal;
            profViewModel.Resources = profile.Resources;
            profViewModel.Created = profile.Created;
            profViewModel.Updated = profile.Updated;
            profViewModel.IsPublished = profile.IsPublished;

            //look up the language IDs that are associated with this profile using helper method
            var langProfHelper = new LanguageProfileHelper(_context);
            var langIdList = langProfHelper.GetListOfLanguageIds(profile.Id);

            //create a new list of LanguageSelectViewModels with the saved selections indicated
            //use helper to find if "Other" option was selected
            bool otherIsSelected = langProfHelper.ListContainsOtherLanguage(langIdList);
            profViewModel.Languages = CreateLanguageListForEdit(langIdList, otherIsSelected);
            //get the language name for the "Other" option selected
            if (otherIsSelected)
            {
                Language otherLang = langProfHelper.GetOtherLanguage(langIdList);
                profViewModel.OtherLanguage = otherLang.Name;
            }
            return View(profViewModel);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins,ApprovedUser")]
        public async Task<IActionResult> Edit(string SaveButton, string PublishButton, ProfileEditViewModel model, IFormFile ImageFile)
        {
            if (model.Id == null) {
                return NotFound();
            }

            //if there is an image, make sure file format and name are valid
            if (ImageFile != null && ImageFile.Length > 0)
            {
                //check the file name to make sure it's an image                 
                var ext = Path.GetExtension(ImageFile.FileName).ToLower();
                if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".gif" && ext != ".bmp")
                {
                    ModelState.AddModelError("PhotoUrl", "Invalid Format");
                }

                //make sure the file name is less than 100 characters
                if (ImageFile.FileName.Length >= 100)
                {
                    ModelState.AddModelError("PhotoUrl", "File name too long");
                }

                //make sure the file is less than 2MB
                if (ImageFile.Length > 2000000)
                {
                    ModelState.AddModelError("PhotoUrl", "File must be less than 2MB");
                }
            }

            if (ModelState.IsValid) {
                //find the profile in the database based on ID
                var profileToUpdate = _context.Profiles.Find(model.Id);

                //if the user's ID does not match the user ID for the found profile, redirect to error page
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                var userId = userManager.GetUserId(currentUser);
                if (profileToUpdate.UserId != userId)
                {
                    return View("Error");
                }

                //update publish status based on which button was clicked
                if (SaveButton != null) {
                    profileToUpdate.IsPublished = false;
                }
                else if (PublishButton != null) {
                    profileToUpdate.IsPublished = true;
                }

                //change update date to now
                profileToUpdate.Updated = DateTimeOffset.Now;

                //update the fields that are simple string updates
                if (await TryUpdateModelAsync(profileToUpdate, "", s => s.FirstName, s => s.LastName, s => s.ContactEmail,
                      s => s.LinkedInUrl, s => s.GitHubUrl, s => s.WebsiteUrl, s => s.City, s => s.State, s => s.Country, s => s.About, s => s.Goal,
                      s => s.Resources)) {
                    //if the update on the model fields is OK, try to update the file if there is one passed in
                    try {
                        //if the photoURL not previously null, determine how it needs to be updated
                        if (profileToUpdate.PhotoUrl != null) {
                            //if a new image is present, we need to upload it and update the photoURL
                            if (ImageFile != null)
                            {
                                //remove the old file if there is one
                                if (System.IO.File.Exists(_environment.WebRootPath + "/ImageUploads/" + profileToUpdate.PhotoUrl))
                                {
                                    System.IO.File.Delete(_environment.WebRootPath + "/ImageUploads/" + profileToUpdate.PhotoUrl);
                                }
                                //upload the new file and get its URL to add to the model
                                //trim extension on filename
                                var trimFileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                                //get unique identifier for file name
                                Random rnd = new Random();
                                var uniqueFileId = Convert.ToString(rnd.Next(100000, 1000000));
                                var fileExtension = Path.GetExtension(ImageFile.FileName);
                                var newFileName = trimFileName + "_" + uniqueFileId + fileExtension;
                                //get absolute path for file save
                                var absPath = Path.Combine(_environment.WebRootPath, "ImageUploads", newFileName);
                                //relative path to store in folder in database
                                profileToUpdate.PhotoUrl = "/ImageUploads/" + newFileName;
                                using(FileStream fs = new FileStream(absPath, FileMode.Create))
                                {
                                    ImageFile.CopyTo(fs);
                                }
                            }
                            //if no photo was uploaded, use the photoURL passed in with the model
                            //this should be the same one that was already there
                            else
                            {
                                //if old and new photoURLs the same
                                if(profileToUpdate.PhotoUrl == model.PhotoUrl)
                                {
                                    //do nothing
                                }
                                //if photoUrl is null
                                else if(model.PhotoUrl == null)
                                {
                                    //remove the old file if there is one
                                    if (System.IO.File.Exists(_environment.WebRootPath + profileToUpdate.PhotoUrl))
                                    {
                                        System.IO.File.Delete(_environment.WebRootPath + profileToUpdate.PhotoUrl);
                                    }
                                    //set the PhotoUrl to null now
                                    profileToUpdate.PhotoUrl = null;
                                }
                                else
                                {
                                    return View("Error");
                                }
                            }  
                        }
                        //if the old photoURL was null, determine the action that needs to be taken
                        else
                        {
                            //if a photo was added, upload the photo and update the photoURL
                            if(ImageFile != null)
                            {
                                //upload the new file and get its URL to add to the model
                                //trim extension on filename
                                var trimFileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                                //get unique identifier for file name
                                Random rnd = new Random();
                                var uniqueFileId = Convert.ToString(rnd.Next(100000, 1000000));
                                var fileExtension = Path.GetExtension(ImageFile.FileName);
                                var newFileName = trimFileName + "_" + uniqueFileId + fileExtension;
                                //get absolute path for file save
                                var absPath = Path.Combine(_environment.WebRootPath, "ImageUploads", newFileName);
                                //relative path to store in folder in database
                                profileToUpdate.PhotoUrl = "/ImageUploads/" + newFileName;
                                using(FileStream fstr = new FileStream(absPath, FileMode.Create))
                                {
                                    ImageFile.CopyTo(fstr);
                                }
                            }
                            //old photoUrl was null, should stay null
                            else
                            {
                                //make sure photoUrl on model is null
                                //if a value was added, it's an error or a user trying to add a value not supposed to be there
                                if(model.PhotoUrl != null)
                                {
                                   return View("Error");
                                }
                            }
                        }

                        //look up the language IDs that are associated with this profile using helper method
                        var langProfHelper = new LanguageProfileHelper(_context);
                        List<int> alreadySelectedLangIdList = langProfHelper.GetListOfLanguageIds(profileToUpdate.Id);

                        //get list of language IDs selected this time
                        List<int> editedSelectedLangIdList = GetListOfSelectedLanguages(model.Languages);

                        //make a comparison of the two lists
                        //find which language-profile entries from the common entries need to be added or removed 

                        //get list of language IDs that need to be added
                        List<int> idsToAdd = langProfHelper.GetListOfLangIdsToAdd(alreadySelectedLangIdList, editedSelectedLangIdList);

                        //get list of language IDs that need to be deleted
                        List<int> idsToRemove = langProfHelper.GetListOfLangIdsToRemove(alreadySelectedLangIdList, editedSelectedLangIdList);

                        //make the changes
                        langProfHelper.AddLangProfiles(profileToUpdate.Id, idsToAdd);
                        langProfHelper.RemoveLangProfiles(profileToUpdate.Id, idsToRemove);

                        //now, look at the "other" selection
                        //a user can do four things in editing that relate to the "other" option:
                        //leave it the same
                        //deselect it (if it was selected before)
                        //select it (if it was not selected before)
                        //change the text in the "other language" box

                        //find out if "other" option was selected last time
                        //if so, get the ID and the name of the language
                        bool otherAlreadySelected = langProfHelper.ListContainsOtherLanguage(alreadySelectedLangIdList);
                        Language previousOtherLang = null;
                        string previousOtherLangName = null;
                        if (otherAlreadySelected)
                        {
                            previousOtherLang = langProfHelper.GetOtherLanguage(alreadySelectedLangIdList);
                            previousOtherLangName = previousOtherLang.Name;
                        }

                        //now find out if "other" option was selected this time
                        bool otherEditedSelected = ListContainsOtherLanguage(editedSelectedLangIdList);

                        string editLangName = null;
                        if (otherEditedSelected)
                        {
                            editLangName = model.OtherLanguage;
                        }

                        //first option - if other was selected the first time and deselected this time
                        //if it was selected before and is deselected now, 
                        //remove the language profile
                        if (otherAlreadySelected == true && otherEditedSelected == false)
                        {
                            langProfHelper.RemoveLangProfile(profileToUpdate.Id, previousOtherLang.Id);
                        }

                        //if it was not selected before and is selected now, add the language entry and the languageProfile entry to the tables
                        if(otherAlreadySelected == false && otherEditedSelected == true)
                        {
                            //if the language is not in the table, add it
                            int? newLangId = langProfHelper.GetLanguageId(model.OtherLanguage);
                            if(newLangId == null)
                            {
                                langProfHelper.AddLanguage(model.OtherLanguage);
                                newLangId = (int)langProfHelper.GetLanguageId(model.OtherLanguage);
                            }
                            langProfHelper.AddLangProfile(profileToUpdate.Id, (int)newLangId);
                        }

                        //if it was selected before and is selected again now, double check to see if the new text matches the old
                        if(otherAlreadySelected == true && otherEditedSelected == true)
                        {
                            
                            if (!previousOtherLangName.Equals(editLangName))
                            {
                                //if new text does not match the old, 
                                //remove the language profile
                                langProfHelper.RemoveLangProfile(profileToUpdate.Id, previousOtherLang.Id);
                                //add the new Language if it doesn't already exist
                                int? updatedLangId = langProfHelper.GetLanguageId(model.OtherLanguage);
                                if (updatedLangId == null)
                                {
                                    langProfHelper.AddLanguage(model.OtherLanguage);
                                    updatedLangId = (int)langProfHelper.GetLanguageId(model.OtherLanguage);
                                }
                                langProfHelper.AddLangProfile(profileToUpdate.Id, (int)updatedLangId);
                            }
                        }

                        _context.Entry(profileToUpdate).State = EntityState.Modified;
                        _context.SaveChanges();

                        //redirect based on which button was clicked
                        //if draft selected, go back to dashboard because details view no longer available
                        if (SaveButton != null)
                        {
                            return RedirectToAction("Index");
                        }
                        //if publish selected, go to profile details
                        else if (PublishButton != null)
                        {
                            return RedirectToAction("Details", new { id = profileToUpdate.Id });
                        }
                        else
                        {
                            return View("Error");
                        }

                    }
                    catch (RetryLimitExceededException /* dex */) {
                        //Log the error (uncomment dex variable name and add a line here to write a log.
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    }
                }
                return View(model);
            }
            return View(model);
        }
       
        private bool ProfileExists(int id)
        {
            return _context.Profiles.Any(e => e.Id == id);
        }

        private List<LanguageSelectViewModel> CreateLanguageList()
        {
            //get all entries in the languages table
            var languageSelectList = new List<LanguageSelectViewModel>();
            var languages = _context.Languages.Select(x => x);
            var languagesList = languages.ToList();
            //put the common languages into a new list of LanguageSelectViewModel objects
            //these are constants
            for(int i = 0; i < MAX_LANG_ID; i++)
            {
                var id = languagesList[i].Id;
                var name = languagesList[i].Name;
                languageSelectList.Add(new LanguageSelectViewModel { Id = id, Name = name, IsSelected = false });
            }
            //add an object to select an "Other" option
            languageSelectList.Add(new LanguageSelectViewModel { Id = 0, Name = "Other", IsSelected = false });
            return languageSelectList;
        }

        private List<LanguageSelectViewModel> CreateLanguageListForEdit(List<int> selectedLanguages, bool otherSelected)
        {
            //get all entries in the languages table
            var languageSelectList = new List<LanguageSelectViewModel>();
            var languages = _context.Languages.Select(x => x);
            var languagesList = languages.ToList();
            //put the common languages into a new list of LanguageSelectViewModel objects
            //these are constants
            for (int i = 0; i < MAX_LANG_ID; i++)
            {
                var id = languagesList[i].Id;
                var name = languagesList[i].Name;
                bool selected;
                if (selectedLanguages.Contains(id))
                {
                    selected = true;
                }
                else
                {
                    selected = false;
                }
                languageSelectList.Add(new LanguageSelectViewModel { Id = id, Name = name, IsSelected = selected });
            }
            //add an object to select an "Other" option
            languageSelectList.Add(new LanguageSelectViewModel { Id = 0, Name = "Other", IsSelected = otherSelected });
            return languageSelectList;
        }

        private List<int> GetListOfSelectedLanguages(List<LanguageSelectViewModel> selectLangList)
        {
            //loop through the list of select objects
            List<int> selectedIds = new List<int>();
            foreach(var s in selectLangList){
                if(s.IsSelected == true) {
                    selectedIds.Add(s.Id);
                }
            }
            return selectedIds;
        }

        //return true if one of the selected boxes has an ID of 0
        private bool ListContainsOtherLanguage(List<int> langIdList)
        {
            return langIdList.Contains(0);
        }

        //given a list of profiles, return a list of profile summaries
        private List<ProfileSummaryViewModel> ProfilesToSummary(List<Profile> profileList)
        {
            List<ProfileSummaryViewModel> profSums = new List<ProfileSummaryViewModel>();
            foreach (var p in profileList)
            {
                ProfileSummaryViewModel profSum = new ProfileSummaryViewModel();
                profSum.Id = p.Id;
                profSum.Name = p.FirstName + " " + p.LastName;
                profSum.State = p.State;
                profSum.Country = p.Country;

                LanguageProfileHelper langProfHelper = new LanguageProfileHelper(_context);
                //get list of languages
                List<string> langList = langProfHelper.GetNamesOfLanguagesForProfile(p.Id);

                //put this list of strings into the format of a single string
                string langString = "";

                int counter = 0;
                //add comma after string if not last element in list
                foreach (var l in langList)
                {
                    langString = langString + l;
                    if (counter != langList.Count - 1)
                    {
                        langString = langString + ", ";
                    }
                    counter++;
                }
                profSum.Languages = langString;
                profSums.Add(profSum);
            }
            return profSums;
        }

        //given a list of ProfileSummaryViewModels, return it with the languages for each added
        private List<ProfileSummaryViewModel> AddLanguagesToSummaryProfiles(List<ProfileSummaryViewModel> profileList)
        {
            foreach (var p in profileList)
            {
                LanguageProfileHelper langProfHelper = new LanguageProfileHelper(_context);
                //get list of languages
                List<string> langList = langProfHelper.GetNamesOfLanguagesForProfile((int)p.Id);

                //put this list of strings into the format of a single string
                string langString = "";

                int counter = 0;
                //add comma after string if not last element in list
                foreach (var l in langList)
                {
                    langString = langString + l;
                    if (counter != langList.Count - 1)
                    {
                        langString = langString + ", ";
                    }
                    counter++;
                }
                p.Languages = langString;
            }
            return profileList;
        }
    }
}
