// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Abstract base class for a result containing a document found by a search query, plus associated metadata.
    /// </summary>
    /// <typeparam name="T">
    /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
    /// </typeparam>
    public abstract class SearchResultBase<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the SearchResultBase class.
        /// </summary>
        protected SearchResultBase()
        {
            // Do nothing.
        }

        /// <summary>
        /// Gets the relevance score of the document compared to other documents returned by the query.
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// Gets text snippets from the document that indicate the matching search terms; null if hit highlighting
        /// was not enabled for the query.
        /// </summary>
        public HitHighlights Highlights { get; set; }

        /// <summary>
        /// Gets the document found by the search query.
        /// </summary>
        public T Document { get; set; }
    }
}
