using System;

namespace Rectangles
{
    class Program
    {
        // defines method to calculate the integer area of a rectangle
        static void RectangleArea(int length, int width)
        {
            int area = length * width;                  // calculates integer area
            Console.WriteLine("\nArea: " + area);       // displays area to user
        }

        // defines method to calculate the float area of a rectangle
        static void RectangleArea(float length, float width)
        {
            float area = length * width;                // calculates integer area
            Console.WriteLine("\nArea: " + area);       // displays area to user
        }

        static void Main(string[] args)
        {
            // prompts user to input rectangle dimensions and stores inputs
            Console.WriteLine("Please enter rectangle length: ");
            string input_length = Console.ReadLine();
            Console.WriteLine("Please enter rectangle width: ");
            string input_width = Console.ReadLine();

            // if the string contains a period (.), convert the contents of the string variables to floats for calculation
            if (input_length.Contains(".") || input_width.Contains("."))
            {
                float length = float.Parse(input_length);
                float width = float.Parse(input_width);
                RectangleArea(length, width);
            }
            // if the string doesn't contain a period (.), convert the contents of the string variables to integers for calculation
            else
            {
                int length = Int32.Parse(input_length);
                int width = Int32.Parse(input_width);
                RectangleArea(length, width);
            }            
            Console.ReadKey();
        }
    }
}





