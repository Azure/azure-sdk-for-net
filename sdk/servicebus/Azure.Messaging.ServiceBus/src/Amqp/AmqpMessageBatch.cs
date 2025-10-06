// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.ServiceBus.Amqp
{
    /// <summary>
    ///   A set of messages with known size constraints, based on messages to be sent
    ///   using an AMQP-based transport.
    /// </summary>
    ///
    internal class AmqpMessageBatch : TransportMessageBatch
    {
        /// <summary>The amount of bytes to reserve as overhead for a small message.</summary>
        private const byte OverheadBytesSmallMessage = 5;

        /// <summary>The amount of bytes to reserve as overhead for a large message.</summary>
        private const byte OverheadBytesLargeMessage = 8;

        /// <summary>The maximum number of bytes that a message may be to be considered small.</summary>
        private const byte MaximumBytesSmallMessage = 255;

        /// <summary>A flag that indicates whether or not the instance has been disposed.</summary>
        private bool _disposed;

        /// <summary>The size of the batch, in bytes, as it will be sent via the AMQP transport.</summary>
        private long _sizeBytes;

        /// <summary>
        ///   The maximum size allowed for the batch, in bytes.  This includes the messages in the batch as
        ///   well as any overhead for the batch itself when sent to the Queue/Topic.
        /// </summary>
        ///
        public override long MaxSizeInBytes => Options.MaxSizeInBytes.Value;

        /// <summary>
        ///   The size of the batch, in bytes, as it will be sent to the Queue/Topic
        ///   service.
        /// </summary>
        ///
        public override long SizeInBytes => _sizeBytes;

        /// <summary>
        ///   The count of messages contained in the batch.
        /// </summary>
        ///
        public override int Count => _batchMessages.Count;

        /// <summary>
        ///   The set of options to apply to the batch.
        /// </summary>
        ///
        private CreateMessageBatchOptions Options { get; }

        /// <summary>
        ///    The converter to use for translating <see cref="ServiceBusMessage" /> into an AMQP-specific message.
        /// </summary>
        private readonly AmqpMessageConverter _messageConverter;

        /// <summary>
        ///   The set of messages that have been added to the batch.
        /// </summary>
        ///
        private List<AmqpMessage> _batchMessages { get; } = new List<AmqpMessage>();

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpMessageBatch"/> class.
        /// </summary>
        ///
        /// <param name="messageConverter">The converter to use for translating <see cref="ServiceBusMessage"/> data into an AMQP-specific message.</param>
        /// <param name="options">The set of options to apply to the batch.</param>
        ///
        public AmqpMessageBatch(AmqpMessageConverter messageConverter,
                                CreateMessageBatchOptions options)
        {
            Argument.AssertNotNull(options, nameof(options));
            Argument.AssertNotNull(options.MaxSizeInBytes, nameof(options.MaxSizeInBytes));
            Argument.AssertNotNull(messageConverter, nameof(AmqpMessageConverter));

            Options = options;
            _messageConverter = messageConverter;
        }

        /// <summary>
        ///   Attempts to add a message to the batch, ensuring that the size
        ///   of the batch does not exceed its maximum.
        /// </summary>
        ///
        /// <param name="message">The message to attempt to add to the batch.</param>
        ///
        /// <returns><c>true</c> if the message was added; otherwise, <c>false</c>.</returns>
        ///
        public override bool TryAddMessage(ServiceBusMessage message)
        {
            Argument.AssertNotNull(message, nameof(message));
            Argument.AssertNotDisposed(_disposed, nameof(ServiceBusMessageBatch));

            // If the batch is full according to the message limit, then
            // reject the message.

            if ((Options.MaxMessageCount.HasValue)
                && (_batchMessages.Count >= Options.MaxMessageCount))
            {
                return false;
            }

            var amqpMessage = _messageConverter.SBMessageToAmqpMessage(message);
            long size = 0;

            if (_batchMessages.Count == 0)
            {
                // Initialize the size by reserving space for the batch envelope taking into account the properties from the first
                // message which will be used to populate properties on the batch envelope.

                using var reserveOverheadMessage =
                    _messageConverter.BuildAmqpBatchFromMessages([amqpMessage], forceBatch: true);

                size = _sizeBytes
                    + reserveOverheadMessage.SerializedMessageSize
                    + (amqpMessage.SerializedMessageSize <= MaximumBytesSmallMessage
                        ? OverheadBytesSmallMessage
                        : OverheadBytesLargeMessage);
            }
            else
            {
                // Calculate the size for the message, based on the AMQP message size and accounting for a
                // bit of reserved overhead size.

                size = _sizeBytes
                    + amqpMessage.SerializedMessageSize
                    + (amqpMessage.SerializedMessageSize <= MaximumBytesSmallMessage
                        ? OverheadBytesSmallMessage
                        : OverheadBytesLargeMessage);
            }

            if (size > MaxSizeInBytes)
            {
                amqpMessage?.Dispose();
                return false;
            }

            _sizeBytes = size;
            _batchMessages.Add(amqpMessage);

            return true;
        }

        /// <summary>
        ///   Clears the batch, removing all messages and resetting the
        ///   available size.
        /// </summary>
        ///
        public override void Clear()
        {
            foreach (var message in _batchMessages)
            {
                message.Dispose();
            }
            _batchMessages.Clear();
            _sizeBytes = 0;
        }

        /// <summary>
        ///   Represents the batch as an enumerable set of transport-specific
        ///   representations of a message.
        /// </summary>
        ///
        /// <typeparam name="T">The transport-specific message representation being requested.</typeparam>
        ///
        /// <returns>The set of messages as an enumerable of the requested type.</returns>
        ///
        public override IReadOnlyCollection<T> AsReadOnly<T>()
        {
            if (typeof(T) != typeof(AmqpMessage))
            {
                throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.UnsupportedTransportEventType, typeof(T).Name));
            }
            return (IReadOnlyCollection<T>)_batchMessages;
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="AmqpMessageBatch" />.
        /// </summary>
        ///
        public override void Dispose()
        {
            _disposed = true;
            Clear();
        }
    }
}
