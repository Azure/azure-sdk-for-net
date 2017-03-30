// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of a load balancing probe.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in future releases, including removal, regardless of any compatibility expectations set by the containing library version number.)
    /// </remarks>
    public interface ILoadBalancerProbe  :
        IHasInner<Models.ProbeInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        IHasLoadBalancingRules,
        IHasProtocol<ProbeProtocol>,
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