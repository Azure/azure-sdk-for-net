// -----------------------------------------------------------------------------------------
// <copyright file="ResultSegment.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents a result segment that was retrieved from the total set of possible results.
    /// </summary>
    /// <typeparam name="TElement">The type of the element.</typeparam>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Other class is a non-generic static helper with the same name.")]
#if WINDOWS_RT
    internal
#else
    public
#endif
 class ResultSegment<TElement>
    {
        /// <summary>
        /// Stores the continuation token used to retrieve the next segment of results.
        /// </summary>
        private IContinuationToken continuationToken;

        /// <summary>
        /// Initializes a new instance of the ResultSegment class.
        /// </summary>
        /// <param name="result">The result.</param>
        internal ResultSegment(List<TElement> result)
        {
            this.Results = result;
        }

        /// <summary>
        /// Gets an enumerable collection of results.
        /// </summary>
        /// <value>An enumerable collection of results.</value>
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Reviewed.")]
        public List<TElement> Results { get; internal set; }

        /// <summary>
        /// Gets a continuation token to use to retrieve the next set of results with a subsequent call to the operation.
        /// </summary>
        /// <value>The continuation token.</value>
        public IContinuationToken ContinuationToken
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
    }
}
