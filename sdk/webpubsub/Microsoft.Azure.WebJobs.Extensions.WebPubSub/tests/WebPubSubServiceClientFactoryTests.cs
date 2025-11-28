// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class WebPubSubServiceClientFactoryTests
    {
        [TestCase("attributeHub", "globalHub", "attributeHub")]
        [TestCase(null, "globalHub", "globalHub")]
        public void TestHubInCreatedClient(string attributeHub, string globalHub, string expectedHub)
        {
            var configuration = new ConfigurationBuilder().Build();
            var options = new WebPubSubServiceAccessOptions
            {
                Hub = globalHub,
                WebPubSubAccess = new WebPubSubServiceAccess(
                    new Uri("https://test.webpubsub.azure.com"),
                    new KeyCredential("test-key"))
            };
            var factory = new WebPubSubServiceClientFactory(
                configuration,
                TestAzureComponentFactory.Instance,
                Options.Create(options));
            var client = factory.Create(null, attributeHub);
            Assert.AreEqual(expectedHub, client.Hub);
        }

        [TestCase(null, "https://global.webpubsub.azure.com")]
        [TestCase("CustomConnection", "https://custom.webpubsub.azure.com")]
        public void TestWebPubSubEndpointInCreatedClient(string attributeConnection, string expectedEndpoint)
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(
                [
                    new KeyValuePair<string, string>("CustomConnection:ServiceUri", "https://custom.webpubsub.azure.com"),
                ])
                .Build();
            var options = new WebPubSubServiceAccessOptions
            {
                WebPubSubAccess = new WebPubSubServiceAccess(
                    new Uri("https://global.webpubsub.azure.com"),
                    new KeyCredential("global-key"))
            };
            var factory = new WebPubSubServiceClientFactory(
                configuration,
                TestAzureComponentFactory.Instance,
                Options.Create(options));
            var client = factory.Create(attributeConnection, "hub");
            Assert.AreEqual(new Uri(expectedEndpoint), client.Endpoint);
        }
    }
}