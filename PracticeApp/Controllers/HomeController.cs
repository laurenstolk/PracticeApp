using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PracticeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace PracticeApp.Controllers
{
    public class HomeController : Controller
    {
        private IRecipesRepository repo;

        public HomeController(IRecipesRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewRecipes()
        {
            var x = repo.Recipes
                .OrderBy(x => x.RecipeID)
                .ToList();

            return View(x);
        }

        [HttpGet]
        public IActionResult AddRecipe()
        {
            Recipe recipe = new Recipe(); // create a new recipe
            ViewBag.Recipes = repo.Recipes.ToList(); // pass in all current recipes
            return View("EditRecipe", recipe);
        }

        [HttpPost]
        public IActionResult AddRecipe(Recipe r)
        {
            if (ModelState.IsValid) // check if data validation is met
            {
                repo.AddRecipe(r);
                return RedirectToAction("ViewRecipes");
            }
            else
            {
                ViewBag.Recipes = repo.Recipes.ToList(); // pass in all current recipes
                return View(r);
            }
        }

        [HttpGet]
        public IActionResult EditRecipe(int recipeid)
        {
            var recipe = repo.Recipes.Single(x => x.RecipeID == recipeid);
            return View(recipe);
        }

        [HttpPost]
        public IActionResult EditRecipe(Recipe r)
        {
            repo.EditRecipe(r);
            return RedirectToAction("ViewRecipes"); // return to all recipes page
        }

        public IActionResult DeleteRecipe(int recipeid)
        {
            var recipe = repo.Recipes.Single(x => x.RecipeID == recipeid);
            repo.DeleteRecipe(recipe);
            return RedirectToAction("ViewRecipes"); // return to all recipes page
        }

    }
}
