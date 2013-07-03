// -----------------------------------------------------------------------------------------
// <copyright file="TableResultSegment.cs" company="Microsoft">
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
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents a segment of <see cref="CloudTable"/> results and contains continuation token information.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Back compatibility.")]
    public sealed class TableResultSegment : IEnumerable<CloudTable>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableResultSegment"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        internal TableResultSegment(List<CloudTable> result)
        {
            this.Results = result;
        }

        /// <summary>
        /// Stores the continuation token used to retrieve the next segment of <see cref="CloudTable"/> results or null if there are no more results.
        /// </summary>
        private TableContinuationToken continuationToken;

        /// <summary>
        /// Gets an enumerable collection of <see cref="CloudTable"/> results.
        /// </summary>
        /// <value>An enumerable collection of results.</value>
        public IList<CloudTable> Results { get; internal set; }

        /// <summary>
        /// Gets the continuation token used to retrieve the next segment of <see cref="CloudTable"/> results. Returns null if there are no more results.
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
        /// Returns an enumerator that iterates through the segment of <see cref="CloudTable"/> results. 
        /// </summary>
        /// <returns>An enumerator that iterates through the segment of <see cref="CloudTable"/> results.</returns>
        public IEnumerator<CloudTable> GetEnumerator()
        {
            return this.Results.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Results.GetEnumerator();
        }
    }
}