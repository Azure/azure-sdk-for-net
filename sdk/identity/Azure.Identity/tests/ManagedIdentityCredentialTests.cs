using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Identity.Tests
{
    public class ManagedIdentityTests
    {
        [Test]
        public async Task GetSystemTokenLiveAsync()
        {
            var credential = new ManagedIdentityCredential();

            var token = await credential.GetTokenAsync(new string[] { "https://management.azure.com//.default" });

            Assert.IsNotNull(token.Token);
        }

    }
}
