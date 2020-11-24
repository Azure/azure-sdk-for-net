// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// Provides factory methods for creating a batch of document write operations to send to the search index.
    /// </summary>
    public static class IndexBatch
    {
        /// <summary>
        /// Creates a new IndexBatch for deleting a batch of documents.
        /// </summary>
        /// <param name="keyName">The name of the key field that uniquely identifies documents in the index.</param>
        /// <param name="keyValues">The keys of the documents to delete.</param>
        /// <returns>A new IndexBatch.</returns>
        public static IndexBatch<Document> Delete(string keyName, IEnumerable<string> keyValues)
        {
            Throw.IfArgumentNull(keyName, "keyName");
            Throw.IfArgumentNull(keyValues, "keyValues");

            return New(keyValues.Select(v => IndexAction.Delete(keyName, v)));
        }

        /// <summary>
        /// Creates a new IndexBatch for deleting a batch of documents.
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name="documents">The documents to delete; Fields other than the key are ignored.</param>
        /// <returns>A new IndexBatch.</returns>
        public static IndexBatch<T> Delete<T>(IEnumerable<T> documents)
        {
            Throw.IfArgumentNull(documents, "documents");

            return New(documents.Select(d => IndexAction.Delete(d)));
        }

        /// <summary>
        /// Creates a new IndexBatch for merging documents into existing documents in the index.
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name="documents">The documents to merge; Set only the properties that you want to change.</param>
        /// <returns>A new IndexBatch.</returns>
        /// <remarks>
        /// <para>If type T contains non-nullable value-typed properties, these properties may not merge correctly. If you
        /// do not set such a property, it will automatically take its default value (for example, 0 for int or false
        /// for bool), which will override the value of the property currently stored in the index, even if this was
        /// not your intent. For this reason, it is strongly recommended that you always declare value-typed
        /// properties to be nullable in type T.</para>
        /// <para>The above does not apply if you are using <see cref="Document" /> as type T.</para>
        /// </remarks>
        public static IndexBatch<T> Merge<T>(IEnumerable<T> documents)
        {
            Throw.IfArgumentNull(documents, "documents");

            return New(documents.Select(d => IndexAction.Merge(d)));
        }

        /// <summary>
        /// Creates a new IndexBatch for uploading documents to the index, or merging them into existing documents
        /// for those that already exist in the index.
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name="documents">The documents to merge or upload.</param>
        /// <returns>A new IndexBatch.</returns>
        /// <remarks>
        /// <para>If type T contains non-nullable value-typed properties, these properties may not merge correctly. If you
        /// do not set such a property, it will automatically take its default value (for example, 0 for int or false
        /// for bool), which will override the value of the property currently stored in the index, even if this was
        /// not your intent. For this reason, it is strongly recommended that you always declare value-typed
        /// properties to be nullable in type T.</para>
        /// <para>The above does not apply if you are using <see cref="Document" /> as type T.</para>
        /// </remarks>
        public static IndexBatch<T> MergeOrUpload<T>(IEnumerable<T> documents)
        {
            Throw.IfArgumentNull(documents, "documents");

            return New(documents.Select(d => IndexAction.MergeOrUpload(d)));
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
        public static IndexBatch<T> New<T>(IEnumerable<IndexAction<T>> actions)
        {
            return new IndexBatch<T>(actions);
        }

        /// <summary>
        /// Creates a new IndexBatch for uploading documents to the index.
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name="documents">The documents to upload.</param>
        /// <returns>A new IndexBatch.</returns>
        public static IndexBatch<T> Upload<T>(IEnumerable<T> documents)
        {
            Throw.IfArgumentNull(documents, "documents");

            return New(documents.Select(d => IndexAction.Upload(d)));
        }
    }
}
