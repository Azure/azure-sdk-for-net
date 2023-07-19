// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Common;

    /// <summary>
    /// Provides factory methods for creating an index action that operates on a document.
    /// </summary>
    public static class IndexAction
    {
        /// <summary>
        /// Creates a new IndexAction for deleting a document.
        /// </summary>
        /// <param name="keyName">The name of the key field of the index.</param>
        /// <param name="keyValue">The key of the document to delete.</param>
        /// <returns>A new IndexAction.</returns>
        public static IndexAction<Document> Delete(string keyName, string keyValue)
        {
            Throw.IfArgumentNull(keyName, "keyName");
            Throw.IfArgumentNull(keyValue, "keyValue");

            return new IndexAction<Document>(new Document() { [keyName] = keyValue }, IndexActionType.Delete);
        }

        /// <summary>
        /// Creates a new IndexAction for deleting a document.
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name="document">The document to delete; Fields other than the key are ignored.</param>
        /// <returns>A new IndexAction.</returns>
        public static IndexAction<T> Delete<T>(T document)
        {
            return new IndexAction<T>(document, IndexActionType.Delete);
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
        /// <para>If type T contains non-nullable value-typed properties, these properties may not merge correctly. If you
        /// do not set such a property, it will automatically take its default value (for example, 0 for int or false
        /// for bool), which will override the value of the property currently stored in the index, even if this was
        /// not your intent. For this reason, it is strongly recommended that you always declare value-typed
        /// properties to be nullable in type T.</para>
        /// <para>The above does not apply if you are using <see cref="Document" /> as type T.</para>
        /// </remarks>
        public static IndexAction<T> Merge<T>(T document)
        {
            return new IndexAction<T>(document, IndexActionType.Merge);
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
        /// <para>If type T contains non-nullable value-typed properties, these properties may not merge correctly. If you
        /// do not set such a property, it will automatically take its default value (for example, 0 for int or false
        /// for bool), which will override the value of the property currently stored in the index, even if this was
        /// not your intent. For this reason, it is strongly recommended that you always declare value-typed
        /// properties to be nullable in type T.</para>
        /// <para>The above does not apply if you are using <see cref="Document" /> as type T.</para>
        /// </remarks>
        public static IndexAction<T> MergeOrUpload<T>(T document)
        {
            return new IndexAction<T>(document, IndexActionType.MergeOrUpload);
        }

        /// <summary>
        /// Creates a new IndexAction for uploading a document to the index.
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name="document">The document to upload.</param>
        /// <returns>A new IndexAction.</returns>
        public static IndexAction<T> Upload<T>(T document)
        {
            return new IndexAction<T>(document, IndexActionType.Upload);
        }
    }
}
