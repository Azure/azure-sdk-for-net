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
    /// A single bucket of a range facet query result that reports the number of documents with a field value falling
    /// within a particular range.
    /// </summary>
    /// <typeparam name="T">
    /// A type that matches the type of the field to which the facet was applied. Valid types include
    /// <c cref="System.DateTimeOffset">DateTimeOffset</c>, <c cref="System.Double">Double</c>, and
    /// <c cref="System.Int64">Int64</c> (long in C#).
    /// </typeparam>
    public class RangeFacetResult<T> where T : struct
    {
        internal RangeFacetResult(long count, T? from, T? to)
        {
            From = from;
            To = to;
            Count = count;
        }

        /// <summary>
        /// Gets the approximate count of documents falling within the bucket described by this facet.
        /// </summary>
        public long Count { get; private set; }

        /// <summary>
        /// Gets a value indicating the inclusive lower bound of the facet's range, or null to indicate that there is
        /// no lower bound (i.e. -- for the first bucket).
        /// </summary>
        public T? From { get; private set; }

        /// <summary>
        /// Gets a value indicating the exclusive upper bound of the facet's range, or null to indicate that there is
        /// no upper bound (i.e. -- for the last bucket).
        /// </summary>
        public T? To { get; private set; }
    }
}
