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

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestTargetCRUDOperations()
        {
            //string resourceGroupName = Recording.GenerateAssetName("SdkRg");
            await IoTOperationsManagementTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,IoTOperationsManagementTestUtilities.DefaultResourceLocation, IoTOperationsManagementTestUtilities.DefaultResourceGroupName);
            string targetName = Recording.GenerateAssetName("sdk-target-name");
            ComponentProperties componentProperties = GetComponentProperties();
            TopologiesProperties topologiesProperties = GetTopologiesProperties();
            ReconciliationPolicyModel reconciliationPolicy = GetReconciliationPolicy();
            TargetData targetData = new TargetData(IoTOperationsManagementTestUtilities.DefaultResourceLocation, new ExtendedLocation("/subscriptions/2bd4119a-4d8d-4090-9183-f9e516c21723/resourceGroups/sdk-test-cluster/providers/Microsoft.ExtendedLocation/customLocations/sdk-test-cluster-cl", "customlocation"))
            {
                Components = { componentProperties },
                Topologies = { topologiesProperties },
                ReconciliationPolicy = reconciliationPolicy,
                Scope = "lm",
                Version = "2",
            };
            TargetCollection targetResourceCollection = await GetTargetsResourceCollectionAsync(IoTOperationsManagementTestUtilities.DefaultResourceGroupName);

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
            TargetData targetUpdateParameter = new TargetData(IoTOperationsManagementTestUtilities.DefaultResourceLocation, new ExtendedLocation("/subscriptions/2bd4119a-4d8d-4090-9183-f9e516c21723/resourceGroups/sdk-test-cluster/providers/Microsoft.ExtendedLocation/customLocations/sdk-test-cluster-cl", "customlocation"))
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
            Assert.IsTrue(string.Equals(targetResource.Data.Components[0].Name, "sdk-test-component-updated"));

            // Delete
            ArmOperation deleteTargetOperation = await targetResource.DeleteAsync(WaitUntil.Completed);
            await deleteTargetOperation.WaitForCompletionResponseAsync();
            Assert.IsTrue(deleteTargetOperation.HasCompleted);
        }
    }
}
