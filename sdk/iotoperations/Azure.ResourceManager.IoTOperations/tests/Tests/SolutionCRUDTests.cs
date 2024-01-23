// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.ResourceManager.IoTOperations.Tests.Helpers;
using Azure.ResourceManager.IoTOperations.Models;

namespace Azure.ResourceManager.IoTOperations.Tests
{
    public class SolutionCRUDTests : IoTOperationsManagementTestBase
    {
        public SolutionCRUDTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task TestSolutionCRUDOperations()
        {
            string resourceGroupName = Recording.GenerateAssetName("SdkRg");
            await IoTOperationsManagementTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,IoTOperationsManagementTestUtilities.DefaultResourceLocation, resourceGroupName);
            string solutionName = Recording.GenerateAssetName("SdkSolutionName");
            ComponentProperties componentProperties = GetComponentProperties();
            SolutionData solutionData = new SolutionData(IoTOperationsManagementTestUtilities.DefaultResourceLocation, new ExtendedLocation("eastus", "edgeZone"))
            {
                Components = { componentProperties },
                Version = "2",
            };
            SolutionCollection solutionResourceCollection = await GetSolutionsResourceCollectionAsync(resourceGroupName);

            // Create
            ArmOperation<SolutionResource> createSolutionOperation = await solutionResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, solutionName, solutionData);
            await createSolutionOperation.WaitForCompletionAsync();
            Assert.IsTrue(createSolutionOperation.HasCompleted);
            Assert.IsTrue(createSolutionOperation.HasValue);

            // Get
            Response<SolutionResource> getSolutionResponse = await solutionResourceCollection.GetAsync(solutionName);
            SolutionResource solutionResource = getSolutionResponse.Value;
            Assert.IsNotNull(solutionResource);

            // Update
            componentProperties.Name = "sdk-test-component-updated";
            SolutionData solutionUpdateParameter = new()
            {
                Components = { componentProperties },
                Version = "2",
            };
            ArmOperation<SolutionResource> updateSolutionOperation = await solutionResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed,solutionName, solutionUpdateParameter);
            Assert.IsTrue(updateSolutionOperation.HasCompleted);
            Assert.IsTrue(updateSolutionOperation.HasValue);

            // Get
            getSolutionResponse = await solutionResourceCollection.GetAsync(solutionName);
            solutionResource = getSolutionResponse.Value;
            Assert.IsNotNull(solutionResource);
            Assert.IsTrue(string.Equals(solutionResource.Data.Components[0].Name, "Updated contact name"));

            // Delete
            ArmOperation deleteSolutionOperation = await solutionResource.DeleteAsync(WaitUntil.Completed);
            await deleteSolutionOperation.WaitForCompletionResponseAsync();
            Assert.IsTrue(deleteSolutionOperation.HasCompleted);
        }
    }
}
