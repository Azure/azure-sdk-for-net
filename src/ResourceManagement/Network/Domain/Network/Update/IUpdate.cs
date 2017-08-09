// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.Network.Update
{
    using Microsoft.Azure.Management.Network.Fluent.Subnet.Update;
    using Microsoft.Azure.Management.Network.Fluent.Subnet.UpdateDefinition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of the virtual network update allowing to add or remove subnets.
    /// </summary>
    public interface IWithSubnet 
    {
        /// <summary>
        /// Removes a subnet from the virtual network.
        /// </summary>
        /// <param name="name">Name of the subnet to remove.</param>
        /// <return>The next stage of the virtual network update.</return>
        Microsoft.Azure.Management.Network.Fluent.Network.Update.IUpdate WithoutSubnet(string name);

        /// <summary>
        /// Begins the definition of a new subnet to be added to this virtual network.
        /// </summary>
        /// <param name="name">The name of the new subnet.</param>
        /// <return>The first stage of the new subnet definition.</return>
        Microsoft.Azure.Management.Network.Fluent.Subnet.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.Network.Update.IUpdate> DefineSubnet(string name);

        /// <summary>
        /// Explicitly adds a subnet to the virtual network.
        /// Note this method's effect is additive, i.e. each time it is used, a new subnet is added to the network.
        /// </summary>
        /// <param name="name">The name to assign to the subnet.</param>
        /// <param name="cidr">The address space of the subnet, within the address space of the network, using the CIDR notation.</param>
        /// <return>The next stage of the virtual network update.</return>
        Microsoft.Azure.Management.Network.Fluent.Network.Update.IUpdate WithSubnet(string name, string cidr);

        /// <summary>
        /// Begins the description of an update of an existing subnet of this network.
        /// </summary>
        /// <param name="name">The name of an existing subnet.</param>
        /// <return>The first stage of the subnet update description.</return>
        Microsoft.Azure.Management.Network.Fluent.Subnet.Update.IUpdate UpdateSubnet(string name);

        /// <summary>
        /// Explicitly defines all the subnets in the virtual network based on the provided map.
        /// This replaces any previously existing subnets.
        /// </summary>
        /// <param name="nameCidrPairs">A  Map of CIDR addresses for the subnets, indexed by the name of each subnet to be added.</param>
        /// <return>The next stage of the virtual network update.</return>
        Microsoft.Azure.Management.Network.Fluent.Network.Update.IUpdate WithSubnets(IDictionary<string,string> nameCidrPairs);
    }

    /// <summary>
    /// The stage of the virtual network update allowing to specify the address space.
    /// </summary>
    public interface IWithAddressSpace 
    {
        /// <summary>
        /// Explicitly adds an address space to the virtual network.
        /// Note this method's effect is additive, i.e. each time it is used, a new address space is added to the network.
        /// This method does not check for conflicts or overlaps with other address spaces. If there is a conflict,
        /// a cloud exception may be thrown after the update is applied.
        /// </summary>
        /// <param name="cidr">The CIDR representation of the address space.</param>
        /// <return>The next stage of the virtual network update.</return>
        Microsoft.Azure.Management.Network.Fluent.Network.Update.IUpdate WithAddressSpace(string cidr);
    }

    /// <summary>
    /// The template for a virtual network update operation, containing all the settings that
    /// can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Network.Fluent.INetwork>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Network.Fluent.Network.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.Network.Update.IWithSubnet,
        Microsoft.Azure.Management.Network.Fluent.Network.Update.IWithDnsServer,
        Microsoft.Azure.Management.Network.Fluent.Network.Update.IWithAddressSpace
    {
    }

    /// <summary>
    /// The stage of the virtual network update allowing to specify the DNS server.
    /// </summary>
    public interface IWithDnsServer 
    {
        /// <summary>
        /// Specifies the IP address of the DNS server to associate with the virtual network.
        /// Note this method's effect is additive, i.e. each time it is used, a new DNS server is
        /// added to the network.
        /// </summary>
        /// <param name="ipAddress">The IP address of the DNS server.</param>
        /// <return>The next stage of the virtual network update.</return>
        Microsoft.Azure.Management.Network.Fluent.Network.Update.IUpdate WithDnsServer(string ipAddress);
    }
}