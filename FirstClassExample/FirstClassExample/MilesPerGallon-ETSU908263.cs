///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  FirstClassExample/FirstClassExample
//	File Name:         MilesPerGallon.cs
//	Description:       Class demo showing #region, properties, override, and XML comments
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Don Bailes, bailes@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Tuesday, August 29, 2017
//	Copyright:         Don Bailes, 2017
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace FirstClassExample
{
    public class MilesPerGallon
    {
        private string strFrom, strTo;
        private double Distance, GallonsUsed;

        #region Public Properties
        /// <summary>
        /// Public property: MPG - miles per gallon
        /// </summary>
        public double MPG { get; set; }

        /// <summary>
        /// Public property: the starting mileage reading of the odometer
        /// </summary>
        public double OdometerStart { get; set; }

        /// <summary>
        /// Property representing the odometer reading at the destination
        /// </summary>
        public double OdometerEnd { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Constructor initializes attributes from parameters and calculates miles per gallon.
        /// </summary>
        /// <param name="from">Starting location</param>
        /// <param name="to">Destination</param>
        /// <param name="start">Beginning odometer reading</param>
        /// <param name="end">Final odometer reading</param>
        /// <param name="gallons">Gallons of fuel used</param>
        public MilesPerGallon(string from, string to, double start, double end, double gallons)
        {
            this.strFrom = from;
            this.strTo = to;
            this.OdometerStart = start;
            this.OdometerEnd = end;
            this.GallonsUsed = gallons;

            // Verify that the end reading is not lower than the start
            if (this.OdometerEnd >= this.OdometerStart)
            {
                this.Distance = this.OdometerEnd - this.OdometerStart;
            }
            else
                throw new ArgumentException("End mileage cannot be less than starting mileage");

            // Calculate the miles per gallon  
            MPG = this.Distance / this.GallonsUsed;
        }

        /// <summary>
        /// Returns the formatted miles per gallon
        /// </summary>
        /// <returns>Calculated miles per gallon for the trip</returns>
        /// 
        public override string ToString()
        {
            return $"You averaged {MPG:0.##} MPG between {strFrom} and {strTo}";
        }
        #endregion
    }
}
