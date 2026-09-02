// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.CognitiveServices.Models
{
    public partial class CognitiveServicesCapabilityHostProperties
    {
        // This helper method is used to convert CognitiveServicesCapabilityHostProperties to CognitiveServicesProjectScopedCapabilityHostProperties to support the mitigation solution of using a single data model for both CapabilityHost and ProjectCapabilityHost resources.
        internal static CognitiveServicesProjectScopedCapabilityHostProperties ToProjectCapabilityHostProperties(CognitiveServicesCapabilityHostProperties capabilityHostProperties)
        {
            if (capabilityHostProperties == null)
                return null;

            return new CognitiveServicesProjectScopedCapabilityHostProperties(
                capabilityHostProperties.AiServicesConnections,
                capabilityHostProperties.VectorStoreConnections,
                capabilityHostProperties.StorageConnections,
                capabilityHostProperties.ThreadStorageConnections,
                capabilityHostProperties.ProvisioningState,
                capabilityHostProperties._additionalBinaryDataProperties);
        }
    }
}
