// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayIPConfiguration type. </summary>
    public partial class ApplicationGatewayIPConfiguration
    {
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource Subnet
        {
            get => SubnetId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = SubnetId };
            set => SubnetId = value?.Id;
        }
    }
}
