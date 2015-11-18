using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Solution.WebAPI.Models
{
    public class Artist : IArtist
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public List<string> Alias { get; set; }
    }
}