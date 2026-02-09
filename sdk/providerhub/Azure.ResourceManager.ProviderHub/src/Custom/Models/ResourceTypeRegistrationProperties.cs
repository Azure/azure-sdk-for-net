// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ProviderHub.Models
{
    /// <summary> The ResourceTypeRegistrationProperties. </summary>
    public partial class ResourceTypeRegistrationProperties
    {
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
