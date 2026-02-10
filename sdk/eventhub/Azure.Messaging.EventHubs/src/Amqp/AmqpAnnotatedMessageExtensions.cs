// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using Azure.Core.Amqp;

namespace Azure.Messaging.EventHubs.Amqp
{
    /// <summary>
    ///   The set of extension methods for the <see cref="AmqpAnnotatedMessage" /> class.
    /// </summary>
    ///
    internal static class AmqpAnnotatedMessageExtensions
    {
        /// <summary>
        ///   Populates the <paramref name="instance"/> from a set of well-known <see cref="EventData"/>
        ///   attributes, setting only those values which are populated.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="properties">The set of free-form application properties to send with the event.</param>
        /// <param name="sequenceNumber">The sequence number assigned to the event when it was enqueued in the associated Event Hub partition.</param>
        /// <param name="offset">The offset of the event when it was received from the associated Event Hub partition.</param>
        /// <param name="enqueuedTime">The date and time, in UTC, of when the event was enqueued in the Event Hub partition.</param>
        /// <param name="partitionKey">The partition hashing key applied to the batch that the associated <see cref="EventData"/>, was sent with.</param>
        /// <param name="lastPartitionSequenceNumber">The sequence number that was last enqueued into the Event Hub partition.</param>
        /// <param name="lastPartitionOffset">The offset that was last enqueued into the Event Hub partition.</param>
        /// <param name="lastPartitionEnqueuedTime">The date and time, in UTC, of the event that was last enqueued into the Event Hub partition.</param>
        /// <param name="lastPartitionPropertiesRetrievalTime">The date and time, in UTC, that the last event information for the Event Hub partition was retrieved from the service.</param>
        ///
        public static void PopulateFromEventProperties(this AmqpAnnotatedMessage instance,
                                                       IDictionary<string, object> properties = null,
                                                       long? sequenceNumber = null,
                                                       string offset = null,
                                                       DateTimeOffset? enqueuedTime = null,
                                                       string partitionKey = null,
                                                       long? lastPartitionSequenceNumber = null,
                                                       string lastPartitionOffset = null,
                                                       DateTimeOffset? lastPartitionEnqueuedTime = null,
                                                       DateTimeOffset? lastPartitionPropertiesRetrievalTime = null)
        {
           if (properties != null)
           {
               CopyDictionary(properties, instance.ApplicationProperties);
           }

           if (sequenceNumber.HasValue)
           {
               instance.MessageAnnotations[AmqpProperty.SequenceNumber.ToString()] = sequenceNumber.Value;
           }

           if (!string.IsNullOrEmpty(offset))
           {
               instance.MessageAnnotations[AmqpProperty.Offset.ToString()] = offset;
           }

           if (enqueuedTime.HasValue)
           {
               instance.MessageAnnotations[AmqpProperty.EnqueuedTime.ToString()] = enqueuedTime.Value;
           }

           if (!string.IsNullOrEmpty(partitionKey))
           {
               instance.MessageAnnotations[AmqpProperty.PartitionKey.ToString()] = partitionKey;
           }

           if (lastPartitionSequenceNumber.HasValue)
           {
               instance.DeliveryAnnotations[AmqpProperty.PartitionLastEnqueuedSequenceNumber.ToString()] = lastPartitionSequenceNumber.Value;
           }

           if (!string.IsNullOrEmpty(lastPartitionOffset))
           {
               instance.DeliveryAnnotations[AmqpProperty.PartitionLastEnqueuedOffset.ToString()] = lastPartitionOffset;
           }

           if (lastPartitionEnqueuedTime.HasValue)
           {
               instance.DeliveryAnnotations[AmqpProperty.PartitionLastEnqueuedTimeUtc.ToString()] = lastPartitionEnqueuedTime.Value;
           }

           if (lastPartitionPropertiesRetrievalTime.HasValue)
           {
               instance.DeliveryAnnotations[AmqpProperty.LastPartitionPropertiesRetrievalTimeUtc.ToString()] = lastPartitionPropertiesRetrievalTime.Value;
           }
        }

