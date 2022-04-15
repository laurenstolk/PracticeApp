using System;
using System.Linq;

namespace PracticeApp.Models
{
    // implements the IRecipesRepository
    public class EFRecipesRepository : IRecipesRepository
    {
        private RecipesDbContext context { get; set; }

        public EFRecipesRepository (RecipesDbContext temp)
        {
            context = temp;
        }

        public IQueryable<Recipe> Recipes => context.Recipes;

        public void AddRecipe(Recipe r)
        {
            context.Add(r);
            context.SaveChanges();
        }

        public void EditRecipe(Recipe r)
        {
            context.Update(r);
            context.SaveChanges();
        }

        public void DeleteRecipe(Recipe r)
        {
            context.Remove(r);
            context.SaveChanges();
        }

    }
}
