// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.ApiKey
{
    /// <summary>
    /// Execution tests for ApiKeyCredential support in ConfigurableCredential.
    /// Validates that the key set via IConfiguration is the key returned by GetToken/GetTokenAsync.
    /// </summary>
    public class ApiKeyCredentialTests : ClientTestBase
    {
        public ApiKeyCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        private static ConfigurableCredential CreateApiKeyCredential(string key)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["MyClient:Credential:CredentialSource"] = "ApiKey",
                    ["MyClient:Credential:Key"] = key,
                })
                .Build();

            IConfigurationSection section = config.GetSection("MyClient:Credential");
            var options = new DefaultAzureCredentialOptions(new CredentialSettings(section), section);
            return new ConfigurableCredential(options);
        }

        [Test]
        public async Task GetTokenAsync_ReturnsConfiguredKey()
        {
            const string expectedKey = "test-api-key-async-12345";
            var credential = CreateApiKeyCredential(expectedKey);

            var context = new TokenRequestContext(new[] { "https://vault.azure.net/.default" });
            AccessToken token = await credential.GetTokenAsync(context, CancellationToken.None);

            Assert.AreEqual(expectedKey, token.Token);
        }

        [Test]
        public void GetToken_ReturnsConfiguredKey()
        {
            const string expectedKey = "test-api-key-sync-67890";
            var credential = CreateApiKeyCredential(expectedKey);

            var context = new TokenRequestContext(new[] { "https://vault.azure.net/.default" });
            AccessToken token = credential.GetToken(context, CancellationToken.None);

            Assert.AreEqual(expectedKey, token.Token);
        }

        [Test]
        public async Task GetTokenAsync_MultipleCallsReturnConsistentToken()
        {
            const string expectedKey = "consistent-async-key";
            var credential = CreateApiKeyCredential(expectedKey);

            var context = new TokenRequestContext(new[] { "https://vault.azure.net/.default" });
            AccessToken token1 = await credential.GetTokenAsync(context, CancellationToken.None);
            AccessToken token2 = await credential.GetTokenAsync(context, CancellationToken.None);

            Assert.AreEqual(expectedKey, token1.Token);
            Assert.AreEqual(token1.Token, token2.Token);
            Assert.AreEqual(token1.ExpiresOn, token2.ExpiresOn);
        }

        [Test]
        public void GetToken_MultipleCallsReturnConsistentToken()
        {
            const string expectedKey = "consistent-sync-key";
            var credential = CreateApiKeyCredential(expectedKey);

            var context = new TokenRequestContext(new[] { "https://vault.azure.net/.default" });
            AccessToken token1 = credential.GetToken(context, CancellationToken.None);
            AccessToken token2 = credential.GetToken(context, CancellationToken.None);

            Assert.AreEqual(expectedKey, token1.Token);
            Assert.AreEqual(token1.Token, token2.Token);
            Assert.AreEqual(token1.ExpiresOn, token2.ExpiresOn);
        }

        [Test]
        public async Task GetTokenAsync_DifferentScopes_ReturnsSameToken()
        {
            const string expectedKey = "scope-independent-key";
            var credential = CreateApiKeyCredential(expectedKey);

            var context1 = new TokenRequestContext(new[] { "https://vault.azure.net/.default" });
            var context2 = new TokenRequestContext(new[] { "https://storage.azure.com/.default" });

            AccessToken token1 = await credential.GetTokenAsync(context1, CancellationToken.None);
            AccessToken token2 = await credential.GetTokenAsync(context2, CancellationToken.None);

            Assert.AreEqual(expectedKey, token1.Token);
            Assert.AreEqual(token1.Token, token2.Token);
        }

        [Test]
        public void GetToken_ExpiresOnIsMaxValue()
        {
            var credential = CreateApiKeyCredential("any-key");

            var context = new TokenRequestContext(new[] { "https://vault.azure.net/.default" });
            AccessToken token = credential.GetToken(context, CancellationToken.None);

            Assert.AreEqual(DateTimeOffset.MaxValue, token.ExpiresOn);
        }

        [Test]
        public async Task GetTokenAsync_ExpiresOnIsMaxValue()
        {
            var credential = CreateApiKeyCredential("any-key");

            var context = new TokenRequestContext(new[] { "https://vault.azure.net/.default" });
            AccessToken token = await credential.GetTokenAsync(context, CancellationToken.None);

            Assert.AreEqual(DateTimeOffset.MaxValue, token.ExpiresOn);
        }

        [Test]
        public void DifferentKeys_ProduceDifferentTokens()
        {
            var credential1 = CreateApiKeyCredential("key-alpha");
            var credential2 = CreateApiKeyCredential("key-beta");

            var context = new TokenRequestContext(new[] { "https://vault.azure.net/.default" });
            AccessToken token1 = credential1.GetToken(context, CancellationToken.None);
            AccessToken token2 = credential2.GetToken(context, CancellationToken.None);

            Assert.AreNotEqual(token1.Token, token2.Token);
            Assert.AreEqual("key-alpha", token1.Token);
            Assert.AreEqual("key-beta", token2.Token);
        }

        [Test]
        public void GetToken_NullKey_ReturnsNullToken()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["MyClient:Credential:CredentialSource"] = "ApiKey",
                })
                .Build();

            IConfigurationSection section = config.GetSection("MyClient:Credential");
            var options = new DefaultAzureCredentialOptions(new CredentialSettings(section), section);
            var credential = new ConfigurableCredential(options);

            var context = new TokenRequestContext(new[] { "https://vault.azure.net/.default" });
            AccessToken token = credential.GetToken(context, CancellationToken.None);

            Assert.IsNull(token.Token);
            Assert.AreEqual(DateTimeOffset.MaxValue, token.ExpiresOn);
        }

        [Test]
        public void GetToken_EmptyKey_ReturnsEmptyToken()
        {
            var credential = CreateApiKeyCredential(string.Empty);

            var context = new TokenRequestContext(new[] { "https://vault.azure.net/.default" });
            AccessToken token = credential.GetToken(context, CancellationToken.None);

            Assert.AreEqual(string.Empty, token.Token);
            Assert.AreEqual(DateTimeOffset.MaxValue, token.ExpiresOn);
        }
    }
}
