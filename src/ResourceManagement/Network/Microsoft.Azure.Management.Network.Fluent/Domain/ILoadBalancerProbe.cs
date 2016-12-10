// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of a load balancing probe.
    /// </summary>
    public interface ILoadBalancerProbe  :
        IWrapper<Models.ProbeInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        IHasLoadBalancingRules,
        IHasProtocol<string>,
        IHasPort
    {
        /// <summary>
        /// Gets number of seconds between probes.
        /// </summary>
        int IntervalInSeconds { get; }

        /// <summary>
        /// Gets number of failed probes before the node is determined to be unhealthy.
        /// </summary>
        int NumberOfProbes { get; }
    }
}