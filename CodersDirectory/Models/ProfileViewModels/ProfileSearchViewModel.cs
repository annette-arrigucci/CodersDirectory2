using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersDirectory.Models
{
    public class ProfileSearchViewModel
    {
        public string Name { get; set; }
        public int? SelectedLanguageId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public List<Language> Languages{ get; set; }
    }
}
