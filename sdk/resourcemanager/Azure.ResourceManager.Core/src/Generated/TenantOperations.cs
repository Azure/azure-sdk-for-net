// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific subscription.
    /// </summary>
    public class TenantOperations : OperationsBase
    {
        private ProviderRestOperations _providerRestOperations;

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantOperations"/> class for mocking.
        /// </summary>
        protected TenantOperations()
        {
        }

        /// <summary>
        /// The resource type for subscription
        /// </summary>
        public static readonly ResourceType ResourceType = ResourceType.RootResourceType;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionOperations"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="baseUri"> The base URI of the service. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        internal TenantOperations(ArmClientOptions options, TokenCredential credential, Uri baseUri, HttpPipeline pipeline)
            : base(new ClientContext(options, credential, baseUri, pipeline), ResourceIdentifier.RootResourceIdentifier)
        {
            _providerRestOperations = new ProviderRestOperations(Diagnostics, Pipeline, Guid.Empty.ToString(), BaseUri);
        }

        /// <summary>
        /// Gets the valid resource type for this operation class
        /// </summary>
        protected override ResourceType ValidResourceType => ResourceType;

        /// <summary>
        /// ListResources of type T.
        /// </summary>
        /// <typeparam name="T"> The type of resource being returned in the list. </typeparam>
        /// <param name="func"> The method to pass the internal properties to. </param>
        /// <returns>  A collection of resources. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<T> ListResources<T>(Func<Uri, TokenCredential, ArmClientOptions, HttpPipeline, Pageable<T>> func)
        {
            return func(BaseUri, Credential, ClientOptions, Pipeline);
        }

        /// <summary>
        /// ListResources of type T.
        /// </summary>
        /// <typeparam name="T"> The type of resource being returned in the list. </typeparam>
        /// <param name="func"> The method to pass the internal properties to. </param>
        /// <returns>  A collection of resources. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<T> ListResourcesAsync<T>(Func<Uri, TokenCredential, ArmClientOptions, HttpPipeline, AsyncPageable<T>> func)
        {
            return func(BaseUri, Credential, ClientOptions, Pipeline);
        }

        /// <summary> Gets all resource providers for a subscription. </summary>
        /// <param name="top"> The number of results to return. If null is passed returns all deployments. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ProviderInfo> ListProviders(int? top = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Page<ProviderInfo> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("TenantOperations.ListProviders");
                scope.Start();

                try
                {
                    Response<ProviderInfoListResult> response = _providerRestOperations.ListAtTenantScope(top, expand, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ProviderInfo> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("TenantOperations.ListProviders");
                scope.Start();

                try
                {
                    Response<ProviderInfoListResult> response = _providerRestOperations.ListAtTenantScopeNextPage(nextLink, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
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
        public virtual AsyncPageable<ProviderInfo> ListProvidersAsync(int? top = null, string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ProviderInfo>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("TenantOperations.ListProviders");
                scope.Start();

                try
                {
                    Response<ProviderInfoListResult> response = await _providerRestOperations.ListAtTenantScopeAsync(top, expand, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ProviderInfo>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("TenantOperations.ListProviders");
                scope.Start();

                try
                {
                    Response<ProviderInfoListResult> response = await _providerRestOperations.ListAtTenantScopeNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets the specified resource provider at the tenant level. </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        public virtual Response<ProviderInfo> GetProvider(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TenantOperations.GetProvider");
            scope.Start();

            try
            {
                return _providerRestOperations.GetAtTenantScope(resourceProviderNamespace, expand, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the specified resource provider at the tenant level. </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        public virtual async Task<Response<ProviderInfo>> GetProviderAsync(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TenantOperations.GetProvider");
            scope.Start();

            try
            {
                return await _providerRestOperations.GetAtTenantScopeAsync(resourceProviderNamespace, expand, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the management group container for this tenant.
        /// </summary>
        /// <returns> A container of the management groups. </returns>
        public virtual ManagementGroupContainer GetManagementGroups()
        {
            return new ManagementGroupContainer(this);
        }

        /// <summary>
        /// Gets the managmeent group operations object associated with the id.
        /// </summary>
        /// <param name="id"> The id of the management group operations. </param>
        /// <returns> A client to perform operations on the management group. </returns>
        internal ManagementGroupOperations GetManagementGroupOperations(string id)
        {
            return new ManagementGroupOperations(this, id);
        }
    }
}
