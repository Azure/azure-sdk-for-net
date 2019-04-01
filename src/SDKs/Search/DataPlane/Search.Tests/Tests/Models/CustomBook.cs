// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;

    internal class CustomBook
    {
        public string InternationalStandardBookNumber { get; set; }

        public string Name { get; set; }

        public string AuthorName { get; set; }

        public DateTime? PublishDateTime { get; set; }

        public override bool Equals(object obj)
        {
            CustomBook other = obj as CustomBook;

            if (other == null)
            {
                return false;
            }

            return
                this.InternationalStandardBookNumber == other.InternationalStandardBookNumber &&
                this.Name == other.Name &&
                this.AuthorName == other.AuthorName &&
                this.PublishDateTime == other.PublishDateTime;
        }

        public override int GetHashCode()
        {
            return (this.InternationalStandardBookNumber != null) ? 
                this.InternationalStandardBookNumber.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return string.Format(
                "ISBN: {0}; Title: {1}; Author: {2}; PublishDate: {3}",
                this.InternationalStandardBookNumber,
                this.Name,
                this.AuthorName,
                this.PublishDateTime);
        }
    }
}
