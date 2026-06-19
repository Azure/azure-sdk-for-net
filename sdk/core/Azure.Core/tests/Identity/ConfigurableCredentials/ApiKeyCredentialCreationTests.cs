// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Reflection;
using Azure.Core;
using Azure.Core.Tests.Identity.ConfigurableCredentials;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
namespace Azure.Core.Tests.Identity.ConfigurableCredentials.ApiKey
{
    /// <summary>
    /// Creation tests for ApiKeyCredential support in ConfigurableCredential.
    /// Validates that configuration properties propagate correctly to the
    /// internal _apiKeyToken field. Unlike other credential types, there is
    /// no underlying TokenCredential for ApiKey.
    /// </summary>
    internal class ApiKeyCredentialCreationTests
    {
        private static ConfigurableCredential CreateFromConfig(IConfiguration config)
        {
            IConfigurationSection section = config.GetSection("MyClient:Credential");
            var options = new DefaultAzureCredentialOptions(new CredentialSettings(section), section);
            return new ConfigurableCredential(options);
        }

        private static AccessToken GetApiKeyToken(ConfigurableCredential credential)
        {
            return (AccessToken)typeof(ConfigurableCredential)
                .GetField("_apiKeyToken", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(credential);
        }

        private static object GetTokenCredential(ConfigurableCredential credential)
        {
            return typeof(ConfigurableCredential)
                .GetField("_tokenCredential", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(credential);
        }

        private static IConfiguration BuildConfig(string key)
        {
            var values = new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "ApiKey",
            };

            if (key != null)
            {
                values["MyClient:Credential:Key"] = key;
            }

            return new ConfigurationBuilder()
                .AddInMemoryCollection(values)
                .Build();
        }

        [Test]
        public void ApiKeySource_SetsApiKeyToken_NotTokenCredential()
        {
            IConfiguration config = BuildConfig("my-secret-key");
            ConfigurableCredential credential = CreateFromConfig(config);

            Assert.IsNull(GetTokenCredential(credential));
            Assert.AreEqual("my-secret-key", GetApiKeyToken(credential).Token);
        }

        [Test]
        public void KeyValue_PropagatesFromConfig()
        {
            const string expectedKey = "propagation-test-key-42";
            IConfiguration config = BuildConfig(expectedKey);
            ConfigurableCredential credential = CreateFromConfig(config);

            AccessToken apiKeyToken = GetApiKeyToken(credential);
            Assert.AreEqual(expectedKey, apiKeyToken.Token);
        }

        [Test]
        public void ExpiresOn_IsAlwaysMaxValue()
        {
            IConfiguration config = BuildConfig("any-key");
            ConfigurableCredential credential = CreateFromConfig(config);

            AccessToken apiKeyToken = GetApiKeyToken(credential);
            Assert.AreEqual(DateTimeOffset.MaxValue, apiKeyToken.ExpiresOn);
        }

        [Test]
        public void NullKey_PropagatesAsNullToken()
        {
            IConfiguration config = BuildConfig(null);
            ConfigurableCredential credential = CreateFromConfig(config);

            Assert.IsNull(GetTokenCredential(credential));
            AccessToken apiKeyToken = GetApiKeyToken(credential);
            Assert.IsNull(apiKeyToken.Token);
            Assert.AreEqual(DateTimeOffset.MaxValue, apiKeyToken.ExpiresOn);
        }

        [Test]
        public void EmptyKey_PropagatesAsEmptyToken()
        {
            IConfiguration config = BuildConfig(string.Empty);
            ConfigurableCredential credential = CreateFromConfig(config);

            Assert.IsNull(GetTokenCredential(credential));
            AccessToken apiKeyToken = GetApiKeyToken(credential);
            Assert.AreEqual(string.Empty, apiKeyToken.Token);
            Assert.AreEqual(DateTimeOffset.MaxValue, apiKeyToken.ExpiresOn);
        }

        [Test]
        public void TokenCredential_IsNull_WhenSourceIsApiKey()
        {
            IConfiguration config = BuildConfig("key-value");
            ConfigurableCredential credential = CreateFromConfig(config);

            Assert.IsNull(GetTokenCredential(credential));
        }

        [Test]
        public void DifferentKeys_ProduceDifferentApiKeyTokens()
        {
            ConfigurableCredential credential1 = CreateFromConfig(BuildConfig("key-one"));
            ConfigurableCredential credential2 = CreateFromConfig(BuildConfig("key-two"));

            Assert.AreNotEqual(GetApiKeyToken(credential1).Token, GetApiKeyToken(credential2).Token);
            Assert.AreEqual("key-one", GetApiKeyToken(credential1).Token);
            Assert.AreEqual("key-two", GetApiKeyToken(credential2).Token);
        }

        [Test]
        public void SpecialCharacterKey_PropagatesCorrectly()
        {
            const string specialKey = "key+with/special=chars&more!@#$%";
            IConfiguration config = BuildConfig(specialKey);
            ConfigurableCredential credential = CreateFromConfig(config);

            Assert.AreEqual(specialKey, GetApiKeyToken(credential).Token);
        }

        [Test]
        public void LongKey_PropagatesCorrectly()
        {
            string longKey = new string('a', 4096);
            IConfiguration config = BuildConfig(longKey);
            ConfigurableCredential credential = CreateFromConfig(config);

            Assert.AreEqual(longKey, GetApiKeyToken(credential).Token);
        }

        [Test]
        public void CreatesCredentialFromConfiguration_GetAzureClientSettings_ApiKey_DispatchesViaCredentialSettings()
        {
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["MyClient:Endpoint"] = "https://test.example.com",
                    ["MyClient:Credential:CredentialSource"] = "ApiKey",
                    ["MyClient:Credential:Key"] = "test-api-key",
                })
                .Build();

