// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/27263")]
    public class VisualStudioCodeCredentialTests : CredentialTestBase<VisualStudioCodeCredentialOptions>
    {
        public VisualStudioCodeCredentialTests(bool isAsync) : base(isAsync)
        { }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
        {
            using var env = new TestEnvVar(new Dictionary<string, string> { { "IDENTITY_TENANT_ID", TenantId } });
            var environment = new IdentityTestEnvironment();
            var vscOptions = new VisualStudioCodeCredentialOptions
            {
                Diagnostics = { IsAccountIdentifierLoggingEnabled = options.Diagnostics.IsAccountIdentifierLoggingEnabled },
                TenantId = environment.TenantId,
                Transport = new MockTransport()
            };

            return InstrumentClient(
                new VisualStudioCodeCredential(
                    vscOptions,
                    null,
                    mockPublicMsalClient,
                    CredentialTestHelpers.CreateFileSystemForVisualStudioCode(environment),
                    new TestVscAdapter("VS Code Azure", "AzureCloud", expectedToken)));
        }

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config) => throw new NotImplementedException();

        [SetUp]
        public void Setup()
        {
            TestSetup();
        }

        [Test]
        [NonParallelizable]
        public async Task AuthenticateWithVsCodeCredential([Values(null, TenantIdHint)] string tenantId, [Values(true)] bool allowMultiTenantAuthentication)
        {
            using var env = new TestEnvVar(new Dictionary<string, string> { { "IDENTITY_TENANT_ID", TenantId } });
            var environment = new IdentityTestEnvironment();
            var options = new VisualStudioCodeCredentialOptions { TenantId = environment.TenantId, AdditionallyAllowedTenants = { TenantIdHint }, Transport = new MockTransport() };
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolverBase.Default.Resolve(environment.TenantId, context, TenantIdResolverBase.AllTenants);

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
        public void AdfsTenantThrowsCredentialUnavailable()
        {
            var options = new VisualStudioCodeCredentialOptions { TenantId = "adfs", Transport = new MockTransport() };
            var context = new TokenRequestContext(new[] { Scope });
            string expectedTenantId = TenantIdResolverBase.Default.Resolve(null, context, TenantIdResolverBase.AllTenants);

            VisualStudioCodeCredential credential = InstrumentClient(new VisualStudioCodeCredential(options));

            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/.default" }), CancellationToken.None));
        }
    }
}
