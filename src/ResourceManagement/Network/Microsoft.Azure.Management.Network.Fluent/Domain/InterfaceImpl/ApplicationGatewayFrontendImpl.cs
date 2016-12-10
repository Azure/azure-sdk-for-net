// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGateway.Definition;
    using ApplicationGateway.Update;
    using ApplicationGatewayFrontend.Definition;
    using ApplicationGatewayFrontend.Update;
    using ApplicationGatewayFrontend.UpdateDefinition;
    using Models;
    using HasPrivateIpAddress.Definition;
    using HasPrivateIpAddress.UpdateDefinition;
    using HasPublicIpAddress.Definition;
    using HasPublicIpAddress.UpdateDefinition;
    using HasPublicIpAddress.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;

    internal partial class ApplicationGatewayFrontendImpl 
    {
        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ApplicationGateway.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions.IInUpdateAlt<ApplicationGateway.Update.IUpdate>.Attach()
        {
            return this.Attach() as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets true is the frontend is accessible via an private IP address.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend.IsPrivate
        {
            get
            {
                return this.IsPrivate();
            }
        }

        /// <return>The associated subnet.</return>
        Microsoft.Azure.Management.Network.Fluent.ISubnet Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend.GetSubnet()
        {
            return this.GetSubnet() as Microsoft.Azure.Management.Network.Fluent.ISubnet;
        }

        /// <summary>
        /// Gets true if the frontend is accessible via a public IP address, else false.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend.IsPublic
        {
            get
            {
                return this.IsPublic();
            }
        }

        /// <return>The associated public IP address.</return>
        Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress Microsoft.Azure.Management.Network.Fluent.IHasPublicIpAddress.GetPublicIpAddress()
        {
            return this.GetPublicIpAddress() as Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress;
        }

        /// <summary>
        /// Gets the resource ID of the associated public IP address.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IHasPublicIpAddress.PublicIpAddressId
        {
            get
            {
                return this.PublicIpAddressId();
            }
        }

        /// <summary>
        /// Assigns the specified subnet to this resource.
        /// </summary>
        /// <param name="parentNetworkResourceId">The resource ID of the virtual network the subnet is part of.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayFrontend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.UpdateDefinition.IWithSubnet<ApplicationGatewayFrontend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithExistingSubnet(string parentNetworkResourceId, string subnetName)
        {
            return this.WithExistingSubnet(parentNetworkResourceId, subnetName) as ApplicationGatewayFrontend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Assigns the specified subnet to this resource.
        /// </summary>
        /// <param name="parentNetworkResourceId">The resource ID of the virtual network the subnet is part of.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayFrontend.Definition.IWithAttach<ApplicationGateway.Definition.IWithListener> Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Definition.IWithSubnet<ApplicationGatewayFrontend.Definition.IWithAttach<ApplicationGateway.Definition.IWithListener>>.WithExistingSubnet(string parentNetworkResourceId, string subnetName)
        {
            return this.WithExistingSubnet(parentNetworkResourceId, subnetName) as ApplicationGatewayFrontend.Definition.IWithAttach<ApplicationGateway.Definition.IWithListener>;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayFrontend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> HasPrivateIpAddress.UpdateDefinition.IWithPrivateIpAddress<ApplicationGatewayFrontend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithPrivateIpAddressDynamic()
        {
            return this.WithPrivateIpAddressDynamic() as ApplicationGatewayFrontend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">A static IP address within the associated private IP range.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayFrontend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> HasPrivateIpAddress.UpdateDefinition.IWithPrivateIpAddress<ApplicationGatewayFrontend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithPrivateIpAddressStatic(string ipAddress)
        {
            return this.WithPrivateIpAddressStatic(ipAddress) as ApplicationGatewayFrontend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayFrontend.Definition.IWithAttach<ApplicationGateway.Definition.IWithListener> HasPrivateIpAddress.Definition.IWithPrivateIpAddress<ApplicationGatewayFrontend.Definition.IWithAttach<ApplicationGateway.Definition.IWithListener>>.WithPrivateIpAddressDynamic()
        {
            return this.WithPrivateIpAddressDynamic() as ApplicationGatewayFrontend.Definition.IWithAttach<ApplicationGateway.Definition.IWithListener>;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">A static IP address within the associated private IP range.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayFrontend.Definition.IWithAttach<ApplicationGateway.Definition.IWithListener> HasPrivateIpAddress.Definition.IWithPrivateIpAddress<ApplicationGatewayFrontend.Definition.IWithAttach<ApplicationGateway.Definition.IWithListener>>.WithPrivateIpAddressStatic(string ipAddress)
        {
            return this.WithPrivateIpAddressStatic(ipAddress) as ApplicationGatewayFrontend.Definition.IWithAttach<ApplicationGateway.Definition.IWithListener>;
        }

        /// <summary>
        /// Gets the name of the subnet associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasSubnet.SubnetName
        {
            get
            {
                return this.SubnetName();
            }
        }

        /// <summary>
        /// Gets the resource ID of the virtual network whose subnet is associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasSubnet.NetworkId
        {
            get
            {
                return this.NetworkId();
            }
        }

        /// <summary>
        /// Gets the private IP address associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IHasPrivateIpAddress.PrivateIpAddress
        {
            get
            {
                return this.PrivateIpAddress();
            }
        }

        /// <summary>
        /// Gets the private IP address allocation method within the associated subnet.
        /// </summary>
        IPAllocationMethod Microsoft.Azure.Management.Network.Fluent.IHasPrivateIpAddress.PrivateIpAllocationMethod
        {
            get
            {
                return this.PrivateIpAllocationMethod();
            }
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIpAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayFrontend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> HasPublicIpAddress.UpdateDefinition.IWithExistingPublicIpAddress<ApplicationGatewayFrontend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            return this.WithExistingPublicIpAddress(publicIpAddress) as ApplicationGatewayFrontend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayFrontend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> HasPublicIpAddress.UpdateDefinition.IWithExistingPublicIpAddress<ApplicationGatewayFrontend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithExistingPublicIpAddress(string resourceId)
        {
            return this.WithExistingPublicIpAddress(resourceId) as ApplicationGatewayFrontend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Removes the existing reference to a public IP address.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayFrontend.Update.IUpdate HasPublicIpAddress.Update.IWithExistingPublicIpAddress<ApplicationGatewayFrontend.Update.IUpdate>.WithoutPublicIpAddress()
        {
            return this.WithoutPublicIpAddress() as ApplicationGatewayFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIpAddress">An existing public IP address.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayFrontend.Update.IUpdate HasPublicIpAddress.Update.IWithExistingPublicIpAddress<ApplicationGatewayFrontend.Update.IUpdate>.WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            return this.WithExistingPublicIpAddress(publicIpAddress) as ApplicationGatewayFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayFrontend.Update.IUpdate HasPublicIpAddress.Update.IWithExistingPublicIpAddress<ApplicationGatewayFrontend.Update.IUpdate>.WithExistingPublicIpAddress(string resourceId)
        {
            return this.WithExistingPublicIpAddress(resourceId) as ApplicationGatewayFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIpAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayFrontend.Definition.IWithAttach<ApplicationGateway.Definition.IWithListener> HasPublicIpAddress.Definition.IWithExistingPublicIpAddress<ApplicationGatewayFrontend.Definition.IWithAttach<ApplicationGateway.Definition.IWithListener>>.WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            return this.WithExistingPublicIpAddress(publicIpAddress) as ApplicationGatewayFrontend.Definition.IWithAttach<ApplicationGateway.Definition.IWithListener>;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayFrontend.Definition.IWithAttach<ApplicationGateway.Definition.IWithListener> HasPublicIpAddress.Definition.IWithExistingPublicIpAddress<ApplicationGatewayFrontend.Definition.IWithAttach<ApplicationGateway.Definition.IWithListener>>.WithExistingPublicIpAddress(string resourceId)
        {
            return this.WithExistingPublicIpAddress(resourceId) as ApplicationGatewayFrontend.Definition.IWithAttach<ApplicationGateway.Definition.IWithListener>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definition.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ApplicationGateway.Definition.IWithListener Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions.IInDefinitionAlt<ApplicationGateway.Definition.IWithListener>.Attach()
        {
            return this.Attach() as ApplicationGateway.Definition.IWithListener;
        }

        /// <summary>
        /// Assigns the specified subnet to this private frontend.
        /// </summary>
        /// <param name="network">The virtual network the subnet exists in.</param>
        /// <param name="subnetName">The name of a subnet.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayFrontend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayFrontend.UpdateDefinition.IWithSubnet<ApplicationGateway.Update.IUpdate>.WithExistingSubnet(INetwork network, string subnetName)
        {
            return this.WithExistingSubnet(network, subnetName) as ApplicationGatewayFrontend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Assigns the specified subnet to this private frontend.
        /// </summary>
        /// <param name="network">The virtual network the subnet exists in.</param>
        /// <param name="subnetName">The name of a subnet.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayFrontend.Definition.IWithAttach<ApplicationGateway.Definition.IWithListener> ApplicationGatewayFrontend.Definition.IWithSubnet<ApplicationGateway.Definition.IWithListener>.WithExistingSubnet(INetwork network, string subnetName)
        {
            return this.WithExistingSubnet(network, subnetName) as ApplicationGatewayFrontend.Definition.IWithAttach<ApplicationGateway.Definition.IWithListener>;
        }
    }
}