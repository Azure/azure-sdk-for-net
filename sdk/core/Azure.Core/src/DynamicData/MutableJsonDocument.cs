// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable enable

namespace Azure.Core.Json
{
    /// <summary>
    /// A mutable representation of a JSON value.
    /// </summary>
#if !NET5_0 // RequiresUnreferencedCode in net5.0 doesn't have AttributeTargets.Class as a target, but it was added in net6.0
    // This class is marked as RequiresUnreferencedCode and RequiresDynamic code for two reasons. First, for the usage of MutableJsonElement in RootElement and WriteTo. Second, the method WriteTo
    // is  used in the MutableJsonDocumentConverter, which causes MutableJsonDocumentConverter to be incompatible with trimming. Since the class is used in the attribute on this class, the entire
    // class must be annotated.
    [RequiresUnreferencedCode(SerializationRequiresUnreferencedCodeClass)]
    [RequiresDynamicCode(SerializationRequiresUnreferencedCodeClass)]
#endif
    [JsonConverter(typeof(MutableJsonDocumentConverter))]
    internal sealed partial class MutableJsonDocument : IDisposable
    {
        private static readonly JsonSerializerOptions DefaultSerializerOptions = new JsonSerializerOptions();

        private readonly ReadOnlyMemory<byte> _original;
        private readonly JsonDocument _originalDocument;

        private readonly JsonSerializerOptions _serializerOptions;
        internal JsonSerializerOptions SerializerOptions => _serializerOptions;

        internal const string SerializationRequiresUnreferencedCodeClass = "This class utilizes reflection-based JSON serialization and deserialization which is not compatible with trimming.";

        private ChangeTracker? _changeTracker;
        internal ChangeTracker Changes
        {
            get
            {
                _changeTracker ??= new();
                return _changeTracker;
            }
        }

        /// <summary>
        /// Gets the root element of this JSON document.
        /// </summary>
        public MutableJsonElement RootElement
        {
            get => new(this, _originalDocument.RootElement, string.Empty);
        }

        /// <summary>
        /// Writes the document to the provided stream as a JSON value.
        /// </summary>
        /// <param name="stream">The stream to which to write the document.</param>
        /// <param name="format">A format string indicating the format to use when writing the document.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="stream"/> parameter is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">Thrown if an unsupported value is passed for format.</exception>
        /// <remarks>The value of <paramref name="format"/> can be default or "J" to write the document as JSON, or "P" to write the changes as JSON Merge Patch.</remarks>
        public void WriteTo(Stream stream, string? format = default)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            switch (format)
            {
                case "J":
                case null:
                    WriteJson(stream);
                    break;
                case "P":
                    WritePatch(stream);
                    break;
                default:
                    AssertInvalidFormat(format);
                    break;
            }
        }

        internal void AssertInvalidFormat(string? format)
        {
            throw new FormatException($"Unsupported format {format}. Supported formats are: \"J\" - JSON, \"P\" - JSON Merge Patch.");
        }

        private void WriteJson(Stream stream)
        {
            if (!Changes.HasChanges)
            {
                WriteOriginal(stream);
                return;
            }

            using Utf8JsonWriter writer = new(stream);
            RootElement.WriteTo(writer);
        }

        private void WriteOriginal(Stream stream)
        {
            if (_original.Length == 0)
            {
                using Utf8JsonWriter writer = new(stream);
                _originalDocument.WriteTo(writer);
                return;
            }

            Write(stream, _original.Span);
        }

        private void WritePatch(Stream stream)
        {
            if (!Changes.HasChanges)
            {
                return;
            }

            using Utf8JsonWriter writer = new(stream);
            RootElement.WritePatch(writer);
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
            JsonDocument doc = JsonDocument.Parse(utf8Json);
            return new MutableJsonDocument(doc, utf8Json, serializerOptions);
        }

        /// <summary>
        /// Parses JSON into a <see cref="MutableJsonDocument"/>.
        /// </summary>
        /// <param name="reader">Reader holding the JSON value.</param>
        /// <param name="serializerOptions">Serializer options used to serialize and deserialize any changes to the JSON.</param>
        /// <returns>A <see cref="MutableJsonDocument"/> representation of the value.</returns>
        public static MutableJsonDocument Parse(ref Utf8JsonReader reader, JsonSerializerOptions? serializerOptions = default)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return new MutableJsonDocument(doc, default, serializerOptions);
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
            JsonDocument doc = JsonDocument.Parse(utf8Json);
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

        private MutableJsonDocument(JsonDocument document, ReadOnlyMemory<byte> utf8Json, JsonSerializerOptions? serializerOptions)
        {
            _originalDocument = document;
            _original = utf8Json;
            _serializerOptions = serializerOptions ?? DefaultSerializerOptions;
        }

#if !NET5_0 // RequiresUnreferencedCode in net5.0 doesn't have AttributeTargets.Class as a target, but it was added in net6.0
        [RequiresUnreferencedCode(classIsIncompatibleWithTrimming)]
#endif
        [RequiresDynamicCode(classIsIncompatibleWithTrimming)]
        private class MutableJsonDocumentConverter : JsonConverter<MutableJsonDocument>
        {
            public const string classIsIncompatibleWithTrimming = "Using MutableJsonDocument or MutableJsonDocumentConverter is not compatible with trimming due to reflection-based serialization.";

            public override MutableJsonDocument Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return Parse(ref reader);
            }

            public override void Write(Utf8JsonWriter writer, MutableJsonDocument value, JsonSerializerOptions options)
            {
                value.WriteTo(writer);
            }
        }
    }
}
