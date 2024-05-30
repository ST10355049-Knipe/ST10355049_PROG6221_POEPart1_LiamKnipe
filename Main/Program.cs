using ST10355049_PROG6221_POEPart2_LiamKnipe.Managers;
using ST10355049_PROG6221_POEPart2_LiamKnipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10355049_PROG6221_POEPart2_LiamKnipe
{
    internal class Program
    {
        // The Program class contains the Main method, which is the entry point of the application.
        static void Main(string[] args)
        {
            //Creating a new instance of the RecipeManager Class.
            var recipeManager = new RecipeManager();

            // Start the application by calling the runMain method on the RecipeManager instance.
            recipeManager.runMain();
        }
    }
}
