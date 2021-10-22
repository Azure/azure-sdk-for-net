// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing collection of resources and their operations over their parent.
    /// </summary>
    public class ProviderCollection : ArmCollection, IEnumerable<Provider>, IAsyncEnumerable<Provider>
    {
        private ClientDiagnostics _clientDiagnostics;
        private ProviderRestOperations _restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderCollection"/> class for mocking.
        /// </summary>
        protected ProviderCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderCollection"/> class.
        /// </summary>
        /// <param name="parent"> The client context to use. </param>
        internal ProviderCollection(Subscription parent)
            : base(parent)
        {
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => Subscription.ResourceType;

        private ProviderRestOperations RestClient => _restClient ??= new ProviderRestOperations(Diagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);

        private ClientDiagnostics Diagnostics => _clientDiagnostics ??= new ClientDiagnostics(ClientOptions);

        /// <summary>
        /// Gets the provider for a namespace.
        /// </summary>
        /// <param name="resourceProviderNamespace"></param>
        /// <param name="expand"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<Provider> Get(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ProviderCollection.Get");
            scope.Start();

            try
            {
                var result = RestClient.Get(resourceProviderNamespace, expand, cancellationToken);
                if (result.Value == null)
                    throw Diagnostics.CreateRequestFailedException(result.GetRawResponse());

                return Response.FromValue(new Provider(this, result), result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the provider for a namespace.
        /// </summary>
        /// <param name="resourceProviderNamespace"></param>
        /// <param name="expand"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<Provider>> GetAsync(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ProviderCollection.Get");
            scope.Start();

            try
            {
                Response<ProviderData> response = await RestClient.GetAsync(resourceProviderNamespace, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await Diagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);

                return Response.FromValue(new Provider(this, response), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets all resource providers for a subscription. </summary>
        /// <param name="top"> The number of results to return. If null is passed returns all deployments. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Provider> GetAll(int? top = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Page<Provider> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("ProviderCollection.GetAll");
                scope.Start();

                try
                {
                    Response<ProviderListResult> response = RestClient.List(top, expand, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(data => new Provider(this, data)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Provider> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("ProviderCollection.GetAll");
                scope.Start();

                try
                {
                    Response<ProviderListResult> response = RestClient.ListNextPage(nextLink, top, expand, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(data => new Provider(this, data)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets all resource providers for a subscription. </summary>
        /// <param name="top"> The number of results to return. If null is passed returns all deployments. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Provider> GetAllAsync(int? top = null, string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<Provider>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("ProviderCollection.GetAll");
                scope.Start();

                try
                {
                    Response<ProviderListResult> response = await RestClient.ListAsync(top, expand, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(data => new Provider(this, data)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Provider>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("ProviderCollection.GetAll");
                scope.Start();

                try
                {
                    Response<ProviderListResult> response = await RestClient.ListNextPageAsync(nextLink, top, expand, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(data => new Provider(this, data)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Returns the resource from Azure if it exists.
        /// </summary>
        /// <param name="resourceProviderNamespace"> The name of the resource you want to get. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual Response<Provider> GetIfExists(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ProviderCollection.GetIfExists");
            scope.Start();

            try
            {
                var response = RestClient.Get(resourceProviderNamespace, expand, cancellationToken);
                return response.Value == null
                   ? Response.FromValue<Provider>(null, response.GetRawResponse())
                   : Response.FromValue(new Provider(this, response.Value), response.GetRawResponse());
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
        /// <param name="resourceProviderNamespace"> The name of the resource you want to get. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual async Task<Response<Provider>> GetIfExistsAsync(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ProviderCollection.GetIfExists");
            scope.Start();

            try
            {
                var response = await RestClient.GetAsync(resourceProviderNamespace, expand, cancellationToken).ConfigureAwait(false);
                return response.Value == null
                   ? Response.FromValue<Provider>(null, response.GetRawResponse())
                   : Response.FromValue(new Provider(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Determines whether or not the azure resource exists in this collection.
        /// </summary>
        /// <param name="resourceProviderNamespace"> The name of the resource you want to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual Response<bool> CheckIfExists(string resourceProviderNamespace, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ProviderCollection.CheckIfExists");
            scope.Start();

            try
            {
                var response = GetIfExists(resourceProviderNamespace, null, cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Determines whether or not the azure resource exists in this collection.
        /// </summary>
        /// <param name="resourceProviderNamespace"> The name of the resource you want to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual async Task<Response<bool>> CheckIfExistsAsync(string resourceProviderNamespace, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ProviderCollection.CheckIfExists");
            scope.Start();

            try
            {
                var response = await GetIfExistsAsync(resourceProviderNamespace, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<Provider> IEnumerable<Provider>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Provider> IAsyncEnumerable<Provider>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
