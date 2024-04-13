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
        private CookBook[] ingredients;
        private string[] steps;
        private string[] stepUnits;
        private double factorScale = 1.0;

        public int NumIngredients
        {
            get { return ingredients?.Length ?? 0; }
        }

        public int NumSteps
        {
            get { return steps?.Length ?? 0; }
        }

        public void RecipeDetails()
        {
            Console.Write("Please enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            ingredients = new CookBook[numIngredients];
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}: ");
                Console.Write("Name: ");
                ingredients[i] = new CookBook { Name = Console.ReadLine() };
                Console.Write("Quantity: ");
                double quantity;
                while (!double.TryParse(Console.ReadLine(), out quantity))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number for the quantity.");
                    Console.Write("  Quantity: ");
                }
                ingredients[i].Quantity = quantity;
                Console.Write("Unit of measurement: ");
                ingredients[i].UnitOfMeasurement = Console.ReadLine();
            }

            Console.Write("Please enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            steps = new string[numSteps];
            stepUnits = new string[numSteps];
            for (int i = 0;i < numSteps; i++)
            {
                Console.Write($"Step {i + 1}: ");
                steps[i] = Console.ReadLine();
                Console.Write("  Unit of measurement: ");
                stepUnits[i] = Console.ReadLine();
            }

        }

        public void DisplayRecipe()
        {
            Console.WriteLine("RECIPE: ");

            Console.WriteLine("Ingredients: ");
            for (int i = 0;i < NumIngredients; i++)
            {
                Console.WriteLine($" {ingredients[i].Quantity * factorScale} {ingredients[i].UnitOfMeasurement} {ingredients[i].Name}");
            }

            Console.WriteLine("Steps: ");
            for (int i = 0; i < NumSteps; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]} ({stepUnits[i]})");
            }

            Console.WriteLine($"Factor Scale: {factorScale}");
        }

        public void RecipeScale(double factor)
        {
            factorScale = factor;
        }

        public void ResetScale()
        {
            factorScale = 1.0;
        }

        public void ClearRecipe()
        {
            ingredients = new CookBook[0];
            steps = new string[0];
            factorScale = 1.0;
        }
    }
}
