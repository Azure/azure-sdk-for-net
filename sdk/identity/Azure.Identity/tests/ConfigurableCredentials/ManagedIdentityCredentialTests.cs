// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.ManagedIdentity
{
    internal class ManagedIdentityCredentialTests : Tests.ManagedIdentityCredentialTests
    {
        private readonly ConfigurableCredentialTestHelper<ManagedIdentityCredential> _helper;

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
            IConfiguration config = isChained ? _helper.GetChainedConfiguration() : _helper.GetConfiguration();
            if (clientId != null)
            {
                config["MyClient:Credential:ManagedIdentityIdKind"] = "ClientId";
                config["MyClient:Credential:ManagedIdentityId"] = clientId;
            }
            if (resourceId != null)
            {
                config["MyClient:Credential:ManagedIdentityIdKind"] = "ResourceId";
                config["MyClient:Credential:ManagedIdentityId"] = resourceId;
            }
            if (objectId != null)
            {
                config["MyClient:Credential:ManagedIdentityIdKind"] = "ObjectId";
                config["MyClient:Credential:ManagedIdentityId"] = objectId;
            }

            // Temporarily clear AZURE_CLIENT_ID so it doesn't interfere with config-based creation.
            // Tests are NonParallelizable so direct env var manipulation is safe.
            var savedClientId = System.Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
            try
            {
                System.Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", null);
                IConfigurationSection credentialSection = config.GetSection("MyClient:Credential");
                var dacOptions = new DefaultAzureCredentialOptions(new CredentialSettings(credentialSection), credentialSection);
                dacOptions.Transport = transport;
                dacOptions.IsForceRefreshEnabled = isForceRefreshEnabled;
                // Use fast retry defaults to avoid test timeouts from pipeline retry delays.
                // Tests that need specific retry behavior pass explicit values.
                dacOptions.Retry.MaxDelay = maxRetryDelay ?? TimeSpan.FromMilliseconds(1);
                dacOptions.Retry.Delay = retryDelay ?? TimeSpan.FromMilliseconds(1);
                if (retryMode.HasValue) dacOptions.Retry.Mode = retryMode.Value;
                if (networkTimeout.HasValue) dacOptions.Retry.NetworkTimeout = networkTimeout.Value;
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
    }
}
