using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulinarna.BusinessLogic.DTOs
{
    public class RecipeListItemDTO
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string AuthorId { get; set; }
        public string Content { get; set; }


    }
}
