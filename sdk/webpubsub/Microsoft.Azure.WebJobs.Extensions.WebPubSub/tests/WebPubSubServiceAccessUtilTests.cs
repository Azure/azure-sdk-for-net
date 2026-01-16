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

            Assert.IsNotNull(result);
            Assert.AreEqual(new Uri(endpoint), result.ServiceEndpoint);
            Assert.IsNull((result.Credential as KeyCredential).AccessKey);
        }

        [Test]
        public void CreateFromConnectionString_ParsesValidConnectionString()
        {
            var endpoint = "https://test.webpubsub.azure.com";
            var accessKey = "test-access-key";
            var connectionString = $"Endpoint={endpoint};AccessKey={accessKey}";

            var result = WebPubSubServiceAccessUtil.CreateFromConnectionString(connectionString);

            Assert.IsNotNull(result);
            Assert.AreEqual(new Uri(endpoint), result.ServiceEndpoint);
            Assert.IsNotNull(result.Credential);
            Assert.IsInstanceOf<KeyCredential>(result.Credential);
            var keyCredential = (KeyCredential)result.Credential;
            Assert.AreEqual(accessKey, keyCredential.AccessKey);
        }

        [Test]
        public void CreateFromConnectionString_ParsesWithCustomPort()
        {
            var endpoint = "https://test.webpubsub.azure.com";
            var accessKey = "test-access-key";
            var port = "8080";
            var connectionString = $"Endpoint={endpoint};AccessKey={accessKey};Port={port}";

            var result = WebPubSubServiceAccessUtil.CreateFromConnectionString(connectionString);

            Assert.IsNotNull(result);
            Assert.AreEqual(8080, result.ServiceEndpoint.Port);
            Assert.AreEqual("test.webpubsub.azure.com", result.ServiceEndpoint.Host);
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

            Assert.IsNotNull(result);
            Assert.AreEqual(int.Parse(validPort), result.ServiceEndpoint.Port);
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

            Assert.IsTrue(success);
            Assert.IsNotNull(result);
            Assert.AreEqual(new Uri(endpoint), result.ServiceEndpoint);
            Assert.IsInstanceOf<KeyCredential>(result.Credential);
            var keyCredential = (KeyCredential)result.Credential;
            Assert.AreEqual(accessKey, keyCredential.AccessKey);
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

            Assert.IsTrue(success);
            Assert.IsNotNull(result);
            Assert.AreEqual(new Uri(serviceUri), result.ServiceEndpoint);
            Assert.IsInstanceOf<IdentityCredential>(result.Credential);
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

            Assert.IsFalse(success);
            Assert.IsNull(result);
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

            Assert.IsTrue(success);
            Assert.IsNotNull(result);
            // Connection string value should be used, not serviceUri
            Assert.AreEqual(new Uri(endpoint), result.ServiceEndpoint);
            Assert.IsInstanceOf<KeyCredential>(result.Credential);
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

            Assert.IsTrue(result);
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

            Assert.IsTrue(result);
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

            Assert.IsFalse(result);
        }
    }
}
