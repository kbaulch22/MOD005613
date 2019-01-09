//----------------------------------------------------------------------------
// Author:          Katherine Baulch
// SID:             1739079
//----------------------------------------------------------------------------

using System;

namespace PetrolStationManagement
{
    public class Display
    {
        private static void DrawVehicles()
        {
            Vehicle v;

            // draws vehicle queue on console
            Console.WriteLine("VEHICLES IN QUEUE:");
            for (int i = 0; i < Data.vehicles.Count; i++)
            {
                v = Data.vehicles[i];
                Console.Write("#{0} {1}, {2} | ", v.carID, v.vehicleType, v.fuelType);
            }

            Console.WriteLine("\n\n");
        }
        private static void DrawPumps()
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
        private static void DrawCounters()
        {
            Console.WriteLine("COUNTERS:");
            Counters.DisplayCounters();            
        }
        public static void DrawUI()
        {
            DrawVehicles();
            DrawPumps();
            DrawCounters();
            Console.WriteLine("VEHICLE TRANSACTION LOG:");
        }
    }
}
