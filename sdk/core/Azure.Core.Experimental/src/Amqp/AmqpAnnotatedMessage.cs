// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Core.Amqp
{
    /// <summary>
    /// Represents an AMQP message.
    /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#section-message-format" />
    /// </summary>
    public class AmqpAnnotatedMessage
    {
        /// <summary>
        /// Initializes a new <see cref="AmqpAnnotatedMessage"/> instance by copying the passed in message.
        /// </summary>
        /// <param name="message">The message to copy.</param>
        public AmqpAnnotatedMessage(AmqpAnnotatedMessage message)
        {
            var data = message.Body as AmqpDataBody;
            Body = new AmqpDataBody(data!.Data);
            ApplicationProperties = new Dictionary<string, object>(message.ApplicationProperties);
            Properties = new AmqpMessageProperties(message.Properties);
            MessageAnnotations = new Dictionary<string, object>(message.MessageAnnotations);
            DeliveryAnnotations = new Dictionary<string, object>(message.DeliveryAnnotations);
            Footer = new Dictionary<string, object>(message.Footer);
            Header = new AmqpMessageHeader(message.Header);
        }

        /// <summary>
        /// Creates a new Data body <see cref="AmqpAnnotatedMessage"/>.
        /// </summary>
        /// <param name="dataBody">The data sections comprising the message body.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-data"/>
        /// </param>
        public AmqpAnnotatedMessage(IEnumerable<BinaryData> dataBody)
        {
            Body = new AmqpDataBody(dataBody);
        }

        /// <summary>
        /// The header of the AMQP message.
        /// </summary>
        public AmqpMessageHeader Header { get; set; } = new AmqpMessageHeader();

        /// <summary>
        /// The footer of the AMQP message.
        /// </summary>
        public IDictionary<string, object> Footer { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// The delivery annotations of the AMQP message.
        /// </summary>
        public IDictionary<string, object> DeliveryAnnotations { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// The message annotations of the AMQP message.
        /// </summary>
        public IDictionary<string, object> MessageAnnotations { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// The properties of the AMQP message.
        /// </summary>
        public AmqpMessageProperties Properties { get; set; } = new AmqpMessageProperties();

        /// <summary>
        /// The application properties of the AMQP message.
        /// </summary>
        public IDictionary<string, object> ApplicationProperties { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// The body of the AMQP message.
        /// </summary>
        public AmqpMessageBody Body { get; set; }
    }
}
