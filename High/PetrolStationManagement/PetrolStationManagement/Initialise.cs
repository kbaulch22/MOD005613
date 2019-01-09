//----------------------------------------------------------------------------
// Author:          Katherine Baulch
// SID:             1739079
//----------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Timers;

namespace PetrolStationManagement
{
    /// <summary>
    ///     This class is used to initialise the program and all objects and 
    ///     events in it.
    /// </summary>
    class Initialise
    {   
        /// <summary>
        ///     A method used to create the nine petrol pumps.
        /// </summary>    
        
        /// <remarks>
        ///     This method creates nine instantiations of the
        ///     Pump class and adds each instantiation to the 
        ///     master Pumps list.
        /// </remarks>
        private static void InitialisePumps()
        {
            Data.pumps = new List<Pump>();

            // creates new object reference for the current pump number
            Pump p;

            for (int i = 0; i < 9; i++)
            {
                p = new Pump(i + 1); 
                Data.pumps.Add(p);
            }
        }

        /// <summary>
        ///     A method used to continuously create a new vehicle every X seconds
        ///     (where X is random).
        /// </summary>

        /// <remarks>
        ///     This method first creates a new instantiation of the Vehicles class.
        ///     It then instantiates a new timer object to fire an event every
        ///     X seconds (where X is random and between 1.5 and 2 seconds). 
        ///     An event handler is then created for the event, meaning that the 
        ///     CreateVehicle() method from the Data class is called when the
        ///     event's time interval elapses.     
        /// </remarks>
        private static void InitialiseVehicles()
        {
            Data.vehicles = new List<Vehicle>();

            // every X seconds, create a new vehicle
            Timer timer;
            timer = new Timer
            {
                Interval = Random.RandomCreationTime(),
                AutoReset = true
            };
            timer.Elapsed += Data.CreateVehicle;
            timer.Enabled = true;
            timer.Start();
        }

        /// <summary>
        ///     A method to check if the log file already exists and delete it if so.
        /// </summary>
        
        /// <remarks>
        ///     This method checks to see if the TransactionLog.txt file already 
        ///     exists, and if it does deletes the file to ensure that data from 
        ///     the program's life time is not compromised by data from a previous 
        ///     runtime.
        /// </remarks>
        private static void InitialiseFile()
        {
            if (File.Exists("TransactionLog.txt"))
            {
                File.Delete("TransactionLog.txt");
            }
        }

        /// <summary>
        ///     A public method to initialise the program and all objects and events in 
        ///     it.
        /// </summary>    

        /// <remarks>
        ///     This method allows three private methods from the current class to be
        ///     called throughout the program whilst protecting their data members. 
        ///     This is done through data hiding and encapsulation, which protects the
        ///     integrity of and access to class members by preventing changes 
        ///     (Kumar, 2016).
        /// </remarks>
        public static void InitialiseProgram()
        {
            InitialiseFile();
            InitialisePumps();
            InitialiseVehicles();
        }
    }
}
