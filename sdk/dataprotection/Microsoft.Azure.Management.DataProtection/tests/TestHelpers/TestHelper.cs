using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Management.DataProtection.Models;
using Microsoft.Rest.Serialization;

namespace Microsoft.Azure.Management.DataProtection.Backup.Tests.TestHelpers
{
    public class TestHelper : IDisposable
    {
        public string ResourceGroup = "mayaggarDiskRG";
        public string VaultName = "DiskbackupVault2";
        public string Location = "southeastasia";

        public DataProtectionClient BackupClient { get; private set; }

        public void Dispose()
        {
            BackupClient.Dispose();
        }

        public void Initialize(MockContext context)
        {
            BackupClient = context.GetServiceClient<DataProtectionClient>();
        }

        public void CreateVault()
        {
            string data = "{\n    \"id\": \"/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarDiskRG/providers/Microsoft.DataProtection/BackupVaults/DiskbackupVault2\",\n    \"name\": \"DiskbackupVault2\",\n    \"type\": \"Microsoft.DataProtection/BackupVaults\",\n    \"location\": \"southeastasia\",\n    \"identity\": {\n        \"type\": \"systemAssigned\"\n    },\n    \"properties\": {\n        \"storageSettings\": [\n            {\n                \"datastoreType\": \"VaultStore\",\n                \"type\": \"ZonallyRedundant\"\n            },\n            {\n                \"datastoreType\": \"OperationalStore\",\n                \"type\": \"ZonallyRedundant\"\n            }\n        ]\n    }\n}";
            BackupVaultResource backupVaultResource = SafeJsonConvert.DeserializeObject<BackupVaultResource>(data, BackupClient.DeserializationSettings);
            BackupVaultResource response = BackupClient.BackupVaults.CreateOrUpdate(VaultName, ResourceGroup, backupVaultResource);
            Assert.NotNull(response);
            Assert.Equal("/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarDiskRG/providers/Microsoft.DataProtection/backupVaults/DiskbackupVault2", response.Id);
            Assert.Equal("DiskbackupVault2", response.Name);
            Assert.Equal("southeastasia", response.Location);
            Assert.Equal("Microsoft.DataProtection/backupVaults", response.Type);
        }

        public void GetVault()
        {
            var response = BackupClient.BackupVaults.Get(VaultName, ResourceGroup);
            Assert.NotNull(response);
            Assert.Equal("/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarDiskRG/providers/Microsoft.DataProtection/backupVaults/DiskbackupVault2", response.Id);
            Assert.Equal("DiskbackupVault2", response.Name);
            Assert.Equal("southeastasia", response.Location);
            Assert.Equal("Microsoft.DataProtection/backupVaults", response.Type);
        }

