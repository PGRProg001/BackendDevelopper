using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Solution.WebAPI.Models;

namespace Solution.WebAPI.Models
{
    public interface IReleaseViewModel
    {
        [DataMember(Order = 1)]
        string ReleaseId { get; set; }

        [DataMember(Order = 2)]
        string Title { get; set; }

        [DataMember(Order = 3)]
        string Status { get; set; }

        [DataMember(Order = 4)]
        string Label { get; set; }

        [DataMember(Order = 5)]
        string NumberOfTracks { get; set; }

        [DataMember(Order = 6)]
        List<OtherArtist> OtherArtists { get; set; }
    }
}
