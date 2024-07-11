// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.ResourceManager;
using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.Tests.TestFramework;
using Azure.Provisioning.Storage;
using Azure.ResourceManager.Authorization.Models;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.Provisioning.Tests
{
    [AsyncOnly]
    public class ProvisioningTests : ProvisioningTestBase
    {
        public ProvisioningTests(bool async) : base(async)
        {
        }

        [RecordedTest]
        public async Task ResourceGroupOnly()
        {
            TestInfrastructure infrastructure = new TestInfrastructure();
            var resourceGroup = infrastructure.AddResourceGroup();
            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync();
        }

        [RecordedTest]
        public async Task CanAddCustomLocationParameter()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();
            rg.AssignProperty(d => d.Location, new Parameter("myLocationParam"));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync(BinaryData.FromObjectAsJson(
                new
                {
                    myLocationParam = new { value = "eastus" },
                }));
        }

        [RecordedTest]
        public void MultipleSubscriptions()
        {
            // ensure deterministic subscription names and directories
            var random = new TestRandom(RecordedTestMode.Playback, 1);
            var infra = new TestSubscriptionInfrastructure();
            var sub1 = new Subscription(infra, random.NewGuid());
            var sub2 = new Subscription(infra, random.NewGuid());
            _ = new ResourceGroup(infra, parent: sub1);
            _ = new ResourceGroup(infra, parent: sub2);
            infra.Build(GetOutputPath());

            // Multiple subscriptions are not fully supported yet. https://github.com/Azure/azure-sdk-for-net/issues/42146
            // await ValidateBicepAsync();
        }

        [RecordedTest]
        public async Task RoleAssignmentWithParameter()
        {
            var infra = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var storageAccount = infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            infra.AddBlobService();
            storageAccount.AssignRole(RoleDefinition.StorageBlobDataContributor);
            storageAccount.AssignRole(RoleDefinition.StorageQueueDataContributor);
            storageAccount.AssignRole(RoleDefinition.StorageTableDataContributor, Guid.Empty, RoleManagementPrincipalType.User);
            infra.Build(GetOutputPath());

            await ValidateBicepAsync(BinaryData.FromObjectAsJson(new { principalId = new { value = Guid.Empty }}), interactiveMode: true);
        }

        [RecordedTest]
        public async Task RoleAssignmentWithoutParameter()
        {
            var infra = new TestInfrastructure();
            var storageAccount = infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            infra.AddBlobService();
            storageAccount.AssignRole(RoleDefinition.StorageBlobDataContributor, Guid.Empty);
            storageAccount.AssignRole(RoleDefinition.StorageQueueDataContributor, Guid.Empty);
            storageAccount.AssignRole(RoleDefinition.StorageTableDataContributor, Guid.Empty, RoleManagementPrincipalType.User);
            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }

        [RecordedTest]
        public async Task RoleAssignmentWithoutParameterInteractiveMode()
        {
            var infra = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var storageAccount = infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            infra.AddBlobService();
            storageAccount.AssignRole(RoleDefinition.StorageBlobDataContributor, Guid.Empty);
            storageAccount.AssignRole(RoleDefinition.StorageQueueDataContributor, Guid.Empty);
            storageAccount.AssignRole(RoleDefinition.StorageTableDataContributor, Guid.Empty, RoleManagementPrincipalType.User);
            infra.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public void RoleAssignmentPrincipalMustBeSuppliedInNonInteractiveMode()
        {
            var infra = new TestInfrastructure();
            var storageAccount = infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            infra.AddBlobService();

            Assert.Throws<InvalidOperationException>(() => storageAccount.AssignRole(RoleDefinition.StorageBlobDataContributor));
        }

        [RecordedTest]
        public async Task UserAssignedIdentities()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            _ = new UserAssignedIdentity(infrastructure);

            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task DependentResources()
        {
            TestInfrastructure infra = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var sa1 = infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            var sa2 = infra.AddStorageAccount(name: "photoAcct2", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            sa2.AddDependency(sa1);

            infra.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [Test]
        public void EmptyConstructThrows()
        {
            TestInfrastructure infra = new TestInfrastructure();
            Assert.Throws<InvalidOperationException>(() => infra.Build(GetOutputPath()));
        }

        [RecordedTest]
        public async Task ExistingUserAssignedIdentityResource()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();

            infra.AddResource(UserAssignedIdentity.FromExisting(infra, "'existingUserAssignedIdentity'", rg));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }
    }
}
