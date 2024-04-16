# ST10355049_PROG6221_POEPart1_LiamKnipe

# Recipe Manager
The Recipe Manager is a console application built using the C# that allows users to manage recipes. The application provides the following key features:

## Features

1. *Add Recipe*: Users can add new recipes by specifying the number of ingredients and steps. For each ingredient, the user can provide the name, quantity and the unit of measurement. For the steps, the user can enter the textual instructions.
2. *View Recipe*: Users can view the details of the current recipe, including the list of ingredients and the steps to prepare the dish. The application will also display the current scale factor applied to the recipe.
3. *Scale Recipe*: Users can scale the recipe by selecting a predefined scale factor (0.5, 2, or 3). The application will update the quantities of the ingredients accordingly, and also convert the units of measurement when necessary (e.g., 16 tablespoons will be converted to 1 cup, 3 teaspoons will be converted to 1 tablespoon).
4. *Reset Scale*: Users can reset the scale factor to 1, reverting the recipe to its original quantities.
5. *Clear Recipe*: Users can clear the current recipe, removing all the ingredients and steps.
6. *Exit*: Users can exit the application.

## To get started:

To use the Recipe Manager, follow these steps:
1. Clone the repository or download the source code files.
2. Open the project in Visual Studio Community or your perferred C# development enviroment.
3. Build the project to ensure there are no compilation errors.
4. Run the application by executing the Program.cs file.

## Usage

When the application starts, the user will be presented with a main menu. From here they can choose from the available options to manage their recipes.
1. *Add Recipe*: The user will be prompted to enter the number of ingredients and steps. For each ingredient, they need to provide the name, quantity and unit of measurement. For the steps, they can enter the textual instructions.
2. *View Recipe*: The application will display the current recipe, including the list of ingredients and the steps to prepare the dish. The current scale factor will also be shown.
3. *Scale Recipe*: The user will be prompted to select a scale factor (0.5, 2, or 3). The application will updated the quantities of the ingredients accordingly, and also convert the units of measurement when necessary.
4. *Reset Scale*: The application will reset the scale factor to 1, reverting the recipe to its original quantities.
5. *Clear Recipe*: The user will be asked to confirm if they want to clear the current recipe. If confirmed, the recipe will be removed and the scale factor will be reset to 1.
6. *Exit*: The application will terminate.

## Error Handling

The Recipe Manager application includes error handling to ensure a smooth user experience. If the user enters invalid input (e.g., non-numeric values for quantities), the application will prompt the user to re-enter the correct information.

## Code Structure

The application is structured using the following classes:
1. *RecipeManager*: This is the main class that handles the user interface, user input and the managment of recipes.
2. *Recipe*: This class represents a recipe, consisting of an array of Ingredient objects and an array of steps.
3. *Ingredient*: This class represents an individual ingredient, with properties for the name, quanitity and unit of measurement.

The *RecipeManager* class is responsible for the core functionality of the application, including adding recipes, viewing recipes, scaling recipes, resetting the scale and clearing recipes.

## Repository Link: https://github.com/ST10355049-Knipe/ST10355049_PROG6221_POEPart1_LiamKnipe
