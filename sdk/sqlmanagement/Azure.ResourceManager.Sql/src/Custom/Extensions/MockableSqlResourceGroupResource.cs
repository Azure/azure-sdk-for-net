// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
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
            return new AsyncPageableWrapper<LongTermRetentionBackupData, SubscriptionLongTermRetentionBackupResource>(
                GetLongTermRetentionBackupsWithResourceGroupLocationAsync(locationName, onlyLatestPerDatabase, databaseState, cancellationToken),
                data => new SubscriptionLongTermRetentionBackupResource(Client, data));
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
            return new PageableWrapper<LongTermRetentionBackupData, SubscriptionLongTermRetentionBackupResource>(
                GetLongTermRetentionBackupsWithResourceGroupLocation(locationName, onlyLatestPerDatabase, databaseState, cancellationToken),
                data => new SubscriptionLongTermRetentionBackupResource(Client, data));
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
            return new AsyncPageableWrapper<LongTermRetentionBackupData, SubscriptionLongTermRetentionBackupResource>(
                GetLongTermRetentionBackupsWithResourceGroupServerAsync(locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken),
                data => new SubscriptionLongTermRetentionBackupResource(Client, data));
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
            return new PageableWrapper<LongTermRetentionBackupData, SubscriptionLongTermRetentionBackupResource>(
                GetLongTermRetentionBackupsWithResourceGroupServer(locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken),
                data => new SubscriptionLongTermRetentionBackupResource(Client, data));
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
            return new AsyncPageableWrapper<ManagedInstanceLongTermRetentionBackupData, SubscriptionLongTermRetentionManagedInstanceBackupResource>(
                GetLongTermRetentionManagedInstanceBackupsWithResourceGroupInstanceAsync(locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken),
                data => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, data));
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
            return new PageableWrapper<ManagedInstanceLongTermRetentionBackupData, SubscriptionLongTermRetentionManagedInstanceBackupResource>(
                GetLongTermRetentionManagedInstanceBackupsWithResourceGroupInstance(locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken),
                data => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, data));
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
            return new AsyncPageableWrapper<ManagedInstanceLongTermRetentionBackupData, SubscriptionLongTermRetentionManagedInstanceBackupResource>(
                GetLongTermRetentionManagedInstanceBackupsWithResourceGroupLocationAsync(locationName, onlyLatestPerDatabase, databaseState, cancellationToken : cancellationToken),
                data => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, data));
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
            return new PageableWrapper<ManagedInstanceLongTermRetentionBackupData, SubscriptionLongTermRetentionManagedInstanceBackupResource>(
                GetLongTermRetentionManagedInstanceBackupsWithResourceGroupLocation(locationName, onlyLatestPerDatabase, databaseState, cancellationToken : cancellationToken),
                data => new SubscriptionLongTermRetentionManagedInstanceBackupResource(Client, data));
        }

        /// <summary>
        /// Lists the long term retention backups for a given location.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<LongTermRetentionBackupData> GetLongTermRetentionBackupsWithLocationAsync(AzureLocation locationName, bool? onlyLatestPerDatabase, SqlDatabaseState? databaseState, CancellationToken cancellationToken)
            => GetLongTermRetentionBackupsWithResourceGroupLocationAsync(locationName, onlyLatestPerDatabase, databaseState, cancellationToken);

        /// <summary>
        /// Lists the long term retention backups for a given location.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<LongTermRetentionBackupData> GetLongTermRetentionBackupsWithLocation(AzureLocation locationName, bool? onlyLatestPerDatabase, SqlDatabaseState? databaseState, CancellationToken cancellationToken)
            => GetLongTermRetentionBackupsWithResourceGroupLocation(locationName, onlyLatestPerDatabase, databaseState, cancellationToken);

        /// <summary>
        /// Lists the long term retention backups for a given server.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<LongTermRetentionBackupData> GetLongTermRetentionBackupsWithServerAsync(AzureLocation locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase, SqlDatabaseState? databaseState, CancellationToken cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(longTermRetentionServerName, nameof(longTermRetentionServerName));
            return GetLongTermRetentionBackupsWithResourceGroupServerAsync(locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken);
        }

        /// <summary>
        /// Lists the long term retention backups for a given server.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<LongTermRetentionBackupData> GetLongTermRetentionBackupsWithServer(AzureLocation locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase, SqlDatabaseState? databaseState, CancellationToken cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(longTermRetentionServerName, nameof(longTermRetentionServerName));
            return GetLongTermRetentionBackupsWithResourceGroupServer(locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken);
        }

        /// <summary>
        /// Lists the long term retention backups for a given managed instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithInstanceAsync(AzureLocation locationName, string managedInstanceName, bool? onlyLatestPerDatabase, SqlDatabaseState? databaseState, CancellationToken cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(managedInstanceName, nameof(managedInstanceName));
            return GetLongTermRetentionManagedInstanceBackupsWithResourceGroupInstanceAsync(locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken);
        }

        /// <summary>
        /// Lists the long term retention backups for a given managed instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithInstance(AzureLocation locationName, string managedInstanceName, bool? onlyLatestPerDatabase, SqlDatabaseState? databaseState, CancellationToken cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(managedInstanceName, nameof(managedInstanceName));
            return GetLongTermRetentionManagedInstanceBackupsWithResourceGroupInstance(locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken);
        }

        /// <summary>
        /// Lists the long term retention backups for managed databases in a given location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstanceBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LongTermRetentionManagedInstanceBackups_ListByResourceGroupLocation</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ManagedInstanceLongTermRetentionBackupData"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocationAsync(AzureLocation locationName, bool? onlyLatestPerDatabase, SqlDatabaseState? databaseState, CancellationToken cancellationToken)
            => GetLongTermRetentionManagedInstanceBackupsWithResourceGroupLocationAsync(locationName, onlyLatestPerDatabase, databaseState, null, null, null, cancellationToken);

        /// <summary>
        /// Lists the long term retention backups for managed databases in a given location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstanceBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LongTermRetentionManagedInstanceBackups_ListByResourceGroupLocation</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedInstanceLongTermRetentionBackupData"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocation(AzureLocation locationName, bool? onlyLatestPerDatabase, SqlDatabaseState? databaseState, CancellationToken cancellationToken)
            => GetLongTermRetentionManagedInstanceBackupsWithResourceGroupLocation(locationName, onlyLatestPerDatabase, databaseState, null, null, null, cancellationToken);

        /// <summary>
        /// Lists the long term retention backups for managed databases in a given location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstanceBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LongTermRetentionManagedInstanceBackups_ListByResourceGroupLocation</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <returns> An async collection of <see cref="ManagedInstanceLongTermRetentionBackupData"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocationAsync(ResourceGroupResourceGetLongTermRetentionManagedInstanceBackupsWithLocationOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return GetLongTermRetentionManagedInstanceBackupsWithResourceGroupLocationAsync(options.LocationName, options.OnlyLatestPerDatabase, options.DatabaseState, options.Skip, options.Top, options.Filter, cancellationToken);
        }

        /// <summary>
        /// Lists the long term retention backups for managed databases in a given location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstanceBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LongTermRetentionManagedInstanceBackups_ListByResourceGroupLocation</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <returns> A collection of <see cref="ManagedInstanceLongTermRetentionBackupData"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocation(ResourceGroupResourceGetLongTermRetentionManagedInstanceBackupsWithLocationOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return GetLongTermRetentionManagedInstanceBackupsWithResourceGroupLocation(options.LocationName, options.OnlyLatestPerDatabase, options.DatabaseState, options.Skip, options.Top, options.Filter, cancellationToken);
        }
    }
}
