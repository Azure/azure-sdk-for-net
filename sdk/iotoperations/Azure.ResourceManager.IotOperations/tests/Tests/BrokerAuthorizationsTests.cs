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
            BrokerAuthorizationResourceCollection brokerAuthorizationResourceCollection =
                await GetBrokerAuthorizationResourceCollectionAsync(ResourceGroup);

            // None are created in a fresh AIO deployment
            // Create BrokerAuthorization
            BrokerAuthorizationResourceData brokerAuthorizationResourceData =
                CreateBrokerAuthorizationResourceData();

            ArmOperation<BrokerAuthorizationResource> resp =
                await brokerAuthorizationResourceCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "sdk-test-brokerauthorization",
                    brokerAuthorizationResourceData
                );
            BrokerAuthorizationResource createdBrokerAuthorization = resp.Value;

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

        private BrokerAuthorizationResourceData CreateBrokerAuthorizationResourceData()
        {
            return new BrokerAuthorizationResourceData(
                // Can normally use the CL from already deployed resource in other RTs but since we are creating new ones in this test we need to construct the CL.
                new ExtendedLocation(ExtendedLocation, ExtendedLocationType.CustomLocation)
            )
            {
                Properties = new BrokerAuthorizationProperties(
                    new AuthorizationConfig
                    {
                        Cache = OperationalMode.Enabled,
                        Rules =
                        {
                            new AuthorizationRule(
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
