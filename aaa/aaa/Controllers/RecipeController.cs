using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace aaa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        //private  List<Recipe> recipes = new List<Recipe>
        //{
        //    new Recipe { Id = 1, Name = "Pasta", CategoryId = 1, PreparationTime = 30, Difficulty = 2, Ingredients = new string[] { "Pasta", "Tomato Sauce", "Cheese" }, Instructions = new string[] { "Boil pasta", "Mix with tomato sauce", "Sprinkle cheese on top" }, UserId = 1, Image = "pasta.jpg" },
        //    new Recipe { Id = 2, Name = "Salad", CategoryId = 2, PreparationTime = 15, Difficulty = 1, Ingredients = new string[] { "Lettuce", "Tomatoes", "Cucumbers", "Dressing" }, Instructions = new string[] { "Chop vegetables", "Mix with dressing" }, UserId = 2, Image = "salad.jpg" },
        //    new Recipe { Id = 3, Name = "Grilled Chicken", CategoryId = 3, PreparationTime = 45, Difficulty = 3, Ingredients = new string[] { "Chicken breasts", "Marinade", "Vegetables" }, Instructions = new string[] { "Marinate chicken", "Grill until cooked", "Serve with grilled vegetables" }, UserId = 1, Image = "chicken.jpg" },
        //    new Recipe { Id = 4, Name = "Chocolate Cake", CategoryId = 4, PreparationTime = 60, Difficulty = 4,  Ingredients = new string[] { "Flour", "Sugar", "Cocoa", "Eggs", "Milk" }, Instructions = new string[] { "Mix dry ingredients", "Add wet ingredients", "Bake in preheated oven" }, UserId = 2, Image = "cake.jpg" }
        //};

        // GET: api/Recipe
        [HttpGet]
        public IActionResult Get([FromServices] List<Recipe> recipes)
        {
            return Ok(recipes);
        }

        // GET: api/Recipe/5
        [HttpGet("{id}")]
        public IActionResult Get([FromServices] List<Recipe> recipes,int id)
        {
            Recipe recipe = recipes.Find(r => r.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        // POST: api/Recipe
        [HttpPost]
        public IActionResult Post([FromServices] List<Recipe> recipes,[FromBody] Recipe recipe)
        {
            if (recipe == null)
            {
                return BadRequest();
            }

            recipe.Id = recipes.Count + 1;
            //recipe.CreationDate = DateTime.Now;
            recipe.CategoryId = recipe.CategoryId % 5;
            recipes.Add(recipe);

            return CreatedAtAction(nameof(Get), new { id = recipe.Id }, recipe);
        }

        // PUT: api/Recipe/5
        [HttpPut("{id}")]
        public IActionResult Put([FromServices] List<Recipe> recipes,int id, [FromBody] Recipe updatedRecipe)
        {
            Recipe existingRecipe = recipes.Find(r => r.Id == id);
            if (existingRecipe == null)
            {
                return NotFound();
            }

            existingRecipe.Name = updatedRecipe.Name;
            existingRecipe.CategoryId = updatedRecipe.CategoryId;
            existingRecipe.Difficulty = updatedRecipe.Difficulty;
            existingRecipe.Id = updatedRecipe.Id;
            existingRecipe.RecipeCode=updatedRecipe.RecipeCode;
            existingRecipe.PreparationTime = updatedRecipe.PreparationTime;

            existingRecipe.Difficulty = updatedRecipe.Difficulty;
            existingRecipe.Ingredients = updatedRecipe.Ingredients;
            existingRecipe.Instructions = updatedRecipe.Instructions;
            existingRecipe.UserId = updatedRecipe.UserId;
            existingRecipe.Image = updatedRecipe.Image;

            return NoContent();
        }

        // DELETE: api/Recipe/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromServices] List<Recipe> recipes,int id)
        {
            Recipe recipe = recipes.Find(r => r.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            recipes.Remove(recipe);
            return NoContent();
        }
    }
}
