// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayUrlPathMap type. </summary>
    public partial class ApplicationGatewayUrlPathMap
    {
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource DefaultRedirectConfiguration
        {
            get => DefaultRedirectConfigurationId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = DefaultRedirectConfigurationId };
            set => DefaultRedirectConfigurationId = value?.Id;
        }
    }
}
