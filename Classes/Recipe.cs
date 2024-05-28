using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ST10355049_PROG6221_POEPart1_LiamKnipe.Classes
{
    internal class Recipe
    {
        //The Ingredients property is a public array of Ingredient objects. The property can be read but the array itself cannot be modified directly.
        public Ingredient[] Ingredients { get; }

        //The Steps property is a public array of string objects. This property can be read but the array itself cannot be modified.
        public string[] Steps { get; }

        //Recipe constructor takes 2 parameters: ingredients and steps. The ingredients parameter is an array of Ingredient objects, and the steps parameter is an array of string objects.
        //The constructor initialises the Ingredients and Steps properties with the values passed in.
        public Recipe(Ingredient[] ingredients, string[] steps)
        {
            Ingredients = ingredients;
            Steps = steps;
        }
    }
}
