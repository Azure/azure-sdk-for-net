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
    public class Feature : ArmResource
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly FeaturesRestOperations _restClient;
        private readonly FeatureData _data;

        /// <summary>
        /// Initializes a new instance of the <see cref="Feature"/> class for mocking.
        /// </summary>
        protected Feature()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Feature"/> class.
        /// </summary>
        /// <param name="operations"> The operations to copy the client options from. </param>
        /// <param name="resource"> The FeatureData to use in these operations. </param>
        internal Feature(ArmResource operations, FeatureData resource)
            : base(operations, resource.Id)
        {
            _data = resource;
            HasData = true;
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new FeaturesRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Feature"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The id of the resource group to use. </param>
        internal Feature(ClientContext options, ResourceIdentifier id)
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

        /// <summary>
        /// Gets whether or not the current instance has data.
        /// </summary>
        public bool HasData { get; }

        /// <summary>
        /// Gets the data representing this Feature.
        /// </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual FeatureData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data you must call Get first");
                return _data;
            }
        }

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
            using var scope = _clientDiagnostics.CreateScope("Feature.Get");
            scope.Start();
            try
            {
                var response = _restClient.Get(Id.ResourceType.Namespace, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());

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
            using var scope = _clientDiagnostics.CreateScope("Feature.Get");
            scope.Start();
            try
            {
                var response = await _restClient.GetAsync(Id.ResourceType.Namespace, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);

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
            using var scope = _clientDiagnostics.CreateScope("Feature.Register");
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
            using var scope = _clientDiagnostics.CreateScope("Feature.Register");
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
            using var scope = _clientDiagnostics.CreateScope("Feature.Unregister");
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
            using var scope = _clientDiagnostics.CreateScope("Feature.Unregister");
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
