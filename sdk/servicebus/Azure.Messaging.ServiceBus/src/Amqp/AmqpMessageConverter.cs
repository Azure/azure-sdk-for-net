// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Azure.Core;
using Azure.Core.Amqp;
using Azure.Messaging.ServiceBus.Primitives;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp
{
    internal class AmqpMessageConverter
    {
        /// <summary>The size, in bytes, to use as a buffer for stream operations.</summary>
        private const int StreamBufferSizeInBytes = 512;

        public static AmqpMessageConverter Default = new AmqpMessageConverter();

        public virtual AmqpMessage BatchSBMessagesAsAmqpMessage(ServiceBusMessage source, bool forceBatch = false)
        {
            Argument.AssertNotNull(source, nameof(source));
            var batchMessages = new List<AmqpMessage>(1) { SBMessageToAmqpMessage(source) };
            return BuildAmqpBatchFromMessages(batchMessages, forceBatch);
        }

        public virtual AmqpMessage BatchSBMessagesAsAmqpMessage(IReadOnlyCollection<ServiceBusMessage> source, bool forceBatch = false)
        {
            Argument.AssertNotNull(source, nameof(source));
            return BuildAmqpBatchFromMessage(source, forceBatch);
        }

        /// <summary>
        ///   Builds a batch of <see cref="AmqpMessage" /> from a set of <see cref="ServiceBusMessage" />
        ///   optionally propagating the custom properties.
        /// </summary>
        ///
        /// <param name="source">The set of messages to use as the body of the batch message.</param>
        /// <param name="forceBatch">Set to true to force creating as a batch even when only one message.</param>
        ///
        /// <returns>The batch <see cref="AmqpMessage" /> containing the source messages.</returns>
        ///
        private AmqpMessage BuildAmqpBatchFromMessage(IReadOnlyCollection<ServiceBusMessage> source, bool forceBatch)
        {
            var batchMessages = new List<AmqpMessage>(source.Count);
            foreach (ServiceBusMessage sbMessage in source)
            {
                 batchMessages.Add(SBMessageToAmqpMessage(sbMessage));
            }
            return BuildAmqpBatchFromMessages(batchMessages, forceBatch);
        }

        /// <summary>
        ///   Builds a batch <see cref="AmqpMessage" /> from a set of <see cref="AmqpMessage" />.
        /// </summary>
        ///
        /// <param name="source">The set of messages to use as the body of the batch message.</param>
        /// <param name="forceBatch">Set to true to force creating as a batch even when only one message.</param>
        ///
        /// <returns>The batch <see cref="AmqpMessage" /> containing the source messages.</returns>
        ///
        public virtual AmqpMessage BuildAmqpBatchFromMessages(
            IReadOnlyCollection<AmqpMessage> source,
            bool forceBatch)
        {
            AmqpMessage batchEnvelope;
            AmqpMessage firstMessage = null;

            var batchMessages = source.GetEnumerator();
            batchMessages.MoveNext();

            if (source.Count > 0)
            {
                firstMessage = batchMessages.Current;
            }

            if (source.Count == 1 && !forceBatch)
            {
                batchEnvelope = batchMessages.Current.Clone();
            }
            else
            {
                var data = new List<Data>(source.Count);

                foreach (var message in source)
                {
                    message.Batchable = true;
                    using var messageStream = message.ToStream();
                    data.Add(new Data { Value = ReadStreamToArraySegment(messageStream) });
                }
                batchEnvelope = AmqpMessage.Create(data);
                batchEnvelope.MessageFormat = AmqpConstants.AmqpBatchedMessageFormat;
            }

            if (firstMessage?.Properties.MessageId != null)
            {
                batchEnvelope.Properties.MessageId = firstMessage.Properties.MessageId;
            }
            if (firstMessage?.Properties.GroupId != null)
            {
                batchEnvelope.Properties.GroupId = firstMessage.Properties.GroupId;
            }

            if (firstMessage?.MessageAnnotations.Map[AmqpMessageConstants.PartitionKeyName] != null)
            {
                batchEnvelope.MessageAnnotations.Map[AmqpMessageConstants.PartitionKeyName] =
                    firstMessage.MessageAnnotations.Map[AmqpMessageConstants.PartitionKeyName];
            }

            if (firstMessage?.MessageAnnotations.Map[AmqpMessageConstants.ViaPartitionKeyName] != null)
            {
                batchEnvelope.MessageAnnotations.Map[AmqpMessageConstants.ViaPartitionKeyName] =
                    firstMessage.MessageAnnotations.Map[AmqpMessageConstants.ViaPartitionKeyName];
            }

            batchEnvelope.Batchable = true;
            return batchEnvelope;
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

        public virtual AmqpMessage SBMessageToAmqpMessage(ServiceBusMessage sbMessage) => AmqpAnnotatedMessageToAmqpMessage(sbMessage.AmqpMessage);

        public virtual AmqpMessage AmqpAnnotatedMessageToAmqpMessage(AmqpAnnotatedMessage annotatedMessage)
        {
            Argument.AssertNotNull(annotatedMessage, nameof(annotatedMessage));

            // body
            AmqpMessage amqpMessage = annotatedMessage.ToAmqpMessage();

            // properties
            amqpMessage.Properties.MessageId = annotatedMessage.Properties.MessageId?.ToString();
            amqpMessage.Properties.CorrelationId = annotatedMessage.Properties.CorrelationId?.ToString();
            amqpMessage.Properties.ContentType = annotatedMessage.Properties.ContentType;
            amqpMessage.Properties.ContentEncoding = annotatedMessage.Properties.ContentEncoding;
            amqpMessage.Properties.Subject = annotatedMessage.Properties.Subject;
            amqpMessage.Properties.To = annotatedMessage.Properties.To?.ToString();
            amqpMessage.Properties.ReplyTo = annotatedMessage.Properties.ReplyTo?.ToString();
            amqpMessage.Properties.GroupId = annotatedMessage.Properties.GroupId;
            amqpMessage.Properties.ReplyToGroupId = annotatedMessage.Properties.ReplyToGroupId;
            amqpMessage.Properties.GroupSequence = annotatedMessage.Properties.GroupSequence;

            if (annotatedMessage.Properties.UserId.HasValue)
            {
                ReadOnlyMemory<byte> userId = annotatedMessage.Properties.UserId.Value;
                if (MemoryMarshal.TryGetArray(userId, out ArraySegment<byte> segment))
                {
                    amqpMessage.Properties.UserId = segment;
                }
                else
                {
                    amqpMessage.Properties.UserId = new ArraySegment<byte>(userId.ToArray());
                }
            }

            // If TTL is set, it is used to calculate AbsoluteExpiryTime and CreationTime
            TimeSpan ttl = annotatedMessage.GetTimeToLive();
            if (ttl != TimeSpan.MaxValue)
            {
                amqpMessage.Header.Ttl = (uint)ttl.TotalMilliseconds;
                amqpMessage.Properties.CreationTime = DateTime.UtcNow;

                if (AmqpConstants.MaxAbsoluteExpiryTime - amqpMessage.Properties.CreationTime.Value > ttl)
                {
                    amqpMessage.Properties.AbsoluteExpiryTime = amqpMessage.Properties.CreationTime.Value + ttl;
                }
                else
                {
                    amqpMessage.Properties.AbsoluteExpiryTime = AmqpConstants.MaxAbsoluteExpiryTime;
                }
            }
            else
            {
                if (annotatedMessage.Properties.CreationTime.HasValue)
                {
                    amqpMessage.Properties.CreationTime = annotatedMessage.Properties.CreationTime.Value.UtcDateTime;
                }
                if (annotatedMessage.Properties.AbsoluteExpiryTime.HasValue)
                {
                    amqpMessage.Properties.AbsoluteExpiryTime = annotatedMessage.Properties.AbsoluteExpiryTime.Value.UtcDateTime;
                }
            }

            // message annotations

            foreach (KeyValuePair<string, object> kvp in annotatedMessage.MessageAnnotations)
            {
                switch (kvp.Key)
                {
                    case AmqpMessageConstants.ScheduledEnqueueTimeUtcName:
                        DateTimeOffset scheduledEnqueueTime = annotatedMessage.GetScheduledEnqueueTime();
                        if (scheduledEnqueueTime != default)
                        {
                            amqpMessage.MessageAnnotations.Map.Add(AmqpMessageConstants.ScheduledEnqueueTimeUtcName, scheduledEnqueueTime.UtcDateTime);
                        }
                        break;
                    case AmqpMessageConstants.PartitionKeyName:
                        string partitionKey = annotatedMessage.GetPartitionKey();
                        if (partitionKey != null)
                        {
                            amqpMessage.MessageAnnotations.Map.Add(AmqpMessageConstants.PartitionKeyName, partitionKey);
                        }
                        break;
                    case AmqpMessageConstants.ViaPartitionKeyName:
                        string viaPartitionKey = annotatedMessage.GetViaPartitionKey();
                        if (viaPartitionKey != null)
                        {
                            amqpMessage.MessageAnnotations.Map.Add(AmqpMessageConstants.ViaPartitionKeyName, viaPartitionKey);
                        }
                        break;
                    default:
                        amqpMessage.MessageAnnotations.Map.Add(kvp.Key, kvp.Value);
                        break;
                }
            }

            // application properties

            if (annotatedMessage.ApplicationProperties.Count > 0)
            {
                if (amqpMessage.ApplicationProperties == null)
                {
                    amqpMessage.ApplicationProperties = new ApplicationProperties();
                }

                foreach (KeyValuePair<string, object> pair in annotatedMessage.ApplicationProperties)
                {
                    if (TryGetAmqpObjectFromNetObject(pair.Value, MappingType.ApplicationProperty, out var amqpObject))
                    {
                        amqpMessage.ApplicationProperties.Map.Add(pair.Key, amqpObject);
                    }
                    else
                    {
                        throw new NotSupportedException(Resources.InvalidAmqpMessageProperty.FormatForUser(pair.Key.GetType()));
                    }
                }
            }

            // delivery annotations

            foreach (KeyValuePair<string, object> kvp in annotatedMessage.DeliveryAnnotations)
            {
                if (TryGetAmqpObjectFromNetObject(kvp.Value, MappingType.ApplicationProperty, out var amqpObject))
                {
                    amqpMessage.DeliveryAnnotations.Map.Add(kvp.Key, amqpObject);
                }
            }

            // header - except for ttl which is set above with the properties

            if (annotatedMessage.Header.DeliveryCount != null)
            {
                amqpMessage.Header.DeliveryCount = annotatedMessage.Header.DeliveryCount;
            }
            if (annotatedMessage.Header.Durable != null)
            {
                amqpMessage.Header.Durable = annotatedMessage.Header.Durable;
            }
            if (annotatedMessage.Header.FirstAcquirer != null)
            {
                amqpMessage.Header.FirstAcquirer = annotatedMessage.Header.FirstAcquirer;
            }
            if (annotatedMessage.Header.Priority != null)
            {
                amqpMessage.Header.Priority = annotatedMessage.Header.Priority;
            }

            // footer

            foreach (KeyValuePair<string, object> kvp in annotatedMessage.Footer)
            {
                amqpMessage.Footer.Map.Add(kvp.Key, kvp.Value);
            }

            return amqpMessage;
        }

        private static AmqpAnnotatedMessage AmqpMessageToAnnotatedMessage(AmqpMessage amqpMessage, bool isPeeked)
        {
            Argument.AssertNotNull(amqpMessage, nameof(amqpMessage));
            AmqpAnnotatedMessage annotatedMessage;
            // body

            if ((amqpMessage.BodyType & SectionFlag.Data) != 0 && amqpMessage.DataBody != null)
            {
                annotatedMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(MessageBody.FromDataSegments(amqpMessage.DataBody)));
            }
            else if ((amqpMessage.BodyType & SectionFlag.AmqpValue) != 0 && amqpMessage.ValueBody?.Value != null)
            {
                if (TryGetNetObjectFromAmqpObject(amqpMessage.ValueBody.Value, MappingType.MessageBody, out object netObject))
                {
                    annotatedMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromValue(netObject));
                }
                else
                {
                    throw new NotSupportedException(Resources.InvalidAmqpMessageValueBody.FormatForUser(amqpMessage.ValueBody.Value.GetType()));
                }
            }
            else if ((amqpMessage.BodyType & SectionFlag.AmqpSequence) != 0)
            {
                annotatedMessage = new AmqpAnnotatedMessage(
                    AmqpMessageBody.FromSequence(amqpMessage.SequenceBody.Select(s => (IList<object>)s.List).ToList()));
            }
            // default to using an empty Data section if no data
            else
            {
                annotatedMessage = new AmqpAnnotatedMessage(new AmqpMessageBody(Enumerable.Empty<ReadOnlyMemory<byte>>()));
            }

            SectionFlag sections = amqpMessage.Sections;

            // properties

            if ((sections & SectionFlag.Properties) != 0)
            {
                if (amqpMessage.Properties.MessageId != null)
                {
                    annotatedMessage.Properties.MessageId = new AmqpMessageId(amqpMessage.Properties.MessageId.ToString());
                }

                if (amqpMessage.Properties.CorrelationId != null)
                {
                    annotatedMessage.Properties.CorrelationId = new AmqpMessageId(amqpMessage.Properties.CorrelationId.ToString());
                }

                if (amqpMessage.Properties.ContentType.Value != null)
                {
                    annotatedMessage.Properties.ContentType = amqpMessage.Properties.ContentType.Value;
                }

                if (amqpMessage.Properties.ContentEncoding.Value != null)
                {
                    annotatedMessage.Properties.ContentEncoding = amqpMessage.Properties.ContentEncoding.Value;
                }

                if (amqpMessage.Properties.Subject != null)
                {
                    annotatedMessage.Properties.Subject = amqpMessage.Properties.Subject;
                }

                if (amqpMessage.Properties.To != null)
                {
                    annotatedMessage.Properties.To = new AmqpAddress(amqpMessage.Properties.To.ToString());
                }

                if (amqpMessage.Properties.ReplyTo != null)
                {
                    annotatedMessage.Properties.ReplyTo = new AmqpAddress(amqpMessage.Properties.ReplyTo.ToString());
                }

                if (amqpMessage.Properties.GroupId != null)
                {
                    annotatedMessage.Properties.GroupId = amqpMessage.Properties.GroupId;
                }

                if (amqpMessage.Properties.ReplyToGroupId != null)
                {
                    annotatedMessage.Properties.ReplyToGroupId = amqpMessage.Properties.ReplyToGroupId;
                }

                if (amqpMessage.Properties.GroupSequence != null)
                {
                    annotatedMessage.Properties.GroupSequence = amqpMessage.Properties.GroupSequence;
                }

                if (amqpMessage.Properties.UserId != null)
                {
                    annotatedMessage.Properties.UserId = amqpMessage.Properties.UserId;
                }

                if (amqpMessage.Properties.CreationTime != null)
                {
                    annotatedMessage.Properties.CreationTime = amqpMessage.Properties.CreationTime;
                }

                if (amqpMessage.Properties.AbsoluteExpiryTime != null)
                {
                    annotatedMessage.Properties.AbsoluteExpiryTime =
                        amqpMessage.Properties.AbsoluteExpiryTime >= DateTimeOffset.MaxValue.UtcDateTime
                        ? DateTimeOffset.MaxValue
                        : amqpMessage.Properties.AbsoluteExpiryTime;
                }
            }

            // Do application properties before message annotations, because the application properties
            // can be updated by entries from message annotation.
            if ((sections & SectionFlag.ApplicationProperties) != 0)
            {
                foreach (var pair in amqpMessage.ApplicationProperties.Map)
                {
                    if (TryGetNetObjectFromAmqpObject(pair.Value, MappingType.ApplicationProperty, out var netObject))
                    {
                        annotatedMessage.ApplicationProperties[pair.Key.ToString()] = netObject;
                    }
                }
            }

            // message annotations

            if ((sections & SectionFlag.MessageAnnotations) != 0)
            {
                foreach (var pair in amqpMessage.MessageAnnotations.Map)
                {
                    var key = pair.Key.ToString();
                    switch (key)
                    {
                        case AmqpMessageConstants.EnqueuedTimeUtcName:
                            annotatedMessage.MessageAnnotations[AmqpMessageConstants.EnqueuedTimeUtcName] = pair.Value;
                            break;
                        case AmqpMessageConstants.ScheduledEnqueueTimeUtcName:
                            annotatedMessage.MessageAnnotations[AmqpMessageConstants.ScheduledEnqueueTimeUtcName] = pair.Value;
                            break;
                        case AmqpMessageConstants.SequenceNumberName:
                            annotatedMessage.MessageAnnotations[AmqpMessageConstants.SequenceNumberName] = pair.Value;
                            break;
                        case AmqpMessageConstants.EnqueueSequenceNumberName:
                            annotatedMessage.MessageAnnotations[AmqpMessageConstants.EnqueueSequenceNumberName] = pair.Value;
                            break;
                        case AmqpMessageConstants.LockedUntilName:
                            DateTimeOffset lockedUntil = (DateTime)pair.Value >= DateTimeOffset.MaxValue.UtcDateTime ?
                                DateTimeOffset.MaxValue : (DateTime)pair.Value;
                            annotatedMessage.MessageAnnotations[AmqpMessageConstants.LockedUntilName] = lockedUntil.UtcDateTime;
                            break;
                        case AmqpMessageConstants.PartitionKeyName:
                            annotatedMessage.MessageAnnotations[AmqpMessageConstants.PartitionKeyName] = pair.Value;
                            break;
                        case AmqpMessageConstants.PartitionIdName:
                            annotatedMessage.MessageAnnotations[AmqpMessageConstants.PartitionIdName] = pair.Value;
                            break;
                        case AmqpMessageConstants.ViaPartitionKeyName:
                            annotatedMessage.MessageAnnotations[AmqpMessageConstants.ViaPartitionKeyName] = pair.Value;
                            break;
                        case AmqpMessageConstants.DeadLetterSourceName:
                            annotatedMessage.MessageAnnotations[AmqpMessageConstants.DeadLetterSourceName] = pair.Value;
                            break;
                        case AmqpMessageConstants.MessageStateName:
                            int enumValue = (int)pair.Value;
                            if (Enum.IsDefined(typeof(ServiceBusMessageState), enumValue))
                            {
                                annotatedMessage.MessageAnnotations[AmqpMessageConstants.MessageStateName] = (ServiceBusMessageState)enumValue;
                            }
                            break;
                        default:
                            if (TryGetNetObjectFromAmqpObject(pair.Value, MappingType.ApplicationProperty, out var netObject))
                            {
                                annotatedMessage.MessageAnnotations[key] = netObject;
                            }
                            break;
                    }
                }
            }

            // delivery annotations

            if ((sections & SectionFlag.DeliveryAnnotations) != 0)
            {
                foreach (KeyValuePair<MapKey, object> kvp in amqpMessage.DeliveryAnnotations.Map)
                {
                    if (TryGetNetObjectFromAmqpObject(kvp.Value, MappingType.ApplicationProperty, out var netObject))
                    {
                        annotatedMessage.DeliveryAnnotations[kvp.Key.ToString()] = netObject;
                    }
                }
            }

            // header

            if ((sections & SectionFlag.Header) != 0)
            {
                if (amqpMessage.Header.Ttl != null)
                {
                    annotatedMessage.Header.TimeToLive = TimeSpan.FromMilliseconds(amqpMessage.Header.Ttl.Value);
                }

                if (amqpMessage.Header.DeliveryCount != null)
                {
                    annotatedMessage.Header.DeliveryCount = isPeeked ? (amqpMessage.Header.DeliveryCount.Value) : (amqpMessage.Header.DeliveryCount.Value + 1);
                }
                annotatedMessage.Header.Durable = amqpMessage.Header.Durable;
                annotatedMessage.Header.FirstAcquirer = amqpMessage.Header.FirstAcquirer;
                annotatedMessage.Header.Priority = amqpMessage.Header.Priority;
            }

            // footer

            if ((sections & SectionFlag.Footer) != 0)
            {
                foreach (KeyValuePair<MapKey, object> kvp in amqpMessage.Footer.Map)
                {
                    if (TryGetNetObjectFromAmqpObject(kvp.Value, MappingType.ApplicationProperty, out var netObject))
                    {
                        annotatedMessage.Footer[kvp.Key.ToString()] = netObject;
                    }
                }
            }

            return annotatedMessage;
        }

        public virtual ServiceBusReceivedMessage AmqpMessageToSBReceivedMessage(AmqpMessage amqpMessage, bool isPeeked = false)
        {
            AmqpAnnotatedMessage annotatedMessage = AmqpMessageToAnnotatedMessage(amqpMessage, isPeeked);

            ServiceBusReceivedMessage sbMessage = new ServiceBusReceivedMessage(annotatedMessage);

            // lock token

            sbMessage.LockTokenGuid = GuidUtilities.ParseGuidBytes(amqpMessage.DeliveryTag);

            amqpMessage.Dispose();

            return sbMessage;
        }

        internal static bool TryGetAmqpObjectFromNetObject(object netObject, MappingType mappingType, out object amqpObject)
        {
            amqpObject = null;
            if (netObject == null)
            {
                return true;
            }

            switch (SerializationUtilities.GetTypeId(netObject))
            {
                case PropertyValueType.Byte:
                case PropertyValueType.SByte:
                case PropertyValueType.Int16:
                case PropertyValueType.Int32:
                case PropertyValueType.Int64:
                case PropertyValueType.UInt16:
                case PropertyValueType.UInt32:
                case PropertyValueType.UInt64:
                case PropertyValueType.Single:
                case PropertyValueType.Double:
                case PropertyValueType.Boolean:
                case PropertyValueType.Decimal:
                case PropertyValueType.Char:
                case PropertyValueType.Guid:
                case PropertyValueType.DateTime:
                case PropertyValueType.String:
                    amqpObject = netObject;
                    break;
                case PropertyValueType.Stream:
                    if (mappingType == MappingType.ApplicationProperty)
                    {
                        amqpObject = ReadStreamToArraySegment((Stream)netObject);
                    }
                    break;
                case PropertyValueType.Uri:
                    amqpObject = new DescribedType((AmqpSymbol)AmqpMessageConstants.UriName, ((Uri)netObject).AbsoluteUri);
                    break;
                case PropertyValueType.DateTimeOffset:
                    amqpObject = new DescribedType((AmqpSymbol)AmqpMessageConstants.DateTimeOffsetName, ((DateTimeOffset)netObject).UtcTicks);
                    break;
                case PropertyValueType.TimeSpan:
                    amqpObject = new DescribedType((AmqpSymbol)AmqpMessageConstants.TimeSpanName, ((TimeSpan)netObject).Ticks);
                    break;
                case PropertyValueType.Unknown:
                    if (netObject is Stream netObjectAsStream)
                    {
                        if (mappingType == MappingType.ApplicationProperty)
                        {
                            amqpObject = ReadStreamToArraySegment(netObjectAsStream);
                        }
                    }
                    else if (mappingType == MappingType.ApplicationProperty)
                    {
                        throw new SerializationException(Resources.FailedToSerializeUnsupportedType.FormatForUser(netObject.GetType().FullName));
                    }
                    else if (netObject is byte[] netObjectAsByteArray)
                    {
                        amqpObject = new ArraySegment<byte>(netObjectAsByteArray);
                    }
                    else if (netObject is IList)
                    {
                        // Array is also an IList
                        amqpObject = netObject;
                    }
                    else if (netObject is IDictionary netObjectAsDictionary)
                    {
                        amqpObject = new AmqpMap(netObjectAsDictionary);
                    }
                    break;
            }

            return amqpObject != null;
        }

        private static bool TryGetNetObjectFromAmqpObject(object amqpObject, MappingType mappingType, out object netObject)
        {
            netObject = null;
            if (amqpObject == null)
            {
                return true;
            }

            switch (SerializationUtilities.GetTypeId(amqpObject))
            {
                case PropertyValueType.Byte:
                case PropertyValueType.SByte:
                case PropertyValueType.Int16:
                case PropertyValueType.Int32:
                case PropertyValueType.Int64:
                case PropertyValueType.UInt16:
                case PropertyValueType.UInt32:
                case PropertyValueType.UInt64:
                case PropertyValueType.Single:
                case PropertyValueType.Double:
                case PropertyValueType.Boolean:
                case PropertyValueType.Decimal:
                case PropertyValueType.Char:
                case PropertyValueType.Guid:
                case PropertyValueType.DateTime:
                case PropertyValueType.String:
                    netObject = amqpObject;
                    break;
                case PropertyValueType.Unknown:
                    if (amqpObject is AmqpSymbol amqpObjectAsAmqpSymbol)
                    {
                        netObject = (amqpObjectAsAmqpSymbol).Value;
                    }
                    else if (amqpObject is ArraySegment<byte> amqpObjectAsArraySegment)
                    {
                        ArraySegment<byte> binValue = amqpObjectAsArraySegment;
                        if (binValue.Count == binValue.Array.Length)
                        {
                            netObject = binValue.Array;
                        }
                        else
                        {
                            var buffer = new byte[binValue.Count];
                            Buffer.BlockCopy(binValue.Array, binValue.Offset, buffer, 0, binValue.Count);
                            netObject = buffer;
                        }
                    }
                    else if (amqpObject is DescribedType amqpObjectAsDescribedType)
                    {
                        if (amqpObjectAsDescribedType.Descriptor is AmqpSymbol)
                        {
                            var amqpSymbol = (AmqpSymbol)amqpObjectAsDescribedType.Descriptor;
                            if (amqpSymbol.Equals((AmqpSymbol)AmqpMessageConstants.UriName))
                            {
                                netObject = new Uri((string)amqpObjectAsDescribedType.Value);
                            }
                            else if (amqpSymbol.Equals((AmqpSymbol)AmqpMessageConstants.TimeSpanName))
                            {
                                netObject = new TimeSpan((long)amqpObjectAsDescribedType.Value);
                            }
                            else if (amqpSymbol.Equals((AmqpSymbol)AmqpMessageConstants.DateTimeOffsetName))
                            {
                                netObject = new DateTimeOffset(new DateTime((long)amqpObjectAsDescribedType.Value, DateTimeKind.Utc));
                            }
                        }
                    }
                    else if (mappingType == MappingType.ApplicationProperty)
                    {
                        throw new SerializationException(Resources.FailedToSerializeUnsupportedType.FormatForUser(amqpObject.GetType().FullName));
                    }
                    else if (amqpObject is AmqpMap map)
                    {
                        var dictionary = new Dictionary<string, object>();
                        foreach (var pair in map)
                        {
                            dictionary.Add(pair.Key.ToString(), pair.Value);
                        }

                        netObject = dictionary;
                    }
                    else
                    {
                        netObject = amqpObject;
                    }
                    break;
            }

            return netObject != null;
        }
    }
}
