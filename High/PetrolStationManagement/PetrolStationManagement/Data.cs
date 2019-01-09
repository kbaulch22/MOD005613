//----------------------------------------------------------------------------
// Author:          Katherine Baulch
// SID:             1739079
//----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Timers;

namespace PetrolStationManagement
{
    /// <summary>
    ///     A class used to create new vehicles and assign them to empty pumps. 
    /// </summary>
    class Data
    {
        public static Pump pumpNum;
        public static List<Vehicle> vehicles;
        public static List<Pump> pumps;

        /// <summary>
        ///     A method used to create new vehicles.
        /// </summary>

        /// <remarks>
        ///     This method calls upon the RandomVehicleGenerator(), 
        ///     RandomFuelGenerator() and RandomRefuelTime() every time it is
        ///     called to ensure that the values generated from these methods
        ///     are truly random. It then creates a new vehicle with a random
        ///     type, fuel type and refuel time. This vehicle is then added to
        ///     the master list 'vehicles'.
        /// </remarks>

        /// <param name="sender">Contains a reference to the time elapsed object which raised this event.</param>
        /// <param name="e">A parameter containing the event data.</param>
        public static void CreateVehicle(object sender, ElapsedEventArgs e)
        {
            string randomVehicleType = Random.RandomVehicleGenerator();

            // queue limit

            // creates a vehicle with a random vehicle type, fuel type and refuel time
            Vehicle vehicle = new Vehicle(randomVehicleType);

            // adds vehicle to the 'vehicles' list
            vehicles.Add(vehicle);
        }

        /// <summary>
        ///     A method to assign a vehicle to a pump should it be available.
        /// </summary>    

        /// <remarks>
        ///     This method uses logic to assign each vehicle in the 'vehicles' 
        ///     list to the 'last available' pump. This means that instead of 
        ///     simply assigning each vehicle sequentially during the program's 
        ///     lifetime, the app now simulates a real petrol station by operating
        ///     a queuing system in the forecourt. 
        ///     
        ///     This queuing system means that a vehicle using pump #1 would block
        ///     new vehicles access to pumps #2 and #3 (the same applies for the
        ///     other lanes) - as per figure #1 in the Assignment Specification.
        /// </remarks>
        public static void AssignVehicleToPump()
        {
            Vehicle v;
            Pump firstLanePump = null;
            Pump middleLanePump = null;
            Pump endLanePump = null;

            if (vehicles.Count == 0)
            {
                return;
            }

            for (int i = 0; i < 9; i += 3)
            {
                firstLanePump = pumps[i];

                if (firstLanePump.PumpIsAvailable())
                {
                    middleLanePump = pumps[i + 1];

                    if (middleLanePump.PumpIsAvailable())
                    {
                        endLanePump = pumps[i + 2];

                        if (endLanePump.PumpIsAvailable())
                        {
                            v = vehicles[0];                        // get first vehicle in queue
                            vehicles.RemoveAt(0);                   // remove vehicle from queue
                            endLanePump.VehicleAssigned(v);         // assign it to pump
                            Vehicle.removalTimer.Enabled = false;   // stop timer
                            pumpNum = endLanePump;
                        }
                        else
                        {
                            v = vehicles[0];                        // get first vehicle in queue
                            vehicles.RemoveAt(0);                   // remove vehicle from queue
                            middleLanePump.VehicleAssigned(v);      // assign it to pump                            
                            Vehicle.removalTimer.Enabled = false;   // stop timer
                            pumpNum = middleLanePump;
                        }
                    }
                    else
                    {
                        v = vehicles[0];                        // get first vehicle in queue
                        vehicles.RemoveAt(0);                   // remove vehicle from queue
                        firstLanePump.VehicleAssigned(v);       // assign it to pump
                        Vehicle.removalTimer.Enabled = false;   // stop timer
                        pumpNum = firstLanePump;
                    }
                }

                if (vehicles.Count == 0)
                {
                    break;
                }
            }
        }

        /// <summary>
        ///     A method to remove a vehicle from the forecourt if it isn't serviced.
        /// </summary>

        /// <remarks>
        ///     This method removes the vehicle from the master list of vehicles if it
        ///     isn't serviced in X seconds (where X is between 1000 and 2000 milli-
        ///     seconds). The number of vehicles which left the forecourt without being
        ///     serviced is then incremented so the value can be updated on the console 
        ///     UI.
        /// </remarks>

        /// <param name="sender">Contains a reference to the time elapsed object which raised this event.</param>
        /// <param name="e">A parameter containing the event data.</param>
        public static void RemoveFromQueue(object sender, ElapsedEventArgs e)
        {
            // remove vehicle from master list
            vehicles.RemoveAt(0);

            // increment number of vehicles which left the forecourt without being serviced
            StaticVariables.vehiclesNotServiced++;
        }
    }
}

