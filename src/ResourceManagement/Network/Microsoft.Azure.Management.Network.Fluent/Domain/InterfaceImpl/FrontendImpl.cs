// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIpAddress.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIpAddress.Update;
    using Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Definition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIpAddress.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIpAddress.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition;
    using Microsoft.Azure.Management.Network.Fluent.PublicFrontend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.PublicFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIpAddress.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.PublicFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIpAddress.Definition;
    public partial class FrontendImpl 
    {
        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions.IInUpdateAlt<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate;
        }

        /// <returns>the resource ID of the associated public IP address</returns>
        string Microsoft.Azure.Management.Network.Fluent.IHasPublicIpAddress.PublicIpAddressId
        {
            get
            { 
            return this.PublicIpAddressId() as string;
            }
        }
        /// <returns>the associated public IP address</returns>
        Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress Microsoft.Azure.Management.Network.Fluent.IHasPublicIpAddress.GetPublicIpAddress() { 
            return this.GetPublicIpAddress() as Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Assigns the specified subnet to this resource.
        /// </summary>
        /// <param name="parentNetworkResourceId">parentNetworkResourceId the resource ID of the virtual network the subnet is part of</param>
        /// <param name="subnetName">subnetName the name of the subnet</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend> Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Definition.IWithSubnet<Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend>>.WithExistingSubnet(string parentNetworkResourceId, string subnetName) { 
            return this.WithExistingSubnet( parentNetworkResourceId,  subnetName) as Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPublicFrontendOrBackend Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPublicFrontendOrBackend>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPublicFrontendOrBackend;
        }

        /// <returns>the private IP allocation method within the associated subnet for this private frontend</returns>
        string Microsoft.Azure.Management.Network.Fluent.IPrivateFrontend.PrivateIpAllocationMethod
        {
            get
            { 
            return this.PrivateIpAllocationMethod() as string;
            }
        }
        /// <returns>the inbound NAT pools on this load balancer that use this frontend, indexed by their names</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Network.Fluent.IInboundNatPool> Microsoft.Azure.Management.Network.Fluent.IFrontend.InboundNatPools
        {
            get
            { 
            return this.InboundNatPools() as System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Network.Fluent.IInboundNatPool>;
            }
        }
        /// <returns>true if the frontend is public, i.e. it has a public IP address associated with it</returns>
        bool Microsoft.Azure.Management.Network.Fluent.IFrontend.IsPublic
        {
            get
            { 
            return this.IsPublic();
            }
        }
        /// <returns>the inbound NAT rules on this load balancer that use this frontend, indexed by their names</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Network.Fluent.IInboundNatRule> Microsoft.Azure.Management.Network.Fluent.IFrontend.InboundNatRules
        {
            get
            { 
            return this.InboundNatRules() as System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Network.Fluent.IInboundNatRule>;
            }
        }
        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">ipAddress a static IP address within the associated private IP range</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HasPrivateIpAddress.UpdateDefinition.IWithPrivateIpAddress<Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>.WithPrivateIpAddressStatic(string ipAddress) { 
            return this.WithPrivateIpAddressStatic( ipAddress) as Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HasPrivateIpAddress.UpdateDefinition.IWithPrivateIpAddress<Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>.WithPrivateIpAddressDynamic() { 
            return this.WithPrivateIpAddressDynamic() as Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">ipAddress a static IP address within the associated private IP range</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend> Microsoft.Azure.Management.Network.Fluent.HasPrivateIpAddress.Definition.IWithPrivateIpAddress<Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend>>.WithPrivateIpAddressStatic(string ipAddress) { 
            return this.WithPrivateIpAddressStatic( ipAddress) as Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend>;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend> Microsoft.Azure.Management.Network.Fluent.HasPrivateIpAddress.Definition.IWithPrivateIpAddress<Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend>>.WithPrivateIpAddressDynamic() { 
            return this.WithPrivateIpAddressDynamic() as Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend>;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">ipAddress a static IP address within the associated private IP range</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HasPrivateIpAddress.Update.IWithPrivateIpAddress<Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Update.IUpdate>.WithPrivateIpAddressStatic(string ipAddress) { 
            return this.WithPrivateIpAddressStatic( ipAddress) as Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HasPrivateIpAddress.Update.IWithPrivateIpAddress<Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Update.IUpdate>.WithPrivateIpAddressDynamic() { 
            return this.WithPrivateIpAddressDynamic() as Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Update.IUpdate;
        }

        /// <returns>the name of the subnet associated with this resource</returns>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasSubnet.SubnetName
        {
            get
            { 
            return this.SubnetName() as string;
            }
        }
        /// <returns>the resource ID of the virtual network whose subnet is associated with this resource</returns>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasSubnet.NetworkId
        {
            get
            { 
            return this.NetworkId() as string;
            }
        }
        /// <returns>the private IP address associated with this resource</returns>
        string Microsoft.Azure.Management.Network.Fluent.IHasPrivateIpAddress.PrivateIpAddress
        {
            get
            { 
            return this.PrivateIpAddress() as string;
            }
        }
        /// <summary>
        /// Removes the existing reference to a public IP address.
        /// </summary>
        /// <returns>the next stage of the update.</returns>
        Microsoft.Azure.Management.Network.Fluent.PublicFrontend.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HasPublicIpAddress.Update.IWithExistingPublicIpAddress<Microsoft.Azure.Management.Network.Fluent.PublicFrontend.Update.IUpdate>.WithoutPublicIpAddress() { 
            return this.WithoutPublicIpAddress() as Microsoft.Azure.Management.Network.Fluent.PublicFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.PublicFrontend.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HasPublicIpAddress.Update.IWithExistingPublicIpAddress<Microsoft.Azure.Management.Network.Fluent.PublicFrontend.Update.IUpdate>.WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress) { 
            return this.WithExistingPublicIpAddress( publicIpAddress) as Microsoft.Azure.Management.Network.Fluent.PublicFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">resourceId the resource ID of an existing public IP address</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.PublicFrontend.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HasPublicIpAddress.Update.IWithExistingPublicIpAddress<Microsoft.Azure.Management.Network.Fluent.PublicFrontend.Update.IUpdate>.WithExistingPublicIpAddress(string resourceId) { 
            return this.WithExistingPublicIpAddress( resourceId) as Microsoft.Azure.Management.Network.Fluent.PublicFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.PublicFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPublicFrontendOrBackend> Microsoft.Azure.Management.Network.Fluent.HasPublicIpAddress.Definition.IWithExistingPublicIpAddress<Microsoft.Azure.Management.Network.Fluent.PublicFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPublicFrontendOrBackend>>.WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress) { 
            return this.WithExistingPublicIpAddress( publicIpAddress) as Microsoft.Azure.Management.Network.Fluent.PublicFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPublicFrontendOrBackend>;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">resourceId the resource ID of an existing public IP address</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.PublicFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPublicFrontendOrBackend> Microsoft.Azure.Management.Network.Fluent.HasPublicIpAddress.Definition.IWithExistingPublicIpAddress<Microsoft.Azure.Management.Network.Fluent.PublicFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPublicFrontendOrBackend>>.WithExistingPublicIpAddress(string resourceId) { 
            return this.WithExistingPublicIpAddress( resourceId) as Microsoft.Azure.Management.Network.Fluent.PublicFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPublicFrontendOrBackend>;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.PublicFrontend.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HasPublicIpAddress.UpdateDefinition.IWithExistingPublicIpAddress<Microsoft.Azure.Management.Network.Fluent.PublicFrontend.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>.WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress) { 
            return this.WithExistingPublicIpAddress( publicIpAddress) as Microsoft.Azure.Management.Network.Fluent.PublicFrontend.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">resourceId the resource ID of an existing public IP address</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.PublicFrontend.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HasPublicIpAddress.UpdateDefinition.IWithExistingPublicIpAddress<Microsoft.Azure.Management.Network.Fluent.PublicFrontend.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>.WithExistingPublicIpAddress(string resourceId) { 
            return this.WithExistingPublicIpAddress( resourceId) as Microsoft.Azure.Management.Network.Fluent.PublicFrontend.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definition.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions.IInDefinitionAlt<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend;
        }

        /// <returns>the associated load balancing rules from this load balancer, indexed by their names</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule> Microsoft.Azure.Management.Network.Fluent.IHasLoadBalancingRules.LoadBalancingRules
        {
            get
            { 
            return this.LoadBalancingRules() as System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule>;
            }
        }
        /// <summary>
        /// Assigns the specified subnet to this private frontend of the internal load balancer.
        /// </summary>
        /// <param name="network">network the virtual network the subnet exists in</param>
        /// <param name="subnetName">subnetName the name of a subnet</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.UpdateDefinition.IWithSubnet<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.WithExistingSubnet(INetwork network, string subnetName) { 
            return this.WithExistingSubnet( network,  subnetName) as Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Assigns the specified subnet to this private frontend of an internal load balancer.
        /// </summary>
        /// <param name="network">network the virtual network the subnet exists in</param>
        /// <param name="subnetName">subnetName the name of a subnet</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend> Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Definition.IWithSubnet<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend>.WithExistingSubnet(INetwork network, string subnetName) { 
            return this.WithExistingSubnet( network,  subnetName) as Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend>;
        }

        /// <returns>the name of this child object</returns>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IChildResource<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>.Name
        {
            get
            { 
            return this.Name() as string;
            }
        }
        /// <summary>
        /// Assigns the specified subnet to this private frontend of the internal load balancer.
        /// </summary>
        /// <param name="network">network the virtual network the subnet exists in</param>
        /// <param name="subnetName">subnetName the name of a subnet</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Update.IWithSubnet.WithExistingSubnet(INetwork network, string subnetName) { 
            return this.WithExistingSubnet( network,  subnetName) as Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Update.IUpdate;
        }

    }
}