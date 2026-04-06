// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ProviderHub.Models
{
    /// <summary> The DefaultRolloutProperties. </summary>
    [CodeGenSuppress("ProvisioningState")]
    public partial class DefaultRolloutProperties
    {
        /// <summary> Gets or sets the provisioning state. </summary>
        public ProviderHubProvisioningState? ProvisioningState { get; set; }
    }
}
