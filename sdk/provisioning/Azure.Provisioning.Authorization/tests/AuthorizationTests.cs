// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Storage;
using Azure.Provisioning.Tests;
using Azure.ResourceManager.Authorization.Models;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.Provisioning.Authorization.Tests
{
    public class AuthorizationTests : ProvisioningTestBase
    {
        public AuthorizationTests(bool isAsync) : base(isAsync)
        {
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
    }
}
