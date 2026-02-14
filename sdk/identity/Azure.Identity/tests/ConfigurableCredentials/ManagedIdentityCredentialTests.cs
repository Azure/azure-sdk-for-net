// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
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
            bool? UseManagedIdentityPipeline = null,
            TimeSpan? maxRetryDelay = null,
            TimeSpan? retryDelay = null,
            RetryMode? retryMode = null,
            TimeSpan? networkTimeout = null)
        {
            IConfiguration config = _helper.GetConfiguration();
            if (clientId != null)
            {
                config["MyClient:Credential:ManagedIdentityClientId"] = clientId;
            }
            if (resourceId != null)
            {
                config["MyClient:Credential:ManagedIdentityResourceId"] = resourceId;
            }
            if (objectId != null)
            {
                config["MyClient:Credential:ManagedIdentityObjectId"] = objectId;
            }
            // Enable IMDS probe when chained, matching the base test's MIC construction.
            config["MyClient:Credential:IsProbeEnabled"] = isChained.ToString();
            if (UseManagedIdentityPipeline.HasValue)
            {
                config["MyClient:Credential:UseManagedIdentityPipeline"] = UseManagedIdentityPipeline.Value.ToString();
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
            var credential = CreateConfiguredCredential(transport, resourceId: resourceId.ToString(), isForceRefreshEnabled: isForceRefreshEnabled);
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
            bool UseManagedIdentityPipeline = false,
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
                UseManagedIdentityPipeline: UseManagedIdentityPipeline,
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

        // With IsProbeEnabled smuggled through config, the MIC inside DAC behaves
        // identically to the base test's MIC. Since DAC with a single CUE source
        // re-throws the original CUE (CreateAggregateException returns it directly),
        // exception types match the base class behavior.
        protected override Type GetExpectedExceptionType(bool isChained)
            => isChained ? typeof(CredentialUnavailableException) : typeof(AuthenticationFailedException);

        #endregion
    }
}
