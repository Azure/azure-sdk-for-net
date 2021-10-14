﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class DelegatedTokenCredentialTests
    {
        private static string[] scopes = { "https://default.mock.auth.scope/.default" };
        private static CancellationToken ctx = new CancellationTokenSource(TimeSpan.FromMinutes(5)).Token;
        private static string expectedToken = "token";
        private static DateTimeOffset expires = DateTimeOffset.UtcNow;
        private static AccessToken staticToken;
        private static Func<TokenRequestContext, CancellationToken, AccessToken> getToken;
        private static Func<TokenRequestContext, CancellationToken, ValueTask<AccessToken>> getTokenAsync;

        private static IEnumerable<object[]> Credentials()
        {
            staticToken = new AccessToken(expectedToken, expires);
            getToken = (context, token) =>
            {
                Assert.AreEqual(scopes, context.Scopes);
                Assert.AreEqual(ctx, token);
                return staticToken;
            };
            getTokenAsync = async (context, token) =>
            {
                Assert.AreEqual(scopes, context.Scopes);
                Assert.AreEqual(ctx, token);
                await Task.Yield();
                return staticToken;
            };
            yield return new object[] { DelegatedTokenCredential.Create(getToken) };
            yield return new object[] { DelegatedTokenCredential.Create(getToken, getTokenAsync) };
        }

        [TestCaseSource(nameof(Credentials))]
        public async Task CreateGetTokenAsyncCallsDelegate(TokenCredential credential)
        {
            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(scopes), ctx);

            Assert.AreEqual(expectedToken, actualToken.Token);
            Assert.AreEqual(expires, actualToken.ExpiresOn);
        }

        [TestCaseSource(nameof(Credentials))]
        public void CreateGetTokenCallsDelegate(TokenCredential credential)
        {
            AccessToken actualToken = credential.GetToken(new TokenRequestContext(scopes), ctx);

            Assert.AreEqual(expectedToken, actualToken.Token);
            Assert.AreEqual(expires, actualToken.ExpiresOn);
        }
    }
}
