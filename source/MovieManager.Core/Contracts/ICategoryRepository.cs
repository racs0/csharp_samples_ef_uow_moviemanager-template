﻿using MovieManager.Core.Entities;
using System.Collections.Generic;

namespace MovieManager.Core.Contracts
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        void AddRange(IEnumerable<Category> categories);
    }
}
