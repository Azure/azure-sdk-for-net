// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Tests
{
    internal class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public DateTime? PublishDate { get; set; }

        /*
        public static SearchIndex CreateIndex(bool useCamelCase = false)
        {
            return new SearchIndex()
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
        /**/

        public override bool Equals(object obj) =>
            obj is Book other &&
            ISBN == other.ISBN &&
            Title == other.Title &&
            Author.EqualsNullSafe(other.Author) &&
            PublishDate == other.PublishDate;
        public override int GetHashCode() => ISBN?.GetHashCode() ?? 0;
        public override string ToString() => $"ISBN: {ISBN}; Title: {Title}; Author: {Author}; PublishDate: {PublishDate}";
    }

    internal class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override bool Equals(object obj) =>
            obj is Author other &&
            FirstName == other.FirstName &&
            LastName == other.LastName;
        public override int GetHashCode() => LastName?.GetHashCode() ?? 0;
        public override string ToString() => $"{FirstName} {LastName}";
    }
}
