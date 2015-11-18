# BackendDevelopper

##Quick Comments and Notes :

##Notes
1. There are actually 15 artists in the excel file, not 16.
2. /artist/search/joh should return John Coltrane, John Mayer, Johnny Cash, Elton John and John Frusciante Not correct. Based on the excel file, there are 6 matches for a Name or alias having a name/alias starting with joh - John Coltrane, John Mayer, Johnny Cash, Jack Johnson, John Frusciante and Elton John.
3. /artist/6c44e9c22-ef82-4a77-9bcd-af6c958446d6/albums will return the first 10 albums from Mumford & Sons. The artist id is not valid. The proper id for Mumford & Sons is c44e9c22-ef82-4a77-9bcd-af6c958446d6.

##Database Setup
The Sql commands are in the file - db creation.sql in the SQL Scripts folder in the solution.
The Connection string name in ArtistDatabase.

##Tests
1. I have stick with MS Test. I had a hell of time trying to get NUnit to work with VS2013 Update 4.
2. Kindly adjust the path to point to the TestRelease.xml this xml file is used to test the Par
For the Test
Kindly adjust the path to point to the TestRelease.xml in the Tests folder in the Test Solution. This file is used in the MusicBrainzReleaseParserTest.cs. In the variable _path. [I don’t test files to the ‘copy to output folder’]

##General Comment
I wasted a lot of time trying to get the tooling to work [NUnit and Ninject]. Ninject requires version 3.2.1 for the Ninject.Web.Api to work. Newer versions did not work.

Inmplemented End Points
* /artist/search/{search_criteria}/{page_number}/{page_size}

* /artist/{artist_id}/albums

Attached is SolutuinOverview.pdf which gives a high level view of the solution organization.
