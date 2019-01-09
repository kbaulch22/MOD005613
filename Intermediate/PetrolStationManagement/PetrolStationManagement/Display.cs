//----------------------------------------------------------------------------
// Author:          Katherine Baulch
// SID:             1739079
//----------------------------------------------------------------------------

using System;

namespace PetrolStationManagement
{
    /// <summary>
    ///     This class is used to draw all elements of the program onto the console
    ///     UI.
    /// </summary>
    public class Display
    {
        /// <summary>
        ///     A method to draw the vehicle queue onto the console UI.
        /// </summary>    

        /// <remarks>
        ///     This method draws the vehicle queue onto the console UI. Every
        ///     vehicle in the 'vehicles' list that has not been assigned to a 
        ///     pump or left the forecourt before assignation is displayed in 
        ///     the vehicle queue alongside it's ID, type and fuel type.
        /// </remarks>
        private static void DrawVehicleQueue()
        {
            Vehicle v;

            // draws vehicle queue on console
            Console.WriteLine("VEHICLES IN QUEUE:");
            for (int i = 0; i < Data.vehicles.Count; i++)
            {
                v = Data.vehicles[i];
                Console.Write("#{0} {1}, {2} | ", v.carID, v.vehicleType,  v.fuelType);
            }

            Console.WriteLine("\n\n");
        }

        /// <summary>
        ///     A method to draw the petrol station forecourt onto the console UI.
        /// </summary>    

        /// <remarks>
        ///     This method draws the petrol station forecourt onto the console UI. 
        ///     It first calls on the PumpIsAvailable() method to return true if 
        ///     the pump is available and false if it's in use, and then writes the
        ///     pump status (either INUSE or EMPTY) to the console. The nine pumps
        ///     are then arranged in lanes of three. 
        /// </remarks>
        private static void DrawForecourt()
        {
            Pump p;

            // draws petrol station layout on console
            Console.WriteLine("PUMP STATUS:\n");
            for (int i = 0; i < 9; i++)
            {
                p = Data.pumps[i];

                Console.Write("-------");
                Console.Write("#{0} ", i + 1);
                if (p.PumpIsAvailable())
                {
                    Console.Write("EMPTY");
                }
                else
                {
                    Console.Write("INUSE");
                }
                // arranges 9 pumps in forecourt over 3 lanes               
                if (i % 3 == 2)
                {
                    Console.WriteLine("\n");
                }
            }

            Console.WriteLine("\n");
        }

        /// <summary>
        ///     A method to draw the counters and their values onto the console UI.
        /// </summary>    

        /// <remarks>
        ///     This method calls on the DisplayCounters() method to update the counter
        ///     values and then displays them on the console UI.
        /// </remarks>
        private static void DrawCounters()
        {
            // displays counters on console
            Console.WriteLine("COUNTERS:");
            Counters.DisplayCounters();
        }

        /// <summary>
        ///     A public method to draw all elements of the program onto the console
        ///     UI.
        /// </summary>    

        /// <remarks>
        ///     This method allows three private methods from the current class to be
        ///     called throughout the program whilst protecting their data members. 
        ///     This is done through data hiding, which protects the integrity of and
        ///     access to class members by preventing changes (Kumar, 2016).
        /// </remarks>
        public static void DrawUI()
        {
            // draws user interface to console
            DrawVehicleQueue();
            DrawForecourt();
            DrawCounters();
        }
    }
}
