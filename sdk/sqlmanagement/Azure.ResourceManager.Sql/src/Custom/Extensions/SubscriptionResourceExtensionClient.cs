// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql.Mock
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class SubscriptionResourceExtension : ArmResource
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
            HttpMessage FirstPageRequest(int? pageSizeHint) => LongTermRetentionBackupsRestClient.CreateListByLocationRequest(Id.SubscriptionId, locationName, onlyLatestPerDatabase, databaseState);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => LongTermRetentionBackupsRestClient.CreateListByLocationNextPageRequest(nextLink, Id.SubscriptionId, locationName, onlyLatestPerDatabase, databaseState);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new SubscriptionLongTermRetentionBackupResource(Client, LongTermRetentionBackupData.DeserializeLongTermRetentionBackupData(e)), LongTermRetentionBackupsClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetLongTermRetentionBackupsByLocation", "value", "nextLink", cancellationToken);
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
            HttpMessage FirstPageRequest(int? pageSizeHint) => LongTermRetentionBackupsRestClient.CreateListByLocationRequest(Id.SubscriptionId, locationName, onlyLatestPerDatabase, databaseState);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => LongTermRetentionBackupsRestClient.CreateListByLocationNextPageRequest(nextLink, Id.SubscriptionId, locationName, onlyLatestPerDatabase, databaseState);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new SubscriptionLongTermRetentionBackupResource(Client, LongTermRetentionBackupData.DeserializeLongTermRetentionBackupData(e)), LongTermRetentionBackupsClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetLongTermRetentionBackupsByLocation", "value", "nextLink", cancellationToken);
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
            HttpMessage FirstPageRequest(int? pageSizeHint) => LongTermRetentionBackupsRestClient.CreateListByServerRequest(Id.SubscriptionId, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => LongTermRetentionBackupsRestClient.CreateListByServerNextPageRequest(nextLink, Id.SubscriptionId, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new SubscriptionLongTermRetentionBackupResource(Client, LongTermRetentionBackupData.DeserializeLongTermRetentionBackupData(e)), LongTermRetentionBackupsClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetLongTermRetentionBackupsByServer", "value", "nextLink", cancellationToken);
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
            HttpMessage FirstPageRequest(int? pageSizeHint) => LongTermRetentionBackupsRestClient.CreateListByServerRequest(Id.SubscriptionId, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => LongTermRetentionBackupsRestClient.CreateListByServerNextPageRequest(nextLink, Id.SubscriptionId, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new SubscriptionLongTermRetentionBackupResource(Client, LongTermRetentionBackupData.DeserializeLongTermRetentionBackupData(e)), LongTermRetentionBackupsClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetLongTermRetentionBackupsByServer", "value", "nextLink", cancellationToken);
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
            HttpMessage FirstPageRequest(int? pageSizeHint) => LongTermRetentionManagedInstanceBackupsRestClient.CreateListByInstanceRequest(Id.SubscriptionId, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => LongTermRetentionManagedInstanceBackupsRestClient.CreateListByInstanceNextPageRequest(nextLink, Id.SubscriptionId, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, ManagedInstanceLongTermRetentionBackupData.DeserializeManagedInstanceLongTermRetentionBackupData(e)), LongTermRetentionManagedInstanceBackupsClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByInstance", "value", "nextLink", cancellationToken);
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
            HttpMessage FirstPageRequest(int? pageSizeHint) => LongTermRetentionManagedInstanceBackupsRestClient.CreateListByInstanceRequest(Id.SubscriptionId, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => LongTermRetentionManagedInstanceBackupsRestClient.CreateListByInstanceNextPageRequest(nextLink, Id.SubscriptionId, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, ManagedInstanceLongTermRetentionBackupData.DeserializeManagedInstanceLongTermRetentionBackupData(e)), LongTermRetentionManagedInstanceBackupsClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByInstance", "value", "nextLink", cancellationToken);
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
            HttpMessage FirstPageRequest(int? pageSizeHint) => LongTermRetentionManagedInstanceBackupsRestClient.CreateListByLocationRequest(Id.SubscriptionId, locationName, onlyLatestPerDatabase, databaseState);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => LongTermRetentionManagedInstanceBackupsRestClient.CreateListByLocationNextPageRequest(nextLink, Id.SubscriptionId, locationName, onlyLatestPerDatabase, databaseState);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, ManagedInstanceLongTermRetentionBackupData.DeserializeManagedInstanceLongTermRetentionBackupData(e)), LongTermRetentionManagedInstanceBackupsClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByLocation", "value", "nextLink", cancellationToken);
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
            HttpMessage FirstPageRequest(int? pageSizeHint) => LongTermRetentionManagedInstanceBackupsRestClient.CreateListByLocationRequest(Id.SubscriptionId, locationName, onlyLatestPerDatabase, databaseState);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => LongTermRetentionManagedInstanceBackupsRestClient.CreateListByLocationNextPageRequest(nextLink, Id.SubscriptionId, locationName, onlyLatestPerDatabase, databaseState);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, ManagedInstanceLongTermRetentionBackupData.DeserializeManagedInstanceLongTermRetentionBackupData(e)), LongTermRetentionManagedInstanceBackupsClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByLocation", "value", "nextLink", cancellationToken);
        }
    }
}
