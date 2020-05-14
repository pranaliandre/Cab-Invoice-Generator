///--------------------------------------------------------------------
///   Class:       CabInvoiceGenerator
///   Description: class for calculate total fare of car
///   Author:      Pranali Andre                Date: 3/5/2020
///--------------------------------------------------------------------
using Remotion.Linq.Parsing;
using System;
using System.Transactions;

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
        public const int PREMIUM_FARE = 20;
        public const int COST_PER_KILOMETER_PREMIUM = 15;
        public const int COST_PER_MINUTE_PREMIUM = 2;
        public const int NORMAL_FARE = 5;
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
        public enum RideType
        {
            NORMAL,
            PREMIUM
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
            //calculate Total Fare for normal journey type
            if (journeyType == "normal")
            {
                //calling method for calculating normal ride
                double NORMAL_RIDE_FARE = NormalRide(distance, time);
                return NORMAL_RIDE_FARE;
            }
            //calculate Total Fare for premium journey type
            if (journeyType == "premium")
            {
                //calling method for calculating premium ride
                double PREMIUM_RIDE_FARE = PremiumRide(distance, time);
                return PREMIUM_RIDE_FARE;
            }
            return 0;
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
        //calculate Total Fare for normal journey type
        public double NormalRide(double distance, int time)
        {
            try
            {
                if (distance < 0)
                {
                    throw new CabServiceException(CabServiceException.ExceptionType.ENTER_PROPER_DISTANCE, "Enter proper distance");
                }
                if(time < 0)
                {
                    throw new CabServiceException(CabServiceException.ExceptionType.ENTER_PROPER_TIME, "Enter proper time");
                }
                //if the totalfare is greater than minimum fare then return totalfare
                if (((distance * COST_PER_KILOMETER_NORMAL) + (time * COST_PER_MINUTE_NORMAL)) > NORMAL_FARE)
                {
                    return (distance * COST_PER_KILOMETER_NORMAL) + (time * COST_PER_MINUTE_NORMAL);
                }
                //if the totalfare is less than minimum fare then return normal fare
                return NORMAL_FARE;
            }
            catch (CabServiceException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }
        //calculate Total Fare for premium journey type
        public double PremiumRide(double distance, int time)
        {
            try
            {
                if (distance < 0)
                {
                    throw new CabServiceException(CabServiceException.ExceptionType.ENTER_PROPER_DISTANCE, "Enter proper distance");
                }
                if (time < 0)
                {
                    throw new CabServiceException(CabServiceException.ExceptionType.ENTER_PROPER_TIME, "Enter proper time");
                }
                //if the totalfare is greater than minimum fare then return totalfare
                if (((distance * COST_PER_KILOMETER_PREMIUM) + (time * COST_PER_MINUTE_PREMIUM)) > PREMIUM_FARE)
                {
                    return (distance * COST_PER_KILOMETER_PREMIUM) + (time * COST_PER_MINUTE_PREMIUM);
                }
                //if the totalfare is less than minimum fare then return premium fare
                return PREMIUM_FARE;
            }
            catch (CabServiceException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
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