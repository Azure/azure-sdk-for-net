// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Search.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Search.Fluent.Models;
    using Microsoft.Azure.Management.Search.Fluent.SearchService.Definition;
    using Microsoft.Azure.Management.Search.Fluent.SearchService.Update;
    using System.Collections.Generic;
    using System;

    internal partial class SearchServiceImpl 
    {
        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.Search.Fluent.ISearchService> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Search.Fluent.ISearchService>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken) as Microsoft.Azure.Management.Search.Fluent.ISearchService;
        }

        /// <summary>
        /// Specifies the Partitions count of the Search service.
        /// </summary>
        /// <param name="count">The partitions count; Partitions allow for scaling of document counts as well as faster data ingestion by spanning your index over multiple Azure Search Units (applies to Standard tiers only).</param>
        /// <return>The next stage of the definition.</return>
        SearchService.Update.IUpdate SearchService.Update.IWithPartitionCount.WithPartitionCount(int count)
        {
            return this.WithPartitionCount(count) as SearchService.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the replicas count of the Search service.
        /// </summary>
        /// <param name="count">The replicas count; replicas distribute workloads across the service. You need 2 or more to support high availability (applies to Basic and Standard tiers only).</param>
        /// <return>The next stage of the definition.</return>
        SearchService.Update.IUpdate SearchService.Update.IWithReplicaCount.WithReplicaCount(int count)
        {
            return this.WithReplicaCount(count) as SearchService.Update.IUpdate;
        }

        /// <summary>
        /// Gets The hosting mode value.
        /// Applicable only for the standard3 SKU. You can set this property to enable up to 3 high density partitions that
        /// allow up to 1000 indexes, which is much higher than the maximum indexes allowed for any other SKU. For the
        /// standard3 SKU, the value is either 'default' or 'highDensity'. For all other SKUs, this value must be 'default'.
        /// </summary>
        /// <summary>
        /// Gets the hosting mode value.
        /// </summary>
        Models.HostingMode Microsoft.Azure.Management.Search.Fluent.ISearchService.HostingMode
        {
            get
            {
                return this.HostingMode();
            }
        }

        /// <summary>
        /// Returns the list of query API keys for the given Azure Search service.
        /// </summary>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable to the List&lt;QueryKey&gt; object.</return>
        async Task<IEnumerable<Microsoft.Azure.Management.Search.Fluent.IQueryKey>> Microsoft.Azure.Management.Search.Fluent.ISearchService.ListQueryKeysAsync(CancellationToken cancellationToken)
        {
            return await this.ListQueryKeysAsync(cancellationToken) as IEnumerable<Microsoft.Azure.Management.Search.Fluent.IQueryKey>;
        }

        /// <summary>
        /// Gets the number of replicas used by the service.
        /// </summary>
        int Microsoft.Azure.Management.Search.Fluent.ISearchService.ReplicaCount
        {
            get
            {
                return this.ReplicaCount();
            }
        }

        /// <summary>
        /// Gets the number of partitions used by the service.
        /// </summary>
        int Microsoft.Azure.Management.Search.Fluent.ISearchService.PartitionCount
        {
            get
            {
                return this.PartitionCount();
            }
        }

        /// <summary>
        /// The primary and secondary admin API keys for the specified Azure Search service.
        /// </summary>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <throws>CloudException thrown if the request is rejected by server.</throws>
        /// <throws>RuntimeException all other wrapped checked exceptions if the request fails to be sent.</throws>
        /// <return>The AdminKeys object if successful.</return>
        Microsoft.Azure.Management.Search.Fluent.IAdminKeys Microsoft.Azure.Management.Search.Fluent.ISearchService.GetAdminKeys()
        {
            return this.GetAdminKeys() as Microsoft.Azure.Management.Search.Fluent.IAdminKeys;
        }

        /// <summary>
        /// Returns the list of query API keys for the given Azure Search service.
        /// </summary>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <throws>CloudException thrown if the request is rejected by server.</throws>
        /// <throws>RuntimeException all other wrapped checked exceptions if the request fails to be sent.</throws>
        /// <return>The List&lt;QueryKey&gt; object if successful.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Search.Fluent.IQueryKey> Microsoft.Azure.Management.Search.Fluent.ISearchService.ListQueryKeys()
        {
            return this.ListQueryKeys() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Search.Fluent.IQueryKey>;
        }

        /// <summary>
        /// Gets The state of the last provisioning operation performed on the Search service.
        /// Provisioning is an intermediate state that occurs while service capacity is being established. After capacity
        /// is set up, provisioningState changes to either 'succeeded' or 'failed'. Client applications can poll
        /// provisioning status (the recommended polling interval is from 30 seconds to one minute) by using the Get Search
        /// Service operation to see when an operation is completed. If you are using the free service, this value tends
        /// to come back as 'succeeded' directly in the call to Create Search service. This is because the free service uses
        /// capacity that is already set up.
        /// </summary>
        /// <summary>
        /// Gets the provisioning state of the resource.
        /// </summary>
        Models.ProvisioningState Microsoft.Azure.Management.Search.Fluent.ISearchService.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Regenerates either the primary or secondary admin API key.
        /// You can only regenerate one key at a time.
        /// </summary>
        /// <param name="name">The name of the new query API key.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        async Task<Microsoft.Azure.Management.Search.Fluent.IQueryKey> Microsoft.Azure.Management.Search.Fluent.ISearchService.CreateQueryKeyAsync(string name, CancellationToken cancellationToken)
        {
            return await this.CreateQueryKeyAsync(name, cancellationToken) as Microsoft.Azure.Management.Search.Fluent.IQueryKey;
        }

        /// <summary>
        /// Gets the SKU type of the service.
        /// </summary>
        Models.Sku Microsoft.Azure.Management.Search.Fluent.ISearchService.Sku
        {
            get
            {
                return this.Sku() as Models.Sku;
            }
        }

        /// <summary>
        /// Deletes the specified query key.
        /// Unlike admin keys, query keys are not regenerated. The process for regenerating a query key is to delete and then
        /// recreate it.
        /// </summary>
        /// <param name="key">The query key to be deleted. Query keys are identified by value, not by name.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <throws>CloudException thrown if the request is rejected by server.</throws>
        /// <throws>RuntimeException all other wrapped checked exceptions if the request fails to be sent.</throws>
        void Microsoft.Azure.Management.Search.Fluent.ISearchService.DeleteQueryKey(string key)
        {
 
            this.DeleteQueryKey(key);
        }

        /// <summary>
        /// Gets the details of the status.
        /// </summary>
        string Microsoft.Azure.Management.Search.Fluent.ISearchService.StatusDetails
        {
            get
            {
                return this.StatusDetails();
            }
        }

        /// <summary>
        /// Gets The status of the Search service.
        /// Possible values include:
        /// 'running':  the Search service is running and no provisioning operations are underway.
        /// 'provisioning': the Search service is being provisioned or scaled up or down.
        /// 'deleting': the Search service is being deleted.
        /// 'degraded': the Search service is degraded. This can occur when the underlying search units are not healthy.
        /// The Search service is most likely operational, but performance might be slow and some requests might be dropped.
        /// 'disabled': the Search service is disabled. In this state, the service will reject all API requests.
        /// 'error': the Search service is in an error state. If your service is in the degraded, disabled, or error states,
        /// it means the Azure Search team is actively investigating the underlying issue. Dedicated services in these
        /// states are still chargeable based on the number of search units provisioned.
        /// </summary>
        /// <summary>
        /// Gets the status of the service.
        /// </summary>
        Models.SearchServiceStatus Microsoft.Azure.Management.Search.Fluent.ISearchService.Status
        {
            get
            {
                return this.Status();
            }
        }

        /// <summary>
        /// The primary and secondary admin API keys for the specified Azure Search service.
        /// </summary>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        async Task<Microsoft.Azure.Management.Search.Fluent.IAdminKeys> Microsoft.Azure.Management.Search.Fluent.ISearchService.GetAdminKeysAsync(CancellationToken cancellationToken)
        {
            return await this.GetAdminKeysAsync(cancellationToken) as Microsoft.Azure.Management.Search.Fluent.IAdminKeys;
        }

        /// <summary>
        /// Regenerates either the primary or secondary admin API key. You can only regenerate one key at a time.
        /// </summary>
        /// <param name="keyKind">Specifies which key to regenerate.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        async Task<Microsoft.Azure.Management.Search.Fluent.IAdminKeys> Microsoft.Azure.Management.Search.Fluent.ISearchService.RegenerateAdminKeysAsync(AdminKeyKind keyKind, CancellationToken cancellationToken)
        {
            return await this.RegenerateAdminKeysAsync(keyKind, cancellationToken) as Microsoft.Azure.Management.Search.Fluent.IAdminKeys;
        }

        /// <summary>
        /// Regenerates either the primary or secondary admin API key.
        /// You can only regenerate one key at a time.
        /// </summary>
        /// <param name="name">The name of the new query API key.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <throws>CloudException thrown if the request is rejected by server.</throws>
        /// <throws>RuntimeException all other wrapped checked exceptions if the request fails to be sent.</throws>
        /// <return>The &lt;QueryKey&gt; object if successful.</return>
        Microsoft.Azure.Management.Search.Fluent.IQueryKey Microsoft.Azure.Management.Search.Fluent.ISearchService.CreateQueryKey(string name)
        {
            return this.CreateQueryKey(name) as Microsoft.Azure.Management.Search.Fluent.IQueryKey;
        }

        /// <summary>
        /// Deletes the specified query key.
        /// Unlike admin keys, query keys are not regenerated. The process for
        /// regenerating a query key is to delete and then recreate it.
        /// </summary>
        /// <param name="key">The query key to be deleted. Query keys are identified by value, not by name.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        async Task Microsoft.Azure.Management.Search.Fluent.ISearchService.DeleteQueryKeyAsync(string key, CancellationToken cancellationToken)
        {
 
            await this.DeleteQueryKeyAsync(key, cancellationToken);
        }

        /// <summary>
        /// Regenerates either the primary or secondary admin API key.
        /// You can only regenerate one key at a time.
        /// </summary>
        /// <param name="keyKind">Specifies which key to regenerate.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <throws>CloudException thrown if the request is rejected by server.</throws>
        /// <throws>RuntimeException all other wrapped checked exceptions if the request fails to be sent.</throws>
        /// <return>The AdminKeys object if successful.</return>
        Microsoft.Azure.Management.Search.Fluent.IAdminKeys Microsoft.Azure.Management.Search.Fluent.ISearchService.RegenerateAdminKeys(AdminKeyKind keyKind)
        {
            return this.RegenerateAdminKeys(keyKind) as Microsoft.Azure.Management.Search.Fluent.IAdminKeys;
        }

        /// <summary>
        /// Specifies the SKU of the Search service.
        /// </summary>
        /// <param name="count">The number of replicas to be created.</param>
        /// <return>The next stage of the definition.</return>
        SearchService.Definition.IWithCreate SearchService.Definition.IWithReplicasAndCreate.WithReplicaCount(int count)
        {
            return this.WithReplicaCount(count) as SearchService.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the SKU of the Search service.
        /// </summary>
        /// <param name="count">The number of partitions to be created.</param>
        /// <return>The next stage of the definition.</return>
        SearchService.Definition.IWithReplicasAndCreate SearchService.Definition.IWithPartitionsAndCreate.WithPartitionCount(int count)
        {
            return this.WithPartitionCount(count) as SearchService.Definition.IWithReplicasAndCreate;
        }

        /// <summary>
        /// Specifies to use a free SKU type for the Search service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SearchService.Definition.IWithCreate SearchService.Definition.IWithSku.WithFreeSku()
        {
            return this.WithFreeSku() as SearchService.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the SKU of the Search service.
        /// </summary>
        /// <param name="skuName">The SKU.</param>
        /// <return>The next stage of the definition.</return>
        SearchService.Definition.IWithCreate SearchService.Definition.IWithSku.WithSku(SkuName skuName)
        {
            return this.WithSku(skuName) as SearchService.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies to use a basic SKU type for the Search service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SearchService.Definition.IWithReplicasAndCreate SearchService.Definition.IWithSku.WithBasicSku()
        {
            return this.WithBasicSku() as SearchService.Definition.IWithReplicasAndCreate;
        }

        /// <summary>
        /// Specifies to use a standard SKU type for the Search service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SearchService.Definition.IWithPartitionsAndCreate SearchService.Definition.IWithSku.WithStandardSku()
        {
            return this.WithStandardSku() as SearchService.Definition.IWithPartitionsAndCreate;
        }

    }
}