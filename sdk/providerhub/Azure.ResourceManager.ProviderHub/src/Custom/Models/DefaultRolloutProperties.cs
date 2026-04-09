// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ProviderHub.Models
{
    // Backward-compat: re-exposes the baseline ProvisioningState property with the old public shape.
    // This is an ApiCompat-only shim, so it stays in custom code instead of changing the TypeSpec contract.
    /// <summary> The DefaultRolloutProperties. </summary>
    public partial class DefaultRolloutProperties
    {
        /// <summary> Gets or sets the provisioning state. </summary>
        public ProviderHubProvisioningState? ProvisioningState { get; set; }
    }
}
