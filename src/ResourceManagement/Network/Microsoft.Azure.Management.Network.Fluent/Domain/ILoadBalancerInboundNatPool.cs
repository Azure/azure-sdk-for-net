// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an inbound NAT rule.
    /// </summary>
    public interface ILoadBalancerInboundNatPool  :
        IHasFrontend,
        IHasBackendPort,
        IHasProtocol<string>,
        IWrapper<Models.InboundNatPoolInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>
    {
        /// <summary>
        /// Gets the starting frontend port number.
        /// </summary>
        int FrontendPortRangeStart { get; }

        /// <summary>
        /// Gets the ending frontend port number.
        /// </summary>
        int FrontendPortRangeEnd { get; }
    }
}