// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Azure.Core;
using Azure.Core.Amqp.Shared;
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
            return new EventData(AmqpAnnotatedMessageConverter.FromAmqpMessage(source));
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

            var geoReplicationEnabled = responseData[AmqpManagement.ResponseMap.GeoReplicationFactor] switch
            {
                int count when count > 1 => true,
                _ => false
            };

            return new EventHubProperties(
                (string)responseData[AmqpManagement.ResponseMap.Name],
                new DateTimeOffset((DateTime)responseData[AmqpManagement.ResponseMap.CreatedAt], TimeSpan.Zero),
                (string[])responseData[AmqpManagement.ResponseMap.PartitionIdentifiers],
                geoReplicationEnabled);
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
                (string)responseData[AmqpManagement.ResponseMap.PartitionLastEnqueuedOffset],
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
