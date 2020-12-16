// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Communication.Identity
{
    public class CommunicationTokenCredentialTest
    {
        private const string SampleToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjMyNTAzNjgwMDAwfQ.9i7FNNHHJT8cOzo-yrAUJyBSfJ-tPPk2emcHavOEpWc";
        private const long SampleTokenExpiry = 32503680000;
        private const string ExpiredToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjEwMH0.1h_scYkNp-G98-O4cW6KvfJZwiz54uJMyeDACE4nypg";

        private static AutoRefreshTokenCredential CreateTokenCredentialWithTestClock(
            TestClock testClock,
            bool refreshProactively,
            Func<CancellationToken, string> tokenRefresher,
            Func<CancellationToken, ValueTask<string>>? asyncTokenRefresher = null,
            string? initialToken = null)
        {
            return new AutoRefreshTokenCredential(
                tokenRefresher,
                asyncTokenRefresher ?? (cancellationToken => new ValueTask<string>(tokenRefresher(cancellationToken))),
                initialToken,
                refreshProactively,
                testClock.Schedule,
                () => testClock.UtcNow);
        }

        [Test]
        public async Task CommunicationTokenCredential_CreateStaticToken()
        {
            var token = ExpiredToken;
            #region Snippet:CommunicationTokenCredential_CreateWithStaticToken
            //@@string token = Environment.GetEnvironmentVariable("COMMUNICATION_SERVICES_USER_TOKEN");
            using var tokenCredential = new CommunicationTokenCredential(token);
            #endregion
            await tokenCredential.GetTokenAsync();
        }

        [Test]
        public async Task CommunicationTokenCredential_CreateRefreshableWithoutInitialToken()
        {
            #region Snippet:CommunicationTokenCredential_CreateRefreshableWithoutInitialToken
            using var tokenCredential = new CommunicationTokenCredential(
                new CommunicationTokenRefreshOptions(
                    refreshProactively: true, // Indicates if the token should be proactively refreshed in the background or only on-demand
                    tokenRefresher: cancellationToken => FetchTokenForUserFromMyServer("bob@contoso.com", cancellationToken),
                    asyncTokenRefresher: cancellationToken => FetchTokenForUserFromMyServerAsync("bob@contoso.com", cancellationToken)
                    )
                );
            #endregion
            await tokenCredential.GetTokenAsync();
        }

        [Test]
        public async Task CommunicationTokenCredential_CreateRefreshableWithInitialToken()
        {
            var initialToken = ExpiredToken;
            #region Snippet:CommunicationTokenCredential_CreateRefreshableWithInitialToken
            //@@string initialToken = Environment.GetEnvironmentVariable("COMMUNICATION_SERVICES_USER_TOKEN");
            using var tokenCredential = new CommunicationTokenCredential(
                new CommunicationTokenRefreshOptions(
                    refreshProactively: true, // Indicates if the token should be proactively refreshed in the background or only on-demand
                    tokenRefresher: cancellationToken => FetchTokenForUserFromMyServer("bob@contoso.com", cancellationToken),
                    asyncTokenRefresher: cancellationToken => FetchTokenForUserFromMyServerAsync("bob@contoso.com", cancellationToken),
                    initialToken)
                );
            #endregion
            await tokenCredential.GetTokenAsync();
        }

#pragma warning disable IDE0060 // Remove unused parameter
        private static string FetchTokenForUserFromMyServer(string userId, CancellationToken cancellationToken) => SampleToken;

        private static ValueTask<string> FetchTokenForUserFromMyServerAsync(string userId, CancellationToken cancellationToken) => new ValueTask<string>(SampleToken);
#pragma warning restore IDE0060 // Remove unused parameter

        [Test]
        [TestCase(SampleToken, SampleTokenExpiry)]
        public async Task CommunicationTokenCredential_DecodesToken(string token, long expectedExpiryUnixTimeSeconds)
        {
            using var tokenCredential = new CommunicationTokenCredential(token);
            AccessToken accessToken = await tokenCredential.GetTokenAsync();

            Assert.AreEqual(token, accessToken.Token);
            Assert.AreEqual(expectedExpiryUnixTimeSeconds, accessToken.ExpiresOn.ToUnixTimeSeconds());
        }

        [Test]
        [TestCase("foo")]
        [TestCase("foo.bar")]
        [TestCase("foo.bar.foobar")]
        public void CommunicationTokenCredential_ThrowsIfInvalidToken(string token)
            => Assert.Throws<FormatException>(() => new CommunicationTokenCredential(token));

        [Test]
        public void CommunicationTokenCredential_ThrowsIfTokenIsNull()
            => Assert.Throws<ArgumentNullException>(() => new CommunicationTokenCredential(token: null!));

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public async Task CommunicationTokenCredential_StaticToken_ReturnsExpiredToken(bool async)
        {
            using var tokenCredential = new CommunicationTokenCredential(ExpiredToken);

            var token = async ? await tokenCredential.GetTokenAsync() : tokenCredential.GetToken();
            Assert.AreEqual(ExpiredToken, token.Token);
        }

        [Test]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public async Task CommunicationTokenCredential_PassesCancellationToken(bool refreshProactively, bool async)
        {
            var cancellationToken = new CancellationToken();
            CancellationToken? actualCancellationToken = null;

            using var tokenCredential = new CommunicationTokenCredential(
                new CommunicationTokenRefreshOptions(
                    refreshProactively,
                    RefreshToken,
                    c => new ValueTask<string>(RefreshToken(c)),
                    ExpiredToken)
                );

            var token = async ? await tokenCredential.GetTokenAsync(cancellationToken) : tokenCredential.GetToken(cancellationToken);
            Assert.AreEqual(cancellationToken, actualCancellationToken);

            string RefreshToken(CancellationToken token)
            {
                actualCancellationToken = token;
                return SampleToken;
            }
        }

        [Test]
        public void CommunicationTokenCredential_RefreshsTokenProactively_ImmediateWhenExpired()
        {
            var refreshCallCount = 0;

            var testClock = new TestClock();
            using var tokenCredential = CreateTokenCredentialWithTestClock(
                testClock,
                true,
                RefreshToken,
                _ => throw new NotImplementedException(),
                ExpiredToken);

            Assert.AreEqual(1, testClock.ScheduledActions.Count());
            testClock.Tick();
            Assert.AreEqual(1, refreshCallCount);

            string RefreshToken(CancellationToken _)
            {
                refreshCallCount++;
                return SampleToken;
            }
        }

        [Test]
        [TestCase(SampleToken, SampleTokenExpiry, false)]
        [TestCase(SampleToken, SampleTokenExpiry, true)]
        public async Task GetTokenSeries_RefreshTokenOnDemandIfNeeded(string token, long expectedExpiryUnixTimeSeconds, bool async)
        {
            var testClock = new TestClock();
            using var tokenCredential = CreateTokenCredentialWithTestClock(
                testClock,
                false,
                _ => token,
                _ => new ValueTask<string>(token),
                initialToken: ExpiredToken);

            Assert.AreEqual(0, testClock.ScheduledActions.Count());

            AccessToken accessToken = async
                ? await tokenCredential.GetTokenAsync()
                : tokenCredential.GetToken();

            Assert.AreEqual(token, accessToken.Token);
            Assert.AreEqual(expectedExpiryUnixTimeSeconds, accessToken.ExpiresOn.ToUnixTimeSeconds());
        }

        [Test]
        [TestCase(SampleToken, false, false)]
        [TestCase(SampleToken, false, true)]
        [TestCase(SampleToken, true, false)]
        [TestCase(SampleToken, true, true)]
        public void GetTokenSeries_Throws_IfTokenRequestedWhileDisposed(string token, bool refreshProactively, bool async)
        {
            using var tokenCredential = new CommunicationTokenCredential(
                new CommunicationTokenRefreshOptions(
                    refreshProactively,
                    _ => token,
                    _ => new ValueTask<string>(token))
                );

            tokenCredential.Dispose();

            if (async)
                Assert.ThrowsAsync<ObjectDisposedException>(async () => await tokenCredential.GetTokenAsync());
            else
                Assert.Throws<ObjectDisposedException>(() => tokenCredential.GetToken());
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void GetTokenSeries_StaticToken_Throws_IfTokenRequestedWhileDisposed(bool async)
        {
            using var tokenCredential = new CommunicationTokenCredential(SampleToken);

            tokenCredential.Dispose();

            if (async)
                Assert.ThrowsAsync<ObjectDisposedException>(async () => await tokenCredential.GetTokenAsync());
            else
                Assert.Throws<ObjectDisposedException>(() => tokenCredential.GetToken());
        }

        [Test]
        public void Dispose_CancelsTimer()
        {
            var testClock = new TestClock();
            using var tokenCredential = CreateTokenCredentialWithTestClock(
                testClock,
                true,
                _ => SampleToken,
                _ => new ValueTask<string>(SampleToken));

            Assert.AreEqual(1, testClock.ScheduledActions.Count());
            tokenCredential.Dispose();

            Assert.AreEqual(0, testClock.ScheduledActions.Count());
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CurrentTokenExpiringSoon_TokenRefreshed(bool inCriticalExpiryWindow)
        {
            var tokenValidForMinutes = inCriticalExpiryWindow
                ? ThreadSafeRefreshableAccessTokenCache.OnDemandRefreshIntervalInMinutes / 2
                : ThreadSafeRefreshableAccessTokenCache.ProactiveRefreshIntervalInMinutes * 2;

            var testClock = new TestClock();
            var initialToken = GenerateTokenValidForMinutes(testClock.UtcNow, tokenValidForMinutes);
            var newToken = GenerateTokenValidForMinutes(testClock.UtcNow, 55);
            var refreshCallCount = 0;

            using var tokenCredential = CreateTokenCredentialWithTestClock(
                testClock,
                refreshProactively: true,
                RefreshToken,
                _ => throw new NotImplementedException(),
                initialToken);

            var token = tokenCredential.GetToken();

            testClock.Tick(TimeSpan.FromMinutes(tokenValidForMinutes - ThreadSafeRefreshableAccessTokenCache.ProactiveRefreshIntervalInMinutes + 0.5));

            Assert.AreEqual(1, refreshCallCount);

            var afterRefreshToken = tokenCredential.GetToken();

            Assert.AreEqual(inCriticalExpiryWindow ? newToken : initialToken, token.Token);
            Assert.AreEqual(newToken, afterRefreshToken.Token);

            string RefreshToken(CancellationToken _)
            {
                refreshCallCount++;
                return newToken;
            }
        }

        [Test]
        public void CurrentTokenExpired_TokenRefreshFails_Throws()
        {
            var expiredToken = GenerateTokenValidForMinutes(DateTimeOffset.UtcNow, -10);

            using var tokenCredential = new CommunicationTokenCredential(
                new CommunicationTokenRefreshOptions(
                    refreshProactively: true,
                    RefreshToken,
                    _ => throw new NotImplementedException(),
                    expiredToken)
                );

            Assert.Throws<ArithmeticException>(() => tokenCredential.GetToken());

            string RefreshToken(CancellationToken _) => throw new ArithmeticException("Refresh token failed");
        }

        [Test]
        public void ProactiveRefreshingEnabled_KeepsSchedulingNewTimers()
        {
            var testClock = new TestClock();
            var twentyMinToken = GenerateTokenValidForMinutes(testClock.UtcNow, 20);

            using var tokenCredential = CreateTokenCredentialWithTestClock(
                testClock,
                refreshProactively: true,
                _ => GenerateTokenValidForMinutes(testClock.UtcNow, 20),
                _ => throw new NotImplementedException(),
                twentyMinToken);

            Assert.AreEqual(1, testClock.ScheduledActions.Count());
            var firstTimer = testClock.ScheduledActions.First();
            // go into soon to expire window
            testClock.Tick(TimeSpan.FromMinutes(20 - ThreadSafeRefreshableAccessTokenCache.ProactiveRefreshIntervalInMinutes + 0.5));

            Assert.AreEqual(1, testClock.ScheduledActions.Count());
            var secondTimer = testClock.ScheduledActions.First();
            Assert.AreNotEqual(firstTimer, secondTimer);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public async Task GetTokenSeries_CallsRefreshTokenOnlyOnce(bool async)
        {
            var refreshCallCount = 0;
            var testClock = new TestClock();
            var twentyMinToken = GenerateTokenValidForMinutes(testClock.UtcNow, 20);

            using var tokenCredential = CreateTokenCredentialWithTestClock(
                testClock,
                refreshProactively: true,
                RefreshToken,
                _ => throw new NotImplementedException(),
                twentyMinToken);

            // go into soon to expire window
            testClock.Tick(TimeSpan.FromMinutes(20 - ThreadSafeRefreshableAccessTokenCache.ProactiveRefreshIntervalInMinutes + 0.5));

            for (var i = 0; i < 10; i++)
            {
                if (async)
                    await tokenCredential.GetTokenAsync();
                else
                    tokenCredential.GetToken();
            }

            Assert.AreEqual(1, refreshCallCount);

            string RefreshToken(CancellationToken _)
            {
                refreshCallCount++;
                return GenerateTokenValidForMinutes(testClock.UtcNow, 20);
            }
        }

        private string GenerateTokenValidForMinutes(DateTimeOffset utcNow, int minutes)
        {
            var expiresOn = utcNow.AddMinutes(minutes).ToUnixTimeSeconds();
            var tokenString = $"{{\"exp\": {expiresOn}}}";
            var base64Token = Convert.ToBase64String(Encoding.ASCII.GetBytes(tokenString));
            return $"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.{ base64Token}.adM-ddBZZlQ1WlN3pdPBOF5G4Wh9iZpxNP_fSvpF4cWs";
        }
    }
}
