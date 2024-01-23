// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.ResourceManager.IoTOperations.Tests.Helpers;
using Azure.ResourceManager.IoTOperations.Models;

namespace Azure.ResourceManager.IoTOperations.Tests
{
    public class InstanceCRUDTests : IoTOperationsManagementTestBase
    {
        public InstanceCRUDTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task TestInstanceCRUDOperations()
        {
            // Create or update Resource Group
            string resourceGroupName = Recording.GenerateAssetName("SdkRg");
            await IoTOperationsManagementTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,IoTOperationsManagementTestUtilities.DefaultResourceLocation, resourceGroupName);

            // Create the unique properties to an instance resource
            string instanceName = Recording.GenerateAssetName("SdkInstanceName");
            ReconciliationPolicyModel reconciliationPolicy = GetReconciliationPolicy();
            InstanceData instanceData = new InstanceData(IoTOperationsManagementTestUtilities.DefaultResourceLocation, new ExtendedLocation("eastus", "edgeZone"))
            {
                Solution = "sdk-solution",
                TargetName = "sdk-target",
                ReconciliationPolicy = reconciliationPolicy,
                Scope = "lm",
                Version = "2",
            };
            InstanceCollection instanceResourceCollection = await GetInstancesResourceCollectionAsync(resourceGroupName);

            // Create
            ArmOperation<InstanceResource> createInstanceOperation = await instanceResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, instanceName, instanceData);
            await createInstanceOperation.WaitForCompletionAsync();
            Assert.IsTrue(createInstanceOperation.HasCompleted);
            Assert.IsTrue(createInstanceOperation.HasValue);

            // Get
            Response<InstanceResource> getInstanceResponse = await instanceResourceCollection.GetAsync(instanceName);
            InstanceResource instanceResource = getInstanceResponse.Value;
            Assert.IsNotNull(instanceResource);

            // Update
            InstanceData instanceUpdateParameter = new()
            {
                Solution = "sdk-solution-updated",
                TargetName = "sdk-target",
                ReconciliationPolicy = reconciliationPolicy,
                Scope = "lm",
                Version = "2",
            };
            ArmOperation<InstanceResource> updateInstanceOperation = await instanceResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed,instanceName, instanceUpdateParameter);
            Assert.IsTrue(updateInstanceOperation.HasCompleted);
            Assert.IsTrue(updateInstanceOperation.HasValue);

            // Get
            getInstanceResponse = await instanceResourceCollection.GetAsync(instanceName);
            instanceResource = getInstanceResponse.Value;
            Assert.IsNotNull(instanceResource);
            Assert.IsTrue(string.Equals(instanceResource.Data.Solution, "sdk-solution-updated"));

            // Delete
            ArmOperation deleteInstanceOperation = await instanceResource.DeleteAsync(WaitUntil.Completed);
            await deleteInstanceOperation.WaitForCompletionResponseAsync();
            Assert.IsTrue(deleteInstanceOperation.HasCompleted);
        }
    }
}
