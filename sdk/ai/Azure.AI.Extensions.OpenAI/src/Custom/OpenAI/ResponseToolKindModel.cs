// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI
{
    /// <summary>
    /// A ModelReaderWriter read adapter for <see cref="ResponseToolKind"/>.
    /// <para>
    /// <see cref="ResponseToolKind"/> is an extensible enum defined in the referenced OpenAI library; as a value
    /// type it does not implement <see cref="IPersistableModel{T}"/>, so <see cref="ModelReaderWriter"/> has no
    /// builder for it. Generated tool discriminator reads nonetheless call
    /// <c>ModelReaderWriter.Read&lt;ResponseToolKind&gt;(...)</c>, which fails at runtime with
    /// "No ModelReaderWriterTypeBuilder found for ResponseToolKind".
    /// </para>
    /// <para>
    /// This adapter parses the discriminator's JSON string value and returns a boxed <see cref="ResponseToolKind"/>.
    /// <see cref="ModelReaderWriter"/> unboxes it back to the requested value type, allowing those generated reads
    /// to succeed without editing generated code. It mirrors <see cref="ResponseItemKindModel"/>.
    /// </para>
    /// </summary>
    internal sealed class ResponseToolKindModel : IJsonModel<object>
    {
        object IPersistableModel<object>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return new ResponseToolKind(document.RootElement.GetString());
        }

        object IJsonModel<object>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return new ResponseToolKind(document.RootElement.GetString());
        }

        string IPersistableModel<object>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<object>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException($"{nameof(ResponseToolKind)} is written inline as a JSON string, not through {nameof(ModelReaderWriter)}.");

        void IJsonModel<object>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException($"{nameof(ResponseToolKind)} is written inline as a JSON string, not through {nameof(ModelReaderWriter)}.");
    }
}
