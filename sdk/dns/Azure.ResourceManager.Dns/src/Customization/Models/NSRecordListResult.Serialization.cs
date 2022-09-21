// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Dns;

namespace Azure.ResourceManager.Dns.Models
{
    internal partial class NSRecordListResult
    {
        internal static NSRecordListResult DeserializeNSRecordSetListResult(JsonElement element)
        {
            Optional<IReadOnlyList<NSRecordData>> value = default;
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
                    List<NSRecordData> array = new List<NSRecordData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(NSRecordData.DeserializeNSRecordData(item));
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
            return new NSRecordListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
