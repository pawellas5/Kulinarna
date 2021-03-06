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

namespace Kulinarna.Web.Pages
{
    public class EditModel : PageModel
    {
        private readonly RecipeService recipeService;

        private readonly UserManager<ApplicationUser> userManager;

        [BindProperty]
        public RecipeDTO RecipeDTO { get; set; }

        public EditModel(RecipeService recipeService, UserManager<ApplicationUser> userManager)
        {
            this.recipeService = recipeService;
            this.userManager = userManager;
        }
        public async Task<IActionResult> OnGet(int? recipeId)
        {

            if (recipeId.HasValue)
            {
                RecipeDTO = await recipeService.GetRecipeById(recipeId.Value);

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
                if (RecipeDTO.AuthorId != userManager.GetUserId(HttpContext.User))
                {
                    return RedirectToPage("./AccessDenied");
                }

                else
                {
                    await recipeService.Update(RecipeDTO);

                }
            }
            else
            {
                RecipeDTO.AuthorId = userManager.GetUserId(HttpContext.User);
                RecipeDTO.AuthorName = userManager.Users.FirstOrDefault(r => r.Id == RecipeDTO.AuthorId).FullName;

                RecipeDTO.RecipeId = await recipeService.Create(RecipeDTO);
            }

            TempData["Message"] = "Recipe saved!";
            return RedirectToPage("./Details", new { recipeID = RecipeDTO.RecipeId });



        }
    }
}
