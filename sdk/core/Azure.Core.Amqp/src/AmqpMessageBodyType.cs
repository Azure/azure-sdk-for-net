// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Amqp
{
    /// <summary>
    /// Represents the possible body types for an AMQP message.
    /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-data"/>
    /// </summary>
    public enum AmqpMessageBodyType
    {
        /// <summary>
        /// The body contains opaque binary data.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-data"/>
        /// </summary>
        Data = 0,

        /// <summary>
        /// The body contains a single AMQP value. This value is not yet supported.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-amqp-value"/>
        /// </summary>
        Value = 1,

        /// <summary>
        /// The body contains an arbitrary number of structured data elements. This value is not yet supported.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-amqp-sequence"/>
        /// </summary>
        Sequence = 2
    }
}
