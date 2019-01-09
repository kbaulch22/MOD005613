/* In order to allow the user to enter five numbers of their choosing, instead of being asked how many elements are in their data set and creating an empty array of that size, an empty array
    of fixed size 5 should be initialised immediately after the user chose to make a calculation. This would be done by replacing the following code:
    
                            // asks user how many elements they want to calculate the mean of, creates an array of that size
                            Console.WriteLine("\nHow many elements would you like to calculate the mean of?: ");
                            int num_of_values = int.Parse(Console.ReadLine());
                            float[] numbers = new float[num_of_values];
        
      with: 
                            float[] numbers = new float[5]; */

using System;
using System.Threading;

namespace ArithmeticMean3
{
    class Program
    {
        static void Main(string[] args)
        {
            // declares variables
            float result = 0f;
            bool repeat_loop = true;
            int user_choice;

            do
            {
                Console.Clear();

                // displays menu to user
                Console.WriteLine("Welcome to Arithmetic Mean! This application will calculate the arithmetic mean of the numbers you enter.\n\nWould you like to:\n\t1. Calculate mean?\n\t2. Exit application?");

                try
                {
                    // converts user choice to integer value
                    user_choice = Int32.Parse(Console.ReadLine());

                    if (user_choice == 1)
                    {
                        // asks user how many elements they want to calculate the mean of, creates an array of that size
                        Console.WriteLine("\nHow many elements would you like to calculate the mean of?: ");
                        int num_of_values = int.Parse(Console.ReadLine());
                        float[] numbers = new float[num_of_values];

                        // creates loop to iterate over the array
                        for (int c = 0; c < numbers.Length; c++)
                        {
                            Console.WriteLine("\nPlease input a value and press enter/return to continue: ");       // asks user to input each number individually
                            numbers[c] = (float.Parse(Console.ReadLine()));                                         // converts string to float, stores it in current element of array
                            result += numbers[c];                                                                   // gets the current element of the array, adds value to the result
                        }

                        result = (result / numbers.Length);                                                         // divide sum by length of the array

                        Console.WriteLine("\nMean: " + result + "\nPress any key to continue...");                  // display mean average to the user
                        Console.ReadKey();

                    }
                    // handles user decision to exit application
                    else if (user_choice == 2)
                    {
                        Console.WriteLine("Thank you for using Arithmetic Mean! Exiting application...");
                        Thread.Sleep(3800);
                        repeat_loop = false;
                        Environment.Exit(0);
                    }
                    else
                    {
                        // displays error message to user
                        Console.WriteLine("\nERROR: Invalid menu option. Please press enter/return to try again.");
                        Console.ReadKey();
                    }
                }
                catch (FormatException)
                {
                    // displays error message to user
                    Console.WriteLine("\nERROR: Invalid menu option. Please press enter/return to try again.");
                    Console.ReadKey();
                }                                                           
            } while (repeat_loop) ;                                                                            // executes as long as user does not choose to exit the application
        }
    }
}
           