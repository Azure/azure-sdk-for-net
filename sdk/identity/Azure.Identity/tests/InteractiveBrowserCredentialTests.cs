﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity.Tests
{
    public class InteractiveBrowserCredentialTests : ClientTestBase
    {
        private string TenantId = "a0287521-e002-0026-7112-207c0c000000";
        private const string TenantIdHint = "a0287521-e002-0026-7112-207c0c001234";
        private const string Scope = "https://vault.azure.net/.default";
        private const string ClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";
        private string expectedCode;
        private string expectedToken;
        private DateTimeOffset expiresOn;
        private MockMsalPublicClient mockMsalClient;
        private DeviceCodeResult deviceCodeResult;
        private string expectedTenantId;

        public InteractiveBrowserCredentialTests(bool isAsync) : base(isAsync)
        { }

        [Test]
        public async Task InteractiveBrowserAcquireTokenInteractiveException()
        {
            string expInnerExMessage = Guid.NewGuid().ToString();

            var mockMsalClient = new MockMsalPublicClient { AuthFactory = (_, _) => { throw new MockClientException(expInnerExMessage); } };

            var credential = InstrumentClient(new InteractiveBrowserCredential(default, "", default, default, mockMsalClient));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.IsNotNull(ex.InnerException);

            Assert.IsInstanceOf(typeof(MockClientException), ex.InnerException);

            Assert.AreEqual(expInnerExMessage, ex.InnerException.Message);

            await Task.CompletedTask;
        }

        [Test]
        public async Task InteractiveBrowserAcquireTokenSilentException()
        {
            string expInnerExMessage = Guid.NewGuid().ToString();
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);

            var mockMsalClient = new MockMsalPublicClient
            {
                AuthFactory = (_, _) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); },
                SilentAuthFactory = (_, _) => { throw new MockClientException(expInnerExMessage); }
            };

            var credential = InstrumentClient(new InteractiveBrowserCredential(default, "", default, default, mockMsalClient));

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expToken, token.Token);

            Assert.AreEqual(expExpiresOn, token.ExpiresOn);

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.IsNotNull(ex.InnerException);

            Assert.IsInstanceOf(typeof(MockClientException), ex.InnerException);

            Assert.AreEqual(expInnerExMessage, ex.InnerException.Message);

            await Task.CompletedTask;
        }

        [Test]
        public async Task InteractiveBrowserRefreshException()
        {
            string expInnerExMessage = Guid.NewGuid().ToString();
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);

            var mockMsalClient = new MockMsalPublicClient
            {
                AuthFactory = (_, _) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); },
                SilentAuthFactory = (_, _) => { throw new MsalUiRequiredException("errorCode", "message"); }
            };

            var credential = InstrumentClient(new InteractiveBrowserCredential(default, "", default, default, mockMsalClient));

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expToken, token.Token);

            Assert.AreEqual(expExpiresOn, token.ExpiresOn);

            mockMsalClient.AuthFactory = (_, _) => { throw new MockClientException(expInnerExMessage); };

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.IsNotNull(ex.InnerException);

            Assert.IsInstanceOf(typeof(MockClientException), ex.InnerException);

            Assert.AreEqual(expInnerExMessage, ex.InnerException.Message);

            await Task.CompletedTask;
        }

        [Test]
        [NonParallelizable]
        public async Task InteractiveBrowserValidateSyncWorkaroundCompatSwitch()
        {
            // once the AppContext switch is set it cannot be unset for this reason this test must sequentially test the following
            // neither Environment variable or AppContext switch is set.
            // environment variable is set and AppContext switch is not set
            // AppContext switch is set
            await ValidateSyncWorkaroundCompatSwitch(!IsAsync);

            using (var envVar = new TestEnvVar("AZURE_IDENTITY_DISABLE_INTERACTIVEBROWSERTHREADPOOLEXECUTION", string.Empty))
            {
                await ValidateSyncWorkaroundCompatSwitch(!IsAsync);
            }

            using (var envVar = new TestEnvVar("AZURE_IDENTITY_DISABLE_INTERACTIVEBROWSERTHREADPOOLEXECUTION", "false"))
            {
                await ValidateSyncWorkaroundCompatSwitch(!IsAsync);
            }

            using (var envVar = new TestEnvVar("AZURE_IDENTITY_DISABLE_INTERACTIVEBROWSERTHREADPOOLEXECUTION", "true"))
            {
                await ValidateSyncWorkaroundCompatSwitch(false);
            }

            using (var envVar = new TestEnvVar("AZURE_IDENTITY_DISABLE_INTERACTIVEBROWSERTHREADPOOLEXECUTION", "1"))
            {
                await ValidateSyncWorkaroundCompatSwitch(false);
            }

            AppContext.SetSwitch("Azure.Identity.DisableInteractiveBrowserThreadpoolExecution", true);

            await ValidateSyncWorkaroundCompatSwitch(false);

            AppContext.SetSwitch("Azure.Identity.DisableInteractiveBrowserThreadpoolExecution", false);

            await ValidateSyncWorkaroundCompatSwitch(!IsAsync);
        }

        [Test]
        public async Task LoginHint([Values(null, "fring@contoso.com")] string loginHint)
        {
            var mockMsalClient = new MockMsalPublicClient
            {
                InteractiveAuthFactory = (_, _, prompt, hintArg, _, _, _) =>
                {
                    Assert.AreEqual(loginHint == null ? Prompt.SelectAccount : Prompt.NoPrompt, prompt);
                    Assert.AreEqual(loginHint, hintArg);
                    return AuthenticationResultFactory.Create(Guid.NewGuid().ToString(), expiresOn: DateTimeOffset.UtcNow.AddMinutes(5));
                }
            };
            var options = new InteractiveBrowserCredentialOptions { LoginHint = loginHint };
            var credential = InstrumentClient(new InteractiveBrowserCredential(default, "", options, default, mockMsalClient));

            await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));
        }

        private async Task ValidateSyncWorkaroundCompatSwitch(bool expectedThreadPoolExecution)
        {
            bool threadPoolExec = false;
            bool inlineExec = false;

            AzureEventSourceListener listener = new AzureEventSourceListener(
                (args, text) =>
                {
                    if (args.EventName == "InteractiveAuthenticationExecutingOnThreadPool")
                    {
                        threadPoolExec = true;
                    }
                    if (args.EventName == "InteractiveAuthenticationExecutingInline")
                    {
                        inlineExec = true;
                    }
                },
                System.Diagnostics.Tracing.EventLevel.Informational);

            var mockClient = new MockMsalPublicClient
            {
                AuthFactory = (_, _) =>
                {
                    return AuthenticationResultFactory.Create(accessToken: Guid.NewGuid().ToString(), expiresOn: DateTimeOffset.UtcNow.AddMinutes(5));
                }
            };

            var credential = InstrumentClient(new InteractiveBrowserCredential(default, "", default, default, mockClient));

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expectedThreadPoolExecution, threadPoolExec);
            Assert.AreEqual(!expectedThreadPoolExecution, inlineExec);
        }

        [Test]
        public void DisableAutomaticAuthenticationException()
        {
            var cred = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { DisableAutomaticAuthentication = true });

            var expTokenRequestContext = new TokenRequestContext(new string[] { "https://vault.azure.net/.default" }, Guid.NewGuid().ToString());

            var ex = Assert.ThrowsAsync<AuthenticationRequiredException>(async () => await cred.GetTokenAsync(expTokenRequestContext).ConfigureAwait(false));

            Assert.AreEqual(expTokenRequestContext, ex.TokenRequestContext);
        }

        [Test]
        public async Task UsesTenantIdHint([Values(null, TenantIdHint)] string tenantId, [Values(true)] bool allowMultiTenantAuthentication)
        {
            TestSetup();
            var options = new InteractiveBrowserCredentialOptions { AllowMultiTenantAuthentication = allowMultiTenantAuthentication };
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolver.Resolve(TenantId, context, options.AllowMultiTenantAuthentication);

            var credential = InstrumentClient(
                new InteractiveBrowserCredential(
                    TenantId,
                    ClientId,
                    options,
                    null,
                    mockMsalClient));

            var actualToken = await credential.GetTokenAsync(context, CancellationToken.None);

            Assert.AreEqual(expectedToken, actualToken.Token, "Token should match");
            Assert.AreEqual(expiresOn, actualToken.ExpiresOn, "expiresOn should match");
        }

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
            mockMsalClient.InteractiveAuthFactory = (_, _, _, _, tenant, _, _) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
            mockMsalClient.SilentAuthFactory = (_, tenant) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
        }
    }
}
