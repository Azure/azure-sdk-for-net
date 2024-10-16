// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Maps;

public class CountryRegion : IJsonModel<CountryRegion>
{
    internal CountryRegion(string isoCode)
    {
        IsoCode = isoCode;
    }

    public string IsoCode { get; }

    internal static CountryRegion FromJson(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }

        string isoCode = default;

        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("isoCode"u8))
            {
                isoCode = property.Value.GetString();
                continue;
            }
        }

        return new CountryRegion(isoCode);
    }

    public string GetFormatFromOptions(ModelReaderWriterOptions options)
        => "J";

    public CountryRegion Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        return FromJson(document.RootElement);
    }

    public CountryRegion Create(BinaryData data, ModelReaderWriterOptions options)
    {
        using var document = JsonDocument.Parse(data.ToString());
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
