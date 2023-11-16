// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql.Mocking
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    public partial class MockableSqlResourceGroupResource : ArmResource
    {
        /// <summary>
        /// Lists the long term retention backups for a given location.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionBackups
        /// Operation Id: LongTermRetentionBackups_ListByResourceGroupLocation
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupLocationAsync(AzureLocation locationName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SubscriptionLongTermRetentionBackupResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetLongTermRetentionBackupsByResourceGroupLocation");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionBackupsRestClient.ListByResourceGroupLocationAsync(Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionBackupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SubscriptionLongTermRetentionBackupResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetLongTermRetentionBackupsByResourceGroupLocation");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionBackupsRestClient.ListByResourceGroupLocationNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionBackupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists the long term retention backups for a given location.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionBackups
        /// Operation Id: LongTermRetentionBackups_ListByResourceGroupLocation
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupLocation(AzureLocation locationName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            Page<SubscriptionLongTermRetentionBackupResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetLongTermRetentionBackupsByResourceGroupLocation");
                scope.Start();
                try
                {
                    var response = LongTermRetentionBackupsRestClient.ListByResourceGroupLocation(Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionBackupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SubscriptionLongTermRetentionBackupResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetLongTermRetentionBackupsByResourceGroupLocation");
                scope.Start();
                try
                {
                    var response = LongTermRetentionBackupsRestClient.ListByResourceGroupLocationNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionBackupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists the long term retention backups for a given server.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionBackups
        /// Operation Id: LongTermRetentionBackups_ListByResourceGroupServer
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="longTermRetentionServerName"> The name of the server. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupServerAsync(AzureLocation locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(longTermRetentionServerName, nameof(longTermRetentionServerName));

            async Task<Page<SubscriptionLongTermRetentionBackupResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetLongTermRetentionBackupsByResourceGroupServer");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionBackupsRestClient.ListByResourceGroupServerAsync(Id.SubscriptionId, Id.ResourceGroupName, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionBackupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SubscriptionLongTermRetentionBackupResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetLongTermRetentionBackupsByResourceGroupServer");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionBackupsRestClient.ListByResourceGroupServerNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionBackupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists the long term retention backups for a given server.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionBackups
        /// Operation Id: LongTermRetentionBackups_ListByResourceGroupServer
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="longTermRetentionServerName"> The name of the server. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupServer(AzureLocation locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(longTermRetentionServerName, nameof(longTermRetentionServerName));

            Page<SubscriptionLongTermRetentionBackupResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetLongTermRetentionBackupsByResourceGroupServer");
                scope.Start();
                try
                {
                    var response = LongTermRetentionBackupsRestClient.ListByResourceGroupServer(Id.SubscriptionId, Id.ResourceGroupName, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionBackupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SubscriptionLongTermRetentionBackupResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetLongTermRetentionBackupsByResourceGroupServer");
                scope.Start();
                try
                {
                    var response = LongTermRetentionBackupsRestClient.ListByResourceGroupServerNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionBackupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists the long term retention backups for a given managed instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstances/{managedInstanceName}/longTermRetentionManagedInstanceBackups
        /// Operation Id: LongTermRetentionManagedInstanceBackups_ListByResourceGroupInstance
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="managedInstanceName"> The name of the managed instance. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstanceAsync(AzureLocation locationName, string managedInstanceName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(managedInstanceName, nameof(managedInstanceName));

            async Task<Page<SubscriptionLongTermRetentionManagedInstanceBackupResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionManagedInstanceBackupsRestClient.ListByResourceGroupInstanceAsync(Id.SubscriptionId, Id.ResourceGroupName, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SubscriptionLongTermRetentionManagedInstanceBackupResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionManagedInstanceBackupsRestClient.ListByResourceGroupInstanceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists the long term retention backups for a given managed instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstances/{managedInstanceName}/longTermRetentionManagedInstanceBackups
        /// Operation Id: LongTermRetentionManagedInstanceBackups_ListByResourceGroupInstance
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="managedInstanceName"> The name of the managed instance. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance(AzureLocation locationName, string managedInstanceName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(managedInstanceName, nameof(managedInstanceName));

            Page<SubscriptionLongTermRetentionManagedInstanceBackupResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance");
                scope.Start();
                try
                {
                    var response = LongTermRetentionManagedInstanceBackupsRestClient.ListByResourceGroupInstance(Id.SubscriptionId, Id.ResourceGroupName, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SubscriptionLongTermRetentionManagedInstanceBackupResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance");
                scope.Start();
                try
                {
                    var response = LongTermRetentionManagedInstanceBackupsRestClient.ListByResourceGroupInstanceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists the long term retention backups for managed databases in a given location.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstanceBackups
        /// Operation Id: LongTermRetentionManagedInstanceBackups_ListByResourceGroupLocation
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocationAsync(AzureLocation locationName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SubscriptionLongTermRetentionManagedInstanceBackupResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocation");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionManagedInstanceBackupsRestClient.ListByResourceGroupLocationAsync(Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SubscriptionLongTermRetentionManagedInstanceBackupResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocation");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionManagedInstanceBackupsRestClient.ListByResourceGroupLocationNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists the long term retention backups for managed databases in a given location.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstanceBackups
        /// Operation Id: LongTermRetentionManagedInstanceBackups_ListByResourceGroupLocation
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocation(AzureLocation locationName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            Page<SubscriptionLongTermRetentionManagedInstanceBackupResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocation");
                scope.Start();
                try
                {
                    var response = LongTermRetentionManagedInstanceBackupsRestClient.ListByResourceGroupLocation(Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SubscriptionLongTermRetentionManagedInstanceBackupResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocation");
                scope.Start();
                try
                {
                    var response = LongTermRetentionManagedInstanceBackupsRestClient.ListByResourceGroupLocationNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
