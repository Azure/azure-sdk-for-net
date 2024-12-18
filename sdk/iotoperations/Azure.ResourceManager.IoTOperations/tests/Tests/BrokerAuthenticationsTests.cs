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
    public class BrokerAuthenticationsTests : IoTOperationsManagementClientBase
    {
        public BrokerAuthenticationsTests(bool isAsync)
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
        public async Task TestBrokerAuthentications()
        {
            // Get BrokerAuthentications
            BrokerAuthenticationResourceCollection brokerAuthenticationResourceCollection =
                await GetBrokerAuthenticationResourceCollectionAsync(
                    IoTOperationsManagementTestUtilities.DefaultResourceGroupName
                );

            BrokerAuthenticationResource brokerAuthenticationResource =
                await brokerAuthenticationResourceCollection.GetAsync("default");

            Assert.IsNotNull(brokerAuthenticationResource);
            Assert.IsNotNull(brokerAuthenticationResource.Data);
            Assert.AreEqual(brokerAuthenticationResource.Data.Name, "default");

            // Update BrokerAuthentication
            BrokerAuthenticationResourceData brokerAuthenticationResourceData =
                CreateBrokerAuthenticationResourceData();

            ArmOperation<BrokerAuthenticationResource> resp =
                await brokerAuthenticationResourceCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "default",
                    brokerAuthenticationResourceData
                );
            BrokerAuthenticationResource updatedBrokerAuthentication = resp.Value;

            Assert.IsNotNull(updatedBrokerAuthentication);
            Assert.IsNotNull(updatedBrokerAuthentication.Data);
            Assert.IsNotNull(updatedBrokerAuthentication.Data.Properties);
        }

        private BrokerAuthenticationResourceData CreateBrokerAuthenticationResourceData()
        {
            return new BrokerAuthenticationResourceData
            {
                Properties = new BrokerAuthenticationProperties
                {
                    // Set properties as needed
                }
            };
        }
    }
}