        public void CreatePolicy(string policyName)
        {
            string requestData = "{\r\n  \"id\": \"/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarDiskRG/providers/Microsoft.DataProtection/BackupVaults/DiskbackupVault2/backupPolicies/retentionpolicy2\",\r\n  \"name\": \"retentionpolicy2\",\r\n  \"type\": \"Microsoft.DataProtection/backupPolicies\",\r\n  \"properties\": {\r\n\t\"policyRules\": [\r\n\t  {\r\n\t\t\"backupParameters\": {\r\n\t\t  \"backupType\": \"Incremental\",\r\n\t\t  \"objectType\": \"AzureBackupParams\"\r\n\t\t},\r\n\t\t\"trigger\": {\r\n\t\t  \"schedule\": {\r\n\t\t\t\"repeatingTimeIntervals\": [\r\n\t\t\t  \"R/2019-12-26T13:08:27.8535071Z/PT4H\"\r\n\t\t\t]\r\n\t\t  },\r\n\t\t  \"taggingCriteria\": [\r\n\t\t\t{\r\n\t\t\t  \"tagInfo\": {\r\n\t\t\t\t\"tagName\": \"Default\",\r\n\t\t\t\t\"id\": \"Default_\"\r\n\t\t\t  },\r\n\t\t\t  \"taggingPriority\": 99,\r\n\t\t\t  \"isDefault\": true,\r\n\t\t\t  \"objectType\": \"TaggingCriteria\"\r\n\t\t\t}\r\n\t\t  ],\r\n\t\t  \"objectType\": \"ScheduleBasedTriggerContext\"\r\n\t\t},\r\n\t\t\"dataStore\": {\r\n\t\t  \"dataStoreType\": \"OperationalStore\",\r\n\t\t  \"objectType\": \"DataStoreInfoBase\"\r\n\t\t},\r\n\t\t\"name\": \"BackupHourly\",\r\n\t\t\"objectType\": \"AzureBackupRule\",\r\n\t\t\"ruleType\": \"Backup\"\r\n\t  },\r\n\t  {\r\n\t\t\"lifecycles\": [\r\n\t\t  {\r\n\t\t\t\"sourceDataStore\": {\r\n\t\t\t  \"dataStoreType\": \"OperationalStore\",\r\n\t\t\t  \"objectType\": \"DataStoreInfoBase\"\r\n\t\t\t},\r\n\t\t\t\"deleteAfter\": {\r\n\t\t\t  \"objectType\": \"AbsoluteDeleteOption\",\r\n\t\t\t  \"duration\": \"P1W\"\r\n\t\t\t}\r\n\t\t  }\r\n\t\t],\r\n\t\t\"isDefault\": true,\r\n\t\t\"name\": \"Default\",\r\n\t\t\"objectType\": \"AzureRetentionRule\",\r\n\t\t\"ruleType\": \"Retention\"\r\n\t  }\r\n\t],\r\n\t\"name\": \"retentionpolicy2\",\r\n\t\"id\": \"75efeda6-7c58-4771-a618-0ec86fe8e423\",\r\n\t\"datasourceTypes\": [\r\n\t  \"Microsoft.Compute/disks\"\r\n\t],\r\n\t\"objectType\": \"BackupPolicy\"\r\n  }\r\n}";
            BaseBackupPolicyResource body = SafeJsonConvert.DeserializeObject<BaseBackupPolicyResource>(requestData.ToString(), BackupClient.DeserializationSettings);
            BaseBackupPolicyResource baseBackupPolicyResource = BackupClient.BackupPolicies.CreateOrUpdate(VaultName, ResourceGroup, policyName, body);
            Assert.NotNull(baseBackupPolicyResource);
            Assert.Equal("retentionpolicy2", baseBackupPolicyResource.Name);
            Assert.Equal("/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarDiskRG/providers/Microsoft.DataProtection/backupVaults/DiskbackupVault2/backupPolicies/retentionpolicy2", baseBackupPolicyResource.Id);
        }

        public void GetPolicy(string policyName)
        {
            BaseBackupPolicyResource baseBackupPolicyResource = BackupClient.BackupPolicies.Get(VaultName, ResourceGroup, policyName);
            Assert.NotNull(baseBackupPolicyResource);
        }

        public void ValidateForBackup()
        {
            string requestData = "{\r\n    \"objectType\": \"ValidateForBackupRequest\",\r\n\t\"backupInstance\": {\r\n\t\t\"objectType\": \"BackupInstance\",\r\n\t\t\"dataSourceInfo\": {\r\n\t\t\t\"objectType\": \"Datasource\",\r\n\t\t\t\"resourceID\": \"/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarDiskRG/providers/Microsoft.Compute/disks/testingDisk\",\r\n\t\t\t\"resourceName\": \"testingDisk\",\r\n\t\t\t\"resourceType\": \"Microsoft.Compute/disks\",\r\n\t\t\t\"resourceUri\": \"\",\r\n\t\t\t\"resourceLocation\": \"southeastasia\",\r\n\t\t\t\"datasourceType\": \"Microsoft.Compute/disks\"\r\n\t\t},\r\n\t\t\"policyInfo\": {\r\n\t\t\t\"policyId\": \"/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarDiskRG/providers/Microsoft.DataProtection/BackupVaults/DiskbackupVault2/backupPolicies/retentionpolicy2\",\r\n\t\t\t\"name\": \"retentionpolicy2\",\r\n\t\t\t\"policyVersion\": \"3.2\",\r\n\t\t\t\"policyParameters\": {\r\n\t\t\t\t\"dataStoreParametersList\": [\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\t\"objectType\": \"AzureOperationalStoreParameters\",\r\n\t\t\t\t\t\t\"dataStoreType\": \"OperationalStore\",\r\n\t\t\t\t\t\t\"resourceGroupId\": \"/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarOTDSRG\"\r\n\t\t\t\t\t}\r\n\t\t\t\t]\r\n\t\t\t}\r\n\t\t}\r\n\t}\r\n}";
            ValidateForBackupRequest body = SafeJsonConvert.DeserializeObject<ValidateForBackupRequest>(requestData.ToString(), BackupClient.DeserializationSettings);
            var response = BackupClient.BackupInstances.ValidateForBackup(VaultName, ResourceGroup, body.BackupInstance);
            Assert.NotNull(response);
            Assert.Null(response.JobId);
        }

