// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    public partial class ArmApplicationPackageSupportUris
    {
        internal static ArmApplicationPackageSupportUris DeserializeArmApplicationPackageSupportUris(JsonElement element)
        {
            Optional<Uri> publicAzure = default;
            Optional<Uri> governmentCloud = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("publicAzure"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null || property.Value.GetString().Length == 0)
                    {
                        publicAzure = null;
                        continue;
                    }
                    publicAzure = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("governmentCloud"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null || property.Value.GetString().Length == 0)
                    {
                        governmentCloud = null;
                        continue;
                    }
                    governmentCloud = new Uri(property.Value.GetString());
                    continue;
                }
            }
            return new ArmApplicationPackageSupportUris(publicAzure.Value, governmentCloud.Value);
        }
    }
}
