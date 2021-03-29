// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Communication.Identity.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="CommunicationIdentityClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class CommunicationIdentityClientLiveTests : CommunicationIdentityClientLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationIdentityClient"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public CommunicationIdentityClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [TestCase(AuthMethod.ConnectionString, "chat", TestName = "GettingTokenWithSingleScopeWithConnectionString")]
        [TestCase(AuthMethod.KeyCredential, "chat", TestName = "GettingTokenWithSingleScopeWithKeyCredential")]
        [TestCase(AuthMethod.TokenCredential, "chat", TestName = "GettingTokenWithSingleScopeWithTokenCredential")]
        [TestCase(AuthMethod.ConnectionString, "chat", "voip", TestName = "GettingTokenWithMultipleScopesWithConnectionString")]
        [TestCase(AuthMethod.KeyCredential, "chat", "voip", TestName = "GettingTokenWithMultipleScopesWithKeyCredential")]
        [TestCase(AuthMethod.TokenCredential, "chat", "voip", TestName = "GettingTokenWithMultipleScopesWithTokenCredential")]
        public async Task GetTokenGeneratesTokenAndIdentityWithScopes(AuthMethod authMethod, params string[] scopes)
        {
            CommunicationIdentityClient client = authMethod switch
            {
                AuthMethod.ConnectionString => CreateClientWithConnectionString(),
                AuthMethod.KeyCredential => CreateClientWithAzureKeyCredential(),
                AuthMethod.TokenCredential => CreateClientWithTokenCredential(),
                _ => throw new ArgumentOutOfRangeException(nameof(authMethod)),
            };

            Response<CommunicationUserIdentifier> userResponse = await client.CreateUserAsync();
            Response<AccessToken> tokenResponse = await client.GetTokenAsync(userResponse.Value, scopes: scopes.Select(x => new CommunicationTokenScope(x)));
            Assert.IsNotNull(tokenResponse.Value);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tokenResponse.Value.Token));
            ValidateScopesIfNotSanitized();

            void ValidateScopesIfNotSanitized()
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    JwtTokenParser.JwtPayload payload = JwtTokenParser.DecodeJwtPayload(tokenResponse.Value.Token);
                    CollectionAssert.AreEquivalent(scopes, payload.Scopes);
                }
            }
        }
    }
}
