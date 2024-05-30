using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static ST10355049_PROG6221_POEPart2_LiamKnipe.Managers.RecipeManager;


namespace ST10355049_PROG6221_POEPart2_LiamKnipe.Models
{
    // The Ingredient class represents an ingredient with a name, quantity, unit of measurement, calories, and food group.
    internal class Ingredient
    {
        //Name property is a public string that can be read but not modified, once set it cannot be changed.
        public string Name { get; }

        //Quantity property is a public double that can be read and modified, this means quantity of the ingredient can be changed as needed.
        public double Quantity { get; set; }

        //UnitOfMeasurement property is a public string that can be read and modified, this Allows UnitOfMeasurement to be changed as needed.
        public string UnitOfMeasurement { get; set; }

        //Calories property is a public int that can be read and modified, once set it can be changed to scale with the recipe.
        public int Calories { get; set; }

        //FoodGroup property is a public string that can be read but not modified, once set it cannot be changed.
        public string FoodGroup { get; }

        //OriginalQuantity property is a public double that can be read and modified, once set it can be changed to scale the calories.
        public double OriginalQuantity { get; set; }

        //OriginalUnitOfMeasurement property is a public string that can be read and modified, once set it can be changed to scale the calories.
        public string OriginalUnitOfMeasurement { get; set; }

        //OriginalCalories property is a public int that can be read and modified, once set it can be changed to scale the calories.
        public int OriginalCalories { get; set; }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Ingredient constructor takes 5 parameters: name, quanitity, unitOfMeasurement, Calories and FoodGroup. It initialises the Name, Quantity and UnitOfMeasurement Calories and FoodGroup properties with the values that are passed in.
        public Ingredient(string name, double quantity, string unitOfMeasurement, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            OriginalQuantity = quantity;
            UnitOfMeasurement = unitOfMeasurement;
            OriginalUnitOfMeasurement = unitOfMeasurement;
            Calories = calories;
            FoodGroup = foodGroup;
        }


    }
}
// End of file