// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Core.Amqp
{
    /// <summary>
    /// Represents the data body of an AMQP message.
    /// This consists of one or more data sections.
    /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-data" />
    /// </summary>
    public class AmqpDataMessageBody : AmqpMessageBody
    {
        /// <summary>
        /// Initializes a new <see cref="AmqpDataMessageBody"/> instance with the
        /// passed in data sections.
        /// </summary>
        /// <param name="data">The data sections.</param>
        public AmqpDataMessageBody(IEnumerable<ReadOnlyMemory<byte>> data)
        {
            Data = data;
        }

        /// <summary>
        /// The data sections for the AMQP message body.
        /// </summary>
        public virtual IEnumerable<ReadOnlyMemory<byte>> Data { get; internal set; }

        /// <summary>
        /// Gets the type of the message body.
        /// </summary>
        public override AmqpMessageBodyType BodyType => AmqpMessageBodyType.Data;
    }
}
