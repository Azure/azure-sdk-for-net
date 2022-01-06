// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Compute
{
    /// <summary> A Class representing a SharedGallery along with the instance operations that can be performed on it. </summary>
    public partial class SharedGallery : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SharedGallery"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location, string galleryUniqueName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}";
            return new ResourceIdentifier(resourceId);
        }
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly SharedGalleriesRestOperations _sharedGalleriesRestClient;
        private readonly SharedGalleryData _data;

        /// <summary> Initializes a new instance of the <see cref="AvailabilitySet"/> class for mocking. </summary>
        protected SharedGallery()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SharedGallery"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        /// <param name="id"> The resource identifier of this resource. </param>
        internal SharedGallery(ArmResource options, SharedGalleryData resource, ResourceIdentifier id) : base(options, id)
        {
            HasData = true;
            _data = resource;
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _sharedGalleriesRestClient = new SharedGalleriesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Initializes a new instance of the <see cref="SharedGallery"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SharedGallery(ArmResource options, ResourceIdentifier id) : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _sharedGalleriesRestClient = new SharedGalleriesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Initializes a new instance of the <see cref="SharedGallery"/> class. </summary>
        /// <param name="clientOptions"> The client options to build client context. </param>
        /// <param name="credential"> The credential to build client context. </param>
        /// <param name="uri"> The uri to build client context. </param>
        /// <param name="pipeline"> The pipeline to build client context. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SharedGallery(ArmClientOptions clientOptions, TokenCredential credential, Uri uri, HttpPipeline pipeline, ResourceIdentifier id) : base(clientOptions, credential, uri, pipeline, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _sharedGalleriesRestClient = new SharedGalleriesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/locations/sharedGalleries";

        /// <summary> Gets the valid resource type for the operations. </summary>
        protected override ResourceType ValidResourceType => ResourceType;

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

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: SharedGalleries_Get
        /// <summary> Get a shared gallery by subscription id or tenant id. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<SharedGallery>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SharedGallery.Get");
            scope.Start();
            try
            {
                var response = await _sharedGalleriesRestClient.GetAsync(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SharedGallery(this, response.Value, Id), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: SharedGalleries_Get
        /// <summary> Get a shared gallery by subscription id or tenant id. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SharedGallery> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SharedGallery.Get");
            scope.Start();
            try
            {
                var response = _sharedGalleriesRestClient.Get(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SharedGallery(this, response.Value, Id), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #region SharedGalleryImage

        /// <summary> Gets a collection of SharedGalleryImages in the ShareGallery. </summary>
        /// <returns> An object representing collection of SharedGalleryImages and their operations over a SharedGallery. </returns>
        public SharedGalleryImageCollection GetSharedGalleryImages()
        {
            return new SharedGalleryImageCollection(this);
        }
        #endregion
    }
}
