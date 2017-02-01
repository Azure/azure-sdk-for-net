// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Encoding;
    using Microsoft.Azure.Amqp.Framing;
    using Microsoft.Azure.Messaging.Amqp;
    using Microsoft.Azure.ServiceBus.Filters;

    static class AmqpMessageConverter
    {
        const string EnqueuedTimeUtcName = "x-opt-enqueued-time";
        const string ScheduledEnqueueTimeUtcName = "x-opt-scheduled-enqueue-time";
        const string SequenceNumberName = "x-opt-sequence-number";
        const string OffsetName = "x-opt-offset";
        const string LockedUntilName = "x-opt-locked-until";
        const string PublisherName = "x-opt-publisher";
        const string PartitionKeyName = "x-opt-partition-key";
        const string PartitionIdName = "x-opt-partition-id";
        const string DeadLetterSourceName = "x-opt-deadletter-source";
        const string TimeSpanName = AmqpConstants.Vendor + ":timespan";
        const string UriName = AmqpConstants.Vendor + ":uri";
        const string DateTimeOffsetName = AmqpConstants.Vendor + ":datetime-offset";
        const int GuidSize = 16;

        public static AmqpMessage BrokeredMessagesToAmqpMessage(IEnumerable<BrokeredMessage> brokeredMessages, bool batchable)
        {
            AmqpMessage amqpMessage;
            AmqpMessage firstAmqpMessage = null;
            BrokeredMessage firstBrokeredMessage = null;
            List<Data> dataList = null;
            int messageCount = 0;
            foreach (var brokeredMessage in brokeredMessages)
            {
                messageCount++;

                amqpMessage = AmqpMessageConverter.ClientGetMessage(brokeredMessage);
                if (firstAmqpMessage == null)
                {
                    firstAmqpMessage = amqpMessage;
                    firstBrokeredMessage = brokeredMessage;
                    continue;
                }

                if (dataList == null)
                {
                    dataList = new List<Data>() { ToData(firstAmqpMessage) };
                }

                dataList.Add(ToData(amqpMessage));
            }

            if (messageCount == 1 && firstAmqpMessage != null)
            {
                firstAmqpMessage.Batchable = batchable;
                return firstAmqpMessage;
            }

            amqpMessage = AmqpMessage.Create(dataList);
            amqpMessage.MessageFormat = AmqpConstants.AmqpBatchedMessageFormat;

            if (firstBrokeredMessage.MessageId != null)
            {
                amqpMessage.Properties.MessageId = firstBrokeredMessage.MessageId;
            }
            if (firstBrokeredMessage.SessionId != null)
            {
                amqpMessage.Properties.GroupId = firstBrokeredMessage.SessionId;
            }

            if (firstBrokeredMessage.PartitionKey != null)
            {
                amqpMessage.MessageAnnotations.Map[AmqpMessageConverter.PartitionKeyName] =
                    firstBrokeredMessage.PartitionKey;
            }

            amqpMessage.Batchable = batchable;
            return amqpMessage;
        }

        // return from AMQP lib to client API for a received message
        // TODO: expose other AMQP sections in BrokeredMessage
        public static BrokeredMessage ClientGetMessage(AmqpMessage amqpMessage)
        {
            BrokeredMessage brokeredMessage;

            if ((amqpMessage.BodyType & SectionFlag.Data) != 0 ||
                (amqpMessage.BodyType & SectionFlag.AmqpSequence) != 0)
            {
                Stream bodyStream = AmqpMessageConverter.GetMessageBodyStream(amqpMessage);
                brokeredMessage = new BrokeredMessage(bodyStream, true);
            }
            else if ((amqpMessage.BodyType & SectionFlag.AmqpValue) != 0)
            {
                object netObject;
                if (!TryGetNetObjectFromAmqpObject(amqpMessage.ValueBody.Value, MappingType.MessageBody, out netObject))
                {
                    netObject = amqpMessage.ValueBody.Value;
                }

                brokeredMessage = new BrokeredMessage(netObject, amqpMessage.BodyStream);
            }
            else
            {
                brokeredMessage = new BrokeredMessage();
            }

            SectionFlag sections = amqpMessage.Sections;
            if ((sections & SectionFlag.Header) != 0)
            {
                if (amqpMessage.Header.Ttl != null)
                {
                    brokeredMessage.TimeToLive = TimeSpan.FromMilliseconds(amqpMessage.Header.Ttl.Value);
                }

                if (amqpMessage.Header.DeliveryCount != null)
                {
                    brokeredMessage.DeliveryCount = (int)(amqpMessage.Header.DeliveryCount.Value + 1);
                }
            }

            if ((sections & SectionFlag.Properties) != 0)
            {
                if (amqpMessage.Properties.MessageId != null)
                {
                    brokeredMessage.MessageId = amqpMessage.Properties.MessageId.ToString();
                }

                if (amqpMessage.Properties.CorrelationId != null)
                {
                    brokeredMessage.CorrelationId = amqpMessage.Properties.CorrelationId.ToString();
                }

                if (amqpMessage.Properties.ContentType.Value != null)
                {
                    brokeredMessage.ContentType = amqpMessage.Properties.ContentType.Value;
                }

                if (amqpMessage.Properties.Subject != null)
                {
                    brokeredMessage.Label = amqpMessage.Properties.Subject;
                }

                if (amqpMessage.Properties.To != null)
                {
                    brokeredMessage.To = amqpMessage.Properties.To.ToString();
                }

                if (amqpMessage.Properties.ReplyTo != null)
                {
                    brokeredMessage.ReplyTo = amqpMessage.Properties.ReplyTo.ToString();
                }

                if (amqpMessage.Properties.GroupId != null)
                {
                    brokeredMessage.SessionId = amqpMessage.Properties.GroupId;
                }

                if (amqpMessage.Properties.ReplyToGroupId != null)
                {
                    brokeredMessage.ReplyToSessionId = amqpMessage.Properties.ReplyToGroupId;
                }
            }

            // Do applicaiton properties before message annotations, because the application properties
            // can be updated by entries from message annotation.
            if ((sections & SectionFlag.ApplicationProperties) != 0)
            {
                foreach (var pair in amqpMessage.ApplicationProperties.Map)
                {
                    object netObject;
                    if (TryGetNetObjectFromAmqpObject(pair.Value, MappingType.ApplicationProperty, out netObject))
                    {
                        brokeredMessage.Properties[pair.Key.ToString()] = netObject;
                    }
                }
            }

            if ((sections & SectionFlag.MessageAnnotations) != 0)
            {
                foreach (var pair in amqpMessage.MessageAnnotations.Map)
                {
                    string key = pair.Key.ToString();
                    switch (key)
                    {
                        case EnqueuedTimeUtcName:
                            brokeredMessage.EnqueuedTimeUtc = (DateTime)pair.Value;
                            break;
                        case ScheduledEnqueueTimeUtcName:
                            brokeredMessage.ScheduledEnqueueTimeUtc = (DateTime)pair.Value;
                            break;
                        case SequenceNumberName:
                            brokeredMessage.SequenceNumber = (long)pair.Value;
                            break;
                        case OffsetName:
                            brokeredMessage.EnqueuedSequenceNumber = long.Parse((string)pair.Value);
                            break;
                        case LockedUntilName:
                            brokeredMessage.LockedUntilUtc = (DateTime)pair.Value;
                            break;
                        case PublisherName:
                            brokeredMessage.Publisher = (string)pair.Value;
                            break;
                        case PartitionKeyName:
                            brokeredMessage.PartitionKey = (string)pair.Value;
                            break;
                        case PartitionIdName:
                            brokeredMessage.PartitionId = (short)pair.Value;
                            break;
                        case DeadLetterSourceName:
                            brokeredMessage.DeadLetterSource = (string)pair.Value;
                            break;
                        default:
                            object netObject;
                            if (TryGetNetObjectFromAmqpObject(pair.Value, MappingType.ApplicationProperty, out netObject))
                            {
                                brokeredMessage.Properties[key] = netObject;
                            }
                            break;
                    }
                }
            }

            if (amqpMessage.DeliveryTag.Count == GuidSize)
            {
                byte[] guidBuffer = new byte[GuidSize];
                Buffer.BlockCopy(amqpMessage.DeliveryTag.Array, amqpMessage.DeliveryTag.Offset, guidBuffer, 0, GuidSize);
                brokeredMessage.LockToken = new Guid(guidBuffer);
            }

            brokeredMessage.AttachDisposables(new[] { amqpMessage });

            return brokeredMessage;
        }

        // return from Client API to AMQP lib for send
        public static AmqpMessage ClientGetMessage(BrokeredMessage brokeredMessage)
        {
            AmqpMessage amqpMessage = AmqpMessageConverter.CreateAmqpMessageFromSbmpMessage(brokeredMessage);

            amqpMessage.Properties.MessageId = brokeredMessage.MessageId;
            amqpMessage.Properties.CorrelationId = brokeredMessage.CorrelationId;
            amqpMessage.Properties.ContentType = brokeredMessage.ContentType;
            amqpMessage.Properties.Subject = brokeredMessage.Label;
            amqpMessage.Properties.To = brokeredMessage.To;
            amqpMessage.Properties.ReplyTo = brokeredMessage.ReplyTo;
            amqpMessage.Properties.GroupId = brokeredMessage.SessionId;
            amqpMessage.Properties.ReplyToGroupId = brokeredMessage.ReplyToSessionId;

            if ((brokeredMessage.InitializedMembers & BrokeredMessage.MessageMembers.TimeToLive) != 0)
            {
                amqpMessage.Header.Ttl = (uint)brokeredMessage.TimeToLive.TotalMilliseconds;
                amqpMessage.Properties.CreationTime = DateTime.UtcNow;

                if (AmqpConstants.MaxAbsoluteExpiryTime - amqpMessage.Properties.CreationTime.Value > brokeredMessage.TimeToLive)
                {
                    amqpMessage.Properties.AbsoluteExpiryTime = amqpMessage.Properties.CreationTime.Value + brokeredMessage.TimeToLive;
                }
                else
                {
                    amqpMessage.Properties.AbsoluteExpiryTime = AmqpConstants.MaxAbsoluteExpiryTime;
                }
            }

            if ((brokeredMessage.InitializedMembers & BrokeredMessage.MessageMembers.ScheduledEnqueueTimeUtc) != 0 &&
                brokeredMessage.ScheduledEnqueueTimeUtc > DateTime.MinValue)
            {
                amqpMessage.MessageAnnotations.Map.Add(ScheduledEnqueueTimeUtcName, brokeredMessage.ScheduledEnqueueTimeUtc);
            }

            if ((brokeredMessage.InitializedMembers & BrokeredMessage.MessageMembers.Publisher) != 0 &&
                brokeredMessage.Publisher != null)
            {
                amqpMessage.MessageAnnotations.Map.Add(PublisherName, brokeredMessage.Publisher);
            }

            if ((brokeredMessage.InitializedMembers & BrokeredMessage.MessageMembers.DeadLetterSource) != 0 &&
                brokeredMessage.DeadLetterSource != null)
            {
                amqpMessage.MessageAnnotations.Map.Add(DeadLetterSourceName, brokeredMessage.DeadLetterSource);
            }

            if ((brokeredMessage.InitializedMembers & BrokeredMessage.MessageMembers.PartitionKey) != 0 &&
                brokeredMessage.PartitionKey != null)
            {
                amqpMessage.MessageAnnotations.Map.Add(PartitionKeyName, brokeredMessage.PartitionKey);
            }

            foreach (KeyValuePair<string, object> pair in brokeredMessage.Properties)
            {
                object amqpObject;
                if (TryGetAmqpObjectFromNetObject(pair.Value, MappingType.ApplicationProperty, out amqpObject))
                {
                    amqpMessage.ApplicationProperties.Map.Add(pair.Key, amqpObject);
                }
            }

            return amqpMessage;
        }

        public static AmqpMessage CreateAmqpMessageFromSbmpMessage(BrokeredMessage brokeredMessage)
        {
            AmqpMessage amqpMessage;

            object bodyObject = brokeredMessage.ClearBodyObject();
            object mappedBodyObject = null;

            if (bodyObject != null)
            {
                TryGetAmqpObjectFromNetObject(bodyObject, MappingType.MessageBody, out mappedBodyObject);
            }

            if (mappedBodyObject != null)
            {
                amqpMessage = AmqpMessage.Create(new AmqpValue() { Value = mappedBodyObject });
            }
            else if (brokeredMessage.BodyStream != null)
            {
                if (brokeredMessage.BodyStream.CanSeek && brokeredMessage.BodyStream.Position != 0)
                {
                    // TODO:throw new InvalidOperationException(SRClient.CannotSerializeMessageWithPartiallyConsumedBodyStream);
                    throw new InvalidOperationException("CannotSerializeMessageWithPartiallyConsumedBodyStream");
                }

                amqpMessage = AmqpMessage.Create(brokeredMessage.BodyStream, false);
            }
            else
            {
                amqpMessage = AmqpMessage.Create();
            }

            return amqpMessage;
        }

        public static bool TryGetAmqpObjectFromNetObject(object netObject, MappingType mappingType, out object amqpObject)
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
                    amqpObject = new DescribedType((AmqpSymbol)UriName, ((Uri)netObject).AbsoluteUri);
                    break;
                case PropertyValueType.DateTimeOffset:
                    amqpObject = new DescribedType((AmqpSymbol)DateTimeOffsetName, ((DateTimeOffset)netObject).UtcTicks);
                    break;
                case PropertyValueType.TimeSpan:
                    amqpObject = new DescribedType((AmqpSymbol)TimeSpanName, ((TimeSpan)netObject).Ticks);
                    break;
                case PropertyValueType.Unknown:
                    if (netObject is Stream)
                    {
                        if (mappingType == MappingType.ApplicationProperty)
                        {
                            amqpObject = StreamToBytes((Stream)netObject);
                        }
                    }
                    else if (mappingType == MappingType.ApplicationProperty)
                    {
                        // TODO: throw FxTrace.Exception.AsError(new SerializationException(SRClient.FailedToSerializeUnsupportedType(netObject.GetType().FullName)));
                        throw new SerializationException("netObject.GetType().FullName");
                    }
                    else if (netObject is byte[])
                    {
                        amqpObject = new ArraySegment<byte>((byte[])netObject);
                    }
                    else if (netObject is IList)
                    {
                        // Array is also an IList
                        amqpObject = netObject;
                    }
                    else if (netObject is IDictionary)
                    {
                        amqpObject = new AmqpMap((IDictionary)netObject);
                    }
                    break;
                default:
                    break;
            }

            return amqpObject != null;
        }

        public static bool TryGetNetObjectFromAmqpObject(object amqpObject, MappingType mappingType, out object netObject)
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
                    if (amqpObject is AmqpSymbol)
                    {
                        netObject = ((AmqpSymbol)amqpObject).Value;
                    }
                    else if (amqpObject is ArraySegment<byte>)
                    {
                        ArraySegment<byte> binValue = (ArraySegment<byte>)amqpObject;
                        if (binValue.Count == binValue.Array.Length)
                        {
                            netObject = binValue.Array;
                        }
                        else
                        {
                            byte[] buffer = new byte[binValue.Count];
                            Buffer.BlockCopy(binValue.Array, binValue.Offset, buffer, 0, binValue.Count);
                            netObject = buffer;
                        }
                    }
                    else if (amqpObject is DescribedType)
                    {
                        DescribedType describedType = (DescribedType)amqpObject;
                        if (describedType.Descriptor is AmqpSymbol)
                        {
                            AmqpSymbol symbol = (AmqpSymbol)describedType.Descriptor;
                            if (symbol.Equals(UriName))
                            {
                                netObject = new Uri((string)describedType.Value);
                            }
                            else if (symbol.Equals(TimeSpanName))
                            {
                                netObject = new TimeSpan((long)describedType.Value);
                            }
                            else if (symbol.Equals(DateTimeOffsetName))
                            {
                                netObject = new DateTimeOffset(new DateTime((long)describedType.Value, DateTimeKind.Utc));
                            }
                        }
                    }
                    else if (mappingType == MappingType.ApplicationProperty)
                    {
                        // TODO: throw FxTrace.Exception.AsError(new SerializationException(SRClient.FailedToSerializeUnsupportedType(amqpObject.GetType().FullName)));
                        throw new SerializationException("netObject.GetType().FullName");
                    }
                    else if (amqpObject is AmqpMap)
                    {
                        AmqpMap map = (AmqpMap)amqpObject;
                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
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
                default:
                    break;
            }

            return netObject != null;
        }

        public static AmqpMap GetRuleDescriptionMap(RuleDescription description)
        {
            AmqpMap ruleDescriptionMap = new AmqpMap();
            if (description.Filter is SqlFilter)
            {
                AmqpMap filterMap = GetSqlFilterMap(description.Filter as SqlFilter);
                ruleDescriptionMap[ManagementConstants.Properties.SqlFilter] = filterMap;
            }
            else if (description.Filter is CorrelationFilter)
            {
                AmqpMap correlationFilterMap = GetCorrelationFilterMap(description.Filter as CorrelationFilter);
                ruleDescriptionMap[ManagementConstants.Properties.CorrelationFilter] = correlationFilterMap;
            }
            else
            {
                throw new NotSupportedException(
                    Resources.RuleFilterNotSupported.FormatForUser(
                        description.Filter.GetType(),
                        nameof(SqlFilter),
                        nameof(CorrelationFilter)));
            }

            AmqpMap amqpAction = GetRuleActionMap(description.Action as SqlRuleAction);
            ruleDescriptionMap[ManagementConstants.Properties.SqlRuleAction] = amqpAction;

            return ruleDescriptionMap;
        }

        public static ArraySegment<byte> StreamToBytes(Stream stream)
        {
            MemoryStream memoryStream = new MemoryStream();
            int bytesRead;
            byte[] readBuffer = new byte[512];
            while ((bytesRead = stream.Read(readBuffer, 0, readBuffer.Length)) > 0)
            {
                memoryStream.Write(readBuffer, 0, bytesRead);
            }

            ArraySegment<byte> buffer = new ArraySegment<byte>(memoryStream.ToArray());

            memoryStream.Dispose();
            return buffer;
        }

        private static Stream GetMessageBodyStream(AmqpMessage message)
        {
            if ((message.BodyType & SectionFlag.Data) != 0 &&
                message.DataBody != null)
            {
                List<ArraySegment<byte>> dataSegments = new List<ArraySegment<byte>>();
                foreach (Data data in message.DataBody)
                {
                    dataSegments.Add((ArraySegment<byte>)data.Value);
                }

                return new BufferListStream(dataSegments.ToArray());
            }

            return null;
        }

        private static Data ToData(AmqpMessage message)
        {
            ArraySegment<byte>[] payload = message.GetPayload();
            BufferListStream buffer = new BufferListStream(payload);
            ArraySegment<byte> value = buffer.ReadBytes((int)buffer.Length);
            return new Data { Value = value };
        }

        static AmqpMap GetSqlFilterMap(SqlFilter sqlFilter)
        {
            AmqpMap amqpFilterMap = new AmqpMap
            {
                [ManagementConstants.Properties.Expression] = sqlFilter.SqlExpression
            };
            return amqpFilterMap;
        }

        static AmqpMap GetCorrelationFilterMap(CorrelationFilter correlationFilter)
        {
            AmqpMap correlationFilterMap = new AmqpMap
            {
                [ManagementConstants.Properties.CorrelationId] = correlationFilter.CorrelationId,
                [ManagementConstants.Properties.MessageId] = correlationFilter.MessageId,
                [ManagementConstants.Properties.To] = correlationFilter.To,
                [ManagementConstants.Properties.ReplyTo] = correlationFilter.ReplyTo,
                [ManagementConstants.Properties.Label] = correlationFilter.Label,
                [ManagementConstants.Properties.SessionId] = correlationFilter.SessionId,
                [ManagementConstants.Properties.ReplyToSessionId] = correlationFilter.ReplyToSessionId,
                [ManagementConstants.Properties.ContentType] = correlationFilter.ContentType
            };

            var propertiesMap = new AmqpMap();
            foreach (var property in correlationFilter.Properties)
            {
                propertiesMap[new MapKey(property.Key)] = property.Value;
            }

            correlationFilterMap[ManagementConstants.Properties.CorrelationFilterProperties] = propertiesMap;

            return correlationFilterMap;
        }

        static AmqpMap GetRuleActionMap(SqlRuleAction sqlRuleAction)
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