// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.PrivateDns;

namespace Azure.ResourceManager.PrivateDns.Models
{
    internal partial class PrivateDnsTxtRecordListResult
    {
        internal static PrivateDnsTxtRecordListResult DeserializePrivateDnsTxtRecordListResult(JsonElement element)
        {
            Optional<IReadOnlyList<PrivateDnsTxtRecordData>> value = default;
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
                    List<PrivateDnsTxtRecordData> array = new List<PrivateDnsTxtRecordData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PrivateDnsTxtRecordData.DeserializePrivateDnsTxtRecordData(item));
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
            return new PrivateDnsTxtRecordListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
