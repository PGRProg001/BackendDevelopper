using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solution.WebAPI.Models
{
    public class ResultViewModel : IResultsViewModel
    {
        public List<Artist> Results { get; set; }

        public int NumberOfSearchResults { get; set; }

        public string Page { get; set; }

        public string PageSize
        {
            get { return _pageSize.ToString(); }

            set
            {
                int pageSize = 0;
                try
                {
                   pageSize= System.Int32.Parse(value);
                }
                catch
                {
                    throw new ArgumentException("PageSize is not a valid number.");
                }
                if (pageSize < 1)
                    throw new ArgumentOutOfRangeException("PageSize must be greater than 0");
                _pageSize = pageSize;
            }
        }

        public string NumberOfPages
        {
            get
            {
                return ((this.NumberOfSearchResults + _pageSize - 1) / _pageSize).ToString();
            }
        }

        private int _pageSize;
    }
}