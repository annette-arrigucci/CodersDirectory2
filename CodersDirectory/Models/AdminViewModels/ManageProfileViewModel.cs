using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersDirectory.Models.AdminViewModels
{
    public class ManageProfileViewModel
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string Languages { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
        public DateTimeOffset LastSaved { get; set; }
        public string Status { get; set; }
        public List<SelectListItem> AllStatuses { get; set; }
    }
}
