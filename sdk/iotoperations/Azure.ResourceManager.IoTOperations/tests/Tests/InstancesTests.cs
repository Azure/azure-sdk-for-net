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
    public class InstancesTests : IoTOperationsManagementClientBase
    {
        public InstancesTests(bool isAsync)
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
            string utcTime = DateTime.UtcNow.ToString("yyyyMMddTHHmmss");
            InstanceResourceData instanceResourceData = CreateInstanceResourceData(
                utcTime,
                instanceResource
            );

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

        private InstanceResourceData CreateInstanceResourceData(
            string utcTime,
            InstanceResource instanceResource
        )
        {
            return new InstanceResourceData(
                new AzureLocation(IoTOperationsManagementTestUtilities.DefaultResourceLocation),
                instanceResource.Data.ExtendedLocation
            )
            {
                Properties = new InstanceProperties(
                    instanceResource.Data.Properties.SchemaRegistryRef
                )
                {
                    Description = "Updated Description: " + utcTime,
                },
            };
        }
    }
}
