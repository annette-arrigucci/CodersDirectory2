using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodersDirectory.Data;
using CodersDirectory.Helpers;
using CodersDirectory.Models;
using CodersDirectory.Models.AdminViewModels;
using CodersDirectory.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CodersDirectory.Controllers
{
    [Authorize(Roles = "Admins")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> userManager;
        private readonly IHostingEnvironment _environment;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> usrMgr, IEmailSender emailSender, IHostingEnvironment env, RoleManager<IdentityRole> roleMgr, IConfiguration configuration)
        {
            _context = context;
            _environment = env;
            _emailSender = emailSender;
            _configuration = configuration;
            userManager = usrMgr;
            roleManager = roleMgr;
        }

        public async Task<IActionResult> Index()
        {
            //create an object to send to the view
            AdminIndexViewModel model = new AdminIndexViewModel();

            //get the first Announcement from the database
            //this should be the only one in the table
            Announcement announce = _context.Announcements.FirstOrDefault();

            model.Announcement = announce.Body;

            //get all the users registered in the application
            //transform results into list of ManagerUserViewModels
            var users = _context.Users.Select(e => new ManageUserViewModel
            {
                UserId = e.Id,
                Email = e.Email,
                EmailVerified = e.EmailConfirmed,
            }).ToList();

            //now go through this list and get the info from profiles and roles table to fill in the view model
            foreach(var u in users)
            {
                //if profile exists, set "profile created" variable to true, and get name and profile ID
                var profileResult = _context.Profiles.Where(p => p.UserId == u.UserId).FirstOrDefault();
                if(profileResult != null)
                {
                    u.ProfileId = profileResult.Id;
                    u.Name = profileResult.FirstName + " " + profileResult.LastName;
                    u.ProfileCreated = true;
                }
                else
                {
                    u.ProfileCreated = false;
                }

                var user = await userManager.FindByIdAsync(u.UserId);
                //find what role the user is assigned to
                //each user should have exactly one role
                var roles = await userManager.GetRolesAsync(user);
                if(roles == null || roles.Count() == 0)
                {
                    u.Role = "None";
                }
                else
                {
                    u.Role = roles.FirstOrDefault();
                }

                List<SelectListItem> rolesList = new List<SelectListItem>();
                rolesList.Add(new SelectListItem { Text = "None", Value = "None" });
                rolesList.Add(new SelectListItem { Text = "New User", Value = "NewUser" });
                rolesList.Add(new SelectListItem { Text = "Approved User", Value = "ApprovedUser" });
                rolesList.Add(new SelectListItem { Text = "Admin", Value = "Admins" });

                //mark the item as selected if it matches the user's role
                foreach(var r in rolesList)
                {
                    if(u.Role == r.Value)
                    {
                        r.Selected = true;
                    }
                    else
                    {
                        r.Selected = false;
                    }
                }

                u.AllRoles = rolesList;
            }

            model.UserSummaries = users.OrderBy(s => s.Role).ToList();

            //now get list of profile summaries
            var profiles = _context.Profiles.Select(e => new ManageProfileViewModel
            {
                ProfileId = e.Id,
                Name = e.FirstName + " " + e.LastName,
                City = e.City,
                State = e.State,
                Country = e.Country,
                Created = e.Created,
                LastUpdated = e.Updated,
                LastSaved = e.Updated ?? e.Created,
                Status = e.IsPublished ? "Published" : "Draft",
            }).ToList();

            //for each profile summary, get list of languages
            foreach(var p in profiles)
            {
                LanguageProfileHelper langProfHelper = new LanguageProfileHelper(_context);
                var languageList = langProfHelper.GetNamesOfLanguagesForProfile(p.ProfileId);
                string langString = "";
                if(languageList != null)
                {
                    int counter = 0;
                    foreach(var l in languageList)
                    {
                        langString += l;
                        if(counter != languageList.Count() - 1)
                        {
                            langString += ", ";
                        }
                        counter++;
                    }
                }
                p.Languages = langString;

                //fill in SelectList for profile status
                List<SelectListItem> statuses = new List<SelectListItem>();

                if(p.Status == "Published")
                {
                    statuses.Add(new SelectListItem { Text = "Published", Value = "Published", Selected = true });
                    statuses.Add(new SelectListItem { Text = "Draft", Value = "Draft", Selected = false });
                }
                else
                {
                    statuses.Add(new SelectListItem { Text = "Published", Value = "Published", Selected = false });
                    statuses.Add(new SelectListItem { Text = "Draft", Value = "Draft", Selected = true });
                }

                p.AllStatuses = statuses;
            }

            model.ProfileSummaries = profiles.OrderByDescending(s => s.LastSaved).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateAnnouncement(string Announcement)
        {
            var announcementToUpdate = _context.Announcements.FirstOrDefault();
            announcementToUpdate.Body = Announcement;

            _context.Entry(announcementToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //update the user's role to the specified one
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRole(string UserId, string SelectedRole)
        {
            //get the current user
            //if this is the admin demo user, don't allow user to update another user to an admin
            var currentLoggedInUser = await userManager.GetUserAsync(User);
            var demoAdminEmail = _configuration["Data:DemoAdminUser:Email"];

            if (currentLoggedInUser.Email == demoAdminEmail && SelectedRole == "Admins")
            {
                ViewBag.Message = "Demo user not allowed to change role to Admin.";
                return View("Error");
            }

            //find selected user
            var user = await userManager.FindByIdAsync(UserId);
            if(user == null)
            {
                return NotFound();
            }

            //get the selected user's current roles
            var currentRoles = await userManager.GetRolesAsync(user);

            //if this is the demo admin account and "Admins" is one of the user's roles, don't allow changes
            if(currentLoggedInUser.Email == demoAdminEmail && currentRoles.Contains("Admins"))
            {
                ViewBag.Message = "Demo user not allowed to change Admin's role.";
                return View("Error");
            }

            //make sure the specified role has been defined in the database
            if (SelectedRole != "None")
            {
                var roleOK = roleManager.FindByNameAsync(SelectedRole);
                //if the role is found, remove the selected user from current roles and add the user to the new role
                if (roleOK != null)
                {
                    //remove from each role
                    if(currentRoles != null && currentRoles.Count() > 0)
                    {
                        foreach(var c in currentRoles)
                        {
                            await userManager.RemoveFromRoleAsync(user, c);
                        }
                    }
                    await userManager.AddToRoleAsync(user, SelectedRole);
                }
            }
            //if the admin selected "None", remove the user from all roles they are currently in
            else
            {
                //remove from each role
                if (currentRoles != null && currentRoles.Count() > 0)
                {
                    foreach (var c in currentRoles)
                    {
                        await userManager.RemoveFromRoleAsync(user, c);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        //update the profile status to the specified one
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdminChangeProfileStatus(int ProfileId, string SelectedStatus)
        {
            //find the profile in the database based on ID
            var profileToUpdate = _context.Profiles.Find(ProfileId);
            if(profileToUpdate == null)
            {
                return NotFound();
            }

            //update boolean based on selected string
            if(SelectedStatus == "Published")
            {
                profileToUpdate.IsPublished = true;
            }
            else if(SelectedStatus == "Draft")
            {
                profileToUpdate.IsPublished = false;
            }
            else
            {
                return View("Error");
            }

            _context.Entry(profileToUpdate).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AdminDeleteUser(string userId)
        {
            //don't allow a demo user to delete an account
            var currentLoggedInUser = await userManager.GetUserAsync(User);
            var demoAdminEmail = _configuration["Data:DemoAdminUser:Email"];

            if (currentLoggedInUser.Email == demoAdminEmail)
            {
                ViewBag.Message = "Demo user not allowed to delete account.";
                return View("Error");
            }

            //make sure user ID is valid
            var userToDelete = await userManager.FindByIdAsync(userId);
            if (userToDelete == null)
            {
                return NotFound();
            }

            //find the username for this ID
            AdminDeleteUserViewModel model = new AdminDeleteUserViewModel();
            model.UserId = userId;

            var username = await userManager.GetUserNameAsync(userToDelete);

            model.UserName = username;

            return View("AdminDeleteUserConfirm", model);
        }

        //GET
        public async Task<IActionResult> AdminDeleteUserConfirm(AdminDeleteUserViewModel model)
        {
            //don't allow a demo user to delete an account
            var currentLoggedInUser = await userManager.GetUserAsync(User);
            var demoAdminEmail = _configuration["Data:DemoAdminUser:Email"];

            if (currentLoggedInUser.Email == demoAdminEmail)
            {
                ViewBag.Message = "Demo user not allowed to delete account.";
                return View("Error");
            }
            return View(model);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminDeleteUserConfirmPost(string userId)
        {
            //make sure user ID is valid
            var userToDelete = await userManager.FindByIdAsync(userId);
            if (userToDelete == null)
            {
                return NotFound();
            }

            //don't allow a demo user to delete an account
            var currentLoggedInUser = await userManager.GetUserAsync(User);
            var demoAdminEmail = _configuration["Data:DemoAdminUser:Email"];

            if (currentLoggedInUser.Email == demoAdminEmail)
            {
                ViewBag.Message = "Demo user not allowed to delete account.";
                return View("Error");
            }

            //Gets list of Roles associated with current user
            var rolesForUser = await userManager.GetRolesAsync(userToDelete);

            if (rolesForUser.Count() > 0)
            {
                foreach (var item in rolesForUser.ToList())
                {
                    // item should be the name of the role
                    var result = await userManager.RemoveFromRoleAsync(userToDelete, item);
                }
            }

            //if there is a profile associated with each user
            //delete the profile before deleting the user
            var profileForUser = _context.Profiles.FirstOrDefault(p => p.UserId == userToDelete.Id);
            if (profileForUser != null)
            {
                _context.Profiles.Remove(profileForUser);
                _context.SaveChanges();
            }

            //Delete User
            await userManager.DeleteAsync(userToDelete);

            return RedirectToAction("Index");
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminDeleteProfile(int profileId, string name)
        {
            //don't allow a demo admin user to delete an account
            var demoAdminEmail = _configuration["Data:DemoAdminUser:Email"];
            var user = await userManager.GetUserAsync(User);

            if (user.Email == demoAdminEmail)
            {
                ViewBag.Message = "Demo user not allowed to delete profile.";
                return View("Error");
            }

            //check that profile ID is valid, check username matches what is in user table
            var profileResult = _context.Profiles.Where(p => p.Id == profileId).FirstOrDefault();
            if (profileResult == null)
            {
                return NotFound();
            }
            else
            {
                AdminDeleteProfileViewModel model = new AdminDeleteProfileViewModel { ProfileId = profileId, Name = name };
                return RedirectToAction("AdminDeleteProfileConfirm", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AdminDeleteProfileConfirm(AdminDeleteProfileViewModel model)
        {
            //don't allow a demo admin user to delete a profile
            var demoAdminEmail = _configuration["Data:DemoAdminUser:Email"];
            var currentLoggedInUser = await userManager.GetUserAsync(User);

            if (currentLoggedInUser.Email == demoAdminEmail)
            {
                ViewBag.Message = "Demo user not allowed to delete profile.";
                return View("Error");
            }

            return View(model);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminDeleteProfileConfirmPost(AdminDeleteProfileViewModel model)
        {
            //don't allow a demo admin user to delete a profile
            var demoAdminEmail = _configuration["Data:DemoAdminUser:Email"];
            var currentLoggedInUser = await userManager.GetUserAsync(User);

            if (currentLoggedInUser.Email == demoAdminEmail)
            {
                ViewBag.Message = "Demo user not allowed to delete profile.";
                return View("Error");
            }

            //delete the profile
            var profileToDelete = _context.Profiles.FirstOrDefault(p => p.Id == model.ProfileId);
            if (profileToDelete == null)
            {
                return NotFound();
            }
            _context.Profiles.Remove(profileToDelete);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}