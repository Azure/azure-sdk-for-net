// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Abstract base class for a result containing a document found by a suggestion query, plus associated metadata.
    /// </summary>
    /// <typeparam name="T">
    /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
    /// </typeparam>
    public abstract class SuggestResultBase<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the SuggestResultBase class.
        /// </summary>
        protected SuggestResultBase()
        {
            // Do nothing.
        }

        /// <summary>
        /// Gets the text of the suggestion result.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets the document on which the suggested text is based.
        /// </summary>
        public T Document { get; set; }
    }
}
