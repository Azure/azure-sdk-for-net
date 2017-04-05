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
    public interface ILoadBalancerInboundNatRule  :
        IHasFrontend,
        IHasBackendPort,
        IHasProtocol<string>,
        IHasFloatingIP,
        IHasFrontendPort,
        IHasInner<Models.InboundNatRuleInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>
    {
        /// <summary>
        /// Gets the number of minutes before an idle connection is closed.
        /// </summary>
        int IdleTimeoutInMinutes { get; }

        /// <summary>
        /// Gets the resource ID of the network interface assigned as the backend of this inbound NAT rule.
        /// </summary>
        string BackendNetworkInterfaceId { get; }

        /// <summary>
        /// Gets the name of the IP configuration within the network interface associated with this NAT rule.
        /// </summary>
        string BackendNicIPConfigurationName { get; }
    }
}