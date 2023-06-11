/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Project:        Project 1 - Strings, Files, and Lists
//  File Name:      Project1Driver.cs
//  Description:    This class runs the program and allows the user to select text files to display in a new format.
//  Course:         CSCI 2210-002 - Data Structures
//  Author:         Calen Cummings, cummingscc@etsu.edu
//  Created:        Monday, September 27, 2021
//  Copyright:      Calen Cummings, 2021
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStructuresProject1
{
    /// <summary>
    /// Driver class of the project that allows the user to interact with the program and see it run.
    /// </summary>
    class Project1Driver
    {

        private static List<string> fileList = new List<string>(); // Holds the created list from the opened file so that we can allow
                                                                   // other methods/functionality to easily interact with the local List

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        [STAThread]
        static void Main(string[] args)
        {
            Tools.Setup();
            BuildMenu(); // Menu provides all the functionality needed in the driver to test text files and string formatting.
        }

        /// <summary>
        /// Builds the menu for the program.
        /// </summary>
        /// <returns></returns>
        public static void BuildMenu()
        {
            Menu projMenu = new Menu("Project 1 - Strings and Text Files");

            projMenu = projMenu + "Get text from a text file"; // adds the first choice to the menu
            projMenu = projMenu + "Format text for output to the console"; // adds the second choice
            projMenu = projMenu + "Display all the words in the file"; // adds the third choice
            projMenu = projMenu + "Exit the program"; // adds the last menu choice

            projMenu.Display();

            int userChoice = projMenu.GetChoice();

            while (userChoice <= 4) // Loop conditions present to make sure the menu keeps popping up for the user after each function, failed or not.
            {
                switch (userChoice)
                {
                    case 1:
                        fileList.Clear(); // clears out the local list so that only one file at a time can be tokenized and displayed through the menu
                        OpenFile();
                        userChoice = projMenu.GetChoice();
                        break;

                    case 2:
                        if (fileList.Count() == 0) // if the local list is empty, then a file has not been loaded to fill it
                            Console.WriteLine("There is no file loaded to pull from. Please open a file, and then try again.");
                        else
                            Console.WriteLine(Tools.Format(fileList, 5, 80));

                        Tools.PressAnyKey();
                        userChoice = projMenu.GetChoice();
                        break;

                    case 3:
                        if (fileList.Count() == 0) // if the local list is empty, then a file has not been loaded to fill it
                            Console.WriteLine("There is no file loaded to pull from. Please open a file, and then try again.");
                        else
                            Tools.ListPrint(fileList);

                        Tools.PressAnyKey();
                        userChoice = projMenu.GetChoice();
                        break;

                    case 4:
                        Tools.GoodbyeMessage("gb");
                        Environment.Exit(-1); // closes the program
                        break;

                }

            }
        }

        /// <summary>
        /// Contains the code for an OpenFileDialog.
        /// </summary>
        public static void OpenFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.InitialDirectory = Application.StartupPath + @".\.\TestData"; // Steps back two folders from the executable location to our project folder containing our text files
            dlg.Title = "Open a Text File";
            dlg.Filter = "text files|*.txt|all files|*.*";

            if (dlg.ShowDialog() == DialogResult.Cancel)
            {
                Console.WriteLine("No file was selected. Returning to menu...");
                Tools.PressAnyKey();
                return;             // if no file is selected, state this and then redirect the user back to the menu
            }

            StreamReader chosenRead = new StreamReader (dlg.FileName);

            string delimiters = " ,.?!-;:'{}[]()$'";

            try
            {
                while (chosenRead.Peek() != -1)
                {
                    string original = chosenRead.ReadLine();

                    List<string> tokens = Tools.Tokenize(original, delimiters);
                    
                    fileList.AddRange(tokens); // adds the list of strings returned from the Tokenize method to the local List so that our read data is stored
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error processing the file."); // if there is an error, kick back to the menu. Repeated attempts on the same file will likely return the same exception
                Tools.PressAnyKey();
                return;
            }
            finally
            {
                if (chosenRead != null)
                {
                    chosenRead.Close(); // Closes the file after I/O, whether the file successfully opened or not.
                }
            }
            Console.WriteLine("File chosen, and text processed!");  // the selected file is stored for other methods to use, and the console lets the user know the 
                                                                    // file selection was successful

            Tools.PressAnyKey();

        }
    }
}
