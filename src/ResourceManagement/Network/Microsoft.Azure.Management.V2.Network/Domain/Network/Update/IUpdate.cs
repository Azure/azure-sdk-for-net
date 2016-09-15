/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network.Network.Update
{

    using Microsoft.Azure.Management.V2.Network.Subnet.Update;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network;
    using Microsoft.Azure.Management.V2.Resource.Core.Resource.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    /// <summary>
    /// The stage of the virtual network update allowing to specify the DNS server.
    /// </summary>
    public interface IWithDnsServer 
    {
        /// <summary>
        /// Specifies the IP address of the DNS server to associate with the virtual network.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, a new DNS server is
        /// added to the network
        /// </summary>
        /// <param name="ipAddress">ipAddress the IP address of the DNS server</param>
        /// <returns>the next stage of the virtual network update</returns>
        Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate WithDnsServer (string ipAddress);

    }
    /// <summary>
    /// The stage of the virtual network update allowing to add or remove subnets.
    /// </summary>
    public interface IWithSubnet 
    {
        /// <summary>
        /// Explicitly adds a subnet to the virtual network.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, a new subnet is added to the network.
        /// </summary>
        /// <param name="name">name the name to assign to the subnet</param>
        /// <param name="cidr">cidr the address space of the subnet, within the address space of the network, using the CIDR notation</param>
        /// <returns>the next stage of the virtual network update</returns>
        Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate WithSubnet (string name, string cidr);

        /// <summary>
        /// Explicitly defines all the subnets in the virtual network based on the provided map.
        /// <p>
        /// This replaces any previously existing subnets.
        /// </summary>
        /// <param name="nameCidrPairs">nameCidrPairs a {@link Map} of CIDR addresses for the subnets, indexed by the name of each subnet to be added</param>
        /// <returns>the next stage of the virtual network update</returns>
        Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate WithSubnets (IDictionary<string,string> nameCidrPairs);

        /// <summary>
        /// Removes a subnet from the virtual network.
        /// </summary>
        /// <param name="name">name name of the subnet to remove</param>
        /// <returns>the next stage of the virtual network update</returns>
        Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate WithoutSubnet (string name);

        /// <summary>
        /// Begins the description of an update of an existing subnet of this network.
        /// </summary>
        /// <param name="name">name the name of an existing subnet</param>
        /// <returns>the first stage of the subnet update description</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate UpdateSubnet (string name);

        /// <summary>
        /// Begins the definition of a new subnet to be added to this virtual network.
        /// </summary>
        /// <param name="name">name the name of the new subnet</param>
        /// <returns>the first stage of the new subnet definition</returns>
        IBlank<Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate> DefineSubnet (string name);

    }
    /// <summary>
    /// The stage of the virtual network update allowing to specify the address space.
    /// </summary>
    public interface IWithAddressSpace 
    {
        /// <summary>
        /// Explicitly adds an address space to the virtual network.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, a new address space is added to the network.
        /// <p>
        /// This method does not check for conflicts or overlaps with other address spaces. If there is a conflict,
        /// a cloud exception may be thrown after the update is applied.
        /// </summary>
        /// <param name="cidr">cidr the CIDR representation of the address space</param>
        /// <returns>the next stage of the virtual network update</returns>
        Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate WithAddressSpace (string cidr);

    }
    /// <summary>
    /// The template for a virtual network update operation, containing all the settings that
    /// can be modified.
    /// <p>
    /// Call {@link Update#apply()} to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.V2.Network.INetwork>,
        IUpdateWithTags<Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate>,
        IWithSubnet,
        IWithDnsServer,
        IWithAddressSpace
    {
    }
}