using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.Service;
using Solution.Entities;
using Solution.DAL.ArtistRepository;
using System.Collections.Generic;
using System.Linq;
using Solution.DAL.ReleaseRepository.musicbrainz;

namespace Test
{
    [TestClass]
    public class ReleaseManagerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldGetAnArgumetExceptionIfSuppliedWithAnEronousArtistId()
        {
            //arrange
            ReleaseManager releaseManager = new ReleaseManager(new MusicBrainzRepository());
            List<Release> releases = new List<Release>();

            //act
            releases = releaseManager.GetReleasesByArtistId("lkhlkhjlkjhoihyugjkgoio");
            //ArgumentException
        }

        [TestMethod]
        public void ShouldGetAListOf10ReleasesForArtist_Mumford_Sons()
        {
            //arrange
            ReleaseManager releaseManager = new ReleaseManager(new MusicBrainzRepository());
            List<Release> releases = new List<Release>();

            //act
            releases = releaseManager.GetReleasesByArtistId("c44e9c22-ef82-4a77-9bcd-af6c958446d6");
            
            //assert
            int expectedNoReleases = 10;
            int actualNoReleases = releases.Count;

            Assert.AreEqual(expectedNoReleases, actualNoReleases);
        }
    }
}
