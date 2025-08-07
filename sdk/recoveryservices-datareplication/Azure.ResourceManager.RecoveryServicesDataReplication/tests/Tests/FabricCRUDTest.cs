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
using System.Threading;

namespace Azure.ResourceManager.RecoveryServicesDataReplication.Tests.Tests
{
    public class FabricCRUDTest : RecoveryServicesDataReplicationManagementTestBase
    {
        public FabricCRUDTest(bool isAsync)
            : base(isAsync, RecordedTestMode.Playback)
        {
        }

        [TestCase]
        public async Task TestFabricCRUDOperations()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroupAsync(
                DataReplicationTestUtilities.DefaultResourceGroupName);

            // Create
            var fabricData = new DataReplicationFabricData(new AzureLocation(DataReplicationTestUtilities.DeafultLocation))
            {
                Properties = new Models.DataReplicationFabricProperties
                {
                    CustomProperties = new Models.HyperVMigrateFabricCustomProperties()
                    {
                        InstanceType = DataReplicationTestUtilities.DefaultFabricInstanceType,
                        HyperVSiteId = new ResourceIdentifier(DataReplicationTestUtilities.DefaultFabricSourceSiteId),
                        MigrationSolutionId = new ResourceIdentifier(DataReplicationTestUtilities.DefaultFabricMigrationSolutionId)
                    }
                }
            };

            var fabricName = $"fabric{IsAsync.ToString()}12";

            var fabricCreateOperation = await rg.GetDataReplicationFabrics().CreateOrUpdateAsync(
                WaitUntil.Completed,
                fabricName,
                fabricData);

            Assert.IsTrue(fabricCreateOperation.HasCompleted);
            Assert.IsTrue(fabricCreateOperation.HasValue);

            // Get
            DataReplicationFabricResource resource = await rg.GetDataReplicationFabrics().GetAsync(fabricName);
            Assert.NotNull(resource);

            // Delete
            var deleteVaultOperation = await resource.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteVaultOperation.HasCompleted);
        }
    }
}
