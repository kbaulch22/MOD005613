//----------------------------------------------------------------------------
// Author:          Katherine Baulch
// SID:             1739079
//----------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.IO;
using System.Timers;

namespace PetrolStationManagement
{
    /// <summary>
    /// 
    /// </summary>
    class Pump
    {   
        public int pumpNum;

        /// <summary>
        /// 
        /// </summary>
        
        /// <remarks>
        /// </remarks>
       
        /// <param name="pnm">Holds current pump number.</param>
        public Pump(int pnm)
        {            
            pumpNum = pnm;
        }

        public Vehicle currentVehicle = null;


        /// <summary>
        ///     A method to check whether or not the given pump is available.
        /// </summary>

        /// <remarks>
        ///     This method  
        /// </remarks>
        public bool PumpIsAvailable()
        {
            // returns TRUE if currentVehicle is NULL, meaning available
            // returns FALSE if currentVehicle is NOT NULL, meaning in use
            return currentVehicle == null;
        }

        /// <summary>
        ///     A method to 
        /// </summary>
        
        /// <remarks>
        ///     This method 
        /// </remarks>

        /// <param name="v"></param>
        public void VehicleAssigned(Vehicle v)
        {
            currentVehicle = v;

            UpdateTotalLitresDispensed(v);

            // once refuel time has elapsed, release vehicle 
            Timer timer = new Timer();
            timer.Interval = v.refuelTime;
            timer.AutoReset = false; 
            timer.Elapsed += ReleaseVehicle;
            timer.Enabled = true;
            timer.Start();
        }

        /// <summary>
        ///     A method to record the number of litres of fuel dispensed to 
        ///     the current vehicle.
        /// </summary>
        
        /// <remarks>
        ///     This method calculates the running total of number of litres
        ///     of each type of fuel dispensed. Logic is used to identify the
        ///     fuel type of the current vehicle, and the amount of litres of
        ///     fuel dispensed to that one vehicle is then calculated. This
        ///     amount is then added to the total number of litres of that
        ///     particular fuel type dispensed.
        /// </remarks>

        /// <param name="v"></param>
        private void UpdateTotalLitresDispensed(Vehicle v)
        {
            currentVehicle = v;
            float litresDispensedPerSecond = 1.5f;

            if (v.fuelType == "Unleaded")
            {
                StaticVariables.litresDispensedUnleaded = (v.refuelTime / 1000) * litresDispensedPerSecond;
            }
            else if (v.fuelType == "Diesel")
            {
                StaticVariables.litresDispensedDiesel = (v.refuelTime / 1000) * litresDispensedPerSecond;
            }
            else if (v.fuelType == "LPG  ")
            {
                StaticVariables.litresDispensedLPG = (v.refuelTime / 1000) * litresDispensedPerSecond;
            }
        }

        /// <summary>
        ///     A method to 
        /// </summary>

        /// <remarks>
        /// </remarks>

        /// <param name="sender">Contains a reference to the time elapsed object which raised this event.</param>
        /// <param name="e">A parameter containing the event data.</param>
        public void ReleaseVehicle(object sender, ElapsedEventArgs e)
        {
            // records details of the last transaction made in *.txt file
            TransactionLog.LogVehicle(currentVehicle, Data.pumpNum);
           
            // vehicle leaves forecourt, pump becomes free
            currentVehicle = null;

            // shows details of the last transaction made
            TransactionLog.ShowTransactions();

            // increment total number of vehicles serviced
            StaticVariables.vehiclesServiced++;

        }
    }
}