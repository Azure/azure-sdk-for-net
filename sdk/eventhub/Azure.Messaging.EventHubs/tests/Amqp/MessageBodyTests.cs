// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core.Amqp;
using Azure.Messaging.EventHubs.Amqp;
using Microsoft.Azure.Amqp.Framing;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="MessageBody" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class MessageBodyTests
    {
        /// <summary>
        ///   Verifies behavior of the <see cref="MessageBody" />
        ///   when a single segment is specified.
        /// </summary>
        ///
        [Test]
        public void ManagesSingleReadOnlyMemoryWithoutCopying()
        {
            var singleReadOnlyMemory = new ReadOnlyMemory<byte>(new byte[] { 1, 2, 3 });
            var message = new AmqpMessageBody(MessageBody.FromReadOnlyMemorySegment(singleReadOnlyMemory));

            message.TryGetData(out var body);
            var fromReadOnlyMemorySegments = (ReadOnlyMemory<byte>)MessageBody.FromReadOnlyMemorySegments(body);

            Assert.That(fromReadOnlyMemorySegments, Is.EqualTo(singleReadOnlyMemory));
        }

        /// <summary>
        ///   Verifies behavior of the <see cref="MessageBody" /> when multiple
        ///   segments are specified and copying is lazy.
        /// </summary>
        ///
        [Test]
        public void ManagesMultipleReadOnlyMemoriesByCopyingOnConversion()
        {
            var firstSegment = new ReadOnlyMemory<byte>(new byte[] { 1, 2, 3 });
            var secondSegment = new ReadOnlyMemory<byte>(new byte[] { 4, 5, 6 });
            var allSegmentsArray = new byte[] { 1, 2, 3, 4, 5, 6 };

            var message = new AmqpMessageBody(MessageBody.FromReadOnlyMemorySegments(new ReadOnlyMemory<byte>[]{ firstSegment, secondSegment }));
            message.TryGetData(out var body);

            var firstSegmentBeforeConversion = body.ElementAt(0);
            var secondSegmentBeforeConversion = body.ElementAt(1);
            var fromReadOnlyMemorySegments = (ReadOnlyMemory<byte>)MessageBody.FromReadOnlyMemorySegments(body);
            var convertedASecondTime = (ReadOnlyMemory<byte>)MessageBody.FromReadOnlyMemorySegments(body);
            var firstSegmentAfterConversion = body.ElementAt(0);
            var secondSegmentAfterConversion = body.ElementAt(1);

            Assert.That(firstSegmentBeforeConversion, Is.EqualTo(firstSegment), "The first segment should match before conversion.");
            Assert.That(secondSegmentBeforeConversion, Is.EqualTo(secondSegment), "The second segment should match before conversion.");
            Assert.That(firstSegmentAfterConversion, Is.Not.EqualTo(firstSegment), "The first segment should not match after conversion.");
            Assert.That(secondSegmentAfterConversion, Is.Not.EqualTo(secondSegment), "The second segment should not match after conversion.");
            Assert.That(fromReadOnlyMemorySegments.ToArray(), Is.EquivalentTo(allSegmentsArray), "The unified segments should match.");
            Assert.That(convertedASecondTime, Is.EqualTo(fromReadOnlyMemorySegments), "The unified segments should match when converted a second time.");
        }

        /// <summary>
        ///   Verifies behavior of the <see cref="MessageBody" /> when multiple
        ///   <see cref="Data" /> segments are specified and copying is eager.
        /// </summary>
        ///
        [Test]
        public void ManagesMultipleAmqpDataSegmentsByCopyingEagerly()
        {
            var firstSegment = new byte[] {1, 2, 3};
            var secondSegment = new byte[] { 4, 5, 6 };
            var allSegmentsArray = new byte[] { 1, 2, 3, 4, 5, 6 };

            var message = new AmqpMessageBody(MessageBody.FromDataSegments(new[]
            {
                new Data { Value = new ArraySegment<byte>(firstSegment) },
                new Data { Value = new ArraySegment<byte>(secondSegment) }
            }));

            message.TryGetData(out var body);

            var firstSegmentBeforeConversion = body.ElementAt(0);
            var secondSegmentBeforeConversion = body.ElementAt(1);
            var fromReadOnlyMemorySegments = (ReadOnlyMemory<byte>)MessageBody.FromReadOnlyMemorySegments(body);
            var convertedASecondTime = (ReadOnlyMemory<byte>)MessageBody.FromReadOnlyMemorySegments(body);
            var firstSegmentAfterConversion = body.ElementAt(0);
            var secondSegmentAfterConversion = body.ElementAt(1);

            Assert.That(firstSegmentBeforeConversion, Is.Not.EqualTo(firstSegment), "The first segment should not match before conversion.");
            Assert.That(secondSegmentBeforeConversion, Is.Not.EqualTo(secondSegment), "The second segment should not match before conversion.");
            Assert.That(firstSegmentAfterConversion, Is.Not.EqualTo(firstSegment), "The first segment should not match after conversion.");
            Assert.That(secondSegmentAfterConversion, Is.Not.EqualTo(secondSegment), "The second segment should not match after conversion.");
            Assert.That(fromReadOnlyMemorySegments.ToArray(), Is.EquivalentTo(allSegmentsArray), "The unified segments should match.");
            Assert.That(convertedASecondTime, Is.EqualTo(fromReadOnlyMemorySegments), "The unified segments should match when converted a second time.");
        }
    }
}
