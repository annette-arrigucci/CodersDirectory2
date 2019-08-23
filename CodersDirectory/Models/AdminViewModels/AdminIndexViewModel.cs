using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersDirectory.Models.AdminViewModels
{
    public class AdminIndexViewModel
    {
        public string Announcement { get; set; }
        public List<ManageProfileViewModel> ProfileSummaries { get; set; }
        public List<ManageUserViewModel> UserSummaries { get; set; }
    }
}