        /// <summary>
        ///   Creates a new copy of the <paramref name="instance"/>, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        ///
        /// <returns>A copy of <see cref="AmqpAnnotatedMessage" /> containing the same data.</returns>
        ///
        public static AmqpAnnotatedMessage Clone(this AmqpAnnotatedMessage instance)
        {
           if (instance == null)
           {
               return null;
           }

           var clone = new AmqpAnnotatedMessage(CloneBody(instance.Body));

           if (instance.HasSection(AmqpMessageSection.Header))
           {
               CopyHeaderSection(instance.Header, clone.Header);
           }

           if (instance.HasSection(AmqpMessageSection.Properties))
           {
               CopyPropertiesSection(instance.Properties, clone.Properties);
           }

           if (instance.HasSection(AmqpMessageSection.Footer))
           {
               CopyDictionary(instance.Footer, clone.Footer);
           }

           if (instance.HasSection(AmqpMessageSection.DeliveryAnnotations))
           {
               CopyDictionary(instance.DeliveryAnnotations, clone.DeliveryAnnotations);
           }

           if (instance.HasSection(AmqpMessageSection.MessageAnnotations))
           {
               CopyDictionary(instance.MessageAnnotations, clone.MessageAnnotations);
           }

           if (instance.HasSection(AmqpMessageSection.ApplicationProperties))
           {
               CopyDictionary(instance.ApplicationProperties, clone.ApplicationProperties);
           }

           return clone;
        }

