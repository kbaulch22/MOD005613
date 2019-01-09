//----------------------------------------------------------------------------
// Revision:        1
// Last Changed:    2018-11-16 (Fri, 16 Nov 2018)
// Author:          Katherine Baulch
// SID:             1739079
//----------------------------------------------------------------------------

namespace PetrolStationManagement
{
    class Vehicle
    {
        public string vehicleType;
        public string fuelType;
        public double refuelTime;
        public int carID;
        public static int nextCarID = 0;        

        public Vehicle(string vtp, string ftp, double rft)
        {
            vehicleType = vtp;
            fuelType = ftp;
            refuelTime = rft;
            carID = nextCarID++;
        }

    }
}
