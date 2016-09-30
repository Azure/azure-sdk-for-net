// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Network.Models;
    /// <summary>
    /// An immutable client-side representation of an inbound NAT rule.
    /// </summary>
    public interface IInboundNatRule  :
        IHasFrontend,
        IHasBackendPort,
        IHasProtocol<string>,
        IHasFloatingIp,
        IWrapper<Microsoft.Azure.Management.Network.Models.InboundNatRuleInner>,
        IChildResource<Microsoft.Azure.Management.Fluent.Network.ILoadBalancer>
    {
        /// <returns>the name of the IP configuration within the network interface associated with this NAT rule</returns>
        string BackendNicIpConfigurationName { get; }

        /// <returns>the resource ID of the network interface assigned as the backend of this inbound NAT rule</returns>
        string BackendNetworkInterfaceId { get; }

        /// <returns>the frontend port number associated with this NAT rule</returns>
        int? FrontendPort { get; }

        /// <returns>the number of minutes before an idle connection is closed</returns>
        int? IdleTimeoutInMinutes { get; }

    }
}