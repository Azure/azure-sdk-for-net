// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ProviderHub.Models
{
    /// <summary> The ResourceTypeRegistrationProperties. </summary>
    [CodeGenSerialization(nameof(ServiceTreeInfos), "serviceTreeInfos")]
    [CodeGenSerialization(nameof(DstsConfiguration), "dstsConfiguration")]
    public partial class ResourceTypeRegistrationProperties
    {
        // Preserve the released collection and its wire name. The internal setter keeps the
        // generator from treating this mutable collection as response-only.
        /// <summary> The service tree infos. </summary>
        public IList<ServiceTreeInfo> ServiceTreeInfos { get; internal set; } = new ChangeTrackingList<ServiceTreeInfo>();

        // Preserve the released authentication configuration and its wire name.
        /// <summary> The dsts configuration. </summary>
        public ProviderDstsConfiguration DstsConfiguration { get; set; }

        /// <summary> Gets or sets the provisioning state. </summary>
        public ProviderHubProvisioningState? ProvisioningState { get; set; }
        /// <summary> Gets or sets the opt in headers. </summary>
        public OptInHeaderType? OptInHeaders
        {
            get => RequestHeaderOptions is null ? default : RequestHeaderOptions.OptInHeaders;
            set
            {
                if (RequestHeaderOptions is null)
                    RequestHeaderOptions = new ProviderRequestHeaderOptions();
                RequestHeaderOptions.OptInHeaders = value;
            }
        }
    }
}
