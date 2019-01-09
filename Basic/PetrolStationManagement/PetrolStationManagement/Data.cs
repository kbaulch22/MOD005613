//----------------------------------------------------------------------------
// Author:          Katherine Baulch
// SID:             1739079
//----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Timers;

namespace PetrolStationManagement
{
    class Data
    {
        public static List<Vehicle> vehicles;

        public static Pump pumpNum;
        public static List<Pump> pumps;

        public static Pump currentPump;
        public static Pump previousPump;

        public static void CreateVehicle(object sender, ElapsedEventArgs e)
        {
            // unleaded, 8 second fuel time
            Vehicle car = new Vehicle("Car", "Unleaded", 8 * 1000);
            vehicles.Add(car);
        }


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
                            pumpNum = endLanePump;
                        }
                        else
                        {
                            v = vehicles[0];                        // get first vehicle in queue
                            vehicles.RemoveAt(0);                   // remove vehicle from queue
                            middleLanePump.VehicleAssigned(v);      // assign it to pump 
                            pumpNum = middleLanePump;
                        }
                    }
                    else
                    {
                        v = vehicles[0];                        // get first vehicle in queue
                        vehicles.RemoveAt(0);                   // remove vehicle from queue
                        firstLanePump.VehicleAssigned(v);       // assign it to pump
                        pumpNum = firstLanePump;
                    }
                }

                if (vehicles.Count == 0)
                {
                    break;
                }
            }
        }
    }
}
