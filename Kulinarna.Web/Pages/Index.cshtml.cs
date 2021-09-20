using Kulinarna.BusinessLogic.DTOs;
using Kulinarna.BusinessLogic.Services;
using Kulinarna.Data.Models;
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

        //********Pagination*****************************************

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));


        //**************************************************8



        [TempData]
        public string Message { get; set; }



        private readonly ILogger<RecipesModel> _logger;
        private readonly RecipeService _recipeService;
        private readonly UserManager<ApplicationUser> userManager;

        public IEnumerable<RecipeListItemDTO> Recipes { get; set; }
        public IEnumerable<RecipeListItemDTO> RecipesByName { get; set; }



        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public string CurrentUserId { get; set; }

        public RecipesModel(ILogger<RecipesModel> logger, RecipeService recipeService, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _recipeService = recipeService;
            this.userManager = userManager;
        }


        public async Task OnGet()
        {
            //old version
            CurrentUserId = userManager.GetUserId(HttpContext.User);



            //var recipes = await _recipeService.GetRecipes(1, 1000);

            //old version
            //RecipesByName = await _recipeService.GetRecipesByName(SearchTerm); //old searching version


            //**************************Pagination******************************************
            RecipesByName = await _recipeService.GetPaginatedResult(CurrentPage, PageSize, SearchTerm);
            Count = await _recipeService.GetCount(SearchTerm);



            //*****************************************************************************8*



        }


    }
}
