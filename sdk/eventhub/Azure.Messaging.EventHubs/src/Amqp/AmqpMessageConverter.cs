// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Azure.Core;
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
        /// <summary>The size, in bytes, to use as a buffer for stream operations.</summary>
        private const int StreamBufferSizeInBytes = 512;

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
        /// <remarks>
        ///   The caller is assumed to hold ownership over the message once it has been created, including
        ///   ensuring proper disposal.
        /// </remarks>
        ///
        public virtual AmqpMessage CreateMessageFromEvent(EventData source,
                                                          string partitionKey = null)
        {
            Argument.AssertNotNull(source, nameof(source));
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
        /// <remarks>
        ///   The caller is assumed to hold ownership over the message once it has been created, including
        ///   ensuring proper disposal.
        /// </remarks>
        ///
        public virtual AmqpMessage CreateBatchFromEvents(IEnumerable<EventData> source,
                                                         string partitionKey = null)
        {
            Argument.AssertNotNull(source, nameof(source));
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
        /// <remarks>
        ///   The caller is assumed to hold ownership over the message once it has been created, including
        ///   ensuring proper disposal.
        /// </remarks>
        ///
        public virtual AmqpMessage CreateBatchFromMessages(IEnumerable<AmqpMessage> source,
                                                           string partitionKey = null)
        {
            Argument.AssertNotNull(source, nameof(source));
            return BuildAmqpBatchFromMessages(source, partitionKey);
        }

        /// <summary>
        ///   Converts a given <see cref="AmqpMessage" /> source into its corresponding
        ///   <see cref="EventData" /> representation.
        /// </summary>
        ///
        /// <param name="source">The source message to convert.</param>
        ///
        /// <returns>The event that represents the converted AMQP message.</returns>
        ///
        /// <remarks>
        ///   The caller is assumed to hold ownership over the specified message, including
        ///   ensuring proper disposal.
        /// </remarks>
        ///
        public virtual EventData CreateEventFromMessage(AmqpMessage source)
        {
            Argument.AssertNotNull(source, nameof(source));
            return BuildEventFromAmqpMessage(source);
        }

        /// <summary>
        ///   Creates an <see cref="AmqpMessage" /> for use in requesting the properties of an Event Hub.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub to query the properties of.</param>
        /// <param name="managementAuthorizationToken">The bearer token to use for authorization of management operations.</param>
        ///
        /// <returns>The AMQP message for issuing the request.</returns>
        ///
        /// <remarks>
        ///   The caller is assumed to hold ownership over the message once it has been created, including
        ///   ensuring proper disposal.
        /// </remarks>
        ///
        public virtual AmqpMessage CreateEventHubPropertiesRequest(string eventHubName,
                                                                   string managementAuthorizationToken)
        {
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNullOrEmpty(managementAuthorizationToken, nameof(managementAuthorizationToken));

            var request = AmqpMessage.Create();
            request.ApplicationProperties = new ApplicationProperties();
            request.ApplicationProperties.Map[AmqpManagement.ResourceNameKey] = eventHubName;
            request.ApplicationProperties.Map[AmqpManagement.OperationKey] = AmqpManagement.ReadOperationValue;
            request.ApplicationProperties.Map[AmqpManagement.ResourceTypeKey] = AmqpManagement.EventHubResourceTypeValue;
            request.ApplicationProperties.Map[AmqpManagement.SecurityTokenKey] = managementAuthorizationToken;

            return request;
        }

        /// <summary>
        ///   Converts a given <see cref="AmqpMessage" /> response to a query for Event Hub properties into the
        ///   corresponding <see cref="EventHubProperties" /> representation.
        /// </summary>
        ///
        /// <param name="response">The response message to convert.</param>
        ///
        /// <returns>The set of properties represented by the response.</returns>
        ///
        /// <remarks>
        ///   The caller is assumed to hold ownership over the specified message, including
        ///   ensuring proper disposal.
        /// </remarks>
        ///
        public virtual EventHubProperties CreateEventHubPropertiesFromResponse(AmqpMessage response)
        {
            Argument.AssertNotNull(response, nameof(response));

            if (!(response.ValueBody?.Value is AmqpMap responseData))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidMessageBody, typeof(AmqpMap).Name));
            }

            return new EventHubProperties(
                (string)responseData[AmqpManagement.ResponseMap.Name],
                new DateTimeOffset((DateTime)responseData[AmqpManagement.ResponseMap.CreatedAt], TimeSpan.Zero),
                (string[])responseData[AmqpManagement.ResponseMap.PartitionIdentifiers]);
        }

        /// <summary>
        ///   Creates an <see cref="AmqpMessage" /> for use in requesting the properties of an Event Hub partition.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub to query the properties of.</param>
        /// <param name="partitionIdentifier">The identifier of the partition to query the properties of.</param>
        /// <param name="managementAuthorizationToken">The bearer token to use for authorization of management operations.</param>
        ///
        /// <returns>The AMQP message for issuing the request.</returns>
        ///
        /// <remarks>
        ///   The caller is assumed to hold ownership over the message once it has been created, including
        ///   ensuring proper disposal.
        /// </remarks>
        ///
        public virtual AmqpMessage CreatePartitionPropertiesRequest(string eventHubName,
                                                                    string partitionIdentifier,
                                                                    string managementAuthorizationToken)
        {
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNullOrEmpty(partitionIdentifier, nameof(partitionIdentifier));
            Argument.AssertNotNullOrEmpty(managementAuthorizationToken, nameof(managementAuthorizationToken));

            var request = AmqpMessage.Create();
            request.ApplicationProperties = new ApplicationProperties();
            request.ApplicationProperties.Map[AmqpManagement.ResourceNameKey] = eventHubName;
            request.ApplicationProperties.Map[AmqpManagement.PartitionNameKey] = partitionIdentifier;
            request.ApplicationProperties.Map[AmqpManagement.OperationKey] = AmqpManagement.ReadOperationValue;
            request.ApplicationProperties.Map[AmqpManagement.ResourceTypeKey] = AmqpManagement.PartitionResourceTypeValue;
            request.ApplicationProperties.Map[AmqpManagement.SecurityTokenKey] = managementAuthorizationToken;

            return request;
        }

        /// <summary>
        ///   Converts a given <see cref="AmqpMessage" /> response to a query for Event Hub partition properties into
        ///   the corresponding <see cref="PartitionProperties" /> representation.
        /// </summary>
        ///
        /// <param name="response">The response message to convert.</param>
        ///
        /// <returns>The set of properties represented by the response.</returns>
        ///
        /// <remarks>
        ///   The caller is assumed to hold ownership over the specified message, including
        ///   ensuring proper disposal.
        /// </remarks>
        ///
        public virtual PartitionProperties CreatePartitionPropertiesFromResponse(AmqpMessage response)
        {
            Argument.AssertNotNull(response, nameof(response));

            if (!(response.ValueBody?.Value is AmqpMap responseData))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidMessageBody, typeof(AmqpMap).Name));
            }

            return new PartitionProperties(
                (string)responseData[AmqpManagement.ResponseMap.Name],
                (string)responseData[AmqpManagement.ResponseMap.PartitionIdentifier],
                (bool)responseData[AmqpManagement.ResponseMap.PartitionRuntimeInfoPartitionIsEmpty],
                (long)responseData[AmqpManagement.ResponseMap.PartitionBeginSequenceNumber],
                (long)responseData[AmqpManagement.ResponseMap.PartitionLastEnqueuedSequenceNumber],
                long.Parse((string)responseData[AmqpManagement.ResponseMap.PartitionLastEnqueuedOffset], NumberStyles.Integer, CultureInfo.InvariantCulture),
                new DateTimeOffset((DateTime)responseData[AmqpManagement.ResponseMap.PartitionLastEnqueuedTimeUtc], TimeSpan.Zero));
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

                batchEnvelope.MessageFormat = AmqpConstants.AmqpBatchedMessageFormat;
            }

            if (!string.IsNullOrEmpty(partitionKey))
            {
                batchEnvelope.MessageAnnotations.Map[AmqpProperty.PartitionKey] = partitionKey;
            }

            batchEnvelope.Batchable = true;
            return batchEnvelope;
        }

        /// <summary>
        ///   Builds an <see cref="AmqpMessage" /> from an <see cref="EventData" />.
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
                message.ApplicationProperties ??= new ApplicationProperties();

                foreach (KeyValuePair<string, object> pair in source.Properties)
                {
                    if (TryCreateAmqpPropertyValueForEventProperty(pair.Value, out var amqpValue))
                    {
                        message.ApplicationProperties.Map[pair.Key] = amqpValue;
                    }
                }
            }

            if (!string.IsNullOrEmpty(partitionKey))
            {
                message.MessageAnnotations.Map[AmqpProperty.PartitionKey] = partitionKey;
            }

            return message;
        }

        /// <summary>
        ///   Builds an <see cref="EventData" /> from an <see cref="AmqpMessage" />.
        /// </summary>
        ///
        /// <param name="source">The message to use as the source of the event.</param>
        ///
        /// <returns>The <see cref="EventData" /> constructed from the source message.</returns>
        ///
        private static EventData BuildEventFromAmqpMessage(AmqpMessage source)
        {
            ReadOnlyMemory<byte> body = (source.BodyType.HasFlag(SectionFlag.Data))
                ? ReadStreamToMemory(source.BodyStream)
                : ReadOnlyMemory<byte>.Empty;

            ParsedAnnotations systemAnnotations = ParseSystemAnnotations(source);

            // If there were application properties associated with the message, translate them
            // to the event.

            var properties = new Dictionary<string, object>();

            if (source.Sections.HasFlag(SectionFlag.ApplicationProperties))
            {
                foreach (KeyValuePair<MapKey, object> pair in source.ApplicationProperties.Map)
                {
                    if (TryCreateEventPropertyForAmqpProperty(pair.Value, out object propertyValue))
                    {
                        properties[pair.Key.ToString()] = propertyValue;
                    }
                }
            }

            return new EventData(
                eventBody: body,
                properties: properties,
                systemProperties: systemAnnotations.ServiceAnnotations,
                sequenceNumber: systemAnnotations.SequenceNumber ?? long.MinValue,
                offset: systemAnnotations.Offset ?? long.MinValue,
                enqueuedTime: systemAnnotations.EnqueuedTime ?? default,
                partitionKey: systemAnnotations.PartitionKey,
                lastPartitionSequenceNumber: systemAnnotations.LastSequenceNumber,
                lastPartitionOffset: systemAnnotations.LastOffset,
                lastPartitionEnqueuedTime: systemAnnotations.LastEnqueuedTime,
                lastPartitionPropertiesRetrievalTime: systemAnnotations.LastReceivedTime);
        }

        /// <summary>
        ///   Parses the annotations set by the Event Hubs service on the <see cref="AmqpMessage"/>
        ///   associated with an event, extracting them into a consumable form.
        /// </summary>
        ///
        /// <param name="source">The message to use as the source of the event.</param>
        ///
        /// <returns>The <see cref="ParsedAnnotations" /> parsed from the source message.</returns>
        ///
        private static ParsedAnnotations ParseSystemAnnotations(AmqpMessage source)
        {
            var systemProperties = new ParsedAnnotations
            {
                ServiceAnnotations = new Dictionary<string, object>()
            };

            object amqpValue;
            object propertyValue;

            // Process the message annotations.

            if (source.Sections.HasFlag(SectionFlag.MessageAnnotations))
            {
                Annotations annotations = source.MessageAnnotations.Map;
                var processed = new HashSet<string>();

                if ((annotations.TryGetValue(AmqpProperty.EnqueuedTime, out amqpValue))
                    && (TryCreateEventPropertyForAmqpProperty(amqpValue, out propertyValue)))
                {
                    systemProperties.EnqueuedTime = propertyValue switch
                    {
                        DateTime dateValue => new DateTimeOffset(dateValue, TimeSpan.Zero),
                        long longValue => new DateTimeOffset(longValue, TimeSpan.Zero),
                        _ => (DateTimeOffset)propertyValue
                    };

                    processed.Add(AmqpProperty.EnqueuedTime.ToString());
                }

                if ((annotations.TryGetValue(AmqpProperty.SequenceNumber, out amqpValue))
                    && (TryCreateEventPropertyForAmqpProperty(amqpValue, out propertyValue)))
                {
                    systemProperties.SequenceNumber = (long)propertyValue;
                    processed.Add(AmqpProperty.SequenceNumber.ToString());
                }

                if ((annotations.TryGetValue(AmqpProperty.Offset, out amqpValue))
                    && (TryCreateEventPropertyForAmqpProperty(amqpValue, out propertyValue))
                    && (long.TryParse((string)propertyValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out var offset)))
                {
                    systemProperties.Offset = offset;
                    processed.Add(AmqpProperty.Offset.ToString());
                }

                if ((annotations.TryGetValue(AmqpProperty.PartitionKey, out amqpValue))
                    && (TryCreateEventPropertyForAmqpProperty(amqpValue, out propertyValue)))
                {
                    systemProperties.PartitionKey = (string)propertyValue;
                    processed.Add(AmqpProperty.PartitionKey.ToString());
                }

                string key;

                foreach (KeyValuePair<MapKey, object> pair in annotations)
                {
                    key = pair.Key.ToString();

                    if ((!processed.Contains(key))
                        && (TryCreateEventPropertyForAmqpProperty(pair.Value, out propertyValue)))
                    {
                        systemProperties.ServiceAnnotations.Add(key, propertyValue);
                        processed.Add(key);
                    }
                }
            }

            // Process the delivery annotations.

            if (source.Sections.HasFlag(SectionFlag.DeliveryAnnotations))
            {
                if ((source.DeliveryAnnotations.Map.TryGetValue(AmqpProperty.PartitionLastEnqueuedTimeUtc, out amqpValue))
                    && (TryCreateEventPropertyForAmqpProperty(amqpValue, out propertyValue)))
                {
                    systemProperties.LastEnqueuedTime = propertyValue switch
                    {
                        DateTime dateValue => new DateTimeOffset(dateValue, TimeSpan.Zero),
                        long longValue => new DateTimeOffset(longValue, TimeSpan.Zero),
                        _ => (DateTimeOffset)propertyValue
                    };
                }

                if ((source.DeliveryAnnotations.Map.TryGetValue(AmqpProperty.PartitionLastEnqueuedSequenceNumber, out amqpValue))
                    && (TryCreateEventPropertyForAmqpProperty(amqpValue, out propertyValue)))
                {
                    systemProperties.LastSequenceNumber = (long)propertyValue;
                }

                if ((source.DeliveryAnnotations.Map.TryGetValue(AmqpProperty.PartitionLastEnqueuedOffset, out amqpValue))
                    && (TryCreateEventPropertyForAmqpProperty(amqpValue, out propertyValue))
                    && (long.TryParse((string)propertyValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out var offset)))
                {
                    systemProperties.LastOffset = offset;
                }

                if ((source.DeliveryAnnotations.Map.TryGetValue(AmqpProperty.LastPartitionPropertiesRetrievalTimeUtc, out amqpValue))
                    && (TryCreateEventPropertyForAmqpProperty(amqpValue, out propertyValue)))
                {
                    systemProperties.LastReceivedTime = propertyValue switch
                    {
                        DateTime dateValue => new DateTimeOffset(dateValue, TimeSpan.Zero),
                        long longValue => new DateTimeOffset(longValue, TimeSpan.Zero),
                        _ => (DateTimeOffset)propertyValue
                    };
                }
            }

            // Process the properties annotations

            if (source.Sections.HasFlag(SectionFlag.Properties))
            {
                Properties properties = source.Properties;

                void conditionalAdd(string name, object value, bool condition)
                {
                    if (condition)
                    {
                        systemProperties.ServiceAnnotations.Add(name, value);
                    }
                }

                conditionalAdd(Properties.MessageIdName, properties.MessageId, properties.MessageId != null);
                conditionalAdd(Properties.UserIdName, properties.UserId, properties.UserId.Array != null);
                conditionalAdd(Properties.ToName, properties.To, properties.To != null);
                conditionalAdd(Properties.SubjectName, properties.Subject, properties.Subject != null);
                conditionalAdd(Properties.ReplyToName, properties.ReplyTo, properties.ReplyTo != null);
                conditionalAdd(Properties.CorrelationIdName, properties.CorrelationId, properties.CorrelationId != null);
                conditionalAdd(Properties.ContentTypeName, properties.ContentType, properties.ContentType.Value != null);
                conditionalAdd(Properties.ContentEncodingName, properties.ContentEncoding, properties.ContentEncoding.Value != null);
                conditionalAdd(Properties.AbsoluteExpiryTimeName, properties.AbsoluteExpiryTime, properties.AbsoluteExpiryTime != null);
                conditionalAdd(Properties.CreationTimeName, properties.CreationTime, properties.CreationTime != null);
                conditionalAdd(Properties.GroupIdName, properties.GroupId, properties.GroupId != null);
                conditionalAdd(Properties.GroupSequenceName, properties.GroupSequence, properties.GroupSequence != null);
                conditionalAdd(Properties.ReplyToGroupIdName, properties.ReplyToGroupId, properties.ReplyToGroupId != null);
            }

            return systemProperties;
        }

        /// <summary>
        ///   Attempts to create an AMQP property value for a given event property.
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
                    amqpPropertyValue = new DescribedType(AmqpProperty.Descriptor.Uri, ((Uri)eventPropertyValue).AbsoluteUri);
                    break;

                case AmqpProperty.Type.DateTimeOffset:
                    amqpPropertyValue = new DescribedType(AmqpProperty.Descriptor.DateTimeOffset, ((DateTimeOffset)eventPropertyValue).UtcTicks);
                    break;

                case AmqpProperty.Type.TimeSpan:
                    amqpPropertyValue = new DescribedType(AmqpProperty.Descriptor.TimeSpan, ((TimeSpan)eventPropertyValue).Ticks);
                    break;

                case AmqpProperty.Type.Unknown:
                    var exception = new SerializationException(string.Format(CultureInfo.CurrentCulture, Resources.FailedToSerializeUnsupportedType, eventPropertyValue.GetType().FullName));
                    EventHubsEventSource.Log.UnexpectedException(exception.Message);
                    throw exception;
            }

            return (amqpPropertyValue != null);
        }

        /// <summary>
        ///   Attempts to create an event property value for a given AMQP property.
        /// </summary>
        ///
        /// <param name="amqpPropertyValue">The value of the AMQP property to create an event property value for.</param>
        /// <param name="eventPropertyValue">The event property value that was created.</param>
        ///
        /// <returns><c>true</c> if an event property value was able to be created; otherwise, <c>false</c>.</returns>
        ///
        private static bool TryCreateEventPropertyForAmqpProperty(object amqpPropertyValue,
                                                                  out object eventPropertyValue)
        {
            eventPropertyValue = null;

            if (amqpPropertyValue == null)
            {
                return true;
            }

            // If the property is a simple type, then use it directly.

            switch (GetTypeIdentifier(amqpPropertyValue))
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
                    eventPropertyValue = amqpPropertyValue;
                    return true;

                case AmqpProperty.Type.Unknown:
                    // An explicitly unknown type will be considered for additional
                    // scenarios below.
                    break;

                default:
                    return false;
            }

            // Attempt to parse the value against other well-known value scenarios.

            switch (amqpPropertyValue)
            {
                case AmqpSymbol symbol:
                    eventPropertyValue = symbol.Value;
                    break;

                case byte[] array:
                    eventPropertyValue = array;
                    break;

                case ArraySegment<byte> segment when segment.Count == segment.Array.Length:
                    eventPropertyValue = segment.Array;
                    break;

                case ArraySegment<byte> segment:
                    var buffer = new byte[segment.Count];
                    Buffer.BlockCopy(segment.Array, segment.Offset, buffer, 0, segment.Count);
                    eventPropertyValue = buffer;
                    break;

                case DescribedType described when (described.Descriptor is AmqpSymbol):
                    eventPropertyValue = TranslateSymbol((AmqpSymbol)described.Descriptor, described.Value);
                    break;

                default:
                    var exception = new SerializationException(string.Format(CultureInfo.CurrentCulture, Resources.FailedToSerializeUnsupportedType, amqpPropertyValue.GetType().FullName));
                    EventHubsEventSource.Log.UnexpectedException(exception.Message);
                    throw exception;
            }

            return (eventPropertyValue != null);
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
        ///   Translates the AMQP symbol into its corresponding typed value, if it belongs to the
        ///   set of known types.
        /// </summary>
        ///
        /// <param name="symbol">The symbol to consider.</param>
        /// <param name="value">The value of the symbol to translate.</param>
        ///
        /// <returns>The typed value of the symbol, if it belongs to the well-known set; otherwise, <c>null</c>.</returns>
        ///
        private static object TranslateSymbol(AmqpSymbol symbol,
                                              object value)
        {
            if (symbol.Equals(AmqpProperty.Descriptor.Uri))
            {
                return new Uri((string)value);
            }

            if (symbol.Equals(AmqpProperty.Descriptor.TimeSpan))
            {
                return new TimeSpan((long)value);
            }

            if (symbol.Equals(AmqpProperty.Descriptor.DateTimeOffset))
            {
                return new DateTimeOffset((long)value, TimeSpan.Zero);
            }

            return null;
        }

        /// <summary>
        ///   Converts a stream to an <see cref="ArraySegment{T}" /> representation.
        /// </summary>
        ///
        /// <param name="stream">The stream to read and capture in memory.</param>
        ///
        /// <returns>The <see cref="ArraySegment{T}" /> containing the stream data.</returns>
        ///
        private static ArraySegment<byte> ReadStreamToArraySegment(Stream stream)
        {
            if (stream == null)
            {
                return new ArraySegment<byte>();
            }

            using var memStream = new MemoryStream(StreamBufferSizeInBytes);
            stream.CopyTo(memStream, StreamBufferSizeInBytes);

            return new ArraySegment<byte>(memStream.ToArray());
        }

        /// <summary>
        ///   Converts a stream to a set of memory bytes.
        /// </summary>
        ///
        /// <param name="stream">The stream to read and capture in memory.</param>
        ///
        /// <returns>The set of memory bytes containing the stream data.</returns>
        ///
        private static ReadOnlyMemory<byte> ReadStreamToMemory(Stream stream)
        {
            if (stream == null)
            {
                return ReadOnlyMemory<byte>.Empty;
            }

            using var memStream = new MemoryStream(StreamBufferSizeInBytes);
            stream.CopyTo(memStream, StreamBufferSizeInBytes);

            return new ReadOnlyMemory<byte>(memStream.ToArray());
        }

        /// <summary>
        ///   The set of system annotations set on a message received from the
        ///   Event Hubs service.
        /// </summary>
        ///
        private struct ParsedAnnotations
        {
            /// <summary>The set of weakly typed annotations associated with the message.</summary>
            public Dictionary<string, object> ServiceAnnotations;

            /// <summary>The sequence number of the event associated with the message.</summary>
            public long? SequenceNumber;

            /// <summary>The offset of the event associated with the message.</summary>
            public long? Offset;

            /// <summary>The date and time, in UTC, that the event associated with the message was enqueued.</summary>
            public DateTimeOffset? EnqueuedTime;

            /// <summary>The partition key that the event associated with the message was published with.</summary>
            public string PartitionKey;

            /// <summary>The sequence number of the event that was last enqueued in the partition.</summary>
            public long? LastSequenceNumber;

            /// <summary>The offset of the event that was last enqueued in the partition.</summary>
            public long? LastOffset;

            /// <summary>The date and time, in UTC, that an event was last enqueued in the partition.</summary>
            public DateTimeOffset? LastEnqueuedTime;

            /// <summary>The date and time, in UTC, that the last enqueued event information was retrieved from the service.</summary>
            public DateTimeOffset? LastReceivedTime;
        }
    }
}
