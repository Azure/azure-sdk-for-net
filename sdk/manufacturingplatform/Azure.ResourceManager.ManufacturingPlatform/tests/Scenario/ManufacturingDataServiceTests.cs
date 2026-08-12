// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManufacturingPlatform.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ManufacturingPlatform.Tests.Scenario
{
    public class ManufacturingDataServiceTests : ManufacturingPlatformManagementTestBase
    {
        public ManufacturingDataServiceTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        [LiveOnly(Reason = "ManufacturingDataService provisioning depends on live service-side resources.")]
        public async Task ManufacturingDataServiceCrud()
        {
            ResourceGroupResource resourceGroup = await CreateResourceGroup(DefaultSubscription, "mfgplatform-rg-", AzureLocation.EastUS2);
            string resourceName = Recording.GenerateAssetName("mfgplatform-");
            string managedResourceGroupName = Recording.GenerateAssetName("mfgplatform-mrg-");
            ManufacturingDataServiceCollection collection = resourceGroup.GetManufacturingDataServices();

            ManufacturingDataServiceData data = CreateManufacturingDataServiceData(managedResourceGroupName);
            ArmOperation<ManufacturingDataServiceResource> createOperation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data);
            Assert.That(createOperation.HasCompleted, Is.True);
            ManufacturingDataServiceResource resource = createOperation.Value;
            Assert.That(resource.Data.Name, Is.EqualTo(resourceName));

            Response<ManufacturingDataServiceResource> getResponse = await collection.GetAsync(resourceName);
            Assert.That(getResponse.Value.Data.Name, Is.EqualTo(resourceName));

            bool found = false;
            await foreach (ManufacturingDataServiceResource item in collection.GetAllAsync())
            {
                if (item.Data.Name == resourceName)
                {
                    found = true;
                    break;
                }
            }
            Assert.That(found, Is.True);

            ArmOperation deleteOperation = await resource.DeleteAsync(WaitUntil.Completed);
            Assert.That(deleteOperation.HasCompleted, Is.True);
            Response<bool> exists = await collection.ExistsAsync(resourceName);
            Assert.That(exists.Value, Is.False);
        }

        private static ManufacturingDataServiceData CreateManufacturingDataServiceData(string managedResourceGroupName)
        {
            return new ManufacturingDataServiceData(AzureLocation.EastUS2)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Sku = new ManufacturingPlatformSku("S1"),
                Properties = ArmManufacturingPlatformModelFactory.ManufacturingDataServiceProperties(
                    aadApplicationId: "00000000-0000-0000-0000-000000000000",
                    managedResourceGroupConfiguration: ArmManufacturingPlatformModelFactory.ManagedResourceGroupConfiguration(managedResourceGroupName, "eastus2"),
                    denyAssignmentExclusions: System.Array.Empty<DenyAssignmentExclusion>())
            };
        }
    }
}