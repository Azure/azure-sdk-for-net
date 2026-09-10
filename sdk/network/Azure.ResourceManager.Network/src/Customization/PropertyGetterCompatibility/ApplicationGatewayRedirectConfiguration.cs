// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayRedirectConfiguration type. </summary>
    public partial class ApplicationGatewayRedirectConfiguration
    {
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource TargetListener
        {
            get => TargetListenerId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = TargetListenerId };
            set => TargetListenerId = value?.Id;
        }
    }
}
