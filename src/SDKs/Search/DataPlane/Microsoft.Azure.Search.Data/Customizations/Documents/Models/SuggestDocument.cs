// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    internal class SuggestDocument
    {
        public SuggestDocument() { }

        public string Text { get; set; }

        public object Document { get; set; }
    }
}
