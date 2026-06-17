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
    /// <summary> The network security perimeter profile resource. </summary>
    [CodeGenSuppress("NetworkSecurityPerimeterProfileData", typeof(NspProfileProperties), typeof(string), typeof(IDictionary<string, BinaryData>))]
    [CodeGenSuppress("DeserializeNetworkSecurityPerimeterProfileData", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class NetworkSecurityPerimeterProfileData
    {
        // The migration customizes this model to inherit ResourceData, but the current generator still
        // emits deserialization against the service-defined base shape and ignores inherited ARM fields
        // in wire format. Keep those raw fields so ResourceData is initialized correctly.
        // TODO: Remove this SDK-side workaround after adopting the generator custom-base serialization fix.
        internal NetworkSecurityPerimeterProfileData(NspProfileProperties properties, string name, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(NetworkResourceDataSerializationCompatibility.GetId(additionalBinaryDataProperties), name ?? NetworkResourceDataSerializationCompatibility.GetName(additionalBinaryDataProperties), NetworkResourceDataSerializationCompatibility.GetResourceType(additionalBinaryDataProperties), NetworkResourceDataSerializationCompatibility.GetSystemData(additionalBinaryDataProperties))
        {
            Properties = properties;
            Name = name ?? NetworkResourceDataSerializationCompatibility.GetName(additionalBinaryDataProperties);
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        // The generated deserializer ignores inherited ARM fields in wire format; keep them in the raw
        // metadata bag so the custom constructor can initialize ResourceData.
        // TODO: Remove this SDK-side workaround after adopting the generator custom-base serialization fix.
        internal static NetworkSecurityPerimeterProfileData DeserializeNetworkSecurityPerimeterProfileData(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            NspProfileProperties properties = default;
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
                        properties = NspProfileProperties.DeserializeNspProfileProperties(prop.Value, options);
                    }
                    return true;
                }
                return false;
            });
            return new NetworkSecurityPerimeterProfileData(properties, name, additionalBinaryDataProperties);
        }
    }
}
