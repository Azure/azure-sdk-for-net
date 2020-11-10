// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Azure.Core;
using Azure.Core.Amqp;
using Azure.Messaging.ServiceBus.Amqp.Framing;
using Azure.Messaging.ServiceBus.Administration;
using Azure.Messaging.ServiceBus.Primitives;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;
using SBMessage = Azure.Messaging.ServiceBus.ServiceBusMessage;

namespace Azure.Messaging.ServiceBus.Amqp
{
    internal static class AmqpMessageConverter
    {
        /// <summary>
        /// The size, in bytes, to use for extracting the delivery tag bytes into <see cref="Guid"/>.
        /// </summary>
        private const int GuidSizeInBytes = 16;

        /// <summary>The size, in bytes, to use as a buffer for stream operations.</summary>
        private const int StreamBufferSizeInBytes = 512;

        public static AmqpMessage BatchSBMessagesAsAmqpMessage(IEnumerable<SBMessage> source)
        {
            Argument.AssertNotNull(source, nameof(source));
            return BuildAmqpBatchFromMessage(source);
        }

        /// <summary>
        ///   Builds a batch <see cref="AmqpMessage" /> from a set of <see cref="SBMessage" />
        ///   optionally propagating the custom properties.
        /// </summary>
        ///
        /// <param name="source">The set of messages to use as the body of the batch message.</param>
        ///
        /// <returns>The batch <see cref="AmqpMessage" /> containing the source messages.</returns>
        ///
        private static AmqpMessage BuildAmqpBatchFromMessage(IEnumerable<SBMessage> source)
        {
            AmqpMessage firstAmqpMessage = null;
            SBMessage firstMessage = null;

            return BuildAmqpBatchFromMessages(
                source.Select(sbMessage =>
                {
                    if (firstAmqpMessage == null)
                    {
                        firstAmqpMessage = SBMessageToAmqpMessage(sbMessage);
                        firstMessage = sbMessage;
                        return firstAmqpMessage;
                    }
                    else
                    {
                        return SBMessageToAmqpMessage(sbMessage);
                    }
                }).ToList(), firstMessage);
        }

