// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials
{
    public class ConfigurableCredentialTests : ClientTestBase
    {
        public ConfigurableCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        private TokenCredential GetInnerCredential(ConfigurableCredential credential)
        {
            return typeof(ConfigurableCredential)
                .GetField("_tokenCredential", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(credential) as TokenCredential;
        }

        private AccessToken GetApiKeyToken(ConfigurableCredential credential)
        {
            return (AccessToken)typeof(ConfigurableCredential)
                .GetField("_apiKeyToken", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(credential);
        }

        private TokenCredential[] GetDefaultAzureCredentialSources(DefaultAzureCredential credential)
        {
            return typeof(DefaultAzureCredential)
                .GetField("_sources", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(credential) as TokenCredential[];
        }

        private TokenCredential[] GetChainedTokenCredentialSources(ChainedTokenCredential credential)
        {
            return typeof(ChainedTokenCredential)
                .GetField("_sources", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(credential) as TokenCredential[];
        }

        private CredentialSettings CreateCredentialSettings(string credentialSource, string apiKey = null)
        {
            var mockSection = new Moq.Mock<IConfigurationSection>();
            mockSection.Setup(s => s["CredentialSource"]).Returns(credentialSource);
            mockSection.Setup(s => s["Key"]).Returns(apiKey);
            mockSection.Setup(s => s.GetSection("AdditionalProperties")).Returns(Moq.Mock.Of<IConfigurationSection>());
            return new CredentialSettings(mockSection.Object);
        }

        [Test]
        public void Constructor_WithNullCredentialSettings_CreatesDefaultAzureCredential()
        {
            var credential = new ConfigurableCredential((CredentialSettings)null);
            var innerCredential = GetInnerCredential(credential);

            Assert.IsNotNull(innerCredential);
            Assert.IsInstanceOf<DefaultAzureCredential>(innerCredential);
        }

        [Test]
        public void Constructor_WithDefaultConstructor_CreatesDefaultAzureCredential()
        {
            var credential = new ConfigurableCredential();
            var innerCredential = GetInnerCredential(credential);

            Assert.IsNotNull(innerCredential);
            Assert.IsInstanceOf<DefaultAzureCredential>(innerCredential);
        }

        [Test]
        public void Constructor_WithApiKeyCredentialSource_CreatesApiKeyToken()
        {
            const string expectedApiKey = "test-api-key-12345";
            var settings = CreateCredentialSettings("ApiKey", expectedApiKey);

            var credential = new ConfigurableCredential(settings);
            var innerCredential = GetInnerCredential(credential);
            var apiKeyToken = GetApiKeyToken(credential);

            Assert.IsNull(innerCredential);
            Assert.AreEqual(expectedApiKey, apiKeyToken.Token);
            Assert.AreEqual(DateTimeOffset.MaxValue, apiKeyToken.ExpiresOn);
        }

        [Test]
        public async Task GetTokenAsync_WithApiKey_ReturnsApiKeyToken()
        {
            const string expectedApiKey = "test-api-key-67890";
            var settings = CreateCredentialSettings("ApiKey", expectedApiKey);
            var credential = new ConfigurableCredential(settings);

            var context = new TokenRequestContext(new[] { "https://vault.azure.net/.default" });
            var token = await credential.GetTokenAsync(context, CancellationToken.None);

            Assert.AreEqual(expectedApiKey, token.Token);
            Assert.AreEqual(DateTimeOffset.MaxValue, token.ExpiresOn);
        }

        [Test]
        public void GetToken_WithApiKey_ReturnsApiKeyToken()
        {
            const string expectedApiKey = "sync-api-key-test";
            var settings = CreateCredentialSettings("ApiKey", expectedApiKey);
            var credential = new ConfigurableCredential(settings);

            var context = new TokenRequestContext(new[] { "https://vault.azure.net/.default" });
            var token = credential.GetToken(context, CancellationToken.None);

            Assert.AreEqual(expectedApiKey, token.Token);
            Assert.AreEqual(DateTimeOffset.MaxValue, token.ExpiresOn);
        }

        [TestCase("AzureCliCredential", typeof(AzureCliCredential))]
        [TestCase("VisualStudioCredential", typeof(VisualStudioCredential))]
        [TestCase("VisualStudioCodeCredential", typeof(VisualStudioCodeCredential))]
        [TestCase("AzurePowerShellCredential", typeof(AzurePowerShellCredential))]
        [TestCase("AzureDeveloperCliCredential", typeof(AzureDeveloperCliCredential))]
        [TestCase("EnvironmentCredential", typeof(EnvironmentCredential))]
        [TestCase("WorkloadIdentityCredential", typeof(WorkloadIdentityCredential))]
        [TestCase("ManagedIdentityCredential", typeof(ManagedIdentityCredential))]
        [TestCase("InteractiveBrowserCredential", typeof(InteractiveBrowserCredential))]
        // Back-compat short names
        [TestCase("AzureCli", typeof(AzureCliCredential))]
        [TestCase("VisualStudio", typeof(VisualStudioCredential))]
        [TestCase("VisualStudioCode", typeof(VisualStudioCodeCredential))]
        [TestCase("AzurePowerShell", typeof(AzurePowerShellCredential))]
        [TestCase("AzureDeveloperCli", typeof(AzureDeveloperCliCredential))]
        [TestCase("Environment", typeof(EnvironmentCredential))]
        [TestCase("WorkloadIdentity", typeof(WorkloadIdentityCredential))]
        [TestCase("ManagedIdentity", typeof(ManagedIdentityCredential))]
        [TestCase("InteractiveBrowser", typeof(InteractiveBrowserCredential))]
        public void Constructor_WithSpecificCredentialSource_CreatesExactlyOneMatchingCredential(string credentialSource, Type expectedCredentialType)
        {
            var settings = CreateCredentialSettings(credentialSource);

            var credential = new ConfigurableCredential(settings);
            var innerCredential = GetInnerCredential(credential) as DefaultAzureCredential;

            Assert.IsNotNull(innerCredential);

            var sources = GetDefaultAzureCredentialSources(innerCredential);
            Assert.IsNotNull(sources);
            Assert.AreEqual(1, sources.Length, $"Expected exactly one credential source, but found {sources.Length}");
            Assert.IsInstanceOf(expectedCredentialType, sources[0], $"Expected credential type {expectedCredentialType.Name} but got {sources[0].GetType().Name}");
        }

        [Test]
        public void Constructor_WithBrokerCredentialSource_CreatesExactlyOneInteractiveBrowserCredential()
        {
            var settings = CreateCredentialSettings("BrokerCredential");

            var credential = new ConfigurableCredential(settings);
            var innerCredential = GetInnerCredential(credential) as DefaultAzureCredential;

            Assert.IsNotNull(innerCredential);

            var sources = GetDefaultAzureCredentialSources(innerCredential);
            Assert.IsNotNull(sources);
            Assert.AreEqual(1, sources.Length, $"Expected exactly one credential source for Broker, but found {sources.Length}");
            // Broker maps to InteractiveBrowserCredential with broker enabled
            Assert.IsInstanceOf<InteractiveBrowserCredential>(sources[0], $"Expected InteractiveBrowserCredential for Broker but got {sources[0].GetType().Name}");
        }

        [Test]
        public void Constructor_WithBrokerCredentialSource_BackCompat_CreatesExactlyOneInteractiveBrowserCredential()
        {
            var settings = CreateCredentialSettings("Broker");

            var credential = new ConfigurableCredential(settings);
            var innerCredential = GetInnerCredential(credential) as DefaultAzureCredential;

            Assert.IsNotNull(innerCredential);

            var sources = GetDefaultAzureCredentialSources(innerCredential);
            Assert.IsNotNull(sources);
            Assert.AreEqual(1, sources.Length, $"Expected exactly one credential source for Broker, but found {sources.Length}");
            // Broker maps to InteractiveBrowserCredential with broker enabled
            Assert.IsInstanceOf<InteractiveBrowserCredential>(sources[0], $"Expected InteractiveBrowserCredential for Broker but got {sources[0].GetType().Name}");
        }

        [Test]
        public void Constructor_WithNullCredentialSource_CreatesDefaultChain()
        {
            var settings = CreateCredentialSettings(null, null);
            var credential = new ConfigurableCredential(settings);

            // Null CredentialSource means use the default credential chain
            Assert.IsNotNull(credential);
            Assert.IsInstanceOf<DefaultAzureCredential>(GetInnerCredential(credential));
        }

        [Test]
        public void Constructor_WithApiKeyButNullKey_CreatesApiKeyWithNullToken()
        {
            var settings = CreateCredentialSettings("ApiKey", null);
            var credential = new ConfigurableCredential(settings);
            var innerCredential = GetInnerCredential(credential);
            var apiKeyToken = GetApiKeyToken(credential);

            Assert.IsNull(innerCredential);
            Assert.IsNull(apiKeyToken.Token);
            Assert.AreEqual(DateTimeOffset.MaxValue, apiKeyToken.ExpiresOn);
        }

        [Test]
        public void Constructor_WithApiKeyButEmptyKey_CreatesApiKeyWithEmptyToken()
        {
            var settings = CreateCredentialSettings("ApiKey", string.Empty);
            var credential = new ConfigurableCredential(settings);
            var innerCredential = GetInnerCredential(credential);
            var apiKeyToken = GetApiKeyToken(credential);

            Assert.IsNull(innerCredential);
            Assert.AreEqual(string.Empty, apiKeyToken.Token);
            Assert.AreEqual(DateTimeOffset.MaxValue, apiKeyToken.ExpiresOn);
        }

        [Test]
        public async Task GetTokenAsync_WithApiKey_MultipleCallsReturnSameToken()
        {
            const string expectedApiKey = "consistent-api-key";
            var settings = CreateCredentialSettings("ApiKey", expectedApiKey);
            var credential = new ConfigurableCredential(settings);

            var context = new TokenRequestContext(new[] { "https://vault.azure.net/.default" });
            var token1 = await credential.GetTokenAsync(context, CancellationToken.None);
            var token2 = await credential.GetTokenAsync(context, CancellationToken.None);

            Assert.AreEqual(token1.Token, token2.Token);
            Assert.AreEqual(token1.ExpiresOn, token2.ExpiresOn);
            Assert.AreEqual(expectedApiKey, token1.Token);
        }

        [Test]
        public void GetToken_WithApiKey_MultipleCallsReturnSameToken()
        {
            const string expectedApiKey = "consistent-sync-api-key";
            var settings = CreateCredentialSettings("ApiKey", expectedApiKey);
            var credential = new ConfigurableCredential(settings);

            var context = new TokenRequestContext(new[] { "https://vault.azure.net/.default" });
            var token1 = credential.GetToken(context, CancellationToken.None);
            var token2 = credential.GetToken(context, CancellationToken.None);

            Assert.AreEqual(token1.Token, token2.Token);
            Assert.AreEqual(token1.ExpiresOn, token2.ExpiresOn);
            Assert.AreEqual(expectedApiKey, token1.Token);
        }

        [Test]
        public void Constructor_DifferentCredentialSources_CreateDistinctInstances()
        {
            var settings1 = CreateCredentialSettings("ApiKey", "key1");
            var settings2 = CreateCredentialSettings("ApiKey", "key2");

            var credential1 = new ConfigurableCredential(settings1);
            var credential2 = new ConfigurableCredential(settings2);

            var context = new TokenRequestContext(new[] { "https://vault.azure.net/.default" });
            var token1 = credential1.GetToken(context, CancellationToken.None);
            var token2 = credential2.GetToken(context, CancellationToken.None);

            Assert.AreNotEqual(token1.Token, token2.Token);
            Assert.AreEqual("key1", token1.Token);
            Assert.AreEqual("key2", token2.Token);
        }

        [Test]
        public void Constructor_WithDefaultAzureCredentialSource_CreatesFullDefaultChain()
        {
            var settings = CreateCredentialSettings("DefaultAzureCredential");

            var credential = new ConfigurableCredential(settings);
            var innerCredential = GetInnerCredential(credential) as DefaultAzureCredential;

            Assert.IsNotNull(innerCredential);

            var sources = GetDefaultAzureCredentialSources(innerCredential);
            Assert.IsNotNull(sources);
            Assert.Greater(sources.Length, 1, "Expected multiple credential sources in the default chain");
        }

        [TestCase("DefaultAzureCredential")]
        [TestCase("defaultazurecredential")]
        public void Constructor_WithDefaultAzureCredentialSource_VariousNames_CreatesFullDefaultChain(string credentialSource)
        {
            var settings = CreateCredentialSettings(credentialSource);

            var credential = new ConfigurableCredential(settings);
            var innerCredential = GetInnerCredential(credential) as DefaultAzureCredential;

            Assert.IsNotNull(innerCredential);
            var sources = GetDefaultAzureCredentialSources(innerCredential);
            Assert.IsNotNull(sources);
            Assert.Greater(sources.Length, 1, $"Expected multiple sources for '{credentialSource}'");
        }

        [Test]
        public void Constructor_WithArrayCredentialSource_CreatesChainedCredentials()
        {
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Credential:CredentialSource:0"] = "VisualStudio",
                    ["Credential:CredentialSource:1"] = "AzureCli"
                })
                .Build();

            var section = config.GetSection("Credential");
            var options = new DefaultAzureCredentialOptions(new CredentialSettings(section), section);
            var credential = new ConfigurableCredential(options);

            var innerCredential = GetInnerCredential(credential) as ChainedTokenCredential;
            Assert.IsNotNull(innerCredential);

            var sources = GetChainedTokenCredentialSources(innerCredential);
            Assert.AreEqual(2, sources.Length, "Expected exactly two credentials in the chain");
            Assert.IsInstanceOf<VisualStudioCredential>(sources[0]);
            Assert.IsInstanceOf<AzureCliCredential>(sources[1]);
        }

        [Test]
        public void Constructor_WithArrayCredentialSource_BackCompatShortNames()
        {
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Credential:CredentialSource:0"] = "VisualStudio",
                    ["Credential:CredentialSource:1"] = "AzurePowerShell",
                    ["Credential:CredentialSource:2"] = "AzureDeveloperCli"
                })
                .Build();

            var section = config.GetSection("Credential");
            var options = new DefaultAzureCredentialOptions(new CredentialSettings(section), section);
            var credential = new ConfigurableCredential(options);

            var innerCredential = GetInnerCredential(credential) as ChainedTokenCredential;
            Assert.IsNotNull(innerCredential);

            var sources = GetChainedTokenCredentialSources(innerCredential);
            Assert.AreEqual(3, sources.Length);
        }

        [Test]
        public void Constructor_WithApiKeyInArray_Throws()
        {
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Credential:CredentialSource:0"] = "VisualStudio",
                    ["Credential:CredentialSource:1"] = "ApiKey"
                })
                .Build();

            var section = config.GetSection("Credential");
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                var options = new DefaultAzureCredentialOptions(new CredentialSettings(section), section);
                new ConfigurableCredential(options);
            });
            Assert.That(ex.Message, Does.Contain("ApiKeyCredential"));
        }

        [Test]
        public void Constructor_WithDefaultAzureCredentialInArray_Throws()
        {
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Credential:CredentialSource:0"] = "VisualStudio",
                    ["Credential:CredentialSource:1"] = "DefaultAzureCredential"
                })
                .Build();

            var section = config.GetSection("Credential");
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                var options = new DefaultAzureCredentialOptions(new CredentialSettings(section), section);
                new ConfigurableCredential(options);
            });
            Assert.That(ex.Message, Does.Contain("DefaultAzureCredential"));
        }

        [Test]
        public void Constructor_WithEmptyArrayCredentialSource_CreatesDefaultChain()
        {
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>())
                .Build();

            var section = config.GetSection("Credential");
            // Empty config → CredentialSource is null, no array children → default chain
            var options = new DefaultAzureCredentialOptions(new CredentialSettings(section), section);
            Assert.IsNull(options.CredentialSource);
            Assert.IsNull(options.CredentialSources);
        }

        [Test]
        public void Constructor_WithSingleSourceArray_CreatesOneCredential()
        {
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Credential:CredentialSource:0"] = "ManagedIdentity"
                })
                .Build();

            var section = config.GetSection("Credential");
            var options = new DefaultAzureCredentialOptions(new CredentialSettings(section), section);
            var credential = new ConfigurableCredential(options);

            var innerCredential = GetInnerCredential(credential) as ChainedTokenCredential;
            Assert.IsNotNull(innerCredential);

            var sources = GetChainedTokenCredentialSources(innerCredential);
            Assert.AreEqual(1, sources.Length);
            Assert.IsInstanceOf<ManagedIdentityCredential>(sources[0]);
        }
    }
}
