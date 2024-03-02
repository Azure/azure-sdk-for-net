// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Convert JSON to and from a SearchDocument.
    /// </summary>
    internal class SearchDocumentConverter : JsonConverter<SearchDocument>
    {
        public static SearchDocumentConverter Shared { get; } =
            new SearchDocumentConverter();

        /// <summary>
        /// Write a SearchDocument as JSON.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The document.</param>
        /// <param name="options">Serialization options.</param>
        public override void Write(
            Utf8JsonWriter writer,
            SearchDocument value,
            JsonSerializerOptions options)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            JsonSerialization.WriteSearchDocument(
                writer,
                value,
                options);
        }

        /// <summary>
        /// Parse JSON into a SearchDocument.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="typeToConvert">The type to convert to.</param>
        /// <param name="options">Serialization options.</param>
        /// <returns>A deserialized SearchDocument.</returns>
        public override SearchDocument Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (typeToConvert == null)
            {
                throw new ArgumentNullException(nameof(typeToConvert));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            return JsonSerialization.ReadSearchDocument(
                ref reader,
                typeToConvert,
                options);
        }
    }
}
