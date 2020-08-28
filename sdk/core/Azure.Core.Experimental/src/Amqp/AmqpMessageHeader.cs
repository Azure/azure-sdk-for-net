// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Amqp
{
    /// <summary>
    /// Represents an AMQP message header.
    /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-header" />
    /// </summary>
    public class AmqpMessageHeader
    {
        /// <summary>
        /// Initializes a new <see cref="AmqpMessageHeader"/> instance.
        /// </summary>
        public AmqpMessageHeader() { }

        /// <summary>
        /// Initializes a new <see cref="AmqpMessageHeader"/> instance by copying the passed in header.
        /// </summary>
        /// <param name="header">The header to copy.</param>
        internal AmqpMessageHeader(AmqpMessageHeader header)
        {
            Durable = header.Durable;
            Priority = header.Priority;
            TimeToLive = header.TimeToLive;
            FirstAcquirer = header.FirstAcquirer;
            DeliveryCount = header.DeliveryCount;
        }

        /// <summary>
        /// The durable value from the AMQP transport header.
        /// </summary>
        public bool? Durable { get; set; }

        /// <summary>
        /// The priority value from the AMQP message header.
        /// </summary>
        public byte? Priority { get; set; }

        /// <summary>
        /// The ttl value from the AMQP message header.
        /// </summary>
        public TimeSpan? TimeToLive { get; set; }

        /// <summary>
        /// The first-acquirer value from the AMQP message header.
        /// </summary>
        public bool? FirstAcquirer { get; set; }

        /// <summary>
        /// The delivery-count value from the AMQP message header.
        /// </summary>
        public uint? DeliveryCount { get; set; }
    }
}
