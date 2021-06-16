using Azure;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Network
{
    /// <summary>
    /// A class representing the operations that can be pefroemd over a specific <see cref="NetworkInterface"/>.
    /// </summary>
    public class NetworkInterfaceOperations : ResourceOperationsBase<ResourceGroupResourceIdentifier, NetworkInterface>
    {
        internal NetworkInterfaceOperations(GenericResourceOperations genericOperations)
            : base(genericOperations, genericOperations.Id)
        {
        }

        internal NetworkInterfaceOperations(ResourceGroupOperations resourceGroup, string nicName)
            : base(resourceGroup, resourceGroup.Id.AppendProviderResource( ResourceType.Namespace, ResourceType.Type, nicName))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkInterfaceOperations"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected NetworkInterfaceOperations(ResourceOperationsBase options, ResourceGroupResourceIdentifier id)
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
            Id.SubscriptionId,
            BaseUri,
            Credential,
            ClientOptions.Convert<NetworkManagementClientOptions>()).NetworkInterfaces;

        /// <inheritdoc/>
        public Response Delete(CancellationToken cancellationToken = default)
        {
            return Operations.StartDelete(Id.ResourceGroupName, Id.Name, cancellationToken)
                .WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            return (await Operations.StartDeleteAsync(Id.ResourceGroupName, Id.Name, cancellationToken))
                .WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public Operation StartDelete(CancellationToken cancellationToken = default)
        {
            return new PhVoidArmOperation(Operations.StartDelete(Id.ResourceGroupName, Id.Name, cancellationToken));
        }

        /// <inheritdoc/>
        public async Task<Operation> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            return new PhVoidArmOperation(await Operations.StartDeleteAsync(Id.ResourceGroupName, Id.Name, cancellationToken));
        }

        /// <inheritdoc/>
        public override Response<NetworkInterface> Get(CancellationToken cancellationToken = default)
        {
            var response = Operations.Get(Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
            return Response.FromValue(new NetworkInterface(this, new NetworkInterfaceData(response.Value)), response.GetRawResponse());
        }

        /// <inheritdoc/>
        public async override Task<Response<NetworkInterface>> GetAsync(CancellationToken cancellationToken = default)
        {
            var response = await Operations.GetAsync(Id.ResourceGroupName, Id.Name, null, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new NetworkInterface(this, new NetworkInterfaceData(response.Value)), response.GetRawResponse());
        }

        /// <inheritdoc/>
        public Response<NetworkInterface> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            var response = Operations.UpdateTags(Id.ResourceGroupName, Id.Name, patchable, cancellationToken);
            return Response.FromValue(new NetworkInterface(this, new NetworkInterfaceData(response.Value)), response.GetRawResponse());
        }

        /// <inheritdoc/>
        public async Task<Response<NetworkInterface>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            var response = await Operations.UpdateTagsAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new NetworkInterface(this, new NetworkInterfaceData(response.Value)), response.GetRawResponse());
        }

        /// <inheritdoc/>
        public Operation<NetworkInterface> StartAddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return new PhArmOperation<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                Operations.UpdateTags(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new NetworkInterface(this, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public async Task<Operation<NetworkInterface>> StartAddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return new PhArmOperation<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                await Operations.UpdateTagsAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new NetworkInterface(this, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public Response<NetworkInterface> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(tags);
            var response = Operations.UpdateTags(Id.ResourceGroupName, Id.Name, patchable, cancellationToken);
            return Response.FromValue(new NetworkInterface(this, new NetworkInterfaceData(response.Value)), response.GetRawResponse());
        }

        /// <inheritdoc/>
        public async Task<Response<NetworkInterface>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(tags);
            var response = await Operations.UpdateTagsAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new NetworkInterface(this, new NetworkInterfaceData(response.Value)), response.GetRawResponse());
        }

        /// <inheritdoc/>
        public Operation<NetworkInterface> StartSetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmOperation<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                Operations.UpdateTags(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new NetworkInterface(this, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public async Task<Operation<NetworkInterface>> StartSetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmOperation<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                await Operations.UpdateTagsAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new NetworkInterface(this, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public Response<NetworkInterface> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            var response = Operations.UpdateTags(Id.ResourceGroupName, Id.Name, patchable, cancellationToken);
            return Response.FromValue(new NetworkInterface(this, new NetworkInterfaceData(response.Value)), response.GetRawResponse());
        }

        /// <inheritdoc/>
        public async Task<Response<NetworkInterface>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            var response = await Operations.UpdateTagsAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new NetworkInterface(this, new NetworkInterfaceData(response.Value)), response.GetRawResponse());
        }

        /// <inheritdoc/>
        public Operation<NetworkInterface> StartRemoveTag(string key, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmOperation<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                Operations.UpdateTags(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new NetworkInterface(this, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public async Task<Operation<NetworkInterface>> StartRemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmOperation<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                await Operations.UpdateTagsAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
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
