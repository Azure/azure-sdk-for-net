// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ProviderHub.Models
{
    // Backward-compat: re-exposes baseline properties that the generated model no longer publishes with the old shape.
    // These are ApiCompat-only shims, so they stay in custom code instead of changing the TypeSpec contract.
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
