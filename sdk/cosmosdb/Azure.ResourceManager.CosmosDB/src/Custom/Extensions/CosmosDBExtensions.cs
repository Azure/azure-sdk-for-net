// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.CosmosDB.Mocking;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB
{
    // Companion partial that restores a single canonical extension method to map
    // ArmClient.GetCassandraClusterResource onto MockableCosmosDBArmClient, after the
    // CodeGenSuppress on this class removes the duplicate generators emitted from
    // @segment("backups") / @segment("commands") action paths in ClusterResource.tsp.
    //
    // It also restores ResourceGroupResource.GetCassandraCluster(Async) extension
    // methods that the MPG generator drops because CassandraClusterCollection.Get is
    // a CustomCodeView partial (see Custom/Resources/CassandraClusterCollection.cs and
    // Custom/Extensions/MockableCosmosDBResourceGroupResource.cs).
    // Tracking issue: https://github.com/Azure/azure-sdk-for-net/issues/59094
    [CodeGenSuppress("GetCassandraClusterResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    public static partial class CosmosDBExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="CassandraClusterResource"/> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="CassandraClusterResource"/> object. </returns>
        public static CassandraClusterResource GetCassandraClusterResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableCosmosDBArmClient(client).GetCassandraClusterResource(id);
        }

        /// <summary>
        /// Get the properties of a managed Cassandra cluster.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> CassandraClusters_Get. </description>
        /// </item>
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableCosmosDBResourceGroupResource.GetCassandraClusterAsync(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="clusterName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Task<Response<CassandraClusterResource>> GetCassandraClusterAsync(this ResourceGroupResource resourceGroupResource, string clusterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableCosmosDBResourceGroupResource(resourceGroupResource).GetCassandraClusterAsync(clusterName, cancellationToken);
        }

        /// <summary>
        /// Get the properties of a managed Cassandra cluster.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> CassandraClusters_Get. </description>
        /// </item>
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableCosmosDBResourceGroupResource.GetCassandraCluster(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="clusterName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<CassandraClusterResource> GetCassandraCluster(this ResourceGroupResource resourceGroupResource, string clusterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableCosmosDBResourceGroupResource(resourceGroupResource).GetCassandraCluster(clusterName, cancellationToken);
        }

        /// <summary>
        /// Companion accessor that mirrors the generator-private GetMockableCosmosDBTenantResource helper.
        /// Required to delegate the back-compat extension methods below to the mockable.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Mocking.MockableCosmosDBTenantResource GetMockableCosmosDBTenantResourceForCustom(TenantResource tenantResource)
        {
            return tenantResource.GetCachedClient(client => new Mocking.MockableCosmosDBTenantResource(client, tenantResource.Id));
        }

        /// <summary>
        /// Checks that the Azure Cosmos DB account name already exists. A valid account name may contain only
        /// lowercase letters, numbers, and the '-' character, and must be between 3 and 50 characters.
        /// Restored after the MPG generator stopped emitting the extension wrapper for the @head op
        /// transformed by @@responseAsBool (the mockable method is provided as custom code in
        /// Custom/Extensions/MockableCosmosDBTenantResource.cs).
        /// Tracking issue: https://github.com/Azure/azure-sdk-for-net/issues/59089
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource"/> the method will execute against. </param>
        /// <param name="accountName"> Cosmos DB database account name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> or <paramref name="accountName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="accountName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Task<Response<bool>> CheckNameExistsDatabaseAccountAsync(this TenantResource tenantResource, string accountName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableCosmosDBTenantResourceForCustom(tenantResource).CheckNameExistsDatabaseAccountAsync(accountName, cancellationToken);
        }

        /// <summary>
        /// Checks that the Azure Cosmos DB account name already exists. A valid account name may contain only
        /// lowercase letters, numbers, and the '-' character, and must be between 3 and 50 characters.
        /// Restored after the MPG generator stopped emitting the extension wrapper for the @head op
        /// transformed by @@responseAsBool (the mockable method is provided as custom code in
        /// Custom/Extensions/MockableCosmosDBTenantResource.cs).
        /// Tracking issue: https://github.com/Azure/azure-sdk-for-net/issues/59089
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource"/> the method will execute against. </param>
        /// <param name="accountName"> Cosmos DB database account name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> or <paramref name="accountName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="accountName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<bool> CheckNameExistsDatabaseAccount(this TenantResource tenantResource, string accountName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableCosmosDBTenantResourceForCustom(tenantResource).CheckNameExistsDatabaseAccount(accountName, cancellationToken);
        }
    }
}
