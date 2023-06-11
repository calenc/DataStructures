/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Project:        Project 1 - Strings, Files, and Lists
//  File Name:      Tools.cs
//  Description:    This class provides the necessary methods to allow the driver class functionality for text handling and formatting.
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
    /// This class provides the methods that the driver will need to give the program functionality, handle text files, and format mulitple strrings.
    /// </summary>
    class Tools
    {

        /// <summary>
        /// Creates a message box with a message welcoming the user and stating the program's purpose.
        /// </summary>
        /// <param name="message">The message/body of the box.</param>
        /// <param name="caption">The caption of the box.</param>
        /// <param name="author">The author.</param>
        public static void WelcomeMessage(String message, String caption, String author)
        {
            message = "Welcome! This program was created to demonstrate Text File handling and working with Strings and Lists.";
            caption = "CSCI 2210 Project 1";

            MessageBox.Show(message, caption);
        }

        /// <summary>
        /// Goodbye message that will display when the program is ended/closed.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void GoodbyeMessage(String message)
        {
            message = "Thank you for using this program. Goodbye!";

            MessageBox.Show(message);
        }

        /// <summary>
        /// Sets the console window for the program, readying the caption, clearing the console, and setting 
        /// background/foreground colors.
        /// </summary>
        public static void Setup()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Title = "Project 1 - Strings, Files, and Lists";
            Console.Clear();
            
            WelcomeMessage("m", "c", "a");

            
        }

        /// <summary>
        /// Removes any trailing or leading spaces/tab characters, and replaces carriage return-newline with newline characters in the string work
        /// and returns the "worked on" string.
        /// </summary>
        /// <param name="work">The work string generated in another method, to help identify each unique word in a string.</param>
        /// <returns></returns>
        private static string CleanString(ref string work)
        {
            work = work.Trim(' '); // Trims any leading/trailing spaces
            work = work.Trim('\n'); // Trims any leading/trailing newline characters
            work = work.Replace("\r\n", "\n"); // Replaces any carriage-return, newline combinations with just a newline character

            return work; // returns the now "cleaned" work string
        }

        /// <summary>
        /// Tokenizes the specified original. Creates a list of words that we can use to format the text as we please.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <param name="delimiters">The delimiters.</param>
        /// <returns></returns>
        public static List<string> Tokenize(string original, string delimiters)
        {
            string temp = original;

            List<string> list = new List<string>();

            while (temp.Length > 0) // while characters are still in the string
            {
                int found;
                found = temp.IndexOfAny(delimiters.ToCharArray());

                if (found == 0) // if a delimiter character is at the start of the string
                {
                    string wordLim = temp.Substring(0, 1);
                    list.Add(wordLim);
                    temp = temp.Remove(found, 1);

                }

                if (found < 0) // if no delimiter is found
                {
                    string longWord = CleanString(ref temp);
                    list.Add(longWord);
                    break;
                }
                    

                string word = temp.Substring(0, (found)); // stores the word between the start of the string and delimited characters

                list.Add(word);

                if ((found >= 0) && temp.Substring(found, 1) != " ") // to save all delimiters EXCEPT spaces as words in the string list
                {
                    string wordLim = temp.Substring(found, 1);
                    list.Add(wordLim);
                    temp = temp.Remove(found, 1);

                }

                temp = temp.Remove(0, (found)); // remove the word from the string

                temp = CleanString(ref temp); // clears leading spaces so the loop can start again with the next word being the start of the string


            }

            return list;
        }

        /// <summary>
        /// Formats the string list to a specified margin width.
        /// </summary>
        public static String Format(List<string> list, int leftMargin, int rightMargin)
        {
            string formatStr = "";

            string delims = " ,.?!-;:'{}[]()$'";

            for (int i = 0; i < list.Count(); i++)
            {

                if (delims.Contains(list[i]))
                {
                    formatStr = formatStr.Trim();
                    formatStr += (list[i] + " ");  // for delimiters like commmas and apostrophes, make sure we trim leading spaces from a previous
                                                   // word print and then print the delimiter character, so punctuation and spacing stays correct
                }
                else
                    formatStr += (list[i] + " ");

            }

            // Not sure how to incorporate the margins without outside sources, can't seem to find any suggestive/hinting material in the Lecture PowerPoints available to us

            return formatStr;
        }


        /// <summary>
        /// Method to make the menu/program wait for user to press a key before moving along.
        /// </summary>
        public static void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Prints all of the words/strings contained in the list.
        /// </summary>
        /// <param name="list">The list.</param>
        public static void ListPrint(List<string> list)
        {
            Console.WriteLine("\n");

            for (int i = 0; i < list.Count(); i++)
            {
                Console.WriteLine("{0}. {1}", (i + 1).ToString().PadLeft(3), list[i]);
            }
        }
    }
}
