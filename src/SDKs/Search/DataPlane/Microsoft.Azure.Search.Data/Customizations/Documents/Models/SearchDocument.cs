// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    internal class SearchDocument
    {
        public SearchDocument() { }

        public double Score { get; set; } 

        public HitHighlights Highlights { get; set; }

        public object Document { get; set; }
    }
}
