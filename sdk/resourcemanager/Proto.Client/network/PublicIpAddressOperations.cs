// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        public ArmResponse<Response> Delete(CancellationToken cancellationToken = default)
        {
            return new ArmResponse(Operations.StartDelete(Id.ResourceGroupName, Id.Name, cancellationToken)
                .WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult());
        }

        /// <inheritdoc />
        public async Task<ArmResponse<Response>> DeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmResponse((await Operations.StartDeleteAsync(Id.ResourceGroupName, Id.Name, cancellationToken))
                .WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult());
        }

        /// <inheritdoc />
        public ArmOperation<Response> StartDelete(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(Operations.StartDelete(Id.ResourceGroupName, Id.Name, cancellationToken));
        }

        /// <inheritdoc />
        public async Task<ArmOperation<Response>> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(await Operations.StartDeleteAsync(Id.ResourceGroupName, Id.Name, cancellationToken));
        }

        /// <inheritdoc />
        public override ArmResponse<PublicIpAddress> Get(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(Operations.Get(Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc />
        public override async Task<ArmResponse<PublicIpAddress>> GetAsync(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(await Operations.GetAsync(Id.ResourceGroupName, Id.Name, null, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc />
        public ArmResponse<PublicIpAddress> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(Operations.UpdateTags(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc />
        public async Task<ArmResponse<PublicIpAddress>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(await Operations.UpdateTagsAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc />
        public ArmOperation<PublicIpAddress> StartAddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return new PhArmOperation<PublicIpAddress, PublicIPAddress>(Operations.UpdateTags(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc />
        public async Task<ArmOperation<PublicIpAddress>> StartAddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return new PhArmOperation<PublicIpAddress, PublicIPAddress>(await Operations.UpdateTagsAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public ArmResponse<PublicIpAddress> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(Operations.UpdateTags(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<PublicIpAddress>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(await Operations.UpdateTagsAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public ArmOperation<PublicIpAddress> StartSetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmOperation<PublicIpAddress, PublicIPAddress>(Operations.UpdateTags(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<PublicIpAddress>> StartSetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmOperation<PublicIpAddress, PublicIPAddress>(await Operations.UpdateTagsAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public ArmResponse<PublicIpAddress> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(Operations.UpdateTags(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<PublicIpAddress>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(await Operations.UpdateTagsAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public ArmOperation<PublicIpAddress> StartRemoveTag(string key, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmOperation<PublicIpAddress, PublicIPAddress>(Operations.UpdateTags(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<PublicIpAddress>> StartRemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmOperation<PublicIpAddress, PublicIPAddress>(await Operations.UpdateTagsAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
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
