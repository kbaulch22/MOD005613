//----------------------------------------------------------------------------
// Revision:        1
// Last Changed:    2018-11-16 (Fri, 16 Nov 2018)
// Author:          Katherine Baulch
// SID:             1739079
//----------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.IO;
using System.Timers;

namespace PetrolStationManagement
{
    class Program
    {     
        static void Main(string[] args)
        {          
            Initialise.InitialiseProgram();

            if (File.Exists("TransactionLog.txt"))
            {
                File.Delete("TransactionLog.txt");
            }

            // keep repeating every 1.5 seconds
            Timer timer = new Timer();            
            timer.Interval = 1500;
            timer.AutoReset = true;  
            timer.Elapsed += RunProgramLoop;        
            timer.Enabled = true;
            timer.Start();

            Console.ReadLine();
        }
        static void RunProgramLoop(object sender, ElapsedEventArgs e)
        {            
            // redraws console to give impression of dynamic app
            Console.Clear();
                        
            Display.DrawUI();            

            Data.AssignVehicleToPump();
        }
    }
}
