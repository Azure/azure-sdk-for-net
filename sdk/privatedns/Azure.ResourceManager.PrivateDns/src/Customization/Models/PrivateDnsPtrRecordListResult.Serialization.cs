// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.PrivateDns;

namespace Azure.ResourceManager.PrivateDns.Models
{
    internal partial class PrivateDnsPtrRecordListResult
    {
        internal static PrivateDnsPtrRecordListResult DeserializePrivateDnsPtrRecordListResult(JsonElement element)
        {
            Optional<IReadOnlyList<PrivateDnsPtrRecordData>> value = default;
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
                    List<PrivateDnsPtrRecordData> array = new List<PrivateDnsPtrRecordData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PrivateDnsPtrRecordData.DeserializePrivateDnsPtrRecordData(item));
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
            return new PrivateDnsPtrRecordListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
