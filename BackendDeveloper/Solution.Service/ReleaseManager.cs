using Solution.DAL.ReleaseRepository;
using Solution.DAL.ReleaseRepository.musicbrainz;
using Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Solution.Service
{
    public class ReleaseManager : IReleaseManager
    {
        IReleaseProxy _releseProxy;// = new MusicBrainzReleaseRepository();

        public ReleaseManager(IReleaseProxy releaseProxy)
        {
            _releseProxy = releaseProxy;
        }

        public List<Release> GetReleasesByArtistId(string artistId)
        {
            string url = "http://musicbrainz.org/ws/2/release/?query=arid:" + artistId + "&limit=10";

           
            XmlDocument xmlResponse = new XmlDocument();
            xmlResponse = _releseProxy.GetXmlResponse(url);

            MusicBrainzReleaseParser releaseParser = new MusicBrainzReleaseParser();

            if (!releaseParser.DoesXmlResponseContainReleases(xmlResponse))
            {
                throw new ArgumentException("artist_id is not in musicbrainz.org repository");
            }

            List<Release> releases = new List<Release>();
            releases = releaseParser.GetReleaseInformationFromXmlForArtistId(xmlResponse, artistId);

            return releases;
        }
    }
}
