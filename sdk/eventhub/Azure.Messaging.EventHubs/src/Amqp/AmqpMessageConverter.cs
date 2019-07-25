// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.EventHubs.Amqp
{
    /// <summary>
    ///   Serves as a translator between client types and AMQP messages for
    ///   communication with the Event Hubs service.
    /// </summary>
    ///
    internal class AmqpMessageConverter
    {
        /// <summary>
        ///   Converts a given <see cref="EventData" /> source into its corresponding
        ///   AMQP representation.
        /// </summary>
        ///
        /// <param name="source">The source event to convert.</param>
        /// <param name="partitionKey">The partition key to associate with the batch, if any.</param>
        ///
        /// <returns>The AMQP message that represents the converted event data.</returns>
        ///
        public virtual AmqpMessage CreateMessageFromEvent(EventData source,
                                                          string partitionKey = null)
        {
            Guard.ArgumentNotNull(nameof(source), source);
            return BuildAmqpMessageFromEvent(source, partitionKey);
        }

        /// <summary>
        ///   Converts a given set of <see cref="EventData" /> instances into a batch AMQP representation.
        /// </summary>
        ///
        /// <param name="source">The set of source events to convert.</param>
        /// <param name="partitionKey">The partition key to associate with the batch, if any.</param>
        ///
        /// <returns>The AMQP message that represents a batch containing the converted set of event data.</returns>
        ///
        public virtual AmqpMessage CreateBatchFromEvents(IEnumerable<EventData> source,
                                                         string partitionKey = null)
        {
            Guard.ArgumentNotNull(nameof(source), source);
            return BuildAmqpBatchFromEvents(source, partitionKey);
        }

        /// <summary>
        ///   Converts a given set of <see cref="AmqpMessage" /> instances into a batch AMQP representation.
        /// </summary>
        ///
        /// <param name="source">The set of source messages to convert.</param>
        /// <param name="partitionKey">The partition key to annotate the AMQP message with; if no partition key is specified, the annotation will not be made.</param>
        ///
        /// <returns>The AMQP message that represents a batch containing the converted set of event data.</returns>
        ///
        public virtual AmqpMessage CreateBatchFromMessages(IEnumerable<AmqpMessage> source,
                                                           string partitionKey = null)
        {
            Guard.ArgumentNotNull(nameof(source), source);
            return BuildAmqpBatchFromMessages(source, partitionKey);
        }

        /// <summary>
        ///   Builds a batch <see cref="AmqpMessage" /> from a set of <see cref="EventData" />
        ///   optionally propagating the custom properties.
        /// </summary>
        ///
        /// <param name="source">The set of events to use as the body of the batch message.</param>
        /// <param name="partitionKey">The partition key to annotate the AMQP message with; if no partition key is specified, the annotation will not be made.</param>
        ///
        /// <returns>The batch <see cref="AmqpMessage" /> containing the source events.</returns>
        ///
        private static AmqpMessage BuildAmqpBatchFromEvents(IEnumerable<EventData> source,
                                                            string partitionKey) =>
            BuildAmqpBatchFromMessages(
                source.Select(eventData => BuildAmqpMessageFromEvent(eventData, partitionKey)),
                partitionKey);

        /// <summary>
        ///   Builds a batch <see cref="AmqpMessage" /> from a set of <see cref="AmqpMessage" />.
        /// </summary>
        ///
        /// <param name="source">The set of messages to use as the body of the batch message.</param>
        /// <param name="partitionKey">The partition key to annotate the AMQP message with; if no partition key is specified, the annotation will not be made.</param>
        ///
        /// <returns>The batch <see cref="AmqpMessage" /> containing the source messages.</returns>
        ///
        private static AmqpMessage BuildAmqpBatchFromMessages(IEnumerable<AmqpMessage> source,
                                                              string partitionKey)
        {
            AmqpMessage batchEnvelope;

            var batchMessages = source.ToList();

            if (batchMessages.Count == 1)
            {
                batchEnvelope = batchMessages[0];
            }
            else
            {
                batchEnvelope = AmqpMessage.Create(batchMessages.Select(message =>
                {
                    message.Batchable = true;
                    using var messageStream = message.ToStream();
                    return new Data { Value = ReadStreamToArraySegment(messageStream) };
                }));
            }

            if (!String.IsNullOrEmpty(partitionKey))
            {
                batchEnvelope.MessageAnnotations.Map[AmqpAnnotation.PartitionKey] = partitionKey;
            }

            batchEnvelope.Batchable = true;
            batchEnvelope.MessageFormat = AmqpConstants.AmqpBatchedMessageFormat;

            return batchEnvelope;
        }

        /// <summary>
        ///   Builds an <see cref="AmqpMessage" /> from an <see cref="EventData" />
        ///   source, optionally propagating the custom properties.
        /// </summary>
        ///
        /// <param name="source">The event to use as the source of the message.</param>
        /// <param name="partitionKey">The partition key to annotate the AMQP message with; if no partition key is specified, the annotation will not be made.</param>
        ///
        /// <returns>The <see cref="AmqpMessage" /> constructed from the source event.</returns>
        ///
        private static AmqpMessage BuildAmqpMessageFromEvent(EventData source,
                                                             string partitionKey)
        {
            var body = new ArraySegment<byte>((source.Body.IsEmpty) ? Array.Empty<byte>() : source.Body.ToArray());
            var message = AmqpMessage.Create(new Data { Value = body });

            if (source.Properties?.Count > 0)
            {
                message.ApplicationProperties = message.ApplicationProperties ?? new ApplicationProperties();

                foreach (var pair in source.Properties)
                {
                    if (TryCreateAmqpPropertyValueForEventProperty(pair.Value, out var amqpValue))
                    {
                        message.ApplicationProperties.Map[pair.Key] = amqpValue;
                    }
                }
            }

            if (!String.IsNullOrEmpty(partitionKey))
            {
                message.MessageAnnotations.Map[AmqpAnnotation.PartitionKey] = partitionKey;
            }

            return message;
        }

        /// <summary>
        ///   Attempts to create an AMQP property value for a given event
        ///   property.
        /// </summary>
        ///
        /// <param name="eventPropertyValue">The value of the event property to create an AMQP property value for.</param>
        /// <param name="amqpPropertyValue">The AMQP property value that was created.</param>
        ///
        /// <returns><c>true</c> if an AMQP property value was able to be created; otherwise, <c>false</c>.</returns>
        ///
        private static bool TryCreateAmqpPropertyValueForEventProperty(object eventPropertyValue,
                                                                       out object amqpPropertyValue)
        {
            amqpPropertyValue = null;

            if (eventPropertyValue == null)
            {
                return true;
            }

            switch (GetTypeIdentifier(eventPropertyValue))
            {
                case AmqpProperty.Type.Byte:
                case AmqpProperty.Type.SByte:
                case AmqpProperty.Type.Int16:
                case AmqpProperty.Type.Int32:
                case AmqpProperty.Type.Int64:
                case AmqpProperty.Type.UInt16:
                case AmqpProperty.Type.UInt32:
                case AmqpProperty.Type.UInt64:
                case AmqpProperty.Type.Single:
                case AmqpProperty.Type.Double:
                case AmqpProperty.Type.Boolean:
                case AmqpProperty.Type.Decimal:
                case AmqpProperty.Type.Char:
                case AmqpProperty.Type.Guid:
                case AmqpProperty.Type.DateTime:
                case AmqpProperty.Type.String:
                    amqpPropertyValue = eventPropertyValue;
                    break;

                case AmqpProperty.Type.Stream:
                case AmqpProperty.Type.Unknown when eventPropertyValue is Stream:
                    amqpPropertyValue = ReadStreamToArraySegment((Stream)eventPropertyValue);
                    break;

                case AmqpProperty.Type.Uri:
                    amqpPropertyValue = new DescribedType(AmqpProperty.Uri, ((Uri)eventPropertyValue).AbsoluteUri);
                    break;

                case AmqpProperty.Type.DateTimeOffset:
                    amqpPropertyValue = new DescribedType(AmqpProperty.DateTimeOffset, ((DateTimeOffset)eventPropertyValue).UtcTicks);
                    break;

                case AmqpProperty.Type.TimeSpan:
                    amqpPropertyValue = new DescribedType(AmqpProperty.TimeSpan, ((TimeSpan)eventPropertyValue).Ticks);
                    break;

                case AmqpProperty.Type.Unknown:
                    var exception = new SerializationException(String.Format(CultureInfo.CurrentCulture, Resources.FailedToSerializeUnsupportedType, eventPropertyValue.GetType().FullName));
                    EventHubsEventSource.Log.UnexpectedException(exception.Message);
                    throw exception;
            }

            return (amqpPropertyValue != null);
        }

        /// <summary>
        ///   Gets the AMQP property type identifier for a given
        ///   value.
        /// </summary>
        ///
        /// <param name="value">The value to determine the type identifier for.</param>
        ///
        /// <returns>The <see cref="AmqpProperty.Type"/> that was identified for the given <paramref name="value"/>.</returns>
        ///
        private static AmqpProperty.Type GetTypeIdentifier(object value) =>
            (value == null)
                ? AmqpProperty.Type.Null
                : value.GetType().ToAmqpPropertyType();

        /// <summary>
        ///   Converts a stream to a set of memory bytes.
        /// </summary>
        ///
        /// <param name="stream">The stream to read and capture in memory.</param>
        ///
        /// <returns>The set of memory bytes containing the stream data.</returns>
        ///
        private static ArraySegment<byte> ReadStreamToArraySegment(Stream stream)
        {
            if (stream == null)
            {
                return new ArraySegment<byte>();
            }

            using (var memStream = new MemoryStream(512))
            {
                stream.CopyTo(memStream, 512);
                return new ArraySegment<byte>(memStream.ToArray());
            }
        }
    }
}
