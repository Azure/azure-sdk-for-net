// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.EventHubs.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventHubs
{
    [CodeGenSuppress("PlatformCapabilitiesConfidentialComputeMode")]
    public partial class EventHubsNamespaceData
    {
        /// <summary> Setting to Enable or Disable Confidential Compute. </summary>
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
