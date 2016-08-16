/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update;
    using Microsoft.Azure.Management.Network.Models;
    /// <summary>
    /// Public IP address.
    /// </summary>
    public interface IPublicIpAddress  :
        IGroupableResource,
        IRefreshable<IPublicIpAddress>,
        IWrapper<PublicIPAddressInner>,
        IUpdatable<IUpdate>
    {
        /// <returns>the assigned IP address</returns>
        string IpAddress { get; }

        /// <returns>the assigned leaf domain label</returns>
        string LeafDomainLabel { get; }

        /// <returns>the assigned FQDN (fully qualified domain name)</returns>
        string Fqdn { get; }

        /// <returns>the assigned reverse FQDN, if any</returns>
        string ReverseFqdn { get; }

        /// <returns>the IP address allocation method (Static/Dynamic)</returns>
        string IpAllocationMethod { get; }

        /// <returns>the idle connection timeout setting (in minutes)</returns>
        int? IdleTimeoutInMinutes { get; }

    }
}