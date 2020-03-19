// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Search.Documents.Models;

namespace Azure.Search.Documents
{
    /// <summary>
    /// JSON serialization and conversion helpers.
    /// </summary>
    internal static class JsonExtensions
    {
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
            value.ToString("o", formatProvider);

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

            recursionDepth ??= options.GetMaxRecursionDepth();
            AssertRecursionDepth(recursionDepth.Value);

            SearchDocument doc = new SearchDocument();
            reader.Expects(JsonTokenType.StartObject);
            while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
            {
                string propertyName = reader.ExpectsPropertyName();

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

            // TODO: #10596 - Investigate using JsonSerializer for reading SearchDocument properties

            // The built in converters for JsonSerializer are a little more
            // helpful than we want right now and will do things like turn "1"
            // to the integer 1 instead of a string.  The number of special
            // cases needed for converting dynamic documents is small enough
            // that we're hard coding them here for now.  We'll revisit with
            // Search experts and their customer scenarios to get this right in
            // the next preview.
            object ReadSearchDocObject(ref Utf8JsonReader reader, int depth)
            {
                AssertRecursionDepth(depth);
                switch (reader.TokenType)
                {
                    case JsonTokenType.String:
                    case JsonTokenType.Number:
                    case JsonTokenType.True:
                    case JsonTokenType.False:
                    case JsonTokenType.None:
                    case JsonTokenType.Null:
                        return ReadPrimitiveValue(ref reader);
                    case JsonTokenType.StartObject:
                        // TODO: #10592- Unify on an Azure.Core spatial type

                        // Return a complex object
                        return ReadSearchDocument(ref reader, typeof(SearchDocument), options, depth - 1);
                    case JsonTokenType.StartArray:
                        var list = new List<object>();
                        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                        {
                            recursionDepth--;
                            object value = ReadSearchDocObject(ref reader, depth - 1);
                            list.Add(value);
                        }
                        return list.ToArray();
                    default:
                        throw new JsonException();
                }
            }
        }

