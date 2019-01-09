//----------------------------------------------------------------------------
// Author:          Katherine Baulch
// SID:             1739079
//----------------------------------------------------------------------------

using System;
using System.Timers;

namespace PetrolStationManagement
{
    /// <summary>
    ///     Main program class containing the methods needed to run the program
    ///     on a continuous loop.
    /// </summary>
    class Program
    {
        /// <summary>
        ///     A method to run the main program loop continuously.
        /// </summary>

        /// <remarks>
        ///     This method defines the entry point of the executable program and
        ///     then initialises the program upon startup.
        /// </remarks>

        /// <param name="args">A string array that represents command line arguments.</param>
        static void Main(string[] args)
        {          
            Initialise.InitialiseProgram();          

            // keep repeating every 1.5 seconds
            Timer timer = new Timer();            
            timer.Interval = 2500;
            timer.AutoReset = true;  
            timer.Elapsed += RunProgramLoop;        
            timer.Enabled = true;
            timer.Start();

            Console.ReadLine();
        }
        /// <summary>
        ///     A method to redraw the console UI and assign vehicles to pump/queue.
        /// </summary>

        /// <remarks>
        ///     This method clears and redraws the console UI (using the most recent
        ///     data obtained in the program's lifetime) to give the impression of a 
        ///     'dynamic app'. It also calls on the AssignVehicleToPump() method to 
        ///     assign the most recently created vehicle to either a pump or the 
        ///     queue to imitate the process usually taken at a petrol station.
        /// </remarks>

        /// <param name="sender">Contains a reference to the time elapsed object which raised this event.</param>
        /// <param name="e">A parameter containing the event data.</param>
        static void RunProgramLoop(object sender, ElapsedEventArgs e)
        {            
            // redraws console to give impression of dynamic app
            Console.Clear();

            // draws user interface
            Display.DrawUI();

            // assigns created vehicle to a pump
            Data.AssignVehicleToPump();
        }
    }
}