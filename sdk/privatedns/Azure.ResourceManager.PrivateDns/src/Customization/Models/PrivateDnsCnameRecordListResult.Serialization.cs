// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.PrivateDns;

namespace Azure.ResourceManager.PrivateDns.Models
{
    internal partial class PrivateDnsCnameRecordListResult
    {
        internal static PrivateDnsCnameRecordListResult DeserializePrivateDnsCnameRecordListResult(JsonElement element)
        {
            Optional<IReadOnlyList<PrivateDnsCnameRecordData>> value = default;
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
                    List<PrivateDnsCnameRecordData> array = new List<PrivateDnsCnameRecordData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PrivateDnsCnameRecordData.DeserializePrivateDnsCnameRecordData(item));
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
            return new PrivateDnsCnameRecordListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