        /// <summary>
        ///   Builds a batch <see cref="AmqpMessage" /> from a set of <see cref="AmqpMessage" />.
        /// </summary>
        ///
        /// <param name="batchMessages">The set of messages to use as the body of the batch message.</param>
        /// <param name="firstMessage"></param>
        ///
        /// <returns>The batch <see cref="AmqpMessage" /> containing the source messages.</returns>
        ///
        private static AmqpMessage BuildAmqpBatchFromMessages(
            IList<AmqpMessage> batchMessages,
            SBMessage firstMessage = null)
        {
            AmqpMessage batchEnvelope;

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

            if (firstMessage?.MessageId != null)
            {
                batchEnvelope.Properties.MessageId = firstMessage.MessageId;
            }
            if (firstMessage?.SessionId != null)
            {
                batchEnvelope.Properties.GroupId = firstMessage.SessionId;
            }

            if (firstMessage?.PartitionKey != null)
            {
                batchEnvelope.MessageAnnotations.Map[AmqpMessageConstants.PartitionKeyName] =
                    firstMessage.PartitionKey;
            }

            if (firstMessage?.TransactionPartitionKey != null)
            {
                batchEnvelope.MessageAnnotations.Map[AmqpMessageConstants.ViaPartitionKeyName] =
                    firstMessage.TransactionPartitionKey;
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
            if (stream == null)
            {
                return new ArraySegment<byte>();
            }

            using var memStream = new MemoryStream(StreamBufferSizeInBytes);
            stream.CopyTo(memStream, StreamBufferSizeInBytes);

            return new ArraySegment<byte>(memStream.ToArray());
        }

        public static AmqpMessage SBMessageToAmqpMessage(SBMessage sbMessage)
        {
            var amqpMessage = sbMessage.ToAmqpMessage();
            amqpMessage.Properties.MessageId = sbMessage.MessageId;
            amqpMessage.Properties.CorrelationId = sbMessage.CorrelationId;
            amqpMessage.Properties.ContentType = sbMessage.ContentType;
            amqpMessage.Properties.Subject = sbMessage.Subject;
            amqpMessage.Properties.To = sbMessage.To;
            amqpMessage.Properties.ReplyTo = sbMessage.ReplyTo;
            amqpMessage.Properties.GroupId = sbMessage.SessionId;
            amqpMessage.Properties.ReplyToGroupId = sbMessage.ReplyToSessionId;

            if (sbMessage.TimeToLive != TimeSpan.MaxValue)
            {
                amqpMessage.Header.Ttl = (uint)sbMessage.TimeToLive.TotalMilliseconds;
                amqpMessage.Properties.CreationTime = DateTime.UtcNow;

                if (AmqpConstants.MaxAbsoluteExpiryTime - amqpMessage.Properties.CreationTime.Value > sbMessage.TimeToLive)
                {
                    amqpMessage.Properties.AbsoluteExpiryTime = amqpMessage.Properties.CreationTime.Value + sbMessage.TimeToLive;
                }
                else
                {
                    amqpMessage.Properties.AbsoluteExpiryTime = AmqpConstants.MaxAbsoluteExpiryTime;
                }
            }

            if ((sbMessage.ScheduledEnqueueTime != null) && sbMessage.ScheduledEnqueueTime > DateTimeOffset.MinValue)
            {
                amqpMessage.MessageAnnotations.Map.Add(AmqpMessageConstants.ScheduledEnqueueTimeUtcName, sbMessage.ScheduledEnqueueTime.UtcDateTime);
            }

            if (sbMessage.PartitionKey != null)
            {
                amqpMessage.MessageAnnotations.Map.Add(AmqpMessageConstants.PartitionKeyName, sbMessage.PartitionKey);
            }

            if (sbMessage.TransactionPartitionKey != null)
            {
                amqpMessage.MessageAnnotations.Map.Add(AmqpMessageConstants.ViaPartitionKeyName, sbMessage.TransactionPartitionKey);
            }

            if (sbMessage.ApplicationProperties != null && sbMessage.ApplicationProperties.Count > 0)
            {
                if (amqpMessage.ApplicationProperties == null)
                {
                    amqpMessage.ApplicationProperties = new ApplicationProperties();
                }

                foreach (var pair in sbMessage.ApplicationProperties)
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

            return amqpMessage;
        }

        public static ServiceBusReceivedMessage AmqpMessageToSBMessage(AmqpMessage amqpMessage, bool isPeeked = false)
        {
            Argument.AssertNotNull(amqpMessage, nameof(amqpMessage));
            AmqpAnnotatedMessage annotatedMessage;

            if ((amqpMessage.BodyType & SectionFlag.Data) != 0 && amqpMessage.DataBody != null)
            {
                annotatedMessage = new AmqpAnnotatedMessage(new AmqpMessageBody(amqpMessage.GetDataViaDataBody()));
            }
            else
            {
                annotatedMessage = new AmqpAnnotatedMessage(new AmqpMessageBody(Enumerable.Empty<ReadOnlyMemory<byte>>()));
            }
            ServiceBusReceivedMessage sbMessage = new ServiceBusReceivedMessage(annotatedMessage);

            SectionFlag sections = amqpMessage.Sections;
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
            }

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

            if ((sections & SectionFlag.MessageAnnotations) != 0)
            {
                foreach (var pair in amqpMessage.MessageAnnotations.Map)
                {
                    var key = pair.Key.ToString();
                    switch (key)
                    {
                        case AmqpMessageConstants.EnqueuedTimeUtcName:
                            annotatedMessage.MessageAnnotations[AmqpMessageConstants.EnqueuedTimeUtcName] = (DateTime)pair.Value;
                            break;
                        case AmqpMessageConstants.ScheduledEnqueueTimeUtcName:
                            annotatedMessage.MessageAnnotations[AmqpMessageConstants.ScheduledEnqueueTimeUtcName] = (DateTime)pair.Value;
                            break;
                        case AmqpMessageConstants.SequenceNumberName:
                            annotatedMessage.MessageAnnotations[AmqpMessageConstants.SequenceNumberName] = (long)pair.Value;
                            break;
                        case AmqpMessageConstants.EnqueueSequenceNumberName:
                            annotatedMessage.MessageAnnotations[AmqpMessageConstants.EnqueueSequenceNumberName] = (long)pair.Value;
                            break;
                        case AmqpMessageConstants.LockedUntilName:
                            DateTimeOffset lockedUntil = (DateTime)pair.Value >= DateTimeOffset.MaxValue.UtcDateTime ?
                                DateTimeOffset.MaxValue : (DateTime)pair.Value;
                            annotatedMessage.MessageAnnotations[AmqpMessageConstants.LockedUntilName] = lockedUntil.UtcDateTime;
                            break;
                        case AmqpMessageConstants.PartitionKeyName:
                            annotatedMessage.MessageAnnotations[AmqpMessageConstants.PartitionKeyName] = (string)pair.Value;
                            break;
                        case AmqpMessageConstants.PartitionIdName:
                            annotatedMessage.MessageAnnotations[AmqpMessageConstants.PartitionIdName] = (short)pair.Value;
                            break;
                        case AmqpMessageConstants.ViaPartitionKeyName:
                            annotatedMessage.MessageAnnotations[AmqpMessageConstants.ViaPartitionKeyName] = (string)pair.Value;
                            break;
                        case AmqpMessageConstants.DeadLetterSourceName:
                            annotatedMessage.MessageAnnotations[AmqpMessageConstants.DeadLetterSourceName] = (string)pair.Value;
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

            if (amqpMessage.DeliveryTag.Count == GuidSizeInBytes)
            {
                var guidBuffer = new byte[GuidSizeInBytes];
                Buffer.BlockCopy(amqpMessage.DeliveryTag.Array, amqpMessage.DeliveryTag.Offset, guidBuffer, 0, GuidSizeInBytes);
                sbMessage.LockTokenGuid = new Guid(guidBuffer);
            }

            amqpMessage.Dispose();

            return sbMessage;
        }

        public static AmqpMap GetRuleDescriptionMap(RuleProperties description)
        {
            var ruleDescriptionMap = new AmqpMap();

            switch (description.Filter)
            {
                case SqlRuleFilter sqlRuleFilter:
                    var filterMap = GetSqlRuleFilterMap(sqlRuleFilter);
                    ruleDescriptionMap[ManagementConstants.Properties.SqlRuleFilter] = filterMap;
                    break;
                case CorrelationRuleFilter correlationFilter:
                    var correlationFilterMap = GetCorrelationRuleFilterMap(correlationFilter);
                    ruleDescriptionMap[ManagementConstants.Properties.CorrelationRuleFilter] = correlationFilterMap;
                    break;
                default:
                    throw new NotSupportedException(
                        Resources.RuleFilterNotSupported.FormatForUser(
                            description.Filter.GetType(),
                            nameof(SqlRuleFilter),
                            nameof(CorrelationRuleFilter)));
            }

            var amqpAction = GetRuleActionMap(description.Action as SqlRuleAction);
            ruleDescriptionMap[ManagementConstants.Properties.SqlRuleAction] = amqpAction;
            ruleDescriptionMap[ManagementConstants.Properties.RuleName] = description.Name;

            return ruleDescriptionMap;
        }

        public static RuleProperties GetRuleDescription(AmqpRuleDescriptionCodec amqpDescription)
        {
            var filter = GetFilter(amqpDescription.Filter);
            var ruleAction = GetRuleAction(amqpDescription.Action);

            var ruleDescription = new RuleProperties(amqpDescription.RuleName, filter)
            {
                Action = ruleAction
            };

            return ruleDescription;
        }

        public static RuleFilter GetFilter(AmqpRuleFilterCodec amqpFilter)
        {
            RuleFilter filter;

            switch (amqpFilter.DescriptorCode)
            {
                case AmqpSqlRuleFilterCodec.Code:
                    var amqpSqlFilter = (AmqpSqlRuleFilterCodec)amqpFilter;
                    filter = new SqlRuleFilter(amqpSqlFilter.Expression);
                    break;

                case AmqpTrueRuleFilterCodec.Code:
                    filter = new TrueRuleFilter();
                    break;

                case AmqpFalseRuleFilterCodec.Code:
                    filter = new FalseRuleFilter();
                    break;

                case AmqpCorrelationRuleFilterCodec.Code:
                    var amqpCorrelationFilter = (AmqpCorrelationRuleFilterCodec)amqpFilter;
                    var correlationFilter = new CorrelationRuleFilter
                    {
                        CorrelationId = amqpCorrelationFilter.CorrelationId,
                        MessageId = amqpCorrelationFilter.MessageId,
                        To = amqpCorrelationFilter.To,
                        ReplyTo = amqpCorrelationFilter.ReplyTo,
                        Subject = amqpCorrelationFilter.Subject,
                        SessionId = amqpCorrelationFilter.SessionId,
                        ReplyToSessionId = amqpCorrelationFilter.ReplyToSessionId,
                        ContentType = amqpCorrelationFilter.ContentType
                    };

                    foreach (var property in amqpCorrelationFilter.Properties)
                    {
                        correlationFilter.ApplicationProperties.Add(property.Key.Key.ToString(), property.Value);
                    }

                    filter = correlationFilter;
                    break;

                default:
                    throw new NotSupportedException($"Unknown filter descriptor code: {amqpFilter.DescriptorCode}");
            }

            return filter;
        }

        private static RuleAction GetRuleAction(AmqpRuleActionCodec amqpAction)
        {
            RuleAction action;

            if (amqpAction.DescriptorCode == AmqpEmptyRuleActionCodec.Code)
            {
                action = null;
            }
            else if (amqpAction.DescriptorCode == AmqpSqlRuleActionCodec.Code)
            {
                var amqpSqlRuleAction = (AmqpSqlRuleActionCodec)amqpAction;
                var sqlRuleAction = new SqlRuleAction(amqpSqlRuleAction.SqlExpression);

                action = sqlRuleAction;
            }
            else
            {
                throw new NotSupportedException($"Unknown action descriptor code: {amqpAction.DescriptorCode}");
            }

            return action;
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
                        amqpObject = StreamToBytes((Stream)netObject);
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
                            amqpObject = StreamToBytes(netObjectAsStream);
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

        private static ArraySegment<byte> StreamToBytes(Stream stream)
        {
            ArraySegment<byte> buffer;
            if (stream == null || stream.Length < 1)
            {
                buffer = default;
            }
            else
            {
                using (var memoryStream = new MemoryStream(512))
                {
                    stream.CopyTo(memoryStream, 512);
                    buffer = new ArraySegment<byte>(memoryStream.ToArray());
                }
            }

            return buffer;
        }

        private static Data ToData(AmqpMessage message)
        {
            ArraySegment<byte>[] payload = message.GetPayload();
            var buffer = new BufferListStream(payload);
            ArraySegment<byte> value = buffer.ReadBytes((int)buffer.Length);
            return new Data { Value = value };
        }

        internal static AmqpMap GetSqlRuleFilterMap(SqlRuleFilter sqlRuleFilter)
        {
            var amqpFilterMap = new AmqpMap
            {
                [ManagementConstants.Properties.Expression] = sqlRuleFilter.SqlExpression
            };
            return amqpFilterMap;
        }

        internal static AmqpMap GetCorrelationRuleFilterMap(CorrelationRuleFilter correlationRuleFilter)
        {
            var correlationRuleFilterMap = new AmqpMap
            {
                [ManagementConstants.Properties.CorrelationId] = correlationRuleFilter.CorrelationId,
                [ManagementConstants.Properties.MessageId] = correlationRuleFilter.MessageId,
                [ManagementConstants.Properties.To] = correlationRuleFilter.To,
                [ManagementConstants.Properties.ReplyTo] = correlationRuleFilter.ReplyTo,
                [ManagementConstants.Properties.Label] = correlationRuleFilter.Subject,
                [ManagementConstants.Properties.SessionId] = correlationRuleFilter.SessionId,
                [ManagementConstants.Properties.ReplyToSessionId] = correlationRuleFilter.ReplyToSessionId,
                [ManagementConstants.Properties.ContentType] = correlationRuleFilter.ContentType
            };

            var propertiesMap = new AmqpMap();
            foreach (var property in correlationRuleFilter.ApplicationProperties)
            {
                propertiesMap[new MapKey(property.Key)] = property.Value;
            }

            correlationRuleFilterMap[ManagementConstants.Properties.CorrelationRuleFilterProperties] = propertiesMap;

            return correlationRuleFilterMap;
        }

        internal static AmqpMap GetRuleActionMap(SqlRuleAction sqlRuleAction)
        {
            AmqpMap ruleActionMap = null;
            if (sqlRuleAction != null)
            {
                ruleActionMap = new AmqpMap { [ManagementConstants.Properties.Expression] = sqlRuleAction.SqlExpression };
            }

            return ruleActionMap;
        }
    }
}
