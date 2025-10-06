// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Net;
using System.Text.Json;

namespace Maps;

public class IPAddressCountryPair : IJsonModel<IPAddressCountryPair>
{
    internal IPAddressCountryPair(CountryRegion countryRegion, IPAddress ipAddress)
    {
        CountryRegion = countryRegion;
        IpAddress = ipAddress;
    }

    public CountryRegion CountryRegion { get; }

    public IPAddress IpAddress { get; }

    internal static IPAddressCountryPair FromJson(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(IPAddressCountryPair)}'");
        }

        CountryRegion? countryRegion = default;
        IPAddress? ipAddress = default;

        foreach (JsonProperty property in element.EnumerateObject())
        {
            if (property.NameEquals("countryRegion"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }

                countryRegion = CountryRegion.FromJson(property.Value);
                continue;
            }

            if (property.NameEquals("ipAddress"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }

                ipAddress = IPAddress.Parse(property.Value.GetString()!);
                continue;
            }
        }

        if (countryRegion is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(IPAddressCountryPair)}': Missing 'countryRegion' property");
        }

        if (ipAddress is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(IPAddressCountryPair)}': Missing 'ipAddress' property");
        }

        return new IPAddressCountryPair(countryRegion, ipAddress);
    }

    internal static IPAddressCountryPair FromResponse(PipelineResponse response)
    {
        using JsonDocument document = JsonDocument.Parse(response.Content);
        return FromJson(document.RootElement);
    }

    public string GetFormatFromOptions(ModelReaderWriterOptions options)
        => "J";

    public IPAddressCountryPair Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return FromJson(document.RootElement);
    }

    public IPAddressCountryPair Create(BinaryData data, ModelReaderWriterOptions options)
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
