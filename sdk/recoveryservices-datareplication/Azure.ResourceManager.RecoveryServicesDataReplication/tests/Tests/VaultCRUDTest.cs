// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.RecoveryServicesDataReplication.Tests.Helpers;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Azure.ResourceManager.RecoveryServicesDataReplication.Tests.Tests
{
    public class VaultCRUDTest: RecoveryServicesDataReplicationManagementTestBase
    {
        public VaultCRUDTest(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        [TestCase]
        public async Task GetVaultTest()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroupAsync(
                RecoveryServicesDataReplicationManagementTestUtilities.DefaultResourceGroupName);

            VaultModelResource resource = await rg.GetVaultModels().GetAsync(
                RecoveryServicesDataReplicationManagementTestUtilities.DefaultVaultName);
            Assert.NotNull(resource);
        }

        [TestCase]
        public async Task TestVaultCRUDOperations()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroupAsync(
                RecoveryServicesDataReplicationManagementTestUtilities.DefaultResourceGroupName);

            // Create
            VaultModelData vaultData = new VaultModelData(new AzureLocation("centraluseuap"))
            {
                Properties = new Models.VaultModelProperties
                {
                    VaultType = Models.ReplicationVaultType.Migrate,
                },
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Tags =
                    {
                         ["Migrate Project"] = "aszmigtest1d6ebba"
                    },
            };

            Random random = new Random();
            var vaultName = $"vault{random.Next(0, 101)}";
            var vaultCreateOperation = await rg.GetVaultModels().CreateOrUpdateAsync(
                WaitUntil.Completed,
                vaultName,
                vaultData);

            Assert.IsTrue(vaultCreateOperation.HasCompleted);
            Assert.IsTrue(vaultCreateOperation.HasValue);

            // Get
            VaultModelResource resource = await rg.GetVaultModels().GetAsync(
                 vaultName);
            Assert.NotNull(resource);

            // Delete
            var deleteVaultOperation = await resource.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteVaultOperation.HasCompleted);
        }
    }
}
