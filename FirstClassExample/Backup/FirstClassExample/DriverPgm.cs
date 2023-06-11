/* ------------------------------------------------------------------------------------------------
 * 
 * Purpose:		A first example
 * Author:		Don Bailes, bailes@etsu.edu
 * Date:		Tuesday, June 09, 2009
 * 
 * ----------------------------------------------------------------------------------------------*/

using System;

namespace FirstClassExample
{
	class DriverPgm
	{
		static void Main ( )
		{
			MilesPerGallon mpg = new MilesPerGallon ("Johnson City", "Charleston", 40000.1, 40336.3, 8.37);
			Console.WriteLine (mpg + "\n\n\n");
		}
	}
}
