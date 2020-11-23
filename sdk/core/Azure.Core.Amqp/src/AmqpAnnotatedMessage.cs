// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        /// Initializes a new Data body <see cref="AmqpAnnotatedMessage"/>.
        /// </summary>
        /// <param name="body">The data sections comprising the message body.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-data"/>
        /// </param>
        public AmqpAnnotatedMessage(AmqpMessageBody body)
        {
            Body = body;
        }

        /// <summary>
        /// Gets the header of the AMQP message.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-header" />
        /// </summary>
        public AmqpMessageHeader Header { get; } = new AmqpMessageHeader();

        /// <summary>
        /// Gets the footer of the AMQP message.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-footer" />
        /// </summary>
        public IDictionary<string, object> Footer
        {
            get
            {
                if (_footer == null)
                {
                    _footer = new Dictionary<string, object>();
                }
                return _footer;
            }
        }

        private Dictionary<string, object>? _footer;

        /// <summary>
        /// Gets the delivery annotations of the AMQP message.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-delivery-annotations"/>
        /// </summary>
        public IDictionary<string, object> DeliveryAnnotations
        {
            get
            {
                if (_deliveryAnnotations == null)
                {
                    _deliveryAnnotations = new Dictionary<string, object>();
                }
                return _deliveryAnnotations;
            }
        }

        private Dictionary<string, object>? _deliveryAnnotations;

        /// <summary>
        /// Gets the message annotations of the AMQP message.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-message-annotations"/>
        /// </summary>
        public IDictionary<string, object> MessageAnnotations
        {
            get
            {
                if (_messageAnnotations == null)
                {
                    _messageAnnotations = new Dictionary<string, object>();
                }
                return _messageAnnotations;
            }
        }

        private Dictionary<string, object>? _messageAnnotations;

        /// <summary>
        /// Gets the properties of the AMQP message.
        /// </summary>
        public AmqpMessageProperties Properties { get; } = new AmqpMessageProperties();

        /// <summary>
        /// Gets the application properties of the AMQP message.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-application-properties"/>
        /// </summary>
        public IDictionary<string, object> ApplicationProperties
        {
            get
            {
                if (_applicationProperties == null)
                {
                    _applicationProperties = new Dictionary<string, object>();
                }
                return _applicationProperties;
            }
        }

        private Dictionary<string, object>? _applicationProperties;

        /// <summary>
        /// Gets or sets the body of the AMQP message.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-data"/>
        /// </summary>
        public AmqpMessageBody Body { get; set; }
    }
}
