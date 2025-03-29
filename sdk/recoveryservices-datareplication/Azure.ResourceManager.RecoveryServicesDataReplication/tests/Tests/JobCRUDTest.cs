// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.RecoveryServicesDataReplication.Tests.Helpers;

namespace Azure.ResourceManager.RecoveryServicesDataReplication.Tests.Tests
{
    public class JobCRUDTest : RecoveryServicesDataReplicationManagementTestBase
    {
        public JobCRUDTest(bool isAsync)
            : base(isAsync, RecordedTestMode.Playback)
        {
        }

        [TestCase]
        public async Task TestJobCRUDOperations()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroupAsync(
                DataReplicationTestUtilities.DefaultResourceGroupName);

            DataReplicationVaultResource vault = await rg.GetDataReplicationVaults().GetAsync(
                DataReplicationTestUtilities.DefaultVaultName);

            var getJobOperation = await vault.GetDataReplicationJobs().GetAsync(
                DataReplicationTestUtilities.DefaultJobName);

            var jobModelResource = getJobOperation.Value;
            Assert.IsNotNull(jobModelResource);
        }
    }
}
