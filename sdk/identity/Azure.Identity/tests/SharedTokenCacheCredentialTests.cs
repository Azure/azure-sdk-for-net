using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Identity.Tests
{
    public class SharedTokenCacheCredentialTests
    {
        [Test]
        public async Task VerifyUserNotInCache()
        {
            var cred = new SharedTokenCacheCredential("04b07795-8ddb-461a-bbee-02f9e1bf7b46", "unauthenticateduser@contoso.com");

            var accessToken = await cred.GetTokenAsync(new string[] { "https://vault.azure.net/.default" });

            Assert.IsNull(accessToken.Token);
        }
    }
}
