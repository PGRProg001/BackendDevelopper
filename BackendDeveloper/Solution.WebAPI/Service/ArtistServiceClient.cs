using Solution.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Solution.Entities;
using Solution.Service;

namespace Solution.WebAPI.Service
{
    public class ArtistServiceClient : IArtistServiceClient
    {
        private IArtistService _artistService; //new ArtistManager();

        public ArtistServiceClient(IArtistService artistService)
        {
            _artistService = artistService;
        }

        public ResultViewModel GetResultsBasedOnArtistNameNAliasSearch(string SearchCriteria, int Page, int PageSize)
        {
            
            List<Solution.Entities.Artist> artists = _artistService.GetAllRecordsBasedOnFilter(new ArtistFilter
            {
                ArtistNameAndAliasSearchTerm = SearchCriteria,
                Page = Page,
                PageSize = PageSize
            });

            int noOfrecords = _artistService.GetNoOfRecordsBasedOnFilter(new ArtistFilter
            {
                ArtistNameAndAliasSearchTerm = SearchCriteria
            });

            var artistViewModelList = new List<Solution.WebAPI.Models.Artist>();

            foreach (Solution.Entities.Artist a in artists)
            {
                Solution.WebAPI.Models.Artist artist = new Solution.WebAPI.Models.Artist();

                artist.Name = a.ArtistName;
                artist.Country = a.Country;

                artist.Alias = new List<string>();

                if (a.Aliases != null)
                    foreach (string alias in a.Aliases.Split(','))
                    {
                        artist.Alias.Add(alias.Trim());
                    }

                artistViewModelList.Add(artist);
            }

            ResultViewModel myResultViewModel = new ResultViewModel();

            myResultViewModel.Results = artistViewModelList;
            myResultViewModel.Page = Page.ToString();
            myResultViewModel.PageSize = PageSize.ToString();
            myResultViewModel.NumberOfSearchResults = noOfrecords;
            return myResultViewModel;
        }
    }
}