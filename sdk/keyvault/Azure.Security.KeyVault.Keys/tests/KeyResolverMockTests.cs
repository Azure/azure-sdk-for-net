// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class KeyResolverMockTests : ClientTestBase
    {
        public KeyResolverMockTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task ShouldNotRequireGetPermissionForKey()
        {
            // Test for https://github.com/Azure/azure-sdk-for-net/issues/11574
            MockTransport transport = new(request => new MockResponse((int)HttpStatusCode.Forbidden, nameof(HttpStatusCode.Forbidden)));

            KeyResolver resolver = GetResolver(transport);

            // This would otherwise throw if "keys/get" permission was denied and #11574 was not resolved.
            CryptographyClient client = await resolver.ResolveAsync(new Uri("https://mock.vault.azure.net/keys/mock-key"));

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.UnwrapKeyAsync(KeyWrapAlgorithm.A256KW, new byte[] { 0, 1, 2, 3 }));
            Assert.AreEqual((int)HttpStatusCode.Forbidden, ex.Status);
        }

        [Test]
        public void ShouldRequireGetPermissionForSecret()
        {
            // Test for https://github.com/Azure/azure-sdk-for-net/issues/11574
            MockTransport transport = new(request => new MockResponse((int)HttpStatusCode.Forbidden, nameof(HttpStatusCode.Forbidden)));

            KeyResolver resolver = GetResolver(transport);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await resolver.ResolveAsync(new Uri("https://mock.vault.azure.net/secrets/mock-secret")));
            Assert.AreEqual((int)HttpStatusCode.Forbidden, ex.Status);
        }

        [Test]
        public async Task ShouldNotAttemptSubsequentDownload()
        {
            // Test for https://github.com/Azure/azure-sdk-for-net/issues/25254
            MockTransport transport = new((MockRequest request) =>
            {
                if (request.Method == RequestMethod.Get)
                {
                    // Any attempt to get the key must return 403 Forbidden.
                    return new MockResponse((int)HttpStatusCode.Forbidden, nameof(HttpStatusCode.Forbidden));
                }

                return new MockResponse((int)HttpStatusCode.OK).WithContent(@"{""kid"":""https://mock.vault.azure.net/keys/mock-key/mock-version"",""value"":""dGVzdA""}");
            });

            KeyResolver resolver = GetResolver(transport);

            // This would otherwise throw if "keys/get" permission was denied and #11574 was not resolved.
            CryptographyClient client = await resolver.ResolveAsync(new Uri("https://mock.vault.azure.net/keys/mock-key"));

            WrapResult result = await client.WrapKeyAsync(KeyWrapAlgorithm.A256KW, new byte[] { 0, 1, 2, 3 });
            Assert.AreEqual("https://mock.vault.azure.net/keys/mock-key/mock-version", result.KeyId);
        }

        protected KeyResolver GetResolver(MockTransport transport)
        {
            Assert.NotNull(transport);

            CryptographyClientOptions options = new CryptographyClientOptions
            {
                Transport = transport,
            };

            return InstrumentClient(
                new KeyResolver(new NullTokenCredential(), options));
        }

        private class NullTokenCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                new("invalid", DateTimeOffset.Now.AddHours(1));

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                new(GetToken(requestContext, cancellationToken));
        }
    }
}
