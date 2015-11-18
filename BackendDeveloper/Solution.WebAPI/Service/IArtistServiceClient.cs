using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.WebAPI.Models;

namespace Solution.WebAPI.Service
{
    public interface IArtistServiceClient
    {
        ResultViewModel GetResultsBasedOnArtistNameNAliasSearch(string SearchCriteria, int Page, int PageSize);
    }
}
