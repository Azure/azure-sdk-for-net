// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IotOperations.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.IotOperations.Tests
{
    public class BrokerListenersTests : IotOperationsManagementClientBase
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
                await GetBrokerListenerResourceCollectionAsync(ResourceGroup);

            BrokerListenerResource brokerListenerResource =
                await brokerListenerResourceCollection.GetAsync(BrokersListenersName);

            Assert.IsNotNull(brokerListenerResource);
            Assert.IsNotNull(brokerListenerResource.Data);
            Assert.AreEqual(brokerListenerResource.Data.Name, BrokersListenersName);

            // Create new BrokerListener
            string utcTime = DateTime.UtcNow.ToString("yyyyMMddTHHmmss");

            BrokerListenerResourceData brokerListenerResourceData =
                CreateBrokerListenerResourceData(brokerListenerResource);

            ArmOperation<BrokerListenerResource> resp =
                await brokerListenerResourceCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "sdk-test-" + utcTime.Substring(utcTime.Length - 4),
                    brokerListenerResourceData
                );

            BrokerListenerResource createdBrokerListener = resp.Value;
            Assert.IsNotNull(createdBrokerListener);
            Assert.IsNotNull(createdBrokerListener.Data);
            Assert.IsNotNull(createdBrokerListener.Data.Properties);

            // Delete BrokerListener
            await createdBrokerListener.DeleteAsync(WaitUntil.Completed);

            // Verify BrokerListener is deleted
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await createdBrokerListener.GetAsync()
            );
        }

        private BrokerListenerResourceData CreateBrokerListenerResourceData(
            BrokerListenerResource brokerListenerResource
        )
        {
            return new BrokerListenerResourceData(brokerListenerResource.Data.ExtendedLocation)
            {
                Properties = new BrokerListenerProperties(
                    [
                        new ListenerPort(1883) { Protocol = "Mqtt" },
                        new ListenerPort(9883)
                        {
                            Protocol = "Mqtt",
                            AuthenticationRef = "default",
                            Tls = new TlsCertMethod()
                            {
                                CertManagerCertificateSpec = new CertManagerCertificateSpec()
                                {
                                    IssuerRef = new CertManagerIssuerRef()
                                    {
                                        Group = "cert-manager.io",
                                        Kind = "ClusterIssuer",
                                        Name = "azure-iot-operations-aio-certificate-issuer"
                                    },
                                    PrivateKey = new CertManagerPrivateKey()
                                    {
                                        Algorithm = "Ec256",
                                        RotationPolicy = "Always"
                                    },
                                },
                                Mode = TlsCertMethodMode.Automatic,
                            }
                        },
                    ]
                )
                {
                    ServiceName = "aio-dmqtt-frontend-test",
                    ServiceType = "LoadBalancer",
                },
            };
        }
    }
}
