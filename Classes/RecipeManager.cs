﻿using System;
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
