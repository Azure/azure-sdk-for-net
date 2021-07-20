// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.Graph.Rbac;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.KeyVault.Tests
{
    [ClientTestFixture]
    public abstract class VaultOperationsTestsBase : ManagementRecordedTestBase<KeyVaultManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

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
        public ManagedHsmProperties ManagedHsmProperties { get; internal set; }

        public VaultOperations VaultOperations { get; set; }
        public VaultContainer VaultContainer { get; set; }
        public DeletedVaultContainer DeletedVaultContainer { get; set; }
        public ManagedHsmContainer ManagedHsmContainer { get; set; }
        public ManagedHsmOperations ManagedHsmOperations { get; set; }
        public ResourceGroup ResourceGroup { get; set; }
        public ProvidersOperations ResourceProvidersClient { get; set; }

        protected VaultOperationsTestsBase(bool isAsync)
            : base(isAsync)
        {
        }

        protected async Task Initialize()
        {
            Client = GetArmClient();
            DeletedVaultContainer = Client.DefaultSubscription.GetDeletedVaultContainer();
            var resourceManagementClient = GetResourceManagementClient();
            ResourceProvidersClient = resourceManagementClient.Providers;

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
            Location = provider.ResourceTypes.Where(
                (resType) =>
                {
                    if (resType.ResourceType == "vaults")
                        return true;
                    else
                        return false;
                }
                ).First().Locations.FirstOrDefault();

            ResGroupName = Recording.GenerateAssetName("sdktestrg");
            var rgResponse = await Client.DefaultSubscription.GetResourceGroups().Construct(Location).CreateOrUpdateAsync(ResGroupName).ConfigureAwait(false);
            ResourceGroup = rgResponse.Value;

            VaultContainer = ResourceGroup.GetVaults();
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

            ManagedHsmContainer = ResourceGroup.GetManagedHsms();
            ManagedHsmProperties = new ManagedHsmProperties();
            ManagedHsmProperties.InitialAdminObjectIds.Add(ObjectId);
            ManagedHsmProperties.CreateMode = CreateMode.Default;
            ManagedHsmProperties.EnablePurgeProtection = true;
            ManagedHsmProperties.EnableSoftDelete = true;
            ManagedHsmProperties.NetworkAcls = new MhsmNetworkRuleSet()
            {
                Bypass = "AzureServices",
                DefaultAction = "Deny" //Property properties.networkAcls.ipRules is not supported currently and must be set to null.
            };
            ManagedHsmProperties.PublicNetworkAccess = PublicNetworkAccess.Disabled;
            ManagedHsmProperties.SoftDeleteRetentionInDays = 10;
            ManagedHsmProperties.TenantId = TenantIdGuid;
        }
    }
}
