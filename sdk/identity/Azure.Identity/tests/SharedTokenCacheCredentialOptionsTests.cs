// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class SharedTokenCacheCredentialOptionsTests
    {
        [Test]
        public void VerifyCachePersistenceOptionsCtorParam()
        {
            // verify passed in TokenCachePeristenceOptions are honored
            var persistenceOptions = new TokenCachePersistenceOptions { Name = "mocktokencachename" };

            var credentialOptions = new SharedTokenCacheCredentialOptions(persistenceOptions);

            Assert.AreEqual(persistenceOptions, credentialOptions.TokenCachePersistenceOptions);

            // verify passing null uses the default token cache persistence settings
            credentialOptions = new SharedTokenCacheCredentialOptions(null);

            Assert.AreEqual(SharedTokenCacheCredentialOptions.s_defaulTokenCachetPersistenceOptions, credentialOptions.TokenCachePersistenceOptions);

            // verify calling the default constructor uses the default token cache persistence settings
            credentialOptions = new SharedTokenCacheCredentialOptions();

            Assert.AreEqual(SharedTokenCacheCredentialOptions.s_defaulTokenCachetPersistenceOptions, credentialOptions.TokenCachePersistenceOptions);
        }
    }
}
