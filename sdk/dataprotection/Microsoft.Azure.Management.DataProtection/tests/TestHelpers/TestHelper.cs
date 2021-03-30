using Microsoft.Azure.Management.DataProtection.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net;

namespace Microsoft.Azure.Management.DataProtection.Backup.Tests.TestHelpers
{
    public class TestHelper : IDisposable
    {
        public string ResourceGroup = "DPPSwaggerTestRg";
        public string VaultName = "DPPNetSDKTestBackupVault";
        public string Location = "southeastasia";

        public DataProtectionBackupClient BackupClient { get; private set; }

        public void Dispose()
        {
            BackupClient.Dispose();
        }

        public void Initialize(MockContext context)
        {
            BackupClient = context.GetServiceClient<DataProtectionBackupClient>();
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
                StorageSettings = storageSettings
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

        public List<BackupPolicies> ListAllPoliciesWithRetries()
        {
            List<BackupPolicies> policies = new List<BackupPolicies>();
            BackupClient.BackupPolicies.ListWithHttpMessagesAsync(VaultName, ResourceGroup);

            return policies;
        }
    }
}
