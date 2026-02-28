// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Reflection;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials
{
    /// <summary>
    /// Shared base for credential creation/priority tests.
    /// Provides common helpers for creating credentials from IConfiguration
    /// and reading internal properties/fields via reflection.
    /// </summary>
    internal abstract class CredentialCreationTestBase<TCredential>
        where TCredential : Azure.Core.TokenCredential
    {
        protected ConfigurableCredentialTestHelper<TCredential> Helper { get; private set; }

        protected abstract string CredentialSource { get; }

        [SetUp]
        public void Setup()
        {
            Helper = new ConfigurableCredentialTestHelper<TCredential>(CredentialSource);
        }

        protected ConfigurableCredential CreateFromConfig(IConfiguration config)
            => Helper.GetCredentialFromConfig(config);

        protected TCredential GetUnderlying(ConfigurableCredential credential)
            => Helper.GetUnderlyingCredential(credential);

        /// <summary>
        /// Returns additional config key-value pairs required to create this credential.
        /// Override in subclasses that need more than just CredentialSource (e.g. TenantId, ClientId).
        /// </summary>
        protected virtual Dictionary<string, string> GetRequiredConfigValues() => new();

        /// <summary>
        /// Returns environment variables to control during e2e creation.
        /// Override in subclasses that need specific env vars set.
        /// </summary>
        protected virtual Dictionary<string, string> GetRequiredEnvVars() => new()
        {
            { "AZURE_TENANT_ID", null },
            { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
        };

        /// <summary>
        /// Verifies the credential can be created end-to-end from IConfiguration
        /// using the GetAzureClientSettings / WithAzureCredential flow.
        /// </summary>
        [Test]
        [NonParallelizable]
        public void CreatesCredentialFromConfiguration_E2E()
        {
            using (new TestEnvVar(GetRequiredEnvVars()))
            {
                var configValues = new Dictionary<string, string>
                {
                    ["MyClient:Endpoint"] = "https://test.example.com",
                    ["MyClient:Credential:CredentialSource"] = CredentialSource,
                };

                foreach (var kvp in GetRequiredConfigValues())
                {
                    configValues[$"MyClient:Credential:{kvp.Key}"] = kvp.Value;
                }

                var config = new ConfigurationBuilder()
                    .AddInMemoryCollection(configValues)
                    .Build();

                var settings = config.GetAzureClientSettings<E2ETestSettings>("MyClient");
                Assert.IsNotNull(settings.CredentialProvider, $"CredentialProvider should be set for {CredentialSource}");
                Assert.IsInstanceOf<ConfigurableCredential>(settings.CredentialProvider, $"CredentialProvider should be ConfigurableCredential for {CredentialSource}");

                var configurableCredential = (ConfigurableCredential)settings.CredentialProvider;
                var underlying = GetUnderlying(configurableCredential);
                Assert.IsInstanceOf<TCredential>(underlying, $"Underlying credential should be {typeof(TCredential).Name} for {CredentialSource}");
            }
        }

        /// <summary>
        /// Verifies that without WithAzureCredential, CredentialProvider is null
        /// and AuthenticationPolicy.Create throws the appropriate error.
        /// </summary>
        [Test]
        [NonParallelizable]
        public void WithoutWithAzureCredential_AuthenticationPolicyCreateThrows()
        {
            using (new TestEnvVar(GetRequiredEnvVars()))
            {
                var configValues = new Dictionary<string, string>
                {
                    ["MyClient:Endpoint"] = "https://test.example.com",
                    ["MyClient:Credential:CredentialSource"] = CredentialSource,
                    ["MyClient:Credential:AdditionalProperties:Scope"] = "https://test.example.com/.default",
                };

                foreach (var kvp in GetRequiredConfigValues())
                {
                    configValues[$"MyClient:Credential:{kvp.Key}"] = kvp.Value;
                }

                var config = new ConfigurationBuilder()
                    .AddInMemoryCollection(configValues)
                    .Build();

                var settings = config.GetClientSettings<E2ETestSettings>("MyClient");
                Assert.IsNull(settings.CredentialProvider, $"CredentialProvider should be null without WithAzureCredential for {CredentialSource}");

                var ex = Assert.Throws<InvalidOperationException>(() => AuthenticationPolicy.Create(settings));
                Assert.That(ex.Message, Does.Contain("No AuthenticationTokenProvider was provided."));
            }
        }

        /// <summary>
        /// Verifies that AddClient with WithAzureCredential resolves a working client from DI.
        /// </summary>
        [Test]
        [NonParallelizable]
        public void AddClient_WithAzureCredential_ResolvesClient()
        {
            using (new TestEnvVar(GetRequiredEnvVars()))
            {
                HostApplicationBuilder builder = Host.CreateApplicationBuilder();
                var configValues = BuildConfigValues();

                builder.Configuration.AddInMemoryCollection(configValues);
                builder.AddClient<DITestClient, E2ETestSettings>("MyClient").WithAzureCredential();

                IHost host = builder.Build();
                var client = host.Services.GetRequiredService<DITestClient>();

                Assert.IsNotNull(client);
                Assert.IsNotNull(client.Endpoint);
                Assert.IsNotNull(client.Credential);
                Assert.IsInstanceOf<ConfigurableCredential>(client.Credential);
            }
        }

        /// <summary>
        /// Verifies that AddClient without WithAzureCredential throws ArgumentNullException
        /// because the credential is null when the DI container resolves the client.
        /// </summary>
        [Test]
        [NonParallelizable]
        public void AddClient_WithoutWithAzureCredential_ThrowsOnResolve()
        {
            using (new TestEnvVar(GetRequiredEnvVars()))
            {
                HostApplicationBuilder builder = Host.CreateApplicationBuilder();
                var configValues = BuildConfigValues();

                builder.Configuration.AddInMemoryCollection(configValues);
                builder.AddClient<DITestClient, E2ETestSettings>("MyClient");

                IHost host = builder.Build();
                var ex = Assert.Throws<ArgumentNullException>(() => host.Services.GetRequiredService<DITestClient>());
                Assert.That(ex.ParamName, Is.EqualTo("credential"));
            }
        }

        /// <summary>
        /// Verifies that AddKeyedClient with WithAzureCredential resolves a working client from DI.
        /// </summary>
        [Test]
        [NonParallelizable]
        public void AddKeyedClient_WithAzureCredential_ResolvesClient()
        {
            using (new TestEnvVar(GetRequiredEnvVars()))
            {
                HostApplicationBuilder builder = Host.CreateApplicationBuilder();
                var configValues = BuildConfigValues();

                builder.Configuration.AddInMemoryCollection(configValues);
                builder.AddKeyedClient<DITestClient, E2ETestSettings>("myKey", "MyClient").WithAzureCredential();

                IHost host = builder.Build();
                var client = host.Services.GetRequiredKeyedService<DITestClient>("myKey");

                Assert.IsNotNull(client);
                Assert.IsNotNull(client.Endpoint);
                Assert.IsNotNull(client.Credential);
                Assert.IsInstanceOf<ConfigurableCredential>(client.Credential);
            }
        }

        /// <summary>
        /// Verifies that AddKeyedClient without WithAzureCredential throws ArgumentNullException
        /// because the credential is null when the DI container resolves the client.
        /// </summary>
        [Test]
        [NonParallelizable]
        public void AddKeyedClient_WithoutWithAzureCredential_ThrowsOnResolve()
        {
            using (new TestEnvVar(GetRequiredEnvVars()))
            {
                HostApplicationBuilder builder = Host.CreateApplicationBuilder();
                var configValues = BuildConfigValues();

                builder.Configuration.AddInMemoryCollection(configValues);
                builder.AddKeyedClient<DITestClient, E2ETestSettings>("myKey", "MyClient");

                IHost host = builder.Build();
                var ex = Assert.Throws<ArgumentNullException>(() => host.Services.GetRequiredKeyedService<DITestClient>("myKey"));
                Assert.That(ex.ParamName, Is.EqualTo("credential"));
            }
        }

        /// <summary>
        /// Builds the config dictionary for DI tests, including CredentialSource and any required config values.
        /// </summary>
        private Dictionary<string, string> BuildConfigValues()
        {
            var configValues = new Dictionary<string, string>
            {
                ["MyClient:Endpoint"] = "https://test.example.com",
                ["MyClient:Credential:CredentialSource"] = CredentialSource,
            };

            foreach (var kvp in GetRequiredConfigValues())
            {
                configValues[$"MyClient:Credential:{kvp.Key}"] = kvp.Value;
            }

            return configValues;
        }

        /// <summary>
        /// Reads an internal/private property by walking the type hierarchy.
        /// </summary>
        protected static T ReadProperty<T>(object target, string name)
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

        /// <summary>
        /// Reads an internal/private field by walking the type hierarchy.
        /// </summary>
        protected static T ReadField<T>(object target, string name)
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
    }
}
