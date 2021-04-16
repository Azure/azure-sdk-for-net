using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Newtonsoft.Json;
using Xunit;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Management.DataProtection.Models;

namespace Microsoft.Azure.Management.DataProtection.Backup.Tests.TestHelpers
{
    public class TestHelper : IDisposable
    {
        public string ResourceGroup = "SwaggerTestRg";
        public string VaultName = "NetSDKTestRsVault";
        public string Location = "southeastasia";
        public JObject mockJson;

        public DataProtectionClient BackupClient { get; private set; }

        public void Dispose()
        {
            BackupClient.Dispose();
        }

        public void Initialize(MockContext context)
        {
            BackupClient = context.GetServiceClient<DataProtectionClient>();
            string[] path = Directory.GetFiles("SessionRecords\\DPPDisksE2ETests", "DisksE2ETests.json");
            mockJson = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(path[0]));
        }

        public void CreateVault()
        {
            JToken requestData = mockJson["Entries"][0]["RequestBody"];
            BackupVaultResource backupVaultResource = JsonConvert.DeserializeObject<BackupVaultResource>(requestData.ToString());
            var response = BackupClient.BackupVaults.CreateOrUpdate(VaultName, ResourceGroup, backupVaultResource);
            Assert.NotNull(response);
        }

        public void GetVault()
        {
            var response = BackupClient.BackupVaults.Get(VaultName, ResourceGroup);
            Assert.NotNull(response);
        }

        public void CreatePolicy(string policyName)
        {
            JToken requestData = mockJson["Entries"][2]["RequestBody"];
            BaseBackupPolicyResource body = JsonConvert.DeserializeObject<BaseBackupPolicyResource>(requestData.ToString());
            BaseBackupPolicyResource baseBackupPolicyResource = BackupClient.BackupPolicies.CreateOrUpdate(VaultName, ResourceGroup, policyName, body);
            Assert.NotNull(baseBackupPolicyResource);
        }

        public void GetPolicy(string policyName)
        {
            BaseBackupPolicyResource baseBackupPolicyResource = BackupClient.BackupPolicies.Get(VaultName, ResourceGroup, policyName);
            Assert.NotNull(baseBackupPolicyResource);
        }

        public void ValidateForBackup(string backupInstanceName)
        {
            JToken requestData = mockJson["Entries"][4]["RequestBody"];
            ValidateForBackupRequest body = JsonConvert.DeserializeObject<ValidateForBackupRequest>(requestData.ToString());
            var response = BackupClient.BackupInstances.ValidateForBackup(VaultName, ResourceGroup, body.BackupInstance);
            Assert.Null(response);
        }

        public void CreateBackupInstance(string backupInstanceName)
        {
            JToken requestData = mockJson["Entries"][5]["RequestBody"];
            BackupInstanceResource body = JsonConvert.DeserializeObject<BackupInstanceResource>(requestData.ToString());
            var response = BackupClient.BackupInstances.CreateOrUpdate(VaultName, ResourceGroup, backupInstanceName, body);
            Assert.NotNull(response);
        }

        public void GetBackupInstance(string backupInstanceName)
        {
            var response = BackupClient.BackupInstances.Get(VaultName, ResourceGroup, backupInstanceName);
            Assert.NotNull(response);
        }

        public void TriggerBackup(string backupInstanceName)
        {
            JToken requestData = mockJson["Entries"][7]["RequestBody"];
            TriggerBackupRequest body = JsonConvert.DeserializeObject<TriggerBackupRequest>(requestData.ToString());
            var response = BackupClient.BackupInstances.AdhocBackup(VaultName, ResourceGroup, backupInstanceName, body.BackupRuleOptions);
            Assert.Null(response);
        }

        public void ValidateForRestore(string backupInstanceName)
        {
            JToken requestData = mockJson["Entries"][8]["RequestBody"];
            AzureBackupRestoreRequest body = JsonConvert.DeserializeObject<AzureBackupRestoreRequest>(requestData.ToString());
            var response = BackupClient.BackupInstances.ValidateRestore(VaultName, ResourceGroup, backupInstanceName, body);
            Assert.Null(response);
        }

        public void TriggerRestore(string backupInstanceName)
        {
            JToken requestData = mockJson["Entries"][9]["RequestBody"];
            AzureBackupRecoveryPointBasedRestoreRequest body = JsonConvert.DeserializeObject<AzureBackupRecoveryPointBasedRestoreRequest>(requestData.ToString());
            var response = BackupClient.BackupInstances.TriggerRestore(VaultName, ResourceGroup, backupInstanceName, body);
            Assert.Null(response);
        }
    }
}
