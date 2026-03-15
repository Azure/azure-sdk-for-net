// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Compute
{
    /// <summary>
    /// A class representing a collection of <see cref="CommunityGalleryImageResource"/> and their operations.
    /// Each <see cref="CommunityGalleryImageResource"/> in the collection will belong to the same instance of <see cref="CommunityGalleryResource"/>.
    /// To get a <see cref="CommunityGalleryImageCollection"/> instance call the GetCommunityGalleryImages method from an instance of <see cref="CommunityGalleryResource"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class CommunityGalleryImageCollection : ArmCollection, IEnumerable<CommunityGalleryImageResource>, IAsyncEnumerable<CommunityGalleryImageResource>
    {
        /// <summary> Initializes a new instance of the <see cref="CommunityGalleryImageCollection"/> class for mocking. </summary>
        protected CommunityGalleryImageCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="CommunityGalleryImageCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal CommunityGalleryImageCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _communityGalleryImagesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Compute", CommunityGalleryImageResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(CommunityGalleryImageResource.ResourceType, out string communityGalleryImageApiVersion);
            _communityGalleryImagesRestClient = new CommunityGalleryImages(_communityGalleryImagesClientDiagnostics, Pipeline, Endpoint, communityGalleryImageApiVersion);
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != CommunityGalleryResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, CommunityGalleryResource.ResourceType), nameof(id));
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
        /// <param name="galleryImageName"> The name of the community gallery image definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryImageName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageName"/> is null. </exception>
        public virtual async Task<Response<CommunityGalleryImageResource>> GetAsync(string galleryImageName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryImageName, nameof(galleryImageName));

            using var scope = _communityGalleryImagesClientDiagnostics.CreateScope("CommunityGalleryImageCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _communityGalleryImagesRestClient.CreateGetRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<CommunityGalleryImageData> response = Response.FromValue(CommunityGalleryImageData.FromResponse(result), result);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                response.Value.Id = CommunityGalleryImageResource.CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName);
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
        /// <param name="galleryImageName"> The name of the community gallery image definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryImageName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageName"/> is null. </exception>
        public virtual Response<CommunityGalleryImageResource> Get(string galleryImageName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryImageName, nameof(galleryImageName));

            using var scope = _communityGalleryImagesClientDiagnostics.CreateScope("CommunityGalleryImageCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _communityGalleryImagesRestClient.CreateGetRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<CommunityGalleryImageData> response = Response.FromValue(CommunityGalleryImageData.FromResponse(result), result);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                response.Value.Id = CommunityGalleryImageResource.CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName);
                return Response.FromValue(new CommunityGalleryImageResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List community gallery images inside a gallery.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CommunityGalleryImages_List</description>
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
        /// <returns> An async collection of <see cref="CommunityGalleryImageResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<CommunityGalleryImageResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _communityGalleryImagesRestClient.CreateGetAllRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, null);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _communityGalleryImagesRestClient.CreateNextGetAllRequest(new Uri(nextLink), Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, null);
            return GalleryPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new CommunityGalleryImageResource(Client, DeserializeCommunityGalleryImageData(e)), _communityGalleryImagesClientDiagnostics, Pipeline, "CommunityGalleryImageCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// List community gallery images inside a gallery.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CommunityGalleryImages_List</description>
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
        /// <returns> A collection of <see cref="CommunityGalleryImageResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<CommunityGalleryImageResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _communityGalleryImagesRestClient.CreateGetAllRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, null);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _communityGalleryImagesRestClient.CreateNextGetAllRequest(new Uri(nextLink), Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, null);
            return GalleryPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new CommunityGalleryImageResource(Client, DeserializeCommunityGalleryImageData(e)), _communityGalleryImagesClientDiagnostics, Pipeline, "CommunityGalleryImageCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        private CommunityGalleryImageData DeserializeCommunityGalleryImageData(JsonElement element)
        {
            var data = CommunityGalleryImageData.DeserializeCommunityGalleryImageData(element, ModelSerializationExtensions.WireOptions);
            data.Id = CommunityGalleryImageResource.CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, data.Name);
            return data;
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        /// <param name="galleryImageName"> The name of the community gallery image definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryImageName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string galleryImageName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryImageName, nameof(galleryImageName));

            using var scope = _communityGalleryImagesClientDiagnostics.CreateScope("CommunityGalleryImageCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _communityGalleryImagesRestClient.CreateGetRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName, context);
                await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(!message.Response.IsError, message.Response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        /// <param name="galleryImageName"> The name of the community gallery image definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryImageName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageName"/> is null. </exception>
        public virtual Response<bool> Exists(string galleryImageName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryImageName, nameof(galleryImageName));

            using var scope = _communityGalleryImagesClientDiagnostics.CreateScope("CommunityGalleryImageCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _communityGalleryImagesRestClient.CreateGetRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName, context);
                Pipeline.Send(message, cancellationToken);
                return Response.FromValue(!message.Response.IsError, message.Response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
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
        /// <param name="galleryImageName"> The name of the community gallery image definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryImageName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageName"/> is null. </exception>
        public virtual async Task<NullableResponse<CommunityGalleryImageResource>> GetIfExistsAsync(string galleryImageName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryImageName, nameof(galleryImageName));

            using var scope = _communityGalleryImagesClientDiagnostics.CreateScope("CommunityGalleryImageCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _communityGalleryImagesRestClient.CreateGetRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName, context);
                await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                if (message.Response.IsError)
                    return new NoValueResponse<CommunityGalleryImageResource>(message.Response);
                Response<CommunityGalleryImageData> response = Response.FromValue(CommunityGalleryImageData.FromResponse(message.Response), message.Response);
                response.Value.Id = CommunityGalleryImageResource.CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName);
                return Response.FromValue(new CommunityGalleryImageResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
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
        /// <param name="galleryImageName"> The name of the community gallery image definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryImageName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageName"/> is null. </exception>
        public virtual NullableResponse<CommunityGalleryImageResource> GetIfExists(string galleryImageName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryImageName, nameof(galleryImageName));

            using var scope = _communityGalleryImagesClientDiagnostics.CreateScope("CommunityGalleryImageCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _communityGalleryImagesRestClient.CreateGetRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName, context);
                Pipeline.Send(message, cancellationToken);
                if (message.Response.IsError)
                    return new NoValueResponse<CommunityGalleryImageResource>(message.Response);
                Response<CommunityGalleryImageData> response = Response.FromValue(CommunityGalleryImageData.FromResponse(message.Response), message.Response);
                response.Value.Id = CommunityGalleryImageResource.CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName);
                return Response.FromValue(new CommunityGalleryImageResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<CommunityGalleryImageResource> IEnumerable<CommunityGalleryImageResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<CommunityGalleryImageResource> IAsyncEnumerable<CommunityGalleryImageResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}