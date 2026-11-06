// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager;
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.KeyVault.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ServiceGroups;
using Azure.ResourceManager.ServiceGroups.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Relationships.Tests
{
    public class RelationshipsManagementTestBase : ManagementRecordedTestBase<RelationshipsManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected RelationshipsManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected RelationshipsManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            ArmClientOptions options = new();
            options.SetApiVersion(ServiceGroupResource.ResourceType, "2024-02-01-preview");
            Client = GetArmClient(options);
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<ServiceGroupResource> CreateServiceGroup(string namePrefix, string parentServiceGroupId = null)
        {
            string tenantId = TestEnvironment.TenantId;
            string serviceGroupName = Recording.GenerateAssetName(namePrefix);
            // Prefer an explicit parent, then the configured shared parent Service Group.
            // Using a shared parent means the child SG inherits Relationships RBAC immediately,
            // avoiding LinkedAuthorizationFailed when creating relationships right after SG creation.
            string parentId = parentServiceGroupId
                ?? TestEnvironment.ServiceGroupId;

            var tenantCollection = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            var tenant = tenantCollection.FirstOrDefault();
            Assert.IsNotNull(tenant, "No tenant found");
            var serviceGroupCollection = tenant.GetServiceGroups();

            var data = new ServiceGroupData
            {
                Properties = new ServiceGroupProperties
                {
                    DisplayName = $"Test ServiceGroup {serviceGroupName}",
                    ParentResourceId = new ResourceIdentifier(parentId)
                },
            };

            var lro = await serviceGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, serviceGroupName, data);
            return lro.Value;
        }

        protected async Task<ServiceGroupResource> GetServiceGroupAsync(ResourceIdentifier serviceGroupId)
        {
            var tenantCollection = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            var tenant = tenantCollection.FirstOrDefault();
            Assert.IsNotNull(tenant, "No tenant found");
            return await tenant.GetServiceGroups().GetAsync(serviceGroupId.Name);
        }

        protected async Task<KeyVaultResource> CreateKeyVault(ResourceGroupResource resourceGroup, string namePrefix)
        {
            string vaultName = Recording.GenerateAssetName(namePrefix);
            var tenantId = Guid.Parse(TestEnvironment.TenantId);
            // Standard SKU, no access policies — the minimum needed for resource existence tests.
            var properties = new KeyVaultProperties(tenantId, new KeyVaultSku(KeyVaultSkuFamily.A, KeyVaultSkuName.Standard));
            var content = new KeyVaultCreateOrUpdateContent(resourceGroup.Data.Location, properties);
            var lro = await resourceGroup.GetKeyVaults().CreateOrUpdateAsync(WaitUntil.Completed, vaultName, content);
            return lro.Value;
        }
    }
}
