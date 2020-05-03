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
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        public Ride(double distance,int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
