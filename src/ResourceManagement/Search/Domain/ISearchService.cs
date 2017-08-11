// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Search.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Search.Fluent.Models;
    using Microsoft.Azure.Management.Search.Fluent.SearchService.Update;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure registry.
    /// </summary>
    public interface ISearchService  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Search.Fluent.ISearchManager,Models.SearchServiceInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Search.Fluent.ISearchService>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SearchService.Update.IUpdate>
    {
        /// <summary>
        /// Regenerates either the primary or secondary admin API key.
        /// You can only regenerate one key at a time.
        /// </summary>
        /// <param name="name">The name of the new query API key.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <throws>CloudException thrown if the request is rejected by server.</throws>
        /// <throws>RuntimeException all other wrapped checked exceptions if the request fails to be sent.</throws>
        /// <return>The &lt;QueryKey&gt; object if successful.</return>
        Microsoft.Azure.Management.Search.Fluent.IQueryKey CreateQueryKey(string name);

        /// <summary>
        /// Regenerates either the primary or secondary admin API key.
        /// You can only regenerate one key at a time.
        /// </summary>
        /// <param name="keyKind">Specifies which key to regenerate.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <throws>CloudException thrown if the request is rejected by server.</throws>
        /// <throws>RuntimeException all other wrapped checked exceptions if the request fails to be sent.</throws>
        /// <return>The AdminKeys object if successful.</return>
        Microsoft.Azure.Management.Search.Fluent.IAdminKeys RegenerateAdminKeys(AdminKeyKind keyKind);

        /// <summary>
        /// The primary and secondary admin API keys for the specified Azure Search service.
        /// </summary>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        Task<Microsoft.Azure.Management.Search.Fluent.IAdminKeys> GetAdminKeysAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the specified query key.
        /// Unlike admin keys, query keys are not regenerated. The process for
        /// regenerating a query key is to delete and then recreate it.
        /// </summary>
        /// <param name="key">The query key to be deleted. Query keys are identified by value, not by name.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        Task DeleteQueryKeyAsync(string key, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Regenerates either the primary or secondary admin API key. You can only regenerate one key at a time.
        /// </summary>
        /// <param name="keyKind">Specifies which key to regenerate.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        Task<Microsoft.Azure.Management.Search.Fluent.IAdminKeys> RegenerateAdminKeysAsync(AdminKeyKind keyKind, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Regenerates either the primary or secondary admin API key.
        /// You can only regenerate one key at a time.
        /// </summary>
        /// <param name="name">The name of the new query API key.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        Task<Microsoft.Azure.Management.Search.Fluent.IQueryKey> CreateQueryKeyAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets The hosting mode value.
        /// Applicable only for the standard3 SKU. You can set this property to enable up to 3 high density partitions that
        /// allow up to 1000 indexes, which is much higher than the maximum indexes allowed for any other SKU. For the
        /// standard3 SKU, the value is either 'default' or 'highDensity'. For all other SKUs, this value must be 'default'.
        /// </summary>
        /// <summary>
        /// Gets the hosting mode value.
        /// </summary>
        Models.HostingMode HostingMode { get; }

        /// <summary>
        /// Returns the list of query API keys for the given Azure Search service.
        /// </summary>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable to the List&lt;QueryKey&gt; object.</return>
        Task<IEnumerable<Microsoft.Azure.Management.Search.Fluent.IQueryKey>> ListQueryKeysAsync(CancellationToken cancellationToken = default(CancellationToken));

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
        Models.ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets the number of partitions used by the service.
        /// </summary>
        int PartitionCount { get; }

        /// <summary>
        /// Gets the number of replicas used by the service.
        /// </summary>
        int ReplicaCount { get; }

        /// <summary>
        /// Gets the details of the status.
        /// </summary>
        string StatusDetails { get; }

        /// <summary>
        /// Deletes the specified query key.
        /// Unlike admin keys, query keys are not regenerated. The process for regenerating a query key is to delete and then
        /// recreate it.
        /// </summary>
        /// <param name="key">The query key to be deleted. Query keys are identified by value, not by name.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <throws>CloudException thrown if the request is rejected by server.</throws>
        /// <throws>RuntimeException all other wrapped checked exceptions if the request fails to be sent.</throws>
        void DeleteQueryKey(string key);

        /// <summary>
        /// The primary and secondary admin API keys for the specified Azure Search service.
        /// </summary>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <throws>CloudException thrown if the request is rejected by server.</throws>
        /// <throws>RuntimeException all other wrapped checked exceptions if the request fails to be sent.</throws>
        /// <return>The AdminKeys object if successful.</return>
        Microsoft.Azure.Management.Search.Fluent.IAdminKeys GetAdminKeys();

        /// <summary>
        /// Gets the SKU type of the service.
        /// </summary>
        Models.Sku Sku { get; }

        /// <summary>
        /// Returns the list of query API keys for the given Azure Search service.
        /// </summary>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <throws>CloudException thrown if the request is rejected by server.</throws>
        /// <throws>RuntimeException all other wrapped checked exceptions if the request fails to be sent.</throws>
        /// <return>The List&lt;QueryKey&gt; object if successful.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Search.Fluent.IQueryKey> ListQueryKeys();

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
        Models.SearchServiceStatus Status { get; }
    }
}