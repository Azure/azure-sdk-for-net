// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.Core.Tests.Identity.CredentialResolvers
{
    /// <summary>
    /// Verifies the AzureOpenAI default-scope quirk writes Scope at the root of the
    /// credential section for both the
    /// <see cref="ConfigurationExtensions.GetAzureClientSettings{T}(IConfiguration, string)"/>
    /// path and the <see cref="ConfigurationExtensions.AddAzureClient{TClient, TSettings}(IHostApplicationBuilder, string)"/>
    /// path.
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

        internal class TestClient
        {
            public TestSettings Settings { get; }
            public TestClient(TestSettings settings) => Settings = settings;
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

            // Scope is written at the root of the credential section.
            Assert.AreEqual(DefaultScope, config["MyClient:Credential:Scope"]);
            // Scope is not duplicated under AdditionalProperties.
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
        public void AddAzureClient_AzureOpenAIEndpoint_WritesScopeAtRoot()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["MyClient:Options:Endpoint"] = OpenAIEndpoint,
                ["MyClient:Credential:CredentialSource"] = "AzureCliCredential",
            });

            builder.AddAzureClient<TestClient, TestSettings>("MyClient");

            // Resolving the client materializes settings, which runs the ConfigureCredential
            // overlay registered by AddAzureClient. After that the section reflects the override.
            using ServiceProvider provider = builder.Services.BuildServiceProvider();
            _ = provider.GetRequiredService<TestClient>();

            Assert.AreEqual(DefaultScope, builder.Configuration["MyClient:Credential:Scope"]);
            Assert.IsNull(builder.Configuration["MyClient:Credential:AdditionalProperties:Scope"]);
        }

        [Test]
        public void AddAzureClient_NonAzureOpenAIEndpoint_DoesNotWriteScope()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["MyClient:Options:Endpoint"] = "https://example.com/",
                ["MyClient:Credential:CredentialSource"] = "AzureCliCredential",
            });

            builder.AddAzureClient<TestClient, TestSettings>("MyClient");

            using ServiceProvider provider = builder.Services.BuildServiceProvider();
            _ = provider.GetRequiredService<TestClient>();

            Assert.IsNull(builder.Configuration["MyClient:Credential:Scope"]);
            Assert.IsNull(builder.Configuration["MyClient:Credential:AdditionalProperties:Scope"]);
        }

        [Test]
        public void AddAzureClient_PreSetScopeAtRoot_NotOverwritten()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["MyClient:Options:Endpoint"] = OpenAIEndpoint,
                ["MyClient:Credential:CredentialSource"] = "AzureCliCredential",
                ["MyClient:Credential:Scope"] = "custom-scope",
            });

            builder.AddAzureClient<TestClient, TestSettings>("MyClient");

            using ServiceProvider provider = builder.Services.BuildServiceProvider();
            _ = provider.GetRequiredService<TestClient>();

            Assert.AreEqual("custom-scope", builder.Configuration["MyClient:Credential:Scope"]);
        }
    }
}
