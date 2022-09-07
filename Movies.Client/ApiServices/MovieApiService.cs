using IdentityModel.Client;
using Movies.Client.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;

namespace Movies.Client.ApiServices
{
    public class MovieApiService : IMovieApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MovieApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<Movie> Create(Movie movie)
        {
            var httpClient = _httpClientFactory.CreateClient("MovieApiClient");

            var response = await httpClient.PostAsJsonAsync("api/movies/", movie).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Movie>(result)!; 
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Movie> GetById(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("MovieApiClient");
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/movies/GetMovie/{id}/");
            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Movie>(result)!;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var httpClient = _httpClientFactory.CreateClient("MovieApiClient");
            var request = new HttpRequestMessage(HttpMethod.Get, "api/movies/GetMovies/");
            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Movie>>(result)!;


            //var apiClientCredential = new ClientCredentialsTokenRequest()
            //{
            //    Address="https://localhost:7256/connect/token",
            //    Scope= "movieAPI",
            //    ClientId= "movieClient",
            //    ClientSecret = "secret"
            //};

            //var client=new HttpClient();
            //var disco=await client.GetDiscoveryDocumentAsync("https://localhost:7256");
            //if (disco.IsError)
            //{
            //    return new List<Movie>();
            //}

            //var responseToken=await client.RequestClientCredentialsTokenAsync(apiClientCredential);
            //if (responseToken.IsError)
            //{
            //    return new List<Movie>();
            //}

            //var apiClient=new HttpClient();
            //client.SetBearerToken(responseToken.AccessToken);

            //var response=await client.GetAsync("https://localhost:7117/api/movies");
            //response.EnsureSuccessStatusCode();

            //var result=await response.Content.ReadAsStringAsync();
            //return JsonConvert.DeserializeObject<List<Movie>>(result)!;
        }

        public Task<Movie> Update(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
