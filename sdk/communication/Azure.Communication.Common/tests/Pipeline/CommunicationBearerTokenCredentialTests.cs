// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Communication.Pipeline
{
    public class CommunicationBearerTokenCredentialTests
    {
        private const string SampleToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjMyNTAzNjgwMDAwfQ.9i7FNNHHJT8cOzo-yrAUJyBSfJ-tPPk2emcHavOEpWc";
        private const long SampleTokenExpiry = 32503680000;
        private const string ExpiredToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjEwMH0.1h_scYkNp-G98-O4cW6KvfJZwiz54uJMyeDACE4nypg";
        private static string FetchTokenForUserFromMyServer(string userId, CancellationToken cancellationToken) => SampleToken;
        private static ValueTask<string> FetchTokenForUserFromMyServerAsync(string userId, CancellationToken cancellationToken) => new ValueTask<string>(SampleToken);

        public TokenRequestContext MockTokenRequestContext()
        {
            var resource = "the resource value";
            return new TokenRequestContext(new[] { resource });
        }

        [Test]
        public async Task CommunicationBearerTokenCredential_CreateStaticToken()
        {
            var token = ExpiredToken;

            using var tokenCredential = new CommunicationTokenCredential(token);
            var communicationBearerTokenCredential = new CommunicationBearerTokenCredential(tokenCredential);

            await communicationBearerTokenCredential.GetTokenAsync(MockTokenRequestContext(), CancellationToken.None);
        }

        [Test]
        public async Task CommunicationBearerTokenCredential_CreateRefreshableWithoutInitialToken()
        {
            var tokenCredential = new CommunicationTokenCredential(
                new CommunicationTokenRefreshOptions(
                refreshProactively: true, // Indicates if the token should be proactively refreshed in the background or only on-demand
                tokenRefresher: cancellationToken => FetchTokenForUserFromMyServer("bob@contoso.com", cancellationToken),
                asyncTokenRefresher: cancellationToken => FetchTokenForUserFromMyServerAsync("bob@contoso.com", cancellationToken))
            );
            var communicationBearerTokenCredential = new CommunicationBearerTokenCredential(tokenCredential);

            await communicationBearerTokenCredential.GetTokenAsync(MockTokenRequestContext(), CancellationToken.None);
        }

        [Test]
        public async Task CommunicationBearerTokenCredential_CreateRefreshableWithInitialToken()
        {
            var initialToken = ExpiredToken;
            var tokenCredential = new CommunicationTokenCredential(
                new CommunicationTokenRefreshOptions(
                refreshProactively: true, // Indicates if the token should be proactively refreshed in the background or only on-demand
                tokenRefresher: cancellationToken => FetchTokenForUserFromMyServer("bob@contoso.com", cancellationToken),
                asyncTokenRefresher: cancellationToken => FetchTokenForUserFromMyServerAsync("bob@contoso.com", cancellationToken),
                initialToken)
            );
            var communicationBearerTokenCredential = new CommunicationBearerTokenCredential(tokenCredential);

            await communicationBearerTokenCredential.GetTokenAsync(MockTokenRequestContext(), CancellationToken.None);
        }

        [Test]
        public async Task CommunicationBearerTokenCredential_DecodesToken()
        {
            var initialToken = SampleToken;
            var tokenCredential = new CommunicationTokenCredential(initialToken);
            var communicationBearerTokenCredential = new CommunicationBearerTokenCredential(tokenCredential);

            var accessToken = await communicationBearerTokenCredential.GetTokenAsync(MockTokenRequestContext(), CancellationToken.None);

            Assert.AreEqual(initialToken, accessToken.Token);
            Assert.AreEqual(SampleTokenExpiry, accessToken.ExpiresOn.ToUnixTimeSeconds());
        }

        [Test]
        public void CommunicationBearerTokenCredential_StaticTokenReturnsExpiredToken()
        {
            var tokenCredential = new CommunicationTokenCredential(ExpiredToken);
            var communicationBearerTokenCredential = new CommunicationBearerTokenCredential(tokenCredential);

            var accessToken = communicationBearerTokenCredential.GetToken(MockTokenRequestContext(), CancellationToken.None);
            Assert.AreEqual(ExpiredToken, accessToken.Token);
        }

        [Test]
        public async Task CommunicationBearerTokenCredential_StaticTokenAsyncReturnsExpiredToken()
        {
            var tokenCredential = new CommunicationTokenCredential(ExpiredToken);
            var communicationBearerTokenCredential = new CommunicationBearerTokenCredential(tokenCredential);

            var accessToken = await communicationBearerTokenCredential.GetTokenAsync(MockTokenRequestContext(), CancellationToken.None);
            Assert.AreEqual(ExpiredToken, accessToken.Token);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CommunicationBearerTokenCredential_PassesCancelToken(bool refreshProactively)
        {
            var cancellationToken = new CancellationToken();
            CancellationToken? actualCancellationToken = null;

            var tokenCredential = new CommunicationTokenCredential(
                new CommunicationTokenRefreshOptions(
                    refreshProactively,
                    RefreshToken,
                    c => new ValueTask<string>(RefreshToken(c)),
                    ExpiredToken)
                );

            var communicationBearerTokenCredential = new CommunicationBearerTokenCredential(tokenCredential);
            var accessToken = communicationBearerTokenCredential.GetToken(MockTokenRequestContext(), cancellationToken);
            Assert.AreEqual(cancellationToken.GetHashCode(), actualCancellationToken.GetHashCode());

            string RefreshToken(CancellationToken token)
            {
                actualCancellationToken = token;
                return SampleToken;
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CommunicationBearerTokenCredential_PassesAsyncCancelToken(bool refreshProactively)
        {
            var cancellationToken = new CancellationToken();
            CancellationToken? actualCancellationToken = null;

            var tokenCredential = new CommunicationTokenCredential(
                new CommunicationTokenRefreshOptions(
                    refreshProactively,
                    RefreshToken,
                    c => new ValueTask<string>(RefreshToken(c)),
                    ExpiredToken)
                );

            var communicationBearerTokenCredential = new CommunicationBearerTokenCredential(tokenCredential);
            var accessToken = await communicationBearerTokenCredential.GetTokenAsync(MockTokenRequestContext(), cancellationToken);
            Assert.AreEqual(cancellationToken.GetHashCode(), actualCancellationToken.GetHashCode());

            string RefreshToken(CancellationToken token)
            {
                actualCancellationToken = token;
                return SampleToken;
            }
        }
    }
}
