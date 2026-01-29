// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
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
                Assert.That(context.Scopes, Is.EqualTo(scopes));
                Assert.That(token, Is.EqualTo(ctx));
                return staticToken;
            };
            getTokenAsync = async (context, token) =>
            {
                Assert.That(context.Scopes, Is.EqualTo(scopes));
                Assert.That(token, Is.EqualTo(ctx));
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

            Assert.That(actualToken.Token, Is.EqualTo(expectedToken));
            Assert.That(actualToken.ExpiresOn, Is.EqualTo(expires));
        }

        [TestCaseSource(nameof(Credentials))]
        public void CreateGetTokenCallsDelegate(TokenCredential credential)
        {
            AccessToken actualToken = credential.GetToken(new TokenRequestContext(scopes), ctx);

            Assert.That(actualToken.Token, Is.EqualTo(expectedToken));
            Assert.That(actualToken.ExpiresOn, Is.EqualTo(expires));
        }

        [Test]
        public void CreateTokenOptionsWithValidScopes()
        {
            // Test with ReadOnlyMemory<string> scopes
            var scopesMemory = new ReadOnlyMemory<string>(new string[] { "scope1", "scope2" });
            var properties = new Dictionary<string, object>
            {
                [GetTokenOptions.ScopesPropertyName] = scopesMemory,
                ["additionalProperty"] = "value"
            };

            var credential = DelegatedTokenCredential.Create(getToken);
            var result = credential.CreateTokenOptions(properties);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Properties[GetTokenOptions.ScopesPropertyName], Is.EqualTo(scopesMemory));
            Assert.That(result.Properties["additionalProperty"], Is.EqualTo("value"));
        }

        [Test]
        public void CreateTokenOptionsWithoutScopes()
        {
            // Test without scopes property
            var properties = new Dictionary<string, object>
            {
                ["additionalProperty"] = "value"
            };

            var credential = DelegatedTokenCredential.Create(getToken);
            var result = credential.CreateTokenOptions(properties);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void CreateTokenOptionsCanCreateValidTokenRequestContext()
        {
            // Test that the created GetTokenOptions can be used to create TokenRequestContext
            var scopesMemory = new ReadOnlyMemory<string>(new string[] { "scope1", "scope2" });
            var properties = new Dictionary<string, object>
            {
                [GetTokenOptions.ScopesPropertyName] = scopesMemory
            };

            var credential = DelegatedTokenCredential.Create(getToken);
            var tokenOptions = credential.CreateTokenOptions(properties);

            Assert.That(tokenOptions, Is.Not.Null);

            // This should not throw since we have valid scopes
            Assert.DoesNotThrow(() =>
            {
                var context = TokenRequestContext.FromGetTokenOptions(tokenOptions);
                Assert.That(context.Scopes, Is.EqualTo(scopesMemory.ToArray()));
            });
        }
    }
}
