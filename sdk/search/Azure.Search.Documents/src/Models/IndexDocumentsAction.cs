// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Serialization;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Models
{
    // Hide the untyped IndexAction
    [CodeGenModel("IndexAction")]
    internal partial class IndexAction { }

    /// <summary>
    /// Represents an index action that operates on a document.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema. Instances of this type can
    /// be retrieved as documents from the index.
    /// </typeparam>
    public class IndexDocumentsAction<T>
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

        #pragma warning disable CS1572 // Not all parameters will be used depending on feature flags
        #pragma warning disable CA1801 // Not all parameters are used depending on feature flags
        #pragma warning disable CS1998 // Won't await depending on feature flags
        /// <summary>
        /// Serialize the document write action.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="serializer">
        /// Optional serializer that can be used to customize the serialization
        /// of strongly typed models.
        /// </param>
        /// <param name="options">JSON serializer options.</param>
        /// <param name="async">Whether to execute sync or async.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>A task representing the serialization.</returns>
        internal async Task SerializeAsync(
            Utf8JsonWriter writer,
            ObjectSerializer serializer,
            JsonSerializerOptions options,
            bool async,
            CancellationToken cancellationToken)
        #pragma warning restore CS1998
        #pragma warning restore CA1801
        #pragma warning restore CS1572
        {
            Debug.Assert(writer != null);

            writer.WriteStartObject();
            writer.WriteString(Constants.SearchActionKeyJson, ActionType.ToSerialString());

            // HACK: Serialize the user's model, parse it, and then write each
            // of its properties as if they were our own.
            byte[] json;
            if (serializer != null)
            {
                using MemoryStream stream = new MemoryStream();
                if (async)
                {
                    await serializer.SerializeAsync(stream, Document, typeof(T), cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    serializer.Serialize(stream, Document, typeof(T), cancellationToken);
                }
                json = stream.ToArray();
            }
            else
            {
                json = JsonSerializer.SerializeToUtf8Bytes<T>(Document, options);
            }
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
    /// <see cref="SearchClient.IndexDocuments"/>.
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
