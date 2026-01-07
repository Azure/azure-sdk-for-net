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

            Assert.That(instanceResource, Is.Not.Null);
            Assert.That(instanceResource.Data, Is.Not.Null);
            Assert.That(InstanceName, Is.EqualTo(instanceResource.Data.Name));

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

            Assert.That(updatedInstance, Is.Not.Null);
            Assert.That(updatedInstance.Data, Is.Not.Null);
            Assert.That(updatedInstance.Data.Properties, Is.Not.Null);
            Assert.That(updatedInstance.Data.Properties.Description, Is.Not.Null);
            Assert.That(
                "Updated Description: " + random.ToString(),
                Is.EqualTo(updatedInstance.Data.Properties.Description)
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
