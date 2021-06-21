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
    public class EditModel : PageModel
    {
        private readonly RecipeService recipeService;


        [BindProperty]
        public RecipeDTO RecipeDTO { get; set; }

        public EditModel(RecipeService recipeService)
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
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                recipeService.Update(RecipeDTO);
                recipeService.Commit();
                return RedirectToPage("./Details", new { recipeID = RecipeDTO.RecipeId });
            }


            return Page();

        }
    }
}
