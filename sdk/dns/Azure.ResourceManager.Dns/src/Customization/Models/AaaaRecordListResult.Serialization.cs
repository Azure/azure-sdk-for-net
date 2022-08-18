// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Dns;

namespace Azure.ResourceManager.Dns.Models
{
    internal partial class AaaaRecordListResult
    {
        internal static AaaaRecordListResult DeserializeAaaaRecordSetListResult(JsonElement element)
        {
            Optional<IReadOnlyList<AaaaRecordData>> value = default;
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
                    List<AaaaRecordData> array = new List<AaaaRecordData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AaaaRecordData.DeserializeAaaaRecordData(item));
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
            return new AaaaRecordListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
