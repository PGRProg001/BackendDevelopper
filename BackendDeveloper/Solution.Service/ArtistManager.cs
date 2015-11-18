using Solution.DAL.ArtistRepository;
using Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public class ArtistManager : IArtistService
    {
        private IArtistDAL _artistDAL;

        public ArtistManager(IArtistDAL artistDAL)
        {
            _artistDAL = artistDAL;
        }

        public List<Artist> GetAllRecordsBasedOnFilter(ArtistFilter artistFilter)
        {
            return _artistDAL.GetList(
                filter: artist =>
                    artist.ArtistName.StartsWith(artistFilter.ArtistNameAndAliasSearchTerm)
                    || artist.ArtistName.Contains(" " + artistFilter.ArtistNameAndAliasSearchTerm)
                    || artist.Aliases.StartsWith(artistFilter.ArtistNameAndAliasSearchTerm)
                    || artist.Aliases.Contains(" " + artistFilter.ArtistNameAndAliasSearchTerm),
                orderBy: o => o.OrderBy(artist => artist.ArtistName),
                page: artistFilter.Page,
                pageSize: artistFilter.PageSize);
        }

        public int GetNoOfRecordsBasedOnFilter(ArtistFilter artistFilter)
        {
            return _artistDAL.GetCount(
                filter: artist =>
                    artist.ArtistName.StartsWith(artistFilter.ArtistNameAndAliasSearchTerm)
                    || artist.ArtistName.Contains(" " + artistFilter.ArtistNameAndAliasSearchTerm)
                    || artist.Aliases.StartsWith(artistFilter.ArtistNameAndAliasSearchTerm)
                    || artist.Aliases.Contains(" " + artistFilter.ArtistNameAndAliasSearchTerm));
        }
    }
}
