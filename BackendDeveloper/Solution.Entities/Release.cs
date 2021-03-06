﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Entities
{
    public class Release
    {
        public string ReleaseId { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public string Label { get; set; }

        public int NumberOfTracks { get; set; }

        public List<NameCredit> NameCredits { get; set; }
    }
}
