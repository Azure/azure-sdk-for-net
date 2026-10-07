// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Amqp.Framing;
using Microsoft.Azure.Amqp;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Amqp
{
    public class AmqpNonExclusiveSessionFilterCodecTests
    {
        [Test]
        public void RoundTripsSessionIdAndLockToken()
        {
            var token = Guid.NewGuid();
            var decoded = RoundTrip(new AmqpNonExclusiveSessionFilterCodec { SessionId = "session-1", LockToken = token });

            Assert.That(decoded.SessionId, Is.EqualTo("session-1"), "The session id should survive a wire round-trip.");
            Assert.That(decoded.LockToken, Is.EqualTo(token), "The lock token should survive a wire round-trip.");
        }

        [Test]
        public void RoundTripsWithoutLockToken()
        {
            // A fresh non-exclusive acquire targets a session but presents no takeover token.
            var decoded = RoundTrip(new AmqpNonExclusiveSessionFilterCodec { SessionId = "session-2", LockToken = null });

            Assert.That(decoded.SessionId, Is.EqualTo("session-2"), "The session id should survive a wire round-trip.");
            Assert.That(decoded.LockToken, Is.Null, "A null lock token should remain null after a round-trip.");
        }

        [Test]
        public void RoundTripsAcceptAnyWithoutSessionId()
        {
            // Accept-any sends a null session id; the broker assigns one. This exercises codec coverage of the
            // null-session-id shape carrying a token; client validation separately forbids presenting a takeover
            // token without a specific session id.
            var token = Guid.NewGuid();
            var decoded = RoundTrip(new AmqpNonExclusiveSessionFilterCodec { SessionId = null, LockToken = token });

            Assert.That(decoded.SessionId, Is.Null, "A null session id should remain null after a round-trip.");
            Assert.That(decoded.LockToken, Is.EqualTo(token), "The lock token should survive a wire round-trip.");
        }

        [Test]
        public void ToStringRedactsTheLockToken()
        {
            var token = Guid.NewGuid();
            var codec = new AmqpNonExclusiveSessionFilterCodec { SessionId = "session-1", LockToken = token };

            var text = codec.ToString();

            Assert.That(text, Does.Contain("non-exclusive-session-filter"), "The filter name should be present.");
            Assert.That(text, Does.Contain("session-1"), "The session id should be present.");
            Assert.That(text, Does.Not.Contain(token.ToString()), "The lock token authorizes taking the session over and must not appear in diagnostic output.");
            Assert.That(text, Does.Contain("<present>"), "The presence of a token should still be reported.");
        }

        [Test]
        public void ToStringReportsAnAbsentLockToken()
        {
            var codec = new AmqpNonExclusiveSessionFilterCodec { SessionId = "session-1" };

            Assert.That(codec.ToString(), Does.Contain("<none>"), "A filter with no token should report the token as absent.");
        }

        /// <summary>
        ///   Pins the wire contract against literals. The round-trip tests encode and decode with the same codec, so
        ///   they stay green if the descriptor changes or the two fields are swapped. Those values are what another
        ///   SDK has to reproduce byte for byte to interoperate, so they are asserted here rather than left implied.
        /// </summary>
        ///
        [Test]
        public void WireContractIsStable()
        {
            Assert.That(AmqpNonExclusiveSessionFilterCodec.Name, Is.EqualTo("com.microsoft:non-exclusive-session-filter:list"), "The descriptor name is part of the wire contract.");
            Assert.That(AmqpNonExclusiveSessionFilterCodec.Code, Is.EqualTo(0x00000137000000EUL), "The descriptor code is part of the wire contract.");

            var token = Guid.NewGuid();
            var codec = new AmqpNonExclusiveSessionFilterCodec { SessionId = "session-order", LockToken = token };

            var buffer = new ByteBuffer(codec.EncodeSize, false);
            codec.Encode(buffer);
            var encoded = new byte[buffer.Length];
            Array.Copy(buffer.Buffer, buffer.Offset, encoded, 0, buffer.Length);

            var sessionIdAt = IndexOf(encoded, System.Text.Encoding.UTF8.GetBytes("session-order"));

            // AMQP encodes a uuid in network byte order, which is not the layout Guid.ToByteArray reports on a
            // little-endian platform, so the big-endian form is what appears on the wire.
            var tokenAt = IndexOf(encoded, ToNetworkOrder(token));

            Assert.That(sessionIdAt, Is.GreaterThanOrEqualTo(0), "The session id should be present in the encoded form.");
            Assert.That(tokenAt, Is.GreaterThanOrEqualTo(0), "The lock token should be present in the encoded form, in network byte order.");
            Assert.That(sessionIdAt, Is.LessThan(tokenAt), "The session id must be encoded before the lock token; the field order is part of the wire contract.");
        }

        private static byte[] ToNetworkOrder(Guid value)
        {
            var bytes = value.ToByteArray();

            Array.Reverse(bytes, 0, 4);
            Array.Reverse(bytes, 4, 2);
            Array.Reverse(bytes, 6, 2);

            return bytes;
        }

        private static int IndexOf(byte[] haystack, byte[] needle)
        {
            for (var index = 0; index + needle.Length <= haystack.Length; ++index)
            {
                var found = true;

                for (var offset = 0; offset < needle.Length; ++offset)
                {
                    if (haystack[index + offset] != needle[offset])
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    return index;
                }
            }

            return -1;
        }

        private static AmqpNonExclusiveSessionFilterCodec RoundTrip(AmqpNonExclusiveSessionFilterCodec original)
        {
            // The described type must be registered before it can be decoded by descriptor; AmqpReceiver's static
            // constructor performs that registration in production, so trigger it here.
            RuntimeHelpers.RunClassConstructor(typeof(AmqpReceiver).TypeHandle);

            var buffer = new ByteBuffer(AmqpCodec.GetSerializableEncodeSize(original), false);
            AmqpCodec.EncodeSerializable(original, buffer);
            return (AmqpNonExclusiveSessionFilterCodec)AmqpCodec.DecodeAmqpDescribed(buffer);
        }
    }
}
