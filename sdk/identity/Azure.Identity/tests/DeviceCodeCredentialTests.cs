// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;

namespace Azure.Identity.Tests
{
    public class DeviceCodeCredentialTests : ClientTestBase
    {
        public DeviceCodeCredentialTests(bool isAsync) : base(isAsync)
        { }

        private const string ClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";
        private const string TenantId = "a0287521-e002-0026-7112-207c0c000000";
        private const string TenantIdHint = "a0287521-e002-0026-7112-207c0c001234";
        private const string Scope = "https://vault.azure.net/.default";
        private readonly HashSet<string> _requestedCodes = new HashSet<string>();
        private TokenCredentialOptions options = new TokenCredentialOptions();
        private readonly object _requestedCodesLock = new object();
        private string expectedCode;
        private string expectedToken;
        private DateTimeOffset expiresOn;
        private MockMsalPublicClient mockMsalClient;
        private DeviceCodeResult deviceCodeResult;
        private string expectedTenantId = null;

        private Task VerifyDeviceCode(DeviceCodeInfo codeInfo, string expectedCode)
        {
            Assert.AreEqual(expectedCode, codeInfo.DeviceCode);

            return Task.CompletedTask;
        }

        private Task VerifyDeviceCodeAndCancel(DeviceCodeInfo codeInfo, string actualCode, CancellationTokenSource cancelSource)
        {
            Assert.AreEqual(actualCode, codeInfo.DeviceCode);

            cancelSource.Cancel();

            return Task.CompletedTask;
        }

        private async Task VerifyDeviceCodeCallbackCancellationToken(DeviceCodeInfo code, CancellationToken cancellationToken)
        {
            await Task.Delay(2000, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
        }

        private class MockException : Exception
        { }

        private async Task ThrowingDeviceCodeCallback(DeviceCodeInfo code, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            throw new MockException();
        }

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
            mockMsalClient.SilentAuthFactory = (_, tId) =>
            {
                Assert.AreEqual(expectedTenantId, tId);
                return result;
            };
            mockMsalClient.DeviceCodeAuthFactory = (_, _) =>
            {
                // Assert.AreEqual(tenantId, tId);
                return result;
            };
        }

        [Test]
        public async Task AuthenticateWithDeviceCodeMockAsync([Values(null, TenantIdHint)] string tenantId, [Values(true)] bool allowMultiTenantAuthentication)
        {
            options = new TokenCredentialOptions { AllowMultiTenantAuthentication = allowMultiTenantAuthentication };
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolver.Resolve(TenantId, context, options.AllowMultiTenantAuthentication) ;
            var cred = InstrumentClient(
                new DeviceCodeCredential((code, _) => VerifyDeviceCode(code, expectedCode), TenantId, ClientId, options, null, mockMsalClient));

            AccessToken token = await cred.GetTokenAsync(context);

            Assert.AreEqual(token.Token, expectedToken);

            token = await cred.GetTokenAsync(context);

            Assert.AreEqual(token.Token, expectedToken);
        }

        [Test]
        public void RespectsIsPIILoggingEnabled([Values(true, false)] bool isLoggingPIIEnabled)
        {
            var credential = new DeviceCodeCredential(new DeviceCodeCredentialOptions { IsLoggingPIIEnabled = isLoggingPIIEnabled});

            Assert.NotNull(credential.Client);
            Assert.AreEqual(isLoggingPIIEnabled, credential.Client.LogPII);
        }

        [Test]
        [NonParallelizable]
        public async Task AuthenticateWithDeviceCodeNoCallback()
        {
            var capturedOut = new StringBuilder();
            var capturedOutWriter = new StringWriter(capturedOut);
            var stdOut = Console.Out;
            Console.SetOut(capturedOutWriter);

            try
            {
                var client = new DeviceCodeCredential { Client = mockMsalClient };
                var cred = InstrumentClient(client);

                AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new[] { Scope }));

                Assert.AreEqual(token.Token, expectedToken);
                Assert.AreEqual(mockMsalClient.DeviceCodeResult.Message + Environment.NewLine, capturedOut.ToString());

                token = await cred.GetTokenAsync(new TokenRequestContext(new[] { Scope }));

                Assert.AreEqual(token.Token, expectedToken);
                Assert.AreEqual(mockMsalClient.DeviceCodeResult.Message + Environment.NewLine, capturedOut.ToString());
            }
            finally
            {
                Console.SetOut(stdOut);
            }
        }

        [Test]
        public async Task AuthenticateWithDeviceCodeMockVerifyMsalCancellationAsync()
        {
            var cancelSource = new CancellationTokenSource();
            var options = new TokenCredentialOptions();

            var cred = InstrumentClient(
                new DeviceCodeCredential(
                    (code, cancelToken) => VerifyDeviceCodeAndCancel(code, expectedCode, cancelSource),
                    null,
                    ClientId,
                    options,
                    null,
                    mockMsalClient));

            var ex = Assert.CatchAsync<OperationCanceledException>(
                async () => await cred.GetTokenAsync(new TokenRequestContext(new[] { Scope }), cancelSource.Token));

            await Task.CompletedTask;
        }

        [Test]
        public async Task AuthenticateWithDeviceCodeMockVerifyCallbackCancellationAsync()
        {
            var cancelSource = new CancellationTokenSource();
            cancelSource.Cancel();
            var cred = InstrumentClient(new DeviceCodeCredential(VerifyDeviceCodeCallbackCancellationToken, null, ClientId, options, null, mockMsalClient));

            var ex = Assert.CatchAsync<OperationCanceledException>(
                async () => await cred.GetTokenAsync(new TokenRequestContext(new[] { Scope }), cancelSource.Token));
            await Task.CompletedTask;
        }

        [Test]
        public void AuthenticateWithDeviceCodeCallbackThrowsAsync()
        {
            IdentityTestEnvironment testEnvironment = new IdentityTestEnvironment();
            var cancelSource = new CancellationTokenSource();
            var options = new TokenCredentialOptions();

            var cred = InstrumentClient(new DeviceCodeCredential(ThrowingDeviceCodeCallback, null, ClientId, options, null, mockMsalClient));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(
                async () => await cred.GetTokenAsync(new TokenRequestContext(new[] { testEnvironment.KeyvaultScope }), cancelSource.Token));
            Assert.IsInstanceOf(typeof(MockException), ex.InnerException);
        }

        [Test]
        public void DisableAutomaticAuthenticationException()
        {
            var cred = InstrumentClient(
                new DeviceCodeCredential(
                    new DeviceCodeCredentialOptions
                    {
                        DisableAutomaticAuthentication = true, DeviceCodeCallback = (code, cancelToken) => VerifyDeviceCode(code, expectedCode)
                    }));

            var expTokenRequestContext = new TokenRequestContext(new[] { Scope }, Guid.NewGuid().ToString());

            var ex = Assert.ThrowsAsync<AuthenticationRequiredException>(async () => await cred.GetTokenAsync(expTokenRequestContext));

            Assert.AreEqual(expTokenRequestContext, ex.TokenRequestContext);
        }
    }
}
