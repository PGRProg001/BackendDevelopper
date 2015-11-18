using Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Solution.DAL.ReleaseRepository.musicbrainz
{
    public class MusicBrainzReleaseParser
    {
        public List<Release> GetReleaseInformationFromXmlForArtistId(XmlDocument xmlDoc, string artistId)
        {
            var nsm = new XmlNamespaceManager(xmlDoc.NameTable);
            nsm.AddNamespace("mbz", "http://musicbrainz.org/ns/mmd-2.0#");

            XmlNodeList nodes = xmlDoc.SelectNodes("//mbz:metadata/mbz:release-list/mbz:release", nsm);

            List<Release> releases = new List<Release>();

            foreach (XmlNode node in nodes)
            {
                Release release = new Release();

                release.ReleaseId = node.Attributes["id"].Value;
                release.Title = node.SelectSingleNode("mbz:title", nsm).InnerText;
                release.Status = node.SelectSingleNode("mbz:status", nsm).InnerText;

                // label is optional 

                if (node.SelectSingleNode("mbz:label-info-list/mbz:label-info/mbz:label/mbz:name", nsm) != null)
                    release.Label = node.SelectSingleNode("mbz:label-info-list/mbz:label-info/mbz:label/mbz:name", nsm).InnerText;

                release.NumberOfTracks = System.Int32.Parse(node.SelectSingleNode("mbz:medium-list/mbz:track-count", nsm).InnerText ?? "0");

                // get the other collaborating artists if any

                List<NameCredit> nameCredits = new List<NameCredit>();

                XmlNodeList creditArtists = node.SelectNodes("mbz:artist-credit/mbz:name-credit/mbz:artist", nsm);
                foreach (XmlNode creditArtist in creditArtists)
                {
                    string id = creditArtist.Attributes["id"].Value;

                    // not need to add self as a colaborating artist on one's own release
                    if (id != artistId)
                    {
                        var otherArtist = new NameCredit();
                        otherArtist.Id = id;
                        otherArtist.Name = creditArtist.SelectSingleNode("mbz:name", nsm).InnerText;
                        nameCredits.Add(otherArtist);
                    }
                }
                release.NameCredits = nameCredits;

                releases.Add(release);
            }
            return releases;
        }

        public bool DoesXmlResponseContainReleases(XmlDocument xmlDoc)
        {
            bool containsReleases = false;

            /*  e.g of invalid artist id -> release-list count = 0
                <metadata created="2015-11-17T11:48:08.164Z" xmlns="http://musicbrainz.org/ns/mmd-2.0#" xmlns:ext="http://musicbrainz.org/ns/ext#-2.0">
                    <release-list count="0" offset="0"/>
                </metadata>
             */

            var nsm = new XmlNamespaceManager(xmlDoc.NameTable);
            nsm.AddNamespace("mbz", "http://musicbrainz.org/ns/mmd-2.0#");

            XmlNode releaseListNode = xmlDoc.SelectSingleNode("//mbz:metadata/mbz:release-list", nsm);

            int count = 0;
            System.Int32.TryParse(releaseListNode.Attributes["count"].Value, out count);

            containsReleases = count > 0 ? true : false;

            return containsReleases;
        }
    }
}
