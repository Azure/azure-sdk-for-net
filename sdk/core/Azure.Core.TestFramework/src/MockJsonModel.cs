// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.TestFramework
{
    public class MockJsonModel : IJsonModel<MockJsonModel>
    {
        public MockJsonModel()
        {
        }

        public int IntValue { get; set; }

        public string StringValue { get; set; }

        public byte[] Utf8BytesValue { get; }

        public MockJsonModel(int intValue, string stringValue)
        {
            IntValue = intValue;
            StringValue = stringValue;

            dynamic json = BinaryData.FromString("{}").ToDynamicFromJson(JsonPropertyNames.CamelCase);
            json.IntValue = IntValue;
            json.StringValue = StringValue;

            MemoryStream stream = new();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);

            writer.WriteStartObject();
            writer.WriteNumber("IntValue", IntValue);
            writer.WriteString("StringValue", StringValue);
            writer.WriteEndObject();

            writer.Flush();
            Utf8BytesValue = stream.ToArray();
        }

        MockJsonModel IPersistableModel<MockJsonModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            dynamic json = data.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            return new MockJsonModel(json.IntValue, json.StringValue);
        }

        MockJsonModel IJsonModel<MockJsonModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            int intValue = doc.RootElement.GetProperty("IntValue").GetInt32();
            string stringValue = doc.RootElement.GetProperty("StringValue").GetString()!;
            return new MockJsonModel(intValue, stringValue);
        }

        string IPersistableModel<MockJsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => "J";

        BinaryData IPersistableModel<MockJsonModel>.Write(ModelReaderWriterOptions options)
        {
            return BinaryData.FromBytes(Utf8BytesValue);
        }

        void IJsonModel<MockJsonModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("IntValue", IntValue);
            writer.WriteString("StringValue", StringValue);
            writer.WriteEndObject();
        }
    }
}
