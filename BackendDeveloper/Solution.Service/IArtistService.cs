using Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public interface IArtistService
    {
        List<Artist> GetAllRecordsBasedOnFilter(ArtistFilter artistFilter);
        int GetNoOfRecordsBasedOnFilter(ArtistFilter artistFilter);
    }
}
