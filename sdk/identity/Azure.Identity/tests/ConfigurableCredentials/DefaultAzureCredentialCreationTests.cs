// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.DefaultAzureCredentialNs
{
    /// <summary>
    /// Validates that CredentialSource: "DefaultAzureCredential" can be created from
    /// IConfiguration, verifies case insensitivity, config-over-env precedence, and
    /// that the resulting chain matches a direct DefaultAzureCredential.
    /// Follows the same creation test pattern as other credential types.
    /// </summary>
    internal class DefaultAzureCredentialCreationTests
    {
        private static ConfigurableCredential CreateFromConfig(IConfiguration config)
        {
            var section = config.GetSection("MyClient:Credential");
            var options = new DefaultAzureCredentialOptions(new CredentialSettings(section), section);
            return new ConfigurableCredential(options);
        }

        private static DefaultAzureCredential GetInnerDac(ConfigurableCredential credential)
        {
            return typeof(ConfigurableCredential)
                .GetField("_tokenCredential", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(credential) as DefaultAzureCredential;
        }

        private static IConfiguration BuildConfig(string credentialSource = "DefaultAzureCredential")
        {
            return new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["MyClient:Credential:CredentialSource"] = credentialSource
                })
                .Build();
        }

        private static IConfiguration BuildDetailedConfig(Dictionary<string, string> properties)
        {
            var prefixed = new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "DefaultAzureCredential"
            };
            foreach (var kvp in properties)
            {
                prefixed[$"MyClient:Credential:{kvp.Key}"] = kvp.Value;
            }
            return new ConfigurationBuilder().AddInMemoryCollection(prefixed).Build();
        }

        private static Dictionary<string, string> NulledEnvVars() => new()
        {
            { "AZURE_TENANT_ID", null },
            { "AZURE_CLIENT_ID", null },
            { "AZURE_CLIENT_SECRET", null },
            { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
            { "AZURE_FEDERATED_TOKEN_FILE", null },
            { "AZURE_TOKEN_CREDENTIALS", null },
        };

        private static T FindCredential<T>(TokenCredential[] sources) where T : TokenCredential
        {
            foreach (var s in sources)
            {
                if (s is T found)
                    return found;
            }
            Assert.Fail($"{typeof(T).Name} not found in chain");
            return default;
        }

        private static T ReadProperty<T>(object target, string name)
        {
            var type = target.GetType();
            while (type != null)
            {
                var prop = type.GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly);
                if (prop != null)
                    return (T)prop.GetValue(target);
                type = type.BaseType;
            }
            throw new InvalidOperationException($"Property '{name}' not found on {target.GetType().Name} or its base types.");
        }

        private static T ReadField<T>(object target, string name)
        {
            var type = target.GetType();
            while (type != null)
            {
                var field = type.GetField(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly);
                if (field != null)
                    return (T)field.GetValue(target);
                type = type.BaseType;
            }
            throw new InvalidOperationException($"Field '{name}' not found on {target.GetType().Name} or its base types.");
        }

        [Test]
        public void CreatesFullDefaultChain()
        {
            var credential = CreateFromConfig(BuildConfig());
            var innerDac = GetInnerDac(credential);

            Assert.IsNotNull(innerDac);
            var sources = innerDac._sources();
            Assert.AreEqual(9, sources.Length);
            Assert.IsInstanceOf<EnvironmentCredential>(sources[0]);
            Assert.IsInstanceOf<WorkloadIdentityCredential>(sources[1]);
            Assert.IsInstanceOf<ManagedIdentityCredential>(sources[2]);
            Assert.IsInstanceOf<VisualStudioCredential>(sources[3]);
            Assert.IsInstanceOf<VisualStudioCodeCredential>(sources[4]);
            Assert.IsInstanceOf<AzureCliCredential>(sources[5]);
            Assert.IsInstanceOf<AzurePowerShellCredential>(sources[6]);
            Assert.IsInstanceOf<AzureDeveloperCliCredential>(sources[7]);
        }

        [Test]
        public void MatchesDirectDefaultAzureCredential()
        {
            var credential = CreateFromConfig(BuildConfig());
            var configuredSources = GetInnerDac(credential)._sources();

            var directSources = new DefaultAzureCredential()._sources();

            Assert.AreEqual(directSources.Length, configuredSources.Length);
            for (int i = 0; i < directSources.Length; i++)
            {
                Assert.AreEqual(directSources[i].GetType(), configuredSources[i].GetType(),
                    $"Chain mismatch at index {i}");
            }
        }

        [TestCase("DefaultAzureCredential")]
        [TestCase("defaultazurecredential")]
        [TestCase("DEFAULTAZURECREDENTIAL")]
        [TestCase("defaultAzureCredential")]
        public void CaseInsensitive(string credentialSource)
        {
            var credential = CreateFromConfig(BuildConfig(credentialSource));
            var innerDac = GetInnerDac(credential);

            Assert.IsNotNull(innerDac, $"Failed for: {credentialSource}");
            Assert.Greater(innerDac._sources().Length, 1, $"Expected full chain for '{credentialSource}'");
        }

        [Test]
        [NonParallelizable]
        public void ConfigTakesPrecedenceOverEnvVar()
        {
            using var env = new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TOKEN_CREDENTIALS", "AzureCli" }
            });

            var credential = CreateFromConfig(BuildConfig());
            var sources = GetInnerDac(credential)._sources();

            Assert.Greater(sources.Length, 1,
                "Config CredentialSource should take precedence over AZURE_TOKEN_CREDENTIALS");
        }

        [Test]
        [NonParallelizable]
        public void CreatesCredentialFromConfiguration_E2E()
        {
            var configValues = new Dictionary<string, string>
            {
                ["MyClient:Endpoint"] = "https://test.example.com",
                ["MyClient:Credential:CredentialSource"] = "DefaultAzureCredential",
            };

            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(configValues)
                .Build();

            var settings = config.GetAzureClientSettings<E2ETestSettings>("MyClient");
            Assert.IsNotNull(settings.CredentialProvider);
            Assert.IsInstanceOf<ConfigurableCredential>(settings.CredentialProvider);

            var innerDac = GetInnerDac((ConfigurableCredential)settings.CredentialProvider);
            Assert.IsNotNull(innerDac);
            Assert.Greater(innerDac._sources().Length, 1);
        }

        [Test]
        [NonParallelizable]
        public void AddClient_WithAzureCredential_ResolvesClient()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            var configValues = new Dictionary<string, string>
            {
                ["MyClient:Endpoint"] = "https://test.example.com",
                ["MyClient:Credential:CredentialSource"] = "DefaultAzureCredential",
            };

            builder.Configuration.AddInMemoryCollection(configValues);
            builder.AddClient<DITestClient, E2ETestSettings>("MyClient").WithAzureCredential();

            IHost host = builder.Build();
            var client = host.Services.GetRequiredService<DITestClient>();

            Assert.IsNotNull(client);
            Assert.IsNotNull(client.Credential);
            Assert.IsInstanceOf<ConfigurableCredential>(client.Credential);
        }

        #region Exclude flags tests

        [TestCase(nameof(DefaultAzureCredentialOptions.ExcludeEnvironmentCredential), typeof(EnvironmentCredential))]
        [TestCase(nameof(DefaultAzureCredentialOptions.ExcludeWorkloadIdentityCredential), typeof(WorkloadIdentityCredential))]
        [TestCase(nameof(DefaultAzureCredentialOptions.ExcludeManagedIdentityCredential), typeof(ManagedIdentityCredential))]
        [TestCase(nameof(DefaultAzureCredentialOptions.ExcludeVisualStudioCredential), typeof(VisualStudioCredential))]
        [TestCase(nameof(DefaultAzureCredentialOptions.ExcludeVisualStudioCodeCredential), typeof(VisualStudioCodeCredential))]
        [TestCase(nameof(DefaultAzureCredentialOptions.ExcludeAzureCliCredential), typeof(AzureCliCredential))]
        [TestCase(nameof(DefaultAzureCredentialOptions.ExcludeAzurePowerShellCredential), typeof(AzurePowerShellCredential))]
        [TestCase(nameof(DefaultAzureCredentialOptions.ExcludeAzureDeveloperCliCredential), typeof(AzureDeveloperCliCredential))]
        [TestCase(nameof(DefaultAzureCredentialOptions.ExcludeBrokerCredential), typeof(BrokerCredential))]
        [NonParallelizable]
        public void ExcludeFlags_RemovesCredentialFromChain(string excludeFlag, Type excludedType)
        {
            using (new TestEnvVar(NulledEnvVars()))
            {
                var config = BuildDetailedConfig(new Dictionary<string, string>
                {
                    [excludeFlag] = "True"
                });

                var sources = GetInnerDac(CreateFromConfig(config))._sources();

                Assert.AreEqual(8, sources.Length, $"Expected 8 sources after excluding {excludedType.Name}");
                Assert.IsFalse(sources.Any(s => s.GetType() == excludedType),
                    $"{excludedType.Name} should not be in chain when {excludeFlag}=True");
            }
        }

        [TestCase(nameof(DefaultAzureCredentialOptions.ExcludeInteractiveBrowserCredential), typeof(InteractiveBrowserCredential))]
        [NonParallelizable]
        public void ExcludeFlags_AlreadyExcludedByDefault_ChainUnchanged(string excludeFlag, Type excludedType)
        {
            using (new TestEnvVar(NulledEnvVars()))
            {
                var config = BuildDetailedConfig(new Dictionary<string, string>
                {
                    [excludeFlag] = "True"
                });

                var sources = GetInnerDac(CreateFromConfig(config))._sources();

                // InteractiveBrowserCredential is excluded by default so chain stays at 9
                Assert.AreEqual(9, sources.Length, $"Expected 9 sources when {excludeFlag}=True (already excluded by default)");
                Assert.IsFalse(sources.Any(s => excludedType.IsAssignableFrom(s.GetType()) && s.GetType() == typeof(InteractiveBrowserCredential)),
                    $"{excludedType.Name} should not be in chain");
            }
        }

        [Test]
        [NonParallelizable]
        public void ExcludeInteractiveBrowser_FalseIncludesInteractive()
        {
            using (new TestEnvVar(NulledEnvVars()))
            {
                var config = BuildDetailedConfig(new Dictionary<string, string>
                {
                    [nameof(DefaultAzureCredentialOptions.ExcludeInteractiveBrowserCredential)] = "False"
                });

                var sources = GetInnerDac(CreateFromConfig(config))._sources();

                Assert.AreEqual(10, sources.Length, "Expected 10 sources when InteractiveBrowser is included");
                Assert.IsTrue(sources.Any(s => s.GetType() == typeof(InteractiveBrowserCredential)),
                    "InteractiveBrowserCredential should be in chain when ExcludeInteractiveBrowserCredential=False");
            }
        }

        #endregion

        #region Property flow tests

        [Test]
        [NonParallelizable]
        public void AzureCliCredential_ConfigPropertiesFlow()
        {
            using (new TestEnvVar(NulledEnvVars()))
            {
                var config = BuildDetailedConfig(new Dictionary<string, string>
                {
                    ["TenantId"] = "test-tenant",
                    ["AdditionallyAllowedTenants:0"] = "extra-tenant",
                    ["CredentialProcessTimeout"] = "00:00:45",
                    ["Subscription"] = "my-sub",
                });

                var sources = GetInnerDac(CreateFromConfig(config))._sources();
                var cli = FindCredential<AzureCliCredential>(sources);

                Assert.AreEqual("test-tenant", ReadProperty<string>(cli, "TenantId"));
                var tenants = ReadProperty<string[]>(cli, "AdditionallyAllowedTenantIds");
                CollectionAssert.Contains(tenants, "extra-tenant");
                Assert.AreEqual(TimeSpan.FromSeconds(45), ReadProperty<TimeSpan>(cli, "ProcessTimeout"));
                Assert.AreEqual("my-sub", ReadProperty<string>(cli, "Subscription"));
                Assert.IsTrue(ReadField<bool>(cli, "_isChainedCredential"));
            }
        }

        [Test]
        [NonParallelizable]
        public void AzurePowerShellCredential_ConfigPropertiesFlow()
        {
            using (new TestEnvVar(NulledEnvVars()))
            {
                var config = BuildDetailedConfig(new Dictionary<string, string>
                {
                    ["TenantId"] = "ps-tenant",
                    ["CredentialProcessTimeout"] = "00:01:00",
                });

                var sources = GetInnerDac(CreateFromConfig(config))._sources();
                var ps = FindCredential<AzurePowerShellCredential>(sources);

                Assert.AreEqual("ps-tenant", ReadProperty<string>(ps, "TenantId"));
                Assert.AreEqual(TimeSpan.FromMinutes(1), ReadProperty<TimeSpan>(ps, "ProcessTimeout"));
                Assert.IsTrue(ReadField<bool>(ps, "_isChainedCredential"));
            }
        }

        [Test]
        [NonParallelizable]
        public void AzureDeveloperCliCredential_ConfigPropertiesFlow()
        {
            using (new TestEnvVar(NulledEnvVars()))
            {
                var config = BuildDetailedConfig(new Dictionary<string, string>
                {
                    ["TenantId"] = "azd-tenant",
                    ["CredentialProcessTimeout"] = "00:00:20",
                });

                var sources = GetInnerDac(CreateFromConfig(config))._sources();
                var azd = FindCredential<AzureDeveloperCliCredential>(sources);

                Assert.AreEqual("azd-tenant", ReadProperty<string>(azd, "TenantId"));
                Assert.AreEqual(TimeSpan.FromSeconds(20), ReadProperty<TimeSpan>(azd, "ProcessTimeout"));
                Assert.IsTrue(ReadField<bool>(azd, "_isChainedCredential"));
            }
        }

        [Test]
        [NonParallelizable]
        public void VisualStudioCredential_ConfigPropertiesFlow()
        {
            using (new TestEnvVar(NulledEnvVars()))
            {
                var config = BuildDetailedConfig(new Dictionary<string, string>
                {
                    ["TenantId"] = "vs-tenant",
                    ["CredentialProcessTimeout"] = "00:00:50",
                });

                var sources = GetInnerDac(CreateFromConfig(config))._sources();
                var vs = FindCredential<VisualStudioCredential>(sources);

                // TenantId cascades from DAC TenantId to VisualStudioTenantId
                Assert.AreEqual("vs-tenant", ReadProperty<string>(vs, "TenantId"));
                Assert.AreEqual(TimeSpan.FromSeconds(50), ReadProperty<TimeSpan>(vs, "ProcessTimeout"));
                Assert.IsTrue(ReadField<bool>(vs, "_isChainedCredential"));
            }
        }

        [Test]
        [NonParallelizable]
        public void VisualStudioCodeCredential_ConfigPropertiesFlow()
        {
            using (new TestEnvVar(NulledEnvVars()))
            {
                var config = BuildDetailedConfig(new Dictionary<string, string>
                {
                    ["TenantId"] = "vscode-tenant",
                });

                var sources = GetInnerDac(CreateFromConfig(config))._sources();
                var vscode = FindCredential<VisualStudioCodeCredential>(sources);

                // VisualStudioCodeCredential inherits from InteractiveBrowserCredential
                // TenantId cascades from DAC TenantId to VisualStudioCodeTenantId
                Assert.AreEqual("vscode-tenant", ReadProperty<string>(vscode, "TenantId"));
                Assert.IsTrue(ReadProperty<bool>(vscode, "IsChainedCredential"));
            }
        }

        [Test]
        [NonParallelizable]
        public void ManagedIdentityCredential_ConfigPropertiesFlow()
        {
            using (new TestEnvVar(NulledEnvVars()))
            {
                var config = BuildDetailedConfig(new Dictionary<string, string>
                {
                    ["ManagedIdentityIdKind"] = "ClientId",
                    ["ManagedIdentityId"] = "test-mi-client-id",
                });

                var sources = GetInnerDac(CreateFromConfig(config))._sources();
                var mi = FindCredential<ManagedIdentityCredential>(sources);

                var client = ReadProperty<ManagedIdentityClient>(mi, "Client");
                Assert.IsNotNull(client);
                var managedId = ReadProperty<ManagedIdentityId>(client, "ManagedIdentityId");
                Assert.AreEqual("test-mi-client-id", ReadField<string>(managedId, "_userAssignedId"));
            }
        }

        [Test]
        [NonParallelizable]
        public void EnvironmentCredential_ConfigPropertiesFlow()
        {
            using (new TestEnvVar(NulledEnvVars()))
            {
                var config = BuildDetailedConfig(new Dictionary<string, string>
                {
                    ["TenantId"] = "env-config-tenant",
                    ["ClientId"] = "test-client-id",
                    ["ClientSecret"] = "test-secret",
                });

                var sources = GetInnerDac(CreateFromConfig(config))._sources();
                var envCred = FindCredential<EnvironmentCredential>(sources);

                var inner = ReadProperty<TokenCredential>(envCred, "Credential");
                Assert.IsNotNull(inner, "EnvironmentCredential should have an inner credential when TenantId+ClientId+ClientSecret are set");
                Assert.IsInstanceOf<ClientSecretCredential>(inner);

                Assert.AreEqual("env-config-tenant", ReadProperty<string>(inner, "TenantId"));
            }
        }

        #endregion

        #region Config precedence in DAC chain

        [Test]
        [NonParallelizable]
        public void TenantId_ConfigWinsOverEnvVar_InDacChain()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", "env-tenant" },
                { "AZURE_CLIENT_ID", null },
                { "AZURE_CLIENT_SECRET", null },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
                { "AZURE_FEDERATED_TOKEN_FILE", null },
                { "AZURE_TOKEN_CREDENTIALS", null },
            }))
            {
                var config = BuildDetailedConfig(new Dictionary<string, string>
                {
                    ["TenantId"] = "config-tenant",
                });

                var sources = GetInnerDac(CreateFromConfig(config))._sources();
                var cli = FindCredential<AzureCliCredential>(sources);

                Assert.AreEqual("config-tenant", ReadProperty<string>(cli, "TenantId"),
                    "Config TenantId should take precedence over AZURE_TENANT_ID env var");
            }
        }

        #endregion
    }
}
