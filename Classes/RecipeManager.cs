using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10355049_PROG6221_POEPart1_LiamKnipe.Classes
{
    internal class RecipeManager
    {
        private Recipe currentRecipe;
        private double factorScale = 1;

        public void runMain()
        {
            while (true)
            {
                DisplayMenu();
                var choice = GetUserChoice();
                ClearConsole();

                switch(choice)
                {
                    case 1:
                        AddRecipe();
                        break;
                    case 2:
                        ViewRecipe();
                        break;
                    case 3:
                        ScaleRecipe();
                        break;
                    case 4:
                        ResetScale();
                        break;
                    case 5:
                        ClearRecipe();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice, please try again.");
                        ClearConsole();
                        break;
                }
            }
        }
        
        private void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Recipe Manager");
            Console.WriteLine("1. Add Recipe");
            Console.WriteLine("2. View Recipe");
            Console.WriteLine("3. Scale Recipe");
            Console.WriteLine("4. Reset Scale");
            Console.WriteLine("5. Clear Recipe");
            Console.WriteLine("6. Exit");
            Console.Write("Please enter your choice (1-6): ");
        }

        private int GetUserChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
            {
                Console.Write("Invalid choice. Please enter a number between 1 and 6: ");
            }
            return choice;
        }

        private void AddRecipe()
        {
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = GetIntInput();

            var ingredients = new Ingredient[numIngredients];
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}: ");
                Console.Write("Name: ");
                string Name = Console.ReadLine();
                Console.Write("Quantity: ");
                double Quantity = GetDoubleInput();
                Console.Write("Unit of measurement: ");
                string Unit = Console.ReadLine();
                ingredients[i] = new Ingredient(Name, Quantity, Unit);
            }
            Console.Write("Enter the number of steps: ");
            int numSteps = GetIntInput();

            var steps = new string[numSteps];
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Step {i + 1}: ");
                steps[i] = Console.ReadLine();
            }
            currentRecipe = new Recipe(ingredients, steps);
            factorScale = 1;
            Console.WriteLine("Recipe added successfully.");
            Console.WriteLine();
        }
        private void ViewRecipe()
        {
            if (currentRecipe == null)
            {
                Console.WriteLine("No recipe available.");
                return;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RECIPE:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ingredients:");
            Console.ResetColor();
            foreach (var ingredient in currentRecipe.Ingredients)
            {
                Console.WriteLine($" {ingredient.Quantity * factorScale} {ingredient.UnitOfMeasurement} {ingredient.Name}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Steps:");
            Console.ResetColor();
            for (int i = 0; i < currentRecipe.Steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {currentRecipe.Steps[i]}");
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Factor Scale: {factorScale}");
            Console.ResetColor();
            Console.WriteLine();
        }
       private void ScaleRecipe()
        {
            if (currentRecipe == null)
            {
                Console.WriteLine("No recipe available.");
                    return;
            }

            Console.WriteLine("Select a scale factor:");
            Console.WriteLine("1. 0.5");
            Console.WriteLine("2. 2");
            Console.WriteLine("3. 3");
            Console.Write("Enter your choice (1-3): ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
            }

            switch (choice)
            {
                case 1:
                    factorScale *= 0.5;
                    break;
                case 2:
                    factorScale *= 2;
                    break;
                case 3:
                    factorScale *= 3;
                    break;
            }

            Console.WriteLine("Recipe successfully scaled.");
            Console.WriteLine();
        }

        private void ResetScale()
        {
            factorScale = 1;
            Console.WriteLine("Scale reset to 1.");
            Console.WriteLine();
        }
        private void ClearRecipe()
        {
            Console.Write("Are you sure you want to clear the recipe? (y/n) ");
            string confirm = Console.ReadLine().ToLower();
            if (confirm == "y")
            {
                currentRecipe = null;
                factorScale = 1;
                Console.WriteLine("Recipe cleared.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Recipe not cleared.");
                Console.WriteLine();
            }
        }
        private int GetIntInput()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
            {
                Console.Write("Invalid input. Please enter a positive integer: ");
            }
            return value;
        }
        private double GetDoubleInput()
        {
            double value;
            while (!double.TryParse(Console.ReadLine(), out value) || value < 0)
            {
                Console.Write("Invalid input. Please enter a positive number: ");
            }
            return value;
        }
        private void ClearConsole()
        {
            Console.Clear();
        }
    }
}
