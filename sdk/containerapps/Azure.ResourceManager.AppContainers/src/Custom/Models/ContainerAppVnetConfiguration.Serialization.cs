// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.AppContainers.Models
{
    [CodeGenSerialization(nameof(InfrastructureSubnetId), DeserializationValueHook = nameof(DeserializeInfrastructureSubnetIdValue))]
    public partial class ContainerAppVnetConfiguration : IUtf8JsonSerializable, IJsonModel<ContainerAppVnetConfiguration>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeInfrastructureSubnetIdValue(JsonProperty property, ref ResourceIdentifier infrastructureSubnetId)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            	return;
            var str = property.Value.GetString();
            if (!string.IsNullOrEmpty(str))
            {
                infrastructureSubnetId = new ResourceIdentifier(property.Value.GetString());
            }
        }
    }
}
