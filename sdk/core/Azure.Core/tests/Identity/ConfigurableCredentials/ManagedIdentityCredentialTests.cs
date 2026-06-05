// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.Tests.Identity.Mock;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

using Azure.Identity;
namespace Azure.Core.Tests.Identity.ConfigurableCredentials.ManagedIdentity
{
    internal class ManagedIdentityCredentialTests : Azure.Core.Tests.Identity.ManagedIdentityCredentialTests
    {
        private readonly ConfigurableCredentialTestHelper<ManagedIdentityCredential> _helper;

        // Tracks the probe-intercepting transport created by the most recent CreateConfiguredCredential
        // call, so probe-focused tests can assert how many ImdsV2 source-detection probes MSAL issued.
        private ProbeInterceptingTransport _lastProbeInterceptingTransport;

        public ManagedIdentityCredentialTests(bool isAsync) : base(isAsync)
        {
            _helper = new ConfigurableCredentialTestHelper<ManagedIdentityCredential>(
                "ManagedIdentity",
                null,
                null,
                InstrumentClient);
        }

        private ConfigurableCredential CreateConfiguredCredential(
            HttpPipelineTransport transport,
            string clientId = null,
            string resourceId = null,
            string objectId = null,
            bool isForceRefreshEnabled = true,
            bool isChained = false,
            TimeSpan? maxRetryDelay = null,
            TimeSpan? retryDelay = null,
            RetryMode? retryMode = null,
            TimeSpan? networkTimeout = null)
        {
            // The ConfigurableCredentials path uses the real MsalManagedIdentityClient, which now
            // routes MSAL's ImdsV2 source-detection probe through the pipeline (and thus the test
            // transport). Wrap the transport so the probe is answered locally and never reaches the
            // inner MockTransport, keeping its request queue limited to the actual token requests.
            if (transport != null)
            {
                var probeInterceptingTransport = new ProbeInterceptingTransport(transport);
                _lastProbeInterceptingTransport = probeInterceptingTransport;
                transport = probeInterceptingTransport;
            }

            IConfiguration config = isChained ? _helper.GetChainedConfiguration() : _helper.GetConfiguration();
            // For chained mode, MI-specific properties go under the source's section.
            string prefix = isChained ? "MyClient:Credential:Sources:0" : "MyClient:Credential";
            if (clientId != null)
            {
                config[$"{prefix}:ManagedIdentityIdKind"] = "ClientId";
                config[$"{prefix}:ManagedIdentityId"] = clientId;
            }
            if (resourceId != null)
            {
                config[$"{prefix}:ManagedIdentityIdKind"] = "ResourceId";
                config[$"{prefix}:ManagedIdentityId"] = resourceId;
            }
            if (objectId != null)
            {
                config[$"{prefix}:ManagedIdentityIdKind"] = "ObjectId";
                config[$"{prefix}:ManagedIdentityId"] = objectId;
            }

            // For chained mode, retry settings go in the source's config section since each source
            // in a ChainedTokenCredential has its own retry configuration.
            // For non-chained mode, retry is set programmatically on the parent options below.
            if (isChained)
            {
                config[$"{prefix}:Retry:MaxDelay"] = (maxRetryDelay ?? TimeSpan.FromMilliseconds(1)).ToString();
                config[$"{prefix}:Retry:Delay"] = (retryDelay ?? TimeSpan.FromMilliseconds(1)).ToString();
                if (retryMode.HasValue) config[$"{prefix}:Retry:Mode"] = retryMode.Value.ToString();
                if (networkTimeout.HasValue) config[$"{prefix}:Retry:NetworkTimeout"] = networkTimeout.Value.ToString();
            }

            // Temporarily clear AZURE_CLIENT_ID so it doesn't interfere with config-based creation.
            // Tests are NonParallelizable so direct env var manipulation is safe.
            var savedClientId = System.Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
            try
            {
                System.Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", null);
                IConfigurationSection credentialSection = config.GetSection("MyClient:Credential");
                var dacOptions = new DefaultAzureCredentialOptions(new CredentialSettings(credentialSection), credentialSection);
                dacOptions.IsForceRefreshEnabled = isForceRefreshEnabled;
                if (isChained && dacOptions.Sources != null)
                {
                    // For chained mode, set Transport and IsForceRefreshEnabled on each source
                    // since credentials are constructed entirely from config (no parent propagation).
                    foreach (var source in dacOptions.Sources)
                    {
                        source.Transport = transport;
                        source.IsForceRefreshEnabled = isForceRefreshEnabled;
                    }
                }
                else
                {
                    dacOptions.Transport = transport;
                }
                if (!isChained)
                {
                    // Non-chained: set retry directly on the parent options (factory clones these).
                    dacOptions.Retry.MaxDelay = maxRetryDelay ?? TimeSpan.FromMilliseconds(1);
                    dacOptions.Retry.Delay = retryDelay ?? TimeSpan.FromMilliseconds(1);
                    if (retryMode.HasValue) dacOptions.Retry.Mode = retryMode.Value;
                    if (networkTimeout.HasValue) dacOptions.Retry.NetworkTimeout = networkTimeout.Value;
                }
                return new ConfigurableCredential(dacOptions);
            }
            finally
            {
                System.Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", savedClientId);
            }
        }

