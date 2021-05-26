// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    public partial class FeatureOperationsListResult
    {
        internal static FeatureOperationsListResult DeserializeFeatureOperationsListResult(JsonElement element)
        {
            Optional<IReadOnlyList<FeatureData>> value = default;
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
                    List<FeatureData> array = new List<FeatureData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FeatureData.DeserializeFeatureData(item));
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
            return new FeatureOperationsListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
