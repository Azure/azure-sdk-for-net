// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Azure.Identity.Tests
{
    public class UsernamePasswordCredentialTests : CredentialTestBase
    {
        public UsernamePasswordCredentialTests(bool isAsync) : base(isAsync)
        { }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
        {
            var pwOptions = new UsernamePasswordCredentialOptions
            {
                Diagnostics = { IsAccountIdentifierLoggingEnabled = options.Diagnostics.IsAccountIdentifierLoggingEnabled }
            };
            return InstrumentClient(new UsernamePasswordCredential("user", "password", TenantId, ClientId, pwOptions, null, mockPublicMsalClient));
        }

        [Test]
        public async Task VerifyMsalClientExceptionAsync()
        {
            string expInnerExMessage = Guid.NewGuid().ToString();

            var mockMsalClient = new MockMsalPublicClient() { UserPassAuthFactory = (_, _) => { throw new MockClientException(expInnerExMessage); } };

            var username = Guid.NewGuid().ToString();
            var password = Guid.NewGuid().ToString();
            var clientId = Guid.NewGuid().ToString();
            var tenantId = Guid.NewGuid().ToString();

            var credential = InstrumentClient(new UsernamePasswordCredential(username, password, clientId, tenantId, default, default, mockMsalClient));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.IsNotNull(ex.InnerException);

            Assert.IsInstanceOf(typeof(MockClientException), ex.InnerException);

            Assert.AreEqual(expInnerExMessage, ex.InnerException.Message);

            await Task.CompletedTask;
        }

        [Test]
        public void RespectsIsPIILoggingEnabled([Values(true, false)] bool isLoggingPIIEnabled)
        {
            var username = Guid.NewGuid().ToString();
            var password = Guid.NewGuid().ToString();
            var clientId = Guid.NewGuid().ToString();
            var tenantId = Guid.NewGuid().ToString();

            var credential = new UsernamePasswordCredential(
                username,
                password,
                clientId,
                tenantId,
                new TokenCredentialOptions { IsLoggingPIIEnabled = isLoggingPIIEnabled },
                default,
                null);

            Assert.NotNull(credential.Client);
            Assert.AreEqual(isLoggingPIIEnabled, credential.Client.IsPiiLoggingEnabled);
        }

        [Test]
        public async Task UsesTenantIdHint([Values(null, TenantIdHint)] string tenantId, [Values(true)] bool allowMultiTenantAuthentication)
        {
            TestSetup();
            var options = new UsernamePasswordCredentialOptions();
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolver.Resolve(TenantId, context);

            var credential = InstrumentClient(new UsernamePasswordCredential("user", "password", TenantId, ClientId, options, null, mockPublicMsalClient));

            AccessToken token = await credential.GetTokenAsync(context);

            Assert.AreEqual(expectedToken, token.Token);
            Assert.AreEqual(expiresOn, token.ExpiresOn);
        }
    }
}
