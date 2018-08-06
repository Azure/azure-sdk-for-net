// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Common;

    /// <summary>
    /// Represents an index action that operates on a document.
    /// </summary>
    public class IndexAction : IndexActionBase
    {
        private IndexAction(IndexActionType actionType, object document)
            : base(actionType, document)
        {
            // Do nothing.
        }

        /// <summary>
        /// Creates a new IndexAction for deleting a document.
        /// </summary>
        /// <param name="keyName">The name of the key field of the index.</param>
        /// <param name="keyValue">The key of the document to delete.</param>
        /// <returns>A new IndexAction.</returns>
        public static IndexAction Delete(string keyName, string keyValue)
        {
            Throw.IfArgumentNull(keyName, "keyName");
            Throw.IfArgumentNull(keyValue, "keyValue");

            return new IndexAction(IndexActionType.Delete, new Document() { { keyName, keyValue } });
        }

        /// <summary>
        /// Creates a new IndexAction for deleting a document.
        /// </summary>
        /// <param name="document">The document to delete; Fields other than the key are ignored.</param>
        /// <returns>A new IndexAction.</returns>
        public static IndexAction Delete(object document)
        {
            return new IndexAction(IndexActionType.Delete, document);
        }

        /// <summary>
        /// Creates a new IndexAction for merging a document into an existing document in the index.
        /// </summary>
        /// <param name="document">The document to merge; Set only the fields that you want to change.</param>
        /// <returns>A new IndexAction.</returns>
        public static IndexAction Merge(object document)
        {
            return new IndexAction(IndexActionType.Merge, document);
        }

        /// <summary>
        /// Creates a new IndexAction for uploading a document to the index, or merging it into an existing document
        /// if it already exists in the index.
        /// </summary>
        /// <param name="document">The document to merge or upload.</param>
        /// <returns>A new IndexAction.</returns>
        public static IndexAction MergeOrUpload(object document)
        {
            return new IndexAction(IndexActionType.MergeOrUpload, document);
        }

        /// <summary>
        /// Creates a new IndexAction for uploading a document to the index.
        /// </summary>
        /// <param name="document">The document to upload.</param>
        /// <returns>A new IndexAction.</returns>
        public static IndexAction Upload(object document)
        {
            return new IndexAction(IndexActionType.Upload, document);
        }
    }
}
