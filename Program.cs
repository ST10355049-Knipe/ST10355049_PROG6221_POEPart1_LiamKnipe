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
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            bool Exit = false;
            while (!Exit)
            {
                Console.WriteLine("Recipe Manager");
                Console.WriteLine("1. Add Recipe");
                Console.WriteLine("2. View Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Scale");
                Console.WriteLine("5. Clear Recipe");
                Console.WriteLine("6. Exit");

                Console.Write("Please enter your choice (1-6): ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    recipe.RecipeDetails();
                }
                else if (choice == "2")
                {
                    recipe.DisplayRecipe();
                }
                else if (choice == "3")
                {
                    Console.Write("Enter scale factor (0.5, 2, or 3): ");
                    double factor = double.Parse(Console.ReadLine());
                    recipe.RecipeScale(factor);
                }
                else if(choice == "4")
                {
                    recipe.ResetScale();
                    Console.WriteLine("Scale reset to default");
                }
                else if (choice == "5")
                {
                    recipe.ClearRecipe();
                    Console.WriteLine("Recipe cleared");
                }
                else if (choice == "6")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice, please try again");
                }
                Console.WriteLine();
            }
        }
    }
}
