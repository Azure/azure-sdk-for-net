// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSerialization("LoadBalancerFrontendIPConfigurationId",
        SerializationValueHook = nameof(SerializeLoadBalancerFrontendIPConfigurationId),
        DeserializationValueHook = nameof(DeserializeLoadBalancerFrontendIPConfigurationId))]
    internal partial class LoadBalancerBackendAddressPropertiesFormat
    {
        private void SerializeLoadBalancerFrontendIPConfigurationId(Utf8JsonWriter writer, ModelReaderWriterOptions options) =>
            ResourceReferenceSerialization.Write(writer, LoadBalancerFrontendIPConfigurationId);

        private static void DeserializeLoadBalancerFrontendIPConfigurationId(JsonProperty property, ref ResourceIdentifier value) =>
            value = ResourceReferenceSerialization.Read(property);
    }
}
