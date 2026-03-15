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
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    /// <summary>
    /// A class representing a collection of <see cref="SharedGalleryImageResource"/> and their operations.
    /// Each <see cref="SharedGalleryImageResource"/> in the collection will belong to the same instance of <see cref="SharedGalleryResource"/>.
    /// To get a <see cref="SharedGalleryImageCollection"/> instance call the GetSharedGalleryImages method from an instance of <see cref="SharedGalleryResource"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SharedGalleryImageCollection : ArmCollection, IEnumerable<SharedGalleryImageResource>, IAsyncEnumerable<SharedGalleryImageResource>
    {
        /// <summary> Initializes a new instance of the <see cref="SharedGalleryImageCollection"/> class for mocking. </summary>
        protected SharedGalleryImageCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SharedGalleryImageCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SharedGalleryImageCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _sharedGalleryImagesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Compute", SharedGalleryImageResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SharedGalleryImageResource.ResourceType, out string sharedGalleryImageApiVersion);
            _sharedGalleryImagesRestClient = new SharedGalleryImages(_sharedGalleryImagesClientDiagnostics, Pipeline, Endpoint, sharedGalleryImageApiVersion);
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SharedGalleryResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SharedGalleryResource.ResourceType), nameof(id));
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
        /// <exception cref="ArgumentException"> <paramref name="galleryImageName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageName"/> is null. </exception>
        public virtual async Task<Response<SharedGalleryImageResource>> GetAsync(string galleryImageName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryImageName, nameof(galleryImageName));

            using var scope = _sharedGalleryImagesClientDiagnostics.CreateScope("SharedGalleryImageCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _sharedGalleryImagesRestClient.CreateGetRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<SharedGalleryImageData> response = Response.FromValue(SharedGalleryImageData.FromResponse(result), result);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                response.Value.Id = SharedGalleryImageResource.CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName);
                return Response.FromValue(new SharedGalleryImageResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        /// <exception cref="ArgumentException"> <paramref name="galleryImageName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageName"/> is null. </exception>
        public virtual Response<SharedGalleryImageResource> Get(string galleryImageName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryImageName, nameof(galleryImageName));

            using var scope = _sharedGalleryImagesClientDiagnostics.CreateScope("SharedGalleryImageCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _sharedGalleryImagesRestClient.CreateGetRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<SharedGalleryImageData> response = Response.FromValue(SharedGalleryImageData.FromResponse(result), result);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                response.Value.Id = SharedGalleryImageResource.CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName);
                return Response.FromValue(new SharedGalleryImageResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List shared gallery images by subscription id or tenant id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SharedGalleryImages_List</description>
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
        /// <param name="sharedTo"> The query parameter to decide what shared galleries to fetch when doing listing operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SharedGalleryImageResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SharedGalleryImageResource> GetAllAsync(SharedToValue? sharedTo = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _sharedGalleryImagesRestClient.CreateGetAllRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, sharedTo?.ToString(), null);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _sharedGalleryImagesRestClient.CreateNextGetAllRequest(new Uri(nextLink), Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, sharedTo?.ToString(), null);
            return GalleryPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new SharedGalleryImageResource(Client, DeserializeSharedGalleryImageData(e)), _sharedGalleryImagesClientDiagnostics, Pipeline, "SharedGalleryImageCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// List shared gallery images by subscription id or tenant id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SharedGalleryImages_List</description>
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
        /// <param name="sharedTo"> The query parameter to decide what shared galleries to fetch when doing listing operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SharedGalleryImageResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SharedGalleryImageResource> GetAll(SharedToValue? sharedTo = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _sharedGalleryImagesRestClient.CreateGetAllRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, sharedTo?.ToString(), null);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _sharedGalleryImagesRestClient.CreateNextGetAllRequest(new Uri(nextLink), Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, sharedTo?.ToString(), null);
            return GalleryPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new SharedGalleryImageResource(Client, DeserializeSharedGalleryImageData(e)), _sharedGalleryImagesClientDiagnostics, Pipeline, "SharedGalleryImageCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        private SharedGalleryImageData DeserializeSharedGalleryImageData(JsonElement element)
        {
            var data = SharedGalleryImageData.DeserializeSharedGalleryImageData(element, ModelSerializationExtensions.WireOptions);
            data.Id = SharedGalleryImageResource.CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, data.Name);
            return data;
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        /// <exception cref="ArgumentException"> <paramref name="galleryImageName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string galleryImageName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryImageName, nameof(galleryImageName));

            using var scope = _sharedGalleryImagesClientDiagnostics.CreateScope("SharedGalleryImageCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _sharedGalleryImagesRestClient.CreateGetRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName, context);
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
        /// <exception cref="ArgumentException"> <paramref name="galleryImageName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageName"/> is null. </exception>
        public virtual Response<bool> Exists(string galleryImageName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryImageName, nameof(galleryImageName));

            using var scope = _sharedGalleryImagesClientDiagnostics.CreateScope("SharedGalleryImageCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _sharedGalleryImagesRestClient.CreateGetRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName, context);
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
        /// <exception cref="ArgumentException"> <paramref name="galleryImageName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageName"/> is null. </exception>
        public virtual async Task<NullableResponse<SharedGalleryImageResource>> GetIfExistsAsync(string galleryImageName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryImageName, nameof(galleryImageName));

            using var scope = _sharedGalleryImagesClientDiagnostics.CreateScope("SharedGalleryImageCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _sharedGalleryImagesRestClient.CreateGetRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName, context);
                await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                if (message.Response.IsError)
                    return new NoValueResponse<SharedGalleryImageResource>(message.Response);
                Response<SharedGalleryImageData> response = Response.FromValue(SharedGalleryImageData.FromResponse(message.Response), message.Response);
                response.Value.Id = SharedGalleryImageResource.CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName);
                return Response.FromValue(new SharedGalleryImageResource(Client, response.Value), response.GetRawResponse());
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
        /// <exception cref="ArgumentException"> <paramref name="galleryImageName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageName"/> is null. </exception>
        public virtual NullableResponse<SharedGalleryImageResource> GetIfExists(string galleryImageName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryImageName, nameof(galleryImageName));

            using var scope = _sharedGalleryImagesClientDiagnostics.CreateScope("SharedGalleryImageCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _sharedGalleryImagesRestClient.CreateGetRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName, context);
                Pipeline.Send(message, cancellationToken);
                if (message.Response.IsError)
                    return new NoValueResponse<SharedGalleryImageResource>(message.Response);
                Response<SharedGalleryImageData> response = Response.FromValue(SharedGalleryImageData.FromResponse(message.Response), message.Response);
                response.Value.Id = SharedGalleryImageResource.CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Id.Name, galleryImageName);
                return Response.FromValue(new SharedGalleryImageResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SharedGalleryImageResource> IEnumerable<SharedGalleryImageResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SharedGalleryImageResource> IAsyncEnumerable<SharedGalleryImageResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}