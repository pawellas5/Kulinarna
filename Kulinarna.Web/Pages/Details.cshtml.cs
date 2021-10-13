using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kulinarna.BusinessLogic.DTOs;
using Kulinarna.BusinessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kulinarna.Web
{

    [AllowAnonymous]
    public class DetailsModel : PageModel
    {
        private readonly RecipeService recipeService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RatingService ratingService;

        [TempData]
        public string Message { get; set; }

        public string CurrentUserId { get; set; }

        [BindProperty]
        public string Value { get; set; }

        [BindProperty]
        public RatingDTO Rating { get; set; }

        public RecipeDTO RecipeDTO { get; set; }

        public DetailsModel(RecipeService recipeService, UserManager<ApplicationUser> userManager, RatingService ratingService)
        {
            this.recipeService = recipeService;
            this.userManager = userManager;
            this.ratingService = ratingService;
        }

        public async Task<IActionResult> OnGet(int recipeId)
        {
            CurrentUserId = userManager.GetUserId(HttpContext.User);
            RecipeDTO = await recipeService.GetRecipeById(recipeId);
            if (RecipeDTO == null)
            {
                return RedirectToPage("./404");
            }

            return Page();
        }


        public async Task<IActionResult> OnPost(int recipeId)
        {
            RecipeDTO = await recipeService.GetRecipeById(recipeId);
            if (RecipeDTO == null)
            {
                return RedirectToPage("./404");
            }


            CurrentUserId = userManager.GetUserId(HttpContext.User);
            if (CurrentUserId == null)
            {
                return RedirectToPage("Rate", new { recipeId });//Rate page is made for authorize (because this page needs authorization) and redirect back to details page
            }
            if (RecipeDTO.AuthorId == CurrentUserId)
            {
                return RedirectToPage("./AccessDenied");
            }
            Rating.Value = int.Parse(Value);
            Rating.AuthorId = CurrentUserId;
            Rating.RecipeId = recipeId;

            if (await ratingService.RatingExists(Rating.RecipeId, Rating.AuthorId))
            {
                await ratingService.UpdateRating(Rating.RecipeId, Rating.AuthorId, Rating.Value);
                await recipeService.UpdateAvgRating(recipeId, await ratingService.AvgRatingForRecipe(Rating.RecipeId));

            }

            else
            {
                await ratingService.AddRating(Rating);
                var avg = await ratingService.AvgRatingForRecipe(recipeId);
                await recipeService.UpdateAvgRating(recipeId, avg);

            }

            //avg rating updates with every new rating

            TempData["Message"] = "Rating added";
            return RedirectToPage("./Details", new { recipeID = recipeId });
        }
    }
}
