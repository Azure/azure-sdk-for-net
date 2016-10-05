// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    /// <summary>
    /// An immutable client-side representation of a subnet of a virtual network.
    /// </summary>
    public interface ISubnet  :
        IWrapper<Microsoft.Azure.Management.Network.Fluent.Models.SubnetInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.INetwork>
    {
        /// <returns>the address space prefix, in CIDR notation, assigned to this subnet</returns>
        string AddressPrefix { get; }

        /// <returns>the network security group associated with this subnet</returns>
        /// <returns><p></returns>
        /// <returns>Note that this method will result in a call to Azure each time it is invoked.</returns>
        Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup GetNetworkSecurityGroup();

    }
}