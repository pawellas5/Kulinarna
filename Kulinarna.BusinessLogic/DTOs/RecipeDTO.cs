﻿using Kulinarna.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulinarna.BusinessLogic.DTOs
{
    public class RecipeDTO
    {
        public int RecipeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }


        public double AvgRating { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }



    }
}
