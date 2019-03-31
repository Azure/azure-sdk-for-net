// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using Models;
    using Utilities;

    internal class Author
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    internal class Book
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public Author Author { get; set; }

        public DateTime? PublishDate { get; set; }

        public static Index DefineIndex(bool useCamelCase = false)
        {
            return new Index()
            {
                Name = SearchTestUtilities.GenerateName(),
                Fields = new[]
                {
                    Field.New(useCamelCase ? "isbn" : "ISBN", DataType.String, isKey: true),
                    Field.New(useCamelCase ? "title" : "Title", DataType.String, isSearchable: true),
                    Field.NewComplex(useCamelCase ? "author" : "Author", isCollection: false, fields: new[]{
                        Field.New(useCamelCase ? "firstName" : "FirstName", DataType.String),
                        Field.New(useCamelCase ? "lastName" : "LastName", DataType.String)
                    }),
                    Field.New(useCamelCase ? "publishDate" : "PublishDate", DataType.DateTimeOffset)
                },
                Suggesters = new[] 
                {
                    new Suggester("sg", useCamelCase ? "title" : "Title")
                }
            };
        }

        public override bool Equals(object obj) =>
            obj is Book other &&
            ISBN == other.ISBN &&
            Title == other.Title &&
            Author == other.Author &&
            PublishDate == other.PublishDate;

        public override int GetHashCode() => ISBN?.GetHashCode() ?? 0;

        public override string ToString() => $"ISBN: {ISBN}; Title: {Title}; Author: {Author}; PublishDate: {PublishDate}";
    }
}
