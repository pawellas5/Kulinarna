using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulinarna.BusinessLogic.DTOs
{
    public class RatingDTO
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public int RecipeId { get; set; }
        public int Value { get; set; }

    }
}
