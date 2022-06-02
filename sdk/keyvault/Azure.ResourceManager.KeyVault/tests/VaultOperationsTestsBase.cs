// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.KeyVault.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using Microsoft.Graph;
using NUnit.Framework;

namespace Azure.ResourceManager.KeyVault.Tests
{
    [ClientTestFixture]
    public abstract class VaultOperationsTestsBase : ManagementRecordedTestBase<KeyVaultManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected const string ObjectIdKey = "ObjectId";
        protected const int DefSoftDeleteRetentionInDays = 7;

        public static TimeSpan ZeroPollingInterval { get; } = TimeSpan.FromSeconds(0);

        public string ObjectId { get; set; }
        //Could not use TestEnvironment.Location since Location is got dynamically
        public AzureLocation Location { get; set; }

        public SubscriptionResource Subscription { get; private set; }
        public AccessPolicyEntry AccessPolicy { get; internal set; }
        public string ResGroupName { get; internal set; }
        public Dictionary<string, string> Tags { get; internal set; }
        public Guid TenantIdGuid { get; internal set; }
        public string VaultName { get; internal set; }
        public string MHSMName { get; internal set; }
        public VaultProperties VaultProperties { get; internal set; }
        public ManagedHsmProperties ManagedHsmProperties { get; internal set; }

        public VaultCollection VaultCollection { get; set; }
        public DeletedVaultCollection DeletedVaultCollection { get; set; }
        public ManagedHsmCollection ManagedHsmCollection { get; set; }
        public ResourceGroupResource ResourceGroupResource { get; set; }

        protected VaultOperationsTestsBase(bool isAsync)
            : base(isAsync)
        {
        }

        protected VaultOperationsTestsBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)//, true)
        {
        }

        protected async Task Initialize()
        {
            Location = AzureLocation.CanadaCentral;
            Client = GetArmClient();
            Subscription = await Client.GetDefaultSubscriptionAsync();
            DeletedVaultCollection = Subscription.GetDeletedVaults();

            if (Mode == RecordedTestMode.Playback)
            {
                this.ObjectId = Recording.GetVariable(ObjectIdKey, string.Empty);
            }
            else if (Mode == RecordedTestMode.Record)
            {
                // Get ObjectId of Service Principal
                // [warning] Microsoft.Graph required corresponding api permission, Please make sure the service has these two api permissions as follows.
                // 1. ServicePrincipalEndpoint.Read.All(TYPE-Application) 2.ServicePrincipalEndpoint.ReadWrite.All(TYPE-Application)
                var scopes = new[] { "https://graph.microsoft.com/.default" };
                var options = new TokenCredentialOptions
                {
                    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
                };
                var clientSecretCredential = new ClientSecretCredential(TestEnvironment.TenantId, TestEnvironment.ClientId, TestEnvironment.ClientSecret, options);
                var graphClient = new GraphServiceClient(clientSecretCredential, scopes);
                var response = await graphClient.ServicePrincipals.Request().GetAsync();
                var result = response.CurrentPage.Where(i => i.AppId == TestEnvironment.ClientId).FirstOrDefault();
                this.ObjectId = result.Id;
                Recording.GetVariable(ObjectIdKey, this.ObjectId);
            }

            ResGroupName = Recording.GenerateAssetName("sdktestrg-kv-");
            ArmOperation<ResourceGroupResource> rgResponse = await Subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, ResGroupName, new ResourceGroupData(Location)).ConfigureAwait(false);
            ResourceGroupResource = rgResponse.Value;

            VaultCollection = ResourceGroupResource.GetVaults();
            VaultName = Recording.GenerateAssetName("sdktest-vault-");
            MHSMName = Recording.GenerateAssetName("sdktest-mhsm-");
            TenantIdGuid = new Guid(TestEnvironment.TenantId);
            Tags = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "value2" }, { "tag3", "value3" } };

            IdentityAccessPermissions permissions = new IdentityAccessPermissions
            {
                Keys = { new KeyPermission("all") },
                Secrets = { new SecretPermission("all") },
                Certificates = { new CertificatePermission("all") },
                Storage = { new StoragePermission("all") },
            };
            AccessPolicy = new AccessPolicyEntry(TenantIdGuid, ObjectId, permissions);

            VaultProperties = new VaultProperties(TenantIdGuid, new KeyVaultSku(KeyVaultSkuFamily.A, KeyVaultSkuName.Standard));

            VaultProperties.EnabledForDeployment = true;
            VaultProperties.EnabledForDiskEncryption = true;
            VaultProperties.EnabledForTemplateDeployment = true;
            VaultProperties.EnableSoftDelete = true;
            VaultProperties.SoftDeleteRetentionInDays = DefSoftDeleteRetentionInDays;
            VaultProperties.VaultUri = new Uri("http://vaulturi.com");
            VaultProperties.NetworkAcls = new NetworkRuleSet() {
                Bypass = "AzureServices",
                DefaultAction = "Allow",
                IPRules =
                {
                    new IPRule("1.2.3.4/32"),
                    new IPRule("1.0.0.0/25")
                }
            };
            VaultProperties.AccessPolicies.Add(AccessPolicy);

            ManagedHsmCollection = ResourceGroupResource.GetManagedHsms();
            ManagedHsmProperties = new ManagedHsmProperties();
            ManagedHsmProperties.InitialAdminObjectIds.Add(ObjectId);
            ManagedHsmProperties.CreateMode = CreateMode.Default;
            ManagedHsmProperties.EnableSoftDelete = true;
            ManagedHsmProperties.SoftDeleteRetentionInDays = DefSoftDeleteRetentionInDays;
            ManagedHsmProperties.EnablePurgeProtection = false;
            ManagedHsmProperties.NetworkRuleSet = new ManagedHsmNetworkRuleSet()
            {
                Bypass = "AzureServices",
                DefaultAction = "Deny" //Property properties.networkAcls.ipRules is not supported currently and must be set to null.
            };
            ManagedHsmProperties.PublicNetworkAccess = PublicNetworkAccess.Disabled;
            ManagedHsmProperties.TenantId = TenantIdGuid;
        }

        public void IgnoreTestInLiveMode()
        {
            if (Mode == RecordedTestMode.Live)
            {
                Assert.Ignore();
            }
        }
    }
}
