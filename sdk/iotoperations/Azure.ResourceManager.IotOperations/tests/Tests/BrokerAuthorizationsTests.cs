// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IotOperations.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.IotOperations.Tests
{
    public class BrokerAuthorizationsTests : IotOperationsManagementClientBase
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
            IotOperationsBrokerAuthorizationCollection brokerAuthorizationResourceCollection =
                await GetBrokerAuthorizationCollectionAsync(ResourceGroup);

            // None are created in a fresh AIO deployment
            // Create BrokerAuthorization
            IotOperationsBrokerAuthorizationData brokerAuthorizationResourceData =
                CreateBrokerAuthorizationData();

            ArmOperation<IotOperationsBrokerAuthorizationResource> resp =
                await brokerAuthorizationResourceCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "sdk-test-brokerauthorization",
                    brokerAuthorizationResourceData
                );
            IotOperationsBrokerAuthorizationResource createdBrokerAuthorization = resp.Value;

            Assert.IsNotNull(createdBrokerAuthorization);
            Assert.IsNotNull(createdBrokerAuthorization.Data);
            Assert.IsNotNull(createdBrokerAuthorization.Data.Properties);

            // Delete BrokerAuthorization
            await createdBrokerAuthorization.DeleteAsync(WaitUntil.Completed);

            // Verify BrokerAuthorization is deleted
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await createdBrokerAuthorization.GetAsync()
            );
        }

        private IotOperationsBrokerAuthorizationData CreateBrokerAuthorizationData()
        {
            return new IotOperationsBrokerAuthorizationData(
                // Can normally use the CL from already deployed resource in other RTs but since we are creating new ones in this test we need to construct the CL.
                new IotOperationsExtendedLocation(ExtendedLocation, IotOperationsExtendedLocationType.CustomLocation)
            )
            {
                Properties = new IotOperationsBrokerAuthorizationProperties(
                    new BrokerAuthorizationConfig
                    {
                        Cache = IotOperationsOperationalMode.Enabled,
                        Rules =
                        {
                            new BrokerAuthorizationRule(
                                new BrokerResourceRule[]
                                {
                                    new BrokerResourceRule(BrokerResourceDefinitionMethod.Connect)
                                    {
                                        },
                                    new BrokerResourceRule(BrokerResourceDefinitionMethod.Subscribe)
                                    {
                                        Topics = { "topic", "topic/with/wildcard/#" }
                                    },
                                },
                                new PrincipalConfig
                                {
                                    ClientIds = { "my-client-id" },
                                    Usernames = { "clientUserName" },
                                }
                            )
                            {
                                StateStoreResources =
                                {
                                    new StateStoreResourceRule(
                                        StateStoreResourceKeyType.Pattern,
                                        new string[] { "*" },
                                        StateStoreResourceDefinitionMethod.ReadWrite
                                    )
                                },
                            }
                        },
                    }
                ),
            };
        }
    }
}
