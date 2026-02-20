// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Reflection;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials
{
    /// <summary>
    /// Standalone helper for creating and instrumenting ConfigurableCredentials in tests.
    /// Mirrors the logic from ConfigurableCredentialTestBase without inheriting from CredentialTestBase.
    /// Instantiate in a test class and use for GetTokenCredential overrides and credential factories.
    /// </summary>
    internal class ConfigurableCredentialTestHelper<TCred>
        where TCred : TokenCredential
    {
        private readonly string _credentialSource;
        private readonly string _processOutput;
        private readonly IFileSystemService _defaultFileSystem;
        private readonly Func<ConfigurableCredential, ConfigurableCredential> _instrumentClient;

        public ConfigurableCredentialTestHelper(
            string credentialSource,
            string processOutput = null,
            IFileSystemService defaultFileSystem = null,
            Func<ConfigurableCredential, ConfigurableCredential> instrumentClient = null)
        {
            _credentialSource = credentialSource;
            _processOutput = processOutput;
            _defaultFileSystem = defaultFileSystem;
            _instrumentClient = instrumentClient;
        }

        public TokenCredential GetTokenCredential(TokenCredentialOptions options, string tenantId)
        {
            IConfiguration config = GetConfiguration();
            config["MyClient:Credential:TenantId"] = tenantId;
            config["MyClient:Credential:Diagnostics:IsAccountIdentifierLoggingEnabled"] = options.Diagnostics.IsAccountIdentifierLoggingEnabled.ToString();

            ConfigurableCredential credential = GetCredentialFromConfig(config);
            return InstrumentCredential(credential);
        }

#if IDENTITY_TESTS
        public TokenCredential GetTokenCredential<TCredOptions>(
            CredentialTestBase<TCredOptions>.CommonCredentialTestConfig config)
            where TCredOptions : TokenCredentialOptions
        {
            IConfiguration configuration = GetConfigurationFromCommonCredentialTestConfig(config);
            ConfigurableCredential credential = GetCredentialFromConfig(configuration);
            return InstrumentCredential(credential);
        }
#endif

        public ConfigurableCredential InstrumentCredential(ConfigurableCredential credential, IProcessService processService = null, IFileSystemService fileSystem = null)
        {
            TCred underlyingCredential = GetUnderlyingCredential(credential);

            var pipelineField = underlyingCredential
                .GetType()
                .GetField("_pipeline", BindingFlags.NonPublic | BindingFlags.Instance)
                ?? underlyingCredential
                .GetType()
                .GetField("<Pipeline>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);
            pipelineField?.SetValue(underlyingCredential, CredentialPipeline.GetInstance(null));

            if (processService != null || _processOutput != null)
            {
#if IDENTITY_TESTS
                // Create a fresh TestProcess each time since TestProcess is single-use
                IProcessService testProcessService = processService ?? new TestProcessService(new TestProcess { Output = _processOutput }, true);

                underlyingCredential
                    .GetType()
                    .GetField("_processService", BindingFlags.NonPublic | BindingFlags.Instance)
                    .SetValue(underlyingCredential, testProcessService);
#endif
            }

            IFileSystemService testFileSystem = fileSystem ?? _defaultFileSystem;
            if (testFileSystem != null)
            {
                underlyingCredential
                    .GetType()
                    .GetField("_fileSystem", BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.SetValue(underlyingCredential, testFileSystem);
            }

            return _instrumentClient != null ? _instrumentClient(credential) : credential;
        }

        public IConfiguration GetConfiguration()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>())
                .Build();
            config["MyClient:Credential:CredentialSource"] = _credentialSource;
            return config;
        }

        public TCred GetUnderlyingCredential(ConfigurableCredential credential)
        {
            // When called on a Castle proxy, get the real target to access original field values
            if (credential is Castle.DynamicProxy.IProxyTargetAccessor proxy)
                credential = (ConfigurableCredential)proxy.DynProxyGetTarget();

            TokenCredential tokenCredential = credential
                .GetType()
                .GetField("_tokenCredential", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(credential) as TokenCredential;
            TokenCredential[] sources = tokenCredential
                .GetType()
                .GetField("_sources", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(tokenCredential) as TokenCredential[];

            Assert.AreEqual(1, sources.Length);
            TCred underlyingCredential = sources[0] as TCred;
            Assert.IsNotNull(underlyingCredential);
            return underlyingCredential;
        }

        public ConfigurableCredential GetCredentialFromConfig(IConfiguration config, HttpPipelineTransport transport = null)
        {
            IConfigurationSection credentialSection = config.GetSection("MyClient:Credential");
            var dacOptions = new DefaultAzureCredentialOptions(new CredentialSettings(credentialSection), credentialSection);
            if (transport != null)
            {
                dacOptions.Transport = transport;
            }
            return new ConfigurableCredential(dacOptions);
        }

        public void CreateCredentialForTenantValidation(string tenantId)
        {
            IConfiguration config = GetConfiguration();
            config["MyClient:Credential:TenantId"] = tenantId;
            GetCredentialFromConfig(config);
        }

#if IDENTITY_TESTS
        public IConfiguration GetConfigurationFromCommonCredentialTestConfig<TCredOptions>(
            CredentialTestBase<TCredOptions>.CommonCredentialTestConfig config)
            where TCredOptions : TokenCredentialOptions
        {
            IConfiguration configuration = GetConfiguration();

            configuration["MyClient:Credential:TenantId"] = config.TenantId;
            if (config.AdditionallyAllowedTenants != null)
            {
                for (int i = 0; i < config.AdditionallyAllowedTenants.Count; i++)
                {
                    configuration[$"MyClient:Credential:AdditionallyAllowedTenants:{i}"] = config.AdditionallyAllowedTenants[i];
                }
            }
            configuration["MyClient:Credential:InteractiveBrowserCredentialClientId"] = config.AuthenticationRecord?.ClientId;
            configuration["MyClient:Credential:WorkloadIdentityClientId"] = config.AuthenticationRecord?.ClientId;
            configuration["MyClient:Credential:ManagedIdentityClientId"] = config.AuthenticationRecord?.ClientId;
            configuration["MyClient:Credential:DisableInstanceDiscovery"] = config.DisableInstanceDiscovery.ToString();
            configuration["MyClient:Credential:AuthorityHost"] = config.AuthorityHost?.ToString();
            configuration["MyClient:Credential:IsUnsafeSupportLoggingEnabled"] = config.IsUnsafeSupportLoggingEnabled.ToString();

            configuration["MyClient:Credential:Diagnostics:IsAccountIdentifierLoggingEnabled"] = config.Diagnostics.IsAccountIdentifierLoggingEnabled.ToString();
            configuration["MyClient:Credential:Diagnostics:ApplicationId"] = config.Diagnostics.ApplicationId;
            configuration["MyClient:Credential:Diagnostics:IsLoggingEnabled"] = config.Diagnostics.IsLoggingEnabled.ToString();
            configuration["MyClient:Credential:Diagnostics:IsTelemetryEnabled"] = config.Diagnostics.IsTelemetryEnabled.ToString();
            if (config.Diagnostics.LoggedHeaderNames != null)
            {
                for (int i = 0; i < config.Diagnostics.LoggedHeaderNames.Count; i++)
                {
                    configuration[$"MyClient:Credential:Diagnostics:LoggedHeaderNames:{i}"] = config.Diagnostics.LoggedHeaderNames[i];
                }
            }
            if (config.Diagnostics.LoggedQueryParameters != null)
            {
                for (int i = 0; i < config.Diagnostics.LoggedQueryParameters.Count; i++)
                {
                    configuration[$"MyClient:Credential:Diagnostics:LoggedQueryParameters:{i}"] = config.Diagnostics.LoggedQueryParameters[i];
                }
            }
            configuration["MyClient:Credential:Diagnostics:LoggedContentSizeLimit"] = config.Diagnostics.LoggedContentSizeLimit.ToString();
            configuration["MyClient:Credential:Diagnostics:IsDistributedTracingEnabled"] = config.Diagnostics.IsDistributedTracingEnabled.ToString();
            configuration["MyClient:Credential:Diagnostics:IsLoggingContentEnabled"] = config.Diagnostics.IsLoggingContentEnabled.ToString();

            configuration["MyClient:Credential:Retry:MaxRetries"] = config.Retry.MaxRetries.ToString();
            configuration["MyClient:Credential:Retry:Delay"] = config.Retry.Delay.ToString();
            configuration["MyClient:Credential:Retry:MaxDelay"] = config.Retry.MaxDelay.ToString();
            configuration["MyClient:Credential:Retry:Mode"] = config.Retry.Mode.ToString();
            configuration["MyClient:Credential:Retry:NetworkTimeout"] = config.Retry.NetworkTimeout.ToString();

            return configuration;
        }
#endif
    }
}
