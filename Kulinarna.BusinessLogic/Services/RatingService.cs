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
    public class RatingService
    {

        private readonly KulinarnaDbContext _dbContext;

        public RatingService(KulinarnaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<double> AvgRatingForRecipe(int recipeId)
        {
            var result = await _dbContext.Ratings.Where(r => r.RecipeId == recipeId).Select(r => r.Value).AverageAsync();
            return result;
        }
        /// <summary>
        /// Checks if given user rated given recipe
        /// </summary>
        public async Task<bool> RatingExists(int recipeId, string authorId)
        {
            var result = await _dbContext.Ratings.FirstOrDefaultAsync(r => r.RecipeId == recipeId && r.AuthorId == authorId);
            if (result == null) return false;
            return true;
        }

        //*************************newcode***************************
        public async Task AddRating(RatingDTO newRatingDTO)
        {
            var newRate = new Rating() { AuthorId = newRatingDTO.AuthorId, RecipeId = newRatingDTO.RecipeId, Value = newRatingDTO.Value };
            await _dbContext.Ratings.AddAsync(newRate);
            await _dbContext.SaveChangesAsync();
        }
        //***************************************************************newcode****************************

        public async Task UpdateRating(int recipeId, string authorId, int value)
        {
            var result = _dbContext.Ratings.FirstOrDefault(r => r.RecipeId == recipeId && r.AuthorId == authorId);



            result.Value = value;
            await _dbContext.SaveChangesAsync();


        }


    }
}
