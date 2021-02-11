// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class InteractiveBrowserCredentialCtorTests
    {
        [Test]
        public void ValidateDefaultConstructor()
        {
            var credential = new InteractiveBrowserCredential();

            AssertOptionsHonored(new InteractiveBrowserCredentialOptions(), credential);
        }

        [Test]
        public void ValidateConstructorOverload1()
        {
            // tests the InteractiveBrowserCredential constructor overload
            // public InteractiveBrowserCredential(InteractiveBrowserCredentialOptions options)

            // null
            var credential = new InteractiveBrowserCredential((InteractiveBrowserCredentialOptions)null);

            AssertOptionsHonored(new InteractiveBrowserCredentialOptions(), credential);

            Assert.AreEqual(CredentialPipeline.GetInstance(null), credential.Pipeline);

            // with options
            var options = new InteractiveBrowserCredentialOptions
            {
                ClientId = Guid.NewGuid().ToString(),
                TenantId = Guid.NewGuid().ToString(),
                AuthorityHost = new Uri("https://login.myauthority.com/"),
                DisableAutomaticAuthentication = true,
                TokenCache = new TokenCache(),
                AuthenticationRecord = new AuthenticationRecord(),
                RedirectUri = new Uri("https://localhost:8080"),
            };

            credential = new InteractiveBrowserCredential(options);

            AssertOptionsHonored(options, credential);
        }

        [Test]
        public void ValidateConstructorOverload2()
        {
            // tests the InteractiveBrowserCredential constructor overload
            // public InteractiveBrowserCredential(string clientId)

            // null
            Assert.Throws<ArgumentNullException>(() => new InteractiveBrowserCredential((string)null));

            // not null
            var options = new InteractiveBrowserCredentialOptions
            {
                ClientId = Guid.NewGuid().ToString()
            };

            var credential = new InteractiveBrowserCredential(options.ClientId);

            AssertOptionsHonored(options, credential);

            Assert.AreEqual(CredentialPipeline.GetInstance(null), credential.Pipeline);
        }

        [Test]
        public void ValidateConstructorOverload3()
        {
            // tests the InteractiveBrowserCredential constructor overload
            // public InteractiveBrowserCredential(string tenantId, string clientId, TokenCredentialOptions options = default)

            // null, null
            Assert.Throws<ArgumentNullException>(() => new InteractiveBrowserCredential(null, null));

            // null, null, null
            Assert.Throws<ArgumentNullException>(() => new InteractiveBrowserCredential(null, null, null));

            // str, null
            Assert.Throws<ArgumentNullException>(() => new InteractiveBrowserCredential("tenantid", null));

            // null, str
            var options = new InteractiveBrowserCredentialOptions { ClientId = Guid.NewGuid().ToString() };

            var credential = new InteractiveBrowserCredential(null, options.ClientId);

            AssertOptionsHonored(options, credential);

            Assert.AreEqual(CredentialPipeline.GetInstance(null), credential.Pipeline);

            // str, str
            options.TenantId = Guid.NewGuid().ToString();

            credential = new InteractiveBrowserCredential(options.TenantId, options.ClientId);

            AssertOptionsHonored(options, credential);

            Assert.AreEqual(CredentialPipeline.GetInstance(null), credential.Pipeline);

            // str, str, options
            options.AuthorityHost = new Uri("https://login.myauthority.com/");

            credential = new InteractiveBrowserCredential(options.TenantId, options.ClientId, new TokenCredentialOptions { AuthorityHost = options.AuthorityHost });

            AssertOptionsHonored(options, credential);
        }

        public void AssertOptionsHonored(InteractiveBrowserCredentialOptions options, InteractiveBrowserCredential credential)
        {
            Assert.AreEqual(options.ClientId, credential.ClientId);
            Assert.AreEqual(options.TenantId, credential.Client.TenantId);
            Assert.AreEqual(options.AuthorityHost, credential.Pipeline.AuthorityHost);
            Assert.AreEqual(options.DisableAutomaticAuthentication, credential.DisableAutomaticAuthentication);
            Assert.AreEqual(options.TokenCache, credential.Client.TokenCache);
            Assert.AreEqual(options.AuthenticationRecord, credential.Record);

            if (options.RedirectUri != null)
            {
                Assert.AreEqual(options.RedirectUri, new Uri(credential.Client.RedirectUrl));
            }
            else
            {
                Assert.AreEqual(Constants.DefaultRedirectUrl, credential.Client.RedirectUrl);
            }
        }
    }
}
