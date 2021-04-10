﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ClientSecretCredentialLiveTests : IdentityRecordedTestBase
    {
        public ClientSecretCredentialLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearDiscoveryCache()
        {
            StaticCachesUtilities.ClearStaticMetadataProviderCache();
            StaticCachesUtilities.ClearAuthorityEndpointResolutionManagerCache();
        }

        [Test]
        public async Task GetToken()
        {
            var tenantId = TestEnvironment.ServicePrincipalTenantId;
            var clientId = TestEnvironment.ServicePrincipalClientId;
            var secret = TestEnvironment.ServicePrincipalClientSecret;

            var cache = new MemoryTokenCache();
            var options = InstrumentClientOptions(new ClientSecretCredentialOptions() { TokenCachePersistenceOptions = cache });

            var credential = InstrumentClient(new ClientSecretCredential(tenantId, clientId, secret, options));

            var tokenRequestContext = new TokenRequestContext(new[] { AzureAuthorityHosts.GetDefaultScope(AzureAuthorityHosts.AzurePublicCloud) });

            // ensure we can initially acquire a  token
            AccessToken token = await credential.GetTokenAsync(tokenRequestContext);

            Assert.IsNotNull(token.Token);
            Assert.That(cache.CacheReadCount, Is.Not.Zero);
            Assert.That(cache.CacheUpdatedCount, Is.Not.Zero);

            // ensure subsequent calls before the token expires are served from the token cache
            AccessToken cachedToken = await credential.GetTokenAsync(tokenRequestContext);

            Assert.AreEqual(token.Token, cachedToken.Token);

            // ensure new credentials don't share tokens from the cache
            var credential2 = new ClientSecretCredential(tenantId, clientId, secret, options);

            AccessToken token2 = await credential2.GetTokenAsync(tokenRequestContext);

            if (Mode != RecordedTestMode.Playback && Mode != RecordedTestMode.None)
            {
                Assert.AreNotEqual(token.Token, token2.Token);
            }
        }

        [Test]
        public void GetTokenIncorrectPassword()
        {
            var tenantId = TestEnvironment.ServicePrincipalTenantId;
            var clientId = TestEnvironment.ServicePrincipalClientId;
            var secret = "badsecret";

            var options = InstrumentClientOptions(new TokenCredentialOptions());

            var credential = InstrumentClient(new ClientSecretCredential(tenantId, clientId, secret, options));

            var tokenRequestContext = new TokenRequestContext(new[] { AzureAuthorityHosts.GetDefaultScope(AzureAuthorityHosts.AzurePublicCloud) });

            // ensure we can initially acquire a  token
            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(tokenRequestContext));
        }

        public class MemoryTokenCache : UnsafeTokenCacheOptions
        {
            private ReadOnlyMemory<byte> Data = new ReadOnlyMemory<byte>();
            public int CacheReadCount;
            public int CacheUpdatedCount;

            protected internal override Task<ReadOnlyMemory<byte>> RefreshCacheAsync()
            {
                CacheReadCount++;
                return Task.FromResult(Data);
            }

            protected internal override Task TokenCacheUpdatedAsync(TokenCacheUpdatedArgs tokenCacheUpdatedArgs)
            {
                CacheUpdatedCount++;
                Data = tokenCacheUpdatedArgs.UnsafeCacheData;
                return Task.CompletedTask;
            }
        }
    }
}
