// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute
{
    /// <summary>
    /// A Class representing a CommunityGallery along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="CommunityGalleryResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetCommunityGalleryResource method.
    /// Otherwise you can get one from its parent resource <see cref="SubscriptionResource"/> using the GetCommunityGallery method.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class CommunityGalleryResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="CommunityGalleryResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="location"> The location. </param>
        /// <param name="publicGalleryName"> The publicGalleryName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, AzureLocation location, string publicGalleryName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly CommunityGalleryData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/locations/communityGalleries";

        /// <summary> Initializes a new instance of the <see cref="CommunityGalleryResource"/> class for mocking. </summary>
        protected CommunityGalleryResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="CommunityGalleryResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal CommunityGalleryResource(ArmClient client, CommunityGalleryData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="CommunityGalleryResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal CommunityGalleryResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual CommunityGalleryData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        private SubscriptionResource GetSubscriptionResource() => Client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(Id.SubscriptionId));

        /// <summary> Gets a collection of CommunityGalleryImageResources in the CommunityGallery. </summary>
        /// <returns> An object representing collection of CommunityGalleryImageResources and their operations over a CommunityGalleryImageResource. </returns>
        public virtual CommunityGalleryImageCollection GetCommunityGalleryImages()
        {
            return GetCachedClient(client => new CommunityGalleryImageCollection(client, Id));
        }

        /// <summary>
        /// Get a community gallery image.
        /// </summary>
        /// <param name="galleryImageName"> The name of the community gallery image definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="galleryImageName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<CommunityGalleryImageResource>> GetCommunityGalleryImageAsync(string galleryImageName, CancellationToken cancellationToken = default)
        {
            return await GetCommunityGalleryImages().GetAsync(galleryImageName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a community gallery image.
        /// </summary>
        /// <param name="galleryImageName"> The name of the community gallery image definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="galleryImageName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<CommunityGalleryImageResource> GetCommunityGalleryImage(string galleryImageName, CancellationToken cancellationToken = default)
        {
            return GetCommunityGalleryImages().Get(galleryImageName, cancellationToken);
        }

        /// <summary>
        /// Get a community gallery by gallery public name.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<CommunityGalleryResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            var response = await GetSubscriptionResource().GetCommunityGalleryAsync(new AzureLocation(Id.Parent.Name), Id.Name, cancellationToken).ConfigureAwait(false);
            response.Value.Id = CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name);
            return Response.FromValue(new CommunityGalleryResource(Client, response.Value), response.GetRawResponse());
        }

        /// <summary>
        /// Get a community gallery by gallery public name.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<CommunityGalleryResource> Get(CancellationToken cancellationToken = default)
        {
            var response = GetSubscriptionResource().GetCommunityGallery(new AzureLocation(Id.Parent.Name), Id.Name, cancellationToken);
            response.Value.Id = CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name);
            return Response.FromValue(new CommunityGalleryResource(Client, response.Value), response.GetRawResponse());
        }
    }
}
