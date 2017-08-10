// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// A client-side representation of an HTTP load balancing rule.
    /// </summary>
    public interface ILoadBalancingRule  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.LoadBalancingRuleInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        Microsoft.Azure.Management.Network.Fluent.IHasBackendPort,
        Microsoft.Azure.Management.Network.Fluent.IHasFrontend,
        Microsoft.Azure.Management.Network.Fluent.IHasFloatingIP,
        Microsoft.Azure.Management.Network.Fluent.IHasProtocol<Models.TransportProtocol>,
        Microsoft.Azure.Management.Network.Fluent.IHasFrontendPort
    {
        /// <summary>
        /// Gets the method of load distribution.
        /// </summary>
        Models.LoadDistribution LoadDistribution { get; }

        /// <summary>
        /// Gets the number of minutes before an inactive connection is closed.
        /// </summary>
        int IdleTimeoutInMinutes { get; }

        /// <summary>
        /// Gets the backend associated with the load balancing rule.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend Backend { get; }

        /// <summary>
        /// Gets the probe associated with the load balancing rule.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerProbe Probe { get; }
    }
}