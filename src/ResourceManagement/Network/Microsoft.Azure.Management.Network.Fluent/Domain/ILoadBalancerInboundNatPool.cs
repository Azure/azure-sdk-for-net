// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an inbound NAT rule.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface ILoadBalancerInboundNatPool  :
        IHasFrontend,
        IHasBackendPort,
        IHasProtocol<string>,
        IHasInner<Models.InboundNatPoolInner>,
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