using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kulinarna.Web.Pages
{
    public class RateModel : PageModel
    {
        public IActionResult OnGet(int recipeId)
        {
            return RedirectToPage("./Details", new { recipeId = recipeId });
        }
    }
}

