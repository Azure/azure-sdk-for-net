// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains a batch of document upload, merge, and/or delete operations to send to the Azure Search index.
    /// </summary>
    public class IndexBatch : IndexBatchBase<IndexAction, Document>
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
