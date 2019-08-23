using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersDirectory.Models
{
    public class FavoriteProfile
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int FavoriteId { get; set; }
    }
}
