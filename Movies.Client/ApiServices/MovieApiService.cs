using IdentityModel.Client;
using Movies.Client.Models;
using Newtonsoft.Json;

namespace Movies.Client.ApiServices
{
    public class MovieApiService : IMovieApiService
    {
        public Task<Movie> Create(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var apiClientCredential = new ClientCredentialsTokenRequest()
            {
                Address="https://localhost:7256/connect/token",
                Scope= "movieAPI",
                ClientId= "movieClient",
                ClientSecret = "secret"
            };

            var client=new HttpClient();
            var disco=await client.GetDiscoveryDocumentAsync("https://localhost:7256");
            if (disco.IsError)
            {
                return new List<Movie>();
            }

            var responseToken=await client.RequestClientCredentialsTokenAsync(apiClientCredential);
            if (responseToken.IsError)
            {
                return new List<Movie>();
            }

            var apiClient=new HttpClient();
            client.SetBearerToken(responseToken.AccessToken);

            var response=await client.GetAsync("https://localhost:7117/api/movies");
            response.EnsureSuccessStatusCode();

            var result=await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Movie>>(result)!;

            //var movies = new List<Movie>();
            //movies.Add(new Movie()
            //{
            //    Id = 1,
            //    Genre = "Comics",
            //    Title = "asd",
            //    ImageUrl = "images/src",
            //    Rating = "9.2",
            //    Owner = "swn",
            //    ReleaseDate = DateTime.Now,
            //});
            //return await Task.FromResult(movies);
        }

        public Task<Movie> Update(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
