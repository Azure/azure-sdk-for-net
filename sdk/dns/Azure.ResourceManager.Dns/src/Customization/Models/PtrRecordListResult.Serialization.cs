// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Dns;

namespace Azure.ResourceManager.Dns.Models
{
    internal partial class PtrRecordListResult
    {
        internal static PtrRecordListResult DeserializePtrRecordSetListResult(JsonElement element)
        {
            Optional<IReadOnlyList<PtrRecordData>> value = default;
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
                    List<PtrRecordData> array = new List<PtrRecordData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PtrRecordData.DeserializePtrRecordData(item));
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
            return new PtrRecordListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
