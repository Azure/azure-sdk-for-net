/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Network.Network.Update;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Rest;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Network.Network.Definition;
    using System.Threading;
    using Microsoft.Azure.Management.V2.Resource;
    public partial class NetworkImpl 
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
        Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate Microsoft.Azure.Management.V2.Network.Network.Update.IWithAddressSpace.WithAddressSpace (string cidr) {
            return this.WithAddressSpace( cidr) as Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <returns>the refreshed resource</returns>
        Microsoft.Azure.Management.V2.Network.INetwork Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.V2.Network.INetwork>.Refresh () {
            return this.Refresh() as Microsoft.Azure.Management.V2.Network.INetwork;
        }

        /// <summary>
        /// Execute the update request asynchronously.
        /// </summary>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <returns>the handle to the REST call</returns>
        async Task<Microsoft.Azure.Management.V2.Network.INetwork> Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.V2.Network.INetwork>.ApplyAsync (CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true) {
            return await this.ApplyAsync() as INetwork;
        }

        /// <summary>
        /// Execute the update request.
        /// </summary>
        /// <returns>the updated resource</returns>
        Microsoft.Azure.Management.V2.Network.INetwork Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.V2.Network.INetwork>.Apply () {
            return this.Apply() as Microsoft.Azure.Management.V2.Network.INetwork;
        }

        /// <summary>
        /// Begins the description of an update of an existing subnet of this network.
        /// </summary>
        /// <param name="name">name the name of an existing subnet</param>
        /// <returns>the first stage of the subnet update description</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate Microsoft.Azure.Management.V2.Network.Network.Update.IWithSubnet.UpdateSubnet (string name) {
            return this.UpdateSubnet( name) as Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new subnet to be added to this virtual network.
        /// </summary>
        /// <param name="name">name the name of the new subnet</param>
        /// <returns>the first stage of the new subnet definition</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IBlank<Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate> Microsoft.Azure.Management.V2.Network.Network.Update.IWithSubnet.DefineSubnet (string name) {
            return this.DefineSubnet( name) as Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IBlank<Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate>;
        }

        /// <summary>
        /// Explicitly adds a subnet to the virtual network.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, a new subnet is added to the network.
        /// </summary>
        /// <param name="name">name the name to assign to the subnet</param>
        /// <param name="cidr">cidr the address space of the subnet, within the address space of the network, using the CIDR notation</param>
        /// <returns>the next stage of the virtual network update</returns>
        Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate Microsoft.Azure.Management.V2.Network.Network.Update.IWithSubnet.WithSubnet (string name, string cidr) {
            return this.WithSubnet( name,  cidr) as Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate;
        }

        /// <summary>
        /// Explicitly defines all the subnets in the virtual network based on the provided map.
        /// <p>
        /// This replaces any previously existing subnets.
        /// </summary>
        /// <param name="nameCidrPairs">nameCidrPairs a {@link Map} of CIDR addresses for the subnets, indexed by the name of each subnet to be added</param>
        /// <returns>the next stage of the virtual network update</returns>
        Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate Microsoft.Azure.Management.V2.Network.Network.Update.IWithSubnet.WithSubnets (IDictionary<string,string> nameCidrPairs) {
            return this.WithSubnets( nameCidrPairs) as Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate;
        }

        /// <summary>
        /// Removes a subnet from the virtual network.
        /// </summary>
        /// <param name="name">name name of the subnet to remove</param>
        /// <returns>the next stage of the virtual network update</returns>
        Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate Microsoft.Azure.Management.V2.Network.Network.Update.IWithSubnet.WithoutSubnet (string name) {
            return this.WithoutSubnet( name) as Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new subnet to add to the virtual network.
        /// <p>
        /// The definition must be completed with a call to {@link Subnet.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name of the subnet</param>
        /// <returns>the first stage of the new subnet definition</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Definition.IBlank<Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet> Microsoft.Azure.Management.V2.Network.Network.Definition.IWithSubnet.DefineSubnet (string name) {
            return this.DefineSubnet( name) as Microsoft.Azure.Management.V2.Network.Subnet.Definition.IBlank<Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet>;
        }

        /// <summary>
        /// Explicitly adds a subnet to the virtual network.
        /// <p>
        /// If no subnets are explicitly specified, a default subnet called "subnet1" covering the
        /// entire first address space will be created.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, a new subnet is added to the network.
        /// </summary>
        /// <param name="name">name the name to assign to the subnet</param>
        /// <param name="cidr">cidr the address space of the subnet, within the address space of the network, using the CIDR notation</param>
        /// <returns>the next stage of the virtual network definition</returns>
        Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet Microsoft.Azure.Management.V2.Network.Network.Definition.IWithSubnet.WithSubnet (string name, string cidr) {
            return this.WithSubnet( name,  cidr) as Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet;
        }

        /// <summary>
        /// Explicitly defines subnets in the virtual network based on the provided map.
        /// </summary>
        /// <param name="nameCidrPairs">nameCidrPairs a {@link Map} of CIDR addresses for the subnets, indexed by the name of each subnet to be defined</param>
        /// <returns>the next stage of the virtual network definition</returns>
        Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet Microsoft.Azure.Management.V2.Network.Network.Definition.IWithSubnet.WithSubnets (IDictionary<string,string> nameCidrPairs) {
            return this.WithSubnets( nameCidrPairs) as Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet;
        }

        /// <summary>
        /// Specifies the IP address of the DNS server to associate with the virtual network.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, a new DNS server is
        /// added to the network
        /// </summary>
        /// <param name="ipAddress">ipAddress the IP address of the DNS server</param>
        /// <returns>the next stage of the virtual network update</returns>
        Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate Microsoft.Azure.Management.V2.Network.Network.Update.IWithDnsServer.WithDnsServer (string ipAddress) {
            return this.WithDnsServer( ipAddress) as Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate;
        }

        /// <returns>list of DNS server IP addresses associated with this virtual network</returns>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.V2.Network.INetwork.DnsServerIPs
        {
            get
            {
                return this.DnsServerIPs as System.Collections.Generic.IList<string>;
            }
        }
        /// <returns>subnets of this virtual network as a map indexed by subnet name</returns>
        /// <returns><p>Note that when a virtual network is created with no subnets explicitly defined, a default subnet is</returns>
        /// <returns>automatically created with the name "subnet1".</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.V2.Network.ISubnet> Microsoft.Azure.Management.V2.Network.INetwork.Subnets () {
            return this.Subnets() as System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.V2.Network.ISubnet>;
        }

        /// <returns>list of address spaces associated with this virtual network, in the CIDR notation</returns>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.V2.Network.INetwork.AddressSpaces
        {
            get
            {
                return this.AddressSpaces as System.Collections.Generic.IList<string>;
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
        /// <param name="cidr">cidr the CIDR representation of the address space</param>
        /// <returns>the next stage of the virtual network definition</returns>
        Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreate.WithAddressSpace (string cidr) {
            return this.WithAddressSpace( cidr) as Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet;
        }

        /// <summary>
        /// Specifies the IP address of an existing DNS server to associate with the virtual network.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, a new dns server is added
        /// to the network.
        /// </summary>
        /// <param name="ipAddress">ipAddress the IP address of the DNS server</param>
        /// <returns>the next stage of the virtual network definition</returns>
        Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreate.WithDnsServer (string ipAddress) {
            return this.WithDnsServer( ipAddress) as Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreate;
        }

    }
}