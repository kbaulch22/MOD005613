//----------------------------------------------------------------------------
// Author:          Katherine Baulch
// SID:             1739079
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;


namespace PetrolStationManagement
{
    /// <summary>
    ///     A class used to perform all the randomly generated selections used
    ///     throughout the program.
    /// </summary>
    class Random
    {
        /// <summary>
        ///     A method to randomly select the fuel type of a newly created
        ///     vehicle.
        /// </summary>    

        /// <remarks>
        ///     This method initialises a new list of strings containing three
        ///     elements (Unleaded, Diesel and LPG) which correspond to the 
        ///     three types of fuel a vehicle can run on in this program. A new
        ///     random object (Microsoft, 2018) is then instantiated, using the
        ///     value given by the system as the random seed. The rand.Next() 
        ///     method is then used to return a non-negative random integer as an
        ///     index value - with the value of the position accessed in the list
        ///     being selected as the vehicle's fuel type.
        /// </remarks>
        public static void RandomFuelGenerator()
        {
            List<string> fuelType = new List<string> { "Unleaded", "Diesel", "LPG  " };

            // instantiates random number generator using system-supplied value as seed
            System.Random rand = new System.Random();

            int index = rand.Next(fuelType.Count);
            StaticVariables.randomFuelType = fuelType[index];
        }

        /// <summary>
        ///     A method to randomly select the vehicle type of a newly created
        ///     vehicle.
        /// </summary>    

        /// <remarks>
        ///     This method initialises a new list of strings containing three
        ///     elements (Car, Van and HGV) which correspond to the three types
        ///     of vehicle found in this program. A new random object 
        ///     (Microsoft, 2018) is then instantiated, using the value given by
        ///     the system as the random seed. The rand.Next() method is then used
        ///     to return a non-negative random integer as an index value - with
        ///     the value of the position accessed in the list being selected as
        ///     the vehicle's fuel type.
        /// </remarks>
        public static void RandomVehicleGenerator()
        {
            List<string> vehicleType = new List<string> { "Car", "Van", "HGV" };

            // instantiates random number generator using system-supplied value as seed
            System.Random rand = new System.Random();

            int index = rand.Next(vehicleType.Count);
            StaticVariables.randomVehicleType = vehicleType[index];
        }

        /// <summary>
        ///     A method to randomly select how often a new vehicle is created.
        /// </summary>    

        /// <remarks>
        ///     This method randomly generates an integer value between 1500 and
        ///     2200 (inclusive). A new random object (Microsoft, 2018) is 
        ///     instantiated, using the value given by the system as the random 
        ///     seed. The rand.Next() method is then used to return a non-negative
        ///     random integer as an index value - with the value of the position
        ///     accessed in the list being selected as the vehicle's fuel type.
        ///     
        ///     All figures are as stated in the Assignment Specification.
        /// </remarks>
        public static void RandomCreationTime()
        {
            // instantiates random number generator using system-supplied value as seed
            System.Random rand = new System.Random();

            StaticVariables.randomCreationTime = rand.Next(1500, 2201);
        }

        /// <summary>
        ///     A method to randomly select the refuel time of a newly created
        ///     vehicle.
        /// </summary>    

        /// <remarks>
        ///     This method randomly generates an integer value between 7000 and
        ///     9000 (inclusive). A new random object (Microsoft, 2018) is 
        ///     instantiated, using the value given by the system as the random 
        ///     seed. The rand.Next() method is then used to return a non-negative
        ///     random integer as an index value - with the value of the position
        ///     accessed in the list being selected as the vehicle's fuel type.
        ///     
        ///     All figures are as stated in the Assignment Specification.
        /// </remarks>
        public static void RandomRefuelTime()
        {
            // instantiates random number generator using system-supplied value as seed
            System.Random rand = new System.Random();

            StaticVariables.randomRefuelTime = rand.Next(7000, 9001);
        }
    }
}
