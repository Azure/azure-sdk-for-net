// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    internal class ReviewedBook : Book
    {
        [CustomField(shouldIgnore: true)]
        public int Rating { get; set; }

        public override bool Equals(object obj) => obj is ReviewedBook other && base.Equals(other) && Rating == other.Rating;

        public override int GetHashCode() => base.GetHashCode();

        public override string ToString() => base.ToString() + $"; Rating: {Rating}";
    }
}
