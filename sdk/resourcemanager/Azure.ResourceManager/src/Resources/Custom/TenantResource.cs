// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources.Models;

[assembly: CodeGenSuppressType("TenantExtensions")]
namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific subscription.
    /// </summary>
    [CodeGenSuppress("TenantResource", typeof(ArmClient), typeof(TenantData))]
    [CodeGenSuppress("Get", typeof(CancellationToken))]
    [CodeGenSuppress("GetAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetAvailableLocations", typeof(CancellationToken))]
    [CodeGenSuppress("GetAvailableLocationsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetTenants")]
    [CodeGenSuppress("CreateResourceIdentifier")]
    // [CodeGenSuppress("_tenantsRestClient")] // TODO: not working for private member
    public partial class TenantResource : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref = "TenantResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        internal TenantResource(ArmClient client) : this(client, ResourceIdentifier.Root)
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "TenantResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal TenantResource(ArmClient client, TenantData data) : this(client, ResourceIdentifier.Root)
        {
            HasData = true;
            _data = data;
        }

        /// <summary>
        /// Gets all resource providers for the tenant.
        /// Request Path: /providers
        /// Operation Id: Providers_ListAtTenantScope
        /// </summary>
        /// <param name="top"> [Deprecated]The number of results to return. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TenantResourceProvider" /> that may take multiple service requests to iterate over. </returns>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete as the `top` parameter is no longer supported in new service versions and will be removed in a future release.", false)]
        public virtual AsyncPageable<TenantResourceProvider> GetTenantResourceProvidersAsync(int top, string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<TenantResourceProvider>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resourceProviderProvidersClientDiagnostics.CreateScope("TenantResource.GetTenantResourceProviders");
                scope.Start();
                try
                {
                    var response = await _resourceProviderProvidersRestClient.ListAtTenantScopeAsync(top, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<TenantResourceProvider>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _resourceProviderProvidersClientDiagnostics.CreateScope("TenantResource.GetTenantResourceProviders");
                scope.Start();
                try
                {
                    var response = await _resourceProviderProvidersRestClient.ListAtTenantScopeNextPageAsync(nextLink, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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

        /// <summary>
        /// Gets all resource providers for the tenant.
        /// Request Path: /providers
        /// Operation Id: Providers_ListAtTenantScope
        /// </summary>
        /// <param name="top"> [Deprecated]The number of results to return. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TenantResourceProvider" /> that may take multiple service requests to iterate over. </returns>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete as the `top` parameter is no longer supported in new service versions and will be removed in a future release.", false)]
        public virtual Pageable<TenantResourceProvider> GetTenantResourceProviders(int top, string expand = null, CancellationToken cancellationToken = default)
        {
            Page<TenantResourceProvider> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resourceProviderProvidersClientDiagnostics.CreateScope("TenantResource.GetTenantResourceProviders");
                scope.Start();
                try
                {
                    var response = _resourceProviderProvidersRestClient.ListAtTenantScope(top, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<TenantResourceProvider> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _resourceProviderProvidersClientDiagnostics.CreateScope("TenantResource.GetTenantResourceProviders");
                scope.Start();
                try
                {
                    var response = _resourceProviderProvidersRestClient.ListAtTenantScopeNextPage(nextLink, expand, cancellationToken: cancellationToken);
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
    }
}
