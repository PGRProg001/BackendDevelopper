using Solution.Entities;
using Solution.Service;
using Solution.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solution.WebAPI.Service
{
    public class ReleaseServiceClient : IReleaseServiceClient
    {
        IReleaseManager _releaseManager;

        public ReleaseServiceClient(IReleaseManager releaseManager)
        {
            _releaseManager = releaseManager;
        }

        public List<Solution.WebAPI.Models.Release> GetReleasesByArtistId(string artistId)
        {
            return MapToViewModel(GetReleasesFromArtistManagerByArtistId(artistId));
        }
        
        private List<Solution.Entities.Release> GetReleasesFromArtistManagerByArtistId(string artistId)
        {
            
            List<Solution.Entities.Release> releases = new List<Solution.Entities.Release>();

            releases = _releaseManager.GetReleasesByArtistId(artistId);

            return releases;
        }

        private List<Solution.WebAPI.Models.Release> MapToViewModel(List<Solution.Entities.Release> release)
        {
            List<Solution.WebAPI.Models.Release> releaseViewModels = new List<Solution.WebAPI.Models.Release>();
            foreach(var r in release)
            {
                Solution.WebAPI.Models.Release releaseViewModel = new Solution.WebAPI.Models.Release();
                releaseViewModel.ReleaseId = r.ReleaseId;
                releaseViewModel.Title = r.Title;
                releaseViewModel.Status = r.Status;
                releaseViewModel.Label = r.Label;
                releaseViewModel.NumberOfTracks = r.NumberOfTracks.ToString();

                List<OtherArtist> otherArtists = new List<OtherArtist>();

                foreach(var o in r.NameCredits)
                {
                    OtherArtist otherArtist = new OtherArtist();
                    otherArtist.Id = o.Id;
                    otherArtist.Name = o.Name;
                    otherArtists.Add(otherArtist);
                }
                releaseViewModel.OtherArtists = otherArtists;
                releaseViewModels.Add(releaseViewModel);
            }
            return releaseViewModels;
        }
    }
}