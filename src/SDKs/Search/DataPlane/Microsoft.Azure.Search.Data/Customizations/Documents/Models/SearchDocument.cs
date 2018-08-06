// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    public class SearchDocument
    {
        public SearchDocument() { }

        public double Score;

        public HitHighlights Highlights;

        public object Document;
    }
}
