using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.Service;
using Solution.Entities;
using Solution.DAL.ArtistRepository;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Solution.DAL.ReleaseRepository.musicbrainz;


namespace Test.Tests
{
    [TestClass]
    public class MusicBrainzReleaseParserTest
    {
        string _path = @"Z:\VS2013\BackendDeveloper\Test\Tests\TestRelease.xml"; //need to change
        string _artistId = "c44e9c22-ef82-4a77-9bcd-af6c958446d6";

        [TestMethod]
        public void ShouldContainOneReleaseForTestXML()
        {
            //arange
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_path);

            List<Release> releases = new List<Release>();
            MusicBrainzReleaseParser mbzParser = new MusicBrainzReleaseParser();

            //act
            releases =  mbzParser.GetReleaseInformationFromXmlForArtistId(xmlDoc, _artistId);

            //assert
            int expectedNoReleases = 1;
            Assert.AreEqual(expectedNoReleases, releases.Count);
        }

        [TestMethod]
        public void ShouldContainReleaseWith_releaseId_title_status_label_NoTracks_ForTestXML()
        {
            //arange
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_path);

            List<Release> releases = new List<Release>();
            MusicBrainzReleaseParser mbzParser = new MusicBrainzReleaseParser();

            //act
            releases = mbzParser.GetReleaseInformationFromXmlForArtistId(xmlDoc, _artistId);

            //assert
            Release expectedRelease = new Release();
            expectedRelease.Title = "Dharohar Project, Laura Marling and Mumford & Sons";
            expectedRelease.Status = "Official";
            expectedRelease.ReleaseId = "4cf8c4b7-2471-46cd-8865-f2a744f26e8d";
            expectedRelease.Label = "Glassnote Records";
            expectedRelease.NumberOfTracks = 4;
            
            // too tired to implement IComprarer -> just bruteforced

            Release actualRelese = new Release();
            actualRelese = releases[0];

            bool areValuesEqual =
                expectedRelease.Title == actualRelese.Title && expectedRelease.Status == actualRelese.Status
                && expectedRelease.ReleaseId == actualRelese.ReleaseId && expectedRelease.Label == actualRelese.Label
                && expectedRelease.NumberOfTracks == actualRelese.NumberOfTracks;

            Assert.AreEqual(true, areValuesEqual);
        }
        [TestMethod]
        public void ShouldContainReleaseWith_2_CreditArtists_ForTestXML()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_path);

            List<Release> releases = new List<Release>();
            MusicBrainzReleaseParser mbzParser = new MusicBrainzReleaseParser();

            //act
            releases = mbzParser.GetReleaseInformationFromXmlForArtistId(xmlDoc, _artistId);

            //assert
            List<NameCredit> expectedNameArtists = new List<NameCredit>();
            expectedNameArtists.Add(new NameCredit { Id = "a015074b-e109-412d-9f7b-170b80a0ebbd", Name = "Dharohar Project" });
            expectedNameArtists.Add(new NameCredit { Id = "cd9713d6-6e5f-4143-9412-4d12b7bd47f2", Name = "Laura Marling" });


            List<NameCredit> actualNameArtists = new List<NameCredit>();

            foreach (var creditArtist in releases[0].NameCredits)
            {
                NameCredit nameCredit = new NameCredit { Id = creditArtist.Id, Name = creditArtist.Name };
                actualNameArtists.Add(nameCredit);
            }

            bool test =expectedNameArtists[0].Id == actualNameArtists[0].Id && expectedNameArtists[1].Id == actualNameArtists[1].Id
                    && expectedNameArtists[0].Name == actualNameArtists[0].Name && expectedNameArtists[1].Name == actualNameArtists[1].Name
                    && expectedNameArtists.Count == actualNameArtists.Count;

            Assert.AreEqual(true, test);
        }
    }
}
