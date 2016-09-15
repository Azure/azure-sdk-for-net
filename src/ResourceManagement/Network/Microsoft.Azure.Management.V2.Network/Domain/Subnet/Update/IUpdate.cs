/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network.Subnet.Update
{

    using Microsoft.Azure.Management.V2.Network;
    using Microsoft.Azure.Management.V2.Network.Network.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResourceActions;
    /// <summary>
    /// The stage of the subnet update allowing to change the network security group to assign to the subnet.
    /// </summary>
    public interface IWithNetworkSecurityGroup 
    {
        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="resourceId">resourceId the resource ID of the network security group</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate WithExistingNetworkSecurityGroup (string resourceId);

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="nsg">nsg the network security group to assign</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate WithExistingNetworkSecurityGroup (INetworkSecurityGroup nsg);

    }
    /// <summary>
    /// The entirety of a subnet update as part of a network update.
    /// </summary>
    public interface IUpdate  :
        IWithAddressPrefix,
        IWithNetworkSecurityGroup,
        ISettable<Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate>
    {
    }
    /// <summary>
    /// The stage of the subnet update allowing to change the address space for the subnet.
    /// </summary>
    public interface IWithAddressPrefix 
    {
        /// <summary>
        /// Specifies the IP address space of the subnet, within the address space of the network.
        /// </summary>
        /// <param name="cidr">cidr the IP address space prefix using the CIDR notation</param>
        /// <returns>the next stage</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate WithAddressPrefix (string cidr);

    }
}