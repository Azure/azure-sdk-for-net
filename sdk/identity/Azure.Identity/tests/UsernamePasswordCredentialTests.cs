// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Testing;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.Identity.Tests
{
    public class UsernamePasswordCredentialTests : ClientTestBase
    {
        private const string ClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";

        public UsernamePasswordCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("This test requires a user account which doesn't have MFA enabled.")]
        public async Task AuthenticateUsernamePasswordLiveAsync()
        {
            var username = Environment.GetEnvironmentVariable("IDENTITYTEST_USERNAMEPASSWORDCREDENTIAL_USERNAME");

            var password = Environment.GetEnvironmentVariable("IDENTITYTEST_USERNAMEPASSWORDCREDENTIAL_PASSWORD");

            var tenantId = Environment.GetEnvironmentVariable("IDENTITYTEST_USERNAMEPASSWORDCREDENTIAL_TENANTID");

            var cred = new UsernamePasswordCredential(username, password, tenantId, ClientId);

            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" }));

            Assert.IsNotNull(token.Token);
        }

        [Test]
        public async Task VerifyMsalClientExceptionAsync()
        {
            string expInnerExMessage = Guid.NewGuid().ToString();

            var mockMsalClient = new MockMsalPublicClient() { UserPassAuthFactory = (_) => { throw new MockClientException(expInnerExMessage); } };

            var username = Guid.NewGuid().ToString();
            var password = Guid.NewGuid().ToString();

            var credential = InstrumentClient(new UsernamePasswordCredential(username, password, CredentialPipeline.GetInstance(null), mockMsalClient));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.IsNotNull(ex.InnerException);

            Assert.IsInstanceOf(typeof(MockClientException), ex.InnerException);

            Assert.AreEqual(expInnerExMessage, ex.InnerException.Message);

            await Task.CompletedTask;
        }
    }
}
