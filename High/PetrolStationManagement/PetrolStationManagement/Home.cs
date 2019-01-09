//----------------------------------------------------------------------------
// Author:          Katherine Baulch
// SID:             1739079
//----------------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace PetrolStationManagement
{
    /// <summary>
    ///     This class is used to draw all elements of the program onto the console
    ///     UI.
    /// </summary>
    static class Home
    {
        /// <summary>
        ///     A method to display the application title on the console UI.
        /// </summary>

        /// <remarks>
        ///     This method displays the app title (as an ASCII text banner)
        ///     on the console UI (patorjk.com, 2018). 
        /// </remarks>
        private static void DrawHome()
        {
            Console.WriteLine(@"   ___     _             _   __ _        _   _                                                                        _   ");
            Console.WriteLine(@"  / _ \___| |_ _ __ ___ | | / _| |_ __ _| |_(_) ___  _ __     /\/\   __ _ _ __   __ _  __ _  ___ _ __ ___   ___ _ __ | |_ ");
            Console.WriteLine(@" / /_)/ _ | __| '__/ _ \| | \ \| __/ _` | __| |/ _ \| '_ \   /    \ / _` | '_ \ / _` |/ _` |/ _ | '_ ` _ \ / _ | '_ \| __|");
            Console.WriteLine(@"/ ___|  __| |_| | | (_) | | _\ | || (_| | |_| | (_) | | | | / /\/\ | (_| | | | | (_| | (_| |  __| | | | | |  __| | | | |_ ");
            Console.WriteLine(@"\/    \___|\__|_|  \___/|___\__/\__\__,_|\__|_|\___/|_| |_| \/    \/\__,_|_| |_|\__,_|\__, |\___|_| |_| |_|\___|_| |_|\__|");
            Console.WriteLine(@"                                                     /   \__ ___ _ __ ___ _           |___/                               ");
            Console.WriteLine(@"                                                    / /\ / _ | '_ ` _ \ / _ \                                              ");
            Console.WriteLine(@"                                                   / /_/|  __| | | | | | (_) |                                             ");
            Console.WriteLine(@"                                                  /___,' \___|_| |_| |_|\___/                                              ");
            Console.WriteLine();
        }

        /// <summary>
        ///     A method to display the welcome message and menu to the user on 
        ///     startup.
        private static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to PSM v1.0! Before the demo begins, PSM requires some data in order to tailor the application specifically for " +
                              "your\nCompany's needs. This data helps us to create a more realistic, valuable tool to aid your Company in the management" +
                              " of\nstations worldwide.\n\n");
        }

        /// <summary>
        ///     A method to display the startup menu to the user.
        /// </summary>

        /// <remarks>
        ///     This method provides the user with the option to input their own fuel
        ///     prices (and no. of litres a pump can dispense per second) or use the
        ///     system defaults. If the user chooses to use the default values, the
        ///     UseDefaultValues() method is called - but if they choose to enter these 
        ///     values manually, the InputUserData() method is called.
        /// </remarks>
        private static void DisplayMenu()
        { 
            bool repeat = true;

            do
            {                
                Console.Write("The system requires prices for all three types of fuel available at stations (Unleaded, Diesel and LPG), as well as\n" +
                                "the amount of litres of fuel a pump can dispense per second. Would you like this data to be entered\n" +
                                "\t1) Manually?\n\t2) Automatically?\n\nPlease input an option number and press enter/return to continue: ");

                try
                {
                    // converts user choice to integer value
                    int user_choice = Int32.Parse(Console.ReadLine());

                    if (user_choice == 1)
                    {
                        // display message box to user telling them they are trying to access a pro feature (Maruf, 2015)
                        MessageBox.Show("Sorry, this is a feature of PSM:Pro. Please visit our website for more detail on how to upgrade your package today.", "PSM:Demo");
                        Console.Clear();
                        DrawHome();                        
                    }
                    else if (user_choice == 2)
                    {
                        UseDefaultValues();
                        Console.WriteLine("Press any key to continue...\n");
                        repeat = false;
                    }
                    else
                    {
                        ErrorMessage();
                    }
                }
                catch (FormatException)
                {
                    ErrorMessage();
                }
            } while (repeat);       
        }

        /// <summary>
        ///     A method to set the default data values for use in the program.
        /// </summary>

        /// <remarks>
        ///     This method is used to set the default data values for  
        ///     later use by the program. All prices are based off UK
        ///     averages and are written in pounds, not pence. The litres
        ///     dispensed per second value is set by default to 1.5, as 
        ///     per the Assignment Specification.
        /// </remarks>
        private static void UseDefaultValues()
        {
            StaticVariables.litresDispensedPerSecond = 1.5d;
            StaticVariables.unleadedPrice = 1.249d;
            StaticVariables.dieselPrice = 1.349d;
            StaticVariables.lpgPrice = 0.669d;
        }

        /// <summary>
        ///     A method to display an error message on the console.
        /// </summary>
        
        /// <remarks>
        ///     This method displays an error message to the user on 
        ///     the console when they have not entered a valid input.
        /// </remarks>
        private static void ErrorMessage()
        {
            // displays error message to user
            Console.WriteLine("\nERROR: Invalid input. Please press enter/return to try again.");
            Console.ReadKey();
            Console.Clear();
            DrawHome();
        }

        /// <summary>
        ///     A public method to draw the program title and startup message 
        ///     onto the console UI.
        /// </summary>

        /// <remarks>
        ///     This method allows two private methods from the current class to be
        ///     called on program startup whilst protecting their data members. 
        ///     This is done through data hiding and encapsulation, which protects the
        ///     integrity of and access to class members by preventing changes 
        ///     (Kumar, 2016).
        /// </remarks>
        public static void DisplayStartup()
        {
            DrawHome();
            DisplayWelcomeMessage();
            DisplayMenu();
        }
    }
}
