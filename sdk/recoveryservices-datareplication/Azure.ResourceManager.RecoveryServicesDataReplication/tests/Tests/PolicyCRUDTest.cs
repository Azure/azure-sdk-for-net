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

            DataReplicationVaultResource vault = await rg.GetDataReplicationVaults().GetAsync(
                RecoveryServicesDataReplicationManagementTestUtilities.DefaultVaultName);

            var policyName = $"policy{IsAsync.ToString()}123";
            var policyModelData = new DataReplicationPolicyData
            {
                Properties = new Models.DataReplicationPolicyProperties
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
            var createPolicyOperation = await vault.GetDataReplicationPolicies().CreateOrUpdateAsync(
                WaitUntil.Completed,
                policyName,
                policyModelData);

            Assert.IsTrue(createPolicyOperation.HasCompleted);
            Assert.IsTrue(createPolicyOperation.HasValue);

            // Get
            var getPolicyOperation = await vault.GetDataReplicationPolicies().GetAsync(policyName);
            var policyModelResource = getPolicyOperation.Value;

            Assert.IsNotNull(policyModelResource);

            // Delete
            var deletePolicyOperation = await policyModelResource.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deletePolicyOperation.HasCompleted);
        }
    }
}
