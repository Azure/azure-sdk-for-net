// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.RecoveryServicesDataReplication.Tests.Helpers;

namespace Azure.ResourceManager.RecoveryServicesDataReplication.Tests.Tests
{
    public class PolicyCRUDTest : RecoveryServicesDataReplicationManagementTestBase
    {
        public PolicyCRUDTest(bool isAsync)
            : base(isAsync, RecordedTestMode.Playback)
        {
        }

        [TestCase]
        public async Task TestPolicyCRUDOperations()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroupAsync(
                RecoveryServicesDataReplicationManagementTestUtilities.DefaultResourceGroupName);

            VaultModelResource vault = await rg.GetVaultModels().GetAsync(
                RecoveryServicesDataReplicationManagementTestUtilities.DefaultVaultName);

            Random random = new Random();
            var policyName = $"policy{random.Next(0, 101)}";
            var policyModelData = new PolicyModelData
            {
                Properties = new Models.PolicyModelProperties
                {
                    CustomProperties = new Models.VMwareToAzStackHCIPolicyModelCustomProperties
                    {
                        InstanceType = "VMwareToAzStackHCI",
                        RecoveryPointHistoryInMinutes =
                            RecoveryServicesDataReplicationManagementTestUtilities.RecoveryPointHistoryInMinutes,
                        CrashConsistentFrequencyInMinutes =
                            RecoveryServicesDataReplicationManagementTestUtilities.CrashConsistentFrequencyInMinutes,
                        AppConsistentFrequencyInMinutes =
                            RecoveryServicesDataReplicationManagementTestUtilities.AppConsistentFrequencyInMinutes
                    }
                }
            };

            // Create
            var createPolicyOperation = await vault.GetPolicyModels().CreateOrUpdateAsync(
                WaitUntil.Completed,
                policyName,
                policyModelData);

            Assert.IsTrue(createPolicyOperation.HasCompleted);
            Assert.IsTrue(createPolicyOperation.HasValue);

            // Get
            var getPolicyOperation = await vault.GetPolicyModels().GetAsync(policyName);
            var policyModelResource = getPolicyOperation.Value;

            Assert.IsNotNull(policyModelResource);

            // Delete
            var deletePolicyOperation = await policyModelResource.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deletePolicyOperation.HasCompleted);
        }
    }
}
