///--------------------------------------------------------------------
///   Class:       Ride
///   Description: Class for ride 
///   Author:      Pranali Andre                   Date: 3/5/2020
///--------------------------------------------------------------------
using System;
namespace cabInvoiceGenerator
{
    public class Ride
    {
        /// <summary>
        /// variable
        /// </summary>
        public double distance;
        public int time;
        public string rideType;
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        public Ride(string rideType,double distance, int time )
        {
            this.distance = distance;
            this.time = time;
            this.rideType = rideType;
        }
    }
}
