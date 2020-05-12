///--------------------------------------------------------------------
///   Class:       CabInvoiceGenerator
///   Description: class for calculate total fare of car
///   Author:      Pranali Andre                Date: 3/5/2020
///--------------------------------------------------------------------
using System;
namespace cabInvoiceGenerator
{
    public class CabInvoiceGenerator
    {
        /// <summary>
        /// constant variable
        /// </summary>
        public const int COST_PER_TIME = 1;
        public const int COST_PER_KILOMETER_NORMAL = 10;
        public const double MINIMUM_COST_PER_KILOMETER = 10;
        public const int MINIMUM_FARE_PREMIUM = 20;
        public const int COST_PER_KILOMETER_PREMIUM = 15;
        public const int COST_PER_MINUTE_PREMIUM = 2;
        public const int MINIMUM_FARE_NORMAL = 5;
        public const int COST_PER_MINUTE_NORMAL = 1;
        /// <summary>
        /// variable
        /// </summary>
        public static double minimumFare = 5;
        public static double totalFare = 0;
        public  int numberOfRides = 0;
        public  double averageFare = 0;
        public double Average
        {
            get
            {
                return this.averageFare;
            }
        }
        /// <summary>
        /// Method to calculate total fare journey of car
        /// </summary>
        /// <param name="journeyType"></param>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(string journeyType, double distance, int time)
        {
            if (journeyType == "normal")
            {
                //calculate Total Fare for normal journey type
                //if the totalfare is greater than minimum fare then return totalfare
                if (((distance * COST_PER_KILOMETER_NORMAL) + (time * COST_PER_MINUTE_NORMAL)) > MINIMUM_FARE_NORMAL)
                {
                    return (distance * COST_PER_KILOMETER_NORMAL) + (time * COST_PER_MINUTE_NORMAL);
                }
                //if the totalfare is less than minimum fare then return totalfare
                return MINIMUM_FARE_NORMAL;
            }
            //calculate Total Fare for premium journey type
            //if the totalcost is greater than minimum fare then return totalfare minimumFarePremium
            if (journeyType == "premium")
            {
                if (((distance * COST_PER_KILOMETER_PREMIUM) + (time * COST_PER_MINUTE_PREMIUM)) > MINIMUM_FARE_PREMIUM)
                {
                    return (distance * COST_PER_KILOMETER_PREMIUM) + (time * COST_PER_MINUTE_PREMIUM);
                }
                //if the totalfare is less than minimum fare then return totalfare
            }
            return MINIMUM_FARE_PREMIUM;
        }
        /// <summary>
        /// Method to given multiple rides and calculate the aggregate total   
        /// </summary>
        /// <param name="rides"></param>
        /// <returns></returns>
        public double CalculateFare(Ride[] rides)
        {
            //calculate Total Fare for multiple rides
            foreach (var total in rides)
            {
                totalFare += CalculateFare(total.rideType, total.distance, total.time);
                //count number of rides
                numberOfRides++;
            }
            //calculate average of total fare
            averageFare = totalFare / numberOfRides;
            //return a calculate total fare
            return totalFare;
        }
        /// <summary>
        /// Main function
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Cab Invoice Generator");
        }
    }
}