using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Entities
{
    public class ArtistFilter
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string ArtistNameAndAliasSearchTerm { get; set; }
        public string ArtistId { get; set; }
    }
}
