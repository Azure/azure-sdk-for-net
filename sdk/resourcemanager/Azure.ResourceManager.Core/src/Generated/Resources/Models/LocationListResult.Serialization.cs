﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    internal partial class LocationListResult
    {
        internal static LocationListResult DeserializeLocationListResult(JsonElement element)
        {
            Optional<IReadOnlyList<LocationExpanded>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<LocationExpanded> array = new List<LocationExpanded>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(LocationExpanded.DeserializeLocationExpanded(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new LocationListResult(Optional.ToList(value));
        }
    }
}
