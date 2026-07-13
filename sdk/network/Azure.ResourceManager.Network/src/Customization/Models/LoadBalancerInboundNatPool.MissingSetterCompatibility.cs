// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the LoadBalancerInboundNatPool type. </summary>
    public partial class LoadBalancerInboundNatPool
    {
        private Azure.ResourceManager.Network.Models.LoadBalancerInboundNatPoolProperties _properties;

        /// <summary> Gets or sets the Properties compatibility property. </summary>
        public Azure.ResourceManager.Network.Models.LoadBalancerInboundNatPoolProperties Properties
        {
            get => _properties;
            set => _properties = value;
        }
    }
}
