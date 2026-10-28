// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network
{
    public partial class LoadBalancingRuleData
    {
        // 1.15.0 retains public Properties and this hidden list facade; flattening would remove the public property bag.
        /// <summary> Gets the backend address pools. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.BackendAddressPools"/> instead. </remarks>
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

        // Preserve the 1.15.0 nullable facade over the required protocol in public Properties, including null-to-default assignment.
        /// <summary> Gets or sets the transport protocol. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.Protocol"/> instead. </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.protocol")]
        public LoadBalancingTransportProtocol? Protocol
        {
            get => Properties?.Protocol;
            set
            {
                Properties ??= new LoadBalancingRuleProperties(default, default);
                Properties.Protocol = value ?? default;
            }
        }

        // Preserve the hidden 1.15.0 load-distribution facade while keeping public Properties as the canonical storage.
        /// <summary> Gets or sets the load distribution policy. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.LoadDistribution"/> instead. </remarks>
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

        // Preserve the 1.15.0 nullable facade over the required frontend port, including null-to-default assignment.
        /// <summary> Gets or sets the frontend port. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.FrontendPort"/> instead. </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.frontendPort")]
        public int? FrontendPort
        {
            get => Properties?.FrontendPort;
            set
            {
                Properties ??= new LoadBalancingRuleProperties(default, default);
                Properties.FrontendPort = value ?? default;
            }
        }

        // Preserve the hidden 1.15.0 backend-port facade alongside public Properties.
        /// <summary> Gets or sets the backend port. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.BackendPort"/> instead. </remarks>
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

        // Preserve the hidden 1.15.0 idle-timeout facade alongside public Properties.
        /// <summary> Gets or sets the idle timeout in minutes. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.IdleTimeoutInMinutes"/> instead. </remarks>
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

        // Preserve the hidden 1.15.0 floating-IP facade alongside public Properties.
        /// <summary> Gets or sets whether floating IP is enabled. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.EnableFloatingIP"/> instead. </remarks>
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

        // Preserve the hidden 1.15.0 TCP-reset facade alongside public Properties.
        /// <summary> Gets or sets whether TCP reset is enabled. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.EnableTcpReset"/> instead. </remarks>
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

        // Preserve the hidden 1.15.0 outbound-SNAT facade alongside public Properties.
        /// <summary> Gets or sets whether outbound SNAT is disabled. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.DisableOutboundSnat"/> instead. </remarks>
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

        // Preserve the hidden 1.15.0 provisioning-state facade over the native read-only value.
        /// <summary> Gets the provisioning state. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.ProvisioningState"/> instead. </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.provisioningState")]
        public NetworkProvisioningState? ProvisioningState => Properties?.ProvisioningState;

        // Preserve the hidden 1.15.0 frontend-ID facade without copying the public Properties object.
        /// <summary> Gets or sets the frontend IP configuration resource ID. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.FrontendIPConfigurationId"/> instead. </remarks>
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

        // Preserve the hidden 1.15.0 backend-pool-ID facade without copying the public Properties object.
        /// <summary> Gets or sets the backend address pool resource ID. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.BackendAddressPoolId"/> instead. </remarks>
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

        // Preserve the hidden 1.15.0 probe-ID facade without copying the public Properties object.
        /// <summary> Gets or sets the probe resource ID. </summary>
        /// <remarks> Use <see cref="Properties"/>.<see cref="LoadBalancingRuleProperties.ProbeId"/> instead. </remarks>
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
    }
}
