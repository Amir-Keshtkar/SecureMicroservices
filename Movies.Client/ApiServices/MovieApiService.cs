using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Movies.Client.Models;

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
            var movies=new List<Movie>();
            movies.Add(new Movie()
            {
                Id=1,
                Genre="Comics",
                Title="asd",
                ImageUrl="images/src",
                Rating="9.2",
                Owner="swn",
                ReleaseDate=DateTime.Now,
            });
            return await Task.FromResult(movies);
        }

        public Task<Movie> Update(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
