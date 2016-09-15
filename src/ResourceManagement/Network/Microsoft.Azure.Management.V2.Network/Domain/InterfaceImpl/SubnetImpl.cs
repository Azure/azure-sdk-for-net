/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.Network.Update;
    using Microsoft.Azure.Management.V2.Network.Subnet.Update;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Network.Subnet.Definition;
    using Microsoft.Azure.Management.V2.Network.Network.Definition;
    public partial class SubnetImpl 
    {
        Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate>.Attach () {
            return this.Attach() as Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate;
        }

        /// <returns>the name of the child resource</returns>
        string Microsoft.Azure.Management.V2.Resource.Core.IChildResource.Name
        {
            get
            {
                return this.Name as string;
            }
        }
        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="resourceId">resourceId the resource ID of the network security group</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Definition.IWithAttach<Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet> Microsoft.Azure.Management.V2.Network.Subnet.Definition.IWithNetworkSecurityGroup<Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet>.WithExistingNetworkSecurityGroup (string resourceId) {
            return this.WithExistingNetworkSecurityGroup( resourceId) as Microsoft.Azure.Management.V2.Network.Subnet.Definition.IWithAttach<Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet>;
        }

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="nsg">nsg the network security group to assign</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Definition.IWithAttach<Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet> Microsoft.Azure.Management.V2.Network.Subnet.Definition.IWithNetworkSecurityGroup<Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet>.WithExistingNetworkSecurityGroup (INetworkSecurityGroup nsg) {
            return this.WithExistingNetworkSecurityGroup( nsg) as Microsoft.Azure.Management.V2.Network.Subnet.Definition.IWithAttach<Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet>;
        }

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="resourceId">resourceId the resource ID of the network security group</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate> Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IWithNetworkSecurityGroup<Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate>.WithExistingNetworkSecurityGroup (string resourceId) {
            return this.WithExistingNetworkSecurityGroup( resourceId) as Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate>;
        }

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="nsg">nsg the network security group to assign</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate> Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IWithNetworkSecurityGroup<Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate>.WithExistingNetworkSecurityGroup (INetworkSecurityGroup nsg) {
            return this.WithExistingNetworkSecurityGroup( nsg) as Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate>;
        }

        /// <returns>the address space prefix, in CIDR notation, assigned to this subnet</returns>
        string Microsoft.Azure.Management.V2.Network.ISubnet.AddressPrefix
        {
            get
            {
                return this.AddressPrefix as string;
            }
        }
        /// <returns>the network security group associated with this subnet</returns>
        /// <returns><p></returns>
        /// <returns>Note that this method will result in a call to Azure each time it is invoked.</returns>
        Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup Microsoft.Azure.Management.V2.Network.ISubnet.NetworkSecurityGroup () {
            return this.NetworkSecurityGroup() as Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup;
        }

        /// <summary>
        /// Specifies the IP address space of the subnet, within the address space of the network.
        /// </summary>
        /// <param name="cidr">cidr the IP address space prefix using the CIDR notation</param>
        /// <returns>the next stage</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate Microsoft.Azure.Management.V2.Network.Subnet.Update.IWithAddressPrefix.WithAddressPrefix (string cidr) {
            return this.WithAddressPrefix( cidr) as Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the IP address space of the subnet, within the address space of the network.
        /// </summary>
        /// <param name="cidr">cidr the IP address space prefix using the CIDR notation</param>
        /// <returns>the next stage of the subnet definition</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Definition.IWithAttach<Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet> Microsoft.Azure.Management.V2.Network.Subnet.Definition.IWithAddressPrefix<Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet>.WithAddressPrefix (string cidr) {
            return this.WithAddressPrefix( cidr) as Microsoft.Azure.Management.V2.Network.Subnet.Definition.IWithAttach<Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet>;
        }

        /// <summary>
        /// Specifies the IP address space of the subnet, within the address space of the network.
        /// </summary>
        /// <param name="cidr">cidr the IP address space prefix using the CIDR notation</param>
        /// <returns>the next stage of the subnet definition</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate> Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IWithAddressPrefix<Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate>.WithAddressPrefix (string cidr) {
            return this.WithAddressPrefix( cidr) as Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Network.Network.Update.IUpdate>;
        }

        Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet>.Attach () {
            return this.Attach() as Microsoft.Azure.Management.V2.Network.Network.Definition.IWithCreateAndSubnet;
        }

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="resourceId">resourceId the resource ID of the network security group</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate Microsoft.Azure.Management.V2.Network.Subnet.Update.IWithNetworkSecurityGroup.WithExistingNetworkSecurityGroup (string resourceId) {
            return this.WithExistingNetworkSecurityGroup( resourceId) as Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate;
        }

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="nsg">nsg the network security group to assign</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate Microsoft.Azure.Management.V2.Network.Subnet.Update.IWithNetworkSecurityGroup.WithExistingNetworkSecurityGroup (INetworkSecurityGroup nsg) {
            return this.WithExistingNetworkSecurityGroup( nsg) as Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate;
        }

    }
}