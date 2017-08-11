// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Search.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Search.Fluent.Models;
    using Microsoft.Azure.Management.Search.Fluent.SearchService.Definition;
    using Microsoft.Rest;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point to Search service management API in Azure.
    /// </summary>
    public interface ISearchServices  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<SearchService.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Search.Fluent.ISearchService>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.Search.Fluent.ISearchService>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Search.Fluent.ISearchService>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Search.Fluent.ISearchService>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.Search.Fluent.ISearchService>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Search.Fluent.ISearchManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Search.Fluent.IServicesOperations>
    {
        /// <summary>
        /// Checks if Search service name is valid and is not in use asynchronously.
        /// </summary>
        /// <param name="name">The Search service name to check.</param>
        /// <return>A representation of the deferred computation of this call, returning whether the name is available or other info if not.</return>
        Task<Microsoft.Azure.Management.Search.Fluent.ICheckNameAvailabilityResult> CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Regenerates either the primary or secondary admin API key. You can only regenerate one key at a time.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the current subscription. You can obtain this value from the Azure Resource Manager API or the portal.</param>
        /// <param name="searchServiceName">The name of the Azure Search service associated with the specified resource group.</param>
        /// <param name="name">The name of the new query API key.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <throws>CloudException thrown if the request is rejected by server.</throws>
        /// <throws>RuntimeException all other wrapped checked exceptions if the request fails to be sent.</throws>
        /// <return>The QueryKey object if successful.</return>
        Microsoft.Azure.Management.Search.Fluent.IQueryKey CreateQueryKey(string resourceGroupName, string searchServiceName, string name);

        /// <summary>
        /// Regenerates either the primary or secondary admin API key. You can only regenerate one key at a time.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the current subscription. You can obtain this value from the Azure Resource Manager API or the portal.</param>
        /// <param name="searchServiceName">The name of the Azure Search service associated with the specified resource group.</param>
        /// <param name="keyKind">
        /// Specifies which key to regenerate. Valid values include 'primary' and 'secondary'.
        /// Possible values include: 'primary', 'secondary'.
        /// </param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <throws>CloudException thrown if the request is rejected by server.</throws>
        /// <throws>RuntimeException all other wrapped checked exceptions if the request fails to be sent.</throws>
        /// <return>The AdminKeys object if successful.</return>
        Microsoft.Azure.Management.Search.Fluent.IAdminKeys RegenerateAdminKeys(string resourceGroupName, string searchServiceName, AdminKeyKind keyKind);

        /// <summary>
        /// Gets the primary and secondary admin API keys for the specified Azure Search service.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the current subscription; you can obtain this value from the Azure Resource Manager API or the portal.</param>
        /// <param name="searchServiceName">The name of the Azure Search service associated with the specified resource group.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        Task<Microsoft.Azure.Management.Search.Fluent.IAdminKeys> GetAdminKeysAsync(string resourceGroupName, string searchServiceName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the specified query key. Unlike admin keys, query keys are not regenerated. The process for
        /// regenerating a query key is to delete and then recreate it.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the current subscription. You can obtain this value from the Azure Resource Manager API or the portal.</param>
        /// <param name="searchServiceName">The name of the Azure Search service associated with the specified resource group.</param>
        /// <param name="key">The query key to be deleted. Query keys are identified by value, not by name.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        Task DeleteQueryKeyAsync(string resourceGroupName, string searchServiceName, string key, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Regenerates either the primary or secondary admin API key. You can only regenerate one key at a time.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the current subscription. You can obtain this value from the Azure Resource Manager API or the portal.</param>
        /// <param name="searchServiceName">The name of the Azure Search service associated with the specified resource group.</param>
        /// <param name="keyKind">
        /// Specifies which key to regenerate. Valid values include 'primary' and 'secondary'.
        /// Possible values include: 'primary', 'secondary'.
        /// </param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable to the AdminKeyResultInner object.</return>
        Task<Microsoft.Azure.Management.Search.Fluent.IAdminKeys> RegenerateAdminKeysAsync(string resourceGroupName, string searchServiceName, AdminKeyKind keyKind, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Regenerates either the primary or secondary admin API key. You can only regenerate one key at a time.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the current subscription. You can obtain this value from the Azure Resource Manager API or the portal.</param>
        /// <param name="searchServiceName">The name of the Azure Search service associated with the specified resource group.</param>
        /// <param name="name">The name of the new query API key.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        Task<Microsoft.Azure.Management.Search.Fluent.IQueryKey> CreateQueryKeyAsync(string resourceGroupName, string searchServiceName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Checks if the specified Search service name is valid and available.
        /// </summary>
        /// <param name="name">The Search service name to check.</param>
        /// <return>Whether the name is available and other info if not.</return>
        Microsoft.Azure.Management.Search.Fluent.ICheckNameAvailabilityResult CheckNameAvailability(string name);

        /// <summary>
        /// Returns the list of query API keys for the given Azure Search service.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the current subscription. You can obtain this value from the Azure Resource Manager API or the portal.</param>
        /// <param name="searchServiceName">The name of the Azure Search service associated with the specified resource group.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        Task<IEnumerable<Microsoft.Azure.Management.Search.Fluent.IQueryKey>> ListQueryKeysAsync(string resourceGroupName, string searchServiceName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the specified query key. Unlike admin keys, query keys are not regenerated. The process for
        /// regenerating a query key is to delete and then recreate it.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the current subscription. You can obtain this value from the Azure Resource Manager API or the portal.</param>
        /// <param name="searchServiceName">The name of the Azure Search service associated with the specified resource group.</param>
        /// <param name="key">The query key to be deleted. Query keys are identified by value, not by name.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <throws>CloudException thrown if the request is rejected by server.</throws>
        /// <throws>RuntimeException all other wrapped checked exceptions if the request fails to be sent.</throws>
        void DeleteQueryKey(string resourceGroupName, string searchServiceName, string key);

        /// <summary>
        /// Gets the primary and secondary admin API keys for the specified Azure Search service.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the current subscription; you can obtain this value from the Azure Resource Manager API or the portal.</param>
        /// <param name="searchServiceName">The name of the Azure Search service associated with the specified resource group.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <throws>CloudException thrown if the request is rejected by server.</throws>
        /// <throws>RuntimeException all other wrapped checked exceptions if the request fails to be sent.</throws>
        /// <return>The AdminKeys object if successful.</return>
        Microsoft.Azure.Management.Search.Fluent.IAdminKeys GetAdminKeys(string resourceGroupName, string searchServiceName);

        /// <summary>
        /// Returns the list of query API keys for the given Azure Search service.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the current subscription; you can obtain this value from the Azure Resource Manager API or the portal.</param>
        /// <param name="searchServiceName">The name of the Azure Search service associated with the specified resource group.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <throws>CloudException thrown if the request is rejected by server.</throws>
        /// <throws>RuntimeException all other wrapped checked exceptions if the request fails to be sent.</throws>
        /// <return>The List&lt;QueryKey&gt; object if successful.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Search.Fluent.IQueryKey> ListQueryKeys(string resourceGroupName, string searchServiceName);
    }
}