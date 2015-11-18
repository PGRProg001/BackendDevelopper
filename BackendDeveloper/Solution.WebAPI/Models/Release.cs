using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solution.WebAPI.Models
{
    public class Release : IReleaseViewModel
    {
        public string ReleaseId { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public string Label { get; set; }

        public string NumberOfTracks { get; set; }

        public List<OtherArtist> OtherArtists { get; set; }
    }
}