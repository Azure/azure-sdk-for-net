// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearningServices.Tests
{
    public class MachineLearningServicesManagerTestBase : ManagementRecordedTestBase<MachineLearningServicesTestEnvironment>
    {
        private const string CommonResourceResourceGroup = "test-ml-common";

        protected ResourceGroupResourceIdentifier CommonResourceGroupId { get; private set; }

        protected string CommonStorageId { get; private set; }

        protected string CommonAppInsightId { get; private set; }

        protected string CommonKeyVaultId { get; private set; }

        protected string CommonAcrId { get; private set; }

        protected ArmClient Client { get; private set; }

        protected string StorageAccount { get; }

        protected MachineLearningServicesManagerTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected MachineLearningServicesManagerTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public void OneTimeDependencySetup()
        {
            CommonResourceGroupId = GlobalClient.DefaultSubscription
                .GetResourceGroups()
                .Construct(Location.WestUS2)
                .CreateOrUpdateAsync(CommonResourceResourceGroup)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult().Value.Id;

            CreateAppInsight();
            CreateAcr();
            CreateKeyVault();
            CreateStorage();
            StopSessionRecording();
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected void CreateStorage()
        {
            var id = CommonResourceGroupId.AppendProviderResource(
                "Microsoft.Storage",
                "storageAccounts",
                "track2mlstorage");
            var res = new GenericResourceData()
            {
                Kind = "StorageV2",
                Location = Location.WestUS2,
                Properties = new Dictionary<string, object>
                {
                    { "minimumTlsVersion", "TLS1_2" },
                    { "allowBlobPublicAccess", true },
                    { "allowSharedKeyAccess", true }
                },
                Sku = new Sku() { Name = "Standard_LRS", Tier = "Standard" }
            };

            _ = GlobalClient.DefaultSubscription.GetGenericResources().CreateOrUpdateAsync(id, res)
                .ConfigureAwait(false).GetAwaiter().GetResult();
            CommonStorageId = id;
        }

        protected void CreateAppInsight()
        {
            var id = CommonResourceGroupId.AppendProviderResource(
                "microsoft.insights",
                "components",
                "track2mlappinsight");
            var res = new GenericResourceData()
            {
                Kind = "web",
                Location = Location.WestUS2,
                Properties = new Dictionary<string, object>
                {
                    { "Ver", "V2" },
                }
            };

            _ = GlobalClient.DefaultSubscription.GetGenericResources().CreateOrUpdateAsync(id, res)
                .ConfigureAwait(false).GetAwaiter().GetResult();
            CommonAppInsightId = id;
        }

        protected void CreateKeyVault()
        {
            var id = CommonResourceGroupId.AppendProviderResource(
                "Microsoft.KeyVault",
                "vaults",
                "track2mltestkeyvault");
            var res = new GenericResourceData()
            {
                Location = Location.WestUS2,
                Properties = new Dictionary<string, object>
                {
                    { "sku", new Dictionary<string, object> { { "Name", "Standard" }, { "Family", "A" } } },
                    { "tenantId", SessionEnvironment.TenantId },
                    { "enableSoftDelete", false},
                    { "accessPolicies", new[]
                        {
                            new Dictionary<string, object>
                            {
                                { "tenantId", SessionEnvironment.TenantId },
                                { "objectId", SessionEnvironment.ClientId },
                                {
                                    "permissions", new Dictionary<string, object>
                                    {
                                        { "keys", new[] { "all" }},
                                        { "secrets", new[] { "all" }},
                                        { "certificates", new[] { "all" }},
                                        { "storage", new[] { "all" }},
                                    }
                                }
                            }
                        }
                    }
                }};

            _ = GlobalClient.DefaultSubscription.GetGenericResources().CreateOrUpdateAsync(id, res)
                .ConfigureAwait(false).GetAwaiter().GetResult();
            CommonKeyVaultId = id;
        }

        protected void CreateAcr()
        {
            var id = CommonResourceGroupId.AppendProviderResource(
                "Microsoft.ContainerRegistry",
                "registries",
                "track2mlacr");
            var res = new GenericResourceData()
            {
                Location = Location.WestUS2,
                Properties = new Dictionary<string, object>(),
                Sku = new Sku() { Name = "basic", Tier = "basic" }
            };

            _ = GlobalClient.DefaultSubscription.GetGenericResources().CreateOrUpdateAsync(id, res)
                .ConfigureAwait(false).GetAwaiter().GetResult();
            CommonAcrId = id;
        }
    }
}
