// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class DeviceCodeCredentialTests : CredentialTestBase<DeviceCodeCredentialOptions>
    {
        public DeviceCodeCredentialTests(bool isAsync) : base(isAsync)
        { }

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

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options) => InstrumentClient(
            new DeviceCodeCredential((code, _) => VerifyDeviceCode(code, expectedCode), TenantId, ClientId, options, null, mockPublicMsalClient));

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
        {
            expectedCode = "some-code-created in DeviceCodeCredentialTests.GetTokenCredential";
            var options = new DeviceCodeCredentialOptions
            {
                AdditionallyAllowedTenants = config.AdditionallyAllowedTenants,
                DisableInstanceDiscovery = config.DisableInstanceDiscovery,
                IsUnsafeSupportLoggingEnabled = config.IsUnsafeSupportLoggingEnabled,
                AuthorityHost = config.AuthorityHost,
            };
            if (config.Transport != null)
            {
                options.Transport = config.Transport;
            }
            if (config.TokenCachePersistenceOptions != null)
            {
                options.TokenCachePersistenceOptions = config.TokenCachePersistenceOptions;
            }
            if (config.AuthenticationRecord != null)
            {
                options.AuthenticationRecord = config.AuthenticationRecord;
            }
            var pipeline = CredentialPipeline.GetInstance(options);
            return InstrumentClient(new DeviceCodeCredential((code, _) =>
            {
                return Task.CompletedTask;
            }, config.TenantId, ClientId, options, pipeline, config.MockPublicMsalClient));
        }

        [SetUp]
        public void Setup()
        {
            TestSetup();
        }

        [Test]
        public async Task AuthenticateWithDeviceCodeMockAsync([Values(null, TenantIdHint)] string tenantId, [Values(true)] bool allowMultiTenantAuthentication)
        {
            var options = new DeviceCodeCredentialOptions { AdditionallyAllowedTenants = { TenantIdHint } };
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolverBase.Default.Resolve(TenantId, context, TenantIdResolverBase.AllTenants);
            var cred = InstrumentClient(
                new DeviceCodeCredential((code, _) => VerifyDeviceCode(code, expectedCode), TenantId, ClientId, options, null, mockPublicMsalClient));

            AccessToken token = await cred.GetTokenAsync(context);

            Assert.AreEqual(token.Token, expectedToken);

            token = await cred.GetTokenAsync(context);

            Assert.AreEqual(token.Token, expectedToken);
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
                var client = new DeviceCodeCredential { Client = mockPublicMsalClient };
                var cred = InstrumentClient(client);

                AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new[] { Scope }));

                Assert.AreEqual(token.Token, expectedToken);
                Assert.AreEqual(mockPublicMsalClient.DeviceCodeResult.Message + Environment.NewLine, capturedOut.ToString());

                token = await cred.GetTokenAsync(new TokenRequestContext(new[] { Scope }));

                Assert.AreEqual(token.Token, expectedToken);
                Assert.AreEqual(mockPublicMsalClient.DeviceCodeResult.Message + Environment.NewLine, capturedOut.ToString());
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
                    mockPublicMsalClient));

            var ex = Assert.CatchAsync<OperationCanceledException>(
                async () => await cred.GetTokenAsync(new TokenRequestContext(new[] { Scope }), cancelSource.Token));

            await Task.CompletedTask;
        }

        [Test]
        public async Task AuthenticateWithDeviceCodeMockVerifyCallbackCancellationAsync()
        {
            var cancelSource = new CancellationTokenSource();
            cancelSource.Cancel();
            var cred = InstrumentClient(new DeviceCodeCredential(VerifyDeviceCodeCallbackCancellationToken, null, ClientId, options, null, mockPublicMsalClient));

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

            var cred = InstrumentClient(new DeviceCodeCredential(ThrowingDeviceCodeCallback, null, ClientId, options, null, mockPublicMsalClient));

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
                        DisableAutomaticAuthentication = true,
                        DeviceCodeCallback = (code, cancelToken) => VerifyDeviceCode(code, expectedCode)
                    }));

            var expTokenRequestContext = new TokenRequestContext(new[] { Scope }, Guid.NewGuid().ToString());

            var ex = Assert.ThrowsAsync<AuthenticationRequiredException>(async () => await cred.GetTokenAsync(expTokenRequestContext));

            Assert.AreEqual(expTokenRequestContext, ex.TokenRequestContext);
        }
    }
}
