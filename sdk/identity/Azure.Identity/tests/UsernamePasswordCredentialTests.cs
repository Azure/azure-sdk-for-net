// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class UsernamePasswordCredentialTests : CredentialTestBase<UsernamePasswordCredentialOptions>
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

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
        {
            if (config.TenantId == null)
            {
                Assert.Ignore("Null TenantId test does not apply to this credential");
            }

            var options = new UsernamePasswordCredentialOptions
            {
                DisableInstanceDiscovery = config.DisableInstanceDiscovery,
                AdditionallyAllowedTenants = config.AdditionallyAllowedTenants,
                IsUnsafeSupportLoggingEnabled = config.IsUnsafeSupportLoggingEnabled,
            };
            if (config.Transport != null)
            {
                options.Transport = config.Transport;
            }
            var pipeline = CredentialPipeline.GetInstance(options);
            return InstrumentClient(new UsernamePasswordCredential("user", "password", config.TenantId, ClientId, options, pipeline, config.MockPublicMsalClient));
        }

        [Test]
        public async Task VerifyMsalClientExceptionAsync()
        {
            string expInnerExMessage = Guid.NewGuid().ToString();

            var mockMsalClient = new MockMsalPublicClient() { UserPassAuthFactory = (_, _, _, _, _, _) => { throw new MockClientException(expInnerExMessage); } };

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
        public async Task UsesTenantIdHint([Values(null, TenantIdHint)] string tenantId, [Values(true)] bool allowMultiTenantAuthentication)
        {
            TestSetup();
            var options = new UsernamePasswordCredentialOptions() { AdditionallyAllowedTenants = { TenantIdHint } };
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolverBase.Default.Resolve(TenantId, context, TenantIdResolverBase.AllTenants);

            var credential = InstrumentClient(new UsernamePasswordCredential("user", "password", TenantId, ClientId, options, null, mockPublicMsalClient));

            AccessToken token = await credential.GetTokenAsync(context);

            Assert.AreEqual(expectedToken, token.Token);
            Assert.AreEqual(expiresOn, token.ExpiresOn);
        }
    }
}
