// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class VirtualMachineScaleSetVmProperties
    {
        /// <summary> The list of network configurations. </summary>
        public IList<VirtualMachineScaleSetNetworkConfiguration> NetworkInterfaceConfigurations => NetworkProfileConfiguration?.NetworkInterfaceConfigurations;
    }
}
