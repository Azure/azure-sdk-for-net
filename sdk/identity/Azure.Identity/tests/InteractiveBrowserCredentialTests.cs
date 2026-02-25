// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;

using NUnit.Framework;

namespace Azure.Identity.Tests
{
    internal class InteractiveBrowserCredentialTests : CredentialTestBase<InteractiveBrowserCredentialOptions>
    {
        public InteractiveBrowserCredentialTests(bool isAsync) : base(isAsync)
        { }
        public override TokenCredential GetTokenCredential(TokenCredentialOptions options) => InstrumentClient(
            new InteractiveBrowserCredential(TenantId, ClientId, options, null, mockPublicMsalClient));

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
        {
            // Configure mock cache to return a token for the expected user
            string resolvedTenantId = config.RequestContext.TenantId ?? config.TenantId ?? TenantId;
            var mockBytes = CredentialTestHelpers.GetMockCacheBytes(ObjectId, ExpectedUsername, ClientId, resolvedTenantId, "token", "refreshToken", config.AuthorityHost.Host);
            var tokenCacheOptions = new MockTokenCache(
                () => Task.FromResult<ReadOnlyMemory<byte>>(mockBytes),
                args => Task.FromResult<ReadOnlyMemory<byte>>(mockBytes));

            var options = new InteractiveBrowserCredentialOptions
            {
                DisableInstanceDiscovery = config.DisableInstanceDiscovery,
                TokenCachePersistenceOptions = tokenCacheOptions,
                AdditionallyAllowedTenants = config.AdditionallyAllowedTenants,
                AuthenticationRecord = new AuthenticationRecord(ExpectedUsername, "login.windows.net", $"{ObjectId}.{resolvedTenantId}", resolvedTenantId, ClientId),
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
            return InstrumentClient(new InteractiveBrowserCredential(config.TenantId, ClientId, options, pipeline, config.MockPublicMsalClient));
        }

        #region Virtual Factory Methods
        protected virtual TokenCredential CreateCredential(MockMsalPublicClient msalClient, string tenantId = null, bool addTenantIdHint = false)
        {
            var options = new InteractiveBrowserCredentialOptions();
            if (addTenantIdHint)
            {
                options.AdditionallyAllowedTenants.Add(TenantIdHint);
            }
            return InstrumentClient(new InteractiveBrowserCredential(tenantId, ClientId, options, null, msalClient));
        }

        protected virtual TokenCredential CreateCredentialWithDisableAutomaticAuth()
        {
            return new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { DisableAutomaticAuthentication = true });
        }

        protected virtual TokenCredential CreateCredentialWithLoginHint(MockMsalPublicClient msalClient, string loginHint)
        {
            var options = new InteractiveBrowserCredentialOptions { LoginHint = loginHint };
            return InstrumentClient(new InteractiveBrowserCredential(default, "", options, default, msalClient));
        }

        protected virtual TokenCredential CreateCredentialWithBrowserCustomization(MockMsalPublicClient msalClient, BrowserCustomizationOptions browserCustomization)
        {
            var options = new InteractiveBrowserCredentialOptions { BrowserCustomization = browserCustomization };
            return InstrumentClient(new InteractiveBrowserCredential(default, "", options, default, msalClient));
        }

        protected virtual TokenCredential CreateBareCredential()
        {
            return InstrumentClient(new InteractiveBrowserCredential());
        }

        /// <summary>
        /// Creates a credential with only a tenant ID for construction validation tests.
        /// No instrumentation needed since the credential is never used to get a token.
        /// </summary>
        protected virtual void CreateCredentialForTenantValidation(string tenantId)
        {
            new InteractiveBrowserCredential(tenantId, ClientId);
        }

        /// <summary>
        /// Returns the expected exception type for error scenarios.
        /// Base: AuthenticationFailedException when not chained, CredentialUnavailableException when chained.
        /// ConfigurableCredential always wraps in DefaultAzureCredential (chained), so always CredentialUnavailableException.
        /// </summary>
        protected virtual Type GetExpectedExceptionType(bool isChained)
            => isChained ? typeof(CredentialUnavailableException) : typeof(AuthenticationFailedException);
        #endregion

        [Test]
        public virtual async Task InteractiveBrowserAcquireTokenInteractiveException()
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
        public virtual async Task InteractiveBrowserAcquireTokenSilentException()
        {
            string expInnerExMessage = Guid.NewGuid().ToString();
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);

            var mockMsalClient = new MockMsalPublicClient
            {
                AuthFactory = (_, _) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); },
                SilentAuthFactory = (_, _, _, _, _) => { throw new MockClientException(expInnerExMessage); }
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
        public virtual async Task InteractiveBrowserRefreshException()
        {
            string expInnerExMessage = Guid.NewGuid().ToString();
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);

