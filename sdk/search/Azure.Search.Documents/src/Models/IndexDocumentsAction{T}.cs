// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Text.Json;
using Azure.Core;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Models
{
    // Hide the untyped IndexAction
    [CodeGenSchema("IndexAction")]
    internal partial class IndexAction { }

    /// <summary>
    /// Represents an index action that operates on a document.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema. Instances of this type can
    /// be retrieved as documents from the index.
    /// </typeparam>
    public class IndexDocumentsAction<T> : IUtf8JsonSerializable
    {
        /// <summary>
        /// The operation to perform on a document in an indexing batch.
        /// </summary>
        public IndexActionType ActionType { get; private set; }

        /// <summary>
        /// The document to index.
        /// </summary>
        public T Document { get; private set; }

        /// <summary>
        /// Private constructor to prevent direct instantiation.
        /// </summary>
        private IndexDocumentsAction() { }

        /// <summary>
        /// Initializes a new instance of the IndexDocumentsAction class.
        /// </summary>
        /// <param name="type">
        /// The operation to perform on the document.
        /// </param>
        /// <param name="doc">The document to index.</param>
        public IndexDocumentsAction(IndexActionType type, T doc)
        {
            Debug.Assert(Enum.IsDefined(typeof(IndexActionType), type));

            ActionType = type;
            Document = doc;
        }

        /// <summary>
        /// Serialize the document write action.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            Debug.Assert(writer != null);

            writer.WriteStartObject();
            writer.WriteString(Constants.SearchActionKey, ActionType.ToSerialString());

            // TODO: #10589 - Investigate a more efficient way of injecting properties into user models with System.Text.Json

            // HACK: Serialize the user's model, parse it, and then write each
            // of its properties as if they were our own.
            byte[] json = JsonSerializer.SerializeToUtf8Bytes<T>(Document, JsonExtensions.SerializerOptions);
            using JsonDocument nested = JsonDocument.Parse(json);
            foreach (JsonProperty property in nested.RootElement.EnumerateObject())
            {
                property.WriteTo(writer);
            }

            writer.WriteEndObject();
        }
    }

    /// <summary>
    /// Creates <see cref="IndexDocumentsAction{T}"/> instances to add to an
    /// <see cref="IndexDocumentsBatch{T}"/> and submit via
    /// <see cref="SearchIndexClient.IndexDocuments"/>.
    /// </summary>
    public static class IndexDocumentsAction
    {
        /// <summary>
        /// Create an <see cref="IndexDocumentsAction{T}"/> to upload.
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="document">The document to upload.</param>
        /// <returns>
        /// An <see cref="IndexDocumentsAction{T}"/> to upload.
        /// </returns>
        public static IndexDocumentsAction<T> Upload<T>(T document) =>
            new IndexDocumentsAction<T>(IndexActionType.Upload, document);

        /// <summary>
        /// Create an <see cref="IndexDocumentsAction{SearchDocument}"/> to
        /// upload.
        /// </summary>
        /// <param name="document">The document to upload.</param>
        /// <returns>
        /// An <see cref="IndexDocumentsAction{SearchDocument}"/> to upload.
        /// </returns>
        public static IndexDocumentsAction<SearchDocument> Upload(SearchDocument document) =>
            new IndexDocumentsAction<SearchDocument>(IndexActionType.Upload, document);

        /// <summary>
        /// Create an <see cref="IndexDocumentsAction{T}"/> to merge.
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="document">The document to merge.</param>
        /// <returns>
        /// An <see cref="IndexDocumentsAction{T}"/> to merge.
        /// </returns>
        public static IndexDocumentsAction<T> Merge<T>(T document) =>
            new IndexDocumentsAction<T>(IndexActionType.Merge, document);

        /// <summary>
        /// Create an <see cref="IndexDocumentsAction{SearchDocument}"/> to
        /// merge.
        /// </summary>
        /// <param name="document">The document to merge.</param>
        /// <returns>
        /// An <see cref="IndexDocumentsAction{SearchDocument}"/> to merge.
        /// </returns>
        public static IndexDocumentsAction<SearchDocument> Merge(SearchDocument document) =>
            new IndexDocumentsAction<SearchDocument>(IndexActionType.Merge, document);

        /// <summary>
        /// Create an <see cref="IndexDocumentsAction{T}"/> to merge or upload.
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="document">The document to merge or upload.</param>
        /// <returns>
        /// An <see cref="IndexDocumentsAction{T}"/> to merge or upload.
        /// </returns>
        public static IndexDocumentsAction<T> MergeOrUpload<T>(T document) =>
            new IndexDocumentsAction<T>(IndexActionType.MergeOrUpload, document);

        /// <summary>
        /// Create an <see cref="IndexDocumentsAction{SearchDocument}"/> to
        /// merge or upload.
        /// </summary>
        /// <param name="document">The document to merge or upload.</param>
        /// <returns>
        /// An <see cref="IndexDocumentsAction{SearchDocument}"/> to merge or
        /// upload.
        /// </returns>
        public static IndexDocumentsAction<SearchDocument> MergeOrUpload(SearchDocument document) =>
            new IndexDocumentsAction<SearchDocument>(IndexActionType.MergeOrUpload, document);

        /// <summary>
        /// Create an <see cref="IndexDocumentsAction{T}"/> to delete.
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="document">The document to delete.</param>
        /// <returns>
        /// An <see cref="IndexDocumentsAction{T}"/> to delete.
        /// </returns>
        public static IndexDocumentsAction<T> Delete<T>(T document) =>
            new IndexDocumentsAction<T>(IndexActionType.Delete, document);

        /// <summary>
        /// Create an <see cref="IndexDocumentsAction{SearchDocument}"/> to
        /// delete.
        /// </summary>
        /// <param name="document">The document to delete.</param>
        /// <returns>
        /// An <see cref="IndexDocumentsAction{SearchDocument}"/> to delete.
        /// </returns>
        public static IndexDocumentsAction<SearchDocument> Delete(SearchDocument document) =>
            new IndexDocumentsAction<SearchDocument>(IndexActionType.Delete, document);

        /// <summary>
        /// Create an <see cref="IndexDocumentsAction{SearchDocument}"/> to
        /// delete.
        /// </summary>
        /// <param name="keyName">
        /// The name of the key field of the index.
        /// </param>
        /// <param name="keyValue">The key of the document to delete.</param>
        /// <returns>
        /// An <see cref="IndexDocumentsAction{SearchDocument}"/> to delete.
        /// </returns>
        public static IndexDocumentsAction<SearchDocument> Delete(string keyName, string keyValue)
        {
            Argument.AssertNotNullOrEmpty(keyName, nameof(keyName));
            Argument.AssertNotNull(keyValue, nameof(keyValue));

            return new IndexDocumentsAction<SearchDocument>(
                IndexActionType.Delete,
                new SearchDocument { [keyName] = keyValue });
        }
    }
}
