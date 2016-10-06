// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    /// <summary>
    /// An immutable client-side representation of a load balancing probe.
    /// </summary>
    public interface IProbe  :
        IWrapper<Microsoft.Azure.Management.Network.Fluent.Models.ProbeInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        IHasLoadBalancingRules,
        IHasProtocol<string>
    {
        /// <returns>the port number the probe is monitoring</returns>
        int Port { get; }

        /// <returns>number of seconds between probes</returns>
        int IntervalInSeconds { get; }

        /// <returns>number of failed probes before the node is determined to be unhealthy</returns>
        int NumberOfProbes { get; }

    }
}