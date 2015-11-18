using Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.ArtistRepository
{
    // communication with the SERVICE LAYER -> no dependence on ORM or DATA access layer
    public interface IArtistDAL : IEntityRepository<Artist>
    {

    }
}
