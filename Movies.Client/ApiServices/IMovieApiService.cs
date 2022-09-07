using Movies.Client.Models;

namespace Movies.Client.ApiServices
{
    public interface IMovieApiService
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetById(int id);
        Task<Movie> Create(Movie movie);
        Task<Movie> Update(Movie movie);
        Task Delete(string id);
    }
}
