using MoviesAnalysis.Models;
using Newtonsoft.Json.Linq;

namespace MoviesAnalysis.Services
{
    public class TmdbService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _http;

        public TmdbService(IConfiguration config)
        {
            _config = config;
            _http = new HttpClient();
        }

        public async Task<List<TmdbSearchResult>> SearchMoviesAsync(string query)
        {
            var apiKey = _config["TMDB:ApiKey"];
            var url = $"https://api.themoviedb.org/3/search/movie?api_key={apiKey}&query={query}";
            var response = await _http.GetStringAsync(url);

            var results = JObject.Parse(response)["results"];
            return results.ToObject<List<TmdbSearchResult>>();
        }

        public async Task<TmdbSearchResult> GetMovieDetailsAsync(int tmdbId)
        {
            var apiKey = _config["TMDB:ApiKey"];
            var url = $"https://api.themoviedb.org/3/movie/{tmdbId}?api_key={apiKey}";
            var response = await _http.GetStringAsync(url);

            return JObject.Parse(response).ToObject<TmdbSearchResult>();
        }
    }
}
