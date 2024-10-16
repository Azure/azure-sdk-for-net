// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Net;
using System.Text.Json;
using Azure;
using Maps;

namespace Azure.Core.Experimental.Tests;

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
            return null;
        }

        CountryRegion countryRegion = default;
        IPAddress ipAddress = default;

        foreach (var property in element.EnumerateObject())
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

                ipAddress = IPAddress.Parse(property.Value.GetString());
                continue;
            }
        }

        return new IPAddressCountryPair(countryRegion, ipAddress);
    }

    internal static IPAddressCountryPair FromResponse(Response response)
    {
        using var document = JsonDocument.Parse(response.Content);
        return FromJson(document.RootElement);
    }

    public string GetFormatFromOptions(ModelReaderWriterOptions options)
        => "J";

    public IPAddressCountryPair Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        return FromJson(document.RootElement);
    }

    public IPAddressCountryPair Create(BinaryData data, ModelReaderWriterOptions options)
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
