﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Azure.Messaging.EventHubs.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubConnectionOptionsExtensions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventHubConnectionOptionsExtensionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConnectionOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
           var options = new EventHubConnectionOptions
            {
                TransportType = EventHubsTransportType.AmqpWebSockets,
                Proxy = Mock.Of<IWebProxy>(),
                CustomEndpointAddress = new Uri("https://fake.servciebus.net"),
                SendBufferSizeInBytes = 65,
                ReceiveBufferSizeInBytes = 66,
                CertificateValidationCallback = (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => false
            };

            EventHubConnectionOptions clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");
            Assert.That(clone.TransportType, Is.EqualTo(options.TransportType), "The connection type of the clone should match.");
            Assert.That(clone.Proxy, Is.EqualTo(options.Proxy), "The proxy of the clone should match.");
            Assert.That(clone.CustomEndpointAddress, Is.EqualTo(options.CustomEndpointAddress), "The custom endpoint address clone should match.");
            Assert.That(clone.SendBufferSizeInBytes, Is.EqualTo(options.SendBufferSizeInBytes), "The send buffer size clone should match.");
            Assert.That(clone.ReceiveBufferSizeInBytes, Is.EqualTo(options.ReceiveBufferSizeInBytes), "The receive buffer size clone should match.");
            Assert.That(clone.CertificateValidationCallback, Is.SameAs(options.CertificateValidationCallback), "The validation callback clone should match.");
        }
    }
}
