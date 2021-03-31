using Microsoft.Azure.Management.DataProtection.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.Management.DataProtection.Backup.Tests.TestHelpers
{
    public class TestHelper : IDisposable
    {
        public string ResourceGroup = "SwaggerTestRg";
        public string VaultName = "NetSDKTestRsVault";
        public string Location = "southeastasia";

        public DataProtectionBackupClient BackupClient { get; private set; }

        public void Dispose()
        {
            BackupClient.Dispose();
        }

        public void Initialize(MockContext context)
        {
            BackupClient = context.GetServiceClient<DataProtectionBackupClient>();
            BackupClient.ApiVersion = "2020-06-01";
            CreateResourceGroup(context);
            CreateVault(VaultName);
        }

        private void CreateResourceGroup(MockContext context)
        {
            ResourceManagementClient resourcesClient = context.GetServiceClient<ResourceManagementClient>();

            try
            {
                resourcesClient.ResourceGroups.CreateOrUpdate(ResourceGroup,
                new ResourceGroup
                {
                    Location = Location
                });

            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode != HttpStatusCode.Conflict) throw;
            }
        }

        private void CreateVault(string vaultName)
        {
            
            BackupVaults vault = new BackupVaults(BackupClient);
            StorageSetting storageSetting = new StorageSetting();
            List<StorageSetting> storageSettings = new List<StorageSetting>();
            storageSettings.Add(storageSetting);
            BackupVaultResource parameters = new BackupVaultResource()
            {
                StorageSettings = storageSettings,
                Location = Location
            };
            try
            {
                vault.CreateOrUpdate(VaultName, ResourceGroup, parameters);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode != HttpStatusCode.Conflict) throw;
            }
        }

        public BaseBackupPolicyResource CreatePolicy(string policyName)
        {
            BaseBackupPolicyResource parameters = new BaseBackupPolicyResource();
            List<string> datasourceTypes = new List<string>();
            datasourceTypes.Add("Microsoft.DBforPostgreSQL/servers/databases");
            // parameters.DatasourceTypes = datasourceTypes;
            string data = "{\"id\":null,\"name\":null,\"type\":null,\"properties\":{\"policyRules\":[{\"backupParameters\":{\"backupType\":\"Full\",\"objectType\":\"AzureBackupParams\",\"extendedParameters\":null},\"trigger\":{\"schedule\":{\"repeatingTimeIntervals\":[\"R/2019-12-26T13:08:27.8535071Z/P0Y0M0DT1H0M\"],\"timeZone\":null},\"taggingCriteria\":[{\"tagInfo\":{\"tagName\":\"Default\",\"eTag\":null,\"id\":\"Default_\"},\"taggingPriority\":99,\"isDefault\":true,\"criteria\":null},{\"tagInfo\":{\"tagName\":\"Weekly\",\"eTag\":null,\"id\":\"Weekly_\"},\"taggingPriority\":20,\"isDefault\":false,\"criteria\":[{\"absoluteCriteria\":null,\"scheduleTimes\":[\"0001-01-01T08:00:00\"],\"daysOfMonth\":null,\"weeksOfTheMonth\":null,\"daysOfTheWeek\":[\"Sunday\"],\"monthsOfYear\":null,\"objectType\":\"ScheduleBasedBackupCriteria\"}]},{\"tagInfo\":{\"tagName\":\"Monthly\",\"eTag\":null,\"id\":\"Monthly_\"},\"taggingPriority\":15,\"isDefault\":false,\"criteria\":[{\"absoluteCriteria\":null,\"scheduleTimes\":[\"0001-01-01T08:00:00\"],\"daysOfMonth\":null,\"weeksOfTheMonth\":[\"First\"],\"daysOfTheWeek\":[\"Sunday\"],\"monthsOfYear\":null,\"objectType\":\"ScheduleBasedBackupCriteria\"}]},{\"tagInfo\":{\"tagName\":\"Yearly\",\"eTag\":null,\"id\":\"Yearly_\"},\"taggingPriority\":10,\"isDefault\":false,\"criteria\":[{\"absoluteCriteria\":null,\"scheduleTimes\":[\"0001-01-01T08:00:00\"],\"daysOfMonth\":null,\"weeksOfTheMonth\":[\"First\"],\"daysOfTheWeek\":[\"Sunday\"],\"monthsOfYear\":[\"January\"],\"objectType\":\"ScheduleBasedBackupCriteria\"}]}],\"objectType\":\"ScheduleBasedTriggerContext\"},\"dataStore\":{\"dataStoreType\":\"VaultStore\",\"objectType\":\"DataStoreInfoBase\"},\"name\":\"BackupWeekly\",\"objectType\":\"AzureBackupRule\"},{\"lifecycles\":[{\"deleteAfter\":{\"objectType\":\"AbsoluteDeleteOption\",\"duration\":\"P1W\"},\"targetDataStoreCopySettings\":null,\"sourceDataStore\":{\"dataStoreType\":\"VaultStore\",\"objectType\":\"DataStoreInfoBase\"}}],\"isDefault\":true,\"name\":\"Default\",\"objectType\":\"AzureRetentionRule\"},{\"lifecycles\":[{\"deleteAfter\":{\"objectType\":\"AbsoluteDeleteOption\",\"duration\":\"P12W\"},\"targetDataStoreCopySettings\":[{\"dataStore\":{\"dataStoreType\":\"ArchiveStore\",\"objectType\":\"DataStoreInfoBase\"},\"copyAfter\":{\"objectType\":\"ImmediateCopyOption\"}}],\"sourceDataStore\":{\"dataStoreType\":\"VaultStore\",\"objectType\":\"DataStoreInfoBase\"}},{\"deleteAfter\":{\"objectType\":\"AbsoluteDeleteOption\",\"duration\":\"P30W\"},\"targetDataStoreCopySettings\":null,\"sourceDataStore\":{\"dataStoreType\":\"ArchiveStore\",\"objectType\":\"DataStoreInfoBase\"}}],\"isDefault\":false,\"name\":\"Weekly\",\"objectType\":\"AzureRetentionRule\"},{\"lifecycles\":[{\"deleteAfter\":{\"objectType\":\"AbsoluteDeleteOption\",\"duration\":\"P60M\"},\"targetDataStoreCopySettings\":[{\"dataStore\":{\"dataStoreType\":\"ArchiveStore\",\"objectType\":\"DataStoreInfoBase\"},\"copyAfter\":{\"objectType\":\"CopyOnExpiryOption\"}}],\"sourceDataStore\":{\"dataStoreType\":\"VaultStore\",\"objectType\":\"DataStoreInfoBase\"}},{\"deleteAfter\":{\"objectType\":\"AbsoluteDeleteOption\",\"duration\":\"P1Y\"},\"targetDataStoreCopySettings\":null,\"sourceDataStore\":{\"dataStoreType\":\"ArchiveStore\",\"objectType\":\"DataStoreInfoBase\"}}],\"isDefault\":false,\"name\":\"Monthly\",\"objectType\":\"AzureRetentionRule\"},{\"lifecycles\":[{\"deleteAfter\":{\"objectType\":\"AbsoluteDeleteOption\",\"duration\":\"P1Y\"},\"targetDataStoreCopySettings\":[{\"dataStore\":{\"dataStoreType\":\"ArchiveStore\",\"objectType\":\"DataStoreInfoBase\"},\"copyAfter\":{\"duration\":\"P2M\",\"objectType\":\"CustomCopyOption\"}}],\"sourceDataStore\":{\"dataStoreType\":\"VaultStore\",\"objectType\":\"DataStoreInfoBase\"}},{\"deleteAfter\":{\"objectType\":\"AbsoluteDeleteOption\",\"duration\":\"P10Y\"},\"targetDataStoreCopySettings\":null,\"sourceDataStore\":{\"dataStoreType\":\"ArchiveStore\",\"objectType\":\"DataStoreInfoBase\"}}],\"isDefault\":false,\"name\":\"Yearly\",\"objectType\":\"AzureRetentionRule\"}],\"datasourceTypes\":[\"Microsoft.DBforPostgreSQL/servers/databases\"],\"objectType\":\"BackupPolicy\"}}";
            BaseBackupPolicyResource body = JsonConvert.DeserializeObject<BaseBackupPolicyResource>(data);
            BaseBackupPolicyResource baseBackupPolicyResource = BackupClient.BackupPolicies.CreateOrUpdate(VaultName, ResourceGroup, policyName, body);
            Assert.NotNull(baseBackupPolicyResource);

            return baseBackupPolicyResource;
        }
    }
}
