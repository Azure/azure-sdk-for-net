using Azure;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Network
{
    /// <summary>
    /// A class representing the operations that can be pefroemd over a specific <see cref="NetworkInterface"/>.
    /// </summary>
    public class NetworkInterfaceOperations : ResourceOperationsBase<NetworkInterface>, ITaggableResource<NetworkInterface>, IDeletableResource
    {
        internal NetworkInterfaceOperations(GenericResourceOperations genericOperations)
            : base(genericOperations)
        {
        }

        internal NetworkInterfaceOperations(ResourceGroupOperations resourceGroup, string nicName)
            : base(resourceGroup, $"{resourceGroup.Id}/providers/Microsoft.Network/networkInterfaces/{nicName}")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkInterfaceOperations"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected NetworkInterfaceOperations(ResourceOperationsBase options, ResourceIdentifier id)
            : base(options, id)
        {
        }

        /// <summary>
        /// The resource type of a <see cref="NetworkInterface"/>.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/networkInterfaces";

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceType;

        internal NetworkInterfacesOperations Operations => new NetworkManagementClient(
            Id.Subscription,
            BaseUri,
            Credential,
            ClientOptions.Convert<NetworkManagementClientOptions>()).NetworkInterfaces;

        /// <inheritdoc/>
        public ArmResponse<Response> Delete(CancellationToken cancellationToken = default)
        {
            return new ArmResponse(Operations.StartDelete(Id.ResourceGroup, Id.Name, cancellationToken)
                .WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult());
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<Response>> DeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmResponse((await Operations.StartDeleteAsync(Id.ResourceGroup, Id.Name, cancellationToken))
                .WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult());
        }

        /// <inheritdoc/>
        public ArmOperation<Response> StartDelete(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(Operations.StartDelete(Id.ResourceGroup, Id.Name, cancellationToken));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<Response>> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(await Operations.StartDeleteAsync(Id.ResourceGroup, Id.Name, cancellationToken));
        }

        /// <inheritdoc/>
        public override ArmResponse<NetworkInterface> Get(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                Operations.Get(Id.ResourceGroup, Id.Name, cancellationToken: cancellationToken),
                n => new NetworkInterface(this, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public async override Task<ArmResponse<NetworkInterface>> GetAsync(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                await Operations.GetAsync(Id.ResourceGroup, Id.Name, null, cancellationToken),
                n => new NetworkInterface(this, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public ArmResponse<NetworkInterface> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return new PhArmResponse<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new NetworkInterface(this, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<NetworkInterface>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return new PhArmResponse<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new NetworkInterface(this, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public ArmOperation<NetworkInterface> StartAddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return new PhArmOperation<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new NetworkInterface(this, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<NetworkInterface>> StartAddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return new PhArmOperation<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new NetworkInterface(this, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public ArmResponse<NetworkInterface> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmResponse<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new NetworkInterface(this, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<NetworkInterface>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmResponse<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new NetworkInterface(this, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public ArmOperation<NetworkInterface> StartSetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmOperation<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new NetworkInterface(this, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<NetworkInterface>> StartSetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmOperation<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new NetworkInterface(this, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public ArmResponse<NetworkInterface> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmResponse<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new NetworkInterface(this, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<NetworkInterface>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmResponse<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new NetworkInterface(this, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public ArmOperation<NetworkInterface> StartRemoveTag(string key, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmOperation<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new NetworkInterface(this, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<NetworkInterface>> StartRemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmOperation<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new NetworkInterface(this, new NetworkInterfaceData(n)));
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        public IEnumerable<LocationData> ListAvailableLocations(CancellationToken cancellationToken = default)
        {
            return ListAvailableLocations(ResourceType, cancellationToken);
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of location that may take multiple service requests to iterate over. </returns>
        /// <exception cref="InvalidOperationException"> The default subscription id is null. </exception>
        public async Task<IEnumerable<LocationData>> ListAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            return await ListAvailableLocationsAsync(ResourceType, cancellationToken);
        }
    }
}
