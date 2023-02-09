// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.Amqp.Shared;
using Microsoft.Azure.Amqp;

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
        public AmqpMessageHeader Header
        {
            get
            {
                if (_header == null)
                {
                    _header = new AmqpMessageHeader();
                }
                return _header;
            }
        }

        private AmqpMessageHeader? _header;

        /// <summary>
        /// Gets the footer of the AMQP message.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-footer" />
        /// </summary>
        public IDictionary<string, object?> Footer
        {
            get
            {
                if (_footer == null)
                {
                    _footer = new Dictionary<string, object?>();
                }
                return _footer;
            }
        }

        private Dictionary<string, object?>? _footer;

        /// <summary>
        /// Gets the delivery annotations of the AMQP message.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-delivery-annotations"/>
        /// </summary>
        public IDictionary<string, object?> DeliveryAnnotations
        {
            get
            {
                if (_deliveryAnnotations == null)
                {
                    _deliveryAnnotations = new Dictionary<string, object?>();
                }
                return _deliveryAnnotations;
            }
        }

        private Dictionary<string, object?>? _deliveryAnnotations;

        /// <summary>
        /// Gets the message annotations of the AMQP message.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-message-annotations"/>
        /// </summary>
        public IDictionary<string, object?> MessageAnnotations
        {
            get
            {
                if (_messageAnnotations == null)
                {
                    _messageAnnotations = new Dictionary<string, object?>();
                }
                return _messageAnnotations;
            }
        }

        private Dictionary<string, object?>? _messageAnnotations;

        /// <summary>
        /// Gets the properties of the AMQP message.
        /// </summary>
        public AmqpMessageProperties Properties
        {
            get
            {
                if (_properties == null)
                {
                    _properties = new AmqpMessageProperties();
                }
                return _properties;
            }
        }

        private AmqpMessageProperties? _properties;

        /// <summary>
        /// Gets the application properties of the AMQP message.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-application-properties"/>
        /// </summary>
        public IDictionary<string, object?> ApplicationProperties
        {
            get
            {
                if (_applicationProperties == null)
                {
                    _applicationProperties = new Dictionary<string, object?>();
                }
                return _applicationProperties;
            }
        }

        private Dictionary<string, object?>? _applicationProperties;

        /// <summary>
        /// Gets or sets the body of the AMQP message.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-data"/>
        /// </summary>
        public AmqpMessageBody Body { get; set; }

        /// <summary>
        /// Determines whether the specified section is present for the AMQP message.
        /// </summary>
        /// <param name="section">The section to consider.</param>
        /// <returns><c>true</c> if the specified <paramref name="section"/> is populated for the AMQP message; otherwise, <c>false</c>.</returns>
        public bool HasSection(AmqpMessageSection section) =>
            section switch
            {
                AmqpMessageSection.Header => (_header != null),
                AmqpMessageSection.DeliveryAnnotations => (_deliveryAnnotations != null),
                AmqpMessageSection.MessageAnnotations => (_messageAnnotations != null),
                AmqpMessageSection.Properties => (_properties != null),
                AmqpMessageSection.ApplicationProperties => (_applicationProperties != null),
                AmqpMessageSection.Body => (Body != null),
                AmqpMessageSection.Footer => (_footer != null),
                _ => throw new ArgumentException($"Unknown AMQP message section: { section }.", nameof(section))
            };

        /// <summary>
        /// Serializes the message into its AMQP binary form.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#section-message-format"/>
        /// </summary>
        /// <returns>A <see cref="BinaryData"/> instance representing the serialized message.</returns>
        public virtual BinaryData ToBytes()
        {
            var stream = AmqpAnnotatedMessageConverter.ToAmqpMessage(this).ToStream();
            return BinaryData.FromStream(stream);
        }

        /// <summary>
        /// Constructs a message from the AMQP binary serialized form.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#section-message-format"/>
        /// </summary>
        /// <param name="messageBytes">The bytes of the message.</param>
        /// <returns>A <see cref="AmqpAnnotatedMessage"/> based on the specified bytes.</returns>
        public static AmqpAnnotatedMessage FromBytes(BinaryData messageBytes)
        {
            var bufferStream = BufferListStream.Create(messageBytes.ToStream(), 4096);
            var amqpMessage = AmqpMessage.CreateInputMessage(bufferStream);
            return AmqpAnnotatedMessageConverter.FromAmqpMessage(amqpMessage);
        }
    }
}
