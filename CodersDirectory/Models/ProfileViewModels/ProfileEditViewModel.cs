using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodersDirectory.Models.ProfileViewModels
{
    public class ProfileEditViewModel
    {
        public int? Id { get; set; }
        [Required]
        [MinLength(1)]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z\.\s\-\']+$", ErrorMessage = "Invalid character in name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z\.\s\-\']+$", ErrorMessage = "Invalid character in name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Photo")]
        public string PhotoUrl { get; set; }
        //field for a programming language that is not among default languages
        [MinLength(1)]
        [StringLength(100)]
        public string OtherLanguage { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Contact Email")]
        public string ContactEmail { get; set; }
        [Url]
        [Display(Name = "LinkedIn URL")]
        public string LinkedInUrl { get; set; }
        [Url]
        [Display(Name = "GitHub URL")]
        public string GitHubUrl { get; set; }
        [Url]
        [Display(Name = "Website URL")]
        public string WebsiteUrl { get; set; }
        [MinLength(2)]
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "State code must contain letters and spaces only with minimum 2 characters")]
        public string State { get; set; }
        [StringLength(100)]
        public string Country { get; set; }
        [StringLength(5000)]
        [Display(Name = "Tell us about yourself and your coding background.")]
        public string About { get; set; }
        [StringLength(5000)]
        [Display(Name = "What is your goal for learning to code?")]
        public string Goal { get; set; }
        [StringLength(5000)]
        [Display(Name = "What are your favorite resources for learning to code?")]
        public string Resources { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public bool IsPublished { get; set; }
        public List<LanguageSelectViewModel> Languages { get; set; }
    }
}
