using System;

namespace tempConverter
{
    class Converter
    {
        static void ConvertAgain()
        {
            bool subsequent_conversion = true;
            string convert_again;

            while (subsequent_conversion)
            {
                // Gives user option to make another conversion
                Console.WriteLine("\nWould you like to make another conversion? Enter 'y' for Yes or 'n' for No & press enter/return to continue.");
                convert_again = (Console.ReadLine()).ToLower();
                               
                if (convert_again == "y")
                {
                    // break from this nested loop
                    subsequent_conversion = false; 
                }
                else if (convert_again == "n")
                {
                    Console.WriteLine("\nThank you for using Temperature Converter! Press any key to exit the application...");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Console.WriteLine("\nERROR: Invalid input. Please input 'y' to make another conversion or 'n' to exit the application: ");
                }
            }
        }
        static void Main(string[] args)
        {
            // declares variables
            float temp;
            string convert_from, convert_to;
            bool repeat_loop = true;

            do
            {
                Console.Clear();

                // Allows user to choose conversion type from numbered list
                string convert_message = "To begin converting, please input the number which corresponds to the conversion you would like to make:\n1. Celsius to Fahrenheit\n2. Celsius to Kelvin\n3. Fahrenheit to Kelvin\n4. Fahrenheit to Celsius\n5. Kelvin to Fahrenheit\n6. Kelvin to Celsius\n and then press enter/return to continue...";
                Console.WriteLine("Welcome to Temperature Converter. " + convert_message + "\n");

                try
                {
                    int conversion_type = Int32.Parse(Console.ReadLine());

                    // branches to handle user decision
                    switch (conversion_type)
                    {
                        case 1:
                            {
                                convert_from = "Celsius";
                                convert_to = "Fahrenheit";

                                // Allows the user to input a temperature to be converted
                                Console.WriteLine("\nGreat! What number would you like to convert from " + convert_from + " to " + convert_to + " ? ");
                                temp = float.Parse(Console.ReadLine());

                                // Converts temp into Fahrenheit, Displays result
                                Console.WriteLine("{0} Fahrenheit", temp * 1.8 + 32);

                                ConvertAgain();
                                break;
                            }
                        case 2:
                            {
                                convert_from = "Celsius";
                                convert_to = "Kelvin";

                                // Allows the user to input a temperature to be converted
                                Console.WriteLine("\nGreat! What number would you like to convert from " + convert_from + " to " + convert_to + " ? ");
                                temp = float.Parse(Console.ReadLine());

                                // Converts temp into Kelvin, Displays result
                                Console.WriteLine("{0} Kelvin", temp + 273.15);

                                ConvertAgain();

                                break;
                            }
                        case 3:
                            {
                                convert_from = "Fahrenheit";
                                convert_to = "Kelvin";

                                // Allows the user to input a temperature to be converted
                                Console.WriteLine("\nGreat! What number would you like to convert from " + convert_from + " to " + convert_to + " ? ");
                                temp = float.Parse(Console.ReadLine());

                                // Converts temp into Kelvin, Displays result
                                Console.WriteLine("{0} Kelvin", ((temp + 459.67) / (1.8)));

                                ConvertAgain();

                                break;
                            }
                        case 4:
                            {
                                convert_from = "Fahrenheit";
                                convert_to = "Celsius";

                                // Allows the user to input a temperature to be converted
                                Console.WriteLine("\nGreat! What number would you like to convert from " + convert_from + " to " + convert_to + " ? ");
                                temp = float.Parse(Console.ReadLine());

                                // Converts temp into Celsius, Displays result
                                Console.WriteLine("{0} Celsius", ((temp - 32) / (1.8)));

                                ConvertAgain();

                                break;
                            }
                        case 5:
                            {
                                convert_from = "Kelvin";
                                convert_to = "Fahrenheit";

                                // Allows the user to input a temperature to be converted
                                Console.WriteLine("\nGreat! What number would you like to convert from " + convert_from + " to " + convert_to + " ? ");
                                temp = float.Parse(Console.ReadLine());

                                // Converts temp into Fahrenheit, Displays result
                                Console.WriteLine("{0} Fahrenheit", ((temp * (1.8)) - 459.67));

                                ConvertAgain();

                                break;
                            }
                        case 6:
                            {
                                convert_from = "Kelvin";
                                convert_to = "Celsius";

                                // Allows the user to input a temperature to be converted
                                Console.WriteLine("\nGreat! What number would you like to convert from " + convert_from + " to " + convert_to + " ? ");
                                temp = float.Parse(Console.ReadLine());

                                // Converts temp into Celsius, Displays result
                                Console.WriteLine("{0} Celsius", temp - 273.15);

                                ConvertAgain();

                                break;
                            }
                        default:
                            {
                                Console.WriteLine("\nERROR: Invalid input. Please input the number which corresponds to the conversion you would like to make: ");
                                break;
                            }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nERROR: Invalid input. Please try again.");
                    Console.ReadKey();
                }
            } while (repeat_loop);
           
        }
    }
}