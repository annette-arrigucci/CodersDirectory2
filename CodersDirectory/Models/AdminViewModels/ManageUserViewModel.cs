using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodersDirectory.Models.AdminViewModels
{
    public class ManageUserViewModel
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public int? ProfileId { get; set; }
        public string Email { get; set; }
        public bool ProfileCreated { get; set; }
        public bool EmailVerified { get; set; }
        public string Role { get; set; }
        public List<SelectListItem> AllRoles { get; set; }
    }
}
