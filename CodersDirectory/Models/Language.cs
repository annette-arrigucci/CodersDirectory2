using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersDirectory.Models
{
    public class Language
    {
        public Language()
        {
            this.LanguageProfiles = new HashSet<LanguageProfile>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LanguageProfile> LanguageProfiles { get; set; }
    }
}
