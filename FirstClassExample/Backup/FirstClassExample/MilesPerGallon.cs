using System;

namespace FirstClassExample
{
	class MilesPerGallon
	{
		private string strFrom, strTo;
		private double odometerStart, miles, gallonsUsed;

		/// <summary>
		/// Constructor initializes attributes from parameters and calculates miles per gallon.
		/// </summary>
		/// <param name="from">Starting location</param>
		/// <param name="to">Destination</param>
		/// <param name="start">Beginning odometer reading</param>
		/// <param name="end">Final odometer reading</param>
		/// <param name="gallons">Gallons of fuel used</param>
		public MilesPerGallon (string from, string to, double start, double end, double gallons)
		{
			this.strFrom = from;
			this.strTo = to;
			this.odometerStart = start;
			this.OdometerEnd = end;
			this.gallonsUsed = gallons;

			// Verify that the end reading is not lower than the start
			if (end >= start)
				this.miles = end - start;
			else
				throw new ArgumentException ("End mileage cannot be less than starting mileage");

			// Calculate the miles per gallon property
			MPG = this.miles / this.gallonsUsed;
		}

		/// <summary>
		/// Returns the formatted miles per gallon
		/// </summary>
		/// <returns>Calculated miles per gallon for the trip</returns>
		public override string ToString ( )
		{
			return String.Format ("You averaged {0:#.##} between {1} and {2}", MPG,
										this.strFrom, this.strTo);
		}

		/// <summary>
		/// Public property: MPG - miles per gallon
		/// </summary>
		public double MPG { get; set; }

		/// <summary>
		/// Property representing the odometer reading at the destination
		/// </summary>
		public double OdometerEnd { get; set; }
	}
}
