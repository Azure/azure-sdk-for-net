// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> The network security perimeter link resource. </summary>
    [CodeGenSuppress("NetworkSecurityPerimeterLinkData", typeof(NspLinkProperties), typeof(string), typeof(IDictionary<string, BinaryData>))]
    [CodeGenSuppress("DeserializeNetworkSecurityPerimeterLinkData", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class NetworkSecurityPerimeterLinkData
    {
        // The migration customizes this model to inherit ResourceData, but the current generator still
        // emits deserialization against the service-defined base shape and ignores inherited ARM fields
        // in wire format. Keep those raw fields so ResourceData is initialized correctly.
        // TODO: Remove this SDK-side workaround after adopting the generator custom-base serialization fix.
        internal NetworkSecurityPerimeterLinkData(NspLinkProperties properties, string name, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(NetworkResourceDataSerializationCompatibility.GetId(additionalBinaryDataProperties), name ?? NetworkResourceDataSerializationCompatibility.GetName(additionalBinaryDataProperties), NetworkResourceDataSerializationCompatibility.GetResourceType(additionalBinaryDataProperties), NetworkResourceDataSerializationCompatibility.GetSystemData(additionalBinaryDataProperties))
        {
            Properties = properties;
            Name = name ?? NetworkResourceDataSerializationCompatibility.GetName(additionalBinaryDataProperties);
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        // The generated deserializer ignores inherited ARM fields in wire format; keep them in the raw
        // metadata bag so the custom constructor can initialize ResourceData.
        // TODO: Remove this SDK-side workaround after adopting the generator custom-base serialization fix.
        internal static NetworkSecurityPerimeterLinkData DeserializeNetworkSecurityPerimeterLinkData(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            NspLinkProperties properties = default;
            string name = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = NetworkResourceDataSerializationCompatibility.CreateAdditionalData(element, options, prop =>
            {
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    return true;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        properties = NspLinkProperties.DeserializeNspLinkProperties(prop.Value, options);
                    }
                    return true;
                }
                return false;
            });
            return new NetworkSecurityPerimeterLinkData(properties, name, additionalBinaryDataProperties);
        }
    }
}
