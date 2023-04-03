// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql.Mock
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    public partial class SqlResourceGroupResourceExtension : ArmResource
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
            HttpMessage FirstPageRequest(int? pageSizeHint) => LongTermRetentionBackupsRestClient.CreateListByResourceGroupLocationRequest(Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => LongTermRetentionBackupsRestClient.CreateListByResourceGroupLocationNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new SubscriptionLongTermRetentionBackupResource(Client, LongTermRetentionBackupData.DeserializeLongTermRetentionBackupData(e)), LongTermRetentionBackupsClientDiagnostics, Pipeline, "ResourceGroupResourceExtension.GetLongTermRetentionBackupsByResourceGroupLocation", "value", "nextLink", cancellationToken);
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
            HttpMessage FirstPageRequest(int? pageSizeHint) => LongTermRetentionBackupsRestClient.CreateListByResourceGroupLocationRequest(Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => LongTermRetentionBackupsRestClient.CreateListByResourceGroupLocationNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new SubscriptionLongTermRetentionBackupResource(Client, LongTermRetentionBackupData.DeserializeLongTermRetentionBackupData(e)), LongTermRetentionBackupsClientDiagnostics, Pipeline, "ResourceGroupResourceExtension.GetLongTermRetentionBackupsByResourceGroupLocation", "value", "nextLink", cancellationToken);
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
            HttpMessage FirstPageRequest(int? pageSizeHint) => LongTermRetentionBackupsRestClient.CreateListByResourceGroupServerRequest(Id.SubscriptionId, Id.ResourceGroupName, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => LongTermRetentionBackupsRestClient.CreateListByResourceGroupServerNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new SubscriptionLongTermRetentionBackupResource(Client, LongTermRetentionBackupData.DeserializeLongTermRetentionBackupData(e)), LongTermRetentionBackupsClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetLongTermRetentionBackupsByResourceGroupServer", "value", "nextLink", cancellationToken);
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
            HttpMessage FirstPageRequest(int? pageSizeHint) => LongTermRetentionBackupsRestClient.CreateListByResourceGroupServerRequest(Id.SubscriptionId, Id.ResourceGroupName, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => LongTermRetentionBackupsRestClient.CreateListByResourceGroupServerNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new SubscriptionLongTermRetentionBackupResource(Client, LongTermRetentionBackupData.DeserializeLongTermRetentionBackupData(e)), LongTermRetentionBackupsClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetLongTermRetentionBackupsByResourceGroupServer", "value", "nextLink", cancellationToken);
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
            HttpMessage FirstPageRequest(int? pageSizeHint) => LongTermRetentionManagedInstanceBackupsRestClient.CreateListByResourceGroupInstanceRequest(Id.SubscriptionId, Id.ResourceGroupName, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => LongTermRetentionManagedInstanceBackupsRestClient.CreateListByResourceGroupInstanceNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, ManagedInstanceLongTermRetentionBackupData.DeserializeManagedInstanceLongTermRetentionBackupData(e)), LongTermRetentionManagedInstanceBackupsClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance", "value", "nextLink", cancellationToken);
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
            HttpMessage FirstPageRequest(int? pageSizeHint) => LongTermRetentionManagedInstanceBackupsRestClient.CreateListByResourceGroupInstanceRequest(Id.SubscriptionId, Id.ResourceGroupName, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => LongTermRetentionManagedInstanceBackupsRestClient.CreateListByResourceGroupInstanceNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, ManagedInstanceLongTermRetentionBackupData.DeserializeManagedInstanceLongTermRetentionBackupData(e)), LongTermRetentionManagedInstanceBackupsClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance", "value", "nextLink", cancellationToken);
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
            HttpMessage FirstPageRequest(int? pageSizeHint) => LongTermRetentionManagedInstanceBackupsRestClient.CreateListByResourceGroupLocationRequest(Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => LongTermRetentionManagedInstanceBackupsRestClient.CreateListByResourceGroupLocationNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, ManagedInstanceLongTermRetentionBackupData.DeserializeManagedInstanceLongTermRetentionBackupData(e)), LongTermRetentionManagedInstanceBackupsClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance", "value", "nextLink", cancellationToken);
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
            HttpMessage FirstPageRequest(int? pageSizeHint) => LongTermRetentionManagedInstanceBackupsRestClient.CreateListByResourceGroupLocationRequest(Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => LongTermRetentionManagedInstanceBackupsRestClient.CreateListByResourceGroupLocationNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, ManagedInstanceLongTermRetentionBackupData.DeserializeManagedInstanceLongTermRetentionBackupData(e)), LongTermRetentionManagedInstanceBackupsClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance", "value", "nextLink", cancellationToken);
        }
    }
}
