// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    /// <summary>
    /// An immutable client-side representation of an inbound NAT rule.
    /// </summary>
    public interface ILoadBalancerInboundNatPool  :
        IHasFrontend,
        IHasBackendPort,
        IHasProtocol<string>,
        IWrapper<Microsoft.Azure.Management.Network.Fluent.Models.InboundNatPoolInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>
    {
        /// <returns>the starting frontend port number</returns>
        int FrontendPortRangeStart { get; }

        /// <returns>the ending frontend port number</returns>
        int FrontendPortRangeEnd { get; }

    }
}