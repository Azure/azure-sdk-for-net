// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class TokenCredentialOptionsTests : ClientTestBase
    {
        public TokenCredentialOptionsTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void InvalidEnvAuthorityHost()
        {
            using (new TestEnvVar("AZURE_AUTHORITY_HOST", "mock-env-authority-host"))
            {
                TokenCredentialOptions option = new TokenCredentialOptions();

                Assert.Throws<UriFormatException>(() => { Uri finalUri = option.AuthorityHost; });
            }
        }

        [Test]
        public void EnvAuthorityHost()
        {
            string envHostValue = KnownAuthorityHosts.AzureChinaCloud.ToString();

            using (new TestEnvVar("AZURE_AUTHORITY_HOST", envHostValue))
            {
                TokenCredentialOptions option = new TokenCredentialOptions();
                Uri finalUri = option.AuthorityHost;

                Assert.AreEqual(finalUri, new Uri(envHostValue));
            }
        }

        [Test]
        public void CustomAuthorityHost()
        {
            string envHostValue = KnownAuthorityHosts.AzureGermanCloud.ToString();

            using (new TestEnvVar("AZURE_AUTHORITY_HOST", envHostValue))
            {
                Uri customUri = KnownAuthorityHosts.AzureChinaCloud;

                TokenCredentialOptions option = new TokenCredentialOptions() { AuthorityHost = customUri };
                Uri finalUri = option.AuthorityHost;

                Assert.AreNotEqual(finalUri, new Uri(envHostValue));
                Assert.AreEqual(finalUri, customUri);
            }
        }

        [Test]
        public void DefaultAuthorityHost()
        {
            using (new TestEnvVar("AZURE_AUTHORITY_HOST", null))
            {
                TokenCredentialOptions option = new TokenCredentialOptions();

                Assert.AreEqual(option.AuthorityHost, KnownAuthorityHosts.AzureCloud);
            }
        }
    }
}
