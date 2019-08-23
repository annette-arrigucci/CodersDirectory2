using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodersDirectory.Models
{
    public class Profile
    {
        public Profile()
        {
            this.LanguageProfiles = new HashSet<LanguageProfile>();
            this.FavoriteProfiles = new HashSet<FavoriteProfile>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public string ContactEmail { get; set; }
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string WebsiteUrl { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string About { get; set; }
        public string Goal { get; set; }
        public string Resources { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public bool IsPublished { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<LanguageProfile> LanguageProfiles { get; set; }
        public virtual ICollection<FavoriteProfile> FavoriteProfiles { get; set; }
    }
}
