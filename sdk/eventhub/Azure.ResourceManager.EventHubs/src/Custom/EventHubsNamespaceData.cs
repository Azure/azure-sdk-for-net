// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.EventHubs.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventHubs
{
    // Rename the generated property "PlatformCapabilitiesConfidentialComputeMode" to "ConfidentialComputeMode"
    // for backward compatibility with the old AutoRest-generated SDK (version 1.2.x).
    //
    // In the TypeSpec definition (models.tsp), the property is nested 3 levels deep:
    //   EHNamespaceProperties.platformCapabilities (PlatformCapabilities)
    //     -> confidentialCompute (ConfidentialCompute)
    //       -> mode (Mode, renamed to EventHubsConfidentialComputeMode via @@clientName in client.tsp)
    //
    // The C# generator applies @@flattenProperty on EventHubsNamespace.properties (client.tsp line 345-347),
    // which flattens EHNamespaceProperties into EventHubsNamespaceData. However, the nested structure
    // within EHNamespaceProperties (platformCapabilities -> confidentialCompute -> mode) is further
    // auto-flattened by the generator into a single property named "PlatformCapabilitiesConfidentialComputeMode"
    // (wire path: "properties.platformCapabilities.confidentialCompute.mode").
    //
    // The old swagger-based SDK exposed this as simply "ConfidentialComputeMode" because AutoRest used
    // x-ms-client-flatten on EHNamespaceProperties. To maintain API compatibility, we use [CodeGenMember]
    // to rename the generated property back to "ConfidentialComputeMode".
    public partial class EventHubsNamespaceData
    {
        /// <summary> Setting to Enable or Disable Confidential Compute. </summary>
        [CodeGenMember("PlatformCapabilitiesConfidentialComputeMode")]
        public EventHubsConfidentialComputeMode? ConfidentialComputeMode
        {
            get
            {
                return Properties is null ? default : Properties.PlatformCapabilitiesConfidentialComputeMode;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new EHNamespaceProperties();
                }
                Properties.PlatformCapabilitiesConfidentialComputeMode = value.Value;
            }
        }
    }
}
