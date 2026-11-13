// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ProviderHub.Models
{
    /// <summary> The DefaultRolloutProperties. </summary>
    public partial class DefaultRolloutProperties
    {
        /// <summary> Gets or sets the provisioning state. </summary>
        public ProviderHubProvisioningState? ProvisioningState { get; set; }
    }
}
