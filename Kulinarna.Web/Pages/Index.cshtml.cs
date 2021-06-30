﻿using Kulinarna.BusinessLogic.DTOs;
using Kulinarna.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kulinarna.Web.Pages
{
    public class RecipesModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        private readonly ILogger<RecipesModel> _logger;
        private readonly RecipeService _recipeService;
        public IEnumerable<RecipeListItemDTO> Recipes { get; set; }
        public IEnumerable<RecipeListItemDTO> RecipesByName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public RecipesModel(ILogger<RecipesModel> logger, RecipeService recipeService)
        {
            _logger = logger;
            _recipeService = recipeService;
        }

        public async Task OnGet()
        {
            //var recipes = await _recipeService.GetRecipes(1, 1000);

            //Recipes = recipes.Recipes;
            RecipesByName = await _recipeService.GetRecipesByName(SearchTerm);



        }
    }
}
