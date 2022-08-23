// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Dns;

namespace Azure.ResourceManager.Dns.Models
{
    internal partial class ARecordListResult
    {
        internal static ARecordListResult DeserializeARecordSetListResult(JsonElement element)
        {
            Optional<IReadOnlyList<ARecordData>> value = default;
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
                    List<ARecordData> array = new List<ARecordData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ARecordData.DeserializeARecordData(item));
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
            return new ARecordListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
