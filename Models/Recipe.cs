//PROG6221-POE Part 2 Liam Knipe ST10355049
// References: https://learn.microsoft.com/en-us/dotnet/standard/events/ , https://www.c-sharpcorner.com/blogs/delegateinc-sharp-in-a-simple-way

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static ST10355049_PROG6221_POEPart2_LiamKnipe.Managers.RecipeManager;

namespace ST10355049_PROG6221_POEPart2_LiamKnipe.Models
{
    // The Recipe class represents a recipe with a name, ingredients, and steps.
    internal class Recipe
    {
        // Properties for the recipe's name, ingredients, and steps.
        public string Name { get; }
        public Ingredient[] Ingredients { get; }
        public string[] Steps { get; }

        public int OriginalTotalCalories { get; set; } // Stores the original total calories

        // Event that is triggered when the total calories of the recipe exceed a certain limit.
        public event ExceededCaloriesHandler OnExceededCalories;

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Recipe constructor takes 2 parameters: ingredients and steps. The ingredients parameter is an array of Ingredient objects, and the steps parameter is an array of string objects.
        //The constructor initialises the Ingredients and Steps properties with the values passed in.
        public Recipe(string name, Ingredient[] ingredients, string[] steps)
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Method to calculate the total calories of the recipe.
        public int TotalCalories()
        {
            int total = Ingredients.Sum(i => i.Calories);
            if (total > 300)
            {
                OnExceededCalories?.Invoke($"Warning: The recipe {Name} exceeds 300 calories.");
            }
            return total;
        }

    }
}
// End of file
