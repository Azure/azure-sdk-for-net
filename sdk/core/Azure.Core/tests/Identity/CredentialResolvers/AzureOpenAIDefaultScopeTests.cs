// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Core.Tests.Identity.CredentialResolvers
{
    /// <summary>
    /// Verifies the AzureOpenAI default-scope quirk writes Scope at the root of the
    /// credential section (the canonical SCM 1.12.0+ location) for both code paths:
    /// the new resolver-aware <see cref="ConfigurationExtensions.GetAzureClientSettings{T}(IConfiguration, string)"/>
    /// path and the legacy <see cref="ConfigurationExtensions.WithAzureCredential{T}(T)"/> path.
    /// </summary>
    public class AzureOpenAIDefaultScopeTests
    {
        private const string OpenAIEndpoint = "https://my-aoai.openai.azure.com/";
        private const string DefaultScope = "https://cognitiveservices.azure.com/.default";

        internal class TestSettings : ClientSettings
        {
            public string Endpoint { get; set; }
            public ClientPipelineOptions Options { get; } = new ClientPipelineOptions();

            protected override void BindCore(IConfigurationSection section)
            {
                Endpoint = section["Endpoint"];
            }
        }

        private static IConfiguration BuildConfig(IDictionary<string, string> values)
            => new ConfigurationBuilder().AddInMemoryCollection(values).Build();

        [Test]
        public void GetAzureClientSettings_AzureOpenAIEndpoint_WritesScopeAtRoot()
        {
            IConfiguration config = BuildConfig(new Dictionary<string, string>
            {
                ["MyClient:Options:Endpoint"] = OpenAIEndpoint,
                ["MyClient:Credential:CredentialSource"] = "AzureCliCredential",
            });

            _ = config.GetAzureClientSettings<TestSettings>("MyClient");

            // Root location is canonical (SCM 1.12.0+ reads here first).
            Assert.AreEqual(DefaultScope, config["MyClient:Credential:Scope"]);
            // Legacy AdditionalProperties location is no longer written by Azure.Core.
            Assert.IsNull(config["MyClient:Credential:AdditionalProperties:Scope"]);
        }

        [Test]
        public void GetAzureClientSettings_NonAzureOpenAIEndpoint_DoesNotWriteScope()
        {
            IConfiguration config = BuildConfig(new Dictionary<string, string>
            {
                ["MyClient:Options:Endpoint"] = "https://example.com/",
                ["MyClient:Credential:CredentialSource"] = "AzureCliCredential",
            });

            _ = config.GetAzureClientSettings<TestSettings>("MyClient");

            Assert.IsNull(config["MyClient:Credential:Scope"]);
            Assert.IsNull(config["MyClient:Credential:AdditionalProperties:Scope"]);
        }

        [Test]
        public void GetAzureClientSettings_PreSetScopeAtRoot_NotOverwritten()
        {
            IConfiguration config = BuildConfig(new Dictionary<string, string>
            {
                ["MyClient:Options:Endpoint"] = OpenAIEndpoint,
                ["MyClient:Credential:CredentialSource"] = "AzureCliCredential",
                ["MyClient:Credential:Scope"] = "custom-scope",
            });

            _ = config.GetAzureClientSettings<TestSettings>("MyClient");

            Assert.AreEqual("custom-scope", config["MyClient:Credential:Scope"]);
        }

        [Test]
        public void WithAzureCredential_AzureOpenAIEndpoint_WritesScopeAtRoot()
        {
            IConfiguration config = BuildConfig(new Dictionary<string, string>
            {
                ["MyClient:Options:Endpoint"] = OpenAIEndpoint,
                ["MyClient:Credential:CredentialSource"] = "AzureCliCredential",
            });

            _ = config.GetClientSettings<TestSettings>("MyClient").WithAzureCredential();

            // Legacy WithAzureCredential path must also write at the canonical root location.
            Assert.AreEqual(DefaultScope, config["MyClient:Credential:Scope"]);
            Assert.IsNull(config["MyClient:Credential:AdditionalProperties:Scope"]);
        }

        [Test]
        public void WithAzureCredential_NonAzureOpenAIEndpoint_DoesNotWriteScope()
        {
            IConfiguration config = BuildConfig(new Dictionary<string, string>
            {
                ["MyClient:Options:Endpoint"] = "https://example.com/",
                ["MyClient:Credential:CredentialSource"] = "AzureCliCredential",
            });

            _ = config.GetClientSettings<TestSettings>("MyClient").WithAzureCredential();

            Assert.IsNull(config["MyClient:Credential:Scope"]);
            Assert.IsNull(config["MyClient:Credential:AdditionalProperties:Scope"]);
        }

        [Test]
        public void WithAzureCredential_PreSetScopeAtRoot_NotOverwritten()
        {
            IConfiguration config = BuildConfig(new Dictionary<string, string>
            {
                ["MyClient:Options:Endpoint"] = OpenAIEndpoint,
                ["MyClient:Credential:CredentialSource"] = "AzureCliCredential",
                ["MyClient:Credential:Scope"] = "custom-scope",
            });

            _ = config.GetClientSettings<TestSettings>("MyClient").WithAzureCredential();

            Assert.AreEqual("custom-scope", config["MyClient:Credential:Scope"]);
        }
    }
}
