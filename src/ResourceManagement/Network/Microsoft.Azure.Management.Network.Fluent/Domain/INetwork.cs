// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Network.Update;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point for Virtual Network management API in Azure.
    /// </summary>
    public interface INetwork :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetwork>,
        IWrapper<Models.VirtualNetworkInner>,
        IUpdatable<Network.Update.IUpdate>
    {
        System.Collections.Generic.IList<string> AddressSpaces { get; }

        System.Collections.Generic.IList<string> DnsServerIps { get; }

        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ISubnet> Subnets { get; }
    }
}