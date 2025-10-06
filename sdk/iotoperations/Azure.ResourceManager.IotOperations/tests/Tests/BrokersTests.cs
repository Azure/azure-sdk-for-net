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
    public class BrokersTests : IotOperationsManagementClientBase
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
            IotOperationsBrokerCollection brokerResourceCollection =
                await GetBrokerCollectionAsync(ResourceGroup);

            IotOperationsBrokerResource brokerResource = await brokerResourceCollection.GetAsync(BrokersName);

            Assert.IsNotNull(brokerResource);
            Assert.IsNotNull(brokerResource.Data);
            Assert.AreEqual(brokerResource.Data.Name, BrokersName);

            // Cant update Broker
        }
    }
}
