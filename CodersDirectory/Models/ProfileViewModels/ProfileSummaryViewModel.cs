using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersDirectory.Models.ProfileViewModels
{
    public class ProfileSummaryViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Languages { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
