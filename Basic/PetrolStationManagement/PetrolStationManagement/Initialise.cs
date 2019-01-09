//----------------------------------------------------------------------------
// Revision:        1
// Last Changed:    2018-11-16 (Fri, 16 Nov 2018)
// Author:          Katherine Baulch
// SID:             1739079
//----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Timers;

namespace PetrolStationManagement
{
    class Initialise
    {       
        private static void InitialisePumps()
        {
            Data.pumps = new List<Pump>();

            Pump p;

            for (int i = 0; i < 9; i++)
            {
                p = new Pump("Unleaded", i+1);
                Data.pumps.Add(p);
            }
        }
        private static void InitialiseVehicles()
        {
            Data.vehicles = new List<Vehicle>();

            // every 1.5 seconds, create a new vehicle
            Timer timer;
            timer = new Timer();
            timer.Interval = 1500;
            timer.AutoReset = true;
            timer.Elapsed += Data.CreateVehicle;
            timer.Enabled = true;
            timer.Start();
        }
        public static void InitialiseProgram()
        {
            InitialisePumps();
            InitialiseVehicles();
        }
    }
}
