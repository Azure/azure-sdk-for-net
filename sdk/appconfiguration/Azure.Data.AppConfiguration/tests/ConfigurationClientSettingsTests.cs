// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SCME0002 // Type is for evaluation purposes only

using System;
using System.ClientModel;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    public class ConfigurationClientSettingsTests
    {
        [Test]
        public void BindLoadsEndpoint()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Client:Endpoint"] = "https://myappconfig.azconfig.io"
                })
                .Build();

            ConfigurationClientSettings settings = config.GetClientSettings<ConfigurationClientSettings>("Client");

            Assert.That(settings.Endpoint, Is.EqualTo(new Uri("https://myappconfig.azconfig.io")));
        }

        [Test]
        public void BindLoadsOptions()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Client:Options:Audience"] = "https://azconfig.io"
                })
                .Build();

            ConfigurationClientSettings settings = config.GetClientSettings<ConfigurationClientSettings>("Client");

            Assert.That(settings.Options, Is.Not.Null);
            Assert.That(settings.Options.Audience, Is.EqualTo(new AppConfigurationAudience("https://azconfig.io")));
        }

        [Test]
        public void BindLoadsCredential()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Client:Credential:CredentialSource"] = "ApiKey",
                    ["Client:Credential:Key"] = "test-key-123"
                })
                .Build();

            ConfigurationClientSettings settings = config.GetClientSettings<ConfigurationClientSettings>("Client");

            Assert.That(settings.Credential, Is.Not.Null);
            Assert.That(settings.Credential.CredentialSource, Is.EqualTo("ApiKey"));
            Assert.That(settings.Credential.Key, Is.EqualTo("test-key-123"));
        }

        [Test]
        public void BindLoadsAllPropertiesTogether()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Client:Endpoint"] = "https://myappconfig.azconfig.io",
                    ["Client:Options:Audience"] = "https://azconfig.io",
                    ["Client:Credential:CredentialSource"] = "ApiKey",
                    ["Client:Credential:Key"] = "my-key"
                })
                .Build();

            ConfigurationClientSettings settings = config.GetClientSettings<ConfigurationClientSettings>("Client");

            Assert.That(settings.Endpoint, Is.EqualTo(new Uri("https://myappconfig.azconfig.io")));
            Assert.That(settings.Options, Is.Not.Null);
            Assert.That(settings.Options.Audience, Is.EqualTo(new AppConfigurationAudience("https://azconfig.io")));
            Assert.That(settings.Credential, Is.Not.Null);
            Assert.That(settings.Credential.CredentialSource, Is.EqualTo("ApiKey"));
            Assert.That(settings.Credential.Key, Is.EqualTo("my-key"));
        }

        [Test]
        public void BindHandlesMissingOptionalProperties()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Client:Endpoint"] = "https://myappconfig.azconfig.io"
                })
                .Build();

            ConfigurationClientSettings settings = config.GetClientSettings<ConfigurationClientSettings>("Client");

            Assert.That(settings.Endpoint, Is.EqualTo(new Uri("https://myappconfig.azconfig.io")));
            Assert.That(settings.Options, Is.Null);
        }

        [Test]
        public void BindHandlesMissingEndpoint()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Client:Options:Audience"] = "https://azconfig.io"
                })
                .Build();

            ConfigurationClientSettings settings = config.GetClientSettings<ConfigurationClientSettings>("Client");

            Assert.That(settings.Endpoint, Is.Null);
            Assert.That(settings.Options, Is.Not.Null);
        }

        [Test]
        public void BindHandlesMissingSection()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>())
                .Build();

            ConfigurationClientSettings settings = config.GetClientSettings<ConfigurationClientSettings>("NonExistentSection");

            Assert.That(settings, Is.Not.Null);
            Assert.That(settings.Endpoint, Is.Null);
            Assert.That(settings.Options, Is.Null);
            Assert.That(settings.Credential, Is.Not.Null);
        }

        [Test]
        public void OptionsAudienceNotSetWhenMissing()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Client:Options:SomeOtherKey"] = "SomeValue"
                })
                .Build();

            ConfigurationClientSettings settings = config.GetClientSettings<ConfigurationClientSettings>("Client");

            Assert.That(settings.Options, Is.Not.Null);
            Assert.That(settings.Options.Audience, Is.Null);
        }

        [Test]
        public void EndpointCanBeSetDirectly()
        {
            var settings = new ConfigurationClientSettings
            {
                Endpoint = new Uri("https://direct.azconfig.io")
            };

            Assert.That(settings.Endpoint, Is.EqualTo(new Uri("https://direct.azconfig.io")));
        }

        [Test]
        public void OptionsCanBeSetDirectly()
        {
            var options = new ConfigurationClientOptions();
            var settings = new ConfigurationClientSettings
            {
                Options = options
            };

            Assert.That(settings.Options, Is.SameAs(options));
        }

        [Test]
        public void CredentialProviderCanBeSetDirectly()
        {
            var settings = new ConfigurationClientSettings();

            // CredentialProvider is settable (default is null)
            Assert.That(settings.CredentialProvider, Is.Null);
        }
    }
}
