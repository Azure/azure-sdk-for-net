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
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class MockableSqlSubscriptionResource : ArmResource
    {
        /// <summary>
        /// Lists the long term retention backups for a given location.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionBackups
        /// Operation Id: LongTermRetentionBackups_ListByLocation
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByLocationAsync(AzureLocation locationName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SubscriptionLongTermRetentionBackupResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetLongTermRetentionBackupsByLocation");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionBackupsRestClient.ListByLocationAsync(Id.SubscriptionId, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetLongTermRetentionBackupsByLocation");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionBackupsRestClient.ListByLocationNextPageAsync(nextLink, Id.SubscriptionId, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionBackups
        /// Operation Id: LongTermRetentionBackups_ListByLocation
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByLocation(AzureLocation locationName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            Page<SubscriptionLongTermRetentionBackupResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetLongTermRetentionBackupsByLocation");
                scope.Start();
                try
                {
                    var response = LongTermRetentionBackupsRestClient.ListByLocation(Id.SubscriptionId, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
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
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetLongTermRetentionBackupsByLocation");
                scope.Start();
                try
                {
                    var response = LongTermRetentionBackupsRestClient.ListByLocationNextPage(nextLink, Id.SubscriptionId, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionBackups
        /// Operation Id: LongTermRetentionBackups_ListByServer
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="longTermRetentionServerName"> The name of the server. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByServerAsync(AzureLocation locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(longTermRetentionServerName, nameof(longTermRetentionServerName));

            async Task<Page<SubscriptionLongTermRetentionBackupResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetLongTermRetentionBackupsByServer");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionBackupsRestClient.ListByServerAsync(Id.SubscriptionId, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetLongTermRetentionBackupsByServer");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionBackupsRestClient.ListByServerNextPageAsync(nextLink, Id.SubscriptionId, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionBackups
        /// Operation Id: LongTermRetentionBackups_ListByServer
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="longTermRetentionServerName"> The name of the server. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByServer(AzureLocation locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(longTermRetentionServerName, nameof(longTermRetentionServerName));

            Page<SubscriptionLongTermRetentionBackupResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetLongTermRetentionBackupsByServer");
                scope.Start();
                try
                {
                    var response = LongTermRetentionBackupsRestClient.ListByServer(Id.SubscriptionId, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
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
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetLongTermRetentionBackupsByServer");
                scope.Start();
                try
                {
                    var response = LongTermRetentionBackupsRestClient.ListByServerNextPage(nextLink, Id.SubscriptionId, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstances/{managedInstanceName}/longTermRetentionManagedInstanceBackups
        /// Operation Id: LongTermRetentionManagedInstanceBackups_ListByInstance
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="managedInstanceName"> The name of the managed instance. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByInstanceAsync(AzureLocation locationName, string managedInstanceName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(managedInstanceName, nameof(managedInstanceName));

            async Task<Page<SubscriptionLongTermRetentionManagedInstanceBackupResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByInstance");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionManagedInstanceBackupsRestClient.ListByInstanceAsync(Id.SubscriptionId, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByInstance");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionManagedInstanceBackupsRestClient.ListByInstanceNextPageAsync(nextLink, Id.SubscriptionId, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstances/{managedInstanceName}/longTermRetentionManagedInstanceBackups
        /// Operation Id: LongTermRetentionManagedInstanceBackups_ListByInstance
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="managedInstanceName"> The name of the managed instance. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByInstance(AzureLocation locationName, string managedInstanceName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(managedInstanceName, nameof(managedInstanceName));

            Page<SubscriptionLongTermRetentionManagedInstanceBackupResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByInstance");
                scope.Start();
                try
                {
                    var response = LongTermRetentionManagedInstanceBackupsRestClient.ListByInstance(Id.SubscriptionId, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
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
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByInstance");
                scope.Start();
                try
                {
                    var response = LongTermRetentionManagedInstanceBackupsRestClient.ListByInstanceNextPage(nextLink, Id.SubscriptionId, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstanceBackups
        /// Operation Id: LongTermRetentionManagedInstanceBackups_ListByLocation
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByLocationAsync(AzureLocation locationName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SubscriptionLongTermRetentionManagedInstanceBackupResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByLocation");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionManagedInstanceBackupsRestClient.ListByLocationAsync(Id.SubscriptionId, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByLocation");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionManagedInstanceBackupsRestClient.ListByLocationNextPageAsync(nextLink, Id.SubscriptionId, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstanceBackups
        /// Operation Id: LongTermRetentionManagedInstanceBackups_ListByLocation
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByLocation(AzureLocation locationName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            Page<SubscriptionLongTermRetentionManagedInstanceBackupResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByLocation");
                scope.Start();
                try
                {
                    var response = LongTermRetentionManagedInstanceBackupsRestClient.ListByLocation(Id.SubscriptionId, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
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
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByLocation");
                scope.Start();
                try
                {
                    var response = LongTermRetentionManagedInstanceBackupsRestClient.ListByLocationNextPage(nextLink, Id.SubscriptionId, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
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
