// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an HTTP load balancing rule.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface ILoadBalancingRule  :
        IHasInner<Models.LoadBalancingRuleInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        IHasBackendPort,
        IHasFrontend,
        IHasFloatingIP,
        IHasProtocol<Models.TransportProtocol>,
        IHasFrontendPort
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