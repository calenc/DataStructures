///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// 
// Project:             Project 2 - Personal Library
// File Name:           PersonalLibrary.cs
// Description:         Class that holds a private list for the Library, and provides methods necessary to provide interaction and functionality with the library.
// Course:              CSCI 2210-002 - Data Structures
// Author:              Calen Cummings, cummingscc@etsu.edu
// Created:             Saturday, October 16, 2021
// Copyright:           Calen Cummings, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProject2
{
    /// <summary>
    /// Holds the Library list and provides methods to interact with the library.
    /// </summary>
    class PersonalLibrary
    {
        private List<Book> library = new List<Book>(); // private attribute that we will use to hold and interact with the loaded library

        /// <summary>
        /// Gets or sets the owner of the Library.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        public Person Owner { get; set; }

        /// <summary>
        /// Provides access to interact with our private Library list.
        /// </summary>
        /// <value>
        /// The book count.
        /// </value>
        public int BookCount 
        {
            get
            {
                return library.Count;
            } 
        }

        /// <summary>
        /// Gets the path of the file loaded for the Library.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path { get;  }

        /// <summary>
        /// Gets or sets a value indicating whether a save is needed for the Library.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [save needed]; otherwise, <c>false</c>.
        /// </value>
        public Boolean SaveNeeded { get; set; }

        /// <summary>
        /// Sorts the Library by title.
        /// </summary>
        public void SortByTitle()
        {
            for (int i = 0; i < library.Count; i++)
            {
                Book temp = library[i];

                for (int k = i + 1; k < library.Count; k++)
                {
                    Book pivot = library[k];

                    if (temp.CompareTo(pivot) > 0)
                    {
                        library[i] = pivot; // the books switch places, sending the book with larger (later in the alphabet/higher UNICODE value) down the line where the
                                            // smaller value was found
                        library[k] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the books written by the specified author/Coauthor
        /// </summary>
        /// <param name="author">The author.</param>
        /// <param name="coauthor">The coauthor.</param>
        /// <returns></returns>
        public List<Book> RetrieveByAuthor(string author, string coauthor = null)
        {
            List<Book> listByAuthor = new List<Book>();

            foreach (Book book in library)
            {
                if (book.Author == author || book.Coauthor == coauthor)
                    listByAuthor.Add(book);
            }

            return listByAuthor;
        }

        /// <summary>
        /// Indexer to allow us to access a Book in the library by its title or position in the library.
        /// </summary>
        /// <value>
        /// The <see cref="Book"/>.
        /// </value>
        /// <param name="i">The i.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// </exception>
        public Book this[int i]
        {
            get
            {
                if (i < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (i >= this.BookCount)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return library[i];
            }

            set
            {
                if (i < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (i >= this.BookCount)
                {
                    throw new ArgumentOutOfRangeException();
                }

                library[i] = value;
                SaveNeeded = true;
            }
        }

        /// <summary>
        /// Gets the <see cref="Book"/> with the specified title.
        /// </summary>
        /// <value>
        /// The <see cref="Book"/>.
        /// </value>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public Book this[string title]
        {
            get
            {
                foreach (Book book in library)
                {
                    if (book.Title == title)
                        return book;
                }
                
                return null;
                
            }
        }

        /// <summary>
        /// Implements the operator + so that we can easily add Books to the library.
        /// </summary>
        /// <param name="temp">The temporary.</param>
        /// <param name="book">The book.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static PersonalLibrary operator + (PersonalLibrary temp, Book book)
        {
            if (!temp.library.Contains(book)) // if the Book is not already in the library, it will be added.
                temp.library.Add(book);
            temp.SaveNeeded = true;
            return temp;
        }

        /// <summary>
        /// Implements the operator - so we can easily drop Books from the library.
        /// </summary>
        /// <param name="temp">The temporary.</param>
        /// <param name="book">The book.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static PersonalLibrary operator - (PersonalLibrary temp, Book book)
        {
            if (temp.library.Remove(book)) // if the book is in the library and dropped, SaveNeeded is updated.
                temp.SaveNeeded = true;
            return temp;
        }
    }
}
