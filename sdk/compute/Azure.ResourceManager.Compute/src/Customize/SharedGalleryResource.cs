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
    /// A Class representing a SharedGallery along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="SharedGalleryResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetSharedGalleryResource method.
    /// Otherwise you can get one from its parent resource <see cref="SubscriptionResource"/> using the GetSharedGallery method.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SharedGalleryResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SharedGalleryResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="location"> The location. </param>
        /// <param name="galleryUniqueName"> The galleryUniqueName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, AzureLocation location, string galleryUniqueName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly SharedGalleryData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/locations/sharedGalleries";

        /// <summary> Initializes a new instance of the <see cref="SharedGalleryResource"/> class for mocking. </summary>
        protected SharedGalleryResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SharedGalleryResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SharedGalleryResource(ArmClient client, SharedGalleryData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SharedGalleryResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SharedGalleryResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual SharedGalleryData Data
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

        /// <summary> Gets a collection of SharedGalleryImageResources in the SharedGallery. </summary>
        /// <returns> An object representing collection of SharedGalleryImageResources and their operations over a SharedGalleryImageResource. </returns>
        public virtual SharedGalleryImageCollection GetSharedGalleryImages()
        {
            return GetCachedClient(client => new SharedGalleryImageCollection(client, Id));
        }

        /// <summary>
        /// Get a shared gallery image by subscription id or tenant id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images/{galleryImageName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SharedGalleryImages_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SharedGalleryImageResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="galleryImageName"> The name of the Shared Gallery Image Definition from which the Image Versions are to be listed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="galleryImageName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SharedGalleryImageResource>> GetSharedGalleryImageAsync(string galleryImageName, CancellationToken cancellationToken = default)
        {
            return await GetSharedGalleryImages().GetAsync(galleryImageName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a shared gallery image by subscription id or tenant id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images/{galleryImageName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SharedGalleryImages_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SharedGalleryImageResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="galleryImageName"> The name of the Shared Gallery Image Definition from which the Image Versions are to be listed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="galleryImageName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<SharedGalleryImageResource> GetSharedGalleryImage(string galleryImageName, CancellationToken cancellationToken = default)
        {
            return GetSharedGalleryImages().Get(galleryImageName, cancellationToken);
        }

        /// <summary>
        /// Get a shared gallery by subscription id or tenant id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SharedGalleries_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SharedGalleryResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<SharedGalleryResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await GetSubscriptionResource().GetSharedGalleryAsync(new AzureLocation(Id.Parent.Name), Id.Name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a shared gallery by subscription id or tenant id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SharedGalleries_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SharedGalleryResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<SharedGalleryResource> Get(CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResource().GetSharedGallery(new AzureLocation(Id.Parent.Name), Id.Name, cancellationToken);
        }
    }
}
