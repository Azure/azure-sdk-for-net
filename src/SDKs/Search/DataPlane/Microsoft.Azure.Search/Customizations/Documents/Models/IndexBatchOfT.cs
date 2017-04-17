// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains a batch of upload, merge, and/or delete actions to send to the Azure Search index.
    /// </summary>
    /// <typeparam name="T">
    /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
    /// </typeparam>
    public class IndexBatch<T> : IndexBatchBase<IndexAction<T>, T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the IndexBatch class.
        /// </summary>
        /// <param name="actions">The index actions to include in the batch.</param>
        public IndexBatch(IEnumerable<IndexAction<T>> actions) : base(actions)
        {
            // Do nothing.
        }
    }
}
