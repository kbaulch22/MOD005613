//----------------------------------------------------------------------------
// Revision:        1
// Last Changed:    2018-11-16 (Fri, 16 Nov 2018)
// Author:          Katherine Baulch
// SID:             1739079
//----------------------------------------------------------------------------

using System;
using System.Timers;

namespace PetrolStationManagement
{
    class Pump
    {        
        public int pumpNum;
        public string fuelType;

        public Pump(string ftp, int pnm)
        {
            pumpNum = pnm;
            fuelType = ftp;
        }



        public Vehicle currentVehicle = null;
        public bool PumpIsAvailable()
        {
            // returns TRUE if currentVehicle is NULL, meaning available
            // returns FALSE if currentVehicle is NOT NULL, meaning in use
            return currentVehicle == null;
        }

        public void VehicleAssigned(Vehicle v)
        {
            currentVehicle = v;
            StaticVariables.litresDispensedToVehicle = (v.refuelTime / 1000) * 1.50;
           
            // once refuel time has elapsed, release vehicle 
            Timer timer = new Timer();
            timer.Interval = v.refuelTime;
            timer.AutoReset = false; 
            timer.Elapsed += ReleaseVehicle;
            timer.Enabled = true;
            timer.Start();
        }               
        public void ReleaseVehicle(object sender, ElapsedEventArgs e)
        {
            // records details of the last transaction made in *.txt file
            TransactionLog.LogVehicle(currentVehicle, Data.pumpNum);
           
            // vehicle leaves forecourt, pump becomes free
            currentVehicle = null;

            // shows details of the last transaction made
            TransactionLog.ShowTransactions();

            // increments number of vehicles serviced
            StaticVariables.numVehiclesServiced++;

        }
    }
}