// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IoTOperations.Models;
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
                await GetInstanceResourceCollectionAsync(ResourceGroup);

            InstanceResource instanceResource = await instanceResourceCollection.GetAsync(
                InstanceName
            );

            Assert.IsNotNull(instanceResource);
            Assert.IsNotNull(instanceResource.Data);
            Assert.AreEqual(instanceResource.Data.Name, InstanceName);

            // Update Instance
            string utcTime = DateTime.UtcNow.ToString("yyyyMMddTHHmmss");
            InstanceResourceData instanceResourceData = CreateInstanceResourceData(
                utcTime,
                instanceResource
            );

            ArmOperation<InstanceResource> resp =
                await instanceResourceCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    InstanceName,
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
                new AzureLocation(DefaultResourceLocation),
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
