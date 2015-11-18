using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.Entities;

namespace Solution.DAL.ArtistRepository.EntityFramework.Mapping
{
    public class ArtistMap : EntityTypeConfiguration<Artist>
    {
        public ArtistMap()
        {
            HasKey(t => t.UniqueIdentifier);
            ToTable("Artist");

            Property(t => t.ArtistName).HasColumnName("ArtistName");
            Property(t => t.UniqueIdentifier).HasColumnName("UniqueIdentifier");
            Property(t => t.Country).HasColumnName("Country");
            Property(t => t.Aliases).HasColumnName("Aliases");
        }
    }
}
