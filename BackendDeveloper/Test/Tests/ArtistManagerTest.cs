using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.Service;
using Solution.Entities;
using Solution.DAL.ArtistRepository;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestClass]
    public class ArtistManagerTest
    {
        [TestMethod]
        public void ShouldRetunAListContainingLadyGaGaBasedOnFilterForGa()
        {
            //arange
            ArtistManager artistManager = new ArtistManager(new EFArtistDAL());
            var artistReturnedList = new List<Artist>();
            var artistFilter = new ArtistFilter();
            artistFilter.ArtistNameAndAliasSearchTerm = "ga";

            //act
            artistReturnedList = artistManager.GetAllRecordsBasedOnFilter(artistFilter);

            //assert
            string actual = artistReturnedList[0].ArtistName;
            string expected = "Lady Gaga";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ShouldRetunAListContaining6ArtistsBasedOnFilterForJoh()
        {
            //arange
            ArtistManager artistManager = new ArtistManager(new EFArtistDAL());
            var artistReturnedList = new List<Artist>();
            var artistFilter = new ArtistFilter();
            artistFilter.ArtistNameAndAliasSearchTerm = "Joh";

            List<String> expectedNames = new List<string>();
            expectedNames.Add("John Mayer");
            expectedNames.Add("Johnny Cash");
            expectedNames.Add("Jack Johnson");
            expectedNames.Add("John Coltrane");
            expectedNames.Add("Elton John");
            expectedNames.Add("John Frusciante");

            //act
            artistReturnedList = artistManager.GetAllRecordsBasedOnFilter(artistFilter);

            List<string> actualNames = new List<string>();
            foreach(var artist in artistReturnedList)
            {
                actualNames.Add(artist.ArtistName);
            }

            // same number of artist and same artits (regardless of order)

            bool test = expectedNames.All(actualNames.Contains) && expectedNames.Count == actualNames.Count;

            //assert
            Assert.AreEqual(true, test);
        }
        [TestMethod]
        public void ShouldRetunAListContaining0ArtistsBasedOnFilterForZXY()
        {
            //arange
            ArtistManager artistManager = new ArtistManager(new EFArtistDAL());
            var artistReturnedList = new List<Artist>();
            var artistFilter = new ArtistFilter();
            artistFilter.ArtistNameAndAliasSearchTerm = "zyz";

            //act
            artistReturnedList = artistManager.GetAllRecordsBasedOnFilter(artistFilter);

            //assert
            int actual = artistReturnedList.Count;
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }
    }
}
