// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core.Amqp;
using Azure.Messaging.ServiceBus.Amqp;
using Microsoft.Azure.Amqp.Framing;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Amqp
{
    /// <summary>
    ///   The suite of tests for the <see cref="MessageBody" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class MessageBodyTests
    {
        [Test]
        public void ManagesSingleReadOnlyMemoryWithoutCopying()
        {
            ReadOnlyMemory<byte> singleReadOnlyMemory = new byte[] { 1, 2, 3 };

            var message = new AmqpMessageBody(MessageBody.FromReadOnlyMemorySegment(singleReadOnlyMemory));

            message.TryGetData(out var body);
            ReadOnlyMemory<byte> fromReadOnlyMemorySegments = MessageBody.FromReadOnlyMemorySegments(body);

            Assert.IsTrue(singleReadOnlyMemory.Equals(fromReadOnlyMemorySegments));
        }

        [Test]
        public void ManagesMultipleReadOnlyMemoriesByCopyingOnConversion()
        {
            ReadOnlyMemory<byte> firstSegment = new byte[] { 1, 2, 3 };
            ReadOnlyMemory<byte> secondSegment = new byte[] { 4, 5, 6 };

            var message = new AmqpMessageBody(MessageBody.FromReadOnlyMemorySegments(new[]{ firstSegment, secondSegment }));

            message.TryGetData(out var body);
            var firstSegmentBeforeConversion = body.ElementAt(0);
            var secondSegmentBeforeConversion = body.ElementAt(1);

            ReadOnlyMemory<byte> fromReadOnlyMemorySegments = MessageBody.FromReadOnlyMemorySegments(body);
            ReadOnlyMemory<byte> convertedASecondTime = MessageBody.FromReadOnlyMemorySegments(body);

            var firstSegmentAfterConversion = body.ElementAt(0);
            var secondSegmentAfterConversion = body.ElementAt(1);

            Assert.IsTrue(firstSegment.Equals(firstSegmentBeforeConversion));
            Assert.IsTrue(secondSegment.Equals(secondSegmentBeforeConversion));

            Assert.IsFalse(firstSegment.Equals(firstSegmentAfterConversion));
            Assert.IsFalse(secondSegment.Equals(secondSegmentAfterConversion));

            Assert.AreEqual(new byte[] { 1, 2, 3, 4, 5, 6 }, fromReadOnlyMemorySegments.ToArray());
            Assert.IsTrue(fromReadOnlyMemorySegments.Equals(convertedASecondTime));
        }

        [Test]
        public void ManagesMultipleAmqpDataSegmentsByCopyingEagerly()
        {
            byte[] firstSegment = new byte[] {1, 2, 3};
            byte[]  secondSegment = new byte[] { 4, 5, 6 };

            var message = new AmqpMessageBody(MessageBody.FromDataSegments(new[]
            {
                new Data {Value = new ArraySegment<byte>(firstSegment) }, new Data {Value = new ArraySegment<byte>(secondSegment) }
            }));

            message.TryGetData(out var body);
            var firstSegmentBeforeConversion = body.ElementAt(0);
            var secondSegmentBeforeConversion = body.ElementAt(1);

            ReadOnlyMemory<byte> fromReadOnlyMemorySegments = MessageBody.FromReadOnlyMemorySegments(body);
            ReadOnlyMemory<byte> convertedASecondTime = MessageBody.FromReadOnlyMemorySegments(body);

            var firstSegmentAfterConversion = body.ElementAt(0);
            var secondSegmentAfterConversion = body.ElementAt(1);

            Assert.IsFalse(firstSegment.Equals(firstSegmentBeforeConversion));
            Assert.IsFalse(secondSegment.Equals(secondSegmentBeforeConversion));

            Assert.IsFalse(firstSegment.Equals(firstSegmentAfterConversion));
            Assert.IsFalse(secondSegment.Equals(secondSegmentAfterConversion));

            Assert.AreEqual(new byte[] { 1, 2, 3, 4, 5, 6 }, fromReadOnlyMemorySegments.ToArray());
            Assert.IsTrue(fromReadOnlyMemorySegments.Equals(convertedASecondTime));
        }
    }
}
