// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;
using Azure.Core.GeoJson;
using Azure.Search.Documents.Models;

namespace Azure.Search.Documents
{
    /// <summary>
    /// JSON serialization and conversion helpers.
    /// </summary>
    internal static class JsonSerialization
    {
        internal const string TrimWarning = "Uses reflection-based serialization which is not compatible with trimming.";

        /// <summary>
        /// We serialize dates with the round-trip format.
        /// </summary>
        private const string DateTimeOutputFormat = "o";

        /// <summary>
        /// Default JsonSerializerOptions to use.
        /// </summary>
        public static JsonSerializerOptions SerializerOptions { get; } =
            new JsonSerializerOptions().AddSearchConverters();

        /// <summary>
        /// Add all of the Search JsonConverters.
        /// </summary>
        /// <param name="options">Serialization options.</param>
        /// <returns>Serialization options.</returns>
        public static JsonSerializerOptions AddSearchConverters(this JsonSerializerOptions options)
        {
            options ??= new JsonSerializerOptions();
            options.Converters.Add(SearchDoubleConverter.Shared);
            options.Converters.Add(SearchDateTimeOffsetConverter.Shared);
            options.Converters.Add(SearchDateTimeConverter.Shared);
            options.Converters.Add(SearchDocumentConverter.Shared);
            options.Converters.Add(SearchReadOnlyMemoryConverter<float>.Shared);

            return options;
        }

        /// <summary>
        /// Format floating point values.
        /// </summary>
        /// <param name="value">Float.</param>
        /// <param name="formatProvider">Format Provider.</param>
        /// <returns>OData string.</returns>
        public static string Float(float value, IFormatProvider formatProvider) =>
            value switch
            {
                float.NegativeInfinity => Constants.NegativeInfValue,
                float.PositiveInfinity => Constants.InfValue,
                float x when float.IsNaN(x) => Constants.NanValue,
                float x => x.ToString(formatProvider).ToLowerInvariant()
            };

        /// <summary>
        /// Format floating point values.
        /// </summary>
        /// <param name="value">Double.</param>
        /// <param name="formatProvider">Format Provider.</param>
        /// <returns>OData string.</returns>
        public static string Double(double value, IFormatProvider formatProvider) =>
            value switch
            {
                double.NegativeInfinity => Constants.NegativeInfValue,
                double.PositiveInfinity => Constants.InfValue,
                double x when double.IsNaN(x) => Constants.NanValue,
                double x => x.ToString(formatProvider).ToLowerInvariant()
            };

        /// <summary>
        /// Format dates.
        /// </summary>
        /// <param name="value">Date</param>
        /// <param name="formatProvider">Format Provider.</param>
        /// <returns>OData string.</returns>
        public static string Date(DateTime value, IFormatProvider formatProvider) =>
            Date(
                value.Kind == DateTimeKind.Unspecified ?
                    new DateTimeOffset(value, TimeSpan.Zero) :
                    new DateTimeOffset(value),
                formatProvider);

        /// <summary>
        /// Format dates.
        /// </summary>
        /// <param name="value">Date</param>
        /// <param name="formatProvider">Format Provider.</param>
        /// <returns>OData string.</returns>
        public static string Date(DateTimeOffset value, IFormatProvider formatProvider) =>
            value.ToString(DateTimeOutputFormat, formatProvider);

