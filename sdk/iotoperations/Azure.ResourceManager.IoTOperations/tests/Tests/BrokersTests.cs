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
    public class BrokersTests : IoTOperationsManagementClientBase
    {
        public BrokersTests(bool isAsync)
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
        public async Task TestBrokers()
        {
            // Get Brokers
            BrokerResourceCollection brokerResourceCollection =
                await GetBrokerResourceCollectionAsync(
                    IoTOperationsManagementTestUtilities.DefaultResourceGroupName
                );

            BrokerResource brokerResource = await brokerResourceCollection.GetAsync("default");

            Assert.IsNotNull(brokerResource);
            Assert.IsNotNull(brokerResource.Data);
            Assert.AreEqual(brokerResource.Data.Name, "default");

            // // Update Broker
            // BrokerResourceData brokerResourceData = CreateBrokerResourceData(
            //     brokerResource,
            //     "High"
            // );

            // ArmOperation<BrokerResource> resp = await brokerResourceCollection.CreateOrUpdateAsync(
            //     WaitUntil.Completed,
            //     "default",
            //     brokerResourceData
            // );
            // BrokerResource updatedBroker = resp.Value;

            // Assert.IsNotNull(updatedBroker);
            // Assert.IsNotNull(updatedBroker.Data);
            // Assert.IsNotNull(updatedBroker.Data.Properties);

            // brokerResourceData = CreateBrokerResourceData(brokerResource, "Medium");

            // resp = await brokerResourceCollection.CreateOrUpdateAsync(
            //     WaitUntil.Completed,
            //     "default",
            //     brokerResourceData
            // );

            // updatedBroker = resp.Value;

            // Assert.IsNotNull(updatedBroker);
            // Assert.IsNotNull(updatedBroker.Data);
            // Assert.IsNotNull(updatedBroker.Data.Properties);
        }

        private BrokerResourceData CreateBrokerResourceData(
            BrokerResource brokerResource,
            string memoryProfile
        )
        {
            return new BrokerResourceData(brokerResource.Data.ExtendedLocation)
            {
                Properties = new BrokerProperties()
                {
                    Advanced = brokerResource.Data.Properties.Advanced,
                    Cardinality = brokerResource.Data.Properties.Cardinality,
                    Diagnostics = brokerResource.Data.Properties.Diagnostics,
                    DiskBackedMessageBuffer = brokerResource
                        .Data
                        .Properties
                        .DiskBackedMessageBuffer,
                    GenerateResourceLimits = brokerResource.Data.Properties.GenerateResourceLimits,
                    MemoryProfile = new BrokerMemoryProfile(memoryProfile),
                },
            };
        }
    }
}
