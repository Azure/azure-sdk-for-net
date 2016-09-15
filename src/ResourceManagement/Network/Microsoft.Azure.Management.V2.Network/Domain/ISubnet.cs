/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    /// <summary>
    /// An immutable client-side representation of a subnet of a virtual network.
    /// </summary>
    public interface ISubnet  :
        IWrapper<Microsoft.Azure.Management.Network.Models.SubnetInner>,
        IChildResource
    {
        /// <returns>the address space prefix, in CIDR notation, assigned to this subnet</returns>
        string AddressPrefix { get; }

        /// <returns>the network security group associated with this subnet</returns>
        /// <returns><p></returns>
        /// <returns>Note that this method will result in a call to Azure each time it is invoked.</returns>
        INetworkSecurityGroup NetworkSecurityGroup ();

    }
}