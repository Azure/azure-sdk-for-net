// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IotOperations.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.IotOperations.Tests
{
    public class InstancesTests : IotOperationsManagementClientBase
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
            IotOperationsInstanceCollection instanceResourceCollection =
                await GetInstanceCollectionAsync(ResourceGroup);

            IotOperationsInstanceResource instanceResource = await instanceResourceCollection.GetAsync(
                InstanceName
            );

            Assert.IsNotNull(instanceResource);
            Assert.IsNotNull(instanceResource.Data);
            Assert.AreEqual(instanceResource.Data.Name, InstanceName);

            // Update Instance
            Random random = new Random();
            IotOperationsInstanceData instanceResourceData = CreateInstanceData(
                random.ToString(),
                instanceResource
            );

            ArmOperation<IotOperationsInstanceResource> resp =
                await instanceResourceCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    InstanceName,
                    instanceResourceData
                );
            IotOperationsInstanceResource updatedInstance = resp.Value;

            Assert.IsNotNull(updatedInstance);
            Assert.IsNotNull(updatedInstance.Data);
            Assert.IsNotNull(updatedInstance.Data.Properties);
            Assert.IsNotNull(updatedInstance.Data.Properties.Description);
            Assert.AreEqual(
                updatedInstance.Data.Properties.Description,
                "Updated Description: " + random.ToString()
            );
        }

        private IotOperationsInstanceData CreateInstanceData(
            string value,
            IotOperationsInstanceResource instanceResource
        )
        {
            return new IotOperationsInstanceData(
                new AzureLocation(DefaultResourceLocation),
                instanceResource.Data.ExtendedLocation
            )
            {
                Properties = new IotOperationsInstanceProperties(
                    instanceResource.Data.Properties.SchemaRegistryRef
                )
                {
                    Description = "Updated Description: " + value,
                },
            };
        }
    }
}
