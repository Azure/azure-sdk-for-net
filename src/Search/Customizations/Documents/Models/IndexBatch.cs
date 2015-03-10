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

using System.Collections.Generic;

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Contains a batch of document upload, merge, and/or delete operations to send to the Azure Search index.
    /// </summary>
    public class IndexBatch : IndexBatch<Document>
    {
        /// <summary>
        /// Initializes a new instance of the IndexBatch class.
        /// </summary>
        /// <param name="actions">The index actions to include in the batch.</param>
        public IndexBatch(IEnumerable<IndexAction> actions) : base(actions)
        {
            // Do nothing.
        }

        /// <summary>
        /// Creates a new instance of the IndexBatch class.
        /// </summary>
        /// <param name="actions">The index actions to include in the batch.</param>
        /// <returns>A new IndexBatch.</returns>
        public static IndexBatch Create(params IndexAction[] actions)
        {
            return new IndexBatch(actions);
        }

        /// <summary>
        /// Creates a new instance of the IndexBatch class.
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name="actions">The index actions to include in the batch.</param>
        /// <returns>A new IndexBatch.</returns>
        /// <remarks>
        /// You can use this method as a convenience if you don't want to explicitly specify your model class as a
        /// type parameter.
        /// </remarks>
        public static IndexBatch<T> Create<T>(IEnumerable<IndexAction<T>> actions) where T : class
        {
            return new IndexBatch<T>(actions);
        }

        /// <summary>
        /// Creates a new instance of the IndexBatch class.
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name="actions">The index actions to include in the batch.</param>
        /// <returns>A new IndexBatch.</returns>
        /// <remarks>
        /// You can use this method as a convenience if you don't want to explicitly specify your model class as a
        /// type parameter.
        /// </remarks>
        public static IndexBatch<T> Create<T>(params IndexAction<T>[] actions) where T : class
        {
            return new IndexBatch<T>(actions);
        }
    }
}
