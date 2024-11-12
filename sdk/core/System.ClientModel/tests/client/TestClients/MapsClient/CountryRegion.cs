// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Maps;

public class CountryRegion : IJsonModel<CountryRegion>
{
    public CountryRegion(string isoCode)
    {
        IsoCode = isoCode;
    }

    public string IsoCode { get; }

    internal static CountryRegion FromJson(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(CountryRegion)}'");
        }

        string? isoCode = default;

        foreach (JsonProperty property in element.EnumerateObject())
        {
            if (property.NameEquals("isoCode"u8))
            {
                isoCode = property.Value.GetString();
                continue;
            }
        }

        if (isoCode is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(CountryRegion)}': Missing 'isoCode' property");
        }

        return new CountryRegion(isoCode);
    }

    public string GetFormatFromOptions(ModelReaderWriterOptions options)
        => "J";

    public CountryRegion Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return FromJson(document.RootElement);
    }

    public CountryRegion Create(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.Parse(data.ToString());
        return FromJson(document.RootElement);
    }

    public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new NotSupportedException("This model is used for output only");
    }

    public BinaryData Write(ModelReaderWriterOptions options)
    {
        throw new NotSupportedException("This model is used for output only");
    }
}
