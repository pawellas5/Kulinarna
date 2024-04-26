using Kulinarna.BusinessLogic.DTOs;
using Kulinarna.Data;
using Kulinarna.Data.Models;
using Microsoft.AspNetCore.Identity;
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


        public IQueryable<RecipeListItemDTO> GetRecipesByName(string name = null)
        {
            if (name != null) name = name.ToLower();
            var recipes = _dbContext.Recipes.Where(r => r.Name.ToLower().Contains(name) || String.IsNullOrEmpty(name))
                .OrderBy(r => r.Name)
                .Select(r => new RecipeListItemDTO { RecipeId = r.Id, Name = r.Name, AuthorId = r.AuthorId, AvgRating = r.AvgRating, AuthorName = r.AuthorName, Content = r.Content.Substring(0, 61) });//Substring is in order to give shortened content to index page

            return recipes;
        }


        public async Task<RecipeDTO> GetRecipeById(int id)
        {
            var recipe = await _dbContext.Recipes
                .Where(r => r.Id == id)
                .Select(r => new RecipeDTO { RecipeId = r.Id, Name = r.Name, Content = r.Content, AuthorId = r.AuthorId, AuthorName = r.AuthorName }).SingleOrDefaultAsync();

            return recipe;
        }

        public async Task Update(RecipeDTO updatedRecipe)
        {
            var recipe = _dbContext.Recipes.FirstOrDefault(r => r.Id == updatedRecipe.RecipeId);
            if (recipe != null)
            {
                recipe.Name = updatedRecipe.Name;
                recipe.Content = updatedRecipe.Content;
                await _dbContext.SaveChangesAsync();
                return;
            }

            throw new ArgumentException("Recipe doesn't exist");
        }
        public async Task<int> Create(RecipeDTO newRecipeDto)
        {
            var newRecipe = new Recipe() { Name = newRecipeDto.Name, Content = newRecipeDto.Content, AuthorId = newRecipeDto.AuthorId, AvgRating = 0.0, AuthorName = newRecipeDto.AuthorName };
            _dbContext.Recipes.Add(newRecipe);
            await _dbContext.SaveChangesAsync();
            return newRecipe.Id;
        }

        public async Task Delete(int id)
        {
            var recipe = _dbContext.Recipes.FirstOrDefault(r => r.Id == id);
            if (recipe != null)
            {
                _dbContext.Recipes.Remove(recipe);
                await _dbContext.SaveChangesAsync();

            }
            return;


        }
        public async Task UpdateAvgRating(int recipeId, double avg)
        {
            var recipe = await _dbContext.Recipes.FirstOrDefaultAsync(r => r.Id == recipeId);

            if (recipe != null)
            {
                recipe.AvgRating = avg;
                await _dbContext.SaveChangesAsync();
            }
        }

        //*********************Pagination************************

        public async Task<IEnumerable<RecipeListItemDTO>> GetPaginatedResult(int currentPage, int pageSize = 10, string name = null)
        {
            var data = GetRecipesByName(name);
            return await data.OrderByDescending(r => r.AvgRating).ThenBy(r => r.Name).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetCount(string name = null)
        {
            return await GetRecipesByName(name).CountAsync();
        }


        //***********************************************************




    }

}
