// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.Administration.Models;
using Azure.Communication.Identity;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Administration.Tests
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
        [TestCase("chat", TestName = "IssuingTokenWithSingleScope")]
        [TestCase("chat", "pstn", TestName = "IssuingTokenWithMultipleScopes")]
        public async Task IssuingTokenGeneratesTokenAndIdentityWithScopes(params string[] scopes)
        {
            CommunicationIdentityClient client = CreateInstrumentedCommunicationIdentityClient();
            Response<CommunicationUser> userResponse = await client.CreateUserAsync();
            Response<CommunicationUserToken> tokenResponse = await client.IssueTokenAsync(userResponse.Value, scopes: scopes.Select(x => new CommunicationTokenScope(x)));
            Assert.IsNotNull(tokenResponse.Value);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tokenResponse.Value.Token));
            Assert.IsFalse(string.IsNullOrWhiteSpace(tokenResponse.Value.User.Id));
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