        public void CreateBackupInstance()
        {
            string requestData = "{\r\n\t\"id\": null,\r\n\t\"name\": \"testingDisk\",\r\n\t\"type\": \"Microsoft.DataProtection/backupvaults/backupInstances\",\r\n\t\"location\": null,\r\n\t\"tags\": null,\r\n\t\"eTag\": null,\r\n\t\"properties\": {\r\n\t\t\"objectType\": \"BackupInstance\",\r\n\t\t\"dataSourceInfo\": {\r\n\t\t\t\"objectType\": \"Datasource\",\r\n\t\t\t\"resourceID\": \"/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarDiskRG/providers/Microsoft.Compute/disks/testingDisk\",\r\n\t\t\t\"resourceName\": \"testingDisk\",\r\n\t\t\t\"resourceType\": \"Microsoft.Compute/disks\",\r\n\t\t\t\"resourceUri\": \"/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarDiskRG/providers/Microsoft.Compute/disks/testingDisk\",\r\n\t\t\t\"resourceLocation\": \"southeastasia\",\r\n\t\t\t\"datasourceType\": \"Microsoft.Compute/disks\"\r\n\t\t},\r\n\t\t\"policyInfo\": {\r\n\t\t\t\"policyId\": \"/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarDiskRG/providers/Microsoft.DataProtection/BackupVaults/DiskbackupVault2/backupPolicies/retentionpolicy2\",\r\n\t\t\t\"name\": \"retentionpolicy2\",\r\n\t\t\t\"policyVersion\": \"3.2\",\r\n            \"policyParameters\": {\r\n\t\t\t\t\"dataStoreParametersList\": [\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\t\"objectType\": \"AzureOperationalStoreParameters\",\r\n\t\t\t\t\t\t\"dataStoreType\": \"OperationalStore\",\r\n\t\t\t\t\t\t\"resourceGroupId\": \"/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarOTDSRG\"\r\n\t\t\t\t\t}\r\n\t\t\t\t]\r\n\t\t\t}\r\n\t\t}\r\n\t}\r\n}";
            BackupInstanceResource body = SafeJsonConvert.DeserializeObject<BackupInstanceResource>(requestData.ToString(), BackupClient.DeserializationSettings);
            var response = BackupClient.BackupInstances.CreateOrUpdate(VaultName, ResourceGroup, body.Name, body);
            Assert.NotNull(response);
            Assert.Equal("/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarDiskRG/providers/Microsoft.DataProtection/backupVaults/DiskbackupVault2/backupInstances/testingDisk", response.Id);
            Assert.Equal("testingDisk", response.Name);
        }

        public void GetBackupInstance(string backupInstanceName)
        {
            var response = BackupClient.BackupInstances.Get(VaultName, ResourceGroup, backupInstanceName);
            Assert.NotNull(response);
        }

        public void TriggerBackup(string backupInstanceName)
        {
            //JToken requestData = mockJson["Entries"][7]["RequestBody"];
            string requestData = "{\r\n  \"backupRuleOptions\": {\r\n    \"ruleName\": \"BackupHourly\",\r\n    \"triggerOption\": {\r\n      \"retentionTagOverride\": \"Default\"\r\n    }\r\n  }\r\n}";
            TriggerBackupRequest body = SafeJsonConvert.DeserializeObject<TriggerBackupRequest>(requestData.ToString(), BackupClient.DeserializationSettings);
            var response = BackupClient.BackupInstances.AdhocBackup(VaultName, ResourceGroup, backupInstanceName, body.BackupRuleOptions);
            Assert.NotNull(response);
            Assert.Equal("/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarDiskRG/providers/Microsoft.DataProtection/backupVaults/DiskbackupVault2/backupJobs/610fe9cb-4196-4508-ab4b-4dbcfdc44b57", response.JobId);
        }

