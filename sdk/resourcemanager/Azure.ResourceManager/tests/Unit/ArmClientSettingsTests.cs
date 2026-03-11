// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SCME0002 // Type is for evaluation purposes only

using System;
using System.ClientModel;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ArmClientSettingsTests
    {
        [Test]
        public void BindLoadsDefaultSubscriptionId()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Client:DefaultSubscriptionId"] = "00000000-0000-0000-0000-000000000001"
                })
                .Build();

            ArmClientSettings settings = config.GetClientSettings<ArmClientSettings>("Client");

            Assert.That(settings.DefaultSubscriptionId, Is.EqualTo("00000000-0000-0000-0000-000000000001"));
        }

        [Test]
        public void BindLoadsOptions()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Client:Options:Environment:Endpoint"] = "https://management.chinacloudapi.cn",
                    ["Client:Options:Environment:Audience"] = "https://management.chinacloudapi.cn"
                })
                .Build();

            ArmClientSettings settings = config.GetClientSettings<ArmClientSettings>("Client");

            Assert.That(settings.Options, Is.Not.Null);
            Assert.That(settings.Options.Environment.HasValue, Is.True);
            Assert.That(settings.Options.Environment.Value.Endpoint, Is.EqualTo(new Uri("https://management.chinacloudapi.cn")));
            Assert.That(settings.Options.Environment.Value.Audience, Is.EqualTo("https://management.chinacloudapi.cn"));
        }

        [Test]
        public void BindLoadsCredential()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Client:Credential:CredentialSource"] = "ManagedIdentity"
                })
                .Build();

            ArmClientSettings settings = config.GetClientSettings<ArmClientSettings>("Client");

            Assert.That(settings.Credential, Is.Not.Null);
            Assert.That(settings.Credential.CredentialSource, Is.EqualTo("ManagedIdentity"));
        }

        [Test]
        public void BindLoadsAllPropertiesTogether()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Client:DefaultSubscriptionId"] = "00000000-0000-0000-0000-000000000002",
                    ["Client:Options:Environment:Endpoint"] = "https://management.usgovcloudapi.net",
                    ["Client:Options:Environment:Audience"] = "https://management.usgovcloudapi.net",
                    ["Client:Credential:CredentialSource"] = "ManagedIdentity"
                })
                .Build();

            ArmClientSettings settings = config.GetClientSettings<ArmClientSettings>("Client");

            Assert.That(settings.DefaultSubscriptionId, Is.EqualTo("00000000-0000-0000-0000-000000000002"));
            Assert.That(settings.Options, Is.Not.Null);
            Assert.That(settings.Options.Environment.HasValue, Is.True);
            Assert.That(settings.Options.Environment.Value.Endpoint, Is.EqualTo(new Uri("https://management.usgovcloudapi.net")));
            Assert.That(settings.Options.Environment.Value.Audience, Is.EqualTo("https://management.usgovcloudapi.net"));
            Assert.That(settings.Credential, Is.Not.Null);
            Assert.That(settings.Credential.CredentialSource, Is.EqualTo("ManagedIdentity"));
        }

        [Test]
        public void BindHandlesMissingOptionalProperties()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Client:DefaultSubscriptionId"] = "00000000-0000-0000-0000-000000000003"
                })
                .Build();

            ArmClientSettings settings = config.GetClientSettings<ArmClientSettings>("Client");

            Assert.That(settings.DefaultSubscriptionId, Is.EqualTo("00000000-0000-0000-0000-000000000003"));
            Assert.That(settings.Options, Is.Null);
        }

        [Test]
        public void BindHandlesMissingSubscriptionId()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Client:Options:Environment:Endpoint"] = "https://management.azure.com",
                    ["Client:Options:Environment:Audience"] = "https://management.azure.com/"
                })
                .Build();

            ArmClientSettings settings = config.GetClientSettings<ArmClientSettings>("Client");

            Assert.That(settings.DefaultSubscriptionId, Is.Null);
            Assert.That(settings.Options, Is.Not.Null);
        }

        [Test]
        public void BindHandlesMissingSection()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>())
                .Build();

            ArmClientSettings settings = config.GetClientSettings<ArmClientSettings>("NonExistentSection");

            Assert.That(settings, Is.Not.Null);
            Assert.That(settings.DefaultSubscriptionId, Is.Null);
            Assert.That(settings.Options, Is.Null);
            Assert.That(settings.Credential, Is.Not.Null);
        }

        [Test]
        public void EnvironmentNotSetWhenPartialConfig()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Client:Options:Environment:Endpoint"] = "https://management.azure.com"
                })
                .Build();

            ArmClientSettings settings = config.GetClientSettings<ArmClientSettings>("Client");

            Assert.That(settings.Options, Is.Not.Null);
            Assert.That(settings.Options.Environment.HasValue, Is.False);
        }

        [Test]
        public void DefaultSubscriptionIdCanBeSetDirectly()
        {
            var settings = new ArmClientSettings
            {
                DefaultSubscriptionId = "00000000-0000-0000-0000-000000000004"
            };

            Assert.That(settings.DefaultSubscriptionId, Is.EqualTo("00000000-0000-0000-0000-000000000004"));
        }

        [Test]
        public void OptionsCanBeSetDirectly()
        {
            var options = new ArmClientOptions();
            var settings = new ArmClientSettings
            {
                Options = options
            };

            Assert.That(settings.Options, Is.SameAs(options));
        }

        [Test]
        public void CredentialProviderCanBeSetDirectly()
        {
            var settings = new ArmClientSettings();

            Assert.That(settings.CredentialProvider, Is.Null);
        }
    }
}
