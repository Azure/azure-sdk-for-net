// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Reflection;
using Azure.Core;
using Azure.Identity.Tests.Mock;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.DefaultAzureCredentialNs
{
    /// <summary>
    /// Inherits all tests from the base DefaultAzureCredentialTests, creating the
    /// DefaultAzureCredential through ConfigurableCredential with
    /// CredentialSource: "DefaultAzureCredential".
    /// </summary>
    internal class DefaultAzureCredentialTests : Tests.DefaultAzureCredentialTests
    {
        public DefaultAzureCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        protected override DefaultAzureCredential CreateDefaultAzureCredential()
        {
            return CreateDacFromConfig(new Dictionary<string, string>
            {
                ["CredentialSource"] = "DefaultAzureCredential"
            });
        }

        protected override DefaultAzureCredential CreateDefaultAzureCredentialWithInteractive(bool includeInteractive)
        {
            return CreateDacFromConfig(new Dictionary<string, string>
            {
                ["CredentialSource"] = "DefaultAzureCredential",
                ["ExcludeInteractiveBrowserCredential"] = (!includeInteractive).ToString(),
            });
        }

        protected override DefaultAzureCredential CreateDefaultAzureCredentialWithOptions(DefaultAzureCredentialOptions options)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            if (!options.ExcludeSharedTokenCacheCredential)
            {
                Assert.Ignore("SharedTokenCacheCredential is obsolete and not supported through the configurable credential path.");
            }
#pragma warning restore CS0618
            return CreateDacFromConfig(OptionsToConfigValues(options));
        }

        internal override TokenCredential CreateMockedDefaultAzureCredential(
            DefaultAzureCredentialOptions options,
            Action<MockDefaultAzureCredentialFactory> configureMocks)
        {
            // Convert options to config values (exclude flags, tenant, client, etc.)
            var configValues = OptionsToConfigValues(options);

            // Create CC and options from the same config — guarantees both see identical values
            var cc = CreateConfigurableFromConfig(configValues, out var configOptions);

            // SharedTokenCacheCredential is obsolete and not configurable through config.
            // Carry forward the caller's value so mock factory creates the right set of credentials.
#pragma warning disable CS0618
            configOptions.ExcludeSharedTokenCacheCredential = options.ExcludeSharedTokenCacheCredential;
#pragma warning restore CS0618

            // Create factory from config-derived options
            var factory = new MockDefaultAzureCredentialFactory(configOptions);
            configureMocks(factory);

            // Wire factory's credential chain into inner DAC
            GetInnerDac(cc)._sources = factory.CreateCredentialChain();
            return cc;
        }

        internal override TokenCredential InstrumentFactoryCredential(TokenCredential cred)
            => InstrumentClient((ConfigurableCredential)cred);

        private static Dictionary<string, string> OptionsToConfigValues(DefaultAzureCredentialOptions options)
        {
            var configValues = new Dictionary<string, string>
            {
                ["CredentialSource"] = "DefaultAzureCredential",
                ["ExcludeEnvironmentCredential"] = options.ExcludeEnvironmentCredential.ToString(),
                ["ExcludeWorkloadIdentityCredential"] = options.ExcludeWorkloadIdentityCredential.ToString(),
                ["ExcludeManagedIdentityCredential"] = options.ExcludeManagedIdentityCredential.ToString(),
                ["ExcludeAzureDeveloperCliCredential"] = options.ExcludeAzureDeveloperCliCredential.ToString(),
                ["ExcludeInteractiveBrowserCredential"] = options.ExcludeInteractiveBrowserCredential.ToString(),
                ["ExcludeBrokerCredential"] = options.ExcludeBrokerCredential.ToString(),
                ["ExcludeAzureCliCredential"] = options.ExcludeAzureCliCredential.ToString(),
                ["ExcludeVisualStudioCredential"] = options.ExcludeVisualStudioCredential.ToString(),
                ["ExcludeVisualStudioCodeCredential"] = options.ExcludeVisualStudioCodeCredential.ToString(),
                ["ExcludeAzurePowerShellCredential"] = options.ExcludeAzurePowerShellCredential.ToString(),
                ["DisableInstanceDiscovery"] = options.DisableInstanceDiscovery.ToString(),
            };

            if (options.TenantId != null)
            {
                configValues["TenantId"] = options.TenantId;
            }

            if (options.AdditionallyAllowedTenants != null)
            {
                for (int i = 0; i < options.AdditionallyAllowedTenants.Count; i++)
                {
                    configValues[$"AdditionallyAllowedTenants:{i}"] = options.AdditionallyAllowedTenants[i];
                }
            }

            if (!string.IsNullOrEmpty(options.ClientId))
            {
                configValues["ClientId"] = options.ClientId;
            }

            if (options.DisableAutomaticAuthentication)
            {
                configValues["DisableAutomaticAuthentication"] = options.DisableAutomaticAuthentication.ToString();
            }

            return configValues;
        }

        private static IConfigurationSection BuildConfigSection(Dictionary<string, string> configValues)
        {
            const string prefix = "MyClient:Credential:";
            var prefixed = new Dictionary<string, string>();
            foreach (var kvp in configValues)
            {
                prefixed[$"{prefix}{kvp.Key}"] = kvp.Value;
            }

            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(prefixed)
                .Build();

            return config.GetSection("MyClient:Credential");
        }

        private static ConfigurableCredential CreateConfigurableFromConfig(Dictionary<string, string> configValues)
            => CreateConfigurableFromConfig(configValues, out _);

        private static ConfigurableCredential CreateConfigurableFromConfig(Dictionary<string, string> configValues, out DefaultAzureCredentialOptions configOptions)
        {
            var section = BuildConfigSection(configValues);
            configOptions = new DefaultAzureCredentialOptions(new CredentialSettings(section), section);
            return new ConfigurableCredential(configOptions);
        }

        private static DefaultAzureCredential GetInnerDac(ConfigurableCredential configurable)
        {
            return typeof(ConfigurableCredential)
                .GetField("_tokenCredential", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(configurable) as DefaultAzureCredential;
        }

        private static DefaultAzureCredential CreateDacFromConfig(Dictionary<string, string> configValues)
            => GetInnerDac(CreateConfigurableFromConfig(configValues));
    }
}
