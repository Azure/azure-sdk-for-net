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
    public class PublicIpAddressOperations : ResourceOperationsBase<PublicIpAddress>, ITaggableResource<PublicIpAddress>, IDeletableResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PublicIpAddressOperations"/> class.
        /// </summary>
        /// <param name="genericOperations"> An instance of <see cref="GenericResourceOperations"/> that has an id for a virtual machine. </param>
        internal PublicIpAddressOperations(GenericResourceOperations genericOperations)
            : base(genericOperations)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PublicIpAddressOperations"/> class.
        /// </summary>
        /// <param name="resourceGroup"> The client parameters to use in these operations. </param>
        /// <param name="publicIpName"> The public ip address name. </param>
        internal PublicIpAddressOperations(ResourceGroupOperations resourceGroup, string publicIpName)
            : base(resourceGroup, $"{resourceGroup.Id}/providers/Microsoft.Network/publicIpAddresses/{publicIpName}")
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
            Id.Subscription,
            BaseUri, 
            Credential,
            ClientOptions.Convert<NetworkManagementClientOptions>()).PublicIPAddresses;

        /// <summary>
        /// The operation to delete a public IP address.
        /// </summary>
        /// <returns> A response with the <see cref="ArmResponse{Response}"/> operation for this resource. </returns>
        public ArmResponse<Response> Delete()
        {
            return new ArmResponse(Operations.StartDelete(Id.ResourceGroup, Id.Name).WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult());
        }

        /// <summary>
        /// The operation to delete a public IP address.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmResponse{Response}"/> operation for this resource. </returns>
        public async Task<ArmResponse<Response>> DeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmResponse((await Operations.StartDeleteAsync(Id.ResourceGroup, Id.Name, cancellationToken)).WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult());
        }

        /// <summary>
        /// The operation to delete a public IP address.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <returns> An <see cref="ArmOperation{Response}"/> that allows polling for completion of the operation. </returns>
        public ArmOperation<Response> StartDelete(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(Operations.StartDelete(Id.ResourceGroup, Id.Name, cancellationToken));
        }

        /// <summary>
        /// The operation to delete a public IP address.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="ArmOperation{Response}"/> that allows polling for completion of the operation. </returns>
        public async Task<ArmOperation<Response>> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(await Operations.StartDeleteAsync(Id.ResourceGroup, Id.Name, cancellationToken));
        }

        /// <inheritdoc />
        public override ArmResponse<PublicIpAddress> Get()
        {
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(Operations.Get(Id.ResourceGroup, Id.Name),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc />
        public override async Task<ArmResponse<PublicIpAddress>> GetAsync(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(await Operations.GetAsync(Id.ResourceGroup, Id.Name, null, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <summary>
        /// Add a tag to a public IP address.
        /// If the tag already exists it will be modified.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <returns> An <see cref="ArmResponse{PublicIpAddress}"/> that allows polling for completion of the operation. </returns>
        public ArmResponse<PublicIpAddress> AddTag(string key, string value)
        {
            var resource = GetResource();
            var patchable = new TagsObject() { Tags = resource.Data.Tags };
            patchable.Tags[key] = value;
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <summary>
        /// Add a tag to a public IP address.
        /// If the tag already exists it will be modified.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="ArmResponse{PublicIpAddress}"/> that allows polling for completion of the operation. </returns>
        public async Task<ArmResponse<PublicIpAddress>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject() { Tags = resource.Data.Tags };
            patchable.Tags[key] = value;
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <summary>
        /// Add a tag to a public IP address.
        /// If the tag already exists it will be modified.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <returns> An <see cref="ArmOperation{PublicIpAddress}"/> that allows polling for completion of the operation. </returns>
        public ArmOperation<PublicIpAddress> StartAddTag(string key, string value)
        {
            var resource = GetResource();
            var patchable = new TagsObject() { Tags = resource.Data.Tags };
            patchable.Tags[key] = value;
            return new PhArmOperation<PublicIpAddress, PublicIPAddress>(Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <summary>
        /// Add a tag to a public IP address.
        /// If the tag already exists it will be modified.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="ArmOperation{PublicIpAddress}"/> that allows polling for completion of the operation. </returns>
        public async Task<ArmOperation<PublicIpAddress>> StartAddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject() { Tags = resource.Data.Tags };
            patchable.Tags[key] = value;
            return new PhArmOperation<PublicIpAddress, PublicIPAddress>(await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public ArmResponse<PublicIpAddress> SetTags(IDictionary<string, string> tags)
        {
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<PublicIpAddress>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public ArmOperation<PublicIpAddress> StartSetTags(IDictionary<string, string> tags)
        {
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmOperation<PublicIpAddress, PublicIPAddress>(Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<PublicIpAddress>> StartSetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmOperation<PublicIpAddress, PublicIPAddress>(await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public ArmResponse<PublicIpAddress> RemoveTag(string key)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<PublicIpAddress>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public ArmOperation<PublicIpAddress> StartRemoveTag(string key)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmOperation<PublicIpAddress, PublicIPAddress>(Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<PublicIpAddress>> StartRemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmOperation<PublicIpAddress, PublicIPAddress>(await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new PublicIpAddress(this, new PublicIPAddressData(n)));
        }
        
        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        public IEnumerable<LocationData> ListAvailableLocations()
        {
            return ListAvailableLocations(ResourceType);
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
