// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIPAddress.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIPAddress.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIPAddress.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.HasSubnet.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class LoadBalancerFrontendImpl 
    {
        /// <summary>
        /// Gets the name of the subnet associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasSubnet.SubnetName
        {
            get
            {
                return this.SubnetName();
            }
        }

        /// <summary>
        /// Gets the resource ID of the virtual network whose subnet is associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasSubnet.NetworkId
        {
            get
            {
                return this.NetworkId();
            }
        }

        /// <summary>
        /// Assigns the specified subnet to this private frontend of the internal load balancer.
        /// </summary>
        /// <param name="network">The virtual network the subnet exists in.</param>
        /// <param name="subnetName">The name of a subnet.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPrivateFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancerPrivateFrontend.UpdateDefinition.IWithSubnet<LoadBalancer.Update.IUpdate>.WithExistingSubnet(INetwork network, string subnetName)
        {
            return this.WithExistingSubnet(network, subnetName) as LoadBalancerPrivateFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Assigns the specified subnet to this private frontend of an internal load balancer.
        /// </summary>
        /// <param name="network">The virtual network the subnet exists in.</param>
        /// <param name="subnetName">The name of a subnet.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPrivateFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate> LoadBalancerPrivateFrontend.Definition.IWithSubnet<LoadBalancer.Definition.IWithCreate>.WithExistingSubnet(INetwork network, string subnetName)
        {
            return this.WithExistingSubnet(network, subnetName) as LoadBalancerPrivateFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>;
        }

        /// <return>
        /// Associated subnet
        /// Note this makes a separate call to Azure.
        /// </return>
        Microsoft.Azure.Management.Network.Fluent.ISubnet Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPrivateFrontend.GetSubnet()
        {
            return this.GetSubnet() as Microsoft.Azure.Management.Network.Fluent.ISubnet;
        }

        /// <summary>
        /// Gets the private IP address allocation method within the associated subnet.
        /// </summary>
        Models.IPAllocationMethod Microsoft.Azure.Management.Network.Fluent.IHasPrivateIPAddress.PrivateIPAllocationMethod
        {
            get
            {
                return this.PrivateIPAllocationMethod() as Models.IPAllocationMethod;
            }
        }

        /// <summary>
        /// Gets the private IP address associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IHasPrivateIPAddress.PrivateIPAddress
        {
            get
            {
                return this.PrivateIPAddress();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        LoadBalancer.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<LoadBalancer.Update.IUpdate>.Attach()
        {
            return this.Attach() as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPublicFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate> HasPublicIPAddress.Definition.IWithExistingPublicIPAddress<LoadBalancerPublicFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>>.WithExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return this.WithExistingPublicIPAddress(publicIPAddress) as LoadBalancerPublicFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPublicFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate> HasPublicIPAddress.Definition.IWithExistingPublicIPAddress<LoadBalancerPublicFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>>.WithExistingPublicIPAddress(string resourceId)
        {
            return this.WithExistingPublicIPAddress(resourceId) as LoadBalancerPublicFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Removes the existing reference to a public IP address.
        /// </summary>
        /// <return>The next stage of the update.</return>
        LoadBalancerPublicFrontend.Update.IUpdate HasPublicIPAddress.Update.IWithExistingPublicIPAddress<LoadBalancerPublicFrontend.Update.IUpdate>.WithoutPublicIPAddress()
        {
            return this.WithoutPublicIPAddress() as LoadBalancerPublicFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancerPublicFrontend.Update.IUpdate HasPublicIPAddress.Update.IWithExistingPublicIPAddress<LoadBalancerPublicFrontend.Update.IUpdate>.WithExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return this.WithExistingPublicIPAddress(publicIPAddress) as LoadBalancerPublicFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPublicFrontend.Update.IUpdate HasPublicIPAddress.Update.IWithExistingPublicIPAddress<LoadBalancerPublicFrontend.Update.IUpdate>.WithExistingPublicIPAddress(string resourceId)
        {
            return this.WithExistingPublicIPAddress(resourceId) as LoadBalancerPublicFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPublicFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasPublicIPAddress.UpdateDefinition.IWithExistingPublicIPAddress<LoadBalancerPublicFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return this.WithExistingPublicIPAddress(publicIPAddress) as LoadBalancerPublicFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPublicFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasPublicIPAddress.UpdateDefinition.IWithExistingPublicIPAddress<LoadBalancerPublicFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithExistingPublicIPAddress(string resourceId)
        {
            return this.WithExistingPublicIPAddress(resourceId) as LoadBalancerPublicFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Gets the inbound NAT pools on this load balancer that use this frontend, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> Microsoft.Azure.Management.Network.Fluent.ILoadBalancerFrontend.InboundNatPools
        {
            get
            {
                return this.InboundNatPools() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool>;
            }
        }

        /// <summary>
        /// Gets true if the frontend is public, i.e. it has a public IP address associated with it.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.ILoadBalancerFrontend.IsPublic
        {
            get
            {
                return this.IsPublic();
            }
        }

        /// <summary>
        /// Gets the inbound NAT rules on this load balancer that use this frontend, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatRule> Microsoft.Azure.Management.Network.Fluent.ILoadBalancerFrontend.InboundNatRules
        {
            get
            {
                return this.InboundNatRules() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatRule>;
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        LoadBalancer.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<LoadBalancer.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as LoadBalancer.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a new public IP address to associate with the resource.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPublicFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate> HasPublicIPAddress.Definition.IWithNewPublicIPAddressNoDnsLabel<LoadBalancerPublicFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>>.WithNewPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> creatable)
        {
            return this.WithNewPublicIPAddress(creatable) as LoadBalancerPublicFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPublicFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate> HasPublicIPAddress.Definition.IWithNewPublicIPAddressNoDnsLabel<LoadBalancerPublicFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>>.WithNewPublicIPAddress()
        {
            return this.WithNewPublicIPAddress() as LoadBalancerPublicFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new public IP address to associate with the resource.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPublicFrontend.Update.IUpdate HasPublicIPAddress.Update.IWithNewPublicIPAddressNoDnsLabel<LoadBalancerPublicFrontend.Update.IUpdate>.WithNewPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> creatable)
        {
            return this.WithNewPublicIPAddress(creatable) as LoadBalancerPublicFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPublicFrontend.Update.IUpdate HasPublicIPAddress.Update.IWithNewPublicIPAddressNoDnsLabel<LoadBalancerPublicFrontend.Update.IUpdate>.WithNewPublicIPAddress()
        {
            return this.WithNewPublicIPAddress() as LoadBalancerPublicFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address to associate with the resource.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPublicFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasPublicIPAddress.UpdateDefinition.IWithNewPublicIPAddressNoDnsLabel<LoadBalancerPublicFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithNewPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> creatable)
        {
            return this.WithNewPublicIPAddress(creatable) as LoadBalancerPublicFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPublicFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasPublicIPAddress.UpdateDefinition.IWithNewPublicIPAddressNoDnsLabel<LoadBalancerPublicFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithNewPublicIPAddress()
        {
            return this.WithNewPublicIPAddress() as LoadBalancerPublicFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <return>The associated public IP address.</return>
        Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress Microsoft.Azure.Management.Network.Fluent.IHasPublicIPAddress.GetPublicIPAddress()
        {
            return this.GetPublicIPAddress() as Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress;
        }

        /// <summary>
        /// Gets the resource ID of the associated public IP address.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IHasPublicIPAddress.PublicIPAddressId
        {
            get
            {
                return this.PublicIPAddressId();
            }
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPrivateFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasPrivateIPAddress.UpdateDefinition.IWithPrivateIPAddress<LoadBalancerPrivateFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithPrivateIPAddressDynamic()
        {
            return this.WithPrivateIPAddressDynamic() as LoadBalancerPrivateFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">A static IP address within the associated private IP range.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPrivateFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasPrivateIPAddress.UpdateDefinition.IWithPrivateIPAddress<LoadBalancerPrivateFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithPrivateIPAddressStatic(string ipAddress)
        {
            return this.WithPrivateIPAddressStatic(ipAddress) as LoadBalancerPrivateFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPrivateFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate> HasPrivateIPAddress.Definition.IWithPrivateIPAddress<LoadBalancerPrivateFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>>.WithPrivateIPAddressDynamic()
        {
            return this.WithPrivateIPAddressDynamic() as LoadBalancerPrivateFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">A static IP address within the associated private IP range.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPrivateFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate> HasPrivateIPAddress.Definition.IWithPrivateIPAddress<LoadBalancerPrivateFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>>.WithPrivateIPAddressStatic(string ipAddress)
        {
            return this.WithPrivateIPAddressStatic(ipAddress) as LoadBalancerPrivateFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <return>The next stage of the update.</return>
        LoadBalancerPrivateFrontend.Update.IUpdate HasPrivateIPAddress.Update.IWithPrivateIPAddress<LoadBalancerPrivateFrontend.Update.IUpdate>.WithPrivateIPAddressDynamic()
        {
            return this.WithPrivateIPAddressDynamic() as LoadBalancerPrivateFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">A static IP address within the associated private IP range.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancerPrivateFrontend.Update.IUpdate HasPrivateIPAddress.Update.IWithPrivateIPAddress<LoadBalancerPrivateFrontend.Update.IUpdate>.WithPrivateIPAddressStatic(string ipAddress)
        {
            return this.WithPrivateIPAddressStatic(ipAddress) as LoadBalancerPrivateFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associates it with the resource.
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPublicFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate> HasPublicIPAddress.Definition.IWithNewPublicIPAddress<LoadBalancerPublicFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>>.WithNewPublicIPAddress(string leafDnsLabel)
        {
            return this.WithNewPublicIPAddress(leafDnsLabel) as LoadBalancerPublicFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associates it with the resource.
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPublicFrontend.Update.IUpdate HasPublicIPAddress.Update.IWithNewPublicIPAddress<LoadBalancerPublicFrontend.Update.IUpdate>.WithNewPublicIPAddress(string leafDnsLabel)
        {
            return this.WithNewPublicIPAddress(leafDnsLabel) as LoadBalancerPublicFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associates it with the resource.
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPublicFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasPublicIPAddress.UpdateDefinition.IWithNewPublicIPAddress<LoadBalancerPublicFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithNewPublicIPAddress(string leafDnsLabel)
        {
            return this.WithNewPublicIPAddress(leafDnsLabel) as LoadBalancerPublicFrontend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Gets the associated load balancing rules from this load balancer, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule> Microsoft.Azure.Management.Network.Fluent.IHasLoadBalancingRules.LoadBalancingRules
        {
            get
            {
                return this.LoadBalancingRules() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule>;
            }
        }

        /// <summary>
        /// Assigns the specified subnet to this private frontend of the internal load balancer.
        /// </summary>
        /// <param name="network">The virtual network the subnet exists in.</param>
        /// <param name="subnetName">The name of a subnet.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPrivateFrontend.Update.IUpdate LoadBalancerPrivateFrontend.Update.IWithSubnet.WithExistingSubnet(INetwork network, string subnetName)
        {
            return this.WithExistingSubnet(network, subnetName) as LoadBalancerPrivateFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definition.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        LoadBalancer.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.IInDefinitionAlt<LoadBalancer.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as LoadBalancer.Definition.IWithCreate;
        }

        /// <summary>
        /// Assigns the specified subnet to this resource.
        /// </summary>
        /// <param name="parentNetworkResourceId">The resource ID of the virtual network the subnet is part of.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerPrivateFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate> Microsoft.Azure.Management.ResourceManager.Fluent.Core.HasSubnet.Definition.IWithSubnet<LoadBalancerPrivateFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>>.WithExistingSubnet(string parentNetworkResourceId, string subnetName)
        {
            return this.WithExistingSubnet(parentNetworkResourceId, subnetName) as LoadBalancerPrivateFrontend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        LoadBalancer.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.IInUpdateAlt<LoadBalancer.Update.IUpdate>.Attach()
        {
            return this.Attach() as LoadBalancer.Update.IUpdate;
        }
    }
}