        #region Factory Method Overrides

        protected override TokenCredential CreateCredentialForImds(
            MockTransport transport,
            string clientId = null,
            bool isChained = false,
            bool isForceRefreshEnabled = true,
            Uri authorityHost = null)
        {
            var credential = CreateConfiguredCredential(transport, clientId: clientId, isForceRefreshEnabled: isForceRefreshEnabled, isChained: isChained);
            return InstrumentClient(credential);
        }

        protected override TokenCredential CreateCredentialForImdsWithResourceId(
            MockTransport transport,
            ResourceIdentifier resourceId,
            bool isChained = false,
            bool isForceRefreshEnabled = true)
        {
            var credential = CreateConfiguredCredential(transport, resourceId: resourceId.ToString(), isForceRefreshEnabled: isForceRefreshEnabled, isChained: isChained);
            return InstrumentClient(credential);
        }

        protected override TokenCredential CreateBareCredentialWithOptions(TokenCredentialOptions options)
        {
            var credential = CreateConfiguredCredential(
                options?.Transport as HttpPipelineTransport,
                isChained: options?.IsChainedCredential ?? false,
                maxRetryDelay: options?.Retry.MaxDelay,
                retryDelay: options?.Retry.Delay,
                retryMode: options?.Retry.Mode,
                networkTimeout: options?.Retry.NetworkTimeout);
            return InstrumentClient(credential);
        }

        protected override TokenCredential CreateCredentialForNonImdsSource(
            MockTransport transport,
            string clientId = null,
            string resourceId = null,
            bool isForceRefreshEnabled = true,
            TimeSpan? maxRetryDelay = null)
        {
            var credential = CreateConfiguredCredential(transport, clientId: clientId, resourceId: resourceId, isForceRefreshEnabled: isForceRefreshEnabled);
            return InstrumentClient(credential);
        }

        protected override TokenCredential CreateCredentialForImdsWithRetryOptions(
            MockTransport transport,
            string clientId = null,
            bool isChained = false,
            bool isForceRefreshEnabled = true,
            bool isManagedIdentityPipeline = false,
            TimeSpan? maxRetryDelay = null,
            TimeSpan? retryDelay = null,
            RetryMode? retryMode = null,
            TimeSpan? networkTimeout = null)
        {
            var credential = CreateConfiguredCredential(
                transport,
                clientId: clientId,
                isForceRefreshEnabled: isForceRefreshEnabled,
                isChained: isChained,
                maxRetryDelay: maxRetryDelay,
                retryDelay: retryDelay,
                retryMode: retryMode,
                networkTimeout: networkTimeout);
            return InstrumentClient(credential);
        }

        protected override TokenCredential CreateCredentialWithManagedIdentityId(
            MockTransport transport,
            ManagedIdentityId managedIdentityId,
            bool isForceRefreshEnabled = true)
        {
            string idStr = managedIdentityId.ToString();
            string clientId = null;
            string resourceId = null;
            string objectId = null;

            if (idStr.StartsWith("ClientId "))
                clientId = idStr.Substring("ClientId ".Length);
            else if (idStr.StartsWith("ResourceId "))
                resourceId = idStr.Substring("ResourceId ".Length);
            else if (idStr.StartsWith("ObjectId "))
                objectId = idStr.Substring("ObjectId ".Length);

            var credential = CreateConfiguredCredential(transport, clientId: clientId, resourceId: resourceId, objectId: objectId, isForceRefreshEnabled: isForceRefreshEnabled);
            return InstrumentClient(credential);
        }

