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
    /// A single bucket of a simple or interval facet query result that reports the number of documents with a field
    /// falling within a particular interval or having a specific value.
    /// </summary>
    /// <typeparam name="T">
    /// A type that matches the type of the field to which the facet was applied.
    /// </typeparam>
    public class ValueFacet<T>
    {
        internal ValueFacet(long count, T value)
        {
            Value = value;
            Count = count;
        }

        /// <summary>
        /// Gets the approximate count of documents falling within the bucket described by this facet.
        /// </summary>
        public long Count { get; private set; }

        /// <summary>
        /// Gets the value of the facet, or the inclusive lower bound if it's an interval facet.
        /// </summary>
        public T Value { get; private set; }
    }
}