        public void ValidateForRestore(string backupInstanceName)
        {
            string requestData = "{\"objectType\":\"ValidateRestoreRequestObject\",\"restoreRequestObject\":{\"objectType\":\"AzureBackupRecoveryPointBasedRestoreRequest\",\"sourceDataStoreType\":\"OperationalStore\",\"restoreTargetInfo\":{\"objectType\":\"restoreTargetInfo\",\"recoveryOption\":\"FailIfExists\",\"dataSourceInfo\":{\"objectType\":\"Datasource\",\"resourceID\":\"/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggartargetrg/providers/Microsoft.Compute/disks/restoredisk1\",\"resourceName\":\"restoredisk1\",\"resourceType\":\"Microsoft.Compute/disks\",\"resourceLocation\":\"centraluseuap\",\"resourceUri\":\"/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggartargetrg/providers/Microsoft.Compute/disks/restoredisk1\",\"datasourceType\":\"Microsoft.Compute/disks\"},\"restoreLocation\":\"southeastasia\"},\"recoveryPointId\":\"7327d7065c4145b3b6d80bcb8a787ea6\"}}";
            ValidateRestoreRequestObject body = SafeJsonConvert.DeserializeObject<ValidateRestoreRequestObject>(requestData.ToString(), BackupClient.DeserializationSettings);
            var response = BackupClient.BackupInstances.ValidateForRestore(VaultName, ResourceGroup, backupInstanceName, body.RestoreRequestObject);
            Assert.NotNull(response);
            Assert.Null(response.JobId);
        }

        public void TriggerRestore(string backupInstanceName)
        {
            string requestData = "{\r\n\t\"objectType\": \"AzureBackupRecoveryPointBasedRestoreRequest\",\r\n    \"recoveryPointId\": \"7327d7065c4145b3b6d80bcb8a787ea6\",\r\n    \"sourceDataStoreType\": \"OperationalStore\",\r\n    \"recoveryPointTime\": \"2020-10-30T11:47:00.0000000Z\",\r\n   \t\"restoreTargetInfo\": {\r\n\t\t\t\"objectType\": \"restoreTargetInfo\",\r\n\t\t\t\"recoveryOption\": \"FailIfExists\",\r\n\t\t\t\"dataSourceInfo\": {\r\n\t\t\t\t\"objectType\": \"Datasource\",\r\n\t\t\t\t\"resourceID\": \"/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarTargetRG/providers/Microsoft.Compute/disks/restoreDisk1\",\r\n\t\t\t\t\"resourceName\": \"restoreDisk1\",\r\n\t\t\t\t\"resourceType\": \"Microsoft.Compute/disks\",\r\n\t\t\t\t\"resourceLocation\": \"southeastasia\",\r\n\t\t\t\t\"resourceUri\": \"/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarTargetRG/providers/Microsoft.Compute/disks/restoreDisk1\",\r\n\t\t\t\t\"datasourceType\": \"Microsoft.Compute/disks\"\r\n\t\t\t},\r\n\t\t\t\"restoreLocation\": \"southeastasia\"\r\n\t\t}\r\n}";
            AzureBackupRecoveryPointBasedRestoreRequest body = SafeJsonConvert.DeserializeObject<AzureBackupRecoveryPointBasedRestoreRequest>(requestData.ToString(), BackupClient.DeserializationSettings);
            var response = BackupClient.BackupInstances.TriggerRestore(VaultName, ResourceGroup, backupInstanceName, body);
            Assert.NotNull(response);
            Assert.Equal("/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/mayaggarDiskRG/providers/Microsoft.DataProtection/backupVaults/DiskbackupVault2/backupJobs/0c4803ea-3c92-40f1-a1dc-a5d7c602f1d5", response.JobId);
        }
    }
}
