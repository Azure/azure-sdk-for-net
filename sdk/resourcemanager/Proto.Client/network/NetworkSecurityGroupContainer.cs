﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Network
{
    /// <summary>
    /// A class representing collection of NetworkSecurityGroup and their operations over a resource group.
    /// </summary>
    public class NetworkSecurityGroupContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, NetworkSecurityGroup, NetworkSecurityGroupData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkSecurityGroupContainer"/> class.
        /// </summary>
        /// <param name="genericOperations"> An instance of <see cref="GenericResourceOperations"/> that has an id for a [Resource]. </param>
        internal NetworkSecurityGroupContainer(GenericResourceOperations genericOperations)
            : base(genericOperations)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkSecurityGroupContainer"/> class.
        /// </summary>
        /// <param name="resourceGroup"> The ResourceGroup that is the parent of the NetworkSecurityGroups. </param>
        internal NetworkSecurityGroupContainer(ResourceGroupOperations resourceGroup)
            : base(resourceGroup)
        {
        }

        /// <summary>
        /// Gets the valid resource type for network security groups.
        /// </summary>
        /// <summary>
        /// Typed Resource Identifier for the container.
        /// </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary>
        /// ResourceType for the container.
        /// </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        private NetworkSecurityGroupsOperations Operations => new NetworkManagementClient(
            Id.SubscriptionId,
            BaseUri,
            Credential,
            ClientOptions.Convert<NetworkManagementClientOptions>()).NetworkSecurityGroups;

        /// <summary>
        /// The operation to create or update a network security group. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the network security group. </param>
        /// <param name="resourceDetails"> The desired network security group configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="Response{NetworkSecurityGroup}"/> operation for this resource. </returns>
        public Response<NetworkSecurityGroup> CreateOrUpdate(string name, NetworkSecurityGroupData resourceDetails, CancellationToken cancellationToken = default)
        {
            var response = Operations.StartCreateOrUpdate(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken).WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
            return Response.FromValue(new NetworkSecurityGroup(Parent, new NetworkSecurityGroupData(response.Value)), response.GetRawResponse());
        }

        /// <summary>
        /// The operation to create or update a network security group. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the network security group. </param>
        /// <param name="resourceDetails"> The desired network security group configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="Response{NetworkSecurityGroup}"/> operation for this network security group. </returns>
        public async Task<Response<NetworkSecurityGroup>> CreateOrUpdateAsync(string name, NetworkSecurityGroupData resourceDetails, CancellationToken cancellationToken = default)
        {
            var response = await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult().WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new NetworkSecurityGroup(Parent, new NetworkSecurityGroupData(response.Value)), response.GetRawResponse());
        }

        /// <summary>
        /// The operation to create or update a network security group. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the network security group. </param>
        /// <param name="resourceDetails"> The desired network security group configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An <see cref="Operation{NetworkSecurityGroup}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public Operation<NetworkSecurityGroup> StartCreateOrUpdate(string name, NetworkSecurityGroupData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(
                Operations.StartCreateOrUpdate(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken),
                n => new NetworkSecurityGroup(Parent, new NetworkSecurityGroupData(n)));
        }

        /// <summary>
        /// The operation to create or update a network security group. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the network security group. </param>
        /// <param name="resourceDetails"> The desired network security group configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="Operation{NetworkSecurityGroup}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public async Task<Operation<NetworkSecurityGroup>> StartCreateOrUpdateAsync(string name, NetworkSecurityGroupData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(
                await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken).ConfigureAwait(false),
                n => new NetworkSecurityGroup(Parent, new NetworkSecurityGroupData(n)));
        }

        /// <summary>
        /// Construct an object used to create a network security group.
        /// </summary>
        /// <param name="locationData"> The location to create the network security group. </param>
        /// <param name="openPorts"> The location to create the network security group. </param>
        /// <returns> Object used to create a <see cref="NetworkSecurityGroup"/>. </returns>
        public NetworkSecurityGroupBuilder Construct(LocationData locationData = null, params int[] openPorts)
        {
            var parent = GetParentResource<ResourceGroup, ResourceGroupResourceIdentifier, ResourceGroupOperations>();
            var nsg = new Azure.ResourceManager.Network.Models.NetworkSecurityGroup
            {
                Location = locationData ?? parent.Data.Location
            };
            var index = 0;
            foreach(int port in openPorts)
            {
                var securityRule = new SecurityRule
                {
                    Name = $"Port{port}",
                    Priority = 1000 + (++index),
                    Protocol = SecurityRuleProtocol.Tcp,
                    Access = SecurityRuleAccess.Allow,
                    Direction = SecurityRuleDirection.Inbound,
                    SourcePortRange = "*",
                    SourceAddressPrefix = "*",
                    DestinationPortRange = $"{port}",
                    DestinationAddressPrefix = "*",
                    Description = $"Port_{port}"
                };
                nsg.SecurityRules.Add(securityRule);
            }

            return new NetworkSecurityGroupBuilder(this, new NetworkSecurityGroupData(nsg));
        }

        /// <summary>
        /// Construct an object used to create a network security group.
        /// </summary>
        /// <param name="openPorts"> The location to create the network security group. </param>
        /// <returns> Object used to create a <see cref="NetworkSecurityGroup"/>. </returns>
        public NetworkSecurityGroupBuilder Construct(params int[] openPorts)
        {
            var parent = GetParentResource<ResourceGroup, ResourceGroupResourceIdentifier, ResourceGroupOperations>();
            var nsg = new Azure.ResourceManager.Network.Models.NetworkSecurityGroup
            {
                Location = parent.Data.Location,
            };
            var index = 0;
            foreach (int port in openPorts)
            {
                var securityRule = new SecurityRule
                {
                    Name = $"Port{port}",
                    Priority = 1000 + (++index),
                    Protocol = SecurityRuleProtocol.Tcp,
                    Access = SecurityRuleAccess.Allow,
                    Direction = SecurityRuleDirection.Inbound,
                    SourcePortRange = "*",
                    SourceAddressPrefix = "*",
                    DestinationPortRange = $"{port}",
                    DestinationAddressPrefix = "*",
                    Description = $"Port_{port}"
                };
                nsg.SecurityRules.Add(securityRule);
            }

            return new NetworkSecurityGroupBuilder(this, new NetworkSecurityGroupData(nsg));
        }

        /// <summary>
        /// List the network security groups for this network security group.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="NetworkSecurityGroup"/> that may take multiple service requests to iterate over. </returns>
        public Pageable<NetworkSecurityGroup> List(CancellationToken cancellationToken = default)
        {
            return new PhWrappingPageable<Azure.ResourceManager.Network.Models.NetworkSecurityGroup, NetworkSecurityGroup>(
                Operations.List(Id.Name, cancellationToken),
                r => new NetworkSecurityGroup(Parent, new NetworkSecurityGroupData(r)));
        }

        /// <summary>
        /// List the network security groups for this network security group.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="NetworkSecurityGroup"/> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<NetworkSecurityGroup> ListAsync(CancellationToken cancellationToken = default)
        {
            return new PhWrappingAsyncPageable<Azure.ResourceManager.Network.Models.NetworkSecurityGroup, NetworkSecurityGroup>(
                Operations.ListAsync(Id.Name, cancellationToken),
                r => new NetworkSecurityGroup(Parent, new NetworkSecurityGroupData(r)));
        }

        /// <summary>
        /// Filters the list of network security groups for this resource group represented as generic resources.
        /// </summary>
        /// <param name="nameFilter"> The substring to filter by. </param>
        /// <param name="top"> The number of items to truncate by. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="GenericResource"/> that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new ResourceFilterCollection(NetworkSecurityGroupOperations.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary>
        /// Filters the list of network security groups for this resource group represented as generic resources.
        /// </summary>
        /// <param name="nameFilter"> The substring to filter by. </param>
        /// <param name="top"> The number of items to truncate by. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="GenericResource"/> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new ResourceFilterCollection(NetworkSecurityGroupOperations.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <inheritdoc />
        public override Response<NetworkSecurityGroup> Get(string networkSecurityGroup, CancellationToken cancellationToken = default)
        {
            var response = Operations.Get(Id.ResourceGroupName, networkSecurityGroup, cancellationToken: cancellationToken);
            return Response.FromValue(new NetworkSecurityGroup(Parent, new NetworkSecurityGroupData(response.Value)), response.GetRawResponse());
        }

        /// <inheritdoc/>
        public override async Task<Response<NetworkSecurityGroup>> GetAsync(string networkSecurityGroup, CancellationToken cancellationToken = default)
        {
            var response = await Operations.GetAsync(Id.ResourceGroupName, networkSecurityGroup, null, cancellationToken);
            return Response.FromValue(new NetworkSecurityGroup(Parent, new NetworkSecurityGroupData(response.Value)), response.GetRawResponse());
        }
    }
}
