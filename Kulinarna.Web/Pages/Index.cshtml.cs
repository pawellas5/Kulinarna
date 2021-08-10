using Kulinarna.BusinessLogic.DTOs;
using Kulinarna.BusinessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kulinarna.Web.Pages
{
    [AllowAnonymous]
    public class RecipesModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        private readonly ILogger<RecipesModel> _logger;
        private readonly RecipeService _recipeService;
        private readonly UserManager<ApplicationUser> userManager;
        public string CurrentUserId { get; set; }


        public IEnumerable<RecipeListItemDTO> Recipes { get; set; }
        public IEnumerable<RecipeListItemDTO> RecipesByName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public RecipesModel(ILogger<RecipesModel> logger, RecipeService recipeService, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _recipeService = recipeService;
            this.userManager = userManager;
        }


        public async Task OnGet()
        {


            CurrentUserId = userManager.GetUserId(HttpContext.User);





            //var recipes = await _recipeService.GetRecipes(1, 1000);

            //Recipes = recipes.Recipes;
            RecipesByName = await _recipeService.GetRecipesByName(SearchTerm);



        }
    }
}
