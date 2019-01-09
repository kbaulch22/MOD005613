using System;
using System.Threading;

namespace DrinksMachine
{
    class Errors
    {
        public static void InvalidOption()
        {
            Console.Write("Invalid option. Please input a single digit number and press enter/return to continue.");
            Console.ReadKey();
        }
        public static void OutOfStock(bool repeat_loop)
        {
            // displays error message to user
            Console.WriteLine("ERROR: Sorry, ingredients needed to make this drink are not in stock.\nPlease wait for machine to be restocked before ordering again.");
            Thread.Sleep(3000);
            // breaks loop to ensure program doesn't consume ingredients or dispense a drink
            repeat_loop = false;
        }
    }
}
