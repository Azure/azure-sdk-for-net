// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Core;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="TransportTypeExtensions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class ConnectionTypeExtensionTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="TransportTypeExtensions.GetUriScheme" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(TransportType.AmqpTcp)]
        [TestCase(TransportType.AmqpWebSockets)]
        public void GetUriSchemeUnderstandsAmqpConnectionTypes(TransportType transportType)
        {
            var scheme = transportType.GetUriScheme();

            Assert.That(scheme, Is.Not.Null.And.Not.Empty);
            Assert.That(transportType.GetUriScheme(), Contains.Substring("amqp"));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TransportTypeExtensions.GetUriScheme" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetUriSchemeUDisallowsUnknownConnectionTypes()
        {
            var invalidConnectionType = (TransportType)int.MinValue;
            Assert.That(() => invalidConnectionType.GetUriScheme(), Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TransportTypeExtensions.IsWebSocketTransport" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(TransportType.AmqpTcp, false)]
        [TestCase(TransportType.AmqpWebSockets, true)]
        public void IsWebSocketTransportRecognizesSocketTransports(TransportType transportType,
                                                                   bool expectedResult)
        {
            Assert.That(transportType.IsWebSocketTransport(), Is.EqualTo(expectedResult));
        }
    }
}
