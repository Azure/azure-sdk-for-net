// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591
#pragma warning disable CA1822
#pragma warning disable CS0109
#pragma warning disable SA1206
#pragma warning disable SA1402
#pragma warning disable SA1508

namespace Azure.ResourceManager.Sql.Mocking
{
    public partial class MockableSqlSubscriptionResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.Models.SqlNameAvailabilityResponse> CheckSqlServerNameAvailability(Azure.ResourceManager.Sql.Models.SqlNameAvailabilityContent p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.SqlNameAvailabilityResponse>> CheckSqlServerNameAvailabilityAsync(Azure.ResourceManager.Sql.Models.SqlNameAvailabilityContent p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.Models.SqlLocationCapabilities> GetCapabilitiesByLocation(Azure.Core.AzureLocation p0, System.Nullable<Azure.ResourceManager.Sql.Models.SqlCapabilityGroup> p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.SqlLocationCapabilities>> GetCapabilitiesByLocationAsync(Azure.Core.AzureLocation p0, System.Nullable<Azure.ResourceManager.Sql.Models.SqlCapabilityGroup> p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.DeletedServerResource> GetDeletedServer(Azure.Core.AzureLocation p0, System.String p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DeletedServerResource>> GetDeletedServerAsync(Azure.Core.AzureLocation p0, System.String p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.Sql.DeletedServerCollection GetDeletedServers(Azure.Core.AzureLocation p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByLocation(Azure.Core.AzureLocation p0, System.Nullable<System.Boolean> p1, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByLocationAsync(Azure.Core.AzureLocation p0, System.Nullable<System.Boolean> p1, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByServer(Azure.Core.AzureLocation p0, System.String p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByServerAsync(Azure.Core.AzureLocation p0, System.String p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.LongTermRetentionBackupData> GetLongTermRetentionBackupsWithLocation(Azure.Core.AzureLocation p0, System.Nullable<System.Boolean> p1, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.LongTermRetentionBackupData> GetLongTermRetentionBackupsWithLocationAsync(Azure.Core.AzureLocation p0, System.Nullable<System.Boolean> p1, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.LongTermRetentionBackupData> GetLongTermRetentionBackupsWithServer(Azure.Core.AzureLocation p0, System.String p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.LongTermRetentionBackupData> GetLongTermRetentionBackupsWithServerAsync(Azure.Core.AzureLocation p0, System.String p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByInstance(Azure.Core.AzureLocation p0, System.String p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByInstanceAsync(Azure.Core.AzureLocation p0, System.String p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByLocation(Azure.Core.AzureLocation p0, System.Nullable<System.Boolean> p1, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByLocationAsync(Azure.Core.AzureLocation p0, System.Nullable<System.Boolean> p1, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithInstance(Azure.Core.AzureLocation p0, System.String p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithInstanceAsync(Azure.Core.AzureLocation p0, System.String p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocation(Azure.Core.AzureLocation p0, System.Nullable<System.Boolean> p1, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocation(Azure.ResourceManager.Sql.Models.SubscriptionResourceGetLongTermRetentionManagedInstanceBackupsWithLocationOptions p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocationAsync(Azure.Core.AzureLocation p0, System.Nullable<System.Boolean> p1, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocationAsync(Azure.ResourceManager.Sql.Models.SubscriptionResourceGetLongTermRetentionManagedInstanceBackupsWithLocationOptions p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlTimeZoneResource> GetSqlTimeZone(Azure.Core.AzureLocation p0, System.String p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlTimeZoneResource>> GetSqlTimeZoneAsync(Azure.Core.AzureLocation p0, System.String p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.Sql.SqlTimeZoneCollection GetSqlTimeZones(Azure.Core.AzureLocation p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetSubscriptionLongTermRetentionBackup(Azure.Core.AzureLocation p0, System.String p1, System.String p2, System.String p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource>> GetSubscriptionLongTermRetentionBackupAsync(Azure.Core.AzureLocation p0, System.String p1, System.String p2, System.String p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupCollection GetSubscriptionLongTermRetentionBackups(Azure.Core.AzureLocation p0, System.String p1, System.String p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetSubscriptionLongTermRetentionManagedInstanceBackup(Azure.Core.AzureLocation p0, System.String p1, System.String p2, System.String p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource>> GetSubscriptionLongTermRetentionManagedInstanceBackupAsync(Azure.Core.AzureLocation p0, System.String p1, System.String p2, System.String p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupCollection GetSubscriptionLongTermRetentionManagedInstanceBackups(Azure.Core.AzureLocation p0, System.String p1, System.String p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionUsageResource> GetSubscriptionUsage(Azure.Core.AzureLocation p0, System.String p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionUsageResource>> GetSubscriptionUsageAsync(Azure.Core.AzureLocation p0, System.String p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.Sql.SubscriptionUsageCollection GetSubscriptionUsages(Azure.Core.AzureLocation p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.SubResource> GetSyncDatabaseIdsSyncGroups(Azure.Core.AzureLocation p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.SubResource> GetSyncDatabaseIdsSyncGroupsAsync(Azure.Core.AzureLocation p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public static partial class SqlExtensions
    {
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.Sql.Models.SqlNameAvailabilityResponse> CheckSqlServerNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.ResourceManager.Sql.Models.SqlNameAvailabilityContent p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.SqlNameAvailabilityResponse>> CheckSqlServerNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.ResourceManager.Sql.Models.SqlNameAvailabilityContent p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.Sql.Models.SqlLocationCapabilities> GetCapabilitiesByLocation(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.Nullable<Azure.ResourceManager.Sql.Models.SqlCapabilityGroup> p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.SqlLocationCapabilities>> GetCapabilitiesByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.Nullable<Azure.ResourceManager.Sql.Models.SqlCapabilityGroup> p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.Sql.DeletedServerResource> GetDeletedServer(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DeletedServerResource>> GetDeletedServerAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.Sql.DeletedServerCollection GetDeletedServers(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.Sql.DistributedAvailabilityGroupResource GetDistributedAvailabilityGroupResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.Sql.InstanceFailoverGroupResource> GetInstanceFailoverGroup(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstanceFailoverGroupResource>> GetInstanceFailoverGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.Sql.InstanceFailoverGroupCollection GetInstanceFailoverGroups(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByLocation(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupLocation(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupLocationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupServer(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Nullable<System.Boolean> p3, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Nullable<System.Boolean> p3, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByServer(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Nullable<System.Boolean> p3, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByServerAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Nullable<System.Boolean> p3, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.Sql.LongTermRetentionBackupData> GetLongTermRetentionBackupsWithLocation(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.Sql.LongTermRetentionBackupData> GetLongTermRetentionBackupsWithLocation(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.LongTermRetentionBackupData> GetLongTermRetentionBackupsWithLocationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.LongTermRetentionBackupData> GetLongTermRetentionBackupsWithLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.Sql.LongTermRetentionBackupData> GetLongTermRetentionBackupsWithServer(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Nullable<System.Boolean> p3, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.Sql.LongTermRetentionBackupData> GetLongTermRetentionBackupsWithServer(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Nullable<System.Boolean> p3, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.LongTermRetentionBackupData> GetLongTermRetentionBackupsWithServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Nullable<System.Boolean> p3, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.LongTermRetentionBackupData> GetLongTermRetentionBackupsWithServerAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Nullable<System.Boolean> p3, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByInstance(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Nullable<System.Boolean> p3, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByInstanceAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Nullable<System.Boolean> p3, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByLocation(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Nullable<System.Boolean> p3, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Nullable<System.Boolean> p3, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocation(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithInstance(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Nullable<System.Boolean> p3, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithInstance(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Nullable<System.Boolean> p3, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Nullable<System.Boolean> p3, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithInstanceAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Nullable<System.Boolean> p3, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocation(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocation(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.ResourceManager.Sql.Models.ResourceGroupResourceGetLongTermRetentionManagedInstanceBackupsWithLocationOptions p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocation(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocation(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.ResourceManager.Sql.Models.SubscriptionResourceGetLongTermRetentionManagedInstanceBackupsWithLocationOptions p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.ResourceManager.Sql.Models.ResourceGroupResourceGetLongTermRetentionManagedInstanceBackupsWithLocationOptions p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.ResourceManager.Sql.Models.SubscriptionResourceGetLongTermRetentionManagedInstanceBackupsWithLocationOptions p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.Sql.ManagedInstanceServerTrustCertificateResource GetManagedInstanceServerTrustCertificateResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource> GetResourceGroupLongTermRetentionBackup(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.String p3, System.String p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource>> GetResourceGroupLongTermRetentionBackupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.String p3, System.String p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource GetResourceGroupLongTermRetentionBackupResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupCollection GetResourceGroupLongTermRetentionBackups(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.String p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource> GetResourceGroupLongTermRetentionManagedInstanceBackup(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.String p3, System.String p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource>> GetResourceGroupLongTermRetentionManagedInstanceBackupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.String p3, System.String p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource GetResourceGroupLongTermRetentionManagedInstanceBackupResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupCollection GetResourceGroupLongTermRetentionManagedInstanceBackups(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.String p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineResource GetSqlDatabaseSqlVulnerabilityAssessmentBaselineResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.Sql.SqlServerJobVersionStepResource GetSqlServerJobVersionStepResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.Sql.SqlServerTrustGroupResource> GetSqlServerTrustGroup(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerTrustGroupResource>> GetSqlServerTrustGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.Sql.SqlServerTrustGroupCollection GetSqlServerTrustGroups(this Azure.ResourceManager.Resources.ResourceGroupResource p0, Azure.Core.AzureLocation p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.Sql.SqlTimeZoneResource> GetSqlTimeZone(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlTimeZoneResource>> GetSqlTimeZoneAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.Sql.SqlTimeZoneCollection GetSqlTimeZones(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetSubscriptionLongTermRetentionBackup(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.String p3, System.String p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource>> GetSubscriptionLongTermRetentionBackupAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.String p3, System.String p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource GetSubscriptionLongTermRetentionBackupResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupCollection GetSubscriptionLongTermRetentionBackups(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.String p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetSubscriptionLongTermRetentionManagedInstanceBackup(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.String p3, System.String p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource>> GetSubscriptionLongTermRetentionManagedInstanceBackupAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.String p3, System.String p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource GetSubscriptionLongTermRetentionManagedInstanceBackupResource(this Azure.ResourceManager.ArmClient p0, Azure.Core.ResourceIdentifier p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupCollection GetSubscriptionLongTermRetentionManagedInstanceBackups(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.String p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Response<Azure.ResourceManager.Sql.SubscriptionUsageResource> GetSubscriptionUsage(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionUsageResource>> GetSubscriptionUsageAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.String p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.ResourceManager.Sql.SubscriptionUsageCollection GetSubscriptionUsages(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.Pageable<Azure.ResourceManager.Resources.Models.SubResource> GetSyncDatabaseIdsSyncGroups(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.SubResource> GetSyncDatabaseIdsSyncGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource p0, Azure.Core.AzureLocation p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql.Mocking
{
    public partial class MockableSqlResourceGroupResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.InstanceFailoverGroupResource> GetInstanceFailoverGroup(Azure.Core.AzureLocation p0, System.String p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstanceFailoverGroupResource>> GetInstanceFailoverGroupAsync(Azure.Core.AzureLocation p0, System.String p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.Sql.InstanceFailoverGroupCollection GetInstanceFailoverGroups(Azure.Core.AzureLocation p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupLocation(Azure.Core.AzureLocation p0, System.Nullable<System.Boolean> p1, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupLocationAsync(Azure.Core.AzureLocation p0, System.Nullable<System.Boolean> p1, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupServer(Azure.Core.AzureLocation p0, System.String p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupServerAsync(Azure.Core.AzureLocation p0, System.String p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.LongTermRetentionBackupData> GetLongTermRetentionBackupsWithLocation(Azure.Core.AzureLocation p0, System.Nullable<System.Boolean> p1, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.LongTermRetentionBackupData> GetLongTermRetentionBackupsWithLocationAsync(Azure.Core.AzureLocation p0, System.Nullable<System.Boolean> p1, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.LongTermRetentionBackupData> GetLongTermRetentionBackupsWithServer(Azure.Core.AzureLocation p0, System.String p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.LongTermRetentionBackupData> GetLongTermRetentionBackupsWithServerAsync(Azure.Core.AzureLocation p0, System.String p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance(Azure.Core.AzureLocation p0, System.String p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstanceAsync(Azure.Core.AzureLocation p0, System.String p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocation(Azure.Core.AzureLocation p0, System.Nullable<System.Boolean> p1, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocationAsync(Azure.Core.AzureLocation p0, System.Nullable<System.Boolean> p1, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithInstance(Azure.Core.AzureLocation p0, System.String p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithInstanceAsync(Azure.Core.AzureLocation p0, System.String p1, System.Nullable<System.Boolean> p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocation(Azure.Core.AzureLocation p0, System.Nullable<System.Boolean> p1, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocation(Azure.ResourceManager.Sql.Models.ResourceGroupResourceGetLongTermRetentionManagedInstanceBackupsWithLocationOptions p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocationAsync(Azure.Core.AzureLocation p0, System.Nullable<System.Boolean> p1, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData> GetLongTermRetentionManagedInstanceBackupsWithLocationAsync(Azure.ResourceManager.Sql.Models.ResourceGroupResourceGetLongTermRetentionManagedInstanceBackupsWithLocationOptions p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource> GetResourceGroupLongTermRetentionBackup(Azure.Core.AzureLocation p0, System.String p1, System.String p2, System.String p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource>> GetResourceGroupLongTermRetentionBackupAsync(Azure.Core.AzureLocation p0, System.String p1, System.String p2, System.String p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupCollection GetResourceGroupLongTermRetentionBackups(Azure.Core.AzureLocation p0, System.String p1, System.String p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource> GetResourceGroupLongTermRetentionManagedInstanceBackup(Azure.Core.AzureLocation p0, System.String p1, System.String p2, System.String p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource>> GetResourceGroupLongTermRetentionManagedInstanceBackupAsync(Azure.Core.AzureLocation p0, System.String p1, System.String p2, System.String p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupCollection GetResourceGroupLongTermRetentionManagedInstanceBackups(Azure.Core.AzureLocation p0, System.String p1, System.String p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerTrustGroupResource> GetSqlServerTrustGroup(Azure.Core.AzureLocation p0, System.String p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerTrustGroupResource>> GetSqlServerTrustGroupAsync(Azure.Core.AzureLocation p0, System.String p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.Sql.SqlServerTrustGroupCollection GetSqlServerTrustGroups(Azure.Core.AzureLocation p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class ManagedDatabaseResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedDatabaseSensitivityLabelResource> GetCurrentManagedDatabaseSensitivityLabels(System.String p0, System.Nullable<System.Boolean> p1, System.String p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedDatabaseSensitivityLabelResource> GetCurrentManagedDatabaseSensitivityLabelsAsync(System.String p0, System.Nullable<System.Boolean> p1, System.String p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedDatabaseColumnResource> GetManagedDatabaseColumnsByDatabase(System.Collections.Generic.IEnumerable<System.String> p0, System.Collections.Generic.IEnumerable<System.String> p1, System.Collections.Generic.IEnumerable<System.String> p2, System.Collections.Generic.IEnumerable<System.String> p3, System.String p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedDatabaseColumnResource> GetManagedDatabaseColumnsByDatabaseAsync(System.Collections.Generic.IEnumerable<System.String> p0, System.Collections.Generic.IEnumerable<System.String> p1, System.Collections.Generic.IEnumerable<System.String> p2, System.Collections.Generic.IEnumerable<System.String> p3, System.String p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceQuery> GetManagedDatabaseQuery(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceQuery>> GetManagedDatabaseQueryAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SecurityEvent> GetManagedDatabaseSecurityEventsByDatabase(System.String p0, System.Nullable<System.Int64> p1, System.Nullable<System.Int64> p2, System.String p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SecurityEvent> GetManagedDatabaseSecurityEventsByDatabaseAsync(System.String p0, System.Nullable<System.Int64> p1, System.Nullable<System.Int64> p2, System.String p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedDatabaseSensitivityLabelResource> GetManagedDatabaseSensitivityLabelsByDatabase(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedDatabaseSensitivityLabelResource> GetManagedDatabaseSensitivityLabelsByDatabaseAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.QueryStatistics> GetQueryStatistics(System.String p0, System.String p1, System.String p2, System.Nullable<Azure.ResourceManager.Sql.Models.QueryTimeGrainType> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.QueryStatistics> GetQueryStatisticsAsync(System.String p0, System.String p1, System.String p2, System.Nullable<Azure.ResourceManager.Sql.Models.QueryTimeGrainType> p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedDatabaseSensitivityLabelResource> GetRecommendedManagedDatabaseSensitivityLabels(System.String p0, System.Nullable<System.Boolean> p1, System.String p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedDatabaseSensitivityLabelResource> GetRecommendedManagedDatabaseSensitivityLabelsAsync(System.String p0, System.Nullable<System.Boolean> p1, System.String p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response UpdateManagedDatabaseSensitivityLabel(Azure.ResourceManager.Sql.Models.SensitivityLabelUpdateList p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response> UpdateManagedDatabaseSensitivityLabelAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelUpdateList p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response UpdateRecommendedManagedDatabaseSensitivityLabel(Azure.ResourceManager.Sql.Models.RecommendedSensitivityLabelUpdateList p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response> UpdateRecommendedManagedDatabaseSensitivityLabelAsync(Azure.ResourceManager.Sql.Models.RecommendedSensitivityLabelUpdateList p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class ManagedInstanceResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation CreateManagedInstanceTdeCertificate(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.TdeCertificate p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateManagedInstanceTdeCertificateAsync(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.TdeCertificate p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedDatabaseResource> GetInaccessibleManagedDatabases(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedDatabaseResource> GetInaccessibleManagedDatabasesAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceOperationResource> GetManagedInstanceOperation(System.Guid p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceOperationResource>> GetManagedInstanceOperationAsync(System.Guid p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceServerTrustCertificateResource> GetManagedInstanceServerTrustCertificate(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceServerTrustCertificateResource>> GetManagedInstanceServerTrustCertificateAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.Sql.ManagedInstanceServerTrustCertificateCollection GetManagedInstanceServerTrustCertificates()
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SqlOutboundEnvironmentEndpoint> GetOutboundNetworkDependencies(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SqlOutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlServerTrustGroupResource> GetSqlServerTrustGroups(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlServerTrustGroupResource> GetSqlServerTrustGroupsAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.TopQueries> GetTopQueries(Azure.ResourceManager.Sql.Models.ManagedInstanceResourceGetTopQueriesOptions p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.TopQueries> GetTopQueriesAsync(Azure.ResourceManager.Sql.Models.ManagedInstanceResourceGetTopQueriesOptions p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class InstancePoolResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceResource> GetManagedInstances(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceResource> GetManagedInstancesAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlInstancePoolOperationResource> GetSqlInstancePoolOperation(System.Guid p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlInstancePoolOperationResource>> GetSqlInstancePoolOperationAsync(System.Guid p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.InstancePoolUsage> GetUsages(System.Nullable<System.Boolean> p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.InstancePoolUsage> GetUsagesAsync(System.Nullable<System.Boolean> p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class ManagedInstanceServerTrustCertificateCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceServerTrustCertificateResource> CreateOrUpdate(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.Sql.ServerTrustCertificateData p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceServerTrustCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.Sql.ServerTrustCertificateData p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceServerTrustCertificateResource> Get(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceServerTrustCertificateResource> GetAll(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceServerTrustCertificateResource> GetAllAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceServerTrustCertificateResource>> GetAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.NullableResponse<Azure.ResourceManager.Sql.ManagedInstanceServerTrustCertificateResource> GetIfExists(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Sql.ManagedInstanceServerTrustCertificateResource>> GetIfExistsAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlDatabaseResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response CancelDatabaseOperation(System.Guid p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response> CancelDatabaseOperationAsync(System.Guid p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.ImportExportExtensionsOperationResult> CreateOrUpdateDatabaseExtension(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.Sql.Models.SqlDatabaseExtension p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.ImportExportExtensionsOperationResult>> CreateOrUpdateDatabaseExtensionAsync(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.Sql.Models.SqlDatabaseExtension p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerDatabaseRestorePointResource> CreateRestorePoint(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.CreateDatabaseRestorePointDefinition p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerDatabaseRestorePointResource>> CreateRestorePointAsync(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.CreateDatabaseRestorePointDefinition p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlDatabaseSensitivityLabelResource> GetCurrentSensitivityLabels(System.String p0, System.Nullable<System.Boolean> p1, System.String p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlDatabaseSensitivityLabelResource> GetCurrentSensitivityLabelsAsync(System.String p0, System.Nullable<System.Boolean> p1, System.String p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlDatabaseColumnResource> GetDatabaseColumns(System.Collections.Generic.IEnumerable<System.String> p0, System.Collections.Generic.IEnumerable<System.String> p1, System.Collections.Generic.IEnumerable<System.String> p2, System.Collections.Generic.IEnumerable<System.String> p3, System.String p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlDatabaseColumnResource> GetDatabaseColumnsAsync(System.Collections.Generic.IEnumerable<System.String> p0, System.Collections.Generic.IEnumerable<System.String> p1, System.Collections.Generic.IEnumerable<System.String> p2, System.Collections.Generic.IEnumerable<System.String> p3, System.String p4, System.Threading.CancellationToken p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ImportExportExtensionsOperationResult> GetDatabaseExtensions(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ImportExportExtensionsOperationResult> GetDatabaseExtensionsAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.DatabaseOperationData> GetDatabaseOperations(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.DatabaseOperationData> GetDatabaseOperationsAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.DatabaseUsage> GetDatabaseUsages(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.DatabaseUsage> GetDatabaseUsagesAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlDatabaseSensitivityLabelResource> GetRecommendedSensitivityLabels(System.String p0, System.Nullable<System.Boolean> p1, System.String p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlDatabaseSensitivityLabelResource> GetRecommendedSensitivityLabelsAsync(System.String p0, System.Nullable<System.Boolean> p1, System.String p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlDatabaseSensitivityLabelResource> GetSensitivityLabels(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlDatabaseSensitivityLabelResource> GetSensitivityLabelsAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentResource> GetSqlDatabaseSqlVulnerabilityAssessment(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentResource>> GetSqlDatabaseSqlVulnerabilityAssessmentAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation RevalidateDatabaseEncryptionProtector(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.EncryptionProtectorName p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevalidateDatabaseEncryptionProtectorAsync(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.EncryptionProtectorName p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation RevertDatabaseEncryptionProtector(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.EncryptionProtectorName p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevertDatabaseEncryptionProtectorAsync(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.EncryptionProtectorName p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response UpdateRecommendedSensitivityLabel(Azure.ResourceManager.Sql.Models.RecommendedSensitivityLabelUpdateList p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response> UpdateRecommendedSensitivityLabelAsync(Azure.ResourceManager.Sql.Models.RecommendedSensitivityLabelUpdateList p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response UpdateSensitivityLabel(Azure.ResourceManager.Sql.Models.SensitivityLabelUpdateList p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response> UpdateSensitivityLabelAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelUpdateList p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class DataMaskingPolicyResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.Models.DataMaskingRule> CreateOrUpdateDataMaskingRule(System.String p0, Azure.ResourceManager.Sql.Models.DataMaskingRule p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DataMaskingRule>> CreateOrUpdateDataMaskingRuleAsync(System.String p0, Azure.ResourceManager.Sql.Models.DataMaskingRule p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.DataMaskingRule> GetDataMaskingRules(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.DataMaskingRule> GetDataMaskingRulesAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation CreateTdeCertificate(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.TdeCertificate p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateTdeCertificateAsync(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.TdeCertificate p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlDatabaseResource> GetInaccessibleDatabases(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlDatabaseResource> GetInaccessibleDatabasesAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlServerDatabaseReplicationLinkResource> GetReplicationLinks(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlServerDatabaseReplicationLinkResource> GetReplicationLinksAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ServerOperationData> GetServerOperations(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ServerOperationData> GetServerOperationsAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SqlServerUsage> GetServerUsages(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SqlServerUsage> GetServerUsagesAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerDevOpsAuditingSettingResource> GetSqlServerDevOpsAuditingSetting(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerDevOpsAuditingSettingResource>> GetSqlServerDevOpsAuditingSettingAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentResource> GetSqlServerSqlVulnerabilityAssessment(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentResource>> GetSqlServerSqlVulnerabilityAssessmentAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SyncGroupResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SyncGroupLogProperties> GetLogs(System.String p0, System.String p1, Azure.ResourceManager.Sql.Models.SyncGroupLogType p2, System.String p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SyncGroupLogProperties> GetLogsAsync(System.String p0, System.String p1, Azure.ResourceManager.Sql.Models.SyncGroupLogType p2, System.String p3, System.Threading.CancellationToken p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class ResourceGroupLongTermRetentionBackupCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource> Get(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource> GetAll(System.Nullable<System.Boolean> p0, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource> GetAllAsync(System.Nullable<System.Boolean> p0, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource>> GetAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.NullableResponse<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource> GetIfExists(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource>> GetIfExistsAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class ResourceGroupLongTermRetentionManagedInstanceBackupCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource> Get(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource> GetAll(System.Nullable<System.Boolean> p0, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource> GetAllAsync(System.Nullable<System.Boolean> p0, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource>> GetAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.NullableResponse<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource> GetIfExists(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource>> GetIfExistsAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class ElasticPoolResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response CancelElasticPoolOperation(System.Guid p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response> CancelElasticPoolOperationAsync(System.Guid p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlDatabaseResource> GetDatabases(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlDatabaseResource> GetDatabasesAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlDatabaseCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlDatabaseResource> GetAll(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlDatabaseResource> GetAllAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlDatabaseSqlVulnerabilityAssessmentBaselineCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineResource> CreateOrUpdate(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p1, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineCreateOrUpdateContent p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineResource>> CreateOrUpdateAsync(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p1, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineCreateOrUpdateContent p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<System.Boolean> Exists(Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<System.Boolean>> ExistsAsync(Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineResource> Get(Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineResource> GetAll(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineResource> GetAllAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineResource>> GetAsync(Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.NullableResponse<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineResource> GetIfExists(Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineResource>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerJobAgentResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlServerJobExecutionResource> GetJobExecutionsByAgent(Azure.ResourceManager.Sql.Models.SqlServerJobAgentResourceGetJobExecutionsByAgentOptions p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlServerJobExecutionResource> GetJobExecutionsByAgentAsync(Azure.ResourceManager.Sql.Models.SqlServerJobAgentResourceGetJobExecutionsByAgentOptions p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerJobExecutionCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlServerJobExecutionResource> GetAll(Azure.ResourceManager.Sql.Models.SqlServerJobExecutionCollectionGetAllOptions p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlServerJobExecutionResource> GetAll(System.Nullable<System.DateTimeOffset> p0, System.Nullable<System.DateTimeOffset> p1, System.Nullable<System.DateTimeOffset> p2, System.Nullable<System.DateTimeOffset> p3, System.Nullable<System.Boolean> p4, System.Nullable<System.Int32> p5, System.Nullable<System.Int32> p6, System.Threading.CancellationToken p7)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlServerJobExecutionResource> GetAllAsync(Azure.ResourceManager.Sql.Models.SqlServerJobExecutionCollectionGetAllOptions p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlServerJobExecutionResource> GetAllAsync(System.Nullable<System.DateTimeOffset> p0, System.Nullable<System.DateTimeOffset> p1, System.Nullable<System.DateTimeOffset> p2, System.Nullable<System.DateTimeOffset> p3, System.Nullable<System.Boolean> p4, System.Nullable<System.Int32> p5, System.Nullable<System.Int32> p6, System.Threading.CancellationToken p7)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlServerJobExecutionStepTargetResource> GetJobTargetExecutions(Azure.ResourceManager.Sql.Models.SqlServerJobExecutionCollectionGetJobTargetExecutionsOptions p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlServerJobExecutionStepTargetResource> GetJobTargetExecutions(System.Guid p0, System.Nullable<System.DateTimeOffset> p1, System.Nullable<System.DateTimeOffset> p2, System.Nullable<System.DateTimeOffset> p3, System.Nullable<System.DateTimeOffset> p4, System.Nullable<System.Boolean> p5, System.Nullable<System.Int32> p6, System.Nullable<System.Int32> p7, System.Threading.CancellationToken p8)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlServerJobExecutionStepTargetResource> GetJobTargetExecutionsAsync(Azure.ResourceManager.Sql.Models.SqlServerJobExecutionCollectionGetJobTargetExecutionsOptions p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlServerJobExecutionStepTargetResource> GetJobTargetExecutionsAsync(System.Guid p0, System.Nullable<System.DateTimeOffset> p1, System.Nullable<System.DateTimeOffset> p2, System.Nullable<System.DateTimeOffset> p3, System.Nullable<System.DateTimeOffset> p4, System.Nullable<System.Boolean> p5, System.Nullable<System.Int32> p6, System.Nullable<System.Int32> p7, System.Threading.CancellationToken p8)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerJobExecutionStepCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlServerJobExecutionStepResource> GetAll(Azure.ResourceManager.Sql.Models.SqlServerJobExecutionStepCollectionGetAllOptions p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlServerJobExecutionStepResource> GetAll(System.Nullable<System.DateTimeOffset> p0, System.Nullable<System.DateTimeOffset> p1, System.Nullable<System.DateTimeOffset> p2, System.Nullable<System.DateTimeOffset> p3, System.Nullable<System.Boolean> p4, System.Nullable<System.Int32> p5, System.Nullable<System.Int32> p6, System.Threading.CancellationToken p7)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlServerJobExecutionStepResource> GetAllAsync(Azure.ResourceManager.Sql.Models.SqlServerJobExecutionStepCollectionGetAllOptions p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlServerJobExecutionStepResource> GetAllAsync(System.Nullable<System.DateTimeOffset> p0, System.Nullable<System.DateTimeOffset> p1, System.Nullable<System.DateTimeOffset> p2, System.Nullable<System.DateTimeOffset> p3, System.Nullable<System.Boolean> p4, System.Nullable<System.Int32> p5, System.Nullable<System.Int32> p6, System.Threading.CancellationToken p7)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerJobExecutionStepTargetCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlServerJobExecutionStepTargetResource> GetAll(Azure.ResourceManager.Sql.Models.SqlServerJobExecutionStepTargetCollectionGetAllOptions p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlServerJobExecutionStepTargetResource> GetAll(System.Nullable<System.DateTimeOffset> p0, System.Nullable<System.DateTimeOffset> p1, System.Nullable<System.DateTimeOffset> p2, System.Nullable<System.DateTimeOffset> p3, System.Nullable<System.Boolean> p4, System.Nullable<System.Int32> p5, System.Nullable<System.Int32> p6, System.Threading.CancellationToken p7)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlServerJobExecutionStepTargetResource> GetAllAsync(Azure.ResourceManager.Sql.Models.SqlServerJobExecutionStepTargetCollectionGetAllOptions p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlServerJobExecutionStepTargetResource> GetAllAsync(System.Nullable<System.DateTimeOffset> p0, System.Nullable<System.DateTimeOffset> p1, System.Nullable<System.DateTimeOffset> p2, System.Nullable<System.DateTimeOffset> p3, System.Nullable<System.Boolean> p4, System.Nullable<System.Int32> p5, System.Nullable<System.Int32> p6, System.Threading.CancellationToken p7)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerJobVersionStepCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerJobVersionStepResource> Get(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlServerJobVersionStepResource> GetAll(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlServerJobVersionStepResource> GetAllAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerJobVersionStepResource>> GetAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.NullableResponse<Azure.ResourceManager.Sql.SqlServerJobVersionStepResource> GetIfExists(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Sql.SqlServerJobVersionStepResource>> GetIfExistsAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SubscriptionLongTermRetentionBackupCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> Get(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetAll(System.Nullable<System.Boolean> p0, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetAllAsync(System.Nullable<System.Boolean> p0, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource>> GetAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.NullableResponse<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetIfExists(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource>> GetIfExistsAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SubscriptionLongTermRetentionManagedInstanceBackupCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> Get(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetAll(System.Nullable<System.Boolean> p0, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetAllAsync(System.Nullable<System.Boolean> p0, System.Nullable<Azure.ResourceManager.Sql.Models.SqlDatabaseState> p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource>> GetAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.NullableResponse<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetIfExists(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource>> GetIfExistsAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class ResourceGroupLongTermRetentionBackupResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource> ChangeAccessTierByResourceGroup(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.ChangeLongTermRetentionBackupAccessTierParameters p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource>> ChangeAccessTierByResourceGroupAsync(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.ChangeLongTermRetentionBackupAccessTierParameters p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.String p0, System.String p1, Azure.Core.AzureLocation p2, System.String p3, System.String p4, System.String p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource> Get(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource>> GetAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource> LockTimeBasedImmutabilityByResourceGroup(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource>> LockTimeBasedImmutabilityByResourceGroupAsync(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource> RemoveLegalHoldImmutabilityByResourceGroup(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource>> RemoveLegalHoldImmutabilityByResourceGroupAsync(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource> RemoveTimeBasedImmutabilityByResourceGroup(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource>> RemoveTimeBasedImmutabilityByResourceGroupAsync(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource> SetLegalHoldImmutabilityByResourceGroup(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource>> SetLegalHoldImmutabilityByResourceGroupAsync(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class ResourceGroupLongTermRetentionManagedInstanceBackupResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.String p0, System.String p1, Azure.Core.AzureLocation p2, System.String p3, System.String p4, System.String p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource> Get(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource>> GetAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlDatabaseSqlVulnerabilityAssessmentBaselineResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.String p0, System.String p1, System.String p2, System.String p3, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName p4, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineResource> Get(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineResource>> GetAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineResource> Update(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineCreateOrUpdateContent p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineResource>> UpdateAsync(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineCreateOrUpdateContent p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerJobStepResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.String p0, System.String p1, System.String p2, System.String p3, System.String p4, System.String p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerJobStepResource> Update(Azure.WaitUntil p0, Azure.ResourceManager.Sql.SqlServerJobStepData p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerJobStepResource>> UpdateAsync(Azure.WaitUntil p0, Azure.ResourceManager.Sql.SqlServerJobStepData p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SubscriptionLongTermRetentionBackupResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> ChangeAccessTier(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.ChangeLongTermRetentionBackupAccessTierParameters p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource>> ChangeAccessTierAsync(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.ChangeLongTermRetentionBackupAccessTierParameters p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult> Copy(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.CopyLongTermRetentionBackupContent p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult>> CopyAsync(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.CopyLongTermRetentionBackupContent p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.String p0, Azure.Core.AzureLocation p1, System.String p2, System.String p3, System.String p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> Get(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource>> GetAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> LockTimeBasedImmutability(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource>> LockTimeBasedImmutabilityAsync(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> RemoveLegalHoldImmutability(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource>> RemoveLegalHoldImmutabilityAsync(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> RemoveTimeBasedImmutability(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource>> RemoveTimeBasedImmutabilityAsync(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> SetLegalHoldImmutability(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource>> SetLegalHoldImmutabilityAsync(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult> Update(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.UpdateLongTermRetentionBackupContent p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult>> UpdateAsync(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.UpdateLongTermRetentionBackupContent p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SubscriptionLongTermRetentionManagedInstanceBackupResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.String p0, Azure.Core.AzureLocation p1, System.String p2, System.String p3, System.String p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> Get(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource>> GetAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerSqlVulnerabilityAssessmentBaselineCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineResource> CreateOrUpdate(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p1, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineCreateOrUpdateContent p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineResource>> CreateOrUpdateAsync(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p1, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineCreateOrUpdateContent p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<System.Boolean> Exists(Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<System.Boolean>> ExistsAsync(Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineResource> Get(Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineResource>> GetAsync(Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.NullableResponse<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineResource> GetIfExists(Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineResource>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerSqlVulnerabilityAssessmentBaselineRuleCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineRuleResource> CreateOrUpdate(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<System.Boolean> Exists(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<System.Boolean>> ExistsAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineRuleResource> Get(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineRuleResource>> GetAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.NullableResponse<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineRuleResource> GetIfExists(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineRuleResource>> GetIfExistsAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerSqlVulnerabilityAssessmentScanCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<System.Boolean> Exists(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<System.Boolean>> ExistsAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentScanResource> Get(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentScanResource>> GetAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.NullableResponse<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentScanResource> GetIfExists(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentScanResource>> GetIfExistsAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerSqlVulnerabilityAssessmentScanResultCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<System.Boolean> Exists(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<System.Boolean>> ExistsAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentScanResultResource> Get(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentScanResultResource>> GetAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.NullableResponse<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentScanResultResource> GetIfExists(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentScanResultResource>> GetIfExistsAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlDatabaseSqlVulnerabilityAssessmentResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation ExecuteScan(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteScanAsync(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineResource> GetSqlDatabaseSqlVulnerabilityAssessmentBaseline(Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineResource>> GetSqlDatabaseSqlVulnerabilityAssessmentBaselineAsync(Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineCollection GetSqlDatabaseSqlVulnerabilityAssessmentBaselines()
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerSqlVulnerabilityAssessmentBaselineRuleResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineRuleResource> Get(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineRuleResource>> GetAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineRuleResource> Update(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineRuleResource>> UpdateAsync(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerSqlVulnerabilityAssessmentResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation ExecuteScan(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteScanAsync(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineResource> GetSqlServerSqlVulnerabilityAssessmentBaseline(Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineResource>> GetSqlServerSqlVulnerabilityAssessmentBaselineAsync(Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentScanResource> GetSqlServerSqlVulnerabilityAssessmentScan(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentScanResource>> GetSqlServerSqlVulnerabilityAssessmentScanAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class ManagedDatabaseSensitivityLabelCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedDatabaseSensitivityLabelResource> CreateOrUpdate(Azure.WaitUntil p0, Azure.ResourceManager.Sql.SensitivityLabelData p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedDatabaseSensitivityLabelResource>> CreateOrUpdateAsync(Azure.WaitUntil p0, Azure.ResourceManager.Sql.SensitivityLabelData p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class ManagedInstanceServerTrustCertificateResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceServerTrustCertificateResource> Get(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceServerTrustCertificateResource>> GetAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceServerTrustCertificateResource> Update(Azure.WaitUntil p0, Azure.ResourceManager.Sql.ServerTrustCertificateData p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceServerTrustCertificateResource>> UpdateAsync(Azure.WaitUntil p0, Azure.ResourceManager.Sql.ServerTrustCertificateData p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlDatabaseSensitivityLabelCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabaseSensitivityLabelResource> CreateOrUpdate(Azure.WaitUntil p0, Azure.ResourceManager.Sql.SensitivityLabelData p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabaseSensitivityLabelResource>> CreateOrUpdateAsync(Azure.WaitUntil p0, Azure.ResourceManager.Sql.SensitivityLabelData p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlDatabaseSqlVulnerabilityAssessmentBaselineRuleCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineRuleResource> CreateOrUpdate(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlDatabaseSqlVulnerabilityAssessmentBaselineRuleResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineRuleResource> Update(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineRuleResource>> UpdateAsync(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerDevOpsAuditingSettingCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerDevOpsAuditingSettingResource> CreateOrUpdate(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.Sql.SqlServerDevOpsAuditingSettingData p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerDevOpsAuditingSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.Sql.SqlServerDevOpsAuditingSettingData p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<System.Boolean> Exists(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<System.Boolean>> ExistsAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerDevOpsAuditingSettingResource> Get(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerDevOpsAuditingSettingResource>> GetAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerJobResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerJobExecutionResource> CreateJobExecution(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerJobExecutionResource>> CreateJobExecutionAsync(Azure.WaitUntil p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerJobStepCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerJobStepResource> CreateOrUpdate(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.Sql.SqlServerJobStepData p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerJobStepResource>> CreateOrUpdateAsync(Azure.WaitUntil p0, System.String p1, Azure.ResourceManager.Sql.SqlServerJobStepData p2, System.Threading.CancellationToken p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerSqlVulnerabilityAssessmentBaselineResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineResource> Get(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineResource>> GetAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineRuleResource> GetSqlServerSqlVulnerabilityAssessmentBaselineRule(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineRuleResource>> GetSqlServerSqlVulnerabilityAssessmentBaselineRuleAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineResource> Update(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineCreateOrUpdateContent p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentBaselineResource>> UpdateAsync(Azure.WaitUntil p0, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineCreateOrUpdateContent p1, System.Threading.CancellationToken p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql.Mocking
{
    public partial class MockableSqlArmClient
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.Sql.ManagedInstanceServerTrustCertificateResource GetManagedInstanceServerTrustCertificateResource(Azure.Core.ResourceIdentifier p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource GetResourceGroupLongTermRetentionBackupResource(Azure.Core.ResourceIdentifier p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource GetResourceGroupLongTermRetentionManagedInstanceBackupResource(Azure.Core.ResourceIdentifier p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineResource GetSqlDatabaseSqlVulnerabilityAssessmentBaselineResource(Azure.Core.ResourceIdentifier p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.Sql.SqlServerJobVersionStepResource GetSqlServerJobVersionStepResource(Azure.Core.ResourceIdentifier p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource GetSubscriptionLongTermRetentionBackupResource(Azure.Core.ResourceIdentifier p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource GetSubscriptionLongTermRetentionManagedInstanceBackupResource(Azure.Core.ResourceIdentifier p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    public static partial class ArmSqlModelFactory
    {
        public static Azure.ResourceManager.Sql.Models.ImportExportExtensionsOperationResult ImportExportExtensionsOperationResult(Azure.Core.ResourceIdentifier p0, System.String p1, Azure.Core.ResourceType p2, Azure.ResourceManager.Models.SystemData p3, System.Nullable<System.Guid> p4, System.String p5, System.String p6, System.String p7, System.String p8, System.String p9, System.String p10, System.String p11, System.Uri p12, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.Models.PrivateEndpointConnectionRequestStatus> p13)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        public static Azure.ResourceManager.Sql.Models.InstancePoolUsage InstancePoolUsage(Azure.Core.ResourceIdentifier p0, Azure.ResourceManager.Sql.Models.InstancePoolUsageName p1, System.Nullable<Azure.Core.ResourceType> p2, System.String p3, System.Nullable<System.Int32> p4, System.Nullable<System.Int32> p5, System.Nullable<System.Int32> p6)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        public static Azure.ResourceManager.Sql.Models.InstancePoolUsageName InstancePoolUsageName(System.String p0, System.String p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        public static Azure.ResourceManager.Sql.Models.ManagedInstanceQuery ManagedInstanceQuery(Azure.Core.ResourceIdentifier p0, System.String p1, Azure.Core.ResourceType p2, Azure.ResourceManager.Models.SystemData p3, System.String p4)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        public static Azure.ResourceManager.Sql.RestorableDroppedDatabaseData RestorableDroppedDatabaseData(Azure.Core.ResourceIdentifier p0, System.String p1, Azure.Core.ResourceType p2, Azure.ResourceManager.Models.SystemData p3, System.Collections.Generic.IDictionary<System.String, System.String> p4, Azure.Core.AzureLocation p5, Azure.ResourceManager.Sql.Models.SqlSku p6, System.String p7, System.Nullable<System.Int64> p8, System.Nullable<System.DateTimeOffset> p9, System.Nullable<System.DateTimeOffset> p10, System.Nullable<System.DateTimeOffset> p11, System.Nullable<Azure.ResourceManager.Sql.Models.SqlBackupStorageRedundancy> p12, System.Collections.Generic.IDictionary<System.String, Azure.ResourceManager.Sql.Models.SqlDatabaseKey> p13)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        public static Azure.ResourceManager.Sql.Models.SensitivityLabelUpdate SensitivityLabelUpdate(Azure.Core.ResourceIdentifier p0, System.String p1, Azure.Core.ResourceType p2, Azure.ResourceManager.Models.SystemData p3, System.Nullable<Azure.ResourceManager.Sql.Models.SensitivityLabelUpdateKind> p4, System.String p5, System.String p6, System.String p7, Azure.ResourceManager.Sql.SensitivityLabelData p8)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        public static Azure.ResourceManager.Sql.Models.SqlDatabaseExtension SqlDatabaseExtension(Azure.Core.ResourceIdentifier p0, System.String p1, Azure.Core.ResourceType p2, Azure.ResourceManager.Models.SystemData p3, System.Nullable<Azure.ResourceManager.Sql.Models.DatabaseExtensionOperationMode> p4, System.Nullable<Azure.ResourceManager.Sql.Models.StorageKeyType> p5, System.String p6, System.Uri p7, System.String p8, System.String p9, System.String p10, System.String p11, System.String p12, System.String p13, Azure.ResourceManager.Sql.Models.NetworkIsolationSettings p14)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        public static Azure.ResourceManager.Sql.SqlDistributedAvailabilityGroupData SqlDistributedAvailabilityGroupData(Azure.Core.ResourceIdentifier p0, System.String p1, Azure.Core.ResourceType p2, Azure.ResourceManager.Models.SystemData p3, System.String p4, System.Nullable<System.Guid> p5, System.Nullable<Azure.ResourceManager.Sql.Models.SqlReplicationModeType> p6, System.Nullable<Azure.ResourceManager.Sql.Models.SqlServerSideLinkRole> p7, System.String p8, System.String p9, System.Nullable<Azure.ResourceManager.Sql.Models.SqlServerSideLinkRole> p10, System.String p11, System.Nullable<Azure.ResourceManager.Sql.Models.SqlServerFailoverModeType> p12, System.Nullable<Azure.ResourceManager.Sql.Models.SeedingModeType> p13, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.Models.DistributedAvailabilityGroupDatabase> p14)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        public static Azure.ResourceManager.Sql.SqlServerDatabaseReplicationLinkData SqlServerDatabaseReplicationLinkData(Azure.Core.ResourceIdentifier p0, System.String p1, Azure.Core.ResourceType p2, Azure.ResourceManager.Models.SystemData p3, System.String p4, System.String p5, System.String p6, System.Nullable<Azure.Core.AzureLocation> p7, System.Nullable<Azure.ResourceManager.Sql.Models.SqlServerDatabaseReplicationRole> p8, System.Nullable<Azure.ResourceManager.Sql.Models.SqlServerDatabaseReplicationRole> p9, System.String p10, System.Nullable<System.DateTimeOffset> p11, System.Nullable<System.Int32> p12, System.Nullable<Azure.ResourceManager.Sql.Models.ReplicationLinkState> p13, System.Nullable<System.Boolean> p14, System.Nullable<Azure.ResourceManager.Sql.Models.ReplicationLinkType> p15)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        public static Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineAdjustedResult SqlVulnerabilityAssessmentBaselineAdjustedResult(Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineDetails p0, System.Nullable<Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentRuleStatus> p1, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.String>> p2, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.String>> p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        public static Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineCreateOrUpdateContent SqlVulnerabilityAssessmentBaselineCreateOrUpdateContent(Azure.Core.ResourceIdentifier p0, System.String p1, Azure.Core.ResourceType p2, Azure.ResourceManager.Models.SystemData p3, System.Nullable<System.Boolean> p4, System.Collections.Generic.IDictionary<System.String, System.Collections.Generic.IList<System.Collections.Generic.IList<System.String>>> p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        public static Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineDetails SqlVulnerabilityAssessmentBaselineDetails(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.String>> p0, System.Nullable<System.DateTimeOffset> p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        public static Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent(Azure.Core.ResourceIdentifier p0, System.String p1, Azure.Core.ResourceType p2, Azure.ResourceManager.Models.SystemData p3, System.Nullable<System.Boolean> p4, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.String>> p5)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        public static Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBenchmarkReference SqlVulnerabilityAssessmentBenchmarkReference(System.String p0, System.String p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        public static Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentQueryCheck SqlVulnerabilityAssessmentQueryCheck(System.String p0, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.String>> p1, System.Collections.Generic.IEnumerable<System.String> p2)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        public static Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentRemediation SqlVulnerabilityAssessmentRemediation(System.String p0, System.Collections.Generic.IEnumerable<System.String> p1, System.Nullable<System.Boolean> p2, System.String p3)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        public static Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentRuleMetadata SqlVulnerabilityAssessmentRuleMetadata(System.String p0, System.Nullable<Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentRuleSeverity> p1, System.String p2, System.Nullable<Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentRuleType> p3, System.String p4, System.String p5, System.String p6, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentQueryCheck p7, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBenchmarkReference> p8)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        public static Azure.ResourceManager.Sql.SqlVulnerabilityAssessmentScanResultData SqlVulnerabilityAssessmentScanResultData(Azure.Core.ResourceIdentifier p0, System.String p1, Azure.Core.ResourceType p2, Azure.ResourceManager.Models.SystemData p3, System.String p4, System.Nullable<Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentRuleStatus> p5, System.String p6, System.Nullable<System.Boolean> p7, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.String>> p8, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentRemediation p9, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineAdjustedResult p10, Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentRuleMetadata p11)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerJobVersionResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerJobVersionStepResource> GetSqlServerJobVersionStep(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerJobVersionStepResource>> GetSqlServerJobVersionStepAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.ResourceManager.Sql.SqlServerJobVersionStepCollection GetSqlServerJobVersionSteps()
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class ManagedDatabaseColumnResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response DisableRecommendationManagedDatabaseSensitivityLabel(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response> DisableRecommendationManagedDatabaseSensitivityLabelAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response EnableRecommendationManagedDatabaseSensitivityLabel(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response> EnableRecommendationManagedDatabaseSensitivityLabelAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlDatabaseColumnResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response DisableRecommendationSensitivityLabel(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response> DisableRecommendationSensitivityLabelAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response EnableRecommendationSensitivityLabel(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response> EnableRecommendationSensitivityLabelAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class ManagedInstanceOperationCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<System.Boolean> Exists(System.Guid p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<System.Boolean>> ExistsAsync(System.Guid p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceOperationResource> Get(System.Guid p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceOperationResource>> GetAsync(System.Guid p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlDatabaseSqlVulnerabilityAssessmentCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<System.Boolean> Exists(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<System.Boolean>> ExistsAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentResource> Get(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseSqlVulnerabilityAssessmentResource>> GetAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlInstancePoolOperationCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<System.Boolean> Exists(System.Guid p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<System.Boolean>> ExistsAsync(System.Guid p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlInstancePoolOperationResource> Get(System.Guid p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlInstancePoolOperationResource>> GetAsync(System.Guid p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerJobVersionStepResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerJobVersionStepResource> Get(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerJobVersionStepResource>> GetAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerSqlVulnerabilityAssessmentCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<System.Boolean> Exists(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<System.Boolean>> ExistsAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentResource> Get(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentResource>> GetAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerSqlVulnerabilityAssessmentScanResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentScanResource> Get(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentScanResource>> GetAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentScanResultResource> GetSqlServerSqlVulnerabilityAssessmentScanResult(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentScanResultResource>> GetSqlServerSqlVulnerabilityAssessmentScanResultAsync(System.String p0, System.Threading.CancellationToken p1)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerSqlVulnerabilityAssessmentScanResultResource
    {
        [Azure.Core.ForwardsClientCalls]
        public new virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentScanResultResource> Get(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public new virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerSqlVulnerabilityAssessmentScanResultResource>> GetAsync(System.Threading.CancellationToken p0)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}
