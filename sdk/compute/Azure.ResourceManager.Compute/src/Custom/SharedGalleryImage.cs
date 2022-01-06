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
    /// <summary> A Class representing a SharedGalleryImage along with the instance operations that can be performed on it. </summary>
    public partial class SharedGalleryImage : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SharedGalleryImage"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location, string galleryUniqueName, string galleryImageName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images/{galleryImageName}";
            return new ResourceIdentifier(resourceId);
        }
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly SharedGalleryImagesRestOperations _sharedGalleryImagesRestClient;
        private readonly SharedGalleryImageData _data;

        /// <summary> Initializes a new instance of the <see cref="AvailabilitySet"/> class for mocking. </summary>
        protected SharedGalleryImage()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SharedGalleryImage"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        /// <param name="id"> The resource identifier of this resource. </param>
        internal SharedGalleryImage(ArmResource options, SharedGalleryImageData resource, ResourceIdentifier id) : base(options, id)
        {
            HasData = true;
            _data = resource;
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _sharedGalleryImagesRestClient = new SharedGalleryImagesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Initializes a new instance of the <see cref="SharedGalleryImage"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SharedGalleryImage(ArmResource options, ResourceIdentifier id) : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _sharedGalleryImagesRestClient = new SharedGalleryImagesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Initializes a new instance of the <see cref="SharedGalleryImage"/> class. </summary>
        /// <param name="clientOptions"> The client options to build client context. </param>
        /// <param name="credential"> The credential to build client context. </param>
        /// <param name="uri"> The uri to build client context. </param>
        /// <param name="pipeline"> The pipeline to build client context. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SharedGalleryImage(ArmClientOptions clientOptions, TokenCredential credential, Uri uri, HttpPipeline pipeline, ResourceIdentifier id) : base(clientOptions, credential, uri, pipeline, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _sharedGalleryImagesRestClient = new SharedGalleryImagesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/locations/sharedGalleries/images";

        /// <summary> Gets the valid resource type for the operations. </summary>
        protected override ResourceType ValidResourceType => ResourceType;

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual SharedGalleryImageData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images/{galleryImageName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images/{galleryImageName}
        /// OperationId: SharedGalleryImages_Get
        /// <summary> Get a shared gallery image by subscription id or tenant id. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<SharedGalleryImage>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SharedGalleryImage.Get");
            scope.Start();
            try
            {
                var response = await _sharedGalleryImagesRestClient.GetAsync(Id.SubscriptionId, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SharedGalleryImage(this, response.Value, Id), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images/{galleryImageName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images/{galleryImageName}
        /// OperationId: SharedGalleryImages_Get
        /// <summary> Get a shared gallery image by subscription id or tenant id. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SharedGalleryImage> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SharedGalleryImage.Get");
            scope.Start();
            try
            {
                var response = _sharedGalleryImagesRestClient.Get(Id.SubscriptionId, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SharedGalleryImage(this, response.Value, Id), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
