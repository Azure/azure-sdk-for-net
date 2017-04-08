// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;

    /// <summary>
    /// Represents an index action that operates on a document.
    /// </summary>
    public class IndexAction : IndexActionBase<Document>
    {
        private IndexAction(IndexActionType actionType, Document document)
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
        public static IndexAction Delete(Document document)
        {
            return new IndexAction(IndexActionType.Delete, document);
        }

        /// <summary>
        /// Creates a new IndexAction for deleting a document.
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name="document">The document to delete; Fields other than the key are ignored.</param>
        /// <returns>A new IndexAction.</returns>
        public static IndexAction<T> Delete<T>(T document) where T : class
        {
            return new IndexAction<T>(IndexActionType.Delete, document);
        }

        /// <summary>
        /// Creates a new IndexAction for merging a document into an existing document in the index.
        /// </summary>
        /// <param name="document">The document to merge; Set only the fields that you want to change.</param>
        /// <returns>A new IndexAction.</returns>
        public static IndexAction Merge(Document document)
        {
            return new IndexAction(IndexActionType.Merge, document);
        }

        /// <summary>
        /// Creates a new IndexAction for merging a document into an existing document in the index.
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name="document">The document to merge; Set only the properties that you want to change.</param>
        /// <returns>A new IndexAction.</returns>
        /// <remarks>
        /// If type T contains non-nullable value-typed properties, these properties may not merge correctly. If you
        /// do not set such a property, it will automatically take its default value (for example, 0 for int or false
        /// for bool), which will override the value of the property currently stored in the index, even if this was
        /// not your intent. For this reason, it is strongly recommended that you always declare value-typed
        /// properties to be nullable in type T.
        /// </remarks>
        public static IndexAction<T> Merge<T>(T document) where T : class
        {
            return new IndexAction<T>(IndexActionType.Merge, document);
        }

        /// <summary>
        /// Creates a new IndexAction for uploading a document to the index, or merging it into an existing document
        /// if it already exists in the index.
        /// </summary>
        /// <param name="document">The document to merge or upload.</param>
        /// <returns>A new IndexAction.</returns>
        public static IndexAction MergeOrUpload(Document document)
        {
            return new IndexAction(IndexActionType.MergeOrUpload, document);
        }

        /// <summary>
        /// Creates a new IndexAction for uploading a document to the index, or merging it into an existing document
        /// if it already exists in the index.
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name="document">The document to merge or upload.</param>
        /// <returns>A new IndexAction.</returns>
        /// <remarks>
        /// If type T contains non-nullable value-typed properties, these properties may not merge correctly. If you
        /// do not set such a property, it will automatically take its default value (for example, 0 for int or false
        /// for bool), which will override the value of the property currently stored in the index, even if this was
        /// not your intent. For this reason, it is strongly recommended that you always declare value-typed
        /// properties to be nullable in type T.
        /// </remarks>
        public static IndexAction<T> MergeOrUpload<T>(T document) where T : class
        {
            return new IndexAction<T>(IndexActionType.MergeOrUpload, document);
        }

        /// <summary>
        /// Creates a new IndexAction for uploading a document to the index.
        /// </summary>
        /// <param name="document">The document to upload.</param>
        /// <returns>A new IndexAction.</returns>
        public static IndexAction Upload(Document document)
        {
            return new IndexAction(IndexActionType.Upload, document);
        }

        /// <summary>
        /// Creates a new IndexAction for uploading a document to the index.
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name="document">The document to upload.</param>
        /// <returns>A new IndexAction.</returns>
        public static IndexAction<T> Upload<T>(T document) where T : class
        {
            return new IndexAction<T>(IndexActionType.Upload, document);
        }
    }
}
