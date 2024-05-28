using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10355049_PROG6221_POEPart1_LiamKnipe.Classes
{
    //Ingredient class represents an ingredient with a name, quantity and unit of measurement
    internal class Ingredient
    {
        //Name property is a public string that can be read but not modified, once set it cannot be changed.
        public string Name { get; }

        //Quantity property is a public double that can be read and modified, this means quantity of the ingredient can be changed as needed.
        public double Quantity { get; set; }

        //UnitOfMeasurement property is a public string that can be read but not modified, once set it cannot be changed.
        public string UnitOfMeasurement { get; }

        //Ingredient constructor takes 3 parameters: name, quanitity, and unitOfMeasurement. It initialises the Name, Quantity and UnitOfMeasurement properties with the values that are passed in.
        public Ingredient(string name, double quantity, string unitOfMeasurement)
        {
            Name = name;
            Quantity = quantity;
            UnitOfMeasurement = unitOfMeasurement;
        }
    }
}
