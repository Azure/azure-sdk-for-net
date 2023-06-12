// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Json
{
    /// <summary>
    /// A mutable representation of a JSON value.
    /// </summary>
    [JsonConverter(typeof(JsonConverter))]
    internal sealed partial class MutableJsonDocument : IDisposable
    {
        private readonly ReadOnlyMemory<byte> _original;
        private readonly JsonDocument _originalDocument;

        private readonly JsonSerializerOptions _serializerOptions;
        internal JsonSerializerOptions SerializerOptions { get => _serializerOptions; }

        private ChangeTracker? _changeTracker;
        internal ChangeTracker Changes
        {
            get
            {
                _changeTracker ??= new ChangeTracker(SerializerOptions);
                return _changeTracker;
            }
        }

        /// <summary>
        /// Gets the root element of this JSON document.
        /// </summary>
        public MutableJsonElement RootElement
        {
            get
            {
                if (Changes.TryGetChange(string.Empty, -1, out MutableJsonChange change))
                {
                    if (change.ReplacesJsonElement)
                    {
                        return new MutableJsonElement(this, change.AsJsonElement(), string.Empty, change.Index);
                    }
                }

                return new MutableJsonElement(this, _originalDocument.RootElement, string.Empty);
            }
        }

        /// <summary>
        /// Writes the document to the provided stream as a JSON value.
        /// </summary>
        /// <param name="stream">The stream to which to write the document.</param>
        /// <param name="format">A format string indicating the format to use when writing the document.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="stream"/> parameter is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">Thrown if an unsupported value is passed for format.</exception>
        /// <remarks>The value of <paramref name="format"/> can be default or 'J' to write the document as JSON.</remarks>
        public void WriteTo(Stream stream, StandardFormat format = default)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            if (format != default && format.Symbol != 'J')
            {
                throw new FormatException($"Unsupported format {format.Symbol}. Supported formats are: 'J' - JSON.");
            }

            if (!Changes.HasChanges)
            {
                Write(stream, _original.Span);
                return;
            }

            using Utf8JsonWriter writer = new(stream);
            RootElement.WriteTo(writer);
        }

        /// <summary>
        /// Writes the document to the provided stream as a JSON value.
        /// </summary>
        /// <param name="writer">The writer to which to write the document.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="writer"/> parameter is <see langword="null"/>.</exception>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        public void WriteTo(Utf8JsonWriter writer)
#pragma warning restore AZC0014 // Avoid using banned types in public API
        {
            Argument.AssertNotNull(writer, nameof(writer));

            if (!Changes.HasChanges)
            {
                _originalDocument.RootElement.WriteTo(writer);
                return;
            }

            RootElement.WriteTo(writer);
        }

        private static void Write(Stream stream, ReadOnlySpan<byte> buffer)
        {
            byte[] sharedBuffer = ArrayPool<byte>.Shared.Rent(buffer.Length);
            try
            {
                buffer.CopyTo(sharedBuffer);
                stream.Write(sharedBuffer, 0, buffer.Length);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(sharedBuffer);
            }
        }

        /// <summary>
        /// Parses a UTF-8 encoded string representing a single JSON value into a <see cref="MutableJsonDocument"/>.
        /// </summary>
        /// <param name="utf8Json">A UTF-8 encoded string representing a JSON value.</param>
        /// <returns>A <see cref="MutableJsonDocument"/> representation of the value.</returns>
        /// <param name="serializerOptions">Serializer options used to serialize and deserialize any changes to the JSON.</param>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
        public static MutableJsonDocument Parse(ReadOnlyMemory<byte> utf8Json, JsonSerializerOptions? serializerOptions = default)
        {
            var doc = JsonDocument.Parse(utf8Json);
            return new MutableJsonDocument(doc, utf8Json, serializerOptions);
        }

        /// <summary>
        /// Parses a UTF-8 encoded string representing a single JSON value into a <see cref="MutableJsonDocument"/>.
        /// </summary>
        /// <param name="utf8Json">A UTF-8 encoded string representing a JSON value.</param>
        /// <param name="serializerOptions">Serializer options used to serialize and deserialize any changes to the JSON.</param>
        /// <returns>A <see cref="MutableJsonDocument"/> representation of the value.</returns>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
        public static MutableJsonDocument Parse(BinaryData utf8Json, JsonSerializerOptions? serializerOptions = default)
        {
            var doc = JsonDocument.Parse(utf8Json);
            return new MutableJsonDocument(doc, utf8Json.ToMemory(), serializerOptions);
        }

        /// <summary>
        /// Parses test representing a single JSON value into a <see cref="MutableJsonDocument"/>.
        /// </summary>
        /// <param name="json">The JSON string.</param>
        /// <param name="serializerOptions">Serializer options used to serialize and deserialize any changes to the JSON.</param>
        /// <returns>A <see cref="MutableJsonDocument"/> representation of the value.</returns>
        /// <exception cref="JsonException"><paramref name="json"/> does not represent a valid single JSON value.</exception>
        public static MutableJsonDocument Parse(string json, JsonSerializerOptions? serializerOptions = default)
        {
            byte[] utf8 = Encoding.UTF8.GetBytes(json);
            Memory<byte> jsonMemory = utf8.AsMemory();
            return new MutableJsonDocument(JsonDocument.Parse(jsonMemory), jsonMemory, serializerOptions);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _originalDocument.Dispose();
        }

        internal MutableJsonDocument(JsonDocument document, JsonSerializerOptions? serializerOptions) : this(document, GetBytesFromDocument(document), serializerOptions)
        {
        }

        internal MutableJsonDocument(JsonDocument document, ReadOnlyMemory<byte> utf8Json, JsonSerializerOptions? serializerOptions)
        {
            _original = utf8Json;
            _originalDocument = document;
            _serializerOptions = serializerOptions ?? new JsonSerializerOptions();
        }

        private static ReadOnlyMemory<byte> GetBytesFromDocument(JsonDocument document)
        {
            using MemoryStream stream = new();
            using (Utf8JsonWriter writer = new(stream))
            {
                document.WriteTo(writer);
            }

            return new ReadOnlyMemory<byte>(stream.GetBuffer(), 0, (int)stream.Position);
        }

        private class JsonConverter : JsonConverter<MutableJsonDocument>
        {
            public override MutableJsonDocument Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                JsonDocument document = JsonDocument.ParseValue(ref reader);
                return new MutableJsonDocument(document, options);
            }

            public override void Write(Utf8JsonWriter writer, MutableJsonDocument value, JsonSerializerOptions options)
            {
                value.WriteTo(writer);
            }
        }
    }
}