        #endregion

        // These overrides exist because the base tests use isManagedIdentityPipeline as an
        // independent parameter, while the configurable path derives it from IsInChain.
        // Single cred selection (IsInChain=false) → standard pipeline (no 404/410 retries, MaxRetries=3).
        // Chained (IsInChain=true) → IMDS pipeline with probe-skip.

        [Test]
        public override async Task RetriesOnRetriableStatusCode([Values(404, 410, 500)] int status)
        {
            int tryCount = 0;
            using var environment = new TestEnvVar(
                new()
                {
                    { "MSI_ENDPOINT", null },
                    { "MSI_SECRET", null },
                    { "IDENTITY_ENDPOINT", null },
                    { "IDENTITY_HEADER", null },
                    { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null }
                });
            var errorMessage = "Some error happened";
            var mockTransport = new MockTransport(request =>
            {
                tryCount++;
                return CreateErrorMockResponse(status, errorMessage);
            });
            var credential = CreateCredentialForImdsWithRetryOptions(mockTransport, clientId: "mock-client-id", maxRetryDelay: TimeSpan.Zero, isManagedIdentityPipeline: true);

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
            Assert.That(ex.Message, Does.Contain(errorMessage));

            // Single cred source uses standard pipeline: 404/410 not retriable, 500 uses MaxRetries=3
            int expectedTries = status == 500 ? 4 : 1;
            Assert.That(tryCount, Is.EqualTo(expectedTries));

            await Task.CompletedTask;
        }

        [NonParallelizable]
        [Test]
        public override async Task VerifyMsiUnavailableOnIMDSAggregateExcpetion()
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });
            var mockTransport = new MockTransport(req =>
            {
                throw new OperationCanceledException();
            });
            // isChained:true → array CredentialSource → ChainedTokenCredential wrapping MI
            var credential = CreateCredentialForImdsWithRetryOptions(mockTransport, isChained: true, retryDelay: TimeSpan.FromMilliseconds(1), retryMode: RetryMode.Fixed, networkTimeout: TimeSpan.FromMilliseconds(100));

            // CTC wraps non-CUE exceptions (like OCE from IMDS timeout) in AuthenticationFailedException
            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
            Assert.That(ex.Message, Does.Contain("The operation was canceled"));

            await Task.CompletedTask;
        }

        // The base body seeds the inner transport with a 400-then-success queue, where the 400 is
        // consumed by MSAL's source-detection probe. In the ConfigurableCredentials path the probe is
        // intercepted by ProbeInterceptingTransport (and answered locally), so the inner transport
        // must only return the token success response.
        [NonParallelizable]
        [Test]
        public override async Task VerifyImdsRequestWithClientIdMock()
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var response = CreateSuccessResponse(ExpectedToken);
            var mockTransport = new MockTransport(response);
            var credential = CreateCredentialForImds(mockTransport, clientId: "mock-client-id", isChained: true);

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(ExpectedToken, actualToken.Token);

            MockRequest request = mockTransport.Requests[0];

            string query = request.Uri.Query;

            Assert.AreEqual(request.Uri.Host, "169.254.169.254");
            Assert.AreEqual(request.Uri.Path, "/metadata/identity/oauth2/token");
            Assert.IsTrue(query.Contains("api-version=2018-02-01"));
            Assert.IsTrue(query.Contains($"resource={ScopeUtilities.ScopesToResource(MockScopes.Default)}"));
            Assert.IsTrue(query.Contains($"{Constants.ManagedIdentityClientId}=mock-client-id"));
        }

        // The base body detects the probe via the absence of the Metadata header on the inner
        // transport. In the ConfigurableCredentials path the probe never reaches the inner transport
        // (it is intercepted), so probe counting is observed on the ProbeInterceptingTransport instead.
        [NonParallelizable]
        [Test]
        public override async Task VerifyImdsSendsProbeOnlyOnFirstRequest()
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var mockTransport = new MockTransport(req => CreateSuccessResponse(ExpectedToken));
            var credential = CreateCredentialForImds(mockTransport, clientId: "mock-client-id", isChained: true);
            var probeTransport = _lastProbeInterceptingTransport;

            await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(ExpectedToken, actualToken.Token);
            Assert.AreEqual(1, probeTransport.ProbeCount, "Probe was sent more than once.");
        }
    }
}
