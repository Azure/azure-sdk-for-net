// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewayUrlPathMap
    {
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource DefaultRedirectConfiguration
        {
            get => DefaultRedirectConfigurationId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = DefaultRedirectConfigurationId };
            set => DefaultRedirectConfigurationId = value?.Id;
        }
    }
}
