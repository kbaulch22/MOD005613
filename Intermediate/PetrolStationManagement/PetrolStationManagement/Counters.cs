//----------------------------------------------------------------------------
// Author:          Katherine Baulch
// SID:             1739079
//----------------------------------------------------------------------------

using System;

namespace PetrolStationManagement
{
    /// <summary>
    ///     This class is used to update all counter values displayed on the console UI.
    /// </summary>
    class Counters
    {
        /// <summary>
        ///     A method to update counters #2 and #4 (as stated in Assignment Specification).
        /// </summary>

        /// <remarks>
        ///     This method updates the total number of vehicles serviced in the program's 
        ///     lifetime (#4) and the total value of the petrol sold (#2).
        /// </remarks>
        private static void UpdateCounters()
        {
            // gets and displays total number of vehicles serviced
            Console.Write("Total number of vehicles serviced:\t{0}\n", StaticVariables.vehiclesServiced);

            // gets and displays total number of vehicles that left the forecourt without being serviced
            Console.Write("Number of vehicles left w/o being serviced:\t{0}\n", StaticVariables.vehiclesNotServiced);

            // calculates and displays the value of fuel sold to serviced vehicles
            StaticVariables.fuelSoldValue = (StaticVariables.litresDispensedUnleadedTotal * 1.299) + (StaticVariables.litresDispensedDieselTotal * 1.299) + (StaticVariables.litresDispensedLPGTotal * 1.299);
            Console.Write("Value of petrol sold:\t\t\t£" + StaticVariables.fuelSoldValue + "\n\n");
        }

        /// <summary>
        ///     A method to update counter #1 for each type of fuel (as stated in the Assignment
        ///     Specification).
        /// </summary>

        /// <remarks>
        ///     This method updates the total number of litres dispensed for each type of 
        ///     fuel (Unleaded, LPG and Diesel) during the app's lifetime.
        /// </remarks>
        private static void UpdateLitresSold()
        {
            // calculates and displays total amount of unleaded fuel dispensed to vehicles that have been serviced
            StaticVariables.litresDispensedUnleadedTotal += StaticVariables.litresDispensedUnleaded;
            Console.Write("Total number of litres of unleaded sold:\t" + StaticVariables.litresDispensedUnleadedTotal + "\n");

            // calculates and displays total amount of diesel dispensed to vehicles that have been serviced
            StaticVariables.litresDispensedDieselTotal += StaticVariables.litresDispensedDiesel;
            Console.Write("Total number of litres of diesel sold:\t\t" + StaticVariables.litresDispensedDieselTotal + "\n");

            // calculates and displays total amount of LPG fuel dispensed to vehicles that have been serviced
            StaticVariables.litresDispensedLPGTotal += StaticVariables.litresDispensedLPG;
            Console.Write("Total number of litres of LPG fuel sold:\t" + StaticVariables.litresDispensedLPGTotal + "\n");            
        }

        /// <summary>
        ///     A method to update counter #3 and the fuel attendant's day wage inc. commission.
        /// </summary>

        /// <remarks>
        ///     This method first calculates the 1% commission by multiplying the total value
        ///     of fuel sold in the program's lifetime by 0.01. The fuel attendant's day
        ///     wage is then calculated by multiplying the hourly rate (£2.49) by the number 
        ///     of hours worked (8), and finally adding the 1% commission. 
        ///     
        ///     All figures are as stated in the Assignment Specification.
        /// </remarks>
        private static void CalculateAttendantWage()
        {
            // calculates and displays 1% commission 
            double commission = StaticVariables.fuelSoldValue * 0.01;
            Console.WriteLine("Commission:\t\t\t\t£" + commission);

            // calculates and displays a fuel attendant's day wage 
            double fuelAttendantHoursWorked = 8, fuelAttendantHourlyRate = 2.49d, fuelAttendantDayWage = 0d;
            fuelAttendantDayWage = (fuelAttendantHourlyRate * fuelAttendantHoursWorked) + commission;
            Console.WriteLine("Daily Wage (inc. commission):\t\t£" + fuelAttendantDayWage);
        }
        /// <summary>
        ///     A public method to update all counter values displayed on the console
        ///     UI.
        /// </summary>

        /// <remarks>
        ///     This method allows three private methods from the current class to be
        ///     called throughout the program whilst protecting their data members. 
        ///     This is done through data hiding, which protects the integrity of and
        ///     access to class members by preventing changes (Kumar, 2016).
        /// </remarks>
        public static void DisplayCounters()
        {
            UpdateCounters();
            UpdateLitresSold();
            CalculateAttendantWage();
            Console.WriteLine("\n");
        }
    }
}
