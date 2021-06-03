using Kulinarna.BusinessLogic.DTOs;
using Kulinarna.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulinarna.BusinessLogic.Services
{
    public class RecipeService
    {
        private readonly KulinarnaDbContext _dbContext;

        public RecipeService(KulinarnaDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<RecipesDTO> GetRecipes(int pageNumber, int pageSize)
        {
            var recipes = await _dbContext.Recipes.Skip(pageSize * (pageNumber-1)).Take(pageSize)
                .Select(r => new RecipeDTO { Name = r.Name, Content = r.Content, Author = null })
                .ToListAsync();
            return new RecipesDTO(recipes, recipes.Count());
        }
    }
}
