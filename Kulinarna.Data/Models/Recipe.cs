using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulinarna.Data.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Content { get; set; }

        public string AuthorId { get; set; }
        public double AvgRating { get; set; }
        public string AuthorName { get; set; }

    }
}
