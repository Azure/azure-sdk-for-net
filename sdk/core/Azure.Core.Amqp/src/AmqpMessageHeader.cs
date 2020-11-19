// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Amqp
{
    /// <summary>
    /// Represents an AMQP message transport header.
    /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-header" />
    /// </summary>
    public class AmqpMessageHeader
    {
        /// <summary>
        /// Initializes a new <see cref="AmqpMessageHeader"/> instance.
        /// </summary>
        internal AmqpMessageHeader() { }

        /// <summary>
        /// Gets or sets the durable value from the AMQP message transport header.
        /// </summary>
        public bool? Durable { get; set; }

        /// <summary>
        /// Gets or sets the priority value from the AMQP message transport header.
        /// </summary>
        public byte? Priority { get; set; }

        /// <summary>
        /// Gets or sets the ttl value from the AMQP message transport header.
        /// </summary>
        public TimeSpan? TimeToLive { get; set; }

        /// <summary>
        /// Gets or sets the first-acquirer value from the AMQP message transport header.
        /// </summary>
        public bool? FirstAcquirer { get; set; }

        /// <summary>
        /// Gets or sets the delivery-count value from the AMQP message transport header.
        /// </summary>
        public uint? DeliveryCount { get; set; }
    }
}
