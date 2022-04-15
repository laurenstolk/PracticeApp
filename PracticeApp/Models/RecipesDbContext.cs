using System;
using Microsoft.EntityFrameworkCore;

namespace PracticeApp.Models
{
    public class RecipesDbContext : DbContext
    {
        // constructor
        public RecipesDbContext(DbContextOptions<RecipesDbContext> options) : base (options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }

        // seed the data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Recipe>().HasData(
                new Recipe
                {
                    RecipeID = 1,
                    RecipeName = "Dirty Diet Coke",
                    RecipeType = "Drink",
                    NumIngredients = 3,
                    PrepTimeInMinutes = 2,
                    ServingSize = 1,
                    Notes = "Best in a large stanley cup. Enjoy throughout the day.",
                }
            );
        }
    }
}
