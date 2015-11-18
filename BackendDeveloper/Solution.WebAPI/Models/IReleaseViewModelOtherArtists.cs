using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Solution.WebAPI.Models
{
    public interface IReleaseViewModelOtherArtists
    {
        [DataMember(Order = 1)]
        string Id { get; set; }

        [DataMember(Order = 2)]
        string Name { get; set; }
    }
}