using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Solution.DAL.ReleaseRepository.musicbrainz
{
    public class MusicBrainzRepository : IReleaseProxy
    {
        public XmlDocument GetXmlResponse(string queryUrl)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(queryUrl);

            return xmlDoc;
        }
    }
}
