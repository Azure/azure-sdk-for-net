// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    /// <summary>
    /// An immutable client-side representation of an HTTP load balancing rule.
    /// </summary>
    public interface ILoadBalancingRule  :
        IWrapper<Microsoft.Azure.Management.Network.Fluent.Models.LoadBalancingRuleInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        IHasBackendPort,
        IHasFrontend,
        IHasFloatingIp,
        IHasProtocol<string>
    {
        /// <returns>the method of load distribution</returns>
        string LoadDistribution { get; }

        /// <returns>the number of minutes before an inactive connection is closed</returns>
        int IdleTimeoutInMinutes { get; }

        /// <returns>the load balanced front end port</returns>
        int FrontendPort { get; }

        /// <returns>the backend associated with the load balancing rule</returns>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend Backend { get; }

        /// <returns>the probe associated with the load balancing rule</returns>
        Microsoft.Azure.Management.Network.Fluent.IProbe Probe { get; }

    }
}