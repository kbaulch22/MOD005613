using System;
using System.Collections.Generic;
using System.Threading;

namespace DrinksMachine
{
    class Program
    {  
        static void MenuReturn()
        {
            Thread.Sleep(100);
            Console.Write("\nReturning to menu... Press any key to continue...");
            Console.ReadKey();
        }        
        
        static void Main(string[] args)
        {
            // sets loop variable as true so statements will execute, declares a new array which will count the number of each type of drink purchased 
            bool repeat_loop = true;
            int[] drinks_counter = new int[6] {0, 0, 0, 0, 0, 0};     

            // declares a new dictionary which holds the name of each ingredient and the quantity of it remaining 
            Dictionary<string, int> ingredients = new Dictionary<string, int>()
            {
                { "Tea", 10 },
                { "Coffee", 10 },
                { "Milk", 10 },
                { "Sugar", 10 },
                { "Cups", 10 }
            };
           
            do  // loops as long as user doesn't choose to quit the application/ whilst all ingredients are in stock
            {
                // clears console and displays menu options to user
                Console.Clear();
                Console.Write("Welcome to Drinks Machine.\n\nWhat would you like to order?\nMenu:\n1. Tea with Milk\n2. Tea with Sugar\n3. Tea with Milk and Sugar\n4. Coffee with Milk\n5. Coffee with Sugar\n6. Coffee with Milk and Sugar\n7. Quit\n\nPlease input an option number and press enter/return to continue: ");

                try
                {
                    // converts menu option into an integer value for use in switch-case                 
                    int option_num = int.Parse(Console.ReadLine());              

                    switch (option_num)  // handles user's choice                                    
                    {
                        case 1:
                            Console.Write("\n\nYou have selected Tea with Milk.\n\nProcessing choice...\t\t\t");
                            Thread.Sleep(3500);

                            // if all required ingredients are in stock, execute
                            if ((ingredients["Tea"] != 0) || (ingredients["Milk"] != 0) || (ingredients["Cups"] != 0))
                            {
                                Console.WriteLine("Tea with Milk is in stock.\n");
                                Drinks.DispenseDrink();

                                // increment number of this drink bought
                                drinks_counter[0]++;

                                Console.WriteLine("\nNumber of teas with milk bought:\t" + drinks_counter[0]);
                                Drinks.UpdateTeaIngredients(ingredients);

                                // reduce quantity of other tea ingredients by one
                                ingredients["Milk"] -= 1;

                                MenuReturn();
                            }
                            else // if any ingredients needed to make the drink are out of stock, display Out of Stock message
                            {
                                Errors.OutOfStock(repeat_loop);
                            }
                            break;
                        case 2:
                            Console.Write("\n\nYou have selected Tea with Sugar.\n\nProcessing choice...\t\t\t");
                            Thread.Sleep(3500);

                            // if all required ingredients are in stock, execute
                            if ((ingredients["Tea"] != 0) || (ingredients["Sugar"] != 0) || (ingredients["Cups"] != 0))
                            {
                                Console.WriteLine("Tea with Sugar is in stock.\n");
                                Drinks.DispenseDrink();

                                // increment number of this drink bought
                                drinks_counter[1]++;

                                Console.WriteLine("\nNumber of teas with sugar bought:\t" + drinks_counter[1]);
                                Drinks.UpdateTeaIngredients(ingredients);

                                // reduce quantity of other tea ingredients by one
                                ingredients["Sugar"] -= 1;

                                MenuReturn();
                            }
                            else
                            {
                                Errors.OutOfStock(repeat_loop);
                            }
                            break;
                        case 3:
                            Console.Write("\n\nYou have selected Tea with Milk and Sugar.\n\nProcessing choice...\t\t\t");
                            Thread.Sleep(3500);

                            // if all required ingredients are in stock, execute
                            if ((ingredients["Tea"] != 0) || (ingredients["Milk"] != 0) || (ingredients["Sugar"] != 0) || (ingredients["Cups"] != 0))
                            {
                                Console.WriteLine("Tea with Milk and Sugar is in stock.\n");
                                Drinks.DispenseDrink();

                                // increment number of this drink bought
                                drinks_counter[2]++;

                                Console.WriteLine("\nNumber of teas with milk and sugar bought:\t" + drinks_counter[2]);
                                Drinks.UpdateTeaIngredients(ingredients);

                                // reduce quantity of other tea ingredients by one
                                ingredients["Milk"] -= 1;
                                ingredients["Sugar"] -= 1;

                                MenuReturn();
                            }
                            else
                            {
                                Errors.OutOfStock(repeat_loop);
                            }
                            break;
                        case 4: 
                            Console.Write("\n\nYou have selected Coffee with Milk.\n\nProcessing choice...\t\t\t");
                            Thread.Sleep(3500);

                            // if all required ingredients are in stock, execute
                            if ((ingredients["Coffee"] != 0) || (ingredients["Milk"] != 0) || (ingredients["Cups"] != 0))
                            {
                                Console.WriteLine("Coffee with Milk is in stock.\n");
                                Drinks.DispenseDrink();

                                // increment number of this drink bought
                                drinks_counter[3]++;

                                Console.WriteLine("\nNumber of coffees with milk bought:\t" + drinks_counter[3]);
                                Drinks.UpdateCoffeeIngredients(ingredients);

                                // reduce quantity of other coffee ingredients by one
                                ingredients["Milk"] -= 1;

                                MenuReturn();
                            }
                            else
                            {
                                Errors.OutOfStock(repeat_loop);
                            }
                            break;
                        case 5: 
                            Console.Write("\n\nYou have selected Coffee with Sugar.\n\nProcessing choice...\t\t\t");
                            Thread.Sleep(3500);

                            // if all required ingredients are in stock, execute
                            if ((ingredients["Coffee"] != 0) || (ingredients["Sugar"] != 0) || (ingredients["Cups"] != 0))
                            {
                                Console.WriteLine("Coffee with Sugar is in stock.\n");
                                Drinks.DispenseDrink();

                                // increment number of this drink bought
                                drinks_counter[4]++;

                                Console.WriteLine("\nNumber of coffees with sugar bought:\t" + drinks_counter[4]);
                                Drinks.UpdateCoffeeIngredients(ingredients);

                                // reduce quantity of other coffee ingredients by one
                                ingredients["Sugar"] -= 1;

                                MenuReturn();
                            }
                            else
                            {
                                Errors.OutOfStock(repeat_loop);
                            }
                            break;
                        case 6: 
                            Console.Write("\n\nYou have selected Coffee with Milk and Sugar.\n\nProcessing choice...\t\t\t");
                            Thread.Sleep(3500);

                            // if all required ingredients are in stock, execute
                            if ((ingredients["Coffee"] != 0) || (ingredients["Milk"] != 0) || (ingredients["Sugar"] != 0) || (ingredients["Cups"] != 0))
                            {
                                Console.WriteLine("Coffee with Milk and Sugar is in stock.\n");
                                Drinks.DispenseDrink();

                                // increment number of this drink bought
                                drinks_counter[5]++;

                                Console.WriteLine("\nNumber of coffees with milk and sugar bought:\t" + drinks_counter[5]);
                                Drinks.UpdateCoffeeIngredients(ingredients);

                                // reduce quantity of other coffee ingredients by one
                                ingredients["Milk"] -= 1;
                                ingredients["Sugar"] -= 1;

                                MenuReturn();
                            }
                            else
                            {
                                Errors.OutOfStock(repeat_loop);
                            }
                            break;
                        case 7: // handles user decision to exit application
                            Console.Write("\n\nThank you for using the Drinks Machine application.\nGoodbye!");
                            Thread.Sleep(3500);
                            repeat_loop = false;
                            Environment.Exit(0);
                            break;
                        default: // displays error message to user
                            Errors.InvalidOption();
                            break;
                    }  
                }
                catch (FormatException)
                {
                    // displays error message to user
                    Errors.InvalidOption();
                }
            } while (repeat_loop);
        }
    }
}
