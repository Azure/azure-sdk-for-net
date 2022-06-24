// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Dns;

namespace Azure.ResourceManager.Dns.Models
{
    internal partial class TxtRecordSetListResult
    {
        internal static TxtRecordSetListResult DeserializeTxtRecordSetListResult(JsonElement element)
        {
            Optional<IReadOnlyList<TxtRecordSetData>> value = default;
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
                    List<TxtRecordSetData> array = new List<TxtRecordSetData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TxtRecordSetData.DeserializeTxtRecordSetData(item));
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
            return new TxtRecordSetListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
