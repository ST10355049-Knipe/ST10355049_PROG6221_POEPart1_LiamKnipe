using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10355049_PROG6221_POEPart1_LiamKnipe.Classes
{
    internal class Ingredient
    {
        public string Name { get; }
        public double Quantity { get; }
        public string UnitOfMeasurement { get; }
      
        public Ingredient(string name, double quantity, string unitOfMeasurement)
        {
            Name = name;
            Quantity = quantity;
            UnitOfMeasurement = unitOfMeasurement;
        }
    }
}
