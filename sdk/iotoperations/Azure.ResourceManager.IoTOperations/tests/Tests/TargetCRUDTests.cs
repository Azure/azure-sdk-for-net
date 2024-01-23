// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.ResourceManager.IoTOperations.Tests.Helpers;
using Azure.ResourceManager.IoTOperations.Models;

namespace Azure.ResourceManager.IoTOperations.Tests
{
    public class TargetCRUDTests : IoTOperationsManagementTestBase
    {
        public TargetCRUDTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task TestTargetCRUDOperations()
        {
            string resourceGroupName = Recording.GenerateAssetName("SdkRg");
            await IoTOperationsManagementTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,IoTOperationsManagementTestUtilities.DefaultResourceLocation, resourceGroupName);
            string targetName = Recording.GenerateAssetName("SdkTargetName");
            ComponentProperties componentProperties = GetComponentProperties();
            TopologiesProperties topologiesProperties = GetTopologiesProperties();
            ReconciliationPolicyModel reconciliationPolicy = GetReconciliationPolicy();
            TargetData targetData = new TargetData(IoTOperationsManagementTestUtilities.DefaultResourceLocation, new ExtendedLocation("eastus", "edgeZone"))
            {
                Components = { componentProperties },
                Topologies = { topologiesProperties },
                ReconciliationPolicy = reconciliationPolicy,
                Scope = "lm",
                Version = "2",
            };
            TargetCollection targetResourceCollection = await GetTargetsResourceCollectionAsync(resourceGroupName);

            // Create
            ArmOperation<TargetResource> createTargetOperation = await targetResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, targetName, targetData);
            await createTargetOperation.WaitForCompletionAsync();
            Assert.IsTrue(createTargetOperation.HasCompleted);
            Assert.IsTrue(createTargetOperation.HasValue);

            // Get
            Response<TargetResource> getTargetResponse = await targetResourceCollection.GetAsync(targetName);
            TargetResource targetResource = getTargetResponse.Value;
            Assert.IsNotNull(targetResource);

            // Update
            componentProperties.Name = "sdk-test-component-updated";
            TargetData targetUpdateParameter = new()
            {
                Components = { componentProperties },
                Topologies = { topologiesProperties },
                ReconciliationPolicy = reconciliationPolicy,
                Scope = "lm",
                Version = "2",
            };
            ArmOperation<TargetResource> updateTargetOperation = await targetResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed,targetName, targetUpdateParameter);
            Assert.IsTrue(updateTargetOperation.HasCompleted);
            Assert.IsTrue(updateTargetOperation.HasValue);

            // Get
            getTargetResponse = await targetResourceCollection.GetAsync(targetName);
            targetResource = getTargetResponse.Value;
            Assert.IsNotNull(targetResource);
            Assert.IsTrue(string.Equals(targetResource.Data.Components[0].Name, "Updated contact name"));

            // Delete
            ArmOperation deleteTargetOperation = await targetResource.DeleteAsync(WaitUntil.Completed);
            await deleteTargetOperation.WaitForCompletionResponseAsync();
            Assert.IsTrue(deleteTargetOperation.HasCompleted);
        }
    }
}
