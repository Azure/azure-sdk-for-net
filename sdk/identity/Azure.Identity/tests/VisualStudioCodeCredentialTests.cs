// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class VisualStudioCodeCredentialTests : CredentialTestBase
    {
        public VisualStudioCodeCredentialTests(bool isAsync) : base(isAsync)
        { }

        [SetUp]
        public void Setup()
        {
            TestSetup();
        }

        [Test]
        [NonParallelizable]
        public async Task AuthenticateWithVsCodeCredential([Values(null, TenantIdHint)] string tenantId, [Values(true)] bool allowMultiTenantAuthentication)
        {
            using var env = new TestEnvVar(new Dictionary<string, string> {{"TENANT_ID", TenantId}});
            var environment = new IdentityTestEnvironment();
            var options = new VisualStudioCodeCredentialOptions { TenantId = environment.TenantId, Transport = new MockTransport() };
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolver.Resolve(environment.TenantId, context);

            VisualStudioCodeCredential credential = InstrumentClient(
                new VisualStudioCodeCredential(
                    options,
                    null,
                    mockPublicMsalClient,
                    CredentialTestHelpers.CreateFileSystemForVisualStudioCode(environment),
                    new TestVscAdapter("VS Code Azure", "AzureCloud", expectedToken)));

            var actualToken = await credential.GetTokenAsync(context, CancellationToken.None);

            Assert.AreEqual(expectedToken, actualToken.Token, "Token should match");
            Assert.AreEqual(expiresOn, actualToken.ExpiresOn, "expiresOn should match");
        }

        [Test]
        public void RespectsIsPIILoggingEnabled([Values(true, false)] bool isLoggingPIIEnabled)
        {
            var credential = new VisualStudioCodeCredential(new VisualStudioCodeCredentialOptions{ IsLoggingPIIEnabled = isLoggingPIIEnabled});

            Assert.NotNull(credential.Client);
            Assert.AreEqual(isLoggingPIIEnabled, credential.Client.IsPiiLoggingEnabled);
        }

        [Test]
        public void AdfsTenantThrowsCredentialUnavailable()
        {
            var options = new VisualStudioCodeCredentialOptions { TenantId = "adfs", Transport = new MockTransport() };
            var context = new TokenRequestContext(new[] { Scope });
            string expectedTenantId = TenantIdResolver.Resolve(null, context);

            VisualStudioCodeCredential credential = InstrumentClient(new VisualStudioCodeCredential(options));

            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/.default" }), CancellationToken.None));
        }
    }
}
