// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventData" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventDataTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventData.BodyAsStream "/>
        ///   property.
        /// </summary>
        ///
        [Test]
        public void BodyAsStreamReturnsTheBody()
        {
            var eventData = new EventData(new byte[] { 0x11, 0x22, 0x65, 0x78 });

            using var eventDataStream = eventData.BodyAsStream;
            using var bodyStream = new MemoryStream();
            eventDataStream.CopyTo(bodyStream);

            var streamData = bodyStream.ToArray();
            Assert.That(streamData, Is.Not.Null, "There should have been data in the stream.");
            Assert.That(streamData, Is.EqualTo(eventData.Body.ToArray()), "The body data and the data read from the stream should agree.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventData.BodyAsStream "/>
        ///   property.
        /// </summary>
        ///
        [Test]
        public void BodyAsStreamAllowsAnEmptyBody()
        {
            var eventData = new EventData(Array.Empty<byte>());

            using var eventDataStream = eventData.BodyAsStream;
            using var bodyStream = new MemoryStream();
            eventDataStream.CopyTo(bodyStream);

            var streamData = bodyStream.ToArray();
            Assert.That(streamData, Is.Not.Null, "There should have been data in the stream.");
            Assert.That(streamData.Length, Is.EqualTo(0), "The stream should have contained no data.");
        }
    }
}
