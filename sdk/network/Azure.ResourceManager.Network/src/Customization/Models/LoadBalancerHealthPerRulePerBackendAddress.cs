// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> The information about health per rule per backend address. </summary>
    public partial class LoadBalancerHealthPerRulePerBackendAddress
    {
        /// <summary> The id of the network interface ip configuration belonging to the backend address. </summary>
        public NetworkInterfaceIPConfigurationData NetworkInterfaceIPConfigurationId
        {
            get
            {
                if (NetworkInterfaceIPConfigurationResourceId != null)
                {
                    return new NetworkInterfaceIPConfigurationData() { Id = NetworkInterfaceIPConfigurationResourceId };
                }
                return null;
            }
        }
    }
}
