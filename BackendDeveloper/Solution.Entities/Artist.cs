using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Entities
{
    public class Artist : IEntity
    {
        public string ArtistName { get; set; }

        public string UniqueIdentifier { get; set; }

        public string Country { get; set; }

        public string Aliases { get; set; }
    }
}
