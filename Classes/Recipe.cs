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
        public Ingredient[] Ingredients { get; }
        public string[] Steps { get; }

        public Recipe(Ingredient[] ingredients, string[] steps)
        {
            Ingredients = ingredients;
            Steps = steps;
        }
    }
}
