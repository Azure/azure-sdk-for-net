// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: RegistryPrivateEndpoint is generated from PrivateEndpointResource, but the generated
    // subnetArmId property would duplicate the shipped SubnetArmId compatibility property on its
    // MachineLearningPrivateEndpoint base type. Suppress the duplicate and use the inherited property.
    [CodeGenSuppress("SubnetArmId")]
    [CodeGenSuppress("RegistryPrivateEndpoint", typeof(ResourceIdentifier), typeof(IDictionary<string, BinaryData>))]
    public partial class RegistryPrivateEndpoint
    {
        /// <summary> Initializes a new instance of <see cref="RegistryPrivateEndpoint"/>. </summary>
        /// <param name="id"> The resource identifier of the private endpoint. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal RegistryPrivateEndpoint(ResourceIdentifier id, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(id, GetSubnetArmId(additionalBinaryDataProperties), RemoveSubnetArmId(additionalBinaryDataProperties))
        {
        }

        internal RegistryPrivateEndpoint(ResourceIdentifier id, IDictionary<string, BinaryData> additionalBinaryDataProperties, ResourceIdentifier subnetArmId)
            : base(id, subnetArmId, additionalBinaryDataProperties)
        {
        }

        private static ResourceIdentifier GetSubnetArmId(IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            if (additionalBinaryDataProperties is null || !additionalBinaryDataProperties.TryGetValue("subnetArmId", out BinaryData subnetArmId))
            {
                return default;
            }

            using JsonDocument document = JsonDocument.Parse(subnetArmId);
            return document.RootElement.ValueKind == JsonValueKind.Null ? default : new ResourceIdentifier(document.RootElement.GetString());
        }

        private static IDictionary<string, BinaryData> RemoveSubnetArmId(IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            if (additionalBinaryDataProperties is null || !additionalBinaryDataProperties.ContainsKey("subnetArmId"))
            {
                return additionalBinaryDataProperties;
            }

            ChangeTrackingDictionary<string, BinaryData> result = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (KeyValuePair<string, BinaryData> property in additionalBinaryDataProperties)
            {
                if (property.Key != "subnetArmId")
                {
                    result.Add(property.Key, property.Value);
                }
            }

            return result;
        }
    }
}
