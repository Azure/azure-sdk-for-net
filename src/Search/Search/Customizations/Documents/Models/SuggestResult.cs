// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Contains a document found by a suggestion query, plus associated metadata.
    /// </summary>
    public class SuggestResult : SuggestResultBase<Document>
    {
        /// <summary>
        /// Initializes a new instance of the SuggestResult class.
        /// </summary>
        public SuggestResult()
        {
            // Do nothing.
        }
    }
}
