using Azure;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Core;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Proto.Network
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific virtual nerwork.
    /// </summary>
    public class VirtualNetworkOperations : ResourceOperationsBase<VirtualNetwork>, ITaggableResource<VirtualNetwork>, IDeletableResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualNetworkOperations"/> class.
        /// </summary>
        /// <param name="genericOperations"> An instance of <see cref="GenericResourceOperations"/> that has an id for a virtual nerwork. </param>
        internal VirtualNetworkOperations(GenericResourceOperations genericOperations)
            : base(genericOperations)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualNetworkOperations"/> class.
        /// </summary>
        /// <param name="resourceGroup"> The client parameters to use in these operations. </param>
        /// <param name="vnetName"> The name of the virtual network to use. </param>
        internal VirtualNetworkOperations(ResourceGroupOperations resourceGroup, string vnetName)
            : base(resourceGroup, $"{resourceGroup.Id}/providers/Microsoft.Network/virtualNetworks/{vnetName}")
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualNetworkOperations"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected VirtualNetworkOperations(ResourceOperationsBase options, ResourceIdentifier id)
            : base(options, id)
        {
        }

        /// <summary>
        /// Gets the resource type definition for a virtual nerwork.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/virtualNetworks";

        /// <summary>
        /// Gets the valid resource type definition for a virtual nerwork.
        /// </summary>
        protected override ResourceType ValidResourceType => ResourceType;

        private VirtualNetworksOperations Operations => new NetworkManagementClient(
            Id.Subscription,
            BaseUri,
            Credential,
            ClientOptions.Convert<NetworkManagementClientOptions>()).VirtualNetworks;

        /// <summary>
        /// The operation to delete a virtual nerwork. 
        /// </summary>
        /// <returns> A response with the <see cref="ArmResponse{Response}"/> operation for this resource. </returns>
        public ArmResponse<Response> Delete()
        {
            return new ArmResponse(Operations.StartDelete(Id.ResourceGroup, Id.Name).WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult());
        }

        /// <summary>
        /// The operation to delete a virtual nerwork. 
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmResponse{Response}"/> operation for this resource. </returns>
        public async Task<ArmResponse<Response>> DeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmResponse((await Operations.StartDeleteAsync(Id.ResourceGroup, Id.Name, cancellationToken)).WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult());
        }

        /// <summary>
        /// The operation to delete a virtual nerwork.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning"> Details on long running operation object. </see>
        /// </remarks>
        /// <returns> An <see cref="ArmOperation{Response}"/> that allows polling for completion of the operation. </returns>
        public ArmOperation<Response> StartDelete(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(Operations.StartDelete(Id.ResourceGroup, Id.Name, cancellationToken));
        }

        /// <summary>
        /// The operation to delete a virtual nerwork.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning"> Details on long running operation object. </see>
        /// </remarks>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="ArmOperation{Response}"/> that allows polling for completion of the operation. </returns>
        public async Task<ArmOperation<Response>> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(await Operations.StartDeleteAsync(Id.ResourceGroup, Id.Name, cancellationToken));
        }

        /// <inheritdoc/>
        public override ArmResponse<VirtualNetwork> Get()
        {
            return new PhArmResponse<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(Operations.Get(Id.ResourceGroup, Id.Name),
                n => new VirtualNetwork(this, new VirtualNetworkData(n)));
        }

        /// <inheritdoc/>
        public async override Task<ArmResponse<VirtualNetwork>> GetAsync(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(await Operations.GetAsync(Id.ResourceGroup, Id.Name, null, cancellationToken),
                n => new VirtualNetwork(this, new VirtualNetworkData(n)));
        }

        /// <summary>
        /// Adds a tag to a virtual network.
        /// If the tag already exists it will be modified.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning"> Details on long running operation object. </see>
        /// </remarks>
        /// <returns> An <see cref="ArmResponse{VirtualNetwork}"/> that allows polling for completion of the operation. </returns>
        public ArmResponse<VirtualNetwork> AddTag(string key, string value)
        {
            var resource = GetResource();
            var patchable = new TagsObject() { Tags = resource.Data.Tags };
            patchable.Tags[key] = value;
            return new PhArmResponse<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable),
                n => new VirtualNetwork(this, new VirtualNetworkData(n)));
        }

        /// <summary>
        /// Adds a tag to a virtual network.
        /// If the tag already exists it will be modified.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning"> Details on long running operation object. </see>
        /// </remarks>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="ArmResponse{VirtualNetwork}"/> that allows polling for completion of the operation. </returns>
        public async Task<ArmResponse<VirtualNetwork>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject() { Tags = resource.Data.Tags };
            patchable.Tags[key] = value;
            return new PhArmResponse<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new VirtualNetwork(this, new VirtualNetworkData(n)));
        }

        /// <summary>
        /// Adds a tag to a virtual network.
        /// If the tag already exists it will be modified.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning"> Details on long running operation object. </see>
        /// </remarks>
        /// <returns> An <see cref="ArmOperation{VirtualNetwork}"/> that allows polling for completion of the operation. </returns>
        public ArmOperation<VirtualNetwork> StartAddTag(string key, string value)
        {
            var resource = GetResource();
            var patchable = new TagsObject() { Tags = resource.Data.Tags };
            patchable.Tags[key] = value;
            return new PhArmOperation<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable),
                n => new VirtualNetwork(this, new VirtualNetworkData(n)));
        }

        /// <summary>
        /// Adds a tag to a virtual network.
        /// If the tag already exists it will be modified.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning"> Details on long running operation object. </see>
        /// </remarks>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="ArmOperation{VirtualNetwork}"/> that allows polling for completion of the operation. </returns>
        public async Task<ArmOperation<VirtualNetwork>> StartAddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject() { Tags = resource.Data.Tags };
            patchable.Tags[key] = value;
            return new PhArmOperation<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new VirtualNetwork(this, new VirtualNetworkData(n)));
        }

        /// <summary>
        /// Gets a subnet in the virtual nerwork.
        /// </summary>
        /// <param name="subnet"> The name of the subnet. </param>
        /// <returns> An instance of SubnetOperations. </returns>
        public SubnetOperations GetSubnetOperations(string subnet)
        {
            return new SubnetOperations(this, subnet);
        }

        /// <summary>
        /// Gets a list of subnet in the virtual nerwork.
        /// </summary>
        /// <returns> An object representing collection of subnets and their operations over a virtual network. </returns>
        public SubnetContainer GetSubnetContainer()
        {
            return new SubnetContainer(this);
        }

        /// <inheritdoc/>
        public ArmResponse<VirtualNetwork> SetTags(IDictionary<string, string> tags)
        {
            var resource = GetResource();
            var patchable = new TagsObject() { Tags = resource.Data.Tags };
            ReplaceTags(tags, patchable.Tags);
            return new PhArmResponse<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable),
                n => new VirtualNetwork(this, new VirtualNetworkData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<VirtualNetwork>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject() { Tags = resource.Data.Tags };
            ReplaceTags(tags, patchable.Tags);
            return new PhArmResponse<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new VirtualNetwork(this, new VirtualNetworkData(n)));
        }

        /// <inheritdoc/>
        public ArmOperation<VirtualNetwork> StartSetTags(IDictionary<string, string> tags)
        {
            var resource = GetResource();
            var patchable = new TagsObject() { Tags = resource.Data.Tags };
            ReplaceTags(tags, patchable.Tags);
            return new PhArmOperation<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable),
                n => new VirtualNetwork(this, new VirtualNetworkData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<VirtualNetwork>> StartSetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject() { Tags = resource.Data.Tags };
            ReplaceTags(tags, patchable.Tags);
            return new PhArmOperation<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new VirtualNetwork(this, new VirtualNetworkData(n)));
        }

        /// <inheritdoc/>
        public ArmResponse<VirtualNetwork> RemoveTag(string key)
        {
            var resource = GetResource();
            var patchable = new TagsObject() { Tags = resource.Data.Tags };
            DeleteTag(key, patchable.Tags);
            return new PhArmResponse<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable),
                n => new VirtualNetwork(this, new VirtualNetworkData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<VirtualNetwork>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject() { Tags = resource.Data.Tags };
            DeleteTag(key, patchable.Tags);
            return new PhArmResponse<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new VirtualNetwork(this, new VirtualNetworkData(n)));
        }

        /// <inheritdoc/>
        public ArmOperation<VirtualNetwork> StartRemoveTag(string key)
        {
            var resource = GetResource();
            var patchable = new TagsObject() { Tags = resource.Data.Tags };
            DeleteTag(key, patchable.Tags);
            return new PhArmOperation<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable),
                n => new VirtualNetwork(this, new VirtualNetworkData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<VirtualNetwork>> StartRemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject() { Tags = resource.Data.Tags };
            DeleteTag(key, patchable.Tags);
            return new PhArmOperation<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new VirtualNetwork(this, new VirtualNetworkData(n)));
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        public IEnumerable<LocationData> ListAvailableLocations()
        {
            var pageableProvider = ResourcesClient.Providers.List(expand: "metadata");
            var vnProvider = pageableProvider.FirstOrDefault(p => string.Equals(p.Namespace, ResourceType?.Namespace, StringComparison.InvariantCultureIgnoreCase));
            var vnResource = vnProvider.ResourceTypes.FirstOrDefault(r => ResourceType.Type.Equals(r.ResourceType));
            return vnResource.Locations.Select(l => (LocationData)l);
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of location that may take multiple service requests to iterate over. </returns>
        /// <exception cref="InvalidOperationException"> The default subscription id is null. </exception>
        public async Task<IEnumerable<LocationData>> ListAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            var asyncpageableProvider = ResourcesClient.Providers.ListAsync(expand: "metadata", cancellationToken: cancellationToken);
            var vnProvider = await asyncpageableProvider.FirstOrDefaultAsync(p => string.Equals(p.Namespace, ResourceType?.Namespace, StringComparison.InvariantCultureIgnoreCase));
            var vnResource = vnProvider.ResourceTypes.FirstOrDefault(r => ResourceType.Type.Equals(r.ResourceType));
            return vnResource.Locations.Select(l => (LocationData)l);
        }
    }
}
