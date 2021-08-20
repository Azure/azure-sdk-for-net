// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Azure.Identity.Tests
{
    public class UsernamePasswordCredentialTests : ClientTestBase
    {
        private string TenantId = "a0287521-e002-0026-7112-207c0c000000";
        private const string TenantIdHint = "a0287521-e002-0026-7112-207c0c001234";
        private const string Scope = "https://vault.azure.net/.default";
        private const string ClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";
        private string expectedCode;
        private string expectedToken;
        private DateTimeOffset expiresOn;
        private MockMsalPublicClient mockMsal;
        private DeviceCodeResult deviceCodeResult;
        private string expectedTenantId;

        public UsernamePasswordCredentialTests(bool isAsync) : base(isAsync)
        { }

        [Test]
        public async Task VerifyMsalClientExceptionAsync()
        {
            string expInnerExMessage = Guid.NewGuid().ToString();

            var mockMsalClient = new MockMsalPublicClient() { UserPassAuthFactory = (_, _) => { throw new MockClientException(expInnerExMessage); } };

            var username = Guid.NewGuid().ToString();
            var password = Guid.NewGuid().ToString();
            var clientId = Guid.NewGuid().ToString();
            var tenantId = Guid.NewGuid().ToString();

            var credential = InstrumentClient(new UsernamePasswordCredential(username, password, clientId, tenantId, default, default, mockMsalClient));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.IsNotNull(ex.InnerException);

            Assert.IsInstanceOf(typeof(MockClientException), ex.InnerException);

            Assert.AreEqual(expInnerExMessage, ex.InnerException.Message);

            await Task.CompletedTask;
        }

        [Test]
        public void RespectsIsPIILoggingEnabled([Values(true, false)] bool isLoggingPIIEnabled)
        {
            var username = Guid.NewGuid().ToString();
            var password = Guid.NewGuid().ToString();
            var clientId = Guid.NewGuid().ToString();
            var tenantId = Guid.NewGuid().ToString();

            var credential = new UsernamePasswordCredential(username, password, clientId, tenantId, new TokenCredentialOptions{ IsLoggingPIIEnabled = isLoggingPIIEnabled}, default, null);

            Assert.NotNull(credential.Client);
            Assert.AreEqual(isLoggingPIIEnabled, credential.Client.LogPII);
        }

        [Test]
        public async Task UsesTenantIdHint([Values(null, TenantIdHint)] string tenantId, [Values(true)] bool allowMultiTenantAuthentication)
        {
            TestSetup();
            var options = new UsernamePasswordCredentialOptions { AllowMultiTenantAuthentication = allowMultiTenantAuthentication };
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolver.Resolve(TenantId, context, options.AllowMultiTenantAuthentication);

            var credential = InstrumentClient(new UsernamePasswordCredential("user", "password", TenantId, ClientId, options, null, mockMsal));

            AccessToken token = await credential.GetTokenAsync(context);

            Assert.AreEqual(expectedToken, token.Token);
            Assert.AreEqual(expiresOn, token.ExpiresOn);
        }

        public void TestSetup()
        {
            expectedTenantId = null;
            expectedCode = Guid.NewGuid().ToString();
            expectedToken = Guid.NewGuid().ToString();
            expiresOn = DateTimeOffset.Now.AddHours(1);
            mockMsal = new MockMsalPublicClient();
            deviceCodeResult = MockMsalPublicClient.GetDeviceCodeResult(deviceCode: expectedCode);
            mockMsal.DeviceCodeResult = deviceCodeResult;
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
            mockMsal.UserPassAuthFactory = (_, tenant) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
        }
    }
}
