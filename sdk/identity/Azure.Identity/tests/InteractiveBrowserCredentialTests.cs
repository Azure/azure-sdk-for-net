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
    public class InteractiveBrowserCredentialTests : CredentialTestBase<InteractiveBrowserCredentialOptions>
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
        public async Task InteractiveBrowserRefreshException()
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
        public async Task InteractiveBrowserValidateSyncWorkaroundCompatSwitch()
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
            var options = new InteractiveBrowserCredentialOptions() { AdditionallyAllowedTenants = { TenantIdHint } };
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolverBase.Default.Resolve(TenantId, context, TenantIdResolverBase.AllTenants);

            var credential = InstrumentClient(
                new InteractiveBrowserCredential(
                    TenantId,
                    ClientId,
                    options,
                    null,
                    mockPublicMsalClient));

            var actualToken = await credential.GetTokenAsync(context, CancellationToken.None);

            Assert.AreEqual(expectedToken, actualToken.Token, "Token should match");
            Assert.AreEqual(expiresOn, actualToken.ExpiresOn, "expiresOn should match");
        }

        public class ExtendedInteractiveBrowserCredentialOptions : InteractiveBrowserCredentialOptions, IMsalPublicClientInitializerOptions
        {
            private Action<PublicClientApplicationBuilder> _beforeBuildClient;

            public ExtendedInteractiveBrowserCredentialOptions(Action<PublicClientApplicationBuilder> beforeBuildClient)
            {
                _beforeBuildClient = beforeBuildClient;
            }

            public bool IsProofOfPossessionRequired { get; set; }

            public bool UseDefaultBrokerAccount { get; set; }

            Action<PublicClientApplicationBuilder> IMsalPublicClientInitializerOptions.BeforeBuildClient { get { return _beforeBuildClient; } }
        }

        [Test]
        public async Task InvokesBeforeBuildClientOnExtendedOptions()
        {
            bool beforeBuildClientInvoked = false;

            var cancelSource = new CancellationTokenSource(2000);

            var options = new ExtendedInteractiveBrowserCredentialOptions(builder =>
            {
                Assert.NotNull(builder);
                beforeBuildClientInvoked = true;
                cancelSource.Cancel();
            }
            );

            var credential = InstrumentClient(new InteractiveBrowserCredential(options));

            try
            {
                await credential.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" }), cancelSource.Token);
            }
            catch (OperationCanceledException) { }

            Assert.True(beforeBuildClientInvoked);
        }

        [Test]
        public void FailsWithCredentialUnavailableExceptionWhenChainedInBrokerMode()
        {
            bool beforeBuildClientInvoked = false;

            var cancelSource = new CancellationTokenSource(2000);

            var options = new ExtendedInteractiveBrowserCredentialOptions(builder =>
            {
                Assert.NotNull(builder);
                beforeBuildClientInvoked = true;
                cancelSource.Cancel();
            });
            options.UseDefaultBrokerAccount = true;
            options.IsChainedCredential = true;

            var credential = InstrumentClient(new InteractiveBrowserCredential(options));

            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" }), cancelSource.Token));

            Assert.True(beforeBuildClientInvoked);
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
            var options = new InteractiveBrowserCredentialOptions()
            {
                BrowserCustomization = new BrowserCustomizationOptions()
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    UseEmbeddedWebView = false,
#pragma warning restore CS0618 // Type or member is obsolete
                    SuccessMessage = htmlMessageSuccess,
                    ErrorMessage = htmlMessageError
                }
            };

            var credential = InstrumentClient(new InteractiveBrowserCredential(default, "", options, default, mockMsalClient));

            await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));
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
            var options = new InteractiveBrowserCredentialOptions()
            {
                BrowserCustomization = new BrowserCustomizationOptions()
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    UseEmbeddedWebView = useEmbeddedWebView,
#pragma warning restore CS0618 // Type or member is obsolete
                    ErrorMessage = htmlMessageError
                }
            };

            var credential = InstrumentClient(new InteractiveBrowserCredential(default, "", options, default, mockMsalClient));

            await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));
        }
    }
}
