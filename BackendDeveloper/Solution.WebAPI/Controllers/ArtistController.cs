using Solution.WebAPI.Models;
using Solution.WebAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace Solution.WebAPI.Controllers
{
    public class ArtistController : ApiController
    {
        IArtistServiceClient _artistServiceClient;
        IReleaseServiceClient _releaseServiceClient;

        public ArtistController(IArtistServiceClient artistServiceClient, IReleaseServiceClient releaseServiceClient)
        {
            _artistServiceClient = artistServiceClient;
            _releaseServiceClient = releaseServiceClient;
        }

        [HttpGet]
        [Route("artist/search/{search_criteria}/{page_number:int}/{page_size:int}")]
        public HttpResponseMessage Search(string search_criteria, int page_number, int page_size)
        {
            if (page_number < 1)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "page_number cannot be less than 1");
            if (page_size < 1)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "page_size cannot be less than 1");

            ResultViewModel results = new ResultViewModel();
 
            try
            {
                results = _artistServiceClient.GetResultsBasedOnArtistNameNAliasSearch(search_criteria, page_number, page_size);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Oops - Something unexpected happened.");
            }

            if (results.Results.Count == 0)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No matching records found.");

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [HttpGet]
        [Route("artist/{artist_id}/albums")]
        public HttpResponseMessage GetReleasesByArtistID(string artist_id)
        {
            Regex regex = new Regex("^[0-9a-f/-]{36}$");
            if (!regex.IsMatch(artist_id.ToLower()))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "atrist_id is not in the correct format.");

            //ReleaseServiceClient _releaseServiceClient = new ReleaseServiceClient(ReleaseManager);

            List<Release> releaseList = new List<Release>();
            try
            {
                releaseList = _releaseServiceClient.GetReleasesByArtistId(artist_id);
            }
            catch (ArgumentException)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "artist_id not in system.");
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Oops - something unexpected happened.");
            }

            ReleaseViewModel releases = new ReleaseViewModel();
            releases.releases = releaseList;
            return Request.CreateResponse(HttpStatusCode.OK, releases);
        }
    }
}
