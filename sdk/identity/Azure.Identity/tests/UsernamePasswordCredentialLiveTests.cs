// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class UsernamePasswordCredentialLiveTests : IdentityRecordedTestBase
    {
        private const string ClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";

        public UsernamePasswordCredentialLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearDiscoveryCache()
        {
            StaticCachesUtilities.ClearStaticMetadataProviderCache();
        }

        [Test]
        public async Task GetToken()
        {
            var tenantId = TestEnvironment.IdentityTenantId;
            var username = TestEnvironment.Username;
            var password = TestEnvironment.TestPassword;

            var options = InstrumentClientOptions(new TokenCredentialOptions());

            var cred = InstrumentClient(new UsernamePasswordCredential(username, password, tenantId, ClientId, options));

            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" }));

            Assert.IsNotNull(token.Token);
        }

        [Ignore("Skipped: tenant requires MFA; test no longer valid for TME tenant.")]
        [Test]
        public async Task AuthenticateNoContext()
        {
            var tenantId = TestEnvironment.IdentityTenantId;
            var username = TestEnvironment.Username;
            var password = TestEnvironment.TestPassword;

            var options = InstrumentClientOptions(new TokenCredentialOptions());

            var cred = InstrumentClient(new UsernamePasswordCredential(username, password, tenantId, ClientId, options));

            AuthenticationRecord record = await cred.AuthenticateAsync();

            Assert.IsNotNull(record);

            Assert.AreEqual(username, record.Username);
            Assert.AreEqual(tenantId, record.TenantId);
        }

        [Test]
        public async Task AuthenticateWithContext()
        {
            var tenantId = TestEnvironment.IdentityTenantId;
            var username = TestEnvironment.Username;
            var password = TestEnvironment.TestPassword;

            var options = InstrumentClientOptions(new TokenCredentialOptions());

            var cred = InstrumentClient(new UsernamePasswordCredential(username, password, tenantId, ClientId, options));

            AuthenticationRecord record = await cred.AuthenticateAsync(new TokenRequestContext(new[] { "https://vault.azure.net/.default" }));

            Assert.IsNotNull(record);

            Assert.AreEqual(username, record.Username);
            Assert.AreEqual(tenantId, record.TenantId);
        }
    }
}
