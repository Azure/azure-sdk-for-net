// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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

            // BrokerAuthorizationResource brokerAuthorizationResource =
            //     await brokerAuthorizationResourceCollection.GetAsync("default");

            // Assert.IsNotNull(brokerAuthorizationResource);
            // Assert.IsNotNull(brokerAuthorizationResource.Data);
            // Assert.AreEqual(brokerAuthorizationResource.Data.Name, "default");

            // Create BrokerAuthorization
            string utcTime = DateTime.UtcNow.ToString("yyyyMMddTHHmmss");

            BrokerAuthorizationResourceData brokerAuthorizationResourceData =
                CreateBrokerAuthorizationResourceData();

            ArmOperation<BrokerAuthorizationResource> resp =
                await brokerAuthorizationResourceCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "sdk-test-" + utcTime.Substring(utcTime.Length - 4),
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
                new ExtendedLocation(
                    "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/sdk-test-cluster-110596935/providers/Microsoft.ExtendedLocation/customLocations/location-o5fjq",
                    ExtendedLocationType.CustomLocation
                )
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
                                new PrincipalDefinition
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
