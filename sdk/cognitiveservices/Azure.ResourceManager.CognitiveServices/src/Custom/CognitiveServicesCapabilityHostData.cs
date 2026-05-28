// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.CognitiveServices.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.CognitiveServices
{
    public partial class CognitiveServicesCapabilityHostData
    {
        // This helper method is used to convert CognitiveServicesCapabilityHostData to CognitiveServicesProjectScopedCapabilityHostData to support the mitigation solution of using a single data model for both CapabilityHost and ProjectCapabilityHost resources.
        internal static CognitiveServicesProjectScopedCapabilityHostData ToProjectCapabilityHostData(CognitiveServicesCapabilityHostData capabilityHostData)
        {
            if (capabilityHostData == null)
                return null;

            return new CognitiveServicesProjectScopedCapabilityHostData(
                id: capabilityHostData.Id,
                name: capabilityHostData.Name,
                resourceType: capabilityHostData.ResourceType,
                systemData: capabilityHostData.SystemData,
                properties: CognitiveServicesCapabilityHostProperties.ToProjectCapabilityHostProperties(capabilityHostData.Properties),
                additionalBinaryDataProperties: capabilityHostData._additionalBinaryDataProperties
            );
        }
    }
}
