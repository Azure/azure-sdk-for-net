// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace ClientModel.Tests.Collections;

// A mock model that illustrates values that can be returned in a streamed collection
public class StreamedValue
{
    public StreamedValue(int id, string value)
    {
        Id = id;
        Value = value;
    }

    public int Id { get; }

    public string Value { get; }

    public string ToJson() => $"{{ \"id\" : {Id}, \"value\" : \"{Value}\" }}";

    public static StreamedValue FromJson(JsonElement element)
    {
        int id = element.GetProperty("id").GetInt32();
        string value = element.GetProperty("value").GetString()!;
        return new StreamedValue(id, value);
    }

    public static StreamedValue FromJson(byte[] data)
    {
        using JsonDocument doc = JsonDocument.Parse(data);
        return FromJson(doc.RootElement);
    }

    public override string ToString() => ToJson();
}
