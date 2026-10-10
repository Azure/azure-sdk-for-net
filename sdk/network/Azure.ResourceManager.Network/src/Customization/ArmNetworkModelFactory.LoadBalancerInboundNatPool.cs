// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    // The retained factory without a dictionary argument must initialize native extension storage,
    // rather than passing null to the generated dictionary getter and JSON writer.
    [CodeGenSuppress("LoadBalancerInboundNatPoolProperties", typeof(ResourceIdentifier), typeof(LoadBalancingTransportProtocol), typeof(int), typeof(int), typeof(int), typeof(int?), typeof(bool?), typeof(bool?), typeof(NetworkProvisioningState?))]
    public static partial class ArmNetworkModelFactory
    {
        /// <summary> Creates inbound NAT pool properties for mocking. </summary>
        /// <param name="frontendIPConfigurationId"> The frontend IP configuration resource ID. </param>
        /// <param name="protocol"> The transport protocol. </param>
        /// <param name="frontendPortRangeStart"> The first frontend port in the range. </param>
        /// <param name="frontendPortRangeEnd"> The last frontend port in the range. </param>
        /// <param name="backendPort"> The backend port. </param>
        /// <param name="idleTimeoutInMinutes"> The idle timeout in minutes. </param>
        /// <param name="enableFloatingIP"> Whether floating IP is enabled. </param>
        /// <param name="enableTcpReset"> Whether TCP reset is enabled. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <returns> A new <see cref="Azure.ResourceManager.Network.Models.LoadBalancerInboundNatPoolProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LoadBalancerInboundNatPoolProperties LoadBalancerInboundNatPoolProperties(ResourceIdentifier frontendIPConfigurationId = default, LoadBalancingTransportProtocol protocol = default, int frontendPortRangeStart = 0, int frontendPortRangeEnd = 0, int backendPort = 0, int? idleTimeoutInMinutes = default, bool? enableFloatingIP = default, bool? enableTcpReset = default, NetworkProvisioningState? provisioningState = default)
        {
            return new LoadBalancerInboundNatPoolProperties(
                frontendIPConfigurationId is null ? default : new NetworkSubResource(frontendIPConfigurationId, default),
                protocol,
                frontendPortRangeStart,
                frontendPortRangeEnd,
                backendPort,
                idleTimeoutInMinutes,
                enableFloatingIP,
                enableTcpReset,
                provisioningState,
                new ChangeTrackingDictionary<string, BinaryData>());
        }
    }
}
