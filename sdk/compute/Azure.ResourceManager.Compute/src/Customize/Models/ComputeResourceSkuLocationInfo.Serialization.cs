// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    // TEMPORARY: this piece of customized code replaces the ExtendedLocationType with the one in resourcemanager
    public partial class ComputeResourceSkuLocationInfo
    {
        internal static ComputeResourceSkuLocationInfo DeserializeComputeResourceSkuLocationInfo(JsonElement element)
        {
            Optional<AzureLocation> location = default;
            Optional<IReadOnlyList<string>> zones = default;
            Optional<IReadOnlyList<ComputeResourceSkuZoneDetails>> zoneDetails = default;
            Optional<IReadOnlyList<string>> extendedLocations = default;
            Optional<Azure.ResourceManager.Resources.Models.ExtendedLocationType> type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("location"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("zones"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    zones = array;
                    continue;
                }
                if (property.NameEquals("zoneDetails"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<ComputeResourceSkuZoneDetails> array = new List<ComputeResourceSkuZoneDetails>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ComputeResourceSkuZoneDetails.DeserializeComputeResourceSkuZoneDetails(item));
                    }
                    zoneDetails = array;
                    continue;
                }
                if (property.NameEquals("extendedLocations"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    extendedLocations = array;
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    type = new Azure.ResourceManager.Resources.Models.ExtendedLocationType(property.Value.GetString());
                    continue;
                }
            }
            return new ComputeResourceSkuLocationInfo(Optional.ToNullable(location), Optional.ToList(zones), Optional.ToList(zoneDetails), Optional.ToList(extendedLocations), Optional.ToNullable(type));
        }
    }
}
