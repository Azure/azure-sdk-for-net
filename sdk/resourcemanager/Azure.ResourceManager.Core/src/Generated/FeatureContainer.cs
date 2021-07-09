// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing collection of FeatureContainer and their operations over a Feature.
    /// </summary>
    public class FeatureContainer : ResourceContainerBase<SubscriptionProviderIdentifier, Feature, FeatureData>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private FeaturesRestOperations _restClient { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureContainer"/> class for mocking.
        /// </summary>
        protected FeatureContainer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureContainer"/> class.
        /// </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
       internal FeatureContainer(ProviderOperations parent)
            : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new FeaturesRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);
        }

        /// <inheritdoc />
        protected override ResourceType ValidResourceType => ProviderOperations.ResourceType;

        /// <summary>
        /// Gets the resource identifier.
        /// </summary>
        public new SubscriptionProviderIdentifier Id => base.Id as SubscriptionProviderIdentifier;

        /// <summary> Gets all the preview features in a provider namespace that are available through AFEC for the subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Feature> ListAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Feature>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FeatureContainer.List");
                scope.Start();
                try
                {
                    var response = await _restClient.ListAsync(Id.Provider, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(d => new Feature(Parent, d)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Feature>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FeatureContainer.List");
                scope.Start();
                try
                {
                    var response = await _restClient.ListNextPageAsync(nextLink, Id.Provider, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(d => new Feature(Parent, d)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets all the preview features in a provider namespace that are available through AFEC for the subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Feature> List(CancellationToken cancellationToken = default)
        {
            Page<Feature> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FeatureContainer.List");
                scope.Start();
                try
                {
                    var response = _restClient.List(Id.Provider, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(d => new Feature(Parent, d)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Feature> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FeatureContainer.List");
                scope.Start();
                try
                {
                    var response = _restClient.ListNextPage(nextLink, Id.Provider, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(d => new Feature(Parent, d)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets the preview feature with the specified name. </summary>
        /// <param name="featureName"> The name of the feature to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Feature> Get(string featureName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FeatureContainer.Get");
            scope.Start();
            try
            {
                var response = _restClient.Get(Id.Provider, featureName, cancellationToken);
                return Response.FromValue(new Feature(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the preview feature with the specified name. </summary>
        /// <param name="featureName"> The name of the feature to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Feature>> GetAsync(string featureName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FeatureContainer.Get");
            scope.Start();
            try
            {
                var response = await _restClient.GetAsync(Id.Provider, featureName, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new Feature(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns the resource from Azure if it exists.
        /// </summary>
        /// <param name="featureName"> The name of the resource you want to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual Feature TryGet(string featureName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("FeatureContainer.TryGet");
            scope.Start();

            try
            {
                return Get(featureName, cancellationToken).Value;
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns the resource from Azure if it exists.
        /// </summary>
        /// <param name="featureName"> The name of the resource you want to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual async Task<Feature> TryGetAsync(string featureName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("FeatureContainer.TryGet");
            scope.Start();

            try
            {
                return await GetAsync(featureName, cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Determines whether or not the azure resource exists in this container.
        /// </summary>
        /// <param name="featureName"> The name of the resource you want to check. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual bool DoesExist(string featureName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("FeatureContainer.DoesExist");
            scope.Start();
            return TryGet(featureName, cancellationToken) != null;
        }

        /// <summary>
        /// Determines whether or not the azure resource exists in this container.
        /// </summary>
        /// <param name="featureName"> The name of the resource you want to check. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual async Task<bool> DoesExistAsync(string featureName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("FeatureContainer.DoesExist");
            scope.Start();
            return await TryGetAsync(featureName, cancellationToken).ConfigureAwait(false) != null;
        }
    }
}
