using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulinarna.BusinessLogic.DTOs
{
    public class RecipesDTO
    {
        public IEnumerable<RecipeDTO> Recipes { get; private set; }

        public int RecipesCount { get; private set; }

        public RecipesDTO(IEnumerable<RecipeDTO> recipes, int count)
        {
            Recipes = recipes;
            RecipesCount = count;
        }
    }
}
