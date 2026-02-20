// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.InteractiveBrowser
{
    /// <summary>
    /// Tests for InteractiveBrowserCredential accessed through ConfigurableCredential.
    /// Inherits from Tests.InteractiveBrowserCredentialTests to get all InteractiveBrowser-specific test cases.
    /// Overrides factory methods to create credentials via IConfiguration.
    /// </summary>
    internal class InteractiveBrowserCredentialTests : Tests.InteractiveBrowserCredentialTests
    {
        private readonly ConfigurableCredentialTestHelper<InteractiveBrowserCredential> _helper;

        public InteractiveBrowserCredentialTests(bool isAsync) : base(isAsync)
        {
            _helper = new ConfigurableCredentialTestHelper<InteractiveBrowserCredential>(
                "InteractiveBrowser",
                null,
                null,
                InstrumentClient);
        }

        /// <summary>
        /// Creates a configured credential from IConfiguration, optionally injecting a mock MSAL client.
        /// All factory methods delegate to this to avoid duplication.
        /// </summary>
        private TokenCredential CreateFromConfig(
            MockMsalPublicClient msalClient = null,
            string tenantId = null,
            bool addTenantIdHint = false,
            bool? isAccountIdentifierLoggingEnabled = null,
            bool? disableAutomaticAuthentication = null,
            string loginHint = null,
            BrowserCustomizationOptions browserCustomization = null,
            AuthenticationRecord authenticationRecord = null)
        {
            IConfiguration config = _helper.GetConfiguration();
            config["MyClient:Credential:InteractiveBrowserCredentialClientId"] = ClientId;
            if (tenantId != null)
            {
                config["MyClient:Credential:TenantId"] = tenantId;
            }
            if (addTenantIdHint)
            {
                config["MyClient:Credential:AdditionallyAllowedTenants:0"] = TenantIdHint;
            }
            if (isAccountIdentifierLoggingEnabled != null)
            {
                config["MyClient:Credential:Diagnostics:IsAccountIdentifierLoggingEnabled"] = isAccountIdentifierLoggingEnabled.Value.ToString();
            }
            if (disableAutomaticAuthentication != null)
            {
                config["MyClient:Credential:DisableAutomaticAuthentication"] = disableAutomaticAuthentication.Value.ToString();
            }
            if (loginHint != null)
            {
                config["MyClient:Credential:LoginHint"] = loginHint;
            }
            if (browserCustomization?.SuccessMessage != null)
            {
                config["MyClient:Credential:BrowserCustomization:SuccessMessage"] = browserCustomization.SuccessMessage;
            }
            if (browserCustomization?.ErrorMessage != null)
            {
                config["MyClient:Credential:BrowserCustomization:ErrorMessage"] = browserCustomization.ErrorMessage;
            }
#pragma warning disable CS0618 // Type or member is obsolete
            if (browserCustomization?.UseEmbeddedWebView != null)
            {
                config["MyClient:Credential:BrowserCustomization:UseEmbeddedWebView"] = browserCustomization.UseEmbeddedWebView.Value.ToString();
            }
#pragma warning restore CS0618 // Type or member is obsolete
            WriteAuthenticationRecord(config, authenticationRecord);

            return CreateCredentialFromConfig(config, msalClient);
        }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
            => CreateFromConfig(mockPublicMsalClient, tenantId: TenantId, isAccountIdentifierLoggingEnabled: options.Diagnostics.IsAccountIdentifierLoggingEnabled);

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
        {
            IConfiguration configuration = _helper.GetConfigurationFromCommonCredentialTestConfig<InteractiveBrowserCredentialOptions>(config);
            configuration["MyClient:Credential:InteractiveBrowserCredentialClientId"] = ClientId;

            string resolvedTenantId = config.RequestContext.TenantId ?? config.TenantId ?? TenantId;
            var authRecord = config.AuthenticationRecord ?? new AuthenticationRecord(ExpectedUsername, "login.windows.net", $"{ObjectId}.{resolvedTenantId}", resolvedTenantId, ClientId);
            WriteAuthenticationRecord(configuration, authRecord);

            ConfigurableCredential credential;
            using (new TestEnvVar("AZURE_TENANT_ID", null))
            {
                credential = _helper.GetCredentialFromConfig(configuration, config.Transport);
            }

            var ibc = _helper.GetUnderlyingCredential(credential);

            if (config.MockPublicMsalClient != null)
            {
                // Inject the provided mock MSAL client directly.
                typeof(InteractiveBrowserCredential)
                    .GetField("<Client>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance)
                    .SetValue(ibc, config.MockPublicMsalClient);
            }
            else
            {
                // Transport test: keep the real MsalPublicClient but patch its token cache
                // so MSAL does silent auth via MockTransport instead of launching a browser.
                var cacheOptions = config.TokenCachePersistenceOptions;
                if (cacheOptions == null)
                {
                    var mockBytes = CredentialTestHelpers.GetMockCacheBytes(ObjectId, ExpectedUsername, ClientId, resolvedTenantId, "token", "refreshToken", config.AuthorityHost.Host);
                    cacheOptions = new MockTokenCache(
                        () => Task.FromResult<ReadOnlyMemory<byte>>(mockBytes),
                        args => Task.FromResult<ReadOnlyMemory<byte>>(mockBytes));
                }

                var realClient = ibc.Client;
                typeof(MsalPublicClient).BaseType
                    .GetField("_tokenCachePersistenceOptions", BindingFlags.NonPublic | BindingFlags.Instance)
                    .SetValue(realClient, cacheOptions);
            }

            return _helper.InstrumentCredential(credential);
        }

        private static void WriteAuthenticationRecord(IConfiguration config, AuthenticationRecord authRecord)
        {
            if (authRecord == null)
            {
                return;
            }
            config["MyClient:Credential:AuthenticationRecord:Username"] = authRecord.Username;
            config["MyClient:Credential:AuthenticationRecord:Authority"] = authRecord.Authority;
            config["MyClient:Credential:AuthenticationRecord:HomeAccountId"] = authRecord.HomeAccountId;
            config["MyClient:Credential:AuthenticationRecord:TenantId"] = authRecord.TenantId;
            config["MyClient:Credential:AuthenticationRecord:ClientId"] = authRecord.ClientId;
        }

        private TokenCredential CreateCredentialFromConfig(IConfiguration config, MockMsalPublicClient msalClient, HttpPipelineTransport transport = null)
        {
            ConfigurableCredential credential;
            using (new TestEnvVar("AZURE_TENANT_ID", null))
            {
                credential = _helper.GetCredentialFromConfig(config, transport);
            }

            if (msalClient != null)
            {
                var ibc = _helper.GetUnderlyingCredential(credential);
                typeof(InteractiveBrowserCredential)
                    .GetField("<Client>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance)
                    .SetValue(ibc, msalClient);
            }

            return _helper.InstrumentCredential(credential);
        }

        protected override TokenCredential CreateCredential(MockMsalPublicClient msalClient, string tenantId = null, bool addTenantIdHint = false)
            => CreateFromConfig(msalClient, tenantId: tenantId, addTenantIdHint: addTenantIdHint);

        protected override TokenCredential CreateBareCredential()
            => CreateFromConfig();

        protected override Type GetExpectedExceptionType(bool isChained)
            => typeof(CredentialUnavailableException);

        protected override TokenCredential CreateCredentialWithDisableAutomaticAuth()
            => CreateFromConfig(disableAutomaticAuthentication: true);

        protected override TokenCredential CreateCredentialWithLoginHint(MockMsalPublicClient msalClient, string loginHint)
            => CreateFromConfig(msalClient, loginHint: loginHint);

        protected override TokenCredential CreateCredentialWithBrowserCustomization(MockMsalPublicClient msalClient, BrowserCustomizationOptions browserCustomization)
            => CreateFromConfig(msalClient, browserCustomization: browserCustomization);

        protected override void CreateCredentialForTenantValidation(string tenantId)
            => _helper.CreateCredentialForTenantValidation(tenantId);

        // ConfigurableCredential wraps in DefaultAzureCredential which catches AuthenticationRequiredException
        // (a subclass of CredentialUnavailableException) and wraps it in an aggregate CredentialUnavailableException.
        public override void DisableAutomaticAuthenticationException()
        {
            var cred = CreateCredentialWithDisableAutomaticAuth();
            var expTokenRequestContext = new TokenRequestContext(new string[] { "https://vault.azure.net/.default" }, Guid.NewGuid().ToString());

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await cred.GetTokenAsync(expTokenRequestContext, default).ConfigureAwait(false));
            Assert.IsNotNull(ex);
        }

        public override async Task InteractiveBrowserAcquireTokenInteractiveException()
            => Assert.Ignore("MSAL-specific test does not apply to configurable credential");
        public override async Task InteractiveBrowserAcquireTokenSilentException()
            => Assert.Ignore("MSAL-specific test does not apply to configurable credential");
        public override async Task InteractiveBrowserRefreshException()
            => Assert.Ignore("MSAL-specific test does not apply to configurable credential");
        public override async Task InteractiveBrowserValidateSyncWorkaroundCompatSwitch()
            => Assert.Ignore("Compat switch test does not apply to configurable credential");
    }
}
