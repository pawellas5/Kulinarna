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
    public class DeleteModel : PageModel
    {
        private readonly RecipeService recipeService;
        private readonly UserManager<ApplicationUser> userManager;

        public RecipeDTO RecipeDTO { get; set; }

        public DeleteModel(RecipeService recipeService, UserManager<ApplicationUser> userManager)
        {
            this.recipeService = recipeService;
            this.userManager = userManager;
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

            if (recipe.AuthorId != userManager.GetUserId(HttpContext.User))
            {
                return RedirectToPage("./AccessDenied");
            }

            else
            {
                await recipeService.Delete(recipeId);
            }
            if (recipe == null)
            {
                return RedirectToPage("./404");
            }
            TempData["Message"] = "Recipe deleted.";
            return RedirectToPage("./Index");
        }
    }
}
