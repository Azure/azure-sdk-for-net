// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    // Base of a small discriminated hierarchy for proxy tests. It knows nothing about DerivedTestTool, which is only
    // produced when a proxy registered for this type claims the payload.
    internal class TestTool : IJsonModel<TestTool>
    {
        public TestTool() : this("unknown")
        {
        }

        public TestTool(string type)
        {
            Type = type;
        }

        public string Type { get; }

        protected virtual void WriteProperties(Utf8JsonWriter writer)
        {
        }

        void IJsonModel<TestTool>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("type"u8, Type);
            WriteProperties(writer);
            writer.WriteEndObject();
        }

        TestTool IJsonModel<TestTool>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return Deserialize(document.RootElement);
        }

        BinaryData IPersistableModel<TestTool>.Write(ModelReaderWriterOptions options)
            => ModelReaderWriter.Write(this, options);

        TestTool IPersistableModel<TestTool>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data);
            return Deserialize(document.RootElement);
        }

        string IPersistableModel<TestTool>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        private static TestTool Deserialize(JsonElement element)
            => new(element.TryGetProperty("type", out JsonElement type) ? type.GetString() ?? "unknown" : "unknown");
    }
}
