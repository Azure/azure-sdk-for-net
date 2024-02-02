// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core.Serialization;
using System;
using System.ClientModel.Primitives;

namespace ClientModel.Tests.Mocks;

public class MockPersistableModel : IPersistableModel<MockPersistableModel>
{
    public int IntValue { get; set; }

    public string StringValue { get; set; }

    public string SerializedValue { get; }

    public MockPersistableModel(int intValue, string stringValue)
    {
        IntValue = intValue;
        StringValue = stringValue;

        dynamic json = BinaryData.FromString("{}").ToDynamicFromJson(JsonPropertyNames.CamelCase);
        json.IntValue = IntValue;
        json.StringValue = StringValue;
        SerializedValue = json.ToString();
    }

    MockPersistableModel IPersistableModel<MockPersistableModel>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        dynamic json = data.ToDynamicFromJson(JsonPropertyNames.CamelCase);
        return new MockPersistableModel(json.IntValue, json.StringValue);
    }

    string IPersistableModel<MockPersistableModel>.GetFormatFromOptions(ModelReaderWriterOptions options)
        => "J";

    BinaryData IPersistableModel<MockPersistableModel>.Write(ModelReaderWriterOptions options)
    {
        return BinaryData.FromString(SerializedValue);
    }
}