            var settings = config.GetAzureClientSettings<E2ETestSettings>("MyClient");

            // AzureCredentialResolver intentionally does not claim inline ApiKey
            // sections. Consuming libraries dispatch on
            // Credential.CredentialSource == "apikeycredential" and read
            // Credential.Key directly at client-construction time.
            Assert.IsNull(settings.CredentialProvider, "CredentialProvider should be null for inline ApiKey via GetAzureClientSettings");
            Assert.IsNotNull(settings.Credential, "Credential settings should still be bound");
            Assert.AreEqual("apikeycredential", settings.Credential.CredentialSource);
            Assert.AreEqual("test-api-key", settings.Credential.Key);

            // AuthenticationPolicy.Create can still build a policy from the
            // bound CredentialSettings using the inline Key (no TokenProvider needed).
            var policy = AuthenticationPolicy.Create(settings);
            Assert.IsNotNull(policy);
        }

        [Test]
        public void CreatesCredentialFromConfiguration_WithoutAzureCredentialResolver_E2E()
        {
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["MyClient:Endpoint"] = "https://test.example.com",
                    ["MyClient:Credential:CredentialSource"] = "ApiKey",
                    ["MyClient:Credential:Key"] = "test-api-key",
                })
                .Build();

            var settings = config.GetClientSettings<E2ETestSettings>("MyClient");
            Assert.IsNull(settings.CredentialProvider, "CredentialProvider should be null without an Azure credential resolver registered");

            var policy = AuthenticationPolicy.Create(settings);
            Assert.IsNotNull(policy);
        }

        [Test]
        public void AddClient_WithoutAzureCredentialResolver_ThrowsOnResolve()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["MyClient:Endpoint"] = "https://test.example.com",
                ["MyClient:Credential:CredentialSource"] = "ApiKeyCredential",
                ["MyClient:Credential:Key"] = "test-api-key",
            });

            builder.AddClient<DITestClient, E2ETestSettings>("MyClient");

            IHost host = builder.Build();
            var ex = Assert.Throws<ArgumentNullException>(() => host.Services.GetRequiredService<DITestClient>());
            Assert.That(ex.ParamName, Is.EqualTo("credential"));
        }

        [Test]
        public void AddKeyedClient_WithoutAzureCredentialResolver_ThrowsOnResolve()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["MyClient:Endpoint"] = "https://test.example.com",
                ["MyClient:Credential:CredentialSource"] = "ApiKeyCredential",
                ["MyClient:Credential:Key"] = "test-api-key",
            });

            builder.AddKeyedClient<DITestClient, E2ETestSettings>("myKey", "MyClient");

            IHost host = builder.Build();
            var ex = Assert.Throws<ArgumentNullException>(() => host.Services.GetRequiredKeyedService<DITestClient>("myKey"));
            Assert.That(ex.ParamName, Is.EqualTo("credential"));
        }
    }
}
