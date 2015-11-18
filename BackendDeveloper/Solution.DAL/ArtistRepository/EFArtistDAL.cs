using Solution.DAL.ArtistRepository.EntityFramework.Context;
using Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.ArtistRepository
{
    public class EFArtistDAL : EFEntityRepositoryBase<Artist, SolutionContext>, IArtistDAL
    {
    }
}
