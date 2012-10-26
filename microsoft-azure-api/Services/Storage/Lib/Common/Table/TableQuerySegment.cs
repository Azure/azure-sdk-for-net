// -----------------------------------------------------------------------------------------
// <copyright file="TableQuerySegment.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a segment of results and contains continuation token information.
    /// </summary>
    /// <typeparam name="TElement">The type of the result that the segment contains.</typeparam>
    public class TableQuerySegment<TElement> : IEnumerable<TElement>
    {
        /// <summary>
        /// Stores the continuation token used to retrieve the next segment of results.
        /// </summary>
        private TableContinuationToken continuationToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableQuerySegment{TElement}"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        internal TableQuerySegment(List<TElement> result)
        {
            this.Results = result;
        }

        internal TableQuerySegment(ResultSegment<TElement> resSeg)
            : this(resSeg.Results)
        {
            this.continuationToken = (TableContinuationToken)resSeg.ContinuationToken;
        }

        /// <summary>
        /// Gets an enumerable collection of results.
        /// </summary>
        /// <value>An enumerable collection of results.</value>
        public List<TElement> Results { get; internal set; }

        /// <summary>
        /// Gets a continuation token to use to retrieve the next set of results with a subsequent call to the operation.
        /// </summary>
        /// <value>The continuation token.</value>
        public TableContinuationToken ContinuationToken
        {
            get
            {
                if (this.continuationToken != null)
                {
                    return this.continuationToken;
                }

                return null;
            }

            internal set
            {
                this.continuationToken = value;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="TableQuerySegment{TElement}"/>.
        /// </summary>
        /// <returns>An enumerator that iterates through the <see cref="TableQuerySegment{TElement}"/>.</returns>
        public IEnumerator<TElement> GetEnumerator()
        {
            return this.Results.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Results.GetEnumerator();
        }
    }
}