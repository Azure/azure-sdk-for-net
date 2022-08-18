// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Dns;

namespace Azure.ResourceManager.Dns.Models
{
    internal partial class CaaRecordListResult
    {
        internal static CaaRecordListResult DeserializeCaaRecordSetListResult(JsonElement element)
        {
            Optional<IReadOnlyList<CaaRecordData>> value = default;
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
                    List<CaaRecordData> array = new List<CaaRecordData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CaaRecordData.DeserializeCaaRecordData(item));
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
            return new CaaRecordListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