        /// <summary>
        /// Parse JSON into a SearchDocument.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="typeToConvert">The type to convert to.</param>
        /// <param name="options">Serialization options.</param>
        /// <param name="recursionDepth">
        /// Depth of the current read recursion to bail out of circular
        /// references.
        /// </param>
        /// <returns>A deserialized SearchDocument.</returns>
        public static SearchDocument ReadSearchDocument(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options,
            int? recursionDepth = null)
        {
            Debug.Assert(typeToConvert != null);
            Debug.Assert(typeToConvert.IsAssignableFrom(typeof(SearchDocument)));

            recursionDepth ??= options?.MaxDepth ?? Constants.MaxJsonRecursionDepth;
            if (!recursionDepth.HasValue || recursionDepth.Value <= 0)
            {
                // JsonSerializerOptions uses 0 to mean pick their default of 64
                recursionDepth = Constants.MaxJsonRecursionDepth;
            }
            if (recursionDepth.Value < 0) { throw new JsonException("Exceeded maximum recursion depth."); }

            SearchDocument doc = new SearchDocument();
            Expects(reader, JsonTokenType.StartObject);
            while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
            {
                Expects(reader, JsonTokenType.PropertyName);
                string propertyName = reader.GetString();
                reader.Read(); // Advance the past the property name

                // Ignore OData properties - we don't expose those on custom
                // user schemas
                if (!propertyName.StartsWith(Constants.ODataKeyPrefix, StringComparison.OrdinalIgnoreCase))
                {
                    object value = ReadSearchDocObject(ref reader, recursionDepth.Value - 1);
                    doc[propertyName] = value;
                }
                else
                {
                    reader.Skip();
                }
            }
            return doc;

            object ReadSearchDocObject(ref Utf8JsonReader reader, int depth)
            {
                if (depth < 0) { throw new JsonException("Exceeded maximum recursion depth."); }
                switch (reader.TokenType)
                {
                    case JsonTokenType.String:
                        return reader.GetString();
                    case JsonTokenType.Number:
                        if (reader.TryGetInt32(out int intValue)) { return intValue; }
                        if (reader.TryGetInt64(out long longValue)) { return longValue; }
                        return reader.GetDouble();
                    case JsonTokenType.True:
                        return true;
                    case JsonTokenType.False:
                        return false;
                    case JsonTokenType.None:
                    case JsonTokenType.Null:
                        return null;
                    case JsonTokenType.StartObject:
                        // Clone the reader so we can check if the object is a
                        // GeoJsonPoint without advancing tokens if not
                        Utf8JsonReader clone = reader;
                        try
                        {
                            GeoPoint point = JsonSerializer.Deserialize<GeoPoint>(ref clone);
                            if (point != null)
                            {
                                reader = clone;
                                return point;
                            }
                        }
                        catch
                        {
                        }

                        // Return a complex object
                        return ReadSearchDocument(ref reader, typeof(SearchDocument), options, depth - 1);
                    case JsonTokenType.StartArray:
                        var list = new List<object>();
                        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                        {
                            object value = ReadSearchDocObject(ref reader, depth - 1);
                            list.Add(value);
                        }
                        return list.ToArray();
                    default:
                        throw new JsonException();
                }
            }

            static void Expects(in Utf8JsonReader reader, JsonTokenType expected)
            {
                if (reader.TokenType != expected)
                {
                    throw new JsonException(
                        $"Expected {nameof(JsonTokenType)} " +
                        expected.ToString() +
                        ", not " +
                        reader.TokenType.ToString());
                }
            }
        }

        /// <summary>
        /// Serialize a SearchDocument as JSON.
        /// </summary>
        /// <param name="writer">JSON writer.</param>
        /// <param name="document">The document.</param>
        /// <param name="options">Serialization options.</param>
        public static void WriteSearchDocument(
            Utf8JsonWriter writer,
            SearchDocument document,
            JsonSerializerOptions options)
        {
            Debug.Assert(writer != null);
            Debug.Assert(document != null);
            Debug.Assert(options != null);

            writer.WriteStartObject();
            foreach (string key in document.Keys)
            {
                writer.WritePropertyName(key);
                object value = document[key];

                // Write the value using JsonSerializer so all of our
                // converters take effect
                JsonSerializer.Serialize(
                    writer,
                    value,
                    value?.GetType() ?? typeof(object),
                    options);
            }
            writer.WriteEndObject();
        }

        #pragma warning disable CS1572 // Not all parameters will be used depending on feature flags
        /// <summary>
        /// Deserialize a JSON stream.
        /// </summary>
        /// <typeparam name="T">
        /// The target type to deserialize the JSON stream into.
        /// </typeparam>
        /// <param name="json">A JSON stream.</param>
        /// <param name="serializer">
        /// Optional serializer that can be used to customize the serialization
        /// of strongly typed models.
        /// </param>
        /// <param name="async">Whether to execute sync or async.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>A deserialized object.</returns>
        public static async Task<T> DeserializeAsync<T>(
            this Stream json,
            ObjectSerializer serializer,
            bool async,
            CancellationToken cancellationToken)
        #pragma warning restore CS1572
        {
            if (json is null)
            {
                return default;
            }
            else if (serializer != null)
            {
                return async ?
                    (T)await serializer.DeserializeAsync(json, typeof(T), cancellationToken).ConfigureAwait(false) :
                    (T)serializer.Deserialize(json, typeof(T), cancellationToken);
            }
            else if (async)
            {
                return await JsonSerializer.DeserializeAsync<T>(
                    json,
                    JsonSerialization.SerializerOptions,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                // Copy the stream into memory and then deserialize
                using MemoryStream memory = json.CopyToMemoryStreamAsync(async, cancellationToken).EnsureCompleted();
                return JsonSerializer.Deserialize<T>(
                    memory.ToArray(),
                    JsonSerialization.SerializerOptions);
            }
        }
    }
}
