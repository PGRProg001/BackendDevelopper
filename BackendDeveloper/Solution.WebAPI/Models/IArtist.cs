using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Solution.WebAPI.Models
{
    public interface IArtist
    {
        [DataMember(Order = 1)]
        string Name { get; set; }

        [DataMember(Order = 2)]
        string Country { get; set; }

        [DataMember(Order = 3)]
        List<string> Alias { get; set; }
    }
}
