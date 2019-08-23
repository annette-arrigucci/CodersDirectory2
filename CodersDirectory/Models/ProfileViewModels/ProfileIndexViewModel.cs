using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersDirectory.Models.ProfileViewModels
{
    public class ProfileIndexViewModel
    {
        public string Announcement { get; set; }
        public bool EmailVerified { get; set; }
        public bool ProfileCreated { get; set; }
        public List<ProfileSummaryViewModel> RecentProfiles { get; set; }
        public List<ProfileSummaryViewModel> FavoriteProfiles { get; set; }
    }
}
