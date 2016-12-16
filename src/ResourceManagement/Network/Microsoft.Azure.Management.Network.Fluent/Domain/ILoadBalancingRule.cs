// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an HTTP load balancing rule.
    /// </summary>
    public interface ILoadBalancingRule  :
        IWrapper<Models.LoadBalancingRuleInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        IHasBackendPort,
        IHasFrontend,
        IHasFloatingIp,
        IHasProtocol<string>,
        IHasFrontendPort
    {
        /// <summary>
        /// Gets the method of load distribution.
        /// </summary>
        string LoadDistribution { get; }

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