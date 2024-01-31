// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Authorization;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="AmqpClient"/> class.
    /// </summary>
    [TestFixture]
    public class AmqpClientTests
    {
        /// <summary>
        /// Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorInitializesTheEndpointsWithDefaults()
        {
            var options = new ServiceBusClientOptions();
            var endpoint = new Uri("http://fake.endpoint.com");
            var token = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>());
            var client = new AmqpClient(endpoint.Host, token.Object, options);

            Assert.That(client.ConnectionEndpoint.Host, Is.EqualTo(endpoint.Host), "The connection endpoint should have used the namespace URI.");
            Assert.That(client.ServiceEndpoint.Host, Is.EqualTo(endpoint.Host), "The service endpoint should have used the namespace URI.");
        }

        /// <summary>
        /// Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorInitializesTheEndpointsWithOptions()
        {
            var options = new ServiceBusClientOptions() { CustomEndpointAddress = new Uri("http://fake.custom.com") };
            var endpoint = new Uri("http://fake.endpoint.com");
            var token = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>());
            var client = new AmqpClient(endpoint.Host, token.Object, options);

            Assert.That(client.ConnectionEndpoint.Host, Is.EqualTo(options.CustomEndpointAddress.Host), "The connection endpoint should have used the custom endpoint URI from the options.");
            Assert.That(client.ServiceEndpoint.Host, Is.EqualTo(endpoint.Host), "The service endpoint should have used the namespace URI.");
        }
    }
}
