//----------------------------------------------------------------------------
// Revision:        1
// Last Changed:    2018-11-16 (Fri, 16 Nov 2018)
// Author:          Katherine Baulch
// SID:             1739079
//----------------------------------------------------------------------------

using System;
using System.Text;
using System.IO;

namespace PetrolStationManagement
{
    class TransactionLog
    {
        public static Vehicle currentVehicle = null;
        public static void LogVehicle(Vehicle v, Pump p)
        {
            currentVehicle = v;
            Data.pumpNum = p;

            try
            {
                // passes filepath and filename to streamWriter constructor
                StreamWriter sw = new StreamWriter("TransactionLog.txt", true, Encoding.ASCII);

                // writes transaction details to file
                sw.WriteLine("{0}.\tVehicle Type: {1}\tPump No. : {2}\tLitres Dispensed to Vehicle: {3}\n", v.carID, v.vehicleType, p.pumpNum, StaticVariables.litresDispensedToVehicle);

                // closes file so it can be accessed
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
        public static void ShowTransactions()
        {
            // shows details of the last transaction made
            try
            {
                // passes the filepath and filename to streamReader constructor
                using (StreamReader sr = new StreamReader("TransactionLog.txt"))
                {
                    string line;

                    // read and display lines from file to console until end of file
                    while ((line = sr.ReadLine()) != null)
                    {
                        // write line to console
                        Console.WriteLine(line);

                        // read next line
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}

