using CodersDirectory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersDirectory.Data
{
    public static class SeedData
    {
        public static void CreateLanguages(IServiceProvider serviceProvider)
        {
            ApplicationDbContext context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            if (!context.Languages.Any())
            {
                List<Language> languageList = new List<Language>
                {   new Language { Name = "JavaScript"},
                    new Language { Name = "HTML/CSS"},
                    new Language { Name = "React"},
                    new Language { Name = "Ruby/Rails"},
                    new Language { Name = "C#/.NET"},
                    new Language { Name = "Angular"},
                    new Language { Name = "iOS/Swift"},
                    new Language { Name = "C/C++"},
                    new Language { Name = "Java"},
                    new Language { Name = "Android"},
                    new Language { Name = "PHP"},
                    new Language { Name = "WordPress"},
                    new Language { Name = "Python"},
                    new Language { Name = "Django"},
                    new Language { Name = "R"},
                    new Language { Name = "Salesforce"},
                    new Language { Name = "SharePoint"},
                };
                foreach(var lang in languageList)
                {
                    context.Languages.Add(lang);
                    context.SaveChanges();
                }
            }
        }
    }
}
