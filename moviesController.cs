using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;
using System;
using WebApplication8.services;

namespace WebApplication8
{
    [Route("api/[controller]")]
    [ApiController]
    public class moviesController : ControllerBase
    {
        private readonly movieservice _movieService;
        public moviesController(movieservice movieService) =>
        _movieService = movieService;
        HttpClient client = new HttpClient();
        public async oninit()
        {
            var url = $"https://api.themoviedb.org/3/movie/top_rated?api_key={ api_key }&language=en-US&page=1";
            var response= await _movieService.GetAsync(url)

        }

        [HttpGet]
        public async Task<List<movie>> Get() =>
            await _movieService.GetAsync();


        [HttpGet]
        public async Task<List<movie>> get(string api_key)
        {
            string url = $"https://api.themoviedb.org/3/movie/top_rated?api_key={ api_key }&language=en-US&page=1";
            string response = await client.GetStringAsync(url);
           
            string result = JObject.Parse(response)["results"].ToString(Formatting.None);
            List<movie> model = JsonConvert.DeserializeObject<List<movie>>(result);
            return model;
        }
        [HttpGet("{movie_id}")]
        
        public async Task<moviedetails> getdetails(string movie_id)
        {
            var url = $"https://api.themoviedb.org/3/movie/{ movie_id }?api_key=ddf9442c69a1aa97524b66e3cba8b9b0&language=en-US&page=1";
            string response = await client.GetStringAsync(url);
            
            var obj = JsonConvert.DeserializeObject<moviedetails>(response);
            return obj;
        }

        
        [HttpGet("toptvshows")]
        public async Task<List<tvshow>> gettoptvshows(string api_key)
        {
            string url = $"https://api.themoviedb.org/3/tv/top_rated?api_key={ api_key }&language=en-US&page=1";
            string response = await client.GetStringAsync(url);

            string result = JObject.Parse(response)["results"].ToString(Formatting.None);
            List<tvshow>? model = JsonConvert.DeserializeObject<List<tvshow>>(result);
            return model;
        }
        [HttpPost]
        public async Task<JsonResult> Createmovie ([FromBody]List<movie>  movielist) {
        return
        }

    }
}
