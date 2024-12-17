// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IoTOperations.Models;
using Azure.ResourceManager.IoTOperations.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.IoTOperations.Tests
{
    public class InstanceTests : IoTOperationsManagementClientBase
    {
        public InstanceTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record
        { }

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
        public async Task TestInstance()
        {
            // await IoTOperationsManagementTestUtilities.TryRegisterResourceGroupAsync(
            //     ResourceGroupsOperations,
            //     IoTOperationsManagementTestUtilities.DefaultResourceLocation,
            //     IoTOperationsManagementTestUtilities.DefaultResourceGroupName
            // );

            // Get Instances
            InstanceResourceCollection instanceResourceCollection =
                await GetInstanceResourceCollectionAsync(
                    IoTOperationsManagementTestUtilities.DefaultResourceGroupName
                );

            InstanceResource instanceResource = await instanceResourceCollection.GetAsync(
                "aio-o5fjq"
            );

            Assert.IsNotNull(instanceResource);
            Assert.IsNotNull(instanceResource.Data);
            Assert.AreEqual(instanceResource.Data.Name, "aio-o5fjq");

            // Update Instance
            string utcTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            InstanceResourceData instanceResourceData = new InstanceResourceData(
                new AzureLocation(IoTOperationsManagementTestUtilities.DefaultResourceLocation),
                new ExtendedLocation(
                    "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/sdk-test-cluster-110596935/providers/Microsoft.ExtendedLocation/customLocations/location-o5fjq",
                    ExtendedLocationType.CustomLocation
                )
            )
            {
                Properties = new InstanceProperties(
                    new SchemaRegistryRef(
                        new ResourceIdentifier(
                            "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/sdk-test-cluster-110596935/providers/Microsoft.DeviceRegistry/schemaRegistries/aio-sr-a66bef4c65"
                        )
                    )
                )
                {
                    Description = "Updated Description: " + utcTime,
                },
            };

            ArmOperation<InstanceResource> resp =
                await instanceResourceCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "aio-o5fjq",
                    instanceResourceData
                );
            InstanceResource updatedInstance = resp.Value;

            Assert.IsNotNull(updatedInstance);
            Assert.IsNotNull(updatedInstance.Data);
            Assert.IsNotNull(updatedInstance.Data.Properties);
            Assert.IsNotNull(updatedInstance.Data.Properties.Description);
            Assert.AreEqual(
                updatedInstance.Data.Properties.Description,
                "Updated Description: " + utcTime
            );
        }
    }
}
