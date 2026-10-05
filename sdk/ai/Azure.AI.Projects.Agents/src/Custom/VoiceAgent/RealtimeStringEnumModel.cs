// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.Projects.Agents
{
    internal sealed class RealtimeStringEnumModel<T>(Func<string, T> create) : IJsonModel<object>
    {
        object IPersistableModel<object>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return create(document.RootElement.GetString());
        }

        object IJsonModel<object>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return create(document.RootElement.GetString());
        }

        string IPersistableModel<object>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<object>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("Referenced OpenAI string enums are written directly as JSON strings.");

        void IJsonModel<object>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("Referenced OpenAI string enums are written directly as JSON strings.");
    }
}
