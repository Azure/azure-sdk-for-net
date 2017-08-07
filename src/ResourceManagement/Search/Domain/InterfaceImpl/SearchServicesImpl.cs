// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Search.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Search.Fluent.Models;
    using Microsoft.Azure.Management.Search.Fluent.SearchService.Definition;
    using Microsoft.Rest;

    internal partial class SearchServicesImpl 
    {
        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        SearchService.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<SearchService.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as SearchService.Definition.IBlank;
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Search.Fluent.ISearchService> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.Search.Fluent.ISearchService>.ListByResourceGroup(string resourceGroupName)
        {
            return this.ListByResourceGroup(resourceGroupName) as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Search.Fluent.ISearchService>;
        }

        /// <summary>
        /// Checks if Search service name is valid and is not in use asynchronously.
        /// </summary>
        /// <param name="name">The Search service name to check.</param>
        /// <return>A representation of the deferred computation of this call, returning whether the name is available or other info if not.</return>
        async Task<Microsoft.Azure.Management.Search.Fluent.ICheckNameAvailabilityResult> Microsoft.Azure.Management.Search.Fluent.ISearchServices.CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken)
        {
            return await this.CheckNameAvailabilityAsync(name, cancellationToken) as Microsoft.Azure.Management.Search.Fluent.ICheckNameAvailabilityResult;
        }

        /// <summary>
        /// Returns the list of query API keys for the given Azure Search service.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the current subscription. You can obtain this value from the Azure Resource Manager API or the portal.</param>
        /// <param name="searchServiceName">The name of the Azure Search service associated with the specified resource group.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        async Task<IEnumerable<Microsoft.Azure.Management.Search.Fluent.IQueryKey>> Microsoft.Azure.Management.Search.Fluent.ISearchServices.ListQueryKeysAsync(string resourceGroupName, string searchServiceName, CancellationToken cancellationToken)
        {
            return await this.ListQueryKeysAsync(resourceGroupName, searchServiceName, cancellationToken) as IEnumerable<Microsoft.Azure.Management.Search.Fluent.IQueryKey>;
        }

        /// <summary>
        /// Gets the primary and secondary admin API keys for the specified Azure Search service.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the current subscription; you can obtain this value from the Azure Resource Manager API or the portal.</param>
        /// <param name="searchServiceName">The name of the Azure Search service associated with the specified resource group.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <throws>CloudException thrown if the request is rejected by server.</throws>
        /// <throws>RuntimeException all other wrapped checked exceptions if the request fails to be sent.</throws>
        /// <return>The AdminKeys object if successful.</return>
        Microsoft.Azure.Management.Search.Fluent.IAdminKeys Microsoft.Azure.Management.Search.Fluent.ISearchServices.GetAdminKeys(string resourceGroupName, string searchServiceName)
        {
            return this.GetAdminKeys(resourceGroupName, searchServiceName) as Microsoft.Azure.Management.Search.Fluent.IAdminKeys;
        }

        /// <summary>
        /// Checks if the specified Search service name is valid and available.
        /// </summary>
        /// <param name="name">The Search service name to check.</param>
        /// <return>Whether the name is available and other info if not.</return>
        Microsoft.Azure.Management.Search.Fluent.ICheckNameAvailabilityResult Microsoft.Azure.Management.Search.Fluent.ISearchServices.CheckNameAvailability(string name)
        {
            return this.CheckNameAvailability(name) as Microsoft.Azure.Management.Search.Fluent.ICheckNameAvailabilityResult;
        }

        /// <summary>
        /// Returns the list of query API keys for the given Azure Search service.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the current subscription; you can obtain this value from the Azure Resource Manager API or the portal.</param>
        /// <param name="searchServiceName">The name of the Azure Search service associated with the specified resource group.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <throws>CloudException thrown if the request is rejected by server.</throws>
        /// <throws>RuntimeException all other wrapped checked exceptions if the request fails to be sent.</throws>
        /// <return>The List&lt;QueryKey&gt; object if successful.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Search.Fluent.IQueryKey> Microsoft.Azure.Management.Search.Fluent.ISearchServices.ListQueryKeys(string resourceGroupName, string searchServiceName)
        {
            return this.ListQueryKeys(resourceGroupName, searchServiceName) as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Search.Fluent.IQueryKey>;
        }

        /// <summary>
        /// Regenerates either the primary or secondary admin API key. You can only regenerate one key at a time.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the current subscription. You can obtain this value from the Azure Resource Manager API or the portal.</param>
        /// <param name="searchServiceName">The name of the Azure Search service associated with the specified resource group.</param>
        /// <param name="name">The name of the new query API key.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        async Task<Microsoft.Azure.Management.Search.Fluent.IQueryKey> Microsoft.Azure.Management.Search.Fluent.ISearchServices.CreateQueryKeyAsync(string resourceGroupName, string searchServiceName, string name, CancellationToken cancellationToken)
        {
            return await this.CreateQueryKeyAsync(resourceGroupName, searchServiceName, name, cancellationToken) as Microsoft.Azure.Management.Search.Fluent.IQueryKey;
        }

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
        void Microsoft.Azure.Management.Search.Fluent.ISearchServices.DeleteQueryKey(string resourceGroupName, string searchServiceName, string key)
        {
 
            this.DeleteQueryKey(resourceGroupName, searchServiceName, key);
        }

        /// <summary>
        /// Gets the primary and secondary admin API keys for the specified Azure Search service.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the current subscription; you can obtain this value from the Azure Resource Manager API or the portal.</param>
        /// <param name="searchServiceName">The name of the Azure Search service associated with the specified resource group.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        async Task<Microsoft.Azure.Management.Search.Fluent.IAdminKeys> Microsoft.Azure.Management.Search.Fluent.ISearchServices.GetAdminKeysAsync(string resourceGroupName, string searchServiceName, CancellationToken cancellationToken)
        {
            return await this.GetAdminKeysAsync(resourceGroupName, searchServiceName, cancellationToken) as Microsoft.Azure.Management.Search.Fluent.IAdminKeys;
        }

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
        async Task<Microsoft.Azure.Management.Search.Fluent.IAdminKeys> Microsoft.Azure.Management.Search.Fluent.ISearchServices.RegenerateAdminKeysAsync(string resourceGroupName, string searchServiceName, AdminKeyKind keyKind, CancellationToken cancellationToken)
        {
            return await this.RegenerateAdminKeysAsync(resourceGroupName, searchServiceName, keyKind, cancellationToken) as Microsoft.Azure.Management.Search.Fluent.IAdminKeys;
        }

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
        Microsoft.Azure.Management.Search.Fluent.IQueryKey Microsoft.Azure.Management.Search.Fluent.ISearchServices.CreateQueryKey(string resourceGroupName, string searchServiceName, string name)
        {
            return this.CreateQueryKey(resourceGroupName, searchServiceName, name) as Microsoft.Azure.Management.Search.Fluent.IQueryKey;
        }

        /// <summary>
        /// Deletes the specified query key. Unlike admin keys, query keys are not regenerated. The process for
        /// regenerating a query key is to delete and then recreate it.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the current subscription. You can obtain this value from the Azure Resource Manager API or the portal.</param>
        /// <param name="searchServiceName">The name of the Azure Search service associated with the specified resource group.</param>
        /// <param name="key">The query key to be deleted. Query keys are identified by value, not by name.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        async Task Microsoft.Azure.Management.Search.Fluent.ISearchServices.DeleteQueryKeyAsync(string resourceGroupName, string searchServiceName, string key, CancellationToken cancellationToken)
        {
 
            await this.DeleteQueryKeyAsync(resourceGroupName, searchServiceName, key, cancellationToken);
        }

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
        Microsoft.Azure.Management.Search.Fluent.IAdminKeys Microsoft.Azure.Management.Search.Fluent.ISearchServices.RegenerateAdminKeys(string resourceGroupName, string searchServiceName, AdminKeyKind keyKind)
        {
            return this.RegenerateAdminKeys(resourceGroupName, searchServiceName, keyKind) as Microsoft.Azure.Management.Search.Fluent.IAdminKeys;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<ISearchService>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Search.Fluent.ISearchService>.ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(loadAllPages, cancellationToken) as Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<ISearchService>;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Search.Fluent.ISearchService> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Search.Fluent.ISearchService>.List()
        {
            return this.List() as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Search.Fluent.ISearchService>;
        }
    }
}