        /// <summary>
        /// Read a primitive value from the head of a JSON reader.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <returns>The value.</returns>
        private static object ReadPrimitiveValue(ref Utf8JsonReader reader)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    return reader.GetString() switch
                    {
                        Constants.NanValue => double.NaN,
                        Constants.InfValue => double.PositiveInfinity,
                        Constants.NegativeInfValue => double.NegativeInfinity,
                        string text =>
                            // JsonReader's TryGetDateTimeOffset doesn't play
                            // nicely with time zones so we'll do our own parse
                            DateTimeOffset.TryParse(text, out DateTimeOffset date) ?
                                (object)date :
                                (object)text
                    };
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
                default:
                    return null;
            }
        }

        /// <summary>
        /// Read a .NET object from the head of a JSON reader.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="options">JSON serializer options.</param>
        /// <param name="recursionDepth">
        /// Depth of the current read recursion to bail out of circular
        /// references.
        /// </param>
        /// <returns>The object.</returns>
        public static object ReadObject(
            this ref Utf8JsonReader reader,
            JsonSerializerOptions options,
            int? recursionDepth = null)
        {
            Debug.Assert(options != null);
            recursionDepth ??= options.GetMaxRecursionDepth();
            AssertRecursionDepth(recursionDepth.Value);

            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                case JsonTokenType.Number:
                case JsonTokenType.True:
                case JsonTokenType.False:
                case JsonTokenType.None:
                case JsonTokenType.Null:
                    return ReadPrimitiveValue(ref reader);
                case JsonTokenType.StartObject:
                    // TODO: #10592- Unify on an Azure.Core spatial type

                    // Return a complex object
                    IDictionary<string, object> obj = new Dictionary<string, object>();
                    reader.Expects(JsonTokenType.StartObject);
                    while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
                    {
                        string property = reader.ExpectsPropertyName();
                        object value = ReadObject(ref reader, options, recursionDepth - 1);
                        obj[property] = value;
                    }
                    return obj;
                case JsonTokenType.StartArray:
                    var list = new List<object>();
                    while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                    {
                        object value = ReadObject(ref reader, options, recursionDepth - 1);
                        list.Add(value);
                    }
                    return list.ToArray();
                default:
                    throw new JsonException();
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

        /// <summary>
        /// Get the default max recursion depth.
        /// </summary>
        /// <param name="options">Serialization options.</param>
        /// <returns>The default max recursion depth.</returns>
        public static int GetMaxRecursionDepth(this JsonSerializerOptions options)
        {
            int depth = options?.MaxDepth ?? Constants.MaxJsonRecursionDepth;
            if (depth <= 0)
            {
                // JsonSerializerOptions uses 0 to mean pick their default of 64
                depth = Constants.MaxJsonRecursionDepth;
            }
            return depth;
        }

        /// <summary>
        /// Throw if we've recursed beyond the maximum recursion depth.
        /// </summary>
        /// <param name="depth">Current depth.</param>
        public static void AssertRecursionDepth(int depth)
        {
            if (depth <= 0)
            {
                throw new JsonException("Exceeded maximum recursion depth.");
            }
        }

        /// <summary>
        /// Verify that the next token to be read matches our expectation or
        /// throw an exception otherwise.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="expected">The expected token type.</param>
        public static void Expects(
            this in Utf8JsonReader reader,
            JsonTokenType expected)
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

        /// <summary>
        /// Verify and read the next property name.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <returns>The name of the next property.</returns>
        public static string ExpectsPropertyName(this ref Utf8JsonReader reader)
        {
            reader.Expects(JsonTokenType.PropertyName);
            string name = reader.GetString();
            reader.Read(); // Advance past property names after we read them
            return name;
        }

        /// <summary>
        /// Verify and read the next string value.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <returns>The next string value.</returns>
        public static string ExpectsString(this ref Utf8JsonReader reader)
        {
            reader.Expects(JsonTokenType.String);
            return reader.GetString();
        }

        /// <summary>
        /// Verify and read the next double? value.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <returns>The next double? value.</returns>
        public static double? ExpectsNullableDouble(
            this ref Utf8JsonReader reader)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }
            reader.Expects(JsonTokenType.Number);
            return reader.GetDouble();
        }

        /// <summary>
        /// Verify and read the next long? value.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <returns>The next long? value.</returns>
        public static long? ExpectsNullableLong(
            this ref Utf8JsonReader reader)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }
            reader.Expects(JsonTokenType.Number);
            return reader.GetInt64();
        }

        /// <summary>
        /// Deserialize a JSON stream.
        /// </summary>
        /// <typeparam name="T">
        /// The target type to deserialize the JSON stream into.
        /// </typeparam>
        /// <param name="json">A JSON stream.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>A deserialized object.</returns>
        public static async Task<T> DeserializeAsync<T>(
            this Stream json,
            CancellationToken cancellationToken)
        {
            if (json is null)
            {
                return default;
            }
            else
            {
                return await JsonSerializer.DeserializeAsync<T>(
                    json,
                    JsonExtensions.SerializerOptions,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Deserialize a JSON stream.
        /// </summary>
        /// <typeparam name="T">
        /// The target type to deserialize the JSON stream into.
        /// </typeparam>
        /// <param name="json">A JSON stream.</param>
        /// <returns>A deserialized object.</returns>
        public static T Deserialize<T>(this Stream json)
        {
            // Short circuit for empty/erroneous streams.
            if (json is null)
            {
                return default;
            }

            int written = 0;
            byte[] rented = null;
            ReadOnlySpan<byte> utf8Bom = Constants.Utf8Bom;
            try
            {
                if (json.CanSeek)
                {
                    // Ask for 1 more than the length to avoid resizing later,
                    // which is unnecessary in the common case where the stream
                    // length doesn't change.
                    long expectedLength = Math.Max(utf8Bom.Length, json.Length - json.Position) + 1;
                    rented = ArrayPool<byte>.Shared.Rent(checked((int)expectedLength));
                }
                else
                {
                    rented = ArrayPool<byte>.Shared.Rent(Constants.UnseekableStreamInitialRentSize);
                }

                // Read up to 3 bytes to see if it's the UTF-8 BOM
                int lastRead;
                do
                {
                    // No need for checking for growth, the minimal rent sizes
                    // both guarantee it'll fit.
                    Debug.Assert(rented.Length >= utf8Bom.Length);
                    lastRead = json.Read(rented, written, utf8Bom.Length - written);
                    written += lastRead;
                } while (lastRead > 0 && written < utf8Bom.Length);

                // If we have 3 bytes, and they're the BOM, reset the write
                // position to 0.
                if (written == utf8Bom.Length &&
                    utf8Bom.SequenceEqual(rented.AsSpan(0, utf8Bom.Length)))
                {
                    written = 0;
                }

                do
                {
                    if (rented.Length == written)
                    {
                        byte[] toReturn = rented;
                        rented = ArrayPool<byte>.Shared.Rent(checked(toReturn.Length * 2));
                        Buffer.BlockCopy(toReturn, 0, rented, 0, toReturn.Length);

                        // Holds document content, clear it.
                        ArrayPool<byte>.Shared.Return(toReturn, clearArray: true);
                    }

                    lastRead = json.Read(rented, written, rented.Length - written);
                    written += lastRead;
                } while (lastRead > 0);

                // Deserialize the JSON once we've copied it over
                return JsonSerializer.Deserialize<T>(rented.AsSpan(0, written), JsonExtensions.SerializerOptions);
            }
            finally
            {
                if (rented != null)
                {
                    // Holds document content, clear it before returning it.
                    rented.AsSpan(0, written).Clear();
                    ArrayPool<byte>.Shared.Return(rented);
                }
            }
        }
    }
}
