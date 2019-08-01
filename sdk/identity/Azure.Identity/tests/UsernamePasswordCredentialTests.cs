using Azure.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Identity.Tests
{
    public class UsernamePasswordCredentialTests
    {
        private const string ClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";

        [Test]
        public async Task AuthenticateUsernamePasswordLiveAsync()
        {
            var username = Environment.GetEnvironmentVariable("IDENTITYTEST_USERNAMEPASSWORDCREDENTIAL_USERNAME");

            var password = Environment.GetEnvironmentVariable("IDENTITYTEST_USERNAMEPASSWORDCREDENTIAL_PASSWORD");

            var tenantId = Environment.GetEnvironmentVariable("IDENTITYTEST_USERNAMEPASSWORDCREDENTIAL_TENANTID");

            var cred = new UsernamePasswordCredential(username, password.ToSecureString(), tenantId, ClientId);

            AccessToken token = await cred.GetTokenAsync(new string[] { "https://vault.azure.net/.default" });

            Assert.IsNotNull(token.Token);
        }
    }
}
