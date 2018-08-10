// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// Contains a batch of document upload, merge, and/or delete operations to send to the Azure Search index.
    /// </summary>
    public partial class IndexBatch 
    {
        /// <summary>
        /// Initializes a new instance of the IndexBatch class.
        /// </summary>
        /// <param name="actions">The index actions to include in the batch.</param>
        public IndexBatch(IEnumerable<IndexAction> actions) : this(actions.ToList())
        {
            // Do nothing.
        }

        /// <summary>
        /// Creates a new IndexBatch for deleting a batch of documents.
        /// </summary>
        /// <param name="keyName">The name of the key field that uniquely identifies documents in the index.</param>
        /// <param name="keyValues">The keys of the documents to delete.</param>
        /// <returns>A new IndexBatch.</returns>
        public static IndexBatch Delete(string keyName, IEnumerable<string> keyValues)
        {
            Throw.IfArgumentNull(keyName, "keyName");
            Throw.IfArgumentNull(keyValues, "keyValues");

            return IndexBatch.New(keyValues.Select(v => IndexAction.Delete(keyName, v)));
        }

        /// <summary>
        /// Creates a new IndexBatch for deleting a batch of documents.
        /// </summary>
        /// <param name="documents">The documents to delete; Fields other than the key are ignored.</param>
        /// <returns>A new IndexBatch.</returns>
        public static IndexBatch Delete(IEnumerable<object> documents)
        {
            Throw.IfArgumentNull(documents, "documents");

            return IndexBatch.New(documents.Select(d => IndexAction.Delete(d)));
        }

        /// <summary>
        /// Creates a new IndexBatch for merging documents into existing documents in the index.
        /// </summary>
        /// <param name="documents">The documents to merge; Set only the fields that you want to change.</param>
        /// <returns>A new IndexBatch.</returns>
        public static IndexBatch Merge(IEnumerable<object> documents)
        {
            Throw.IfArgumentNull(documents, "documents");

            return IndexBatch.New(documents.Select(d => IndexAction.Merge(d)));
        }

        /// <summary>
        /// Creates a new IndexBatch for uploading documents to the index, or merging them into existing documents
        /// for those that already exist in the index.
        /// </summary>
        /// <param name="documents">The documents to merge or upload.</param>
        /// <returns>A new IndexBatch.</returns>
        public static IndexBatch MergeOrUpload(IEnumerable<object> documents)
        {
            Throw.IfArgumentNull(documents, "documents");

            return IndexBatch.New(documents.Select(d => IndexAction.MergeOrUpload(d)));
        }

        /// <summary>
        /// Creates a new instance of the IndexBatch class.
        /// </summary>
        /// <param name="actions">The index actions to include in the batch.</param>
        /// <returns>A new IndexBatch.</returns>
        public static IndexBatch New(IEnumerable<IndexAction> actions)
        {
            return new IndexBatch(actions);
        }

        /// <summary>
        /// Creates a new IndexBatch for uploading documents to the index.
        /// </summary>
        /// <param name="documents">The documents to upload.</param>
        /// <returns>A new IndexBatch.</returns>
        public static IndexBatch Upload(IEnumerable<object> documents)
        {
            Throw.IfArgumentNull(documents, "documents");

            return IndexBatch.New(documents.Select(d => IndexAction.Upload(d)));
        }
    }
}
