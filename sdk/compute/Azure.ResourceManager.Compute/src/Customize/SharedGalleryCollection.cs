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
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute
{
    /// <summary>
    /// A class representing a collection of <see cref="SharedGalleryResource"/> and their operations.
    /// Each <see cref="SharedGalleryResource"/> in the collection will belong to the same instance of <see cref="SubscriptionResource"/>.
    /// To get a <see cref="SharedGalleryCollection"/> instance call the GetSharedGalleries method from an instance of <see cref="SubscriptionResource"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SharedGalleryCollection : ArmCollection, IEnumerable<SharedGalleryResource>, IAsyncEnumerable<SharedGalleryResource>
    {
        private readonly ClientDiagnostics _sharedGalleryClientDiagnostics;
        private readonly SharedGalleries _sharedGalleryRestClient;
        private readonly AzureLocation _location;

        /// <summary> Initializes a new instance of the <see cref="SharedGalleryCollection"/> class for mocking. </summary>
        protected SharedGalleryCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SharedGalleryCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        /// <param name="location"> The name of Azure region. </param>
        internal SharedGalleryCollection(ArmClient client, ResourceIdentifier id, AzureLocation location) : base(client, id)
        {
            _location = location;
            _sharedGalleryClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Compute", SharedGalleryResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SharedGalleryResource.ResourceType, out string sharedGalleryApiVersion);
            _sharedGalleryRestClient = new SharedGalleries(_sharedGalleryClientDiagnostics, Pipeline, Endpoint, sharedGalleryApiVersion);
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SubscriptionResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SubscriptionResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Get a shared gallery by subscription id or tenant id.
        /// </summary>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryUniqueName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryUniqueName"/> is null. </exception>
        public virtual async Task<Response<SharedGalleryResource>> GetAsync(string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryUniqueName, nameof(galleryUniqueName));

            using var scope = _sharedGalleryClientDiagnostics.CreateScope("SharedGalleryCollection.Get");
            scope.Start();
            try
            {
                using var message = _sharedGalleryRestClient.CreateGetSharedGalleryRequest(Id.SubscriptionId, new AzureLocation(_location), galleryUniqueName, new RequestContext { CancellationToken = cancellationToken });
                await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                if (message.Response.IsError)
                    throw new RequestFailedException(message.Response);
                using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                var data = SharedGalleryData.DeserializeSharedGalleryData(document.RootElement, ModelSerializationExtensions.WireOptions);
                data.Id = SharedGalleryResource.CreateResourceIdentifier(Id.SubscriptionId, _location, galleryUniqueName);
                return Response.FromValue(new SharedGalleryResource(Client, data), message.Response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a shared gallery by subscription id or tenant id.
        /// </summary>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryUniqueName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryUniqueName"/> is null. </exception>
        public virtual Response<SharedGalleryResource> Get(string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryUniqueName, nameof(galleryUniqueName));

            using var scope = _sharedGalleryClientDiagnostics.CreateScope("SharedGalleryCollection.Get");
            scope.Start();
            try
            {
                using var message = _sharedGalleryRestClient.CreateGetSharedGalleryRequest(Id.SubscriptionId, new AzureLocation(_location), galleryUniqueName, new RequestContext { CancellationToken = cancellationToken });
                Pipeline.Send(message, cancellationToken);
                if (message.Response.IsError)
                    throw new RequestFailedException(message.Response);
                using var document = JsonDocument.Parse(message.Response.ContentStream);
                var data = SharedGalleryData.DeserializeSharedGalleryData(document.RootElement, ModelSerializationExtensions.WireOptions);
                data.Id = SharedGalleryResource.CreateResourceIdentifier(Id.SubscriptionId, _location, galleryUniqueName);
                return Response.FromValue(new SharedGalleryResource(Client, data), message.Response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List shared galleries by subscription id or tenant id.
        /// </summary>
        /// <param name="sharedTo"> The query parameter to decide what shared galleries to fetch when doing listing operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SharedGalleryResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SharedGalleryResource> GetAllAsync(SharedToValue? sharedTo = null, CancellationToken cancellationToken = default)
        {
            var context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage FirstPageRequest(int? pageSizeHint) => _sharedGalleryRestClient.CreateGetSharedGalleriesRequest(Id.SubscriptionId, new AzureLocation(_location), sharedTo?.ToString(), context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _sharedGalleryRestClient.CreateNextGetSharedGalleriesRequest(new Uri(nextLink), Id.SubscriptionId, new AzureLocation(_location), sharedTo?.ToString(), context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new SharedGalleryResource(Client, DeserializeSharedGalleryData(e)), _sharedGalleryClientDiagnostics, Pipeline, "SharedGalleryCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// List shared galleries by subscription id or tenant id.
        /// </summary>
        /// <param name="sharedTo"> The query parameter to decide what shared galleries to fetch when doing listing operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SharedGalleryResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SharedGalleryResource> GetAll(SharedToValue? sharedTo = null, CancellationToken cancellationToken = default)
        {
            var context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage FirstPageRequest(int? pageSizeHint) => _sharedGalleryRestClient.CreateGetSharedGalleriesRequest(Id.SubscriptionId, new AzureLocation(_location), sharedTo?.ToString(), context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _sharedGalleryRestClient.CreateNextGetSharedGalleriesRequest(new Uri(nextLink), Id.SubscriptionId, new AzureLocation(_location), sharedTo?.ToString(), context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new SharedGalleryResource(Client, DeserializeSharedGalleryData(e)), _sharedGalleryClientDiagnostics, Pipeline, "SharedGalleryCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        private SharedGalleryData DeserializeSharedGalleryData(JsonElement element)
        {
            var data = SharedGalleryData.DeserializeSharedGalleryData(element, ModelSerializationExtensions.WireOptions);
            data.Id = SharedGalleryResource.CreateResourceIdentifier(Id.SubscriptionId, _location, data.Name);
            return data;
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// </summary>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryUniqueName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryUniqueName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryUniqueName, nameof(galleryUniqueName));

            using var scope = _sharedGalleryClientDiagnostics.CreateScope("SharedGalleryCollection.Exists");
            scope.Start();
            try
            {
                using var message = _sharedGalleryRestClient.CreateGetSharedGalleryRequest(Id.SubscriptionId, new AzureLocation(_location), galleryUniqueName, new RequestContext { CancellationToken = cancellationToken });
                await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                if (message.Response.Status == 404)
                    return Response.FromValue(false, message.Response);
                if (message.Response.IsError)
                    throw new RequestFailedException(message.Response);
                return Response.FromValue(true, message.Response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// </summary>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryUniqueName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryUniqueName"/> is null. </exception>
        public virtual Response<bool> Exists(string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryUniqueName, nameof(galleryUniqueName));

            using var scope = _sharedGalleryClientDiagnostics.CreateScope("SharedGalleryCollection.Exists");
            scope.Start();
            try
            {
                using var message = _sharedGalleryRestClient.CreateGetSharedGalleryRequest(Id.SubscriptionId, new AzureLocation(_location), galleryUniqueName, new RequestContext { CancellationToken = cancellationToken });
                Pipeline.Send(message, cancellationToken);
                if (message.Response.Status == 404)
                    return Response.FromValue(false, message.Response);
                if (message.Response.IsError)
                    throw new RequestFailedException(message.Response);
                return Response.FromValue(true, message.Response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// </summary>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryUniqueName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryUniqueName"/> is null. </exception>
        public virtual async Task<NullableResponse<SharedGalleryResource>> GetIfExistsAsync(string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryUniqueName, nameof(galleryUniqueName));

            using var scope = _sharedGalleryClientDiagnostics.CreateScope("SharedGalleryCollection.GetIfExists");
            scope.Start();
            try
            {
                using var message = _sharedGalleryRestClient.CreateGetSharedGalleryRequest(Id.SubscriptionId, new AzureLocation(_location), galleryUniqueName, new RequestContext { CancellationToken = cancellationToken });
                await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                if (message.Response.Status == 404)
                    return new NoValueResponse<SharedGalleryResource>(message.Response);
                if (message.Response.IsError)
                    throw new RequestFailedException(message.Response);
                using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                var data = SharedGalleryData.DeserializeSharedGalleryData(document.RootElement, ModelSerializationExtensions.WireOptions);
                data.Id = SharedGalleryResource.CreateResourceIdentifier(Id.SubscriptionId, _location, galleryUniqueName);
                return Response.FromValue(new SharedGalleryResource(Client, data), message.Response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// </summary>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryUniqueName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryUniqueName"/> is null. </exception>
        public virtual NullableResponse<SharedGalleryResource> GetIfExists(string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryUniqueName, nameof(galleryUniqueName));

            using var scope = _sharedGalleryClientDiagnostics.CreateScope("SharedGalleryCollection.GetIfExists");
            scope.Start();
            try
            {
                using var message = _sharedGalleryRestClient.CreateGetSharedGalleryRequest(Id.SubscriptionId, new AzureLocation(_location), galleryUniqueName, new RequestContext { CancellationToken = cancellationToken });
                Pipeline.Send(message, cancellationToken);
                if (message.Response.Status == 404)
                    return new NoValueResponse<SharedGalleryResource>(message.Response);
                if (message.Response.IsError)
                    throw new RequestFailedException(message.Response);
                using var document = JsonDocument.Parse(message.Response.ContentStream);
                var data = SharedGalleryData.DeserializeSharedGalleryData(document.RootElement, ModelSerializationExtensions.WireOptions);
                data.Id = SharedGalleryResource.CreateResourceIdentifier(Id.SubscriptionId, _location, galleryUniqueName);
                return Response.FromValue(new SharedGalleryResource(Client, data), message.Response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SharedGalleryResource> IEnumerable<SharedGalleryResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SharedGalleryResource> IAsyncEnumerable<SharedGalleryResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}