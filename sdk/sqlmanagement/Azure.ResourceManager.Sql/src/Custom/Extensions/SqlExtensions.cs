// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.Sql. </summary>
    public static partial class SqlExtensions
    {
        /// <summary>
        /// Lists the long term retention backups for a given location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LongTermRetentionBackups_ListByLocation</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByLocationAsync(this SubscriptionResource subscriptionResource, AzureLocation locationName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            return GetMockableSqlSubscriptionResource(subscriptionResource).GetLongTermRetentionBackupsByLocationAsync(locationName, onlyLatestPerDatabase, databaseState, cancellationToken);
        }

        /// <summary>
        /// Lists the long term retention backups for a given location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LongTermRetentionBackups_ListByLocation</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByLocation(this SubscriptionResource subscriptionResource, AzureLocation locationName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            return GetMockableSqlSubscriptionResource(subscriptionResource).GetLongTermRetentionBackupsByLocation(locationName, onlyLatestPerDatabase, databaseState, cancellationToken);
        }

        /// <summary>
        /// Lists the long term retention backups for a given server.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LongTermRetentionBackups_ListByServer</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="longTermRetentionServerName"> The name of the server. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="longTermRetentionServerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="longTermRetentionServerName"/> is null. </exception>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByServerAsync(this SubscriptionResource subscriptionResource, AzureLocation locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            return GetMockableSqlSubscriptionResource(subscriptionResource).GetLongTermRetentionBackupsByServerAsync(locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken);
        }

        /// <summary>
        /// Lists the long term retention backups for a given server.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LongTermRetentionBackups_ListByServer</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="longTermRetentionServerName"> The name of the server. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="longTermRetentionServerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="longTermRetentionServerName"/> is null. </exception>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByServer(this SubscriptionResource subscriptionResource, AzureLocation locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            return GetMockableSqlSubscriptionResource(subscriptionResource).GetLongTermRetentionBackupsByServer(locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken);
        }

        /// <summary>
        /// Lists the long term retention backups for a given managed instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstances/{managedInstanceName}/longTermRetentionManagedInstanceBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LongTermRetentionManagedInstanceBackups_ListByInstance</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="managedInstanceName"> The name of the managed instance. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="managedInstanceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="managedInstanceName"/> is null. </exception>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByInstanceAsync(this SubscriptionResource subscriptionResource, AzureLocation locationName, string managedInstanceName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            return GetMockableSqlSubscriptionResource(subscriptionResource).GetLongTermRetentionManagedInstanceBackupsByInstanceAsync(locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken);
        }

        /// <summary>
        /// Lists the long term retention backups for a given managed instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstances/{managedInstanceName}/longTermRetentionManagedInstanceBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LongTermRetentionManagedInstanceBackups_ListByInstance</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="managedInstanceName"> The name of the managed instance. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="managedInstanceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="managedInstanceName"/> is null. </exception>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByInstance(this SubscriptionResource subscriptionResource, AzureLocation locationName, string managedInstanceName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            return GetMockableSqlSubscriptionResource(subscriptionResource).GetLongTermRetentionManagedInstanceBackupsByInstance(locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken);
        }

        /// <summary>
        /// Lists the long term retention backups for managed databases in a given location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstanceBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LongTermRetentionManagedInstanceBackups_ListByLocation</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByLocationAsync(this SubscriptionResource subscriptionResource, AzureLocation locationName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            return GetMockableSqlSubscriptionResource(subscriptionResource).GetLongTermRetentionManagedInstanceBackupsByLocationAsync(locationName, onlyLatestPerDatabase, databaseState, cancellationToken);
        }

        /// <summary>
        /// Lists the long term retention backups for managed databases in a given location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstanceBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LongTermRetentionManagedInstanceBackups_ListByLocation</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByLocation(this SubscriptionResource subscriptionResource, AzureLocation locationName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            return GetMockableSqlSubscriptionResource(subscriptionResource).GetLongTermRetentionManagedInstanceBackupsByLocation(locationName, onlyLatestPerDatabase, databaseState, cancellationToken);
        }

        /// <summary>
        /// Lists the long term retention backups for a given location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LongTermRetentionBackups_ListByResourceGroupLocation</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupLocationAsync(this ResourceGroupResource resourceGroupResource, AzureLocation locationName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            return GetMockableSqlResourceGroupResource(resourceGroupResource).GetLongTermRetentionBackupsByResourceGroupLocationAsync(locationName, onlyLatestPerDatabase, databaseState, cancellationToken);
        }

        /// <summary>
        /// Lists the long term retention backups for a given location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LongTermRetentionBackups_ListByResourceGroupLocation</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupLocation(this ResourceGroupResource resourceGroupResource, AzureLocation locationName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            return GetMockableSqlResourceGroupResource(resourceGroupResource).GetLongTermRetentionBackupsByResourceGroupLocation(locationName, onlyLatestPerDatabase, databaseState, cancellationToken);
        }

        /// <summary>
        /// Lists the long term retention backups for a given server.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LongTermRetentionBackups_ListByResourceGroupServer</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="longTermRetentionServerName"> The name of the server. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="longTermRetentionServerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="longTermRetentionServerName"/> is null. </exception>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupServerAsync(this ResourceGroupResource resourceGroupResource, AzureLocation locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            return GetMockableSqlResourceGroupResource(resourceGroupResource).GetLongTermRetentionBackupsByResourceGroupServerAsync(locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken);
        }

        /// <summary>
        /// Lists the long term retention backups for a given server.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LongTermRetentionBackups_ListByResourceGroupServer</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="longTermRetentionServerName"> The name of the server. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="longTermRetentionServerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="longTermRetentionServerName"/> is null. </exception>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupServer(this ResourceGroupResource resourceGroupResource, AzureLocation locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            return GetMockableSqlResourceGroupResource(resourceGroupResource).GetLongTermRetentionBackupsByResourceGroupServer(locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken);
        }

        /// <summary>
        /// Lists the long term retention backups for a given managed instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstances/{managedInstanceName}/longTermRetentionManagedInstanceBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LongTermRetentionManagedInstanceBackups_ListByResourceGroupInstance</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="managedInstanceName"> The name of the managed instance. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="managedInstanceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="managedInstanceName"/> is null. </exception>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstanceAsync(this ResourceGroupResource resourceGroupResource, AzureLocation locationName, string managedInstanceName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            return GetMockableSqlResourceGroupResource(resourceGroupResource).GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstanceAsync(locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken);
        }

        /// <summary>
        /// Lists the long term retention backups for a given managed instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstances/{managedInstanceName}/longTermRetentionManagedInstanceBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LongTermRetentionManagedInstanceBackups_ListByResourceGroupInstance</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="managedInstanceName"> The name of the managed instance. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="managedInstanceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="managedInstanceName"/> is null. </exception>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance(this ResourceGroupResource resourceGroupResource, AzureLocation locationName, string managedInstanceName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            return GetMockableSqlResourceGroupResource(resourceGroupResource).GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance(locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken);
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocationAsync(this ResourceGroupResource resourceGroupResource, AzureLocation locationName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            return GetMockableSqlResourceGroupResource(resourceGroupResource).GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocationAsync(locationName, onlyLatestPerDatabase, databaseState, cancellationToken);
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackupResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocation(this ResourceGroupResource resourceGroupResource, AzureLocation locationName, bool? onlyLatestPerDatabase = null, SqlDatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            return GetMockableSqlResourceGroupResource(resourceGroupResource).GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocation(locationName, onlyLatestPerDatabase, databaseState, cancellationToken);
        }
    }
}
