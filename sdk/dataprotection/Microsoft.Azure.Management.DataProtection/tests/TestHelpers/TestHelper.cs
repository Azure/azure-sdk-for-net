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
using System.IO;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.DataProtection.Backup.Tests.TestHelpers
{
    public class TestHelper : IDisposable
    {
        public string ResourceGroup = "SwaggerTestRg";
        public string VaultName = "NetSDKTestRsVault";
        public string Location = "southeastasia";
        public JObject mockJson;

        public DataProtectionBackupClient BackupClient { get; private set; }

        public void Dispose()
        {
            BackupClient.Dispose();
        }

        public void Initialize(MockContext context)
        {
            BackupClient = context.GetServiceClient<DataProtectionBackupClient>();
            BackupClient.ApiVersion = "2021-01-01";
            string[] path = Directory.GetFiles("SessionRecords\\DPPDisksE2ETests", "DisksE2ETests.json");
            mockJson = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(path[0]));
            CreateVault(VaultName);
        }

        private void CreateVault(string vaultName)
        {
            
            BackupVaults vault = new BackupVaults(BackupClient);
            
            JToken requestData = mockJson["Entries"][0]["RequestBody"];
            
            BackupVaultResource backupVaultResource = JsonConvert.DeserializeObject<BackupVaultResource>(requestData.ToString());

            var response = vault.CreateOrUpdate(VaultName, ResourceGroup, backupVaultResource);
            Assert.NotNull(response);
        }

        public BaseBackupPolicyResource CreatePolicy(string policyName)
        {
            JToken requestData = mockJson["Entries"][1]["RequestBody"];
            BaseBackupPolicyResource body = JsonConvert.DeserializeObject<BaseBackupPolicyResource>(requestData.ToString());
            BaseBackupPolicyResource baseBackupPolicyResource = BackupClient.BackupPolicies.CreateOrUpdate(VaultName, ResourceGroup, policyName, body);
            Assert.NotNull(baseBackupPolicyResource);
            return baseBackupPolicyResource;
        }
    }
}
