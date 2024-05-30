using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ST10355049_PROG6221_POEPart2_LiamKnipe.Models;

namespace ST10355049_PROG6221_POEPart2_LiamKnipe.Managers
{
    // The RecipeManager class manages the recipes in the application.
    internal class RecipeManager
    {
        // Private variables for the current recipe, the scale factor, and the list of recipes.
        private Recipe currentRecipe;       // Stores the current recipe
        private double factorScale = 1;     // Stores the scale factor for the recipe
        private List<Recipe> recipes = new List<Recipe>(); // Stores all recipes
        public delegate void ExceededCaloriesHandler(string message);

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // The runMain method is the main function of the program.
        public void runMain()
        {
            // Infinite loop to keep the program running until the user chooses to exit.
            while (true)
            {
                // Display the menu
                DisplayMenu();
                // Get the users choice
                var choice = GetUserChoice();
                // Clear the console
                ClearConsole();

                // Switch case to perform actions based on users choice
                switch (choice)
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

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // The DisplayMenu method displays the menu options to the user.
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

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        // The GetUserChoice method gets the user's choice from the menu.
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

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        // The ViewRecipe method displays the current recipe to the user.
        private void ViewRecipe()
        {
            try
            {
                // If there are no recipes, notify the user and return
                if (!recipes.Any())
                {
                    Console.WriteLine("No recipes available.");
                    return;
                }

                // Order the recipes by name
                var orderedRecipes = recipes.OrderBy(r => r.Name).ToList();

                // Ask the user to select a recipe
                Console.WriteLine("Select a recipe:");
                for (int i = 0; i < orderedRecipes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {orderedRecipes[i].Name}");
                }
                Console.Write("Enter your choice: ");
                int choice = GetIntInput();

                // Check if the choice is valid
                if (choice < 1 || choice > orderedRecipes.Count)
                {
                    Console.WriteLine("Invalid choice.");
                    return;
                }

                // Unsubscribe from the OnExceededCalories event of the current recipe
                if (currentRecipe != null)
                {
                    currentRecipe.OnExceededCalories -= HandleExceededCalories;
                }

                // Set the current recipe
                currentRecipe = orderedRecipes[choice - 1];

                // Subscribe to the OnExceededCalories event
                currentRecipe.OnExceededCalories += HandleExceededCalories;

                // Display the recipe
                Console.WriteLine($"Recipe: {currentRecipe.Name}");
                Console.WriteLine("Ingredients:");
                foreach (var ingredient in currentRecipe.Ingredients)
                {
                    Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.UnitOfMeasurement}");
                }
                Console.WriteLine("Steps:");
                for (int i = 0; i < currentRecipe.Steps.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {currentRecipe.Steps[i]}");
                }

                // Calculate and display the total calories
                int totalCalories = currentRecipe.TotalCalories();
                Console.WriteLine($"Total calories: {totalCalories}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        // The AddRecipe method allows the user to add a new recipe.
        private void AddRecipe()
        {
            try
            {
                // Prompt the user to enter the number of ingredients
                Console.Write("Enter the number of ingredients: ");
                int numIngredients = GetIntInput();

                // Check if the number of ingredients is valid
                if (numIngredients <= 0)
                {
                    // If not, notify the user and return
                    Console.WriteLine("Number of ingredients must be greater than 0.");
                    return;
                }

                // Create an array to store the ingredients
                var ingredients = new Ingredient[numIngredients];

                // Calculate the total calories of the recipe
                int totalCalories = 0;

                // Loop through each ingredient
                for (int i = 0; i < numIngredients; i++)
                {
                    // Prompt the user to enter the details of the ingredient
                    Console.WriteLine($"Ingredient {i + 1}: ");
                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    // Check if the name is valid
                    if (string.IsNullOrEmpty(name))
                    {
                        // If not, notify the user and return
                        Console.WriteLine("Ingredient name cannot be null or empty.");
                        return;
                    }

                    // Prompt the user to enter the quantity of the ingredient
                    Console.Write("Quantity: ");
                    double quantity = GetDoubleInput();

                    // Check if the quantity is valid
                    if (quantity <= 0)
                    {
                        // If not, notify the user and return
                        Console.WriteLine("Quantity must be greater than 0.");
                        return;
                    }

                    // Prompt the user to enter the unit of measurement of the ingredient
                    Console.Write("Unit of measurement: ");
                    string unit = Console.ReadLine();

                    // Check if the unit of measurement is valid
                    if (string.IsNullOrEmpty(unit))
                    {
                        // If not, notify the user and return
                        Console.WriteLine("Unit of measurement cannot be null or empty.");
                        return;
                    }

                    // Prompt the user to enter the number of calories of the ingredient
                    Console.Write("Enter the number of calories: ");
                    int calories = GetIntInput();

                    // Check if the number of calories is valid
                    if (calories < 0)
                    {
                        // If not, notify the user and return
                        Console.WriteLine("Number of calories cannot be negative.");
                        return;
                    }

                    // Add the calories to the total
                    totalCalories += calories;

                    // Prompt the user to enter the food group of the ingredient
                    Console.Write("Enter the food group: ");
                    string foodGroup = Console.ReadLine();

                    // Check if the food group is valid
                    if (string.IsNullOrEmpty(foodGroup))
                    {
                        // If not, notify the user and return
                        Console.WriteLine("Food group cannot be null or empty.");
                        return;
                    }

                    // Create a new ingredient with the entered details and add it to the array
                    ingredients[i] = new Ingredient(name, quantity, unit, calories, foodGroup);
                }

                // Prompt the user to enter the name of the recipe
                Console.Write("Enter the name of the recipe: ");
                string recipeName = Console.ReadLine();

                // Check if the recipe name is valid
                if (string.IsNullOrEmpty(recipeName))
                {
                    // If not, notify the user and return
                    Console.WriteLine("Recipe name cannot be null or empty.");
                    return;
                }

                // Prompt the user to enter the number of steps of the recipe
                Console.Write("Enter the number of steps: ");
                int numSteps = GetIntInput();

                // Check if the number of steps is valid
                if (numSteps <= 0)
                {
                    // If not, notify the user and return
                    Console.WriteLine("Number of steps must be greater than 0.");
                    return;
                }

                // Create an array to store the steps
                var steps = new string[numSteps];

                // Loop through each step
                for (int i = 0; i < numSteps; i++)
                {
                    // Prompt the user to enter the details of the step
                    Console.WriteLine($"Enter step {i + 1}: ");
                    steps[i] = Console.ReadLine();
                }

                // Create a new recipe with the entered details and add it to the list
                Recipe recipe = new Recipe(recipeName, ingredients, steps)
                {
                    OriginalTotalCalories = totalCalories // Store the original total calories
                };
                recipes.Add(recipe); // Add the new recipe to the list

                // Notify the user that the recipe was added successfully
                Console.WriteLine("Recipe added successfully. Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception ex)
            {
                // If an error occurs, print the error message
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private void ScaleRecipe()
        {
            try
            {
                // If there are no recipes, notify the user and return
                if (!recipes.Any())
                {
                    Console.WriteLine("No recipes available.");
                    return;
                }

                // Order the recipes by name
                var orderedRecipes = recipes.OrderBy(r => r.Name).ToList();

                // Ask the user to select a recipe
                Console.WriteLine("Select a recipe to scale:");
                for (int i = 0; i < orderedRecipes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {orderedRecipes[i].Name}");
                }
                Console.Write("Enter your choice: ");
                int choice = GetIntInput();

                // Check if the choice is valid
                if (choice < 1 || choice > orderedRecipes.Count)
                {
                    Console.WriteLine("Invalid choice.");
                    return;
                }

                // Set the current recipe
                currentRecipe = orderedRecipes[choice - 1];

                //ask the user what scaling factor and get the input
                Console.Write("Enter the scaling factor (0,5, 2, 3): ");
                double factor = GetDoubleInput();

                // Check if the scaling factor is valid
                if (factor <= 0)
                {
                    // If not, notify the user and return
                    Console.WriteLine("Scaling factor must be greater than 0.");
                    return;
                }

                // Loop through each ingredient in the current recipe
                foreach (var ingredient in currentRecipe.Ingredients)
                {
                    // Store the original values of the ingredient's properties
                    ingredient.OriginalQuantity = ingredient.Quantity;
                    ingredient.OriginalUnitOfMeasurement = ingredient.UnitOfMeasurement;
                    ingredient.OriginalCalories = ingredient.Calories;

                    // Scale the quantity and calories of the ingredient by the scaling factor
                    ingredient.Quantity *= factor;
                    ingredient.Calories = (int)Math.Round(ingredient.Calories * factor); // Round the calories to the nearest integer

                    // Check if the unit of measurement needs to be converted
                    if (ingredient.UnitOfMeasurement == "gram" && ingredient.Quantity >= 1000)
                    {
                        // If the quantity is greater than or equal to 1000 grams, convert it to kilograms
                        ingredient.Quantity /= 1000;
                        ingredient.UnitOfMeasurement = "kilogram";
                    }
                    else if (ingredient.UnitOfMeasurement == "millilitre" && ingredient.Quantity >= 1000)
                    {
                        // If the quantity is greater than or equal to 1000 millilitres, convert it to litres
                        ingredient.Quantity /= 1000;
                        ingredient.UnitOfMeasurement = "litre";
                    }
                    else if (ingredient.UnitOfMeasurement == "teaspoon" && ingredient.Quantity >= 3)
                    {
                        // If the quantity is greater than or equal to 3 teaspoons, convert it to tablespoons
                        ingredient.Quantity /= 3;
                        ingredient.UnitOfMeasurement = "tablespoon";
                    }
                }

                // Notify the user that the recipe was scaled
                Console.WriteLine("Recipe scaled.");
            }
            catch (Exception ex)
            {
                // If an error occurs, print the error message
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // The ResetScale method resets the scale factor of the current recipe.
        private void ResetScale()
        {
            try
            {
                // If there are no recipes, notify the user and return
                if (!recipes.Any())
                {
                    Console.WriteLine("No recipes available.");
                    return;
                }

                // Order the recipes by name
                var orderedRecipes = recipes.OrderBy(r => r.Name).ToList();

                // Ask the user to select a recipe
                Console.WriteLine("Select a recipe to reset:");
                for (int i = 0; i < orderedRecipes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {orderedRecipes[i].Name}");
                }
                Console.Write("Enter your choice: ");
                int choice = GetIntInput();

                // Check if the choice is valid
                if (choice < 1 || choice > orderedRecipes.Count)
                {
                    Console.WriteLine("Invalid choice.");
                    return;
                }

                // Set the current recipe
                currentRecipe = orderedRecipes[choice - 1];


                // Reset the quantities, units of measurement, and calories of the ingredients
                foreach (var ingredient in currentRecipe.Ingredients)
                {
                    double scale = ingredient.OriginalQuantity != 0 ? ingredient.Quantity / ingredient.OriginalQuantity : 0;
                    ingredient.Quantity = ingredient.OriginalQuantity;
                    ingredient.UnitOfMeasurement = ingredient.OriginalUnitOfMeasurement;
                    ingredient.Calories = ingredient.OriginalCalories; // Reset the calories
                }

                // Reset the scale factor
                factorScale = 1;

                Console.WriteLine("Scale reset to 1.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private void ClearRecipe()
        {
            try
            {
                // If there are no recipes, notify the user and return
                if (!recipes.Any())
                {
                    Console.WriteLine("No recipes available.");
                    return;
                }

                // Order the recipes by name
                var orderedRecipes = recipes.OrderBy(r => r.Name).ToList();

                // Ask the user to select a recipe
                Console.WriteLine("Select a recipe to clear:");
                for (int i = 0; i < orderedRecipes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {orderedRecipes[i].Name}");
                }
                Console.Write("Enter your choice: ");
                int choice = GetIntInput();

                // Check if the choice is valid
                if (choice < 1 || choice > orderedRecipes.Count)
                {
                    Console.WriteLine("Invalid choice.");
                    return;
                }

                // Get the selected recipe
                Recipe recipeToClear = orderedRecipes[choice - 1];

                // Ask the user for confirmation
                Console.Write("Are you sure you want to clear the recipe? (y/n) ");
                string confirm = Console.ReadLine().ToLower();
                // If the user confirms, clear the recipe
                if (confirm == "y")
                {
                    //remove the recipe from the arraylist of recipes
                    recipes.Remove(recipeToClear); // Remove the selected recipe
                    if (currentRecipe == recipeToClear) // If the current recipe is the one being cleared, set it to null
                    {
                        currentRecipe = null;
                    }
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
            //catches exceptions and displays an error message
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // The GetIntInput method gets an integer input from the user.
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

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        // The GetDoubleInput method gets a double input from the user.
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

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        // The HandleExceededCalories method handles the OnExceededCalories event.
        public void HandleExceededCalories(string message)
        {
            Console.WriteLine(message);
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        // The ClearConsole method clears the console.
        private void ClearConsole()
        {
            Console.Clear();
        }
    }
}
// End of file
