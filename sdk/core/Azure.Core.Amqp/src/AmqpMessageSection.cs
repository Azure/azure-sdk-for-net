// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Amqp
{
    /// <summary>
    /// Represents the sections of an AMQP message.
    /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#section-message-format"/>
    /// </summary>
    public enum AmqpMessageSection
    {
        /// <summary>
        /// The header section of the message.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-header"/>
        /// <seealso cref="AmqpMessageHeader" />
        /// </summary>
        Header,

        /// <summary>
        /// The delivery annotations section of the message.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-delivery-annotations"/>
        /// </summary>
        DeliveryAnnotations,

        /// <summary>
        /// The message annotations section of the message.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-message-annotations"/>
        /// </summary>
        MessageAnnotations,

        /// <summary>
        /// The properties section of the message.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-properties"/>
        /// <seealso cref="AmqpMessageProperties"/>
        /// </summary>
        Properties,

        /// <summary>
        /// The application properties section of the message.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-application-properties"/>
        /// </summary>
        ApplicationProperties,

        /// <summary>
        /// The body of the message, representing one specific <see cref="AmqpMessageBodyType" /> sections.
        /// <seealso cref="AmqpMessageBody"/>
        /// </summary>
        Body,

        /// <summary>
        /// The footer section of the message.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-footer"/>
        /// </summary>
        Footer
    }
}
