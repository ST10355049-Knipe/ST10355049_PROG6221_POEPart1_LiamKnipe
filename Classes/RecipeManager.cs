using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10355049_PROG6221_POEPart1_LiamKnipe.Classes
{
    internal class RecipeManager
    {
        //declaring private variables
        private Recipe currentRecipe;       // Stores the current recipe
        private double factorScale = 1;     // Stores the scale factor for the recipe

        //Main function to run the program
        public void runMain()
        {
            //Infinite loop to keep the program running until user chooses to exit
            while (true)
            {
                // Display the menu
                DisplayMenu();
                // Get the users choice
                var choice = GetUserChoice();
                // Clear the console
                ClearConsole();

                // Switch case to perform actions based on users choice
                switch(choice)
                {
                    case 1:
                        // Add a new recipe
                        AddRecipe();
                        break;
                    case 2:
                        //View the current recipe
                        ViewRecipe();
                        break;
                    case 3:
                        // Scale the recipe
                        ScaleRecipe();
                        break;
                    case 4:
                        // Reset the scale factor
                        ResetScale();
                        break;
                    case 5:
                        // Clear the current recipe
                        ClearRecipe();
                        break;
                    case 6:
                        // Exit the program
                        return;
                    default:
                        // Invalid choice
                        Console.WriteLine("Invalid Choice, please try again.");
                        ClearConsole();
                        break;
                }
            }
        }
        
        // Function to display the menu
        private void DisplayMenu()
        {
            // Set the console colour to cyan
            Console.ForegroundColor = ConsoleColor.Cyan;
            // Display the menu options
            Console.WriteLine("Recipe Manager");
            Console.WriteLine("1. Add Recipe");
            Console.WriteLine("2. View Recipe");
            Console.WriteLine("3. Scale Recipe");
            Console.WriteLine("4. Reset Scale");
            Console.WriteLine("5. Clear Recipe");
            Console.WriteLine("6. Exit");
            Console.Write("Please enter your choice (1-6): ");
        }

        // Funcation to get the users choice
        private int GetUserChoice()
        {
            // Declare a variable to store the users choice
            int choice;
            // Loop until the user enters a valid choice
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
            {
                Console.Write("Invalid choice. Please enter a number between 1 and 6: ");
            }
            // Return the users choice
            return choice;
        }

        // Funcation to add a new recipe
        private void AddRecipe()
        {
            // Ask the user for the number of ingredients
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = GetIntInput();

            // Declare an array to store the ingredients
            var ingredients = new Ingredient[numIngredients];
            // Loop to get the details of each ingredient
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}: ");
                Console.Write("Name: ");
                string Name = Console.ReadLine();
                Console.Write("Quantity: ");
                double Quantity = GetDoubleInput();
                Console.Write("Unit of measurement: ");
                string Unit = Console.ReadLine();
                // Create a new ingredient and add it to the array
                ingredients[i] = new Ingredient(Name, Quantity, Unit);
            }

            // Ask the user for the number of steps
            Console.Write("Enter the number of steps: ");
            int numSteps = GetIntInput();

            // Declare an array to store the steps
            var steps = new string[numSteps];
            // Loop to get each step
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Step {i + 1}: ");
                steps[i] = Console.ReadLine();
            }

            // Create a new recipe with the ingredients and steps
            currentRecipe = new Recipe(ingredients, steps);
            // Reset the scale factor
            factorScale = 1;
            // Notify the user that the recipe was added successfully
            Console.WriteLine("Recipe added successfully.");
            Console.WriteLine();
        }

        // Function to view the current recipe
        private void ViewRecipe()
        {
            // If there is no current recipe, notify the user and return
            if (currentRecipe == null)
            {
                Console.WriteLine("No recipe available.");
                return;
            }
            // Display the recipe
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RECIPE:");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ingredients:");
            Console.ResetColor();

            // Loop to display each ingredient
            foreach (var ingredient in currentRecipe.Ingredients)
            {
                // Scale the quantity of the ingredient by the factorScale
                double scaledQuantity = ingredient.Quantity * factorScale;

                // Store the unit of measure of the ingredient
                string unit = ingredient.UnitOfMeasurement;

                // Check if unit is a tablespoon and the scaled quantity is equal to or exceeds 16
                if (unit == "tablespoon" && scaledQuantity >= 16)
                {
                    // Convert the quantity from tablespoons to cups
                    scaledQuantity /= 16;
                    // Update the unit of measurement to cups
                    unit = "cup";
                }
                // If unit isn't tablespoon, check if it's a teaspoon and the scaled quantity is equal to or exceeds 3
                else if (unit == "teaspoon" && scaledQuantity >= 3)
                {
                    // Convert the quantity from teaspoons to tablespoons
                    scaledQuantity /= 3;
                    // Update the unit of measurement to tablespoons
                    unit = "tablespoon";
                }
                // Print the scaled quantity, updated unit of measurement, and ingredient name
                Console.WriteLine($" {scaledQuantity} {unit} {ingredient.Name}");
            }
        

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Steps:");
            Console.ResetColor();

            // Loop to display each step
            for (int i = 0; i < currentRecipe.Steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {currentRecipe.Steps[i]}");
            }

            // Display the scale factor
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Factor Scale: {factorScale}");
            Console.ResetColor();
            Console.WriteLine();
        }

        // Function to scale the recipe
        private void ScaleRecipe()
        {
            // If there is no current recipe, notify the user and return
            if (currentRecipe == null)
            {
                Console.WriteLine("No recipe available.");
                    return;
            }

            // Ask the user for the scale factor
            Console.WriteLine("Select a scale factor:");
            Console.WriteLine("1. 0.5");
            Console.WriteLine("2. 2");
            Console.WriteLine("3. 3");
            Console.Write("Enter your choice (1-3): ");

            // Declare a variable to store the user's choice
            int choice;
            // Loop until the user enters a valid choice
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
            }

            // Switch case to set the scale factor based on the user's choice
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

            // Notify the user that the recipe was scaled successfully
            Console.WriteLine("Recipe successfully scaled.");
            Console.WriteLine();
        }

        // Function to reset the scale factor
        private void ResetScale()
        {
            // Reset the scale factor to 1
            factorScale = 1;
            // Notify the user that the scale factor was reset
            Console.WriteLine("Scale reset to 1.");
            Console.WriteLine();
        }

        // Function to clear the current recipe
        private void ClearRecipe()
        {
            // Ask the user for confirmation
            Console.Write("Are you sure you want to clear the recipe? (y/n) ");
            string confirm = Console.ReadLine().ToLower();
            // If the user confirms, clear the recipe
            if (confirm == "y")
            {
                currentRecipe = null;
                factorScale = 1;
                // Notify the user that the recipe was cleared
                Console.WriteLine("Recipe cleared.");
                Console.WriteLine();
            }
            else
            {
                // Notify the user that the recipe was not cleared
                Console.WriteLine("Recipe not cleared.");
                Console.WriteLine();
            }
        }

        // Function to get an integer input from the user
        private int GetIntInput()
        {
            // Declare a variable to store the input
            int value;
            // Loop until the user enters a valid input
            while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
            {
                Console.Write("Invalid input. Please enter a positive integer: ");
            }
            // Return the input
            return value;
        }

        // Function to get a double input from the user
        private double GetDoubleInput()
        {
            // Declare a variable to store the input
            double value;
            // Loop until the user enters a valid input
            while (!double.TryParse(Console.ReadLine(), out value) || value < 0)
            {
                Console.Write("Invalid input. Please enter a positive number: ");
            }
            // Return the input
            return value;
        }


        // Function to clear the console
        private void ClearConsole()
        {
            Console.Clear();
        }
    }
}
