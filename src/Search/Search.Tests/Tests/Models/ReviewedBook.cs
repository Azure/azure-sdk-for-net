// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Newtonsoft.Json;

namespace Microsoft.Azure.Search.Tests
{
    internal class ReviewedBook : Book
    {
        [CustomField(shouldIgnore: true)]
        public int Rating { get; set; }

        public override bool Equals(object obj)
        {
            ReviewedBook other = obj as ReviewedBook;

            if (other == null)
            {
                return false;
            }

            return base.Equals(other) && this.Rating == other.Rating;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("; Rating: {0}", this.Rating);
        }
    }
}
