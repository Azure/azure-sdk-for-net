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
            // Accept-any sends a null session id; the broker assigns one. The token may still be presented for takeover.
            var token = Guid.NewGuid();
            var decoded = RoundTrip(new AmqpNonExclusiveSessionFilterCodec { SessionId = null, LockToken = token });

            Assert.That(decoded.SessionId, Is.Null, "A null session id should remain null after a round-trip.");
            Assert.That(decoded.LockToken, Is.EqualTo(token), "The lock token should survive a wire round-trip.");
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
