// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.IotOperations.Tests
{
    public class BrokerAuthenticationsTests : IotOperationsManagementClientBase
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
                await GetBrokerAuthenticationResourceCollectionAsync(ResourceGroup);

            BrokerAuthenticationResource brokerAuthenticationResource =
                await brokerAuthenticationResourceCollection.GetAsync(BrokersAuthenticationsName);

            Assert.IsNotNull(brokerAuthenticationResource);
            Assert.IsNotNull(brokerAuthenticationResource.Data);
            Assert.AreEqual(brokerAuthenticationResource.Data.Name, BrokersAuthenticationsName);

            // Create BrokerAuthentication
            string utcTime = DateTime.UtcNow.ToString("yyyyMMddTHHmmss");

            BrokerAuthenticationResourceData brokerAuthenticationResourceData =
                CreateBrokerAuthenticationResourceData(brokerAuthenticationResource);

            ArmOperation<BrokerAuthenticationResource> resp =
                await brokerAuthenticationResourceCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "sdk-test-" + utcTime.Substring(utcTime.Length - 4),
                    brokerAuthenticationResourceData
                );
            BrokerAuthenticationResource createdBrokerAuthentication = resp.Value;

            Assert.IsNotNull(createdBrokerAuthentication);
            Assert.IsNotNull(createdBrokerAuthentication.Data);
            Assert.IsNotNull(createdBrokerAuthentication.Data.Properties);

            // Delete BrokerAuthentication
            await createdBrokerAuthentication.DeleteAsync(WaitUntil.Completed);

            // Verify BrokerAuthentication is deleted
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await createdBrokerAuthentication.GetAsync()
            );
        }

        private BrokerAuthenticationResourceData CreateBrokerAuthenticationResourceData(
            BrokerAuthenticationResource brokerAuthenticationResource
        )
        {
            return new BrokerAuthenticationResourceData(
                brokerAuthenticationResource.Data.ExtendedLocation
            )
            {
                Properties = brokerAuthenticationResource.Data.Properties
            };
        }
    }
}
