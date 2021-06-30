using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kulinarna.BusinessLogic.DTOs;
using Kulinarna.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kulinarna.Web.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly RecipeService recipeService;
        public RecipeDTO RecipeDTO { get; set; }

        public DeleteModel(RecipeService recipeService)
        {
            this.recipeService = recipeService;
        }
        public IActionResult OnGet(int recipeId)
        {
            RecipeDTO = recipeService.GetRecipeById(recipeId);
            if (RecipeDTO == null)
            {
                return RedirectToPage("./404");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int recipeId)
        {
            var recipe = recipeService.GetRecipeById(recipeId);

            await recipeService.Delete(recipeId);
            if (recipe == null)
            {
                return RedirectToPage("./404");
            }
            TempData["Message"] = "Recipe deleted.";
            return RedirectToPage("./Index");
        }
    }
}
