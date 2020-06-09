// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Transports.Amqp
{
    /// <summary>
    /// The types of AMQP bodies for an AMQP message.
    /// </summary>
    public enum AmqpBodyType
    {
        /// <summary>
        /// The type of body for the message could not be determined based on the information in the message.
        /// </summary>
        Unspecified,
        /// <summary>
        /// The Data body.
        /// </summary>
        Data,
        /// <summary>
        /// The Sequence body.
        /// </summary>
        Sequence,
        /// <summary>
        /// The Value body.
        /// </summary>
        Value
    }
}
