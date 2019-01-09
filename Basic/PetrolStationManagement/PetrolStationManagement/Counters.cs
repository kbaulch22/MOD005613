//----------------------------------------------------------------------------
// Author:          Katherine Baulch
// SID:             1739079
//----------------------------------------------------------------------------

using System;

namespace PetrolStationManagement
{
    class Counters
    {        
        private static void UpdateCounters()
        {
            // gets and displays total number of vehicles serviced
            Console.Write("Total number of vehicles serviced:\t{0}\n", StaticVariables.numVehiclesServiced);
            
            // calculates and displays total amount of litres dispensed to vehicles that have been serviced
            StaticVariables.litresDispensedTotal += StaticVariables.litresDispensedToVehicle;
            Console.Write("Total number of litres of petrol sold:\t" + StaticVariables.litresDispensedTotal + "\n");

            // calculates and displays the value of fuel sold to serviced vehicles
            StaticVariables.fuelSoldValue = StaticVariables.litresDispensedTotal * 1.299;
            Console.Write("Value of petrol sold:\t\t\t£" + StaticVariables.fuelSoldValue + "\n\n");
        }
        private static void CalculateAttendantWage()
        {
            // calculates and displays 1% commission 
            double commission = StaticVariables.fuelSoldValue * 0.01;
            Console.WriteLine("Commission:\t\t\t\t£" + commission);

            // calculates and displays fuel attendant's wage for the day 
            double fuelAttendantDayRate = 19.92d, fuelAttendantDayWage = 0d;
            fuelAttendantDayWage = fuelAttendantDayRate + commission;
            Console.WriteLine("Daily Wage (inc. commission):\t\t£" + fuelAttendantDayWage);
        }
        public static void DisplayCounters()
        {
            UpdateCounters();
            CalculateAttendantWage();
            Console.WriteLine("\n");
        }
    }
}
