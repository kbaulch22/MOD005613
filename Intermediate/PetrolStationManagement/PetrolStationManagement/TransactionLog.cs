//----------------------------------------------------------------------------
// Author:          Katherine Baulch
// SID:             1739079
//----------------------------------------------------------------------------

using System;
using System.IO;
using System.Collections.Generic;

namespace PetrolStationManagement
{
    /// <summary>
    ///      A class to track and display each fuelling transaction made during
    ///      the program's lifetime. 
    /// </summary>
    class TransactionLog
    {
        public static Vehicle currentVehicle = null;

        /// <summary>
        ///     A method to record each fuelling transaction (counter #6 as per
        ///     the Assignment Specification).
        /// </summary>
        
        /// <remarks>
        ///     This method uses the StreamWriter class to write the details of
        ///     each transaction to the TransactionLog.txt file. As per the 
        ///     Assignment Specification, the transaction log records the vehicle
        ///     type, the number of litres of fuel dispensed to that vehicle and
        ///     the pump number at which they were serviced. The file is then 
        ///     closed so that it can be accessed for display.
        /// </remarks>

        /// <param name="v"></param>
        /// <param name="p"></param>
        public static void LogVehicle(Vehicle v, Pump p)
        {
            currentVehicle = v;
            Data.pumpNum = p;

            try
            {        
                // passes filepath and filename to streamWriter constructor
                StreamWriter sw = new StreamWriter("TransactionLog.txt", true);

                // writes transaction details to file                
                if (v.fuelType == "Unleaded")
                {
                    sw.WriteLine("{0}.\tVehicle Type: {1}\tFuel Type: {4}\tPump No. : {2}\tLitres Dispensed to Vehicle: {3}\n", v.carID, v.vehicleType, p.pumpNum, StaticVariables.litresDispensedUnleaded, v.fuelType);
                }
                else if (v.fuelType == "Diesel")
                {
                    sw.WriteLine("{0}.\tVehicle Type: {1}\tFuel Type: {4}\tPump No. : {2}\tLitres Dispensed to Vehicle: {3}\n", v.carID, v.vehicleType, p.pumpNum, StaticVariables.litresDispensedDiesel, v.fuelType);

                }
                else if (v.fuelType == "LPG  ")
                {
                    sw.WriteLine("{0}.\tVehicle Type: {1}\tFuel Type: {4}\tPump No. : {2}\tLitres Dispensed to Vehicle: {3}\n", v.carID, v.vehicleType, p.pumpNum, StaticVariables.litresDispensedLPG, v.fuelType);
                }

                // closes file so it can be accessed
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        /// <summary>
        ///     A method to display the vehicle transaction log (counter #6).
        /// </summary>

        /// <remarks>
        ///     This method uses the StreamReader class to read the 
        ///     TransactionLog.txt file and displays its contents on the console
        ///     UI.
        /// </remarks>
        public static void ShowTransactions()
        {
            // shows details of all transactions made
            try
            {
                // passes the filepath and filename to streamReader constructor
                using (StreamReader sr = new StreamReader("TransactionLog.txt"))
                {
                    Console.WriteLine("VEHICLE TRANSACTION LOG:");
                    string line;
                    List<string> lst = new List<string>();

                    // read and display lines from file to console until end of file
                    while ((line = sr.ReadLine()) != null)
                    {
                        // write line to console
                        Console.WriteLine(line);

                        // read next line
                        line = sr.ReadLine();
                    }

                    //while (!sr.EndOfStream)
                    //{
                    //    lst.Add(sr.ReadLine());
                    //}

                    //lst.Reverse();

                    //for (int i = 0; i < lst.Count; i++)
                    //{
                    //    Console.WriteLine(lst[0]);
                    //}

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
