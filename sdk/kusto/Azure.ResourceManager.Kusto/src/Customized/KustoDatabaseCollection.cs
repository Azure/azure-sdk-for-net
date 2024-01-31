// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Kusto
{
    /// <summary>
    /// A class representing a collection of <see cref="KustoDatabaseResource" /> and their operations.
    /// Each <see cref="KustoDatabaseResource" /> in the collection will belong to the same instance of <see cref="KustoClusterResource" />.
    /// To get a <see cref="KustoDatabaseCollection" /> instance call the GetKustoDatabases method from an instance of <see cref="KustoClusterResource" />.
    /// </summary>
    public partial class KustoDatabaseCollection : ArmCollection, IEnumerable<KustoDatabaseResource>, IAsyncEnumerable<KustoDatabaseResource>
    {
        /// <summary>
        /// Creates or updates a database.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Databases_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="databaseName"> The name of the database in the Kusto cluster. </param>
        /// <param name="data"> The database parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<KustoDatabaseResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string databaseName, KustoDatabaseData data, CancellationToken cancellationToken) =>
            await CreateOrUpdateAsync(waitUntil, databaseName, data, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates or updates a database.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Databases_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="databaseName"> The name of the database in the Kusto cluster. </param>
        /// <param name="data"> The database parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<KustoDatabaseResource> CreateOrUpdate(WaitUntil waitUntil, string databaseName, KustoDatabaseData data, CancellationToken cancellationToken) =>
            CreateOrUpdate(waitUntil, databaseName, data, null, cancellationToken);

        /// <summary>
        /// Returns the list of databases of the given Kusto cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Databases_ListByCluster</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="KustoDatabaseResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<KustoDatabaseResource> GetAllAsync(CancellationToken cancellationToken = default)
            => GetAllAsync(null, null, cancellationToken);

        /// <summary>
        /// Returns the list of databases of the given Kusto cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Databases_ListByCluster</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="KustoDatabaseResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<KustoDatabaseResource> GetAll(CancellationToken cancellationToken = default)
            => GetAll(null, null, cancellationToken);

        /// <summary>
        /// Returns the list of databases of the given Kusto cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Databases_ListByCluster</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skiptoken"> Skiptoken is only used if a previous operation returned a partial result. If a previous response contains a nextLink element, the value of the nextLink element will include a skiptoken parameter that specifies a starting point to use for subsequent calls. </param>
        /// <param name="top"> limit the number of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="KustoDatabaseResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<KustoDatabaseResource> GetAllAsync(int? top, string skiptoken, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _kustoDatabaseDatabasesRestClient.CreateListByClusterRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, skiptoken);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _kustoDatabaseDatabasesRestClient.CreateListByClusterNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, skiptoken);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new KustoDatabaseResource(Client, KustoDatabaseData.DeserializeKustoDatabaseData(e)), _kustoDatabaseDatabasesClientDiagnostics, Pipeline, "KustoDatabaseCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Returns the list of databases of the given Kusto cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Databases_ListByCluster</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skiptoken"> Skiptoken is only used if a previous operation returned a partial result. If a previous response contains a nextLink element, the value of the nextLink element will include a skiptoken parameter that specifies a starting point to use for subsequent calls. </param>
        /// <param name="top"> limit the number of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="KustoDatabaseResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<KustoDatabaseResource> GetAll(int? top, string skiptoken, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _kustoDatabaseDatabasesRestClient.CreateListByClusterRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, skiptoken);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _kustoDatabaseDatabasesRestClient.CreateListByClusterNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, skiptoken);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new KustoDatabaseResource(Client, KustoDatabaseData.DeserializeKustoDatabaseData(e)), _kustoDatabaseDatabasesClientDiagnostics, Pipeline, "KustoDatabaseCollection.GetAll", "value", "nextLink", cancellationToken);
        }
    }
}
