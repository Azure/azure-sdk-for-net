// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support
{
    /// <summary>
    /// A model that serializes to JSON by default but can be routed to a custom "plain text"
    /// format by a proxy. Used to prove a proxy works with formats other than JSON (note 8).
    /// </summary>
    internal class PlainTextModel : IJsonModel<PlainTextModel>
    {
        public string Value { get; set; } = "";

        PlainTextModel IJsonModel<PlainTextModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return new PlainTextModel { Value = doc.RootElement.TryGetProperty("value", out var v) ? v.GetString() ?? "" : "" };
        }

        PlainTextModel IPersistableModel<PlainTextModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return new PlainTextModel { Value = doc.RootElement.TryGetProperty("value", out var v) ? v.GetString() ?? "" : "" };
        }

        string IPersistableModel<PlainTextModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<PlainTextModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("value"u8, Value);
            writer.WriteEndObject();
        }

        BinaryData IPersistableModel<PlainTextModel>.Write(ModelReaderWriterOptions options)
            => BinaryData.FromString($"{{\"value\":\"{Value}\"}}");
    }
}
