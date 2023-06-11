///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  FirstClassExample/FirstClassExample
//	File Name:         DriverPgm.cs
//	Description:       Driver class for console application that calculates miles/gallon.  It demos the use of the  
//							Console class and the AssemblyInfo.cs file.  Requires a reference to System.Windows.Forms
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Don Bailes, bailes@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Wednesday, December 30, 2019
//	Copyright:         Don Bailes, 2020
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;
using static System.Console;

namespace FirstClassExample
{
    /// <summary>
    /// Class MPGDriver demonstrates the use of the MilesPerGallon class
    /// </summary>
    public static class MPGDriver
    {
        /// <summary>
		/// Defines the entry point of the application
		/// </summary>
		static void Main()
        {
            StartUp();

            MilesPerGallon charlestonTrip = new MilesPerGallon("Johnson City", "Charleston", 40000.1, 40336.3, 10.37);
            MilesPerGallon tripFromTampa = new MilesPerGallon("Tampa", "Johnson City", 51704, 52511, 23.17);
            MilesPerGallon tripToKingsport = new MilesPerGallon(gallons: .75, to: "Kingsport",
                                                end: 52320, from: "Johnson City", start: 52298);

            WriteLine("\n" + charlestonTrip + "\n");
            WriteLine(tripFromTampa + "\n");
            WriteLine(tripToKingsport + "\n\n\n");
            ReadLine();  // pause the program until the Enter key is pressed
        }

        /// <summary>
        /// Initialize the console colors and title
        /// </summary>
        private static void StartUp()
        {
            Title = Application.ProductName;         // Get product name from AssemblyInfo.cs
            BackgroundColor = ConsoleColor.Yellow;
            ForegroundColor = ConsoleColor.Blue;
            Clear();
        }
    }
}
