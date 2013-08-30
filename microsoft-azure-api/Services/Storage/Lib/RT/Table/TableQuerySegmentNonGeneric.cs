// -----------------------------------------------------------------------------------------
// <copyright file="TableQuerySegmentNonGeneric.cs" company="Microsoft">
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
    /// Represents a table query segment.
    /// </summary>
    public sealed class TableQuerySegment : IEnumerable<DynamicTableEntity>
    { 
        internal TableQuerySegment()
        {
            this.Results = new List<DynamicTableEntity>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableQuerySegment"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        internal TableQuerySegment(List<DynamicTableEntity> result)
        {
            this.Results = result;
        }

        internal TableQuerySegment(ResultSegment<DynamicTableEntity> resSeg)
            : this(resSeg.Results)
        {
            this.ContinuationToken = resSeg.ContinuationToken as TableContinuationToken;
        }

        /// <summary>
        /// Gets an enumerable collection of results.
        /// </summary>
        /// <value>An enumerable collection of results.</value>
        public IList<DynamicTableEntity> Results { get; internal set; }

        /// <summary>
        /// Gets a continuation token to use to retrieve the next set of results with a subsequent call to the operation.
        /// </summary>
        /// <value>The continuation token.</value>
        public TableContinuationToken ContinuationToken { get; internal set; }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="DynamicTableEntity"/> collection.
        /// </summary>
        /// <returns>An enumerator that iterates through the <see cref="DynamicTableEntity"/> collection.</returns>
        public IEnumerator<DynamicTableEntity> GetEnumerator()
        {
            return this.Results.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An enumerator that iterates through a collection.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Results.GetEnumerator();
        }
    }
}
