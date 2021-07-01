// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing collection of resources and their operations over their parent.
    /// </summary>
    public class ProviderContainer : ResourceContainerBase<TenantResourceIdentifier, Provider, ProviderData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderContainer"/> class for mocking.
        /// </summary>
        protected ProviderContainer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderContainer"/> class.
        /// </summary>
        /// <param name="parent"> The client context to use. </param>
        internal ProviderContainer(OperationsBase parent)
            : base(parent)
        {
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceIdentifier.RootResourceIdentifier.ResourceType;

        /// <inheritdoc/>
        protected override void Validate(ResourceIdentifier identifier)
        {
        }

        private ProviderRestOperations RestClient
        {
            get
            {
                string subscription;
                if (Id is null || !Id.TryGetSubscriptionId(out subscription))
                {
                    subscription = Guid.Empty.ToString();
                }

                return new ProviderRestOperations(
                    Diagnostics,
                    Pipeline,
                    subscription,
                    BaseUri);
            }
        }

        /// <summary>
        /// Gets the provider for a namespace.
        /// </summary>
        /// <param name="resourceProviderNamespace"></param>
        /// <param name="expand"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<Provider> Get(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ProviderContainer.Get");
            scope.Start();

            try
            {
                Response<ProviderData> result;
                if (Id is SubscriptionResourceIdentifier)
                {
                    result = RestClient.Get(resourceProviderNamespace, expand, cancellationToken);
                }
                else
                {
                    result = RestClient.GetAtTenantScope(resourceProviderNamespace, expand, cancellationToken);
                }
                return Response.FromValue(new Provider(Parent, result), result.GetRawResponse());
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
            using var scope = Diagnostics.CreateScope("ProviderContainer.Get");
            scope.Start();

            try
            {
                Response<ProviderData> result;
                if (Id is SubscriptionResourceIdentifier)
                {
                    result = await RestClient.GetAsync(resourceProviderNamespace, expand, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    result = await RestClient.GetAtTenantScopeAsync(resourceProviderNamespace, expand, cancellationToken).ConfigureAwait(false);
                }
                if (Parent is null)
                    return Response.FromValue(new Provider(result), result.GetRawResponse());
                return Response.FromValue(new Provider(Parent, result), result.GetRawResponse());
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
        public virtual Pageable<Provider> List(int? top = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Page<Provider> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("ProviderContainer.List");
                scope.Start();
                string subscriptionId = "";

                try
                {
                    Response<ProviderListResult> response;
                    if (Id.TryGetSubscriptionId(out subscriptionId))
                    {
                        response = RestClient.List(top, expand, cancellationToken);
                    }
                    else
                    {
                        response = RestClient.ListAtTenantScope(top, expand, cancellationToken);
                    }
                    return Page.FromValues(response.Value.Value.Select(data => new Provider(Parent, data)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Provider> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("ProviderContainer.List");
                scope.Start();
                string subscriptionId = "";

                try
                {
                    Response<ProviderListResult> response;
                    if (Id.TryGetSubscriptionId(out subscriptionId))
                    {
                        response = RestClient.ListNextPage(nextLink, top, expand, cancellationToken);
                    }
                    else
                    {
                        response = RestClient.ListAtTenantScopeNextPage(nextLink, top, expand, cancellationToken);
                    }
                    return Page.FromValues(response.Value.Value.Select(data => new Provider(Parent, data)), response.Value.NextLink, response.GetRawResponse());
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
        public virtual AsyncPageable<Provider> ListAsync(int? top = null, string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<Provider>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("ProviderContainer.List");
                scope.Start();
                string subscriptionId = "";

                try
                {
                    Response<ProviderListResult> response;
                    if (Id.TryGetSubscriptionId(out subscriptionId))
                    {
                        response = await RestClient.ListAsync(top, expand, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        response = await RestClient.ListAtTenantScopeAsync(top, expand, cancellationToken).ConfigureAwait(false);
                    }
                    return Page.FromValues(response.Value.Value.Select(data => new Provider(Parent, data)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Provider>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("ProviderContainer.List");
                scope.Start();
                string subscriptionId = "";

                try
                {
                    Response<ProviderListResult> response;
                    if (Id.TryGetSubscriptionId(out subscriptionId))
                    {
                        response = await RestClient.ListNextPageAsync(nextLink, top, expand, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        response = await RestClient.ListAtTenantScopeNextPageAsync(nextLink, top, expand, cancellationToken).ConfigureAwait(false);
                    }
                    return Page.FromValues(response.Value.Value.Select(data => new Provider(Parent, data)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
