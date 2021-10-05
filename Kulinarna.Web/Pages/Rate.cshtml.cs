using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kulinarna.BusinessLogic.DTOs;
using Kulinarna.BusinessLogic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kulinarna.Web.Pages
{
    public class RateModel : PageModel
    {
        public string CurrentUserId { get; set; }

        [BindProperty]
        public string Value { get; set; }

        [BindProperty]
        public RatingDTO Rating { get; set; }
        public int RecipeId { get; set; }

        private readonly RecipeService recipeService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RatingService ratingService;

        public RateModel(RecipeService recipeService, UserManager<ApplicationUser> userManager, RatingService ratingService)
        {
            this.recipeService = recipeService;
            this.userManager = userManager;
            this.ratingService = ratingService;
        }


        public void OnGet()
        {
        }
        public IActionResult OnPost(int recipeId)
        {



            CurrentUserId = userManager.GetUserId(HttpContext.User);
            Rating.Value = int.Parse(Value);
            Rating.AuthorId = CurrentUserId;
            Rating.RecipeId = recipeId;

            if (ratingService.RatingExists(Rating.RecipeId, Rating.AuthorId))
            {
                ratingService.UpdateRating(Rating.RecipeId, Rating.AuthorId, Rating.Value);
                recipeService.UpdateAvgRating(recipeId, ratingService.AvgRatingForRecipe(Rating.RecipeId));

            }

            else
            {
                ratingService.AddRating(Rating);
                var avg = ratingService.AvgRatingForRecipe(recipeId);
                recipeService.UpdateAvgRating(recipeId, avg);

            }

            //avg rating updates with every new rating

            TempData["Message"] = "Rating added";
            return RedirectToPage("./Details", new { recipeID = recipeId });
        }
    }
}
