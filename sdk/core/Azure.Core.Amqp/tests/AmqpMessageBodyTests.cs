// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Azure.Core.Amqp.Tests
{
    public class AmqpMessageBodyTests
    {
        [Test]
        public void CanCreateDataBody()
        {
            var body = new AmqpMessageBody(Array.Empty<ReadOnlyMemory<byte>>());
            Assert.AreEqual(AmqpMessageBodyType.Data, body.BodyType);
            Assert.IsTrue(body.TryGetData(out var data));
            Assert.NotNull(data);

            Assert.IsFalse(body.TryGetValue(out var value));
            Assert.IsNull(value);

            Assert.IsFalse(body.TryGetSequence(out var sequence));
            Assert.IsNull(sequence);
        }

        [Test]
        public void CanCreateValueBody()
        {
            var body = new AmqpMessageBody("value");
            Assert.AreEqual(AmqpMessageBodyType.Value, body.BodyType);
            Assert.IsTrue(body.TryGetValue(out var value));
            Assert.AreEqual("value", value);

            Assert.IsFalse(body.TryGetData(out var data));
            Assert.IsNull(data);

            Assert.IsFalse(body.TryGetSequence(out var sequence));
            Assert.IsNull(sequence);
        }

        [Test]
        public void CanCreateSequenceBody()
        {
            var sequence = new List<object>[] { new List<object> { 1, "two" }, new List<object> { 3, "four" } };
            var body = new AmqpMessageBody(sequence);
            Assert.AreEqual(AmqpMessageBodyType.Sequence, body.BodyType);
            Assert.IsTrue(body.TryGetSequence(out var outSequence));
            var outList = outSequence.ToList();
            Assert.AreEqual(1, outList[0][0]);
            Assert.AreEqual("two", outList[0][1]);
            Assert.AreEqual(3, outList[1][0]);
            Assert.AreEqual("four", outList[1][1]);

            Assert.IsFalse(body.TryGetData(out var data));
            Assert.IsNull(data);

            Assert.IsFalse(body.TryGetValue(out var value));
            Assert.IsNull(value);
        }

        [Test]
        public void CannotCreateFromNullBody()
        {
            Assert.That(
                () => new AmqpMessageBody(data: null),
                Throws.InstanceOf<ArgumentNullException>());

            Assert.That(
                () => new AmqpMessageBody(value: null),
                Throws.InstanceOf<ArgumentNullException>());

            Assert.That(
                () => new AmqpMessageBody(sequence: null),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
