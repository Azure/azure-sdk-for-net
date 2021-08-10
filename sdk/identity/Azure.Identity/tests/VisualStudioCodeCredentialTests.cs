// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class VisualStudioCodeCredentialTests : ClientTestBase
    {
        private string TenantId = "a0287521-e002-0026-7112-207c0c000000";
        private const string TenantIdHint = "a0287521-e002-0026-7112-207c0c001234";
        private const string Scope = "https://vault.azure.net/.default";
        private string expectedCode;
        private string expectedToken;
        private DateTimeOffset expiresOn;
        private MockMsalPublicClient mockMsalClient;
        private DeviceCodeResult deviceCodeResult;
        private string expectedTenantId;

        public VisualStudioCodeCredentialTests(bool isAsync) : base(isAsync)
        { }

        [SetUp]
        public void TestSetup()
        {
            expectedTenantId = null;
            expectedCode = Guid.NewGuid().ToString();
            expectedToken = Guid.NewGuid().ToString();
            expiresOn = DateTimeOffset.Now.AddHours(1);
            mockMsalClient = new MockMsalPublicClient();
            deviceCodeResult = MockMsalPublicClient.GetDeviceCodeResult(deviceCode: expectedCode);
            mockMsalClient.DeviceCodeResult = deviceCodeResult;
            var result = new AuthenticationResult(
                expectedToken,
                false,
                null,
                expiresOn,
                expiresOn,
                TenantId,
                new MockAccount("username"),
                null,
                new[] { Scope },
                Guid.NewGuid(),
                null,
                "Bearer");
            mockMsalClient.RefreshTokenFactory = (_, _,_, _, tenant, _, _) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
        }

        [Test]
        [NonParallelizable]
        public async Task AuthenticateWithVsCodeCredential([Values(null, TenantIdHint)] string tenantId, [Values(true)] bool allowMultiTenantAuthentication)
        {
            using var env = new TestEnvVar(new Dictionary<string, string> {{"TENANT_ID", TenantId}});
            var environment = new IdentityTestEnvironment();
            var options = new VisualStudioCodeCredentialOptions { TenantId = environment.TenantId, Transport = new MockTransport(), AllowMultiTenantAuthentication = allowMultiTenantAuthentication };
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolver.Resolve(environment.TenantId, context, options.AllowMultiTenantAuthentication);

            VisualStudioCodeCredential credential = InstrumentClient(
                new VisualStudioCodeCredential(
                    options,
                    null,
                    mockMsalClient,
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
            Assert.AreEqual(isLoggingPIIEnabled, credential.Client.LogPII);
        }

        [Test]
        public void AdfsTenantThrowsCredentialUnavailable()
        {
            var options = new VisualStudioCodeCredentialOptions { TenantId = "adfs", Transport = new MockTransport() };
            var context = new TokenRequestContext(new[] { Scope });
            string expectedTenantId = TenantIdResolver.Resolve(null, context, options.AllowMultiTenantAuthentication);

            VisualStudioCodeCredential credential = InstrumentClient(new VisualStudioCodeCredential(options));

            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/.default" }), CancellationToken.None));
        }
    }
}
