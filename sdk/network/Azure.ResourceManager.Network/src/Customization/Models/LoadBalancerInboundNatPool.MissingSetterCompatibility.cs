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

        // TODO: Remove when https://github.com/Azure/azure-sdk-for-net/pull/62632 is available in the generator.
        /// <summary> Gets the additional properties. </summary>
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties
        {
            get
            {
                Properties ??= new LoadBalancerInboundNatPoolProperties(default, default, default, default);
                return Properties.AdditionalProperties;
            }
        }
    }
}
