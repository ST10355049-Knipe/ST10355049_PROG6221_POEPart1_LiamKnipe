using ST10355049_PROG6221_POEPart1_LiamKnipe.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10355049_PROG6221_POEPart1_LiamKnipe
{
    internal class Program
    {
        //Main method, entry point of the application
        static void Main(string[] args)
        {
            //Creating a new instance of the RecipeManager Class.
            var recipeManager = new RecipeManager();

            //Calling the runMain method on the RecipeManager instance to start the application.
            recipeManager.runMain();
        }
    }
}
