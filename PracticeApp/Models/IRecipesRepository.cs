using System;
using System.Linq;

namespace PracticeApp.Models
{
    public interface IRecipesRepository
    {
        IQueryable<Recipe> Recipes { get; }

        // initiate the CRUD functions
        public void AddRecipe(Recipe r);
        public void EditRecipe(Recipe r);
        public void DeleteRecipe(Recipe r);
    }
}
