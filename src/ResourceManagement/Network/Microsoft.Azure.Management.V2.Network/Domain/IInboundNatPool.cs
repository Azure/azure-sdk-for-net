// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Network.Models;
    /// <summary>
    /// An immutable client-side representation of an inbound NAT rule.
    /// </summary>
    public interface IInboundNatPool  :
        IHasFrontend,
        IHasBackendPort,
        IHasProtocol<string>,
        IWrapper<Microsoft.Azure.Management.Network.Models.InboundNatPoolInner>,
        IChildResource<Microsoft.Azure.Management.Fluent.Network.ILoadBalancer>
    {
        /// <returns>the starting frontend port number</returns>
        int? FrontendPortRangeStart { get; }

        /// <returns>the ending frontend port number</returns>
        int? FrontendPortRangeEnd { get; }

    }
}