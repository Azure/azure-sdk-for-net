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
    public class JobCRUDTest : RecoveryServicesDataReplicationManagementTestBase
    {
        public JobCRUDTest(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        [TestCase]
        public async Task TestJobCRUDOperations()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroupAsync(
                RecoveryServicesDataReplicationManagementTestUtilities.DefaultResourceGroupName);

            VaultModelResource vault = await rg.GetVaultModels().GetAsync(
                RecoveryServicesDataReplicationManagementTestUtilities.DefaultVaultName);

            var getJobOperation = await vault.GetJobModels().GetAsync(
                RecoveryServicesDataReplicationManagementTestUtilities.DefaultJobName);

            var jobModelResource = getJobOperation.Value;
            Assert.IsNotNull(jobModelResource);
        }
    }
}
