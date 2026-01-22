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

            Assert.That(credential.Pipeline, Is.EqualTo(CredentialPipeline.GetInstance(null)));

            // with options
            var options = new InteractiveBrowserCredentialOptions
            {
                ClientId = Guid.NewGuid().ToString(),
                TenantId = Guid.NewGuid().ToString(),
                AuthorityHost = new Uri("https://login.myauthority.com/"),
                DisableAutomaticAuthentication = true,
                TokenCachePersistenceOptions = new TokenCachePersistenceOptions(),
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

            Assert.That(credential.Pipeline, Is.EqualTo(CredentialPipeline.GetInstance(null)));
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

            Assert.That(credential.Pipeline, Is.EqualTo(CredentialPipeline.GetInstance(null)));

            // str, str
            options.TenantId = Guid.NewGuid().ToString();

            credential = new InteractiveBrowserCredential(options.TenantId, options.ClientId);

            AssertOptionsHonored(options, credential);

            Assert.That(credential.Pipeline, Is.EqualTo(CredentialPipeline.GetInstance(null)));

            // str, str, options
            options.AuthorityHost = new Uri("https://login.myauthority.com/");

            credential = new InteractiveBrowserCredential(options.TenantId, options.ClientId, new TokenCredentialOptions { AuthorityHost = options.AuthorityHost });

            AssertOptionsHonored(options, credential);
        }

        public void AssertOptionsHonored(InteractiveBrowserCredentialOptions options, InteractiveBrowserCredential credential)
        {
            Assert.That(credential.ClientId, Is.EqualTo(options.ClientId));
            Assert.That(credential.Client.TenantId, Is.EqualTo(options.TenantId));
            Assert.That(credential.DisableAutomaticAuthentication, Is.EqualTo(options.DisableAutomaticAuthentication));
            Assert.That(credential.Record, Is.EqualTo(options.AuthenticationRecord));

            if (options.RedirectUri != null)
            {
                Assert.That(new Uri(credential.Client.RedirectUrl), Is.EqualTo(options.RedirectUri));
            }
            else
            {
                Assert.That(credential.Client.RedirectUrl, Is.EqualTo(Constants.DefaultRedirectUrl));
            }
        }
    }
}
