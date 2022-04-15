using System;
using System.ComponentModel.DataAnnotations;

namespace PracticeApp.Models
{
    public class Recipe
    {
        [Key]
        [Required]
        public int RecipeID { get; set; }

        [Required]
        public string RecipeName { get; set; }

        [Required]
        public string RecipeType { get; set; }

        [Required]
        public int NumIngredients { get; set; }

        public double PrepTimeInMinutes { get; set; }

        public int ServingSize { get; set; }

        public string Notes { get; set; }
    }
}
