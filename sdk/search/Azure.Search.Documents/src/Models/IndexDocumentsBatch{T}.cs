// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using Azure.Core;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Models
{
    // Hide the untyped IndexBatch
    [CodeGenSchema("IndexBatch")]
    internal partial class IndexBatch { }

    /// <summary>
    /// Contains a batch of document write actions to send to a search index
    /// via <see cref="SearchIndexClient.IndexDocuments"/>.
    /// </summary>
    public partial class IndexDocumentsBatch<T> : IUtf8JsonSerializable
    {
        /// <summary>
        /// The actions in the batch.
        /// </summary>
        public IList<IndexDocumentsAction<T>> Actions { get; } = new List<IndexDocumentsAction<T>>();

        /// <summary>
        /// Initializes a new instance of the IndexDocumentsBatch class.
        /// </summary>
        public IndexDocumentsBatch() { }

        /// <summary>
        /// Initializes a new instance of the IndexDocumentsBatch class.
        /// </summary>
        /// <param name="type">
        /// The operation to perform on a document in an indexing batch.
        /// </param>
        /// <param name="documents">
        /// The collection of documents to index.
        /// </param>
        internal IndexDocumentsBatch(IndexActionType type, IEnumerable<T> documents)
        {
            Debug.Assert(Enum.IsDefined(typeof(IndexActionType), type));
            Debug.Assert(documents != null);

            if (documents != null)
            {
                foreach (T doc in documents)
                {
                    Actions.Add(new IndexDocumentsAction<T>(type, doc));
                }
            }
        }

        /// <summary>
        /// Serialize the document batch.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            Debug.Assert(writer != null);
            writer.WriteStartObject();
            writer.WritePropertyName("value");
            writer.WriteStartArray();
            foreach (IndexDocumentsAction<T> action in Actions)
            {
                writer.WriteObjectValue(action);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }

    /// <summary>
    /// Creates <see cref="IndexDocumentsBatch{T}"/> instances to update
    /// search indexes via <see cref="SearchIndexClient.IndexDocuments"/>.
    /// </summary>
    public static partial class IndexDocumentsBatch
    {
        /// <summary>
        /// Create an <see cref="IndexDocumentsBatch{T}"/> to upload.
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="documents">The documents to upload.</param>
        /// <returns>
        /// An <see cref="IndexDocumentsBatch{T}"/> to upload.
        /// </returns>
        public static IndexDocumentsBatch<T> Upload<T>(IEnumerable<T> documents) =>
            new IndexDocumentsBatch<T>(IndexActionType.Upload, documents);

        /// <summary>
        /// Create an <see cref="IndexDocumentsBatch{SearchDocument}"/> to
        /// upload.
        /// </summary>
        /// <param name="documents">The documents to upload.</param>
        /// <returns>
        /// An <see cref="IndexDocumentsBatch{SearchDocument}"/> to upload.
        /// </returns>
        public static IndexDocumentsBatch<SearchDocument> Upload(IEnumerable<SearchDocument> documents) =>
            new IndexDocumentsBatch<SearchDocument>(IndexActionType.Upload, documents);

        /// <summary>
        /// Create an <see cref="IndexDocumentsBatch{T}"/> to merge.
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="documents">The documents to merge.</param>
        /// <returns>
        /// An <see cref="IndexDocumentsBatch{T}"/> to merge.
        /// </returns>
        public static IndexDocumentsBatch<T> Merge<T>(IEnumerable<T> documents) =>
            new IndexDocumentsBatch<T>(IndexActionType.Merge, documents);

        /// <summary>
        /// Create an <see cref="IndexDocumentsBatch{SearchDocument}"/> to
        /// merge.
        /// </summary>
        /// <param name="documents">The documents to merge.</param>
        /// <returns>
        /// An <see cref="IndexDocumentsBatch{SearchDocument}"/> to merge.
        /// </returns>
        public static IndexDocumentsBatch<SearchDocument> Merge(IEnumerable<SearchDocument> documents) =>
            new IndexDocumentsBatch<SearchDocument>(IndexActionType.Merge, documents);

        /// <summary>
        /// Create an <see cref="IndexDocumentsBatch{T}"/> to merge or upload.
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="documents">The documents to merge or upload.</param>
        /// <returns>
        /// An <see cref="IndexDocumentsBatch{T}"/> to merge or upload.
        /// </returns>
        public static IndexDocumentsBatch<T> MergeOrUpload<T>(IEnumerable<T> documents) =>
            new IndexDocumentsBatch<T>(IndexActionType.MergeOrUpload, documents);

        /// <summary>
        /// Create an <see cref="IndexDocumentsBatch{SearchDocument}"/> to
        /// merge or upload.
        /// </summary>
        /// <param name="documents">The documents to merge or upload.</param>
        /// <returns>
        /// An <see cref="IndexDocumentsBatch{SearchDocument}"/> to merge or
        /// upload.
        /// </returns>
        public static IndexDocumentsBatch<SearchDocument> MergeOrUpload(IEnumerable<SearchDocument> documents) =>
            new IndexDocumentsBatch<SearchDocument>(IndexActionType.MergeOrUpload, documents);

        /// <summary>
        /// Create an <see cref="IndexDocumentsBatch{T}"/> to delete.
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="documents">The documents to delete.</param>
        /// <returns>
        /// An <see cref="IndexDocumentsBatch{T}"/> to delete.
        /// </returns>
        public static IndexDocumentsBatch<T> Delete<T>(IEnumerable<T> documents) =>
            new IndexDocumentsBatch<T>(IndexActionType.Delete, documents);

        /// <summary>
        /// Create an <see cref="IndexDocumentsBatch{SearchDocument}"/> to
        /// delete.
        /// </summary>
        /// <param name="documents">The documents to delete.</param>
        /// <returns>
        /// An <see cref="IndexDocumentsBatch{SearchDocument}"/> to delete.
        /// </returns>
        public static IndexDocumentsBatch<SearchDocument> Delete(IEnumerable<SearchDocument> documents) =>
            new IndexDocumentsBatch<SearchDocument>(IndexActionType.Delete, documents);

        /// <summary>
        ///Create an <see cref="IndexDocumentsBatch{SearchDocument}"/> to
        /// delete.
        /// </summary>
        /// <param name="keyName">
        /// The name of the key field that uniquely identifies documents in
        /// the index.
        /// </param>
        /// <param name="keyValues">
        /// The keys of the documents to delete.
        /// </param>
        /// <returns>
        /// An <see cref="IndexDocumentsBatch{SearchDocument}"/> to delete.
        /// </returns>
        public static IndexDocumentsBatch<SearchDocument> Delete(string keyName, IEnumerable<string> keyValues)
        {
            IndexDocumentsBatch<SearchDocument> batch = new IndexDocumentsBatch<SearchDocument>();
            if (keyValues != null)
            {
                foreach (string value in keyValues)
                {
                    batch.Actions.Add(IndexDocumentsAction.Delete(keyName, value));
                }
            }
            return batch;
        }

        /// <summary>
        /// Creates a new <see cref="IndexDocumentsBatch{T}"/> for uploading
        /// documents to the index.
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="actions">The document write actions.</param>
        /// <returns>
        /// An <see cref="IndexDocumentsBatch{T}"/> to update.
        /// </returns>
        public static IndexDocumentsBatch<T> Create<T>(params IndexDocumentsAction<T>[] actions)
        {
            IndexDocumentsBatch<T> batch = new IndexDocumentsBatch<T>();
            if (actions != null)
            {
                foreach (IndexDocumentsAction<T> action in actions)
                {
                    batch.Actions.Add(action);
                }
            }
            return batch;
        }
    }
}
