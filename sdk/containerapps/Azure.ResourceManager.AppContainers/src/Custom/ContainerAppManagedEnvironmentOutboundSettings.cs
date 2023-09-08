// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Net;

namespace Azure.ResourceManager.AppContainers.Models
{
    /// <summary> Configuration used to control the Environment Egress outbound traffic. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerAppManagedEnvironmentOutboundSettings
    {
        /// <summary> Initializes a new instance of ContainerAppManagedEnvironmentOutboundSettings. </summary>
        public ContainerAppManagedEnvironmentOutboundSettings()
        {
        }

        /// <summary> Initializes a new instance of ContainerAppManagedEnvironmentOutboundSettings. </summary>
        /// <param name="outBoundType"> Outbound type for the cluster. </param>
        /// <param name="virtualNetworkApplianceIP"> Virtual Appliance IP used as the Egress controller for the Environment. </param>
        internal ContainerAppManagedEnvironmentOutboundSettings(ContainerAppManagedEnvironmentOutBoundType? outBoundType, IPAddress virtualNetworkApplianceIP)
        {
            OutBoundType = outBoundType;
            VirtualNetworkApplianceIP = virtualNetworkApplianceIP;
        }

        /// <summary> Outbound type for the cluster. </summary>
        public ContainerAppManagedEnvironmentOutBoundType? OutBoundType { get; set; }
        /// <summary> Virtual Appliance IP used as the Egress controller for the Environment. </summary>
        public IPAddress VirtualNetworkApplianceIP { get; set; }
    }
}
