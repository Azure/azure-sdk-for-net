// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Amqp
{
    /// <summary>
    /// The types of AMQP bodies for an AMQP message.
    /// </summary>
    public enum AmqpBodyType
    {
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
