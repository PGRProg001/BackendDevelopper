using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Solution.WebAPI.Models
{
    public interface IResultsViewModel
    {
        [DataMember(Order = 1)]
        List<Artist> Results { get; set; }

        [DataMember(Order = 2)]
        int NumberOfSearchResults { get; }

        [DataMember(Order = 3)]
        string Page { get; set; }

        [DataMember(Order = 4)]
        string PageSize { get; set; }

        [DataMember(Order = 5)]
        string NumberOfPages { get; }
    }
}