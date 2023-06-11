/////////////////////////////////////////////////////////////////////////////////////
//
// Company Name		: Don Bailes
// Department Name	: Computer and Information Sciences 
// File Name			: DriverPgm.cs
// Purpose			: Driver class for console application that calculates 
//							miles/gallon.  It demos the use of the Console 
//							class and the AssemblyInfo.cs file.  Requires a 
//							reference to System.Windows.Forms. 
// Author				: Don Bailes, E-Mail: bailes@etsu.edu
// Create Date			: Monday, June 07, 2010
//
//-----------------------------------------------------------------------------------
//
// Modified Date		: Monday, June 07, 2010
// Modified By			: Don Bailes
//
/////////////////////////////////////////////////////////////////////////////////////


using System;
using System.Windows.Forms;

namespace FirstClassExample
{
	class DriverPgm
	{
		static void Main ( )
		{
			StartUp ( );

			MilesPerGallon CharlestonTrip = new MilesPerGallon ("Johnson City", "Charleston", 40000.1, 40336.3, 10.37);
			MilesPerGallon TripFromTampa = new MilesPerGallon ("Tampa", "Johnson City", 51704, 52511, 23.17);

			MilesPerGallon TripToKingsport = new MilesPerGallon (gallons: .75, to: "Kingsport", 
												end: 52320, from: "Johnson City", start: 52298);

			Console.WriteLine ("\n" + CharlestonTrip + "\n");
			Console.WriteLine (TripFromTampa + "\n");
			Console.WriteLine (TripToKingsport + "\n\n\n");

			Console.ReadLine ( );  // pause the program until the Enter key is pressed
		}

		/// <summary>
		/// Initialize the console colors and title
		/// </summary>
		private static void StartUp ( )
		{
			Console.Title = Application.ProductName;		// Get product name from AssemblyInfo.cs
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Blue;
		}
	}
}
