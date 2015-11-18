using Solution.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.DAL.ArtistRepository.EntityFramework.Mapping;

namespace Solution.DAL.ArtistRepository.EntityFramework.Context
{
    public class SolutionContext : DbContext
    {

        public SolutionContext() : base ("Name=ArtistDatabase")
        {

        }

        public DbSet<Solution.Entities.Artist> Artists { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ArtistMap());
        }
    }
}
