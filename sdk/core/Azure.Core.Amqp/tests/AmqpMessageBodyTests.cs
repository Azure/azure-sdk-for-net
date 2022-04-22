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
        private static readonly object[] s_amqpValues =
        {
            "string",
            new List<string> {"first", "second"},
            'c',
            5,
            new int[] { 5 },
            long.MaxValue,
            new long[] { long.MaxValue },
            (byte) 1,
            (sbyte) 1,
            (short) 1,
            (ushort) 1,
            3.1415926,
            new double[] { 3.1415926 },
            new decimal(3.1415926),
            new decimal[] { new decimal(3.1415926) },
            new DateTimeOffset(2021, 3, 24, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
            new DateTime[] { new DateTimeOffset(2021, 3, 24, 0, 0, 0, TimeSpan.Zero).UtcDateTime },
            new DateTimeOffset(2021, 3, 24, 0, 0, 0, TimeSpan.Zero),
            new DateTimeOffset[] { new DateTimeOffset(2021, 3, 24, 0, 0, 0, TimeSpan.Zero) },
            TimeSpan.FromSeconds(5),
            new TimeSpan[] {TimeSpan.FromSeconds(5)},
            new Uri("http://localHost"),
            new Uri[] { new Uri("http://localHost") },
            new Guid("55f239a6-5d50-4f6d-8f84-deed326e4554"),
            new Guid[] { new Guid("55f239a6-5d50-4f6d-8f84-deed326e4554"), new Guid("55f239a6-5d50-4f6d-8f84-deed326e4554") },
            new Dictionary<string, string> { { "key", "value" } },
            new Dictionary<string, char> {{ "key", 'c' }},
            new Dictionary<string, int> {{ "key", 5 }},
            new Dictionary<string, byte> {{ "key", 1 } },
            new Dictionary<string, sbyte> {{ "key", 1 } },
            new Dictionary<string, short> {{ "key", 1 } },
            new Dictionary<string, double> {{ "key", 3.1415926 } },
            new Dictionary<string, decimal> {{ "key", new decimal(3.1415926) } },
            new Dictionary<string, DateTime> {{ "key", new DateTimeOffset(2021, 3, 24, 0, 0, 0, TimeSpan.Zero).UtcDateTime } },
            new Dictionary<string, DateTimeOffset> {{ "key", new DateTimeOffset(2021, 3, 24, 0, 0, 0, TimeSpan.Zero) } },
            new Dictionary<string, TimeSpan> {{ "key", TimeSpan.FromSeconds(5) } },
            new Dictionary<string, Uri> {{ "key", new Uri("http://localHost") } },
            new Dictionary<string, Guid> {{ "key", new Guid("55f239a6-5d50-4f6d-8f84-deed326e4554") } },
            new Dictionary<string, object> { { "key1", "value" }, { "key2", 2 } },
        };

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
        public void CanCreateDataBodyFactory()
        {
            var body = AmqpMessageBody.FromData(Array.Empty<ReadOnlyMemory<byte>>());
            Assert.AreEqual(AmqpMessageBodyType.Data, body.BodyType);
            Assert.IsTrue(body.TryGetData(out var data));
            Assert.NotNull(data);

            Assert.IsFalse(body.TryGetValue(out var value));
            Assert.IsNull(value);

            Assert.IsFalse(body.TryGetSequence(out var sequence));
            Assert.IsNull(sequence);
        }

        [Test]
        [TestCaseSource(nameof(s_amqpValues))]
        public void CanCreateValueBody(object input)
        {
            var body = AmqpMessageBody.FromValue(input);
            Assert.AreEqual(AmqpMessageBodyType.Value, body.BodyType);
            Assert.IsTrue(body.TryGetValue(out var output));
            Assert.AreEqual(input, output);

            Assert.IsFalse(body.TryGetData(out var data));
            Assert.IsNull(data);

            Assert.IsFalse(body.TryGetSequence(out var sequence));
            Assert.IsNull(sequence);
        }

        [Test]
        public void CanCreateSequenceBody()
        {
            var sequence = new List<object>[] { new List<object> { 1, "two" }, new List<object> { 3, "four" } };
            var body = AmqpMessageBody.FromSequence(sequence);
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
                () => AmqpMessageBody.FromData(data: null),
                Throws.InstanceOf<ArgumentNullException>());

            Assert.That(
                () => AmqpMessageBody.FromValue(value: null),
                Throws.InstanceOf<ArgumentNullException>());

            Assert.That(
                () => AmqpMessageBody.FromSequence(sequence: null),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void CannotUseCustomType()
        {
            Assert.That(
                () => AmqpMessageBody.FromValue(new Test()),
                Throws.InstanceOf<NotSupportedException>());

            Assert.That(
                () => AmqpMessageBody.FromSequence(Enumerable.Repeat(new Test[] { new Test() }, 1)),
                Throws.InstanceOf<NotSupportedException>());
        }

        private class Test
        {
        }
    }
}
