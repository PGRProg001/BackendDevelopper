using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.WebAPI.Service
{
    public interface IReleaseServiceClient
    {
        List<Solution.WebAPI.Models.Release> GetReleasesByArtistId(string artistId);
    }
}
