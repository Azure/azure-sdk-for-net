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
    public class BrokerAuthorizationsTests : IoTOperationsManagementClientBase
    {
        public BrokerAuthorizationsTests(bool isAsync)
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
        public async Task TestBrokerAuthorizations()
        {
            // Get BrokerAuthorizations
            BrokerAuthorizationResourceCollection brokerAuthorizationResourceCollection =
                await GetBrokerAuthorizationResourceCollectionAsync(
                    IoTOperationsManagementTestUtilities.DefaultResourceGroupName
                );

            BrokerAuthorizationResource brokerAuthorizationResource =
                await brokerAuthorizationResourceCollection.GetAsync("default");

            Assert.IsNotNull(brokerAuthorizationResource);
            Assert.IsNotNull(brokerAuthorizationResource.Data);
            Assert.AreEqual(brokerAuthorizationResource.Data.Name, "default");

            // Update BrokerAuthorization
            BrokerAuthorizationResourceData brokerAuthorizationResourceData =
                CreateBrokerAuthorizationResourceData();

            ArmOperation<BrokerAuthorizationResource> resp =
                await brokerAuthorizationResourceCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "default",
                    brokerAuthorizationResourceData
                );
            BrokerAuthorizationResource updatedBrokerAuthorization = resp.Value;

            Assert.IsNotNull(updatedBrokerAuthorization);
            Assert.IsNotNull(updatedBrokerAuthorization.Data);
            Assert.IsNotNull(updatedBrokerAuthorization.Data.Properties);
        }

        private BrokerAuthorizationResourceData CreateBrokerAuthorizationResourceData()
        {
            return new BrokerAuthorizationResourceData
            {
                Properties = new BrokerAuthorizationProperties
                {
                    // Set properties as needed
                }
            };
        }
    }
}
