// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading.Tasks;
    using Network.Definition;
    using Network.Update;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class NetworkImpl
    {
        /// <summary>
        /// Explicitly adds an address space to the virtual network.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, a new address space is added to the network.
        /// <p>
        /// This method does not check for conflicts or overlaps with other address spaces. If there is a conflict,
        /// a cloud exception may be thrown after the update is applied.
        /// </summary>
        /// <param name="cidr">The CIDR representation of the address space.</param>
        Network.Update.IUpdate Network.Update.IWithAddressSpace.WithAddressSpace(string cidr)
        {
            return this.WithAddressSpace(cidr) as Network.Update.IUpdate;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INetwork Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetwork>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Network.Fluent.INetwork;
        }

        /// <summary>
        /// Explicitly adds a subnet to the virtual network.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, a new subnet is added to the network.
        /// </summary>
        /// <param name="name">The name to assign to the subnet.</param>
        /// <param name="cidr">The address space of the subnet, within the address space of the network, using the CIDR notation.</param>
        Network.Update.IUpdate Network.Update.IWithSubnet.WithSubnet(string name, string cidr)
        {
            return this.WithSubnet(name, cidr) as Network.Update.IUpdate;
        }

        /// <summary>
        /// Removes a subnet from the virtual network.
        /// </summary>
        /// <param name="name">Name of the subnet to remove.</param>
        Network.Update.IUpdate Network.Update.IWithSubnet.WithoutSubnet(string name)
        {
            return this.WithoutSubnet(name) as Network.Update.IUpdate;
        }

        /// <summary>
        /// Begins the description of an update of an existing subnet of this network.
        /// </summary>
        /// <param name="name">The name of an existing subnet.</param>
        Subnet.Update.IUpdate Network.Update.IWithSubnet.UpdateSubnet(string name)
        {
            return this.UpdateSubnet(name) as Subnet.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new subnet to be added to this virtual network.
        /// </summary>
        /// <param name="name">The name of the new subnet.</param>
        Subnet.UpdateDefinition.IBlank<Network.Update.IUpdate> Network.Update.IWithSubnet.DefineSubnet(string name)
        {
            return this.DefineSubnet(name) as Subnet.UpdateDefinition.IBlank<Network.Update.IUpdate>;
        }

        /// <summary>
        /// Explicitly defines all the subnets in the virtual network based on the provided map.
        /// <p>
        /// This replaces any previously existing subnets.
        /// </summary>
        /// <param name="nameCidrPairs">A Map of CIDR addresses for the subnets, indexed by the name of each subnet to be added.</param>
        Network.Update.IUpdate Network.Update.IWithSubnet.WithSubnets(IDictionary<string, string> nameCidrPairs)
        {
            return this.WithSubnets(nameCidrPairs) as Network.Update.IUpdate;
        }

        /// <summary>
        /// Explicitly adds a subnet to the virtual network.
        /// <p>
        /// If no subnets are explicitly specified, a default subnet called "subnet1" covering the
        /// entire first address space will be created.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, a new subnet is added to the network.
        /// </summary>
        /// <param name="name">The name to assign to the subnet.</param>
        /// <param name="cidr">The address space of the subnet, within the address space of the network, using the CIDR notation.</param>
        Network.Definition.IWithCreateAndSubnet Network.Definition.IWithSubnet.WithSubnet(string name, string cidr)
        {
            return this.WithSubnet(name, cidr) as Network.Definition.IWithCreateAndSubnet;
        }

        /// <summary>
        /// Begins the definition of a new subnet to add to the virtual network.
        /// <p>
        /// The definition must be completed with a call to Subnet.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the subnet.</param>
        Subnet.Definition.IBlank<Network.Definition.IWithCreateAndSubnet> Network.Definition.IWithSubnet.DefineSubnet(string name)
        {
            return this.DefineSubnet(name) as Subnet.Definition.IBlank<Network.Definition.IWithCreateAndSubnet>;
        }

        /// <summary>
        /// Explicitly defines subnets in the virtual network based on the provided map.
        /// </summary>
        /// <param name="nameCidrPairs">A Map of CIDR addresses for the subnets, indexed by the name of each subnet to be defined.</param>
        Network.Definition.IWithCreateAndSubnet Network.Definition.IWithSubnet.WithSubnets(IDictionary<string, string> nameCidrPairs)
        {
            return this.WithSubnets(nameCidrPairs) as Network.Definition.IWithCreateAndSubnet;
        }

        /// <summary>
        /// Specifies the IP address of the DNS server to associate with the virtual network.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, a new DNS server is
        /// added to the network.
        /// </summary>
        /// <param name="ipAddress">The IP address of the DNS server.</param>
        Network.Update.IUpdate Network.Update.IWithDnsServer.WithDnsServer(string ipAddress)
        {
            return this.WithDnsServer(ipAddress) as Network.Update.IUpdate;
        }

        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Network.Fluent.INetwork.DnsServerIps
        {
            get
            {
                return this.DnsServerIps() as System.Collections.Generic.IList<string>;
            }
        }

        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Network.Fluent.INetwork.AddressSpaces
        {
            get
            {
                return this.AddressSpaces() as System.Collections.Generic.IList<string>;
            }
        }

        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ISubnet> Microsoft.Azure.Management.Network.Fluent.INetwork.Subnets
        {
            get
            {
                return this.Subnets() as System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ISubnet>;
            }
        }

        /// <summary>
        /// Explicitly adds an address space to the virtual network.
        /// <p>
        /// If no address spaces are explicitly specified, a default address space with the CIDR "10.0.0.0/16" will be
        /// assigned to the virtual network.
        /// <p>
        /// Note that this method's effect is additive, i.e. each time it is used, a new address space is added to the network.
        /// This method does not check for conflicts or overlaps with other address spaces. If there is a conflict,
        /// a cloud exception may be thrown at the time the network is created.
        /// </summary>
        /// <param name="cidr">The CIDR representation of the address space.</param>
        Network.Definition.IWithCreateAndSubnet Network.Definition.IWithCreate.WithAddressSpace(string cidr)
        {
            return this.WithAddressSpace(cidr) as Network.Definition.IWithCreateAndSubnet;
        }

        /// <summary>
        /// Specifies the IP address of an existing DNS server to associate with the virtual network.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, a new dns server is added
        /// to the network.
        /// </summary>
        /// <param name="ipAddress">The IP address of the DNS server.</param>
        Network.Definition.IWithCreate Network.Definition.IWithCreate.WithDnsServer(string ipAddress)
        {
            return this.WithDnsServer(ipAddress) as Network.Definition.IWithCreate;
        }
    }
}