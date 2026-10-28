// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute.Models
{
    // The service returns "Name", but earlier versions of this library serialized the property as "name".
    // Accept both spellings so JSON persisted by older versions still round-trips.
    [CodeGenSuppress("DeserializeComputeResourceSkuZoneDetails", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class ComputeResourceSkuZoneDetails
    {
        internal static ComputeResourceSkuZoneDetails DeserializeComputeResourceSkuZoneDetails(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<string> name = default;
            IReadOnlyList<ComputeResourceSkuCapabilities> capabilities = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("Name"u8) || prop.NameEquals("name"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(item.GetString());
                        }
                    }
                    name = array;
                    continue;
                }
                if (prop.NameEquals("capabilities"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ComputeResourceSkuCapabilities> array = new List<ComputeResourceSkuCapabilities>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(ComputeResourceSkuCapabilities.DeserializeComputeResourceSkuCapabilities(item, options));
                    }
                    capabilities = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, prop.Value.GetUtf8Bytes());
                }
            }
            return new ComputeResourceSkuZoneDetails(name ?? new ChangeTrackingList<string>(), capabilities ?? new ChangeTrackingList<ComputeResourceSkuCapabilities>(), additionalBinaryDataProperties);
        }
    }
}
