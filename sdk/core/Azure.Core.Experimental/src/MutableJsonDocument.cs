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
    public sealed partial class MutableJsonDocument : IDisposable
    {
        internal static readonly JsonSerializerOptions DefaultJsonSerializerOptions = new JsonSerializerOptions();

        private readonly Memory<byte> _original;
        private readonly JsonDocument _originalDocument;

        internal ChangeTracker Changes { get; } = new();

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
        /// <param name="stream"></param>
        /// <param name="format"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void WriteTo(Stream stream, StandardFormat format = default)
        {
            // this is so we can add JSON Patch in the future
            if (format != default)
            {
                throw new ArgumentOutOfRangeException(nameof(format));
            }

            Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            if (!Changes.HasChanges)
            {
                Write(stream, _original.Span);
                stream.Flush();
                return;
            }

            WriteRootElementTo(writer);
        }

        internal void WriteTo(Utf8JsonWriter writer)
        {
            if (!Changes.HasChanges)
            {
                _originalDocument.RootElement.WriteTo(writer);
                return;
            }

            WriteRootElementTo(writer);
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
        public static MutableJsonDocument Parse(BinaryData utf8Json)
        {
            var doc = JsonDocument.Parse(utf8Json);
            return new MutableJsonDocument(doc, utf8Json.ToArray().AsMemory());
        }

        /// <summary>
        /// Parses test representing a single JSON value into a <see cref="MutableJsonDocument"/>.
        /// </summary>
        /// <param name="json">The JSON string.</param>
        /// <returns>A <see cref="MutableJsonDocument"/> representation of the value.</returns>
        public static MutableJsonDocument Parse(string json)
        {
            byte[] utf8 = Encoding.UTF8.GetBytes(json);
            Memory<byte> jsonMemory = utf8.AsMemory();
            return new MutableJsonDocument(JsonDocument.Parse(jsonMemory), jsonMemory);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _originalDocument.Dispose();
        }

        internal MutableJsonDocument(JsonDocument jsonDocument, Memory<byte> utf8Json) : this(jsonDocument.RootElement)
        {
            _original = utf8Json;
            _originalDocument = jsonDocument;
        }

        /// <summary>
        /// Creates a new JsonData object which represents the given object.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        internal MutableJsonDocument(object? value) : this(value, DefaultJsonSerializerOptions)
        {
        }

        /// <summary>
        /// Creates a new JsonData object which represents the given object.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="options">Options to control the conversion behavior.</param>
        /// <param name="type">The type of the value to convert. </param>
        internal MutableJsonDocument(object? value, JsonSerializerOptions options, Type? type = null)
        {
            if (value is JsonDocument)
                throw new InvalidOperationException("Calling wrong constructor.");

            Type inputType = type ?? (value == null ? typeof(object) : value.GetType());
            _original = JsonSerializer.SerializeToUtf8Bytes(value, inputType, options);
            _originalDocument = JsonDocument.Parse(_original);
        }

        private class JsonConverter : JsonConverter<MutableJsonDocument>
        {
            public override MutableJsonDocument Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using JsonDocument document = JsonDocument.ParseValue(ref reader);
                return new MutableJsonDocument(document);
            }

            public override void Write(Utf8JsonWriter writer, MutableJsonDocument value, JsonSerializerOptions options)
            {
                value.WriteTo(writer);
            }
        }
    }
}
