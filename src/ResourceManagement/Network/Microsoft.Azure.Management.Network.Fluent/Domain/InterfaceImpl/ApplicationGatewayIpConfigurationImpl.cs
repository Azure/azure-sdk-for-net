// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGateway.Definition;
    using ApplicationGateway.Update;
    using ApplicationGatewayIpConfiguration.Definition;
    using ApplicationGatewayIpConfiguration.Update;
    using ApplicationGatewayIpConfiguration.UpdateDefinition;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;

    internal partial class ApplicationGatewayIpConfigurationImpl 
    {
        /// <summary>
        /// Assigns the specified subnet to this resource.
        /// </summary>
        /// <param name="parentNetworkResourceId">The resource ID of the virtual network the subnet is part of.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayIpConfiguration.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Update.IWithSubnet<ApplicationGatewayIpConfiguration.Update.IUpdate>.WithExistingSubnet(string parentNetworkResourceId, string subnetName)
        {
            return this.WithExistingSubnet(parentNetworkResourceId, subnetName) as ApplicationGatewayIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Assigns the specified subnet to this resource.
        /// </summary>
        /// <param name="parentNetworkResourceId">The resource ID of the virtual network the subnet is part of.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayIpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Definition.IWithSubnet<ApplicationGatewayIpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>>.WithExistingSubnet(string parentNetworkResourceId, string subnetName)
        {
            return this.WithExistingSubnet(parentNetworkResourceId, subnetName) as ApplicationGatewayIpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Assigns the specified subnet to this resource.
        /// </summary>
        /// <param name="parentNetworkResourceId">The resource ID of the virtual network the subnet is part of.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayIpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.UpdateDefinition.IWithSubnet<ApplicationGatewayIpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithExistingSubnet(string parentNetworkResourceId, string subnetName)
        {
            return this.WithExistingSubnet(parentNetworkResourceId, subnetName) as ApplicationGatewayIpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ApplicationGateway.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<ApplicationGateway.Update.IUpdate>.Attach()
        {
            return this.Attach() as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Specifies an existing subnet the application gateway should be part of and get its private IP address from.
        /// </summary>
        /// <param name="subnet">An existing subnet.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayIpConfiguration.Update.IUpdate ApplicationGatewayIpConfiguration.Update.IWithSubnet.WithExistingSubnet(ISubnet subnet)
        {
            return this.WithExistingSubnet(subnet) as ApplicationGatewayIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Specifies an existing subnet the application gateway should be part of and get its private IP address from.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <param name="subnetName">The name of a subnet within the selected network.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayIpConfiguration.Update.IUpdate ApplicationGatewayIpConfiguration.Update.IWithSubnet.WithExistingSubnet(INetwork network, string subnetName)
        {
            return this.WithExistingSubnet(network, subnetName) as ApplicationGatewayIpConfiguration.Update.IUpdate;
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
        /// Specifies an existing subnet the application gateway should be part of and get its private IP address from.
        /// </summary>
        /// <param name="subnet">An existing subnet.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayIpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayIpConfiguration.Definition.IWithSubnet<ApplicationGateway.Definition.IWithCreate>.WithExistingSubnet(ISubnet subnet)
        {
            return this.WithExistingSubnet(subnet) as ApplicationGatewayIpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies an existing subnet the application gateway should be part of and get its private IP address from.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <param name="subnetName">The name of a subnet within the selected network.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayIpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayIpConfiguration.Definition.IWithSubnet<ApplicationGateway.Definition.IWithCreate>.WithExistingSubnet(INetwork network, string subnetName)
        {
            return this.WithExistingSubnet(network, subnetName) as ApplicationGatewayIpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies an existing subnet the application gateway should be part of and get its private IP address from.
        /// </summary>
        /// <param name="subnet">An existing subnet.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayIpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayIpConfiguration.UpdateDefinition.IWithSubnet<ApplicationGateway.Update.IUpdate>.WithExistingSubnet(ISubnet subnet)
        {
            return this.WithExistingSubnet(subnet) as ApplicationGatewayIpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies an existing subnet the application gateway should be part of and get its private IP address from.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <param name="subnetName">The name of a subnet within the selected network.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayIpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayIpConfiguration.UpdateDefinition.IWithSubnet<ApplicationGateway.Update.IUpdate>.WithExistingSubnet(INetwork network, string subnetName)
        {
            return this.WithExistingSubnet(network, subnetName) as ApplicationGatewayIpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <return>
        /// The subnet the application gateway is in
        /// Note, this results in a separate call to Azure.
        /// </return>
        Microsoft.Azure.Management.Network.Fluent.ISubnet Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayIpConfiguration.GetSubnet()
        {
            return this.GetSubnet() as Microsoft.Azure.Management.Network.Fluent.ISubnet;
        }

        /// <summary>
        /// Gets the name of the subnet the application gateway is in.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayIpConfiguration.SubnetName
        {
            get
            {
                return this.SubnetName();
            }
        }

        /// <summary>
        /// Gets the resource ID of the virtual network the application gateway is in.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayIpConfiguration.NetworkId
        {
            get
            {
                return this.NetworkId();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ApplicationGateway.Definition.IWithCreate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<ApplicationGateway.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as ApplicationGateway.Definition.IWithCreate;
        }
    }
}