// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific Feature.
    /// </summary>
    public class FeatureOperations : ResourceOperations
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private FeaturesRestOperations _restClient { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureOperations"/> class for mocking.
        /// </summary>
        protected FeatureOperations()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureOperations"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The id of the feature to use. </param>
        protected FeatureOperations(ResourceOperations options, ResourceIdentifier id)
            : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new FeaturesRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureOperations"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The id of the resource group to use. </param>
        internal FeatureOperations(ClientContext options, ResourceIdentifier id)
            : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new FeaturesRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);
        }

        /// <summary>
        /// Gets the resource type definition for a ResourceType.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Resources/features";

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceType;

        /// <inheritdoc/>
        protected override void ValidateResourceType(ResourceIdentifier identifier)
        {
            if (identifier.ResourceType != $"{Id.ResourceType.Namespace}/features")
            {
                throw new InvalidOperationException($"Invalid resourcetype found when intializing FeatureOperations: {identifier.ResourceType}");
            }
        }

        /// <summary> Gets the current Feature from Azure. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Feature> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FeatureOperations.Get");
            scope.Start();
            try
            {
                var response = _restClient.Get(Id.ResourceType.Namespace, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw Diagnostics.CreateRequestFailedException(response.GetRawResponse());

                return Response.FromValue(new Feature(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the current Feature from Azure. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Feature>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FeatureOperations.Get");
            scope.Start();
            try
            {
                var response = await _restClient.GetAsync(Id.ResourceType.Namespace, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await Diagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);

                return Response.FromValue(new Feature(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Registers the preview feature for the subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Feature> Register(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FeatureOperations.Register");
            scope.Start();
            try
            {
                var response = _restClient.Register(Id.ResourceType.Namespace, Id.Name, cancellationToken);
                return Response.FromValue(new Feature(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Registers the preview feature for the subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Feature>> RegisterAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FeatureOperations.Register");
            scope.Start();
            try
            {
                var response = await _restClient.RegisterAsync(Id.ResourceType.Namespace, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new Feature(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Unregisters the preview feature for the subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Feature> Unregister(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FeatureOperations.Unregister");
            scope.Start();
            try
            {
                var response = _restClient.Unregister(Id.ResourceType.Namespace, Id.Name, cancellationToken);
                return Response.FromValue(new Feature(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Unregisters the preview feature for the subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Feature>> UnregisterAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FeatureOperations.Unregister");
            scope.Start();
            try
            {
                var response = await _restClient.UnregisterAsync(Id.ResourceType.Namespace, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new Feature(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
