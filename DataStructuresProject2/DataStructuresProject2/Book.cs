///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// 
// Project:             Project 2 - Personal Library
// File Name:           Books.cs
// Description:         Class that creates and allows the comparison and manipulation of Book objects for the Library.
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
    /// Class that allows us to create and manipulate Book objects so we can add them to our Library list
    /// </summary>
    /// <seealso cref="System.IEquatable&lt;DataStructuresProject2.Book&gt;" />
    /// <seealso cref="System.IComparable&lt;DataStructuresProject2.Book&gt;" />
    class Book : IEquatable<Book>, IComparable<Book>
    {
        /// <summary>
        /// Constructor for a book object so that a book object can easily be created from a delimited file.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="author">The author.</param>
        /// <param name="coauthor">The coauthor.</param>
        /// <param name="bookCategory">The book category.</param>
        /// <param name="bookType">Type of the book.</param>
        /// <param name="price">The price.</param>
        public Book(Type bookType, string title, string author, string coauthor, Category bookCategory, Decimal price)
        {
            this.BookType = bookType;
            this.Title = title;
            this.Author = author;
            this.Coauthor = coauthor;
            this.BookCategory = bookCategory;
            this.Price = price;
        }

        /// <summary>
        /// Gets or sets the type for a book object.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public Type BookType { get; set; }

        /// <summary>
        /// Gets or sets the title of a book.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the book author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the coauthor.
        /// </summary>
        /// <value>
        /// The coauthor.
        /// </value>
        public string Coauthor { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public Category BookCategory { get; set; }

        /// <summary>
        /// Gets or sets the book price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public Decimal Price { get; set; }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="other" /> in the sort order.  Zero This instance occurs in the same position in the sort order as <paramref name="other" />. Greater than zero This instance follows <paramref name="other" /> in the sort order.
        /// </returns>
        public int CompareTo(Book other)
        {
            return this.Title.CompareTo(other.Title);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        bool IEquatable<Book>.Equals(Book other)
        {
            return this.Title == other.Title;
        }

        /// <summary>
        /// Determines whether the specified object of any kind is equal to this instance. Included to fully implement IEquatable
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return base.Equals(obj);

            if (!(obj is Book))
                throw new ArgumentException();

            return Equals(obj as Book);
        }

        /// <summary>
        /// Returns a hash code for this instance. Included to fully implement IEquatable.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.Title.GetHashCode();
        }
    }
}
