// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Custom JSON converter for handling serialization and deserialization of ReadOnlyMemory&lt;T&gt;.
    /// </summary>
    internal class SearchReadOnlyMemoryConverter<T> : JsonConverter<ReadOnlyMemory<T>>
    {
        public static SearchReadOnlyMemoryConverter<T> Shared { get; } =
            new SearchReadOnlyMemoryConverter<T>();

        /// <summary>
        /// Reads and deserializes a ReadOnlyMemory&lt;T&gt; from JSON.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <param name="options">The serializer options.</param>
        /// <returns>The deserialized ReadOnlyMemory&lt;T&gt;.</returns>
        public override ReadOnlyMemory<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert != null);
            Debug.Assert(options != null);

            if (reader.TokenType == JsonTokenType.Null)
            {
                // Handle null value by returning the default ReadOnlyMemory<T>;.
                return default;
            }

            // Deserialize the value to Single[] and create a ReadOnlyMemory&lt;T&gt; from it.
            var singleArray = JsonSerializer.Deserialize<T[]>(ref reader, options);
            return new ReadOnlyMemory<T>(singleArray);
        }

        /// <summary>
        /// Writes and serializes a ReadOnlyMemory&lt;T&gt; to JSON.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The ReadOnlyMemory&lt;T&gt; value to serialize.</param>
        /// <param name="options">The serializer options.</param>
        public override void Write(Utf8JsonWriter writer, ReadOnlyMemory<T> value, JsonSerializerOptions options)
        {
            Argument.AssertNotNull(writer, nameof(writer));
            Debug.Assert(options != null);

            // Serialize ReadOnlyMemory<T> as a Single[] array using .Span.
            var singleSpan = value.Span;
            var singleArray = singleSpan.ToArray();
            JsonSerializer.Serialize(writer, singleArray, options);
        }
    }
}
