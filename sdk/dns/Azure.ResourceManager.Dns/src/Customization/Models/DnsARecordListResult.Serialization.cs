// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Dns;

namespace Azure.ResourceManager.Dns.Models
{
    internal partial class DnsARecordListResult
    {
        internal static DnsARecordListResult DeserializeDnsARecordListResult(JsonElement element)
        {
            Optional<IReadOnlyList<DnsARecordData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<DnsARecordData> array = new List<DnsARecordData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DnsARecordData.DeserializeDnsARecordData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new DnsARecordListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