            var mockMsalClient = new MockMsalPublicClient
            {
                AuthFactory = (_, _) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); },
                SilentAuthFactory = (_, _, _, _, _) => { throw new MsalUiRequiredException("errorCode", "message"); }
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
        public virtual async Task InteractiveBrowserValidateSyncWorkaroundCompatSwitch()
        {
            // once the AppContext switch is set it cannot be unset for this reason this test must sequentially test the following
            // neither Environment variable or AppContext switch is set.
            // environment variable is set and AppContext switch is not set
            // AppContext switch is set
            await ValidateSyncWorkaroundCompatSwitch(Thread.CurrentThread.GetApartmentState() == ApartmentState.STA);

            using (var envVar = new TestEnvVar("AZURE_IDENTITY_DISABLE_INTERACTIVEBROWSERTHREADPOOLEXECUTION", string.Empty))
            {
                await ValidateSyncWorkaroundCompatSwitch(Thread.CurrentThread.GetApartmentState() == ApartmentState.STA);
            }

            using (var envVar = new TestEnvVar("AZURE_IDENTITY_DISABLE_INTERACTIVEBROWSERTHREADPOOLEXECUTION", "false"))
            {
                await ValidateSyncWorkaroundCompatSwitch(Thread.CurrentThread.GetApartmentState() == ApartmentState.STA);
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

            await ValidateSyncWorkaroundCompatSwitch(Thread.CurrentThread.GetApartmentState() == ApartmentState.STA);
        }

        [Test]
        public async Task LoginHint([Values(null, "fring@contoso.com")] string loginHint)
        {
            var mockMsalClient = new MockMsalPublicClient
            {
                InteractiveAuthFactory = (_, _, prompt, hintArg, _, _, _, _) =>
                {
                    Assert.AreEqual(loginHint == null ? Prompt.SelectAccount : Prompt.NoPrompt, prompt);
                    Assert.AreEqual(loginHint, hintArg);
                    return AuthenticationResultFactory.Create(Guid.NewGuid().ToString(), expiresOn: DateTimeOffset.UtcNow.AddMinutes(5));
                }
            };
            var credential = CreateCredentialWithLoginHint(mockMsalClient, loginHint);

            await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
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
        public virtual void DisableAutomaticAuthenticationException()
        {
            var cred = CreateCredentialWithDisableAutomaticAuth();

            var expTokenRequestContext = new TokenRequestContext(new string[] { "https://vault.azure.net/.default" }, Guid.NewGuid().ToString());

            var ex = Assert.ThrowsAsync<AuthenticationRequiredException>(async () => await cred.GetTokenAsync(expTokenRequestContext, default).ConfigureAwait(false));

            Assert.AreEqual(expTokenRequestContext, ex.TokenRequestContext);
        }

        [Test]
        public async Task UsesTenantIdHint([Values(null, TenantIdHint)] string tenantId, [Values(true)] bool allowMultiTenantAuthentication)
        {
            TestSetup();
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolverBase.Default.Resolve(TenantId, context, TenantIdResolverBase.AllTenants);

            var credential = CreateCredential(mockPublicMsalClient, TenantId, addTenantIdHint: true);

            var actualToken = await credential.GetTokenAsync(context, CancellationToken.None);

            Assert.AreEqual(expectedToken, actualToken.Token, "Token should match");
            Assert.AreEqual(expiresOn, actualToken.ExpiresOn, "expiresOn should match");
        }

        [Test]
        public async Task BrowserCustomizationsHtmlMessage([Values(null, "<p> Login Successfully.</p>")] string htmlMessageSuccess, [Values(null, "<p> An error occured: {0}. Details {1}</p>")] string htmlMessageError)
        {
            var mockMsalClient = new MockMsalPublicClient
            {
                InteractiveAuthFactory = (_, _, _, _, _, _, browserOptions, _) =>
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    Assert.AreEqual(false, browserOptions.UseEmbeddedWebView);
#pragma warning restore CS0618 // Type or member is obsolete
                    Assert.AreEqual(htmlMessageSuccess, browserOptions.SuccessMessage);
                    Assert.AreEqual(htmlMessageError, browserOptions.ErrorMessage);
                    return AuthenticationResultFactory.Create(Guid.NewGuid().ToString(), expiresOn: DateTimeOffset.UtcNow.AddMinutes(5));
                }
            };
            var browserCustomization = new BrowserCustomizationOptions()
            {
#pragma warning disable CS0618 // Type or member is obsolete
                UseEmbeddedWebView = false,
#pragma warning restore CS0618 // Type or member is obsolete
                SuccessMessage = htmlMessageSuccess,
                ErrorMessage = htmlMessageError
            };

            var credential = CreateCredentialWithBrowserCustomization(mockMsalClient, browserCustomization);

            await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
        }

        [Test]
        public async Task BrowserCustomizedUseEmbeddedWebView([Values(null, true, false)] bool useEmbeddedWebView, [Values(null, "<p> An error occured: {0}. Details {1}</p>")] string htmlMessageError)
        {
            var mockMsalClient = new MockMsalPublicClient
            {
                InteractiveAuthFactory = (_, _, _, _, _, _, browserOptions, _) =>
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    Assert.AreEqual(useEmbeddedWebView, browserOptions.UseEmbeddedWebView);
#pragma warning restore CS0618 // Type or member is obsolete
                    Assert.AreEqual(htmlMessageError, browserOptions.ErrorMessage);
                    return AuthenticationResultFactory.Create(Guid.NewGuid().ToString(), expiresOn: DateTimeOffset.UtcNow.AddMinutes(5));
                }
            };
            var browserCustomization = new BrowserCustomizationOptions()
            {
#pragma warning disable CS0618 // Type or member is obsolete
                UseEmbeddedWebView = useEmbeddedWebView,
#pragma warning restore CS0618 // Type or member is obsolete
                ErrorMessage = htmlMessageError
            };

            var credential = CreateCredentialWithBrowserCustomization(mockMsalClient, browserCustomization);

            await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
        }
    }
}
