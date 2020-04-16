using MovieManager.Core.Contracts;
using MovieManager.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace MovieManager.Persistence
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRange(IEnumerable<Movie> movies)
        {
            _dbContext.Movies.AddRange(movies);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _dbContext.Movies.ToArray();
        }
    }
}