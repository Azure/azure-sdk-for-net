﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ClientSecretCredentialTests : CredentialTestBase
    {
        public ClientSecretCredentialTests(bool isAsync) : base(isAsync)
        { }

        [Test]
        public void VerifyCtorParametersValidation()
        {
            var tenantId = Guid.NewGuid().ToString();
            var clientId = Guid.NewGuid().ToString();
            var secret = "secret";

            Assert.Throws<ArgumentNullException>(() => new ClientSecretCredential(null, clientId, secret));
            Assert.Throws<ArgumentNullException>(() => new ClientSecretCredential(tenantId, null, secret));
            Assert.Throws<ArgumentNullException>(() => new ClientSecretCredential(tenantId, clientId, null));
        }

        [Test]
        public async Task UsesTenantIdHint(
            [Values(null, TenantIdHint)] string tenantId,
            [Values(true)] bool allowMultiTenantAuthentication)
        {
            TestSetup();
            options.AllowMultiTenantAuthentication = allowMultiTenantAuthentication;
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolver.Resolve(TenantId, context, options.AllowMultiTenantAuthentication);
            ClientSecretCredential client = InstrumentClient(new ClientSecretCredential(expectedTenantId, ClientId, "secret", options, null, mockConfidentialMsalClient));

            var token = await client.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(token.Token, expectedToken, "Should be the expected token value");
        }

        [Test]
        public async Task VerifyClientSecretRequestFailedAsync()
        {
            var response = new MockResponse(400);
            response.SetContent($"{{ \"error_code\": \"InvalidSecret\", \"message\": \"The specified client_secret is incorrect\" }}");
            var mockTransport = new MockTransport(response);
            var options = new TokenCredentialOptions() { Transport = mockTransport };
            var expectedTenantId = Guid.NewGuid().ToString();
            var expectedClientId = Guid.NewGuid().ToString();
            var expectedClientSecret = "secret";

            ClientSecretCredential client = InstrumentClient(new ClientSecretCredential(expectedTenantId, expectedClientId, expectedClientSecret, options));

            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await client.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            await Task.CompletedTask;
        }

        [Test]
        public async Task VerifyClientSecretCredentialExceptionAsync()
        {
            string expectedInnerExMessage = Guid.NewGuid().ToString();
            var mockMsalClient = new MockMsalConfidentialClient(new MockClientException(expectedInnerExMessage));
            var credential = InstrumentClient(
                new ClientSecretCredential(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), default, default, mockMsalClient));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.IsNotNull(ex.InnerException);
            Assert.IsInstanceOf(typeof(MockClientException), ex.InnerException);
            Assert.AreEqual(expectedInnerExMessage, ex.InnerException.Message);

            await Task.CompletedTask;
        }
    }
}
