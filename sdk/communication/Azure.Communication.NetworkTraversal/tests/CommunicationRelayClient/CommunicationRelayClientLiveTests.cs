// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Tests;
using Azure.Communication.Identity;
using NUnit.Framework;
using System.Text.Json;
using Azure.Core.TestFramework;

namespace Azure.Communication.NetworkTraversal.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="CommunicationRelayClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/27522")]
    public class CommunicationRelayClientLiveTests : CommunicationRelayClientLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationRelayClient"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public CommunicationRelayClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [TestCase(AuthMethod.ConnectionString, TestName = "GettingTurnCredentialsWithConnectionString")]
        [TestCase(AuthMethod.KeyCredential, TestName = "GettingTurnCredentialsWithKeyCredential")]
        [TestCase(AuthMethod.TokenCredential, TestName = "GettingTurnCredentialsWithTokenCredential")]
        public async Task GettingTurnCredentialsGeneratesTurnCredentials(AuthMethod authMethod, params string[] scopes)
        {
            CommunicationRelayClient client = authMethod switch
            {
                AuthMethod.ConnectionString => CreateClientWithConnectionString(),
                AuthMethod.KeyCredential => CreateClientWithAzureKeyCredential(),
                AuthMethod.TokenCredential => CreateClientWithTokenCredential(),
                _ => throw new ArgumentOutOfRangeException(nameof(authMethod)),
            };

            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();

            Response<CommunicationUserIdentifier> userResponse = await communicationIdentityClient.CreateUserAsync();
            Response<CommunicationRelayConfiguration> turnCredentialsResponse = await client.GetRelayConfigurationAsync(userResponse.Value);

            Assert.IsNotNull(turnCredentialsResponse.Value);
            Assert.IsNotNull(turnCredentialsResponse.Value.ExpiresOn);
            Assert.IsNotNull(turnCredentialsResponse.Value.IceServers);
            foreach (CommunicationIceServer serverCredential in turnCredentialsResponse.Value.IceServers)
            {
                foreach (string url in serverCredential.Urls)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(url));
                }
                Assert.IsFalse(string.IsNullOrWhiteSpace(serverCredential.Username));
                Assert.IsFalse(string.IsNullOrWhiteSpace(serverCredential.Credential));
                Assert.IsNotNull((serverCredential.RouteType));
            }
        }

        [Test]
        [TestCase(AuthMethod.ConnectionString, TestName = "GettingTurnCredentialsWithConnectionStringRouteTypeNearest")]
        [TestCase(AuthMethod.KeyCredential, TestName = "GettingTurnCredentialsWithKeyCredentialRouteTypeNearest")]
        [TestCase(AuthMethod.TokenCredential, TestName = "GettingTurnCredentialsWithTokenCredentialRouteTypeNearest")]
        public async Task GettingTurnCredentialsGeneratesTurnCredentialsWithNearestRouteType(AuthMethod authMethod, params string[] scopes)
            => await GettingTurnCredentialsWithRequestedRouteType(authMethod, RouteType.Nearest);

        [Test]
        [TestCase(AuthMethod.ConnectionString, TestName = "GettingTurnCredentialsWithConnectionStringRouteTypeAny")]
        [TestCase(AuthMethod.KeyCredential, TestName = "GettingTurnCredentialsWithKeyCredentialRouteTypeAny")]
        [TestCase(AuthMethod.TokenCredential, TestName = "GettingTurnCredentialsWithTokenCredentialRouteTypeAny")]
        public async Task GettingTurnCredentialsGeneratesTurnCredentialsWithAnyRouteType(AuthMethod authMethod, params string[] scopes)
        => await GettingTurnCredentialsWithRequestedRouteType(authMethod, RouteType.Any);

        public async Task GettingTurnCredentialsWithRequestedRouteType(AuthMethod authMethod, RouteType routeType)
        {
            CommunicationRelayClient client = authMethod switch
            {
                AuthMethod.ConnectionString => CreateClientWithConnectionString(),
                AuthMethod.KeyCredential => CreateClientWithAzureKeyCredential(),
                AuthMethod.TokenCredential => CreateClientWithTokenCredential(),
                _ => throw new ArgumentOutOfRangeException(nameof(authMethod)),
            };

            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();

            Response<CommunicationUserIdentifier> userResponse = await communicationIdentityClient.CreateUserAsync();
            Response<CommunicationRelayConfiguration> turnCredentialsResponse = await client.GetRelayConfigurationAsync(userResponse.Value, routeType);

            Assert.IsNotNull(turnCredentialsResponse.Value);
            Assert.IsNotNull(turnCredentialsResponse.Value.ExpiresOn);
            Assert.IsNotNull(turnCredentialsResponse.Value.IceServers);
            foreach (CommunicationIceServer serverCredential in turnCredentialsResponse.Value.IceServers)
            {
                foreach (string url in serverCredential.Urls)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(url));
                }
                Assert.IsFalse(string.IsNullOrWhiteSpace(serverCredential.Username));
                Assert.IsFalse(string.IsNullOrWhiteSpace(serverCredential.Credential));
                Assert.AreEqual(routeType, serverCredential.RouteType);
            }
        }

        [Test]
        [TestCase(AuthMethod.ConnectionString, TestName = "GettingTurnCredentialsWithConnectionStringWithoutIdentity")]
        [TestCase(AuthMethod.KeyCredential, TestName = "GettingTurnCredentialsWithKeyCredentialWithoutIdentity")]
        [TestCase(AuthMethod.TokenCredential, TestName = "GettingTurnCredentialsWithTokenCredentialWithoutIdentity")]
        public async Task GettingTurnCredentialsGeneratesTurnCredentialsWithoutIdentity(AuthMethod authMethod, params string[] scopes)
        {
            CommunicationRelayClient client = authMethod switch
            {
                AuthMethod.ConnectionString => CreateClientWithConnectionString(),
                AuthMethod.KeyCredential => CreateClientWithAzureKeyCredential(),
                AuthMethod.TokenCredential => CreateClientWithTokenCredential(),
                _ => throw new ArgumentOutOfRangeException(nameof(authMethod)),
            };

            Response<CommunicationRelayConfiguration> turnCredentialsResponse = await client.GetRelayConfigurationAsync();

            Assert.IsNotNull(turnCredentialsResponse.Value);
            Assert.IsNotNull(turnCredentialsResponse.Value.ExpiresOn);
            Assert.IsNotNull(turnCredentialsResponse.Value.IceServers);

            foreach (CommunicationIceServer serverCredential in turnCredentialsResponse.Value.IceServers)
            {
                foreach (string url in serverCredential.Urls)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(url));
                }
                Assert.IsFalse(string.IsNullOrWhiteSpace(serverCredential.Username));
                Assert.IsFalse(string.IsNullOrWhiteSpace(serverCredential.Credential));
                Assert.IsNotNull((serverCredential.RouteType));
            }
        }

        [Test]
        [TestCase(AuthMethod.ConnectionString, TestName = "GettingTurnCredentialsWithConnectionStringWithTtl")]
        [TestCase(AuthMethod.KeyCredential, TestName = "GettingTurnCredentialsWithKeyCredentialWithTtl")]
        [TestCase(AuthMethod.TokenCredential, TestName = "GettingTurnCredentialsWithTokenCredentialWithTtl")]
        public async Task GettingTurnCredentialsGeneratesTurnCredentialsWithTtl(AuthMethod authMethod, params string[] scopes)
        {
            CommunicationRelayClient client = authMethod switch
            {
                AuthMethod.ConnectionString => CreateClientWithConnectionString(),
                AuthMethod.KeyCredential => CreateClientWithAzureKeyCredential(),
                AuthMethod.TokenCredential => CreateClientWithTokenCredential(),
                _ => throw new ArgumentOutOfRangeException(nameof(authMethod)),
            };
            DateTimeOffset currentTime = DateTimeOffset.Now;
            Response<CommunicationRelayConfiguration> turnCredentialsResponse = await client.GetRelayConfigurationAsync(ttl : 5000);
            currentTime.AddSeconds(5000);

            Assert.IsNotNull(turnCredentialsResponse.Value);
            Assert.IsNotNull(turnCredentialsResponse.Value.ExpiresOn);

            // We only check if we are actually hitting an endpoint.
            // If we compare them when running from playback, the expiresOn value will be the one that was previously recorded so it will always fail.
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.IsTrue(currentTime <= turnCredentialsResponse.Value.ExpiresOn);
            }

            Assert.IsNotNull(turnCredentialsResponse.Value.IceServers);

            foreach (CommunicationIceServer serverCredential in turnCredentialsResponse.Value.IceServers)
            {
                foreach (string url in serverCredential.Urls)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(url));
                }
                Assert.IsFalse(string.IsNullOrWhiteSpace(serverCredential.Username));
                Assert.IsFalse(string.IsNullOrWhiteSpace(serverCredential.Credential));
                Assert.IsNotNull((serverCredential.RouteType));
            }
        }

        [Test]
        [TestCase(AuthMethod.ConnectionString, TestName = "GettingTurnCredentialsWithConnectionStringWithAllParameters")]
        [TestCase(AuthMethod.KeyCredential, TestName = "GettingTurnCredentialsWithKeyCredentialWithAllParameters")]
        [TestCase(AuthMethod.TokenCredential, TestName = "GettingTurnCredentialsWithTokenCredentialWithAllParameters")]
        public async Task GettingTurnCredentialsGeneratesTurnCredentialsWithAllparameters(AuthMethod authMethod, params string[] scopes)
        {
            CommunicationRelayClient client = authMethod switch
            {
                AuthMethod.ConnectionString => CreateClientWithConnectionString(),
                AuthMethod.KeyCredential => CreateClientWithAzureKeyCredential(),
                AuthMethod.TokenCredential => CreateClientWithTokenCredential(),
                _ => throw new ArgumentOutOfRangeException(nameof(authMethod)),
            };

            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();

            Response<CommunicationUserIdentifier> userResponse = await communicationIdentityClient.CreateUserAsync();
            DateTimeOffset currentTime = DateTimeOffset.Now;
            Response<CommunicationRelayConfiguration> turnCredentialsResponse = await client.GetRelayConfigurationAsync(userResponse.Value, RouteType.Nearest, 5000);
            currentTime.AddSeconds(5000);

            Assert.IsNotNull(turnCredentialsResponse.Value);
            Assert.IsNotNull(turnCredentialsResponse.Value.ExpiresOn);

            // We only check if we are actually hitting an endpoint.
            // If we compare them when running from playback, the expiresOn value will be the one that was previously recorded so it will always fail.
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.IsTrue(currentTime <= turnCredentialsResponse.Value.ExpiresOn);
            }

            Assert.IsNotNull(turnCredentialsResponse.Value.IceServers);

            foreach (CommunicationIceServer serverCredential in turnCredentialsResponse.Value.IceServers)
            {
                foreach (string url in serverCredential.Urls)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(url));
                }
                Assert.IsFalse(string.IsNullOrWhiteSpace(serverCredential.Username));
                Assert.IsFalse(string.IsNullOrWhiteSpace(serverCredential.Credential));
                Assert.AreEqual(RouteType.Nearest, serverCredential.RouteType);
            }
        }

        [Test]
        [TestCase(AuthMethod.ConnectionString, TestName = "GettingTurnCredentialsAndValidateSerializationWithConnectionStringWithoutIdentity")]
        [TestCase(AuthMethod.KeyCredential, TestName = "GettingTurnCredentialsAndValidateSerializationWithKeyCredentialWithoutIdentity")]
        [TestCase(AuthMethod.TokenCredential, TestName = "GettingTurnCredentialsAndValidateSerializationWithTokenCredentialWithoutIdentity")]
        public async Task GettingTurnCredentialsAndValidateSerialization(AuthMethod authMethod, params string[] scopes)
        {
            CommunicationRelayClient client = authMethod switch
            {
                AuthMethod.ConnectionString => CreateClientWithConnectionString(),
                AuthMethod.KeyCredential => CreateClientWithAzureKeyCredential(),
                AuthMethod.TokenCredential => CreateClientWithTokenCredential(),
                _ => throw new ArgumentOutOfRangeException(nameof(authMethod)),
            };

            Response<CommunicationRelayConfiguration> turnCredentialsResponse = await client.GetRelayConfigurationAsync();

            Assert.IsNotNull(turnCredentialsResponse.Value);
            Assert.IsNotNull(turnCredentialsResponse.Value.ExpiresOn);
            Assert.IsNotNull(turnCredentialsResponse.Value.IceServers);

            var turnConfig = turnCredentialsResponse.Value;
            var turnConfigSerialized = JsonSerializer.Serialize(turnConfig);
            Assert.IsNotNull(turnConfigSerialized);

            var turnConfigDeserialized = JsonSerializer.Deserialize<CommunicationRelayConfiguration>(turnConfigSerialized);
            Assert.IsNotNull(turnConfigDeserialized);

            foreach (CommunicationIceServer serverCredential in turnCredentialsResponse.Value.IceServers)
            {
                foreach (string url in serverCredential.Urls)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(url));
                }

                var serializedIceServer = JsonSerializer.Serialize(serverCredential);
                Assert.IsNotNull(serializedIceServer);

                CommunicationIceServer? deserializedIceServer = JsonSerializer.Deserialize<CommunicationIceServer>(serializedIceServer);

                Assert.IsNotNull(deserializedIceServer);
                Assert.IsNotNull(deserializedIceServer?.Username);
                Assert.IsNotNull(deserializedIceServer?.RouteType);
                Assert.IsNotNull(deserializedIceServer?.Urls);
                Assert.AreEqual(serverCredential.Username, deserializedIceServer?.Username);
                Assert.AreEqual(serverCredential.RouteType, deserializedIceServer?.RouteType);
                CollectionAssert.AreEqual(serverCredential.Urls, deserializedIceServer?.Urls);
            }
        }
    }
}
