// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp.Framing
{
    /// <summary>
    /// Composite source filter used to opt into non-exclusive session locking. Presence of this filter implies
    /// non-exclusive mode; <see cref="SessionId"/> targets a session (null = accept-any) and <see cref="LockToken"/>
    /// is presented to cooperatively take over an existing non-exclusive session lock. The service echoes the same
    /// filter on the attach response with the assigned session id and lock token.
    /// </summary>
    internal sealed class AmqpNonExclusiveSessionFilterCodec : DescribedList
    {
        public const string Name = AmqpConstants.Vendor + ":non-exclusive-session-filter:list";
        public const ulong Code = 0x00000137000000E;
        private const int Fields = 2;

        public AmqpNonExclusiveSessionFilterCodec() : base(Name, Code) { }

        public string SessionId { get; set; }

        public Guid? LockToken { get; set; }

        protected override int FieldCount => Fields;

        protected override void OnEncode(ByteBuffer buffer)
        {
            AmqpCodec.EncodeString(SessionId, buffer);
            AmqpCodec.EncodeUuid(LockToken, buffer);
        }

        protected override void OnDecode(ByteBuffer buffer, int count)
        {
            if (count-- > 0)
            {
                SessionId = AmqpCodec.DecodeString(buffer);
            }

            if (count > 0)
            {
                LockToken = AmqpCodec.DecodeUuid(buffer);
            }
        }

        protected override int OnValueSize()
        {
            return AmqpCodec.GetStringEncodeSize(SessionId) +
                   AmqpCodec.GetUuidEncodeSize(LockToken);
        }
    }
}
