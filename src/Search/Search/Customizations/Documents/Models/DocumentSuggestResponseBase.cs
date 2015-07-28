// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System.Collections.Generic;
using Hyak.Common;

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Response containing suggestion query results from an Azure Search index.
    /// </summary>
    /// <typeparam name="TDoc">
    /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
    /// from the index.
    /// </typeparam>
    /// <typeparam name="TResult">
    /// Type of the model class that encapsulates documents in a suggestion response.
    /// </typeparam>
    public class DocumentSuggestResponseBase<TResult, TDoc> : AzureOperationResponse, IEnumerable<TResult>
        where TResult : SuggestResultBase<TDoc>
        where TDoc : class
    {
        private IList<TResult> _results;

        /// <summary>
        /// Initializes a new instance of the DocumentSuggestResponseBase class.
        /// </summary>
        protected DocumentSuggestResponseBase()
        {
            _results = new LazyList<TResult>();
        }

        /// <summary>
        /// Gets a value indicating the percentage of the index that was included in the query, or null if
        /// MinimumCoverage was not set in the <c cref="SuggestParameters">SuggestParameters</c>.
        /// </summary>
        public double? Coverage { get; set; }

        /// <summary>
        /// Gets the sequence of results returned by the query.
        /// </summary>
        public IList<TResult> Results
        {
            get { return _results; }
            set { _results = value; }
        }

        /// <summary>
        /// Gets the sequence of Results.
        /// </summary>
        public IEnumerator<TResult> GetEnumerator()
        {
            return this.Results.GetEnumerator();
        }

        /// <summary>
        /// Gets the sequence of Results.
        /// </summary>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
