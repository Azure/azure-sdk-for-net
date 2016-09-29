// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    /// <summary>
    /// An immutable client-side representation of a load balancing probe.
    /// </summary>
    public interface IProbe  :
        IWrapper<Microsoft.Azure.Management.Network.Models.ProbeInner>,
        IChildResource<Microsoft.Azure.Management.Fluent.Network.ILoadBalancer>,
        IHasLoadBalancingRules,
        IHasProtocol<string>
    {
        /// <returns>the port number the probe is monitoring</returns>
        int? Port { get; }

        /// <returns>number of seconds between probes</returns>
        int? IntervalInSeconds { get; }

        /// <returns>number of failed probes before the node is determined to be unhealthy</returns>
        int? NumberOfProbes { get; }

    }
}