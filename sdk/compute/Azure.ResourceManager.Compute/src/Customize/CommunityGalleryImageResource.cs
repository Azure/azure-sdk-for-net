// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Compute
{
    /// <summary>
    /// A Class representing a CommunityGalleryImage along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="CommunityGalleryImageResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetCommunityGalleryImageResource method.
    /// Otherwise you can get one from its parent resource <see cref="CommunityGalleryResource"/> using the GetCommunityGalleryImage method.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class CommunityGalleryImageResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="CommunityGalleryImageResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="location"> The location. </param>
        /// <param name="publicGalleryName"> The publicGalleryName. </param>
        /// <param name="galleryImageName"> The galleryImageName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, AzureLocation location, string publicGalleryName, string galleryImageName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _communityGalleryImageClientDiagnostics;
        private readonly CommunityGalleryImagesRestOperations _communityGalleryImageRestClient;
        private readonly CommunityGalleryImageData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/locations/communityGalleries/images";

        /// <summary> Initializes a new instance of the <see cref="CommunityGalleryImageResource"/> class for mocking. </summary>
        protected CommunityGalleryImageResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="CommunityGalleryImageResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal CommunityGalleryImageResource(ArmClient client, CommunityGalleryImageData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="CommunityGalleryImageResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal CommunityGalleryImageResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _communityGalleryImageClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Compute", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string communityGalleryImageApiVersion);
            _communityGalleryImageRestClient = new CommunityGalleryImagesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, communityGalleryImageApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual CommunityGalleryImageData Data
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

        /// <summary> Gets a collection of CommunityGalleryImageVersionResources in the CommunityGalleryImage. </summary>
        /// <returns> An object representing collection of CommunityGalleryImageVersionResources and their operations over a CommunityGalleryImageVersionResource. </returns>
        public virtual CommunityGalleryImageVersionCollection GetCommunityGalleryImageVersions()
        {
            return GetCachedClient(client => new CommunityGalleryImageVersionCollection(client, Id));
        }

        /// <summary>
        /// Get a community gallery image version.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}/versions/{galleryImageVersionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CommunityGalleryImageVersions_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CommunityGalleryImageVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="galleryImageVersionName"> The name of the community gallery image version. Needs to follow semantic version name pattern: The allowed characters are digit and period. Digits must be within the range of a 32-bit integer. Format: &lt;MajorVersion&gt;.&lt;MinorVersion&gt;.&lt;Patch&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageVersionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="galleryImageVersionName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<CommunityGalleryImageVersionResource>> GetCommunityGalleryImageVersionAsync(string galleryImageVersionName, CancellationToken cancellationToken = default)
        {
            return await GetCommunityGalleryImageVersions().GetAsync(galleryImageVersionName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a community gallery image version.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}/versions/{galleryImageVersionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CommunityGalleryImageVersions_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CommunityGalleryImageVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="galleryImageVersionName"> The name of the community gallery image version. Needs to follow semantic version name pattern: The allowed characters are digit and period. Digits must be within the range of a 32-bit integer. Format: &lt;MajorVersion&gt;.&lt;MinorVersion&gt;.&lt;Patch&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageVersionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="galleryImageVersionName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<CommunityGalleryImageVersionResource> GetCommunityGalleryImageVersion(string galleryImageVersionName, CancellationToken cancellationToken = default)
        {
            return GetCommunityGalleryImageVersions().Get(galleryImageVersionName, cancellationToken);
        }

        /// <summary>
        /// Get a community gallery image.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CommunityGalleryImages_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CommunityGalleryImageResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CommunityGalleryImageResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _communityGalleryImageClientDiagnostics.CreateScope("CommunityGalleryImageResource.Get");
            scope.Start();
            try
            {
                var response = await _communityGalleryImageRestClient.GetAsync(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Name), Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                response.Value.Id = CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Name), Id.Parent.Name, Id.Name);
                return Response.FromValue(new CommunityGalleryImageResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a community gallery image.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CommunityGalleryImages_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CommunityGalleryImageResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CommunityGalleryImageResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _communityGalleryImageClientDiagnostics.CreateScope("CommunityGalleryImageResource.Get");
            scope.Start();
            try
            {
                var response = _communityGalleryImageRestClient.Get(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Name), Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                response.Value.Id = CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Name), Id.Parent.Name, Id.Name);
                return Response.FromValue(new CommunityGalleryImageResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
