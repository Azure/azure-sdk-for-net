// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core.Serialization;
using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;

namespace ClientModel.Tests.Mocks;

public class MockPersistableJsonModel : IJsonModel<MockPersistableJsonModel>
{
    public int IntValue { get; set; }

    public string StringValue { get; set; }

    public byte[] Utf8BytesValue { get; }

    public MockPersistableJsonModel(int intValue, string stringValue)
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

    MockPersistableJsonModel IPersistableModel<MockPersistableJsonModel>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        dynamic json = data.ToDynamicFromJson(JsonPropertyNames.CamelCase);
        return new MockPersistableJsonModel(json.IntValue, json.StringValue);
    }

    MockPersistableJsonModel IJsonModel<MockPersistableJsonModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        int intValue = doc.RootElement.GetProperty("IntValue").GetInt32();
        string stringValue = doc.RootElement.GetProperty("StringValue").GetString()!;
        return new MockPersistableJsonModel(intValue, stringValue);
    }

    string IPersistableModel<MockPersistableJsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options)
        => "J";

    BinaryData IPersistableModel<MockPersistableJsonModel>.Write(ModelReaderWriterOptions options)
    {
        return BinaryData.FromBytes(Utf8BytesValue);
    }

    void IJsonModel<MockPersistableJsonModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteNumber("IntValue", IntValue);
        writer.WriteString("StringValue", StringValue);
        writer.WriteEndObject();
    }
}
