// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    /// A class representing the operations that can be performed over a specific NetworkSecurityGroup.
    /// </summary>
    public class PublicIpAddressOperations : ResourceOperationsBase<ResourceGroupResourceIdentifier, PublicIpAddress>, ITaggableResource<ResourceGroupResourceIdentifier, PublicIpAddress>, IDeletableResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PublicIpAddressOperations"/> class.
        /// </summary>
        /// <param name="genericOperations"> An instance of <see cref="GenericResourceOperations"/> that has an id for a virtual machine. </param>
        internal PublicIpAddressOperations(GenericResourceOperations genericOperations)
            : base(genericOperations, genericOperations.Id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PublicIpAddressOperations"/> class.
        /// </summary>
        /// <param name="resourceGroup"> The client parameters to use in these operations. </param>
        /// <param name="publicIpName"> The public ip address name. </param>
        internal PublicIpAddressOperations(ResourceGroupOperations resourceGroup, string publicIpName)
            : base(resourceGroup, resourceGroup.Id.AppendProviderResource(ResourceType.Namespace, ResourceType.Type, publicIpName))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PublicIpAddressOperations"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected PublicIpAddressOperations(ResourceOperationsBase options, ResourceIdentifier id)
            : base(options, id)
        {
        }

        /// <summary>
        /// Gets the resource type definition for a public IP address.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/publicIPAddresses";

        /// <inheritdoc />
        protected override ResourceType ValidResourceType => ResourceType;

        private PublicIPAddressesOperations Operations => new NetworkManagementClient(
            Id.SubscriptionId,
            BaseUri,
            Credential,
            ClientOptions.Convert<NetworkManagementClientOptions>()).PublicIPAddresses;

        /// <inheritdoc />
        public Response Delete(CancellationToken cancellationToken = default)
        {
            return Operations.StartDelete(Id.ResourceGroupName, Id.Name, cancellationToken)
                .WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            return (await Operations.StartDeleteAsync(Id.ResourceGroupName, Id.Name, cancellationToken))
                .WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public Operation StartDelete(CancellationToken cancellationToken = default)
        {
            return new PhVoidArmOperation(Operations.StartDelete(Id.ResourceGroupName, Id.Name, cancellationToken));
        }

        /// <inheritdoc />
        public async Task<Operation> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            return new PhVoidArmOperation(await Operations.StartDeleteAsync(Id.ResourceGroupName, Id.Name, cancellationToken));
        }

        /// <inheritdoc />
        public override Response<PublicIpAddress> Get(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<PublicIpAddress, Azure.ResourceManager.Network.Models.PublicIPAddress>(Operations.Get(Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc />
        public override async Task<Response<PublicIpAddress>> GetAsync(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<PublicIpAddress, Azure.ResourceManager.Network.Models.PublicIPAddress>(await Operations.GetAsync(Id.ResourceGroupName, Id.Name, null, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc />
        public Response<PublicIpAddress> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return new PhArmResponse<PublicIpAddress, Azure.ResourceManager.Network.Models.PublicIPAddress>(Operations.UpdateTags(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc />
        public async Task<Response<PublicIpAddress>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return new PhArmResponse<PublicIpAddress, Azure.ResourceManager.Network.Models.PublicIPAddress>(await Operations.UpdateTagsAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc />
        public Operation<PublicIpAddress> StartAddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return new PhArmOperation<PublicIpAddress, Azure.ResourceManager.Network.Models.PublicIPAddress>(Operations.UpdateTags(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc />
        public async Task<Operation<PublicIpAddress>> StartAddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return new PhArmOperation<PublicIpAddress, Azure.ResourceManager.Network.Models.PublicIPAddress>(await Operations.UpdateTagsAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public Response<PublicIpAddress> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmResponse<PublicIpAddress, Azure.ResourceManager.Network.Models.PublicIPAddress>(Operations.UpdateTags(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public async Task<Response<PublicIpAddress>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmResponse<PublicIpAddress, Azure.ResourceManager.Network.Models.PublicIPAddress>(await Operations.UpdateTagsAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public Operation<PublicIpAddress> StartSetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmOperation<PublicIpAddress, Azure.ResourceManager.Network.Models.PublicIPAddress>(Operations.UpdateTags(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public async Task<Operation<PublicIpAddress>> StartSetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmOperation<PublicIpAddress, Azure.ResourceManager.Network.Models.PublicIPAddress>(await Operations.UpdateTagsAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public Response<PublicIpAddress> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmResponse<PublicIpAddress, Azure.ResourceManager.Network.Models.PublicIPAddress>(Operations.UpdateTags(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public async Task<Response<PublicIpAddress>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmResponse<PublicIpAddress, Azure.ResourceManager.Network.Models.PublicIPAddress>(await Operations.UpdateTagsAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public Operation<PublicIpAddress> StartRemoveTag(string key, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmOperation<PublicIpAddress, Azure.ResourceManager.Network.Models.PublicIPAddress>(Operations.UpdateTags(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public async Task<Operation<PublicIpAddress>> StartRemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new Azure.ResourceManager.Network.Models.TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmOperation<PublicIpAddress, Azure.ResourceManager.Network.Models.PublicIPAddress>(await Operations.UpdateTagsAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
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
