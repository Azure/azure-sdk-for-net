// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
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

        [Test]
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
        public void Constructor_WithNullCredentialSource_Throws()
        {
            var settings = CreateCredentialSettings(null, null);

            var ex = Assert.Throws<InvalidOperationException>(() => new ConfigurableCredential(settings));
            Assert.That(ex.Message, Does.Contain("CredentialSource is required"));
        }

        [Test]
        [TestCase("VisualStudio", typeof(VisualStudioCredential))]
        [TestCase("AzureCli", typeof(AzureCliCredential))]
        [TestCase("AzurePowerShell", typeof(AzurePowerShellCredential))]
        [TestCase("ManagedIdentity", typeof(ManagedIdentityCredential))]
        public void Constructor_VariousCredentialSources_CreatesCorrectSingleCredential(string credentialSource, Type expectedType)
        {
            var settings = CreateCredentialSettings(credentialSource);
            var credential = new ConfigurableCredential(settings);
            var innerCredential = GetInnerCredential(credential) as DefaultAzureCredential;

            Assert.IsNotNull(innerCredential);

            var sources = GetDefaultAzureCredentialSources(innerCredential);
            Assert.IsNotNull(sources);
            Assert.AreEqual(1, sources.Length, $"Expected exactly one credential for {credentialSource}");
            Assert.IsInstanceOf(expectedType, sources[0]);

            // Verify no API key token was created
            var apiKeyToken = GetApiKeyToken(credential);
            Assert.AreEqual(default(AccessToken), apiKeyToken);
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
        public void Constructor_WithAzureCliSource_OnlyAzureCliCredentialInChain()
        {
            var settings = CreateCredentialSettings("AzureCli");
            var credential = new ConfigurableCredential(settings);
            var innerCredential = GetInnerCredential(credential) as DefaultAzureCredential;

            var sources = GetDefaultAzureCredentialSources(innerCredential);

            // Verify only one credential is present
            Assert.AreEqual(1, sources.Length);

            // Verify it's the correct type
            Assert.IsInstanceOf<AzureCliCredential>(sources[0]);

            // Verify no other credential types are present
            Assert.IsFalse(sources.Any(s => s is VisualStudioCredential));
            Assert.IsFalse(sources.Any(s => s is ManagedIdentityCredential));
            Assert.IsFalse(sources.Any(s => s is EnvironmentCredential));
        }

        [Test]
        public void Constructor_WithManagedIdentitySource_OnlyManagedIdentityCredentialInChain()
        {
            var settings = CreateCredentialSettings("ManagedIdentity");
            var credential = new ConfigurableCredential(settings);
            var innerCredential = GetInnerCredential(credential) as DefaultAzureCredential;

            var sources = GetDefaultAzureCredentialSources(innerCredential);

            // Verify only one credential is present
            Assert.AreEqual(1, sources.Length);

            // Verify it's the correct type
            Assert.IsInstanceOf<ManagedIdentityCredential>(sources[0]);

            // Verify no other credential types are present
            Assert.IsFalse(sources.Any(s => s is AzureCliCredential));
            Assert.IsFalse(sources.Any(s => s is VisualStudioCredential));
            Assert.IsFalse(sources.Any(s => s is EnvironmentCredential));
        }
    }
}
