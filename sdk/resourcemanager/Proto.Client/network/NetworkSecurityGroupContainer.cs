// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Network
{
    /// <summary>
    /// A class representing collection of NetworkSecurityGroup and their operations over a resource group.
    /// </summary>
    public class NetworkSecurityGroupContainer : ResourceContainerBase<NetworkSecurityGroup, NetworkSecurityGroupData>
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
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        private NetworkSecurityGroupsOperations Operations => new NetworkManagementClient(
            Id.Subscription,
            BaseUri,
            Credential,
            ClientOptions.Convert<NetworkManagementClientOptions>()).NetworkSecurityGroups;

        /// <inheritdoc />
        public override ArmResponse<NetworkSecurityGroup> CreateOrUpdate(string name, NetworkSecurityGroupData resourceDetails)
        {
            var operation = Operations.StartCreateOrUpdate(Id.ResourceGroup, name, resourceDetails.Model);
            return new PhArmResponse<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(
                operation.WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult(),
                n => new NetworkSecurityGroup(Parent, new NetworkSecurityGroupData(n)));
        }

        /// <inheritdoc />
        public override async Task<ArmResponse<NetworkSecurityGroup>> CreateOrUpdateAsync(string name, NetworkSecurityGroupData resourceDetails, CancellationToken cancellationToken = default)
        {
            var operation = await Operations.StartCreateOrUpdateAsync(Id.ResourceGroup, name, resourceDetails.Model, cancellationToken).ConfigureAwait(false);
            return new PhArmResponse<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(
                await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false),
                n => new NetworkSecurityGroup(Parent, new NetworkSecurityGroupData(n)));
        }

        /// <inheritdoc />
        public override ArmOperation<NetworkSecurityGroup> StartCreateOrUpdate(string name, NetworkSecurityGroupData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(
                Operations.StartCreateOrUpdate(Id.ResourceGroup, name, resourceDetails.Model, cancellationToken),
                n => new NetworkSecurityGroup(Parent, new NetworkSecurityGroupData(n)));
        }

        /// <inheritdoc />
        public override async Task<ArmOperation<NetworkSecurityGroup>> StartCreateOrUpdateAsync(string name, NetworkSecurityGroupData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(
                await Operations.StartCreateOrUpdateAsync(Id.ResourceGroup, name, resourceDetails.Model, cancellationToken).ConfigureAwait(false),
                n => new NetworkSecurityGroup(Parent, new NetworkSecurityGroupData(n)));
        }

        /// <summary>
        /// Construct an object used to create a network security group.
        /// </summary>
        /// <param name="locationData"> The location to create the network security group. </param>
        /// <param name="openPorts"> The location to create the network security group. </param>
        /// <returns> Object used to create a <see cref="NetworkSecurityGroup"/>. </returns>
        public ArmBuilder<NetworkSecurityGroup, NetworkSecurityGroupData> Construct(LocationData locationData = null, params int[] openPorts)
        {
            var parent = GetParentResource<ResourceGroup, ResourceGroupOperations>();
            var nsg = new Azure.ResourceManager.Network.Models.NetworkSecurityGroup
            {
                Location = locationData ?? parent.Data.Location
            };
            var index = 0;
            nsg.SecurityRules = openPorts.Select(openPort => new SecurityRule
            {
                Name = $"Port{openPort}",
                Priority = 1000 + (++index),
                Protocol = SecurityRuleProtocol.Tcp,
                Access = SecurityRuleAccess.Allow,
                Direction = SecurityRuleDirection.Inbound,
                SourcePortRange = "*",
                SourceAddressPrefix = "*",
                DestinationPortRange = $"{openPort}",
                DestinationAddressPrefix = "*",
                Description = $"Port_{openPort}"
            }).ToList();

            return new ArmBuilder<NetworkSecurityGroup, NetworkSecurityGroupData>(this, new NetworkSecurityGroupData(nsg));
        }

        /// <summary>
        /// Construct an object used to create a network security group.
        /// </summary>
        /// <param name="openPorts"> The location to create the network security group. </param>
        /// <returns> Object used to create a <see cref="NetworkSecurityGroup"/>. </returns>
        public ArmBuilder<NetworkSecurityGroup, NetworkSecurityGroupData> Construct(params int[] openPorts)
        {
            var parent = GetParentResource<ResourceGroup, ResourceGroupOperations>();
            var nsg = new Azure.ResourceManager.Network.Models.NetworkSecurityGroup
            {
                Location = parent.Data.Location,
            };
            var index = 0;
            nsg.SecurityRules = openPorts.Select(openPort => new SecurityRule
            {
                Name = $"Port{openPort}",
                Priority = 1000 + (++index),
                Protocol = SecurityRuleProtocol.Tcp,
                Access = SecurityRuleAccess.Allow,
                Direction = SecurityRuleDirection.Inbound,
                SourcePortRange = "*",
                SourceAddressPrefix = "*",
                DestinationPortRange = $"{openPort}",
                DestinationAddressPrefix = "*",
                Description = $"Port_{openPort}"
            }).ToList();

            return new ArmBuilder<NetworkSecurityGroup, NetworkSecurityGroupData>(this, new NetworkSecurityGroupData(nsg));
        }

        /// <summary>
        /// List the network security groups for this resource group.
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
        /// List the network security groups for this resource group.
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
        /// <param name="filter"> The substring to filter by. </param>
        /// <param name="top"> The number of items to truncate by. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="GenericResource"/> that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListByName(string filter, int? top = null, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new ResourceFilterCollection(NetworkSecurityGroupOperations.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary>
        /// Filters the list of network security groups for this resource group represented as generic resources.
        /// </summary>
        /// <param name="filter"> The substring to filter by. </param>
        /// <param name="top"> The number of items to truncate by. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="GenericResource"/> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListByNameAsync(string filter, int? top = null, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new ResourceFilterCollection(NetworkSecurityGroupOperations.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary>
        /// Filters the list of network security groups for this resource group represented as generic resources.
        /// Makes an additional network call to retrieve the full data model for each network security group.
        /// </summary>
        /// <param name="filter"> The substring to filter by. </param>
        /// <param name="top"> The number of items to truncate by. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="NetworkSecurityGroup"/> that may take multiple service requests to iterate over. </returns>
        public Pageable<NetworkSecurityGroup> ListByNameExpanded(string filter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListByName(filter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, NetworkSecurityGroup>(results, s => new NetworkSecurityGroupOperations(s).Get().Value);
        }

        /// <summary>
        /// Filters the list of network security groups for this resource group represented as generic resources.
        /// Makes an additional network call to retrieve the full data model for each network security group.
        /// </summary>
        /// <param name="filter"> The substring to filter by. </param>
        /// <param name="top"> The number of items to truncate by. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="NetworkSecurityGroup"/> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<NetworkSecurityGroup> ListByNameExpandedAsync(string filter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListByNameAsync(filter, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, NetworkSecurityGroup>(results, s => new NetworkSecurityGroupOperations(s).Get().Value);
        }

        /// <inheritdoc />
        public override ArmResponse<NetworkSecurityGroup> Get(string networkSecurityGroup)
        {
            return new PhArmResponse<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(Operations.Get(Id.ResourceGroup, networkSecurityGroup),
                g => new NetworkSecurityGroup(Parent, new NetworkSecurityGroupData(g)));
        }

        /// <inheritdoc/>
        public override async Task<ArmResponse<NetworkSecurityGroup>> GetAsync(string networkSecurityGroup, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(await Operations.GetAsync(Id.ResourceGroup, networkSecurityGroup, null, cancellationToken),
                    g => new NetworkSecurityGroup(Parent, new NetworkSecurityGroupData(g)));
        }     
    }
}
