// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace ClientModel.Tests.Collections;

// A mock model that illustrate value that can be returned in a page collection
public class ValueItem
{
    public ValueItem(int id, string value)
    {
        Id = id;
        Value = value;
    }

    public int Id { get; }

    public string Value { get; }

    public string ToJson() => $"{{ \"id\" : {Id}, \"value\" : \"{Value}\" }}";

    public static ValueItem FromJson(JsonElement element)
    {
        int id = element.GetProperty("id").GetInt32();
        string value = element.GetProperty("value").GetString()!;
        return new ValueItem(id, value);
    }

    public static ValueItem FromJson(BinaryData data)
    {
        using JsonDocument doc = JsonDocument.Parse(data);
        return FromJson(doc.RootElement);
    }

    public override string ToString() => ToJson();
}
