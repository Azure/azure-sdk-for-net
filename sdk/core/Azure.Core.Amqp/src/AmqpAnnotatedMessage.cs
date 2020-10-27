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
        /// <param name="messageToCopy">The message to copy.</param>
        public AmqpAnnotatedMessage(AmqpAnnotatedMessage messageToCopy)
        {
            Argument.AssertNotNull(messageToCopy, nameof(messageToCopy));

            var data = messageToCopy.Body as AmqpDataMessageBody;
            Body = new AmqpDataMessageBody(data!.Data);
            _applicationProperties = new Dictionary<string, object>(messageToCopy.ApplicationProperties);
            Properties = new AmqpMessageProperties(messageToCopy.Properties);
            _messageAnnotations = new Dictionary<string, object>(messageToCopy.MessageAnnotations);
            _deliveryAnnotations = new Dictionary<string, object>(messageToCopy.DeliveryAnnotations);
            _footer = new Dictionary<string, object>(messageToCopy.Footer);
            Header = new AmqpMessageHeader(messageToCopy.Header);
        }

        /// <summary>
        /// Creates a new Data body <see cref="AmqpAnnotatedMessage"/>.
        /// </summary>
        /// <param name="dataBody">The data sections comprising the message body.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-data"/>
        /// </param>
        public AmqpAnnotatedMessage(IEnumerable<BinaryData> dataBody)
        {
            Body = new AmqpDataMessageBody(dataBody);
        }

        /// <summary>
        /// The header of the AMQP message.
        /// </summary>
        public AmqpMessageHeader Header { get; set; } = new AmqpMessageHeader();

        /// <summary>
        /// The footer of the AMQP message.
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
        /// The delivery annotations of the AMQP message.
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
        /// The message annotations of the AMQP message.
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
        /// The properties of the AMQP message.
        /// </summary>
        public AmqpMessageProperties Properties { get; set; } = new AmqpMessageProperties();

        /// <summary>
        /// The application properties of the AMQP message.
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
        /// The body of the AMQP message.
        /// </summary>
        public AmqpMessageBody Body { get; set; }
    }
}
