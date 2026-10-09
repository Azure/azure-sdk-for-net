// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> A load balancing rule for a load balancer. </summary>
    public partial class LoadBalancingRuleData
    {
        /// <summary> Gets the backend address pools. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.BackendAddressPools"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore BackendAddressPools.get.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.backendAddressPools")]
        public IList<WritableSubResource> BackendAddressPools
        {
            get
            {
                Properties ??= new LoadBalancingRuleProperties(default, default);
                return Properties.BackendAddressPools;
            }
        }

        /// <summary> Gets or sets the transport protocol. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.Protocol"/> instead. </remarks>
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
                    Properties ??= new LoadBalancingRuleProperties(default, default);
                    Properties.Protocol = value.Value;
                }
            }
        }

        /// <summary> Gets or sets the load distribution policy. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.LoadDistribution"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore LoadDistribution.get and LoadDistribution.set.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.loadDistribution")]
        public LoadDistribution? LoadDistribution
        {
            get => Properties?.LoadDistribution;
            set
            {
                Properties ??= new LoadBalancingRuleProperties(default, default);
                Properties.LoadDistribution = value;
            }
        }

        /// <summary> Gets or sets the frontend port. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.FrontendPort"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore FrontendPort.get and FrontendPort.set.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.frontendPort")]
        public int? FrontendPort
        {
            get => Properties?.FrontendPort;
            set
            {
                if (value.HasValue)
                {
                    Properties ??= new LoadBalancingRuleProperties(default, default);
                    Properties.FrontendPort = value.Value;
                }
            }
        }

        /// <summary> Gets or sets the backend port. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.BackendPort"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore BackendPort.get and BackendPort.set.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.backendPort")]
        public int? BackendPort
        {
            get => Properties?.BackendPort;
            set
            {
                Properties ??= new LoadBalancingRuleProperties(default, default);
                Properties.BackendPort = value;
            }
        }

        /// <summary> Gets or sets the idle timeout in minutes. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.IdleTimeoutInMinutes"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore IdleTimeoutInMinutes.get and IdleTimeoutInMinutes.set.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.idleTimeoutInMinutes")]
        public int? IdleTimeoutInMinutes
        {
            get => Properties?.IdleTimeoutInMinutes;
            set
            {
                Properties ??= new LoadBalancingRuleProperties(default, default);
                Properties.IdleTimeoutInMinutes = value;
            }
        }

        /// <summary> Gets or sets whether floating IP is enabled. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.EnableFloatingIP"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore EnableFloatingIP.get and EnableFloatingIP.set.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.enableFloatingIP")]
        public bool? EnableFloatingIP
        {
            get => Properties?.EnableFloatingIP;
            set
            {
                Properties ??= new LoadBalancingRuleProperties(default, default);
                Properties.EnableFloatingIP = value;
            }
        }

        /// <summary> Gets or sets whether TCP reset is enabled. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.EnableTcpReset"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore EnableTcpReset.get and EnableTcpReset.set.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.enableTcpReset")]
        public bool? EnableTcpReset
        {
            get => Properties?.EnableTcpReset;
            set
            {
                Properties ??= new LoadBalancingRuleProperties(default, default);
                Properties.EnableTcpReset = value;
            }
        }

        /// <summary> Gets or sets whether outbound SNAT is disabled. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.DisableOutboundSnat"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore DisableOutboundSnat.get and DisableOutboundSnat.set.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.disableOutboundSnat")]
        public bool? DisableOutboundSnat
        {
            get => Properties?.DisableOutboundSnat;
            set
            {
                Properties ??= new LoadBalancingRuleProperties(default, default);
                Properties.DisableOutboundSnat = value;
            }
        }

        /// <summary> Gets or sets whether connection tracking is enabled. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.EnableConnectionTracking"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore EnableConnectionTracking.get and EnableConnectionTracking.set.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.enableConnectionTracking")]
        public bool? EnableConnectionTracking
        {
            get => Properties?.EnableConnectionTracking;
            set
            {
                Properties ??= new LoadBalancingRuleProperties(default, default);
                Properties.EnableConnectionTracking = value;
            }
        }

        /// <summary> Gets the provisioning state. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.ProvisioningState"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore ProvisioningState.get.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.provisioningState")]
        public NetworkProvisioningState? ProvisioningState => Properties?.ProvisioningState;

        /// <summary> Gets or sets the frontend IP configuration resource ID. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.FrontendIPConfigurationId"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore FrontendIPConfigurationId.get and FrontendIPConfigurationId.set.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.frontendIPConfiguration.id")]
        public ResourceIdentifier FrontendIPConfigurationId
        {
            get => Properties?.FrontendIPConfigurationId;
            set
            {
                Properties ??= new LoadBalancingRuleProperties(default, default);
                Properties.FrontendIPConfigurationId = value;
            }
        }

        /// <summary> Gets or sets the backend address pool resource ID. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.BackendAddressPoolId"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore BackendAddressPoolId.get and BackendAddressPoolId.set.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.backendAddressPool.id")]
        public ResourceIdentifier BackendAddressPoolId
        {
            get => Properties?.BackendAddressPoolId;
            set
            {
                Properties ??= new LoadBalancingRuleProperties(default, default);
                Properties.BackendAddressPoolId = value;
            }
        }

        /// <summary> Gets or sets the probe resource ID. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.ProbeId"/> instead. </remarks>
        // ApiCompat 1.17.0 CP0002: restore ProbeId.get and ProbeId.set.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.probe.id")]
        public ResourceIdentifier ProbeId
        {
            get => Properties?.ProbeId;
            set
            {
                Properties ??= new LoadBalancingRuleProperties(default, default);
                Properties.ProbeId = value;
            }
        }

        /// <summary> Gets the additional properties. </summary>
        public IDictionary<string, BinaryData> AdditionalProperties
        {
            get
            {
                Properties ??= new LoadBalancingRuleProperties(default, default);
                return Properties.AdditionalProperties;
            }
        }
    }
}
