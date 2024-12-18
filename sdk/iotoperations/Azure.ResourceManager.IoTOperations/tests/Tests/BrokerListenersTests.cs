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
    public class BrokerListenersTests : IoTOperationsManagementClientBase
    {
        public BrokerListenersTests(bool isAsync)
            : base(isAsync) { }

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
        public async Task TestBrokerListeners()
        {
            // Get BrokerListeners
            BrokerListenerResourceCollection brokerListenerResourceCollection =
                await GetBrokerListenerResourceCollectionAsync(
                    IoTOperationsManagementTestUtilities.DefaultResourceGroupName
                );

            BrokerListenerResource brokerListenerResource =
                await brokerListenerResourceCollection.GetAsync("default");

            Assert.IsNotNull(brokerListenerResource);
            Assert.IsNotNull(brokerListenerResource.Data);
            Assert.AreEqual(brokerListenerResource.Data.Name, "default");

            // Update BrokerListener
            BrokerListenerResourceData brokerListenerResourceData =
                CreateBrokerListenerResourceData();

            ArmOperation<BrokerListenerResource> resp =
                await brokerListenerResourceCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "default",
                    brokerListenerResourceData
                );
            BrokerListenerResource updatedBrokerListener = resp.Value;

            Assert.IsNotNull(updatedBrokerListener);
            Assert.IsNotNull(updatedBrokerListener.Data);
            Assert.IsNotNull(updatedBrokerListener.Data.Properties);
        }

        private BrokerListenerResourceData CreateBrokerListenerResourceData()
        {
            return new BrokerListenerResourceData
            {
                Properties = new BrokerListenerProperties
                {
                    // Set properties as needed
                }
            };
        }
    }
}