        /// <summary>
        ///   Retrieves the body of an <see cref="AmqpAnnotatedMessage" /> in the form
        ///   needed  by the <see cref="EventData.EventBody" /> accessor.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        ///
        /// <returns>The body of the <paramref name="instance"/>, in the appropriate form for use by an <see cref="EventData" /> instance.</returns>
        ///
        /// <exception cref="NotSupportedException">The body of the <paramref name="instance" /> cannot be used directly by <see cref="EventData" />.</exception>
        ///
        public static BinaryData GetEventBody(this AmqpAnnotatedMessage instance)
        {
            if (instance.Body.TryGetData(out IEnumerable<ReadOnlyMemory<byte>> dataBody))
            {
                return BinaryData.FromBytes(MessageBody.FromReadOnlyMemorySegments(dataBody));
            }

            throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, Resources.RawAmqpBodyTypeMask, nameof(EventData), nameof(EventData.EventBody), instance.Body.BodyType, nameof(EventData.GetRawAmqpMessage)));
        }

        /// <summary>
        ///   Retrieves the sequence number of an event from an <see cref="AmqpAnnotatedMessage" />.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="defaultValue">The value to return if the sequence number is not represented in the <paramref name="instance"/>.</param>
        ///
        /// <returns>The sequence number, if represented in the <paramref name="instance"/>; otherwise, <paramref name="defaultValue"/>.</returns>
        ///
        public static long GetSequenceNumber(this AmqpAnnotatedMessage instance,
                                             long defaultValue = long.MinValue)
        {
            if ((instance.HasSection(AmqpMessageSection.MessageAnnotations))
                && (instance.MessageAnnotations.TryGetValue(AmqpProperty.SequenceNumber.ToString(), out var value)))
            {
                return value switch
                {
                    string stringValue when long.TryParse(stringValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out var longValue) => longValue,
                    long longValue => longValue,
                    int intValue => intValue,
                    _ => (long)value
                };
            }

            return defaultValue;
        }

        /// <summary>
        ///   Retrieves the offset of an event from an <see cref="AmqpAnnotatedMessage" />.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="defaultValue">The value to return if the offset is not represented in the <paramref name="instance"/>.</param>
        ///
        /// <returns>The offset, if represented in the <paramref name="instance"/>; otherwise, <paramref name="defaultValue"/>.</returns>
        ///
        public static string GetOffset(this AmqpAnnotatedMessage instance,
                                       string defaultValue = default)
        {
            if ((instance.HasSection(AmqpMessageSection.MessageAnnotations))
                && (instance.MessageAnnotations.TryGetValue(AmqpProperty.Offset.ToString(), out var value)))
            {
                return (string)value;
            }

            return defaultValue;
        }

        /// <summary>
        ///   Retrieves the time that an event was enqueued in the partition from an <see cref="AmqpAnnotatedMessage" />.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="defaultValue">The value to return if the enqueue time is not represented in the <paramref name="instance"/>.</param>
        ///
        /// <returns>The enqueued time, if represented in the <paramref name="instance"/>; otherwise, <paramref name="defaultValue"/>.</returns>
        ///
        public static DateTimeOffset GetEnqueuedTime(this AmqpAnnotatedMessage instance,
                                                     DateTimeOffset defaultValue = default)
        {
            if ((instance.HasSection(AmqpMessageSection.MessageAnnotations))
                && (instance.MessageAnnotations.TryGetValue(AmqpProperty.EnqueuedTime.ToString(), out var value)))
            {
                return value switch
                {
                    DateTime dateValue => new DateTimeOffset(dateValue, TimeSpan.Zero),
                    long longValue => new DateTimeOffset(longValue, TimeSpan.Zero),
                    DateTimeOffset dateTimeOffsetValue => dateTimeOffsetValue,
                    _ => (DateTimeOffset)value
                };
            }

            return defaultValue;
        }

        /// <summary>
        ///   Sets the time that an event was enqueued in the partition on an <see cref="AmqpAnnotatedMessage" />.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="enqueueTime">The value to set as the enqueue time.</param>
        ///
        public static void SetEnqueuedTime(this AmqpAnnotatedMessage instance,
                                           DateTimeOffset enqueueTime)
        {
            instance.MessageAnnotations[AmqpProperty.EnqueuedTime.ToString()] = enqueueTime.UtcDateTime;
        }

        /// <summary>
        ///   Retrieves the partition key of an event from an <see cref="AmqpAnnotatedMessage" />.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="defaultValue">The value to return if the partition key is not represented in the <paramref name="instance"/>.</param>
        ///
        /// <returns>The partition key, if represented in the <paramref name="instance"/>; otherwise, <paramref name="defaultValue"/>.</returns>
        ///
        public static string GetPartitionKey(this AmqpAnnotatedMessage instance,
                                             string defaultValue = default)
        {
            if ((instance.HasSection(AmqpMessageSection.MessageAnnotations))
                && (instance.MessageAnnotations.TryGetValue(AmqpProperty.PartitionKey.ToString(), out var value)))
            {
                return (string)value;
            }

            return defaultValue;
        }

        /// <summary>
        ///   Sets the partition key of an event on an <see cref="AmqpAnnotatedMessage" />.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="partitionKey">The value to set for the partition key.</param>
        ///
        public static void SetPartitionKey(this AmqpAnnotatedMessage instance,
                                           string partitionKey)
        {
            instance.MessageAnnotations[AmqpProperty.PartitionKey.ToString()] = partitionKey;
        }

        /// <summary>
        ///   Retrieves the sequence number of the last event published to the partition from an <see cref="AmqpAnnotatedMessage" />.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="defaultValue">The value to return if the last sequence number is not represented in the <paramref name="instance"/>.</param>
        ///
        /// <returns>The sequence number of the last event published to the partition, if represented in the <paramref name="instance"/>; otherwise, <paramref name="defaultValue"/>.</returns>
        ///
        public static long? GetLastPartitionSequenceNumber(this AmqpAnnotatedMessage instance,
                                                           long? defaultValue = default)
        {
            if ((instance.HasSection(AmqpMessageSection.DeliveryAnnotations))
                && (instance.DeliveryAnnotations.TryGetValue(AmqpProperty.PartitionLastEnqueuedSequenceNumber.ToString(), out var value)))
            {
                return value switch
                {
                    string stringValue when long.TryParse(stringValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out var longValue) => longValue,
                    long longValue => longValue,
                    _ => (long)value
                };
            }

            return defaultValue;
        }

        /// <summary>
        ///   Retrieves the offset of the last event published to the partition from an <see cref="AmqpAnnotatedMessage" />.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="defaultValue">The value to return if the last offset is not represented in the <paramref name="instance"/>.</param>
        ///
        /// <returns>The offset of the last event published to the partition, if represented in the <paramref name="instance"/>; otherwise, <paramref name="defaultValue"/>.</returns>
        ///
        public static string GetLastPartitionOffset(this AmqpAnnotatedMessage instance,
                                                    string defaultValue = default)
        {
            if ((instance.HasSection(AmqpMessageSection.DeliveryAnnotations))
                && (instance.DeliveryAnnotations.TryGetValue(AmqpProperty.PartitionLastEnqueuedOffset.ToString(), out var value)))
            {
                return (string)value;
            }

            return defaultValue;
        }

        /// <summary>
        ///   Retrieves the time that the last event was enqueued in the partition from an <see cref="AmqpAnnotatedMessage" />.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="defaultValue">The value to return if the last enqueue time is not represented in the <paramref name="instance"/>.</param>
        ///
        /// <returns>The time that the last event was enqueued in the partition, if represented in the <paramref name="instance"/>; otherwise, <paramref name="defaultValue"/>.</returns>
        ///
        public static DateTimeOffset? GetLastPartitionEnqueuedTime(this AmqpAnnotatedMessage instance,
                                                                   DateTimeOffset? defaultValue = default)
        {
            if ((instance.HasSection(AmqpMessageSection.DeliveryAnnotations))
                && (instance.DeliveryAnnotations.TryGetValue(AmqpProperty.PartitionLastEnqueuedTimeUtc.ToString(), out var value)))
            {
                return value switch
                {
                    DateTime dateValue => new DateTimeOffset(dateValue, TimeSpan.Zero),
                    long longValue => new DateTimeOffset(longValue, TimeSpan.Zero),
                    DateTimeOffset dateTimeOffsetValue => dateTimeOffsetValue,
                    _ => (DateTimeOffset)value
                };
            }

            return defaultValue;
        }

        /// <summary>
        ///   Retrieves the time that the information about the last event enqueued in the partition was reported from an <see cref="AmqpAnnotatedMessage" />.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="defaultValue">The value to return if the last retrieval time is not represented in the <paramref name="instance"/>.</param>
        ///
        /// <returns>The time that the information about the last event enqueued in the partition was reported, if represented in the <paramref name="instance"/>; otherwise, <paramref name="defaultValue"/>.</returns>
        ///
        public static DateTimeOffset? GetLastPartitionPropertiesRetrievalTime(this AmqpAnnotatedMessage instance,
                                                                              DateTimeOffset? defaultValue = default)
        {
            if ((instance.HasSection(AmqpMessageSection.DeliveryAnnotations))
                && (instance.DeliveryAnnotations.TryGetValue(AmqpProperty.LastPartitionPropertiesRetrievalTimeUtc.ToString(), out var value)))
            {
                return value switch
                {
                    DateTime dateValue => new DateTimeOffset(dateValue, TimeSpan.Zero),
                    long longValue => new DateTimeOffset(longValue, TimeSpan.Zero),
                    DateTimeOffset dateTimeOffsetValue => dateTimeOffsetValue,
                    _ => (DateTimeOffset)value
                };
            }

            return defaultValue;
        }

        /// <summary>
        ///   Retrieves the value for a specific message annotation of an <see cref="AmqpAnnotatedMessage" />
        ///   in normalized form.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="key">The key of the message annotation value to retrieve.</param>
        ///
        /// <returns>The normalized value for the specified <paramref name="key"/>, if present in the <paramref name="instance"/>; otherwise, the default value for the key.</returns>
        ///
        public static object GetMessageAnnotationNormalizedValue(this AmqpAnnotatedMessage instance,
                                                                 string key)
        {
            if (!instance.HasSection(AmqpMessageSection.MessageAnnotations))
            {
                return null;
            }

            return key switch
            {
                _ when key == AmqpProperty.EnqueuedTime.ToString() => GetEnqueuedTime(instance, default),
                _ when key == AmqpProperty.SequenceNumber.ToString() => GetSequenceNumber(instance, default),
                _ when instance.MessageAnnotations.TryGetValue(key, out var value) => value switch
                {
                    AmqpMessageId id => id.ToString(),
                    AmqpAddress address => address.ToString(),
                    _ => value
                },
                _ => null
            };
        }

        /// <summary>
        ///   Clones the body of an <see cref="AmqpAnnotatedMessage" />.
        /// </summary>
        ///
        /// <param name="amqpBody">The <see cref="AmqpMessageBody" /> instance to clone.</param>
        ///
        /// <returns>A shallow clone of the <paramref name="amqpBody" />.</returns>
        ///
        private static AmqpMessageBody CloneBody(AmqpMessageBody amqpBody) =>
            amqpBody switch
            {
                null => null,
                _ when (amqpBody.TryGetData(out var data)) => AmqpMessageBody.FromData(data),
                _ when (amqpBody.TryGetValue(out var value)) => AmqpMessageBody.FromValue(value),
                _ when (amqpBody.TryGetSequence(out var sequence)) => AmqpMessageBody.FromSequence(sequence),
                _ => throw new ArgumentException(Resources.UnknownAmqpBodyType, nameof(amqpBody))
            };

        /// <summary>
        ///   Copies data from one <see cref="AmqpMessageHeader" /> instance to another.
        /// </summary>
        ///
        /// <param name="source">The source instance to copy from.</param>
        /// <param name="destination">The destination instance to write to.</param>
        ///
        private static void CopyHeaderSection(AmqpMessageHeader source,
                                              AmqpMessageHeader destination)
        {
            destination.DeliveryCount = source.DeliveryCount;
            destination.Durable = source.Durable;
            destination.FirstAcquirer = source.FirstAcquirer;
            destination.Priority = source.Priority;
            destination.TimeToLive = source.TimeToLive;
        }

        /// <summary>
        ///   Copies data from one <see cref="AmqpMessageProperties" /> instance to another.
        /// </summary>
        ///
        /// <param name="source">The source instance to copy from.</param>
        /// <param name="destination">The destination instance to write to.</param>
        ///
        private static void CopyPropertiesSection(AmqpMessageProperties source,
                                                  AmqpMessageProperties destination)
        {
            destination.AbsoluteExpiryTime = source.AbsoluteExpiryTime;
            destination.ContentEncoding = source.ContentEncoding;
            destination.ContentType = source.ContentType;
            destination.CorrelationId = source.CorrelationId;
            destination.CreationTime = source.CreationTime;
            destination.GroupId = source.GroupId;
            destination.GroupSequence = source.GroupSequence;
            destination.MessageId = source.MessageId;
            destination.ReplyTo = source.ReplyTo;
            destination.ReplyToGroupId = source.ReplyToGroupId;
            destination.Subject = source.Subject;
            destination.To = source.To;
            destination.UserId = source.UserId;
        }

        /// <summary>
        ///   Copies data from one dictionary instance to another.
        /// </summary>
        ///
        /// <typeparam name="TKey">The type of the key used in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the value used in the dictionary.</typeparam>
        ///
        /// <param name="source">The source instance to copy from.</param>
        /// <param name="destination">The destination instance to write to.</param>
        ///
        private static void CopyDictionary<TKey, TValue>(IDictionary<TKey, TValue> source,
                                                         IDictionary<TKey, TValue> destination)
        {
            if (source.Count > 0)
            {
                foreach (var pair in source)
                {
                    destination[pair.Key] = pair.Value;
                }
            }
        }
    }
}
