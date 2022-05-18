// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Identity.BrokeredAuthentication.Tests
{
    public class SharedTokenCacheCredentialBrokerOptionsTests
    {
        [Test]
        public void VerifyTokenCacheOptionsCtorParam()
        {
            // verify passed in TokenCachePeristenceOptions are honored
            var persistenceOptions = new TokenCachePersistenceOptions { Name = "mocktokencachename" };

            var credentialOptions = new SharedTokenCacheCredentialBrokerOptions(persistenceOptions);

            Assert.AreEqual(persistenceOptions, credentialOptions.TokenCachePersistenceOptions);
        }
    }
}
