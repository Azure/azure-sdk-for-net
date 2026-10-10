// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Inbound NAT pool of the load balancer. </summary>
    public partial class LoadBalancerInboundNatPool
    {
        /// <summary> Gets or sets the transport protocol. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancerInboundNatPoolProperties.Protocol"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore Protocol.get and Protocol.set.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.protocol")]
        public LoadBalancingTransportProtocol? Protocol
        {
            get => Properties?.Protocol;
            set
            {
                if (value.HasValue)
                {
                    Properties ??= new LoadBalancerInboundNatPoolProperties(default, default, default, default);
                    Properties.Protocol = value.Value;
                }
            }
        }

        /// <summary> Gets or sets the first frontend port in the range. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancerInboundNatPoolProperties.FrontendPortRangeStart"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore FrontendPortRangeStart.get and FrontendPortRangeStart.set.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.frontendPortRangeStart")]
        public int? FrontendPortRangeStart
        {
            get => Properties?.FrontendPortRangeStart;
            set
            {
                if (value.HasValue)
                {
                    Properties ??= new LoadBalancerInboundNatPoolProperties(default, default, default, default);
                    Properties.FrontendPortRangeStart = value.Value;
                }
            }
        }

        /// <summary> Gets or sets the last frontend port in the range. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancerInboundNatPoolProperties.FrontendPortRangeEnd"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore FrontendPortRangeEnd.get and FrontendPortRangeEnd.set.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.frontendPortRangeEnd")]
        public int? FrontendPortRangeEnd
        {
            get => Properties?.FrontendPortRangeEnd;
            set
            {
                if (value.HasValue)
                {
                    Properties ??= new LoadBalancerInboundNatPoolProperties(default, default, default, default);
                    Properties.FrontendPortRangeEnd = value.Value;
                }
            }
        }

        /// <summary> Gets or sets the backend port. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancerInboundNatPoolProperties.BackendPort"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore BackendPort.get and BackendPort.set.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.backendPort")]
        public int? BackendPort
        {
            get => Properties?.BackendPort;
            set
            {
                if (value.HasValue)
                {
                    Properties ??= new LoadBalancerInboundNatPoolProperties(default, default, default, default);
                    Properties.BackendPort = value.Value;
                }
            }
        }

        /// <summary> Gets or sets the idle timeout in minutes. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancerInboundNatPoolProperties.IdleTimeoutInMinutes"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore IdleTimeoutInMinutes.get and IdleTimeoutInMinutes.set.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.idleTimeoutInMinutes")]
        public int? IdleTimeoutInMinutes
        {
            get => Properties?.IdleTimeoutInMinutes;
            set
            {
                Properties ??= new LoadBalancerInboundNatPoolProperties(default, default, default, default);
                Properties.IdleTimeoutInMinutes = value;
            }
        }

        /// <summary> Gets or sets whether floating IP is enabled. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancerInboundNatPoolProperties.EnableFloatingIP"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore EnableFloatingIP.get and EnableFloatingIP.set.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.enableFloatingIP")]
        public bool? EnableFloatingIP
        {
            get => Properties?.EnableFloatingIP;
            set
            {
                Properties ??= new LoadBalancerInboundNatPoolProperties(default, default, default, default);
                Properties.EnableFloatingIP = value;
            }
        }

        /// <summary> Gets or sets whether TCP reset is enabled. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancerInboundNatPoolProperties.EnableTcpReset"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore EnableTcpReset.get and EnableTcpReset.set.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.enableTcpReset")]
        public bool? EnableTcpReset
        {
            get => Properties?.EnableTcpReset;
            set
            {
                Properties ??= new LoadBalancerInboundNatPoolProperties(default, default, default, default);
                Properties.EnableTcpReset = value;
            }
        }

        /// <summary> Gets the provisioning state. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancerInboundNatPoolProperties.ProvisioningState"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore ProvisioningState.get.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.provisioningState")]
        public NetworkProvisioningState? ProvisioningState => Properties?.ProvisioningState;

        /// <summary> Gets or sets the frontend IP configuration resource ID. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancerInboundNatPoolProperties.FrontendIPConfigurationId"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore FrontendIPConfigurationId.get and FrontendIPConfigurationId.set.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.frontendIPConfiguration.id")]
        public ResourceIdentifier FrontendIPConfigurationId
        {
            get => Properties?.FrontendIPConfigurationId;
            set
            {
                Properties ??= new LoadBalancerInboundNatPoolProperties(default, default, default, default);
                Properties.FrontendIPConfigurationId = value;
            }
        }

        /// <summary> Gets the additional properties. </summary>
        public IDictionary<string, BinaryData> AdditionalProperties
        {
            get
            {
                Properties ??= new LoadBalancerInboundNatPoolProperties(default, default, default, default);
                return Properties.AdditionalProperties;
            }
        }
    }
}
