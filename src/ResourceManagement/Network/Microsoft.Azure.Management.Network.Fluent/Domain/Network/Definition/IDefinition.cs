// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.Network.Definition
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Subnet.Definition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of the public IP definition which contains all the minimum required inputs for
    /// the resource to be created (via WithCreate.create()), but also allows
    /// for any other optional settings to be specified, including adding subnets.
    /// </summary>
    public interface IWithCreateAndSubnet  :
        IWithCreate,
        IWithSubnet
    {
    }

    /// <summary>
    /// The first stage of a virtual network definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.Network.Fluent.Network.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of the virtual network definition allowing to add subnets.
    /// </summary>
    public interface IWithSubnet 
    {
        /// <summary>
        /// Begins the definition of a new subnet to add to the virtual network.
        /// The definition must be completed with a call to Subnet.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the subnet.</param>
        /// <return>The first stage of the new subnet definition.</return>
        Microsoft.Azure.Management.Network.Fluent.Subnet.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.Network.Definition.IWithCreateAndSubnet> DefineSubnet(string name);

        /// <summary>
        /// Explicitly adds a subnet to the virtual network.
        /// If no subnets are explicitly specified, a default subnet called "subnet1" covering the
        /// entire first address space will be created.
        /// Note this method's effect is additive, i.e. each time it is used, a new subnet is added to the network.
        /// </summary>
        /// <param name="name">The name to assign to the subnet.</param>
        /// <param name="cidr">The address space of the subnet, within the address space of the network, using the CIDR notation.</param>
        /// <return>The next stage of the virtual network definition.</return>
        Microsoft.Azure.Management.Network.Fluent.Network.Definition.IWithCreateAndSubnet WithSubnet(string name, string cidr);

        /// <summary>
        /// Explicitly defines subnets in the virtual network based on the provided map.
        /// </summary>
        /// <param name="nameCidrPairs">A Map of CIDR addresses for the subnets, indexed by the name of each subnet to be defined.</param>
        /// <return>The next stage of the virtual network definition.</return>
        Microsoft.Azure.Management.Network.Fluent.Network.Definition.IWithCreateAndSubnet WithSubnets(IDictionary<string,string> nameCidrPairs);
    }

    /// <summary>
    /// The entirety of the virtual network definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Network.Fluent.Network.Definition.IBlank,
        Microsoft.Azure.Management.Network.Fluent.Network.Definition.IWithGroup,
        IWithSubnet,
        IWithCreate,
        IWithCreateAndSubnet
    {
    }

    /// <summary>
    /// The stage of the virtual network definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Network.Fluent.Network.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of the virtual network definition which contains all the minimum required inputs for
    /// the resource to be created (via WithCreate.create()), but also allows
    /// for any other optional settings to be specified, except for adding subnets.
    /// Subnets can be added only right after the address space is explicitly specified
    /// (see WithCreate.create()).
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork>,
        IDefinitionWithTags<Microsoft.Azure.Management.Network.Fluent.Network.Definition.IWithCreate>
    {
        /// <summary>
        /// Specifies the IP address of an existing DNS server to associate with the virtual network.
        /// Note this method's effect is additive, i.e. each time it is used, a new dns server is added
        /// to the network.
        /// </summary>
        /// <param name="ipAddress">The IP address of the DNS server.</param>
        /// <return>The next stage of the virtual network definition.</return>
        Microsoft.Azure.Management.Network.Fluent.Network.Definition.IWithCreate WithDnsServer(string ipAddress);

        /// <summary>
        /// Explicitly adds an address space to the virtual network.
        /// If no address spaces are explicitly specified, a default address space with the CIDR "10.0.0.0/16" will be
        /// assigned to the virtual network.
        /// Note that this method's effect is additive, i.e. each time it is used, a new address space is added to the network.
        /// This method does not check for conflicts or overlaps with other address spaces. If there is a conflict,
        /// a cloud exception may be thrown at the time the network is created.
        /// </summary>
        /// <param name="cidr">The CIDR representation of the address space.</param>
        /// <return>The next stage of the virtual network definition.</return>
        Microsoft.Azure.Management.Network.Fluent.Network.Definition.IWithCreateAndSubnet WithAddressSpace(string cidr);
    }
}