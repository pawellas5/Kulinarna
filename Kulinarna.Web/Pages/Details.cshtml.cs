using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kulinarna.BusinessLogic.DTOs;
using Kulinarna.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kulinarna.Web
{
    public class DetailsModel : PageModel
    {
        private readonly RecipeService recipeService;

        [TempData]
        public string Message { get; set; }

        public RecipeDTO RecipeDTO { get; set; }

        public DetailsModel(RecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        public IActionResult OnGet(int recipeID)
        {
            RecipeDTO = recipeService.GetRecipeById(recipeID);
            if (RecipeDTO == null)
            {
                return RedirectToPage("./404");
            }
            return Page();
        }
    }
}
