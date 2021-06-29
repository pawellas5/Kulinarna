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
        public IActionResult OnGet(int? recipeId)
        {
            if (recipeId.HasValue)
            {
                RecipeDTO = recipeService.GetRecipeById(recipeId.Value);

            }
            else //create
            {
                RecipeDTO = new RecipeDTO();

            }
            if (RecipeDTO == null)
            {
                return RedirectToPage("./404");
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (RecipeDTO.RecipeId > 0)
            {
                await recipeService.Update(RecipeDTO);
            }
            else
            {
                RecipeDTO.RecipeId = await recipeService.Create(RecipeDTO);
            }

            TempData["Message"] = "Recipe saved!";
            return RedirectToPage("./Details", new { recipeID = RecipeDTO.RecipeId });



        }
    }
}
