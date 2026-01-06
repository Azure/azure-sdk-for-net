// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class WebPubSubServiceAccessUtilTests
    {
        [Test]
        public void CreateFromConnectionString_ThrowsArgumentNullException_WhenConnectionStringIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                WebPubSubServiceAccessUtil.CreateFromConnectionString(null));
        }

        [Test]
        public void CreateFromConnectionString_ThrowsArgumentNullException_WhenConnectionStringIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
                WebPubSubServiceAccessUtil.CreateFromConnectionString(string.Empty));
        }

        [Test]
        public void CreateFromConnectionString_ThrowsArgumentException_WhenEndpointIsMissing()
        {
            var connectionString = "AccessKey=testkey";

            var ex = Assert.Throws<ArgumentException>(() =>
                WebPubSubServiceAccessUtil.CreateFromConnectionString(connectionString));

            Assert.That(ex.Message, Does.Contain("Required property not found in connection string: Endpoint"));
        }

        [Test]
        public void CreateFromConnectionString_SucceedsWithoutAccessKey()
        {
            var endpoint = "https://test.webpubsub.azure.com";
            var connectionString = $"Endpoint={endpoint}";

            var result = WebPubSubServiceAccessUtil.CreateFromConnectionString(connectionString);

            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.ServiceEndpoint, Is.EqualTo(new Uri(endpoint)));
                Assert.That((result.Credential as KeyCredential).AccessKey, Is.Null);
            });
        }

        [Test]
        public void CreateFromConnectionString_ParsesValidConnectionString()
        {
            var endpoint = "https://test.webpubsub.azure.com";
            var accessKey = "test-access-key";
            var connectionString = $"Endpoint={endpoint};AccessKey={accessKey}";

            var result = WebPubSubServiceAccessUtil.CreateFromConnectionString(connectionString);

            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.ServiceEndpoint, Is.EqualTo(new Uri(endpoint)));
                Assert.That(result.Credential, Is.Not.Null);
            });
            Assert.That(result.Credential, Is.InstanceOf<KeyCredential>());
            var keyCredential = (KeyCredential)result.Credential;
            Assert.That(keyCredential.AccessKey, Is.EqualTo(accessKey));
        }

        [Test]
        public void CreateFromConnectionString_ParsesWithCustomPort()
        {
            var endpoint = "https://test.webpubsub.azure.com";
            var accessKey = "test-access-key";
            var port = "8080";
            var connectionString = $"Endpoint={endpoint};AccessKey={accessKey};Port={port}";

            var result = WebPubSubServiceAccessUtil.CreateFromConnectionString(connectionString);

            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.ServiceEndpoint.Port, Is.EqualTo(8080));
                Assert.That(result.ServiceEndpoint.Host, Is.EqualTo("test.webpubsub.azure.com"));
            });
        }

        [Test]
        [TestCase("0")]
        [TestCase("-1")]
        [TestCase("65536")]
        [TestCase("70000")]
        [TestCase("abc")]
        [TestCase("")]
        public void CreateFromConnectionString_ThrowsArgumentException_WhenPortIsInvalid(string invalidPort)
        {
            var endpoint = "https://test.webpubsub.azure.com";
            var accessKey = "test-access-key";
            var connectionString = $"Endpoint={endpoint};AccessKey={accessKey};Port={invalidPort}";

            var ex = Assert.Throws<ArgumentException>(() =>
                WebPubSubServiceAccessUtil.CreateFromConnectionString(connectionString));

            Assert.That(ex.Message, Does.Contain($"Invalid Port value: {invalidPort}"));
        }

        [Test]
        [TestCase("1")]
        [TestCase("80")]
        [TestCase("443")]
        [TestCase("8080")]
        [TestCase("65535")]
        public void CreateFromConnectionString_AcceptsValidPort(string validPort)
        {
            var endpoint = "https://test.webpubsub.azure.com";
            var accessKey = "test-access-key";
            var connectionString = $"Endpoint={endpoint};AccessKey={accessKey};Port={validPort}";

            var result = WebPubSubServiceAccessUtil.CreateFromConnectionString(connectionString);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ServiceEndpoint.Port, Is.EqualTo(int.Parse(validPort)));
        }

        [Test]
        public void CreateFromIConfiguration_ReturnsTrue_WhenConnectionStringValueExists()
        {
            var endpoint = "https://test.webpubsub.azure.com";
            var accessKey = "test-access-key";
            var connectionString = $"Endpoint={endpoint};AccessKey={accessKey}";

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "TestConnection", connectionString }
                })
                .Build();

            var section = configuration.GetSection("TestConnection");

            var success = WebPubSubServiceAccessUtil.CreateFromIConfiguration(section, TestAzureComponentFactory.Instance, out var result);

            Assert.Multiple(() =>
            {
                Assert.That(success, Is.True);
                Assert.That(result, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(result.ServiceEndpoint, Is.EqualTo(new Uri(endpoint)));
                Assert.That(result.Credential, Is.InstanceOf<KeyCredential>());
            });
            var keyCredential = (KeyCredential)result.Credential;
            Assert.That(keyCredential.AccessKey, Is.EqualTo(accessKey));
        }

        [Test]
        public void CreateFromIConfiguration_ReturnsTrue_WhenServiceUriExists()
        {
            var serviceUri = "https://test.webpubsub.azure.com";

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "TestConnection:serviceUri", serviceUri }
                })
                .Build();

            var section = configuration.GetSection("TestConnection");

            var success = WebPubSubServiceAccessUtil.CreateFromIConfiguration(section, TestAzureComponentFactory.Instance, out var result);

            Assert.Multiple(() =>
            {
                Assert.That(success, Is.True);
                Assert.That(result, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(result.ServiceEndpoint, Is.EqualTo(new Uri(serviceUri)));
                Assert.That(result.Credential, Is.InstanceOf<IdentityCredential>());
            });
        }

        [Test]
        public void CreateFromIConfiguration_ReturnsFalse_WhenNoConnectionInfoExists()
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "TestConnection:SomeOtherKey", "value" }
                })
                .Build();

            var section = configuration.GetSection("TestConnection");

            var success = WebPubSubServiceAccessUtil.CreateFromIConfiguration(section, TestAzureComponentFactory.Instance, out var result);

            Assert.Multiple(() =>
            {
                Assert.That(success, Is.False);
                Assert.That(result, Is.Null);
            });
        }

        [Test]
        public void CreateFromIConfiguration_PrefersConnectionStringOverServiceUri()
        {
            var endpoint = "https://connstring.webpubsub.azure.com";
            var accessKey = "test-access-key";
            var connectionString = $"Endpoint={endpoint};AccessKey={accessKey}";
            var serviceUri = "https://serviceuri.webpubsub.azure.com";
            var mockCredential = new Mock<TokenCredential>();

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "TestConnection", connectionString },
                    { "TestConnection:serviceUri", serviceUri }
                })
                .Build();

            var section = configuration.GetSection("TestConnection");

            var success = WebPubSubServiceAccessUtil.CreateFromIConfiguration(section, TestAzureComponentFactory.Instance, out var result);

            Assert.Multiple(() =>
            {
                Assert.That(success, Is.True);
                Assert.That(result, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                // Connection string value should be used, not serviceUri
                Assert.That(result.ServiceEndpoint, Is.EqualTo(new Uri(endpoint)));
                Assert.That(result.Credential, Is.InstanceOf<KeyCredential>());
            });
        }

        [Test]
        public void CanCreateFromIConfiguration_ReturnsTrue_WhenConnectionStringExists()
        {
            var connectionString = "Endpoint=https://test.webpubsub.azure.com;AccessKey=testkey";

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "TestConnection", connectionString }
                })
                .Build();

            var section = configuration.GetSection("TestConnection");

            var result = WebPubSubServiceAccessUtil.CanCreateFromIConfiguration(section);

            Assert.That(result, Is.True);
        }

        [Test]
        public void CanCreateFromIConfiguration_ReturnsTrue_WhenServiceUriExists()
        {
            var serviceUri = "https://test.webpubsub.azure.com";

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "TestConnection:serviceUri", serviceUri }
                })
                .Build();

            var section = configuration.GetSection("TestConnection");

            var result = WebPubSubServiceAccessUtil.CanCreateFromIConfiguration(section);

            Assert.That(result, Is.True);
        }

        [Test]
        public void CanCreateFromIConfiguration_ReturnsFalse_WhenNoConnectionInfoExists()
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "TestConnection:SomeOtherKey", "value" }
                })
                .Build();

            var section = configuration.GetSection("TestConnection");

            var result = WebPubSubServiceAccessUtil.CanCreateFromIConfiguration(section);

            Assert.That(result, Is.False);
        }
    }
}
