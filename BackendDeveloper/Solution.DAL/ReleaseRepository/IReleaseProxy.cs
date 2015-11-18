using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Solution.DAL.ReleaseRepository
{
    public interface IReleaseProxy
    {
        XmlDocument GetXmlResponse(string queryUrl);
    }
}
