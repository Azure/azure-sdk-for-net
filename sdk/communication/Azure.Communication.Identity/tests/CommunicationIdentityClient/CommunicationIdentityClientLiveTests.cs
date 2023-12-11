// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using static Azure.Communication.Identity.CommunicationIdentityClientOptions;

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
        /// Options used to exchange an AAD access token of a Teams user for a new Communication Identity access token.
        /// </summary>
        private GetTokenForTeamsUserOptions CTEOptions = new GetTokenForTeamsUserOptions("Sanitized", "Sanitized", "Sanitized");

        private const string TOKEN_EXPIRATION_OVERFLOW_MESSAGE = "The tokenExpiresIn argument is out of permitted bounds [1,24] hours. Please refer to the documentation and set the value accordingly.";
        private const double TOKEN_EXPIRATION_ALLOWED_DEVIATION = 0.05;

        private const string MIN_VALID_EXPIRATION_TIME = "minValidExpirationTime";
        private const string MAX_VALID_EXPIRATION_TIME = "maxValidExpirationTime";
        private const string MAX_INVALID_EXPIRATION_TIME = "maxInvalidExpirationTime";
        private const string MIN_INVALID_EXPIRATION_TIME = "minInvalidExpirationTime";

        private Dictionary<string, TimeSpan> TokenCustomExpirationTimes = new Dictionary<string, TimeSpan>
        {
            { MIN_VALID_EXPIRATION_TIME, TimeSpan.FromHours(1) },
            { MAX_VALID_EXPIRATION_TIME, TimeSpan.FromHours(24) },
            { MAX_INVALID_EXPIRATION_TIME, TimeSpan.FromMinutes(59) },
            { MIN_INVALID_EXPIRATION_TIME, TimeSpan.FromMinutes(1441) },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationIdentityClient"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public CommunicationIdentityClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task InitVariables()
        {
            CTEOptions = await CreateTeamsUserParams();
        }

        [TestCase(AuthMethod.ConnectionString, TestName = "GettingTokenWithConnectionString")]
        [TestCase(AuthMethod.KeyCredential, TestName = "GettingTokenWithKeyCredential")]
        [TestCase(AuthMethod.TokenCredential, TestName = "GettingTokenWithTokenCredential")]
        public async Task GetTokenUsingDifferentAuthentication(AuthMethod authMethod)
        {
            string[] scopes = new[] { "chat", "voip" };

            CommunicationIdentityClient client = CreateClient(authMethod);

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

        [TestCase("chat", TestName = "GettingTokenWithChatScope")]
        [TestCase("voip", TestName = "GettingTokenWithVoipScope")]
        [TestCase("chat.join", TestName = "GettingTokenWithChatJoinScope")]
        [TestCase("chat.join.limited", TestName = "GettingTokenWithChatJoinLimitedScope")]
        [TestCase("voip.join", TestName = "GettingTokenWithVoipJoinScope")]
        [TestCase("chat", "voip", TestName = "GettingTokenWithChatVoipScopes")]
        [TestCase("chat", "chat.join", "chat.join.limited", TestName = "GettingTokenWithAllChatScopes")]
        [TestCase("voip", "voip.join", TestName = "GettingTokenWithAllVoipScopes")]
        [TestCase("chat.join", "voip.join", TestName = "GettingTokenWithChatJoinVoipJoinScopes")]
        public async Task GetTokenGeneratesTokenAndIdentityWithScopes(params string[] scopes)
        {
            CommunicationIdentityClient client = CreateClient();
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

        [Test]
        public async Task GetTokenWithNullUserShouldThrow()
        {
            try
            {
                CommunicationIdentityClient client = CreateClient();
                Response<AccessToken> accessToken = await client.GetTokenAsync(communicationUser: null, scopes: new[] { CommunicationTokenScope.Chat });
            }
            catch (NullReferenceException ex)
            {
                Assert.NotNull(ex.Message);
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("RevokeTokensAsync should have thrown an exception.");
        }

        [Test]
        public async Task GetTokenWithNullScopesShouldThrow()
        {
            try
            {
                CommunicationIdentityClient client = CreateClient();
                CommunicationUserIdentifier userIdentifier = await client.CreateUserAsync();
                Response<AccessToken> accessToken = await client.GetTokenAsync(communicationUser: userIdentifier, scopes: null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("scopes", ex.ParamName);
                return;
            }
            Assert.Fail("RevokeTokensAsync should have thrown an exception.");
        }

        [Test]
        [TestCase("chat", TestName = "CreateUserAndTokenWithChatScope")]
        [TestCase("voip", TestName = "CreateUserAndTokenWithVoIPScope")]
        [TestCase("chat.join", TestName = "CreateUserAndTokenWithChatJoinScope")]
        [TestCase("chat.join.limited", TestName = "CreateUserAndTokenWithChatJoinLimitedScope")]
        [TestCase("voip.join", TestName = "CreateUserAndTokenWithVoipJoinScope")]
        [TestCase("chat", "voip", TestName = "CreateUserAndTokenWithChatVoipScopes")]
        [TestCase("chat", "chat.join", "chat.join.limited", TestName = "CreateUserAndTokenWithAllChatScopes")]
        [TestCase("voip", "voip.join", TestName = "CreateUserAndTokenWithAllVoipScopes")]
        [TestCase("chat.join", "voip.join", TestName = "CreateUserAndTokenWithChatJoinVoipJoinScopes")]
        public async Task CreateUserAndTokenWithDifferentScopes(params string[] scopes)
        {
            CommunicationIdentityClient client = CreateClient();
            Response<CommunicationUserIdentifierAndToken> accessToken = await client.CreateUserAndTokenAsync(scopes: scopes.Select(x => new CommunicationTokenScope(x)));

            Assert.IsNotNull(accessToken.Value.AccessToken);
            Assert.IsFalse(string.IsNullOrWhiteSpace(accessToken.Value.AccessToken.Token));
            ValidateScopesIfNotSanitized();

            void ValidateScopesIfNotSanitized()
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    JwtTokenParser.JwtPayload payload = JwtTokenParser.DecodeJwtPayload(accessToken.Value.AccessToken.Token);
                    CollectionAssert.AreEquivalent(scopes, payload.Scopes);
                }
            }
        }

        [Test]
        [TestCase(MIN_VALID_EXPIRATION_TIME, TestName = "CreateUserAndTokenWithMinValidCustomExpiration")]
        [TestCase(MAX_VALID_EXPIRATION_TIME, TestName = "CreateUserAndTokenWithMaxValidCustomExpiration")]
        public async Task CreateUserAndTokenWithValidCustomExpiration(string expiresIn)
        {
            TimeSpan tokenExpiresIn = TokenCustomExpirationTimes[expiresIn];

            CommunicationIdentityClient client = CreateClient();
            Response<CommunicationUserIdentifierAndToken> accessToken = await client.CreateUserAndTokenAsync(scopes: new[] { CommunicationTokenScope.Chat }, tokenExpiresIn: tokenExpiresIn);

            Assert.IsNotNull(accessToken.Value.AccessToken);
            Assert.IsFalse(string.IsNullOrWhiteSpace(accessToken.Value.AccessToken.Token));

            if (Mode == RecordedTestMode.Live)
            {
                TimeSpan tokenTimeSpan;
                var tokenExpirationWithinAllowedDeviation = TokenExpirationWithinAllowedDeviation(tokenExpiresIn, accessToken.Value.AccessToken.ExpiresOn, TOKEN_EXPIRATION_ALLOWED_DEVIATION, out tokenTimeSpan);
                Assert.True(tokenExpirationWithinAllowedDeviation,
                    $"Token expiration is outside of allowed {TOKEN_EXPIRATION_ALLOWED_DEVIATION * 100}% deviation." +
                    $"Expected minutes: {tokenExpiresIn.TotalMinutes}, actual minutes: {tokenTimeSpan.TotalMinutes:0.##}.");
            }
        }

        [Test]
        [TestCase(MIN_INVALID_EXPIRATION_TIME, TestName = "CreateUserAndTokenWithMinInvalidCustomExpiration")]
        [TestCase(MAX_INVALID_EXPIRATION_TIME, TestName = "CreateUserAndTokenWithMaxInvalidCustomExpiration")]
        public async Task CreateUserAndTokenWithInvalidCustomExpirationShouldThrow(string expiresIn)
        {
            try
            {
                TimeSpan tokenExpiresIn = TokenCustomExpirationTimes[expiresIn];
                CommunicationIdentityClient client = CreateClient();
                Response<CommunicationUserIdentifierAndToken> accessToken = await client.CreateUserAndTokenAsync(scopes: new[] { CommunicationTokenScope.Chat }, tokenExpiresIn: tokenExpiresIn);
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail($"{nameof(CreateUserAndTokenWithInvalidCustomExpirationShouldThrow)} should have thrown an exception.");
        }

        [Test]
        public async Task CreateUserAndTokenWithOverflownExpirationShouldThrow()
        {
            try
            {
                // int.MaxValue / 20 as hours argument is used to simulate situation when subsequent flow tries to convert minutes value of the TimeSpan instance to int type and overflows
                TimeSpan tokenExpiresIn = new TimeSpan(int.MaxValue / 20, 0, 0);
                CommunicationIdentityClient client = CreateClient();
                Response<CommunicationUserIdentifierAndToken> accessToken = await client.CreateUserAndTokenAsync(scopes: new[] { CommunicationTokenScope.Chat }, tokenExpiresIn: tokenExpiresIn);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.True(ex.Message.Contains(TOKEN_EXPIRATION_OVERFLOW_MESSAGE));
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail($"{nameof(CreateUserAndTokenWithOverflownExpirationShouldThrow)} should have thrown an exception.");
        }

        [Test]
        [TestCase(MIN_VALID_EXPIRATION_TIME, TestName = "GetTokenWithMinValidCustomExpiration")]
        [TestCase(MAX_VALID_EXPIRATION_TIME, TestName = "GetTokenWithMaxValidCustomExpiration")]
        public async Task GetTokenWithValidCustomExpiration(string expiresIn)
        {
            TimeSpan tokenExpiresIn = TokenCustomExpirationTimes[expiresIn];

            CommunicationIdentityClient client = CreateClient();
            CommunicationUserIdentifier userIdentifier = await client.CreateUserAsync();
            Response<AccessToken> accessToken = await client.GetTokenAsync(communicationUser: userIdentifier, scopes: new[] { CommunicationTokenScope.VoIP }, tokenExpiresIn: tokenExpiresIn);

            Assert.IsNotNull(accessToken.Value);
            Assert.IsFalse(string.IsNullOrWhiteSpace(accessToken.Value.Token));

            if (Mode == RecordedTestMode.Live)
            {
                TimeSpan tokenTimeSpan;
                var tokenExpirationWithinAllowedDeviation = TokenExpirationWithinAllowedDeviation(tokenExpiresIn, accessToken.Value.ExpiresOn, TOKEN_EXPIRATION_ALLOWED_DEVIATION, out tokenTimeSpan);
                Assert.True(tokenExpirationWithinAllowedDeviation,
                    $"Token expiration is outside of allowed {TOKEN_EXPIRATION_ALLOWED_DEVIATION * 100}% deviation." +
                    $"Expected minutes: {tokenExpiresIn.TotalMinutes}, actual minutes: {tokenTimeSpan.TotalMinutes:0.##}.");
            }
        }

        [Test]
        [TestCase(MIN_INVALID_EXPIRATION_TIME, TestName = "GetTokenWithMinInvalidCustomExpiration")]
        [TestCase(MAX_INVALID_EXPIRATION_TIME, TestName = "GetTokenWithMaxInvalidCustomExpiration")]
        public async Task GetTokenWithInvalidCustomExpirationShouldThrow(string expiresIn)
        {
            try
            {
                TimeSpan tokenExpiresIn = TokenCustomExpirationTimes[expiresIn];
                CommunicationIdentityClient client = CreateClient();
                CommunicationUserIdentifier userIdentifier = await client.CreateUserAsync();
                Response<AccessToken> accessToken = await client.GetTokenAsync(communicationUser: userIdentifier, scopes: new[] { CommunicationTokenScope.VoIP }, tokenExpiresIn: tokenExpiresIn);
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail($"{nameof(GetTokenWithInvalidCustomExpirationShouldThrow)} should have thrown an exception.");
        }

        [Test]
        public async Task GetTokenWithOverflownExpirationShouldThrow()
        {
            try
            {
                // int.MaxValue / 20 as hours argument is used to simulate situation when subsequent flow tries to convert minutes value of the TimeSpan instance to int type and overflows
                TimeSpan tokenExpiresIn = new TimeSpan(int.MaxValue / 20, 0, 0);
                CommunicationIdentityClient client = CreateClient();
                CommunicationUserIdentifier userIdentifier = await client.CreateUserAsync();
                Response<AccessToken> accessToken = await client.GetTokenAsync(communicationUser: userIdentifier, scopes: new[] { CommunicationTokenScope.VoIP }, tokenExpiresIn: tokenExpiresIn);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.True(ex.Message.Contains(TOKEN_EXPIRATION_OVERFLOW_MESSAGE));
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail($"{nameof(GetTokenWithOverflownExpirationShouldThrow)} should have thrown an exception.");
        }

        [Test]
        public async Task DeleteUserWithNullUserShouldThrow()
        {
            try
            {
                CommunicationIdentityClient client = CreateClient();
                Response deleteResponse = await client.DeleteUserAsync(communicationUser: null);
            }
            catch (NullReferenceException ex)
            {
                Assert.NotNull(ex.Message);
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("DeleteUserAsync should have thrown an exception.");
        }

        [Test]
        public async Task RevokeTokenWithNullUserShouldThrow()
        {
            try
            {
                CommunicationIdentityClient client = CreateClient();
                Response deleteResponse = await client.RevokeTokensAsync(communicationUser: null);
            }
            catch (NullReferenceException ex)
            {
                Assert.NotNull(ex.Message);
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("RevokeTokensAsync should have thrown an exception.");
        }

        [Test]
        public async Task GetTokenForTeamsUserWithValidParameters()
        {
            if (TestEnvironment.ShouldIgnoreIdentityExchangeTokenTest)
            {
                Assert.Pass("Ignore exchange teams token test if flag is enabled.");
            }

            CommunicationIdentityClient client = CreateClient();
            Response<AccessToken> tokenResponse = await client.GetTokenForTeamsUserAsync(CTEOptions);
            Assert.IsNotNull(tokenResponse.Value);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tokenResponse.Value.Token));
        }

        [Test]
        [TestCase(true, false, false, "token", TestName = "GetTokenForTeamsUserWithNullTokenShouldThrow")]
        [TestCase(false, true, false, "appId", TestName = "GetTokenForTeamsUserWithNullAppIdShouldThrow")]
        [TestCase(false, false, true, "userId", TestName = "GetTokenForTeamsUserWithNullUserIdShouldThrow")]
        [TestCase(true, true, true, "token", TestName = "GetTokenForTeamsUserWithNullParamsShouldThrow")]
        public async Task GetTokenForTeamsUserWithNullParamsShouldThrow(bool isTokenNull, bool isAppIdNull, bool isUserIdNull, string paramName)
        {
            var teamsUserAadToken = isTokenNull ? null : CTEOptions.TeamsUserAadToken;
            var clientId = isAppIdNull ? null : CTEOptions.ClientId;
            var userObjectId = isUserIdNull ? null : CTEOptions.UserObjectId;
            try
            {
                CommunicationIdentityClient client = CreateClient();
                Response<AccessToken> tokenResponse = await client.GetTokenForTeamsUserAsync(new GetTokenForTeamsUserOptions(teamsUserAadToken, clientId, userObjectId));
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(paramName, ex.ParamName);
                return;
            }
            Assert.Fail("An exception should have been thrown.");
        }

        [Test]
        [TestCase("", TestName = "GetTokenForTeamsUserWithEmptyTokenShouldThrow")]
        [TestCase("invalid", TestName = "GetTokenForTeamsUserWithInvalidTokenShouldThrow")]
        public async Task GetTokenForTeamsUserWithInvalidTokenShouldThrow(string token)
        {
            try
            {
                CommunicationIdentityClient client = CreateClient();
                Response<AccessToken> tokenResponse = await client.GetTokenForTeamsUserAsync(new GetTokenForTeamsUserOptions(token, CTEOptions.ClientId, CTEOptions.UserObjectId));
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.True(ex.Message.Contains("401"));
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("An exception should have been thrown.");
        }

        [Test]
        public async Task GetTokenForTeamsUserWithExpiredTokenShouldThrow()
        {
            try
            {
                CommunicationIdentityClient client = CreateClient();
                Response<AccessToken> tokenResponse = await client.GetTokenForTeamsUserAsync(new GetTokenForTeamsUserOptions(TestEnvironment.CommunicationExpiredTeamsToken, CTEOptions.ClientId, CTEOptions.UserObjectId));
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.True(ex.Message.Contains("401"));
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("An exception should have been thrown.");
        }

        [Test]
        [TestCase("", TestName = "GetTokenForTeamsUserWithEmptyClientIdShouldThrow")]
        [TestCase("invalid", TestName = "GetTokenForTeamsUserWithInvalidClientIdShouldThrow")]
        public async Task GetTokenForTeamsUserWithInvalidClientIdShouldThrow(string clientId)
        {
            if (TestEnvironment.ShouldIgnoreIdentityExchangeTokenTest)
            {
                Assert.Pass("Ignore exchange teams token test if flag is enabled.");
            }

            try
            {
                CommunicationIdentityClient client = CreateClient();
                Response<AccessToken> tokenResponse = await client.GetTokenForTeamsUserAsync(new GetTokenForTeamsUserOptions(CTEOptions.TeamsUserAadToken, clientId, CTEOptions.UserObjectId));
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.True(ex.Message.Contains("400"));
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("An exception should have been thrown.");
        }

        [Test]
        public async Task GetTokenForTeamsUserWithWrongClientIdShouldThrow()
        {
            if (TestEnvironment.ShouldIgnoreIdentityExchangeTokenTest)
            {
                Assert.Pass("Ignore exchange teams token test if flag is enabled.");
            }

            try
            {
                CommunicationIdentityClient client = CreateClient();
                Response<AccessToken> tokenResponse = await client.GetTokenForTeamsUserAsync(new GetTokenForTeamsUserOptions(CTEOptions.TeamsUserAadToken, CTEOptions.UserObjectId, CTEOptions.UserObjectId));
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.True(ex.Message.Contains("400"));
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("An exception should have been thrown.");
        }

        [Test]
        [TestCase("", TestName = "GetTokenForTeamsUserWithEmptyUserObjectIdShouldThrow")]
        [TestCase("invalid", TestName = "GetTokenForTeamsUserWithInvalidUserObjectIdShouldThrow")]
        public async Task GetTokenForTeamsUserWithInvalidUserObjectIdShouldThrow(string userObjectId)
        {
            if (TestEnvironment.ShouldIgnoreIdentityExchangeTokenTest)
            {
                Assert.Pass("Ignore exchange teams token test if flag is enabled.");
            }

            try
            {
                CommunicationIdentityClient client = CreateClient();
                Response<AccessToken> tokenResponse = await client.GetTokenForTeamsUserAsync(new GetTokenForTeamsUserOptions(CTEOptions.TeamsUserAadToken, CTEOptions.ClientId, userObjectId));
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.True(ex.Message.Contains("400"));
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("An exception should have been thrown.");
        }

        [Test]
        public async Task GetTokenForTeamsUserWithWrongUserObjectIdShouldThrow()
        {
            if (TestEnvironment.ShouldIgnoreIdentityExchangeTokenTest)
            {
                Assert.Pass("Ignore exchange teams token test if flag is enabled.");
            }

            try
            {
                CommunicationIdentityClient client = CreateClient();
                Response<AccessToken> tokenResponse = await client.GetTokenForTeamsUserAsync(new GetTokenForTeamsUserOptions(CTEOptions.TeamsUserAadToken, CTEOptions.ClientId, CTEOptions.ClientId));
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.True(ex.Message.Contains("400"));
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("An exception should have been thrown.");
        }

        [Test]
        [TestCase(ServiceVersion.V2021_03_07, TestName = "CreateIdentityWithServiceVersion_V2021_03_07")]
        [TestCase(ServiceVersion.V2022_06_01, TestName = "CreateIdentityWithServiceVersion_V2022_06_01")]
        [TestCase(ServiceVersion.V2022_10_01, TestName = "CreateIdentityWithServiceVersion_V2022_10_01")]
        [TestCase(ServiceVersion.V2023_10_01, TestName = "CreateIdentityWithServiceVersion_V2023_10_01")]
        public async Task CreateIdentityWithDifferentServiceVersions(ServiceVersion version)
        {
            try
            {
                CommunicationIdentityClient client = CreateClient(default, version);
                CommunicationUserIdentifier userResponse = await client.CreateUserAsync();
                Assert.IsNotNull(userResponse);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public void CreateClientWithIncorrectServiceVersionShouldThrow()
        {
            try
            {
                ServiceVersion invalidVersion = (ServiceVersion)(-1);
                CommunicationIdentityClient client = CreateClient(default, invalidVersion);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.NotNull(ex.Message);
                return;
            }
            Assert.Fail("An exception should have been thrown.");
        }

        private bool TokenExpirationWithinAllowedDeviation(TimeSpan expectedTokenExpiration, DateTimeOffset tokenExpiresIn, double allowedDeviation, out TimeSpan tokenTimeSpan)
        {
            tokenTimeSpan = tokenExpiresIn - DateTimeOffset.UtcNow;
            var tokenSeconds = tokenTimeSpan.TotalSeconds;
            var expectedSeconds = expectedTokenExpiration.TotalSeconds;
            var timeDiff = Math.Abs(expectedSeconds - tokenSeconds);
            var allowedTimeDiff = expectedSeconds * allowedDeviation;
            return timeDiff < allowedTimeDiff;
        }
    }
}
