using Microsoft.Azure.Management.DataProtection.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

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

        public List<BackupPolicies> ListAllPoliciesWithRetries()
        {
            List<BackupPolicies> policies = new List<BackupPolicies>();
            BackupClient.BackupPolicies.ListWithHttpMessagesAsync(VaultName, ResourceGroup);

            return policies;
        }
    }
}
