//----------------------------------------------------------------------------
// Author:          Katherine Baulch
// SID:             1739079
//----------------------------------------------------------------------------

using System.Timers;

namespace PetrolStationManagement
{
    /// <summary>
    ///     A class to hold the details of each individual vehicle in the program.
    /// </summary>
    class Vehicle
    {
        public static Timer removalTimer;
        public string vehicleType;
        public string fuelType;
        public double refuelTime;
        public int carID;
        public static int nextCarID = 0;

        /// <summary>
        ///     
        /// </summary>

        /// <remarks>
        ///     
        /// </remarks>

        /// <param name="vtp">Holds the current type of a vehicle.</param>
        /// <param name="ftp">Holds the current fuel type of a vehicle.</param>
        /// <param name="ftm">Holds the current refuel time of a vehicle.</param>
        public Vehicle(string vtp, string ftp, double ftm) 
        {
            // Timer to remove vehicles from the forecourt if they haven't been serviced in X seconds
            //      (where X is random)          
            removalTimer = new Timer
            {
                Interval = 1500,
                AutoReset = false
            };
            removalTimer.Elapsed += Data.RemoveFromQueue;
            removalTimer.Enabled = true;
            removalTimer.Start();

            vehicleType = vtp;
            fuelType = ftp;
            refuelTime = ftm;
            carID = nextCarID++;
        }




   

    }
}
