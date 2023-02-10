// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Azure.Core;
using Azure.Core.Amqp;
using Azure.Core.Amqp.Shared;
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

        /// <summary>The set of key names for annotations known to be DateTime-based system properties.</summary>
        private static readonly HashSet<string> SystemPropertyDateTimeKeys = new()
        {
            AmqpProperty.EnqueuedTime.ToString(),
            AmqpProperty.PartitionLastEnqueuedTimeUtc.ToString(),
            AmqpProperty.LastPartitionPropertiesRetrievalTimeUtc.ToString()
        };

        /// <summary>The set of key names for annotations known to be long-based system properties.</summary>
        private static readonly HashSet<string> SystemPropertyLongKeys = new()
        {
            AmqpProperty.SequenceNumber.ToString(),
            AmqpProperty.Offset.ToString(),
            AmqpProperty.PartitionLastEnqueuedSequenceNumber.ToString(),
            AmqpProperty.PartitionLastEnqueuedOffset.ToString()
        };

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
        public virtual AmqpMessage CreateBatchFromEvents(IReadOnlyCollection<EventData> source,
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
        public virtual AmqpMessage CreateBatchFromMessages(IReadOnlyCollection<AmqpMessage> source,
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
        ///   Conditionally applies the set of properties associated with message
        ///   publishing, if values were provided.
        /// </summary>
        ///
        /// <param name="message">The message to conditionally set properties on; this message will be mutated.</param>
        /// <param name="sequenceNumber">The sequence number to consider and apply.</param>
        /// <param name="groupId">The group identifier to consider and apply.</param>
        /// <param name="ownerLevel">The owner level to consider and apply.</param>
        ///
        public virtual void ApplyPublisherPropertiesToAmqpMessage(AmqpMessage message,
                                                                  int? sequenceNumber,
                                                                  long? groupId,
                                                                  short? ownerLevel) => SetPublisherProperties(message, sequenceNumber, groupId, ownerLevel);

        /// <summary>
        ///   Removes the set of properties associated with message publishing.
        /// </summary>
        ///
        /// <param name="message">The message to conditionally set properties on; this message will be mutated.</param>
        ///
        public virtual void RemovePublishingPropertiesFromAmqpMessage(AmqpMessage message)
        {
            message.MessageAnnotations.Map.TryRemoveValue<int?>(AmqpProperty.ProducerSequenceNumber, out var _);
            message.MessageAnnotations.Map.TryRemoveValue<long?>(AmqpProperty.ProducerGroupId, out var _);
            message.MessageAnnotations.Map.TryRemoveValue<short?>(AmqpProperty.ProducerOwnerLevel, out var _);
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
        private static AmqpMessage BuildAmqpBatchFromEvents(IReadOnlyCollection<EventData> source,
                                                            string partitionKey)
        {
            var messages = new List<AmqpMessage>(source.Count);

            foreach (var eventData in source)
            {
                messages.Add(BuildAmqpMessageFromEvent(eventData, partitionKey));
            }

            return BuildAmqpBatchFromMessages(messages, partitionKey);
        }

        /// <summary>
        ///   Builds a batch <see cref="AmqpMessage" /> from a set of <see cref="AmqpMessage" />.
        /// </summary>
        ///
        /// <param name="source">The set of messages to use as the body of the batch message.</param>
        /// <param name="partitionKey">The partition key to annotate the AMQP message with; if no partition key is specified, the annotation will not be made.</param>
        ///
        /// <returns>The batch <see cref="AmqpMessage" /> containing the source messages.</returns>
        ///
        /// <remarks>
        ///   The caller is assumed to hold ownership over the message once it has been created, including
        ///   ensuring proper disposal.
        /// </remarks>
        ///
        private static AmqpMessage BuildAmqpBatchFromMessages(IReadOnlyCollection<AmqpMessage> source,
                                                              string partitionKey)
        {
            AmqpMessage batchEnvelope;

            // If there is a single message, then it will be used as the
            // envelope.  To avoid mutating the instance and polluting it with
            // delivery state which prevents it from being sent during retries,
            // clone it.

            if (source.Count == 1)
            {
                switch (source)
                {
                    case List<AmqpMessage> messageList:
                        batchEnvelope = messageList[0].Clone();
                        break;

                    case AmqpMessage[] messageArray:
                        batchEnvelope = messageArray[0].Clone();
                        break;

                    default:
                        var enumerator = source.GetEnumerator();
                        enumerator.MoveNext();

                        batchEnvelope = enumerator.Current;
                        break;
                }
            }
            else
            {
                var messageData = new Data[source.Count];
                var count = 0;

                foreach (var message in source)
                {
                    message.Batchable = true;

                    using var messageStream = message.ToStream();
                    messageData[count] = new Data { Value = ReadStreamToArraySegment(messageStream) };

                    ++count;
                }

                batchEnvelope = AmqpMessage.Create(messageData);
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
        /// <remarks>
        ///   The caller is assumed to hold ownership over the message once it has been created, including
        ///   ensuring proper disposal.
        /// </remarks>
        ///
        private static AmqpMessage BuildAmqpMessageFromEvent(EventData source,
                                                             string partitionKey)
        {
            var sourceMessage = source.GetRawAmqpMessage();
            var message = AmqpAnnotatedMessageConverter.ToAmqpMessage(sourceMessage);

            // Special cases

            if (!string.IsNullOrEmpty(partitionKey))
            {
                message.MessageAnnotations.Map[AmqpProperty.PartitionKey] = partitionKey;
            }

            SetPublisherProperties(message, source.PendingPublishSequenceNumber, source.PendingProducerGroupId, source.PendingProducerOwnerLevel);
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
            var message = AmqpAnnotatedMessageConverter.FromAmqpMessage(source);

            // Message Annotations - special handling for Event Hub service annotations

            if ((source.Sections & SectionFlag.MessageAnnotations) > 0)
            {
                NormalizeBrokerProperties(message.MessageAnnotations, source.MessageAnnotations.Map);
            }

            // Delivery Annotations - special handling for Event Hub service annotations

            if ((source.Sections & SectionFlag.DeliveryAnnotations) > 0)
            {
                NormalizeBrokerProperties(message.DeliveryAnnotations, source.DeliveryAnnotations.Map);
            }

            return new EventData(message);
        }

        private static void NormalizeBrokerProperties(IDictionary<string, object> properties, Annotations sourceProperties)
        {
            foreach (var pair in sourceProperties)
            {
                string keyString = pair.Key.ToString();
                if (SystemPropertyDateTimeKeys.Contains(keyString))
                {
                    properties[keyString] =
                        pair.Value switch
                        {
                            DateTime dateValue => new DateTimeOffset(dateValue, TimeSpan.Zero),
                            long longValue => new DateTimeOffset(longValue, TimeSpan.Zero),
                            _ => pair.Value
                        };
                }
                else if (SystemPropertyLongKeys.Contains(keyString))
                {
                    properties[keyString] =
                        pair.Value switch
                        {
                            string stringValue when long.TryParse(stringValue, NumberStyles.Integer, CultureInfo.InvariantCulture,
                                    out var longValue) =>
                                longValue,
                            _ => pair.Value
                        };
                }
            }
        }

        /// <summary>
        ///   Conditionally applies the set of properties associated with message
        ///   publishing, if values were provided.
        /// </summary>
        ///
        /// <param name="message">The message to conditionally set properties on; this message will be mutated.</param>
        /// <param name="sequenceNumber">The sequence number to consider and apply.</param>
        /// <param name="groupId">The group identifier to consider and apply.</param>
        /// <param name="ownerLevel">The owner level to consider and apply.</param>
        ///
        private static void SetPublisherProperties(AmqpMessage message,
                                                   int? sequenceNumber,
                                                   long? groupId,
                                                   short? ownerLevel)
        {
            if (sequenceNumber.HasValue)
            {
                message.MessageAnnotations.Map[AmqpProperty.ProducerSequenceNumber] = sequenceNumber;
            }

            if (groupId.HasValue)
            {
                message.MessageAnnotations.Map[AmqpProperty.ProducerGroupId] = groupId;
            }

            if (ownerLevel.HasValue)
            {
                message.MessageAnnotations.Map[AmqpProperty.ProducerOwnerLevel] = ownerLevel;
            }
        }

        /// <summary>
        ///   Translates the data body segments into the corresponding set of
        ///   <see cref="Data" /> instances.
        /// </summary>
        ///
        /// <param name="dataBody">The data body to translate.</param>
        ///
        /// <returns>The set of <see cref="Data" /> instances that represents the <paramref name="dataBody" />.</returns>
        ///
        private static IEnumerable<Data> TranslateDataBody(IEnumerable<ReadOnlyMemory<byte>> dataBody)
        {
            foreach (var bodySegment in dataBody)
            {
                if (!MemoryMarshal.TryGetArray(bodySegment, out ArraySegment<byte> dataSegment))
                {
                    dataSegment = new ArraySegment<byte>(bodySegment.ToArray());
                }

                yield return new Data
                {
                    Value = dataSegment
                };
            }
        }

        /// <summary>
        ///   Translates the data body elements into the corresponding set of
        ///   <see cref="AmqpSequence" /> instances.
        /// </summary>
        ///
        /// <param name="sequenceBody">The sequence body to translate.</param>
        ///
        /// <returns>The set of <see cref="AmqpSequence" /> instances that represents the <paramref name="sequenceBody" /> in AMQP format.</returns>
        ///
        private static IEnumerable<AmqpSequence> TranslateSequenceBody(IEnumerable<IList<object>> sequenceBody)
        {
            foreach (var item in sequenceBody)
            {
                yield return new AmqpSequence((System.Collections.IList)item);
            }
        }

        /// <summary>
        ///   Translates the data body into the corresponding set of
        ///   <see cref="AmqpValue" /> instance.
        /// </summary>
        ///
        /// <param name="valueBody">The sequence body to translate.</param>
        ///
        /// <returns>The <see cref="AmqpValue" /> instance that represents the <paramref name="valueBody" /> in AMQP format.</returns>
        ///
        private static AmqpValue TranslateValueBody(object valueBody)
        {
            if (TryCreateAmqpPropertyValueForEventProperty(valueBody, out var amqpValue, allowBodyTypes: true))
            {
                return new AmqpValue { Value = amqpValue };
            }

            throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidAmqpMessageValueBodyMask, valueBody.GetType().Name));
        }

        /// <summary>
        ///   Attempts to read the data body of an <see cref="AmqpMessage" />.
        /// </summary>
        ///
        /// <param name="source">The <see cref="AmqpMessage" /> to read from.</param>
        /// <param name="dataBody">The value of the data body, if read.</param>
        ///
        /// <returns><c>true</c> if the body was successfully read; otherwise, <c>false</c>.</returns>
        ///
        private static bool TryGetDataBody(AmqpMessage source, out AmqpMessageBody dataBody)
        {
            if (((source.BodyType & SectionFlag.Data) == 0) || (source.DataBody == null))
            {
                dataBody = null;
                return false;
            }

            dataBody = AmqpMessageBody.FromData(MessageBody.FromDataSegments(source.DataBody));
            return true;
        }

        /// <summary>
        ///   Attempts to read the sequence body of an <see cref="AmqpMessage" />.
        /// </summary>
        ///
        /// <param name="source">The <see cref="AmqpMessage" /> to read from.</param>
        /// <param name="sequenceBody">The value of the sequence body, if read.</param>
        ///
        /// <returns><c>true</c> if the body was successfully read; otherwise, <c>false</c>.</returns>
        ///
        private static bool TryGetSequenceBody(AmqpMessage source, out AmqpMessageBody sequenceBody)
        {
            if ((source.BodyType & SectionFlag.AmqpSequence) == 0)
            {
                sequenceBody = null;
                return false;
            }

            var bodyContent = new List<IList<object>>();

            foreach (var item in source.SequenceBody)
            {
                bodyContent.Add((IList<object>)item.List);
            }

            sequenceBody = AmqpMessageBody.FromSequence(bodyContent);
            return true;
        }

        /// <summary>
        ///   Attempts to read the sequence body of an <see cref="AmqpMessage" />.
        /// </summary>
        ///
        /// <param name="source">The <see cref="AmqpMessage" /> to read from.</param>
        /// <param name="valueBody">The value body, if read.</param>
        ///
        /// <returns><c>true</c> if the body was successfully read; otherwise, <c>false</c>.</returns>
        ///
        private static bool TryGetValueBody(AmqpMessage source, out AmqpMessageBody valueBody)
        {
            if (((source.BodyType & SectionFlag.AmqpValue) == 0) || (source.ValueBody?.Value == null))
            {
                valueBody = null;
                return false;
            }

            if (TryCreateEventPropertyForAmqpProperty(source.ValueBody.Value, out var translatedValue, allowBodyTypes: true))
            {
                valueBody = AmqpMessageBody.FromValue(translatedValue);
                return true;
            }

            throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidAmqpMessageValueBodyMask, source.ValueBody.Value.GetType().Name));
        }

        /// <summary>
        ///   Attempts to create an AMQP property value for a given event property.
        /// </summary>
        ///
        /// <param name="eventPropertyValue">The value of the event property to create an AMQP property value for.</param>
        /// <param name="amqpPropertyValue">The AMQP property value that was created.</param>
        /// <param name="allowBodyTypes"><c>true</c> to allow an AMQP map to be translated to additional types supported only by a message body; otherwise, <c>false</c>.</param>
        ///
        /// <returns><c>true</c> if an AMQP property value was able to be created; otherwise, <c>false</c>.</returns>
        ///
        private static bool TryCreateAmqpPropertyValueForEventProperty(object eventPropertyValue,
                                                                       out object amqpPropertyValue,
                                                                       bool allowBodyTypes = false)
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

                case AmqpProperty.Type.Unknown when allowBodyTypes && eventPropertyValue is byte[] byteArray:
                    amqpPropertyValue = new ArraySegment<byte>(byteArray);
                    break;

                case AmqpProperty.Type.Unknown when allowBodyTypes && eventPropertyValue is System.Collections.IDictionary dict:
                    amqpPropertyValue = new AmqpMap(dict);
                    break;

                case AmqpProperty.Type.Unknown when allowBodyTypes && eventPropertyValue is System.Collections.IList:
                    amqpPropertyValue = eventPropertyValue;
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
        /// <param name="allowBodyTypes"><c>true</c> to allow an AMQP map to be translated to additional types supported only by a message body; otherwise, <c>false</c>.</param>
        ///
        /// <returns><c>true</c> if an event property value was able to be created; otherwise, <c>false</c>.</returns>
        ///
        private static bool TryCreateEventPropertyForAmqpProperty(object amqpPropertyValue,
                                                                  out object eventPropertyValue,
                                                                  bool allowBodyTypes = false)
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

                case AmqpMap map when allowBodyTypes:
                {
                    var dict = new Dictionary<string, object>(map.Count);

                    foreach (var pair in map)
                    {
                        dict.Add(pair.Key.ToString(), pair.Value);
                    }

                    eventPropertyValue = dict;
                    break;
                }

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
            switch (stream)
            {
                case { Length: < 1 }:
                    return default;

                case BufferListStream bufferListStream:
                    return bufferListStream.ReadBytes((int)stream.Length);

                case MemoryStream memStreamSource:
                {
                    using var memStreamCopy = new MemoryStream((int)(memStreamSource.Length - memStreamSource.Position));
                    memStreamSource.CopyTo(memStreamCopy, StreamBufferSizeInBytes);
                    if (!memStreamCopy.TryGetBuffer(out ArraySegment<byte> segment))
                    {
                        segment = new ArraySegment<byte>(memStreamCopy.ToArray());
                    }
                    return segment;
                }

                default:
                {
                    using var memStreamCopy = new MemoryStream(StreamBufferSizeInBytes);
                    stream.CopyTo(memStreamCopy, StreamBufferSizeInBytes);
                    if (!memStreamCopy.TryGetBuffer(out ArraySegment<byte> segment))
                    {
                        segment = new ArraySegment<byte>(memStreamCopy.ToArray());
                    }
                    return segment;
                }
            }
        }
    }
}
