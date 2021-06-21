using Kulinarna.BusinessLogic.DTOs;
using Kulinarna.Data;
using Kulinarna.Data.Models;
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


        public async Task<IEnumerable<RecipeListItemDTO>> GetRecipes(int pageNumber, int pageSize)
        {
            var recipes = await _dbContext.Recipes.Skip(pageSize * (pageNumber - 1)).Take(pageSize)
                .Select(r => new RecipeListItemDTO { RecipeId = r.Id, Name = r.Name }).ToListAsync();
            return recipes;
        }


        public async Task<IEnumerable<RecipeListItemDTO>> GetRecipesByName(string name = null)
        {
            var recipes = await _dbContext.Recipes.Where(r => r.Name.Contains(name) || String.IsNullOrEmpty(name))
                .OrderBy(r => r.Name)
                .Select(r => new RecipeListItemDTO { RecipeId = r.Id, Name = r.Name }).ToListAsync();
            return recipes;
        }
        //???????????????????????
        public RecipeDTO GetRecipeById(int id)
        {
            var recipes = _dbContext.Recipes
                .Where(r => r.Id == id)
                .Select(r => new RecipeDTO { RecipeId = r.Id, Name = r.Name, Content = r.Content }).SingleOrDefault();

            return recipes;
        }
        //????????????????????????????

        public RecipeDTO Update(RecipeDTO updatedRecipe)
        {
            var recipe = _dbContext.Recipes.Where(r => r.Id == updatedRecipe.RecipeId)
                                           .Select(r => new RecipeDTO()).FirstOrDefault();//because when using only FirstOrDefault there is a problem with types
            if (recipe != null)
            {
                recipe.Name = updatedRecipe.Name;
                recipe.Content = updatedRecipe.Content;

            }
            return recipe;
        }


        public int Commit()
        {
            return 0;
        }

    }

}
