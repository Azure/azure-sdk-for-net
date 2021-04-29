// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class VisualStudioCodeCredentialTests : ClientTestBase
    {
        public VisualStudioCodeCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void AdfsTenantThrowsCredentialUnavailable()
        {
            var options = new VisualStudioCodeCredentialOptions { TenantId = "adfs", Transport = new MockTransport() };

            VisualStudioCodeCredential credential = InstrumentClient(new VisualStudioCodeCredential(options));

            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/.default" }), CancellationToken.None));
        }
    }
}
