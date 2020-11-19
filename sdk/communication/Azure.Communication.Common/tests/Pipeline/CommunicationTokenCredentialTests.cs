// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Communication.Pipeline
{
    public class CommunicationTokenCredentialTests
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
        public async Task CommunicationTokenCredential_CreateStaticToken()
        {
            var token = ExpiredToken;

            using var userCredential = new CommunicationUserCredential(token);
            var communicationTokenCredential = new CommunicationTokenCredential(userCredential);

            await communicationTokenCredential.GetTokenAsync(MockTokenRequestContext(), CancellationToken.None);
        }

        [Test]
        public async Task CommunicationTokenCredential_CreateRefreshableWithoutInitialToken()
        {
            var userCredential = new CommunicationUserCredential(
                refreshProactively: true, // Indicates if the token should be proactively refreshed in the background or only on-demand
                tokenRefresher: cancellationToken => FetchTokenForUserFromMyServer("bob@contoso.com", cancellationToken),
                asyncTokenRefresher: cancellationToken => FetchTokenForUserFromMyServerAsync("bob@contoso.com", cancellationToken));
            var communicationTokenCredential = new CommunicationTokenCredential(userCredential);

            await communicationTokenCredential.GetTokenAsync(MockTokenRequestContext(), CancellationToken.None);
        }

        [Test]
        public async Task CommunicationTokenCredential_CreateRefreshableWithInitialToken()
        {
            var initialToken = ExpiredToken;
            var userCredential = new CommunicationUserCredential(
                refreshProactively: true, // Indicates if the token should be proactively refreshed in the background or only on-demand
                tokenRefresher: cancellationToken => FetchTokenForUserFromMyServer("bob@contoso.com", cancellationToken),
                asyncTokenRefresher: cancellationToken => FetchTokenForUserFromMyServerAsync("bob@contoso.com", cancellationToken),
                initialToken);
            var communicationTokenCredential = new CommunicationTokenCredential(userCredential);

            await communicationTokenCredential.GetTokenAsync(MockTokenRequestContext(), CancellationToken.None);
        }

        [Test]
        public async Task CommunicationTokenCredential_DecodesToken()
        {
            var initialToken = SampleToken;
            var userCredential = new CommunicationUserCredential(initialToken);
            var communicationTokenCredential = new CommunicationTokenCredential(userCredential);

            var accessToken = await communicationTokenCredential.GetTokenAsync(MockTokenRequestContext(), CancellationToken.None);

            Assert.AreEqual(initialToken, accessToken.Token);
            Assert.AreEqual(SampleTokenExpiry, accessToken.ExpiresOn.ToUnixTimeSeconds());
        }

        [Test]
        public void CommunicationTokenCredential_StaticTokenReturnsExpiredToken()
        {
            var userCredential = new CommunicationUserCredential(ExpiredToken);
            var communicationTokenCredential = new CommunicationTokenCredential(userCredential);

            var accessToken = communicationTokenCredential.GetToken(MockTokenRequestContext(), CancellationToken.None);
            Assert.AreEqual(ExpiredToken, accessToken.Token);
        }

        [Test]
        public async Task CommunicationTokenCredential_StaticTokenAsyncReturnsExpiredToken()
        {
            var userCredential = new CommunicationUserCredential(ExpiredToken);
            var communicationTokenCredential = new CommunicationTokenCredential(userCredential);

            var accessToken = await communicationTokenCredential.GetTokenAsync(MockTokenRequestContext(), CancellationToken.None);
            Assert.AreEqual(ExpiredToken, accessToken.Token);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CommunicationTokenCredential_PassesCancelToken(bool refreshProactively)
        {
            var cancellationToken = new CancellationToken();
            CancellationToken? actualCancellationToken = null;

            var userCredential = new CommunicationUserCredential(
                refreshProactively,
                RefreshToken,
                c => new ValueTask<string>(RefreshToken(c)),
                ExpiredToken);

            var communicationTokenCredential = new CommunicationTokenCredential(userCredential);
            var accessToken = communicationTokenCredential.GetToken(MockTokenRequestContext(), cancellationToken);
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
        public async Task CommunicationTokenCredential_PassesAsyncCancelToken(bool refreshProactively)
        {
            var cancellationToken = new CancellationToken();
            CancellationToken? actualCancellationToken = null;

            var userCredential = new CommunicationUserCredential(
                refreshProactively,
                RefreshToken,
                c => new ValueTask<string>(RefreshToken(c)),
                ExpiredToken);

            var communicationTokenCredential = new CommunicationTokenCredential(userCredential);
            var accessToken = await communicationTokenCredential.GetTokenAsync(MockTokenRequestContext(), cancellationToken);
            Assert.AreEqual(cancellationToken.GetHashCode(), actualCancellationToken.GetHashCode());

            string RefreshToken(CancellationToken token)
            {
                actualCancellationToken = token;
                return SampleToken;
            }
        }
    }
}
