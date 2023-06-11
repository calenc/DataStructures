///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// 
// Project:             Project 3 - Stacks
// File Name:           Tools.cs
// Description:         Class to hold frequently used methods so they can quickly be called by other classes.
// Course:              CSCI 2210-002 - Data Structures
// Author:              Calen Cummings, cummingscc@etsu.edu
// Created:             Monday, November 8, 2021
// Copyright:           Calen Cummings, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_3___Stacks
{
    /// <summary>
    /// Tools class to hold frequently used methods.
    /// </summary>
    class Tools
    {
        /// <summary>
        /// Tokenize method modified from previous project
        /// </summary>
        /// <param name="original"></param>
        /// <param name="delimiters"></param>
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
                    string longWord = temp;
                    list.Add(longWord);
                    break;
                }


                string word = temp.Substring(0, (found)); // stores the word between the start of the string and delimited characters
                word = word.Trim();
                list.Add(word);


                if (found > 0) // to save all delimiters EXCEPT spaces as words in the string list
                {
                    string wordLim = temp.Substring(found, 1);
                    list.Add(wordLim);
                    temp = temp.Remove(found, 1);
                    temp = temp.Trim();
                }

                temp = temp.Remove(0, (found)); // remove the word from the string
                temp = temp.Trim();
            }

            return list;
        }

    }
}
