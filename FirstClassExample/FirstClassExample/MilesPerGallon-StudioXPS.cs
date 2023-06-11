



/////////////////////////////////////////////////////////////////////////////////////
//
// Company Name		: Don Bailes
// Department Name	: Computer and Information Sciences 
// File Name			: MilesPerGallon.cs
// Purpose			: Class demo showing #region, properties, override, and 
//							XML comments 
// Author				: Don Bailes, E-Mail: bailes@etsu.edu
// Create Date			: Tuesday, June 21, 2011
//
//-----------------------------------------------------------------------------------
//
// Modified Date		: Tuesday, June 21, 2011
// Modified By			: Don Bailes
//
/////////////////////////////////////////////////////////////////////////////////////


using System;

namespace FirstClassExample
{
	class MilesPerGallon
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
		public MilesPerGallon (string from, string to, double start, double end, double gallons)
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
				throw new ArgumentException ("End mileage cannot be less than starting mileage");

			// Calculate the miles per gallon property  
			MPG = this.Distance / this.GallonsUsed;
		}

		/// <summary>
		/// Returns the formatted miles per gallon
		/// </summary>
		/// <returns>Calculated miles per gallon for the trip</returns>
		/// 
		public override string ToString ( )
		{
			return String.Format ("You averaged {0:#.##} MPG between {1} and {2}", MPG,
										this.strFrom, this.strTo);
		} 
		#endregion
	}
}
