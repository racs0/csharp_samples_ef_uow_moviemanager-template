using MovieManager.Core.Contracts;
using MovieManager.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;



namespace MovieManager.Persistence
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRange(IEnumerable<Category> categories)
        {
            _dbContext.AddRange(categories);
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbContext.Categories.Include(m => m.Movies).ToArray();
        }
    }
}