// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.Graph.Rbac;
using Azure.ResourceManager.KeyVault.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.KeyVault.Tests
{
    [ClientTestFixture]
    public abstract class VaultOperationsTestsBase : ManagementRecordedTestBase<KeyVaultManagementTestEnvironment>
    {
        private const string ObjectIdKey = "ObjectId";
        public static TimeSpan ZeroPollingInterval { get; } = TimeSpan.FromSeconds(0);

        public string ObjectId { get; set; }
        //Could not use TestEnvironment.Location since Location is got dynamically
        public string Location { get; set; }

        public AccessPolicyEntry AccessPolicy { get; internal set; }
        public string ResGroupName { get; internal set; }
        public Dictionary<string, string> Tags { get; internal set; }
        public Guid TenantIdGuid { get; internal set; }
        public string VaultName { get; internal set; }
        public VaultProperties VaultProperties { get; internal set; }

        public VaultsOperations VaultsClient { get; set; }
        public ResourcesOperations ResourcesClient { get; set; }
        public ResourceGroupsOperations ResourceGroupsClient { get; set; }
        public ProvidersOperations ResourceProvidersClient { get; set; }

        protected VaultOperationsTestsBase(bool isAsync)
            : base(isAsync)
        {
        }

        protected async Task Initialize()
        {
            var resourceManagementClient = GetResourceManagementClient();
            ResourcesClient = resourceManagementClient.Resources;
            ResourceGroupsClient = resourceManagementClient.ResourceGroups;
            ResourceProvidersClient = resourceManagementClient.Providers;

            var keyVaultManagementClient = GetKeyVaultManagementClient();
            VaultsClient = keyVaultManagementClient.Vaults;

            if (Mode == RecordedTestMode.Playback)
            {
                this.ObjectId = Recording.GetVariable(ObjectIdKey, string.Empty);
            }
            else if (Mode == RecordedTestMode.Record)
            {
                var spClient = new RbacManagementClient(TestEnvironment.TenantId, TestEnvironment.Credential).ServicePrincipals;
                var servicePrincipalList = spClient.ListAsync($"appId eq '{TestEnvironment.ClientId}'").ToEnumerableAsync().Result;
                foreach (var servicePrincipal in servicePrincipalList)
                {
                    this.ObjectId = servicePrincipal.ObjectId;
                    Recording.GetVariable(ObjectIdKey, this.ObjectId);
                    break;
                }
            }
            var provider = (await ResourceProvidersClient.GetAsync("Microsoft.KeyVault")).Value;
            this.Location = provider.ResourceTypes.Where(
                (resType) =>
                {
                    if (resType.ResourceType == "vaults")
                        return true;
                    else
                        return false;
                }
                ).First().Locations.FirstOrDefault();

            ResGroupName = Recording.GenerateAssetName("sdktestrg");
            await ResourceGroupsClient.CreateOrUpdateAsync(ResGroupName, new ResourceManager.Resources.Models.ResourceGroup(Location));
            VaultName = Recording.GenerateAssetName("sdktestvault");

            TenantIdGuid = new Guid(TestEnvironment.TenantId);
            Tags = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "value2" }, { "tag3", "value3" } };

            var permissions = new Permissions
            {
                Keys = { new KeyPermissions("all") },
                Secrets = { new SecretPermissions("all") },
                Certificates = { new CertificatePermissions("all") },
                Storage = { new StoragePermissions("all") },
            };
            AccessPolicy = new AccessPolicyEntry(TenantIdGuid, ObjectId, permissions);

            VaultProperties = new VaultProperties(TenantIdGuid, new Sku(SkuFamily.A, SkuName.Standard));

            VaultProperties.EnabledForDeployment = true;
            VaultProperties.EnabledForDiskEncryption = true;
            VaultProperties.EnabledForTemplateDeployment = true;
            VaultProperties.EnableSoftDelete = true;
            VaultProperties.VaultUri = "";
            VaultProperties.NetworkAcls = new NetworkRuleSet() {
                Bypass = "AzureServices",
                DefaultAction = "Allow",
                IpRules =
                {
                    new IPRule("1.2.3.4/32"),
                    new IPRule("1.0.0.0/25")
                }
            };
            VaultProperties.AccessPolicies.Add(AccessPolicy);
        }

        internal KeyVaultManagementClient GetKeyVaultManagementClient()
        {
            return InstrumentClient(new KeyVaultManagementClient(TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                InstrumentClientOptions(new KeyVaultManagementClientOptions())));
        }
    }
}
