using Kulinarna.BusinessLogic.DTOs;
using Kulinarna.Data;
using Kulinarna.Data.Models;
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

        public double AvgRatingForRecipe(int recipeId)
        {
            var result = _dbContext.Ratings.Where(r => r.RecipeId == recipeId).Select(r => r.Value).Average();
            return result;
        }
        //******************************************checks if proper rating exists
        public bool RatingExists(int recipeId, string authorId)
        {
            var result = _dbContext.Ratings.FirstOrDefault(r => r.RecipeId == recipeId && r.AuthorId == authorId);
            if (result == null) return false;
            return true;
        }

        //*************************newcode***************************
        public void AddRating(RatingDTO newRatingDTO)
        {
            var newRate = new Rating() { AuthorId = newRatingDTO.AuthorId, RecipeId = newRatingDTO.RecipeId, Value = newRatingDTO.Value };
            _dbContext.Ratings.Add(newRate);
            _dbContext.SaveChanges();
        }
        //***************************************************************newcode****************************

        public void UpdateRating(int recipeId, string authorId, int value)
        {
            var result = _dbContext.Ratings.FirstOrDefault(r => r.RecipeId == recipeId && r.AuthorId == authorId);

            if (result != null)
            {
                result.Value = value;

            }
        }


    }
}
