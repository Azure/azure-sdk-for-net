// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using Models;
    using Utilities;

    internal class Book
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime? PublishDate { get; set; }

        public static Index DefineIndex(bool useCamelCase = false)
        {
            return new Index()
            {
                Name = SearchTestUtilities.GenerateName(),
                Fields = new[]
                {
                    new Field(useCamelCase ? "isbn" : "ISBN", DataType.String) { IsKey = true },
                    new Field(useCamelCase ? "title" : "Title", DataType.String) { IsSearchable = true },
                    new Field(useCamelCase ? "author" : "Author", DataType.String),
                    new Field(useCamelCase ? "publishDate" : "PublishDate", DataType.DateTimeOffset)
                },
                Suggesters = new[] 
                {
                    new Suggester("sg", SuggesterSearchMode.AnalyzingInfixMatching, useCamelCase ? "title" : "Title")
                }
            };
        }

        public override bool Equals(object obj)
        {
            Book other = obj as Book;

            if (other == null)
            {
                return false;
            }

            return 
                this.ISBN == other.ISBN &&
                this.Title == other.Title &&
                this.Author == other.Author &&
                this.PublishDate == other.PublishDate;
        }

        public override int GetHashCode()
        {
            return (this.ISBN != null) ? this.ISBN.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return string.Format(
                "ISBN: {0}; Title: {1}; Author: {2}; PublishDate: {3}",
                this.ISBN,
                this.Title,
                this.Author,
                this.PublishDate);
        }
    }
}
