using System;
using System.Collections.Generic;
using System.Threading;

namespace DrinksMachine
{
    class Drinks
    {
        public static void UpdateTeaIngredients(Dictionary<string, int> ingredients)
        {
            ingredients["Tea"]--;
            ingredients["Cups"]--;
        }
        public static void UpdateCoffeeIngredients(Dictionary<string, int> ingredients)
        {
            ingredients["Coffee"] -= 1;
            ingredients["Cups"] -= 1;
        }
        public static void DispenseDrink()
        {
            Thread.Sleep(3000);
            Console.WriteLine("\n\t\t  ...Dispensing drink now...\n");
            Thread.Sleep(5000);
        }
    }
}
