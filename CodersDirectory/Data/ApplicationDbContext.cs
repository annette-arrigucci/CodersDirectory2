using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CodersDirectory.Models;
using Microsoft.AspNetCore.Identity;

namespace CodersDirectory.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<LanguageProfile> LanguageProfiles { get; set; }
        public DbSet<FavoriteProfile> FavoriteProfiles { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Announcement> Announcements { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        //AdminUser - manages user roles, can access admin dashboard, can delete profiles
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            UserManager<ApplicationUser> userManager =
                serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string adminUsername = configuration["Data:AdminUser:Name"];
            string adminEmail = configuration["Data:AdminUser:Email"];
            string adminPassword = configuration["Data:AdminUser:Password"];
            string adminRole = configuration["Data:AdminUser:Role"];

            if(await userManager.FindByNameAsync(adminUsername) == null)
            {
                if(await roleManager.FindByNameAsync(adminRole) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(adminRole));
                }

                ApplicationUser user = new ApplicationUser
                {
                    UserName = adminUsername,
                    Email = adminEmail
                };

                IdentityResult result1 = await userManager.CreateAsync(user, adminPassword);
                if (result1.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, adminRole);
                }
            }

            string newUsername = configuration["Data:NewUser:Name"];
            string newEmail = configuration["Data:NewUser:Email"];
            string newPassword = configuration["Data:NewUser:Password"];
            string newRole = configuration["Data:NewUser:Role"];

            if (await userManager.FindByNameAsync(newUsername) == null)
            {
                if (await roleManager.FindByNameAsync(newRole) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(newRole));
                }

                ApplicationUser user = new ApplicationUser
                {
                    UserName = newUsername,
                    Email = newEmail
                };

                IdentityResult result2 = await userManager.CreateAsync(user, newPassword);
                if (result2.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, newRole);
                }
            }

            string approvedUsername = configuration["Data:ApprovedUser:Name"];
            string approvedEmail = configuration["Data:ApprovedUser:Email"];
            string approvedPassword = configuration["Data:ApprovedUser:Password"];
            string approvedRole = configuration["Data:ApprovedUser:Role"];

            if (await userManager.FindByNameAsync(approvedUsername) == null)
            {
                if (await roleManager.FindByNameAsync(approvedRole) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(approvedRole));
                }

                ApplicationUser user = new ApplicationUser
                {
                    UserName = approvedUsername,
                    Email = approvedEmail
                };

                IdentityResult result3 = await userManager.CreateAsync(user, approvedPassword);
                if (result3.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, approvedRole);
                }
            }
        }
    }
}
