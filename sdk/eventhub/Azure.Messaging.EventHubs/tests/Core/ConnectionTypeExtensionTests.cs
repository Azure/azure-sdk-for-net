// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    [Parallelizable(ParallelScope.All)]
    public class ConnectionTypeExtensionTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="TransportTypeExtensions.GetUriScheme" />
        ///   method;
        /// </summary>
        ///
        [Test]
        [TestCase(TransportType.AmqpTcp)]
        [TestCase(TransportType.AmqpWebSockets)]
        public void GetUriSchemeUnderstandsAmqpConnectionTypes(TransportType connectionType)
        {
            var scheme = connectionType.GetUriScheme();

            Assert.That(scheme, Is.Not.Null.Or.Empty);
            Assert.That(connectionType.GetUriScheme(), Contains.Substring("amqp"));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TransportTypeExtensions.GetUriScheme" />
        ///   method;
        /// </summary>
        ///
        [Test]
        public void GetUriSchemeUDisallowsUnknownConnectionTypes()
        {
            var invalidConnectionType = (TransportType)Int32.MinValue;
            Assert.That(() => invalidConnectionType.GetUriScheme(), Throws.ArgumentException);
        }
    }
}
