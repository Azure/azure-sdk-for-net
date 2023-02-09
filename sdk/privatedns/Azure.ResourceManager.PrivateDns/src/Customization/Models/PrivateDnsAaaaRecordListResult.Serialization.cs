// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.PrivateDns;

namespace Azure.ResourceManager.PrivateDns.Models
{
    internal partial class PrivateDnsAaaaRecordListResult
    {
        internal static PrivateDnsAaaaRecordListResult DeserializePrivateDnsAaaaRecordListResult(JsonElement element)
        {
            Optional<IReadOnlyList<PrivateDnsAaaaRecordData>> value = default;
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
                    List<PrivateDnsAaaaRecordData> array = new List<PrivateDnsAaaaRecordData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PrivateDnsAaaaRecordData.DeserializePrivateDnsAaaaRecordData(item));
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
            return new PrivateDnsAaaaRecordListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
