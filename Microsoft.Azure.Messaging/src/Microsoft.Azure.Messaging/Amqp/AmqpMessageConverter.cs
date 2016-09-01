// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;

namespace Microsoft.Azure.Messaging.Amqp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Runtime.Serialization;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Encoding;
    using Microsoft.Azure.Amqp.Framing;

    static class AmqpMessageConverter
    {
        const int GuidSize = 16;
        public const string EnqueuedTimeUtcName = "x-opt-enqueued-time";
        public const string ScheduledEnqueueTimeUtcName = "x-opt-scheduled-enqueue-time";
        public const string SequenceNumberName = "x-opt-sequence-number";
        public const string OffsetName = "x-opt-offset";
        public const string LockTokenName = "x-opt-lock-token";
        public const string LockedUntilName = "x-opt-locked-until";
        public const string PublisherName = "x-opt-publisher";
        public const string PartitionKeyName = "x-opt-partition-key";
        public const string PartitionIdName = "x-opt-partition-id";
        public const string PrefilteredMessageHeadersName = "x-opt-prefiltered-headers";
        public const string PrefilteredMessagePropertiesName = "x-opt-prefiltered-properties";
        public const string DeadLetterSourceName = "x-opt-deadletter-source";
        public const string TransferSourceName = "x-opt-transfer-source";
        public const string TransferDestinationName = "x-opt-transfer-destination";
        public const string TransferResourceName = "x-opt-transfer-resource";
        public const string TransferSessionName = "x-opt-transfer-session";
        public const string TransferSequenceNumberName = "x-opt-transfer-sn";
        public const string TransferHopCountName = "x-opt-transfer-hop-count";
        public const string TimeSpanName = AmqpConstants.Vendor + ":timespan";
        public const string UriName = AmqpConstants.Vendor + ":uri";
        public const string DateTimeOffsetName = AmqpConstants.Vendor + ":datetime-offset";


        public static AmqpMessage BrokeredMessagesToAmqpMessage(IEnumerable<BrokeredMessage> brokeredMessages, bool batchable)
        {
            AmqpMessage amqpMessage;
            if (brokeredMessages.Count() == 1)
            {
                BrokeredMessage singleBrokeredMessage = brokeredMessages.Single();
                //TODO: ProcessFaultInjectionInfo(singleBrokeredMessage);
                amqpMessage = AmqpMessageConverter.ClientGetMessage(singleBrokeredMessage);
            }
            else
            {
                var dataList = new List<Data>();
                foreach (BrokeredMessage brokeredMessage in brokeredMessages)
                {
                    //TODO: ProcessFaultInjectionInfo(brokeredMessage);
                    AmqpMessage amqpMessageItem = AmqpMessageConverter.ClientGetMessage(brokeredMessage);
                    ArraySegment<byte>[] payload = amqpMessageItem.GetPayload();
                    BufferListStream buffer = new BufferListStream(payload);
                    ArraySegment<byte> value = buffer.ReadBytes((int)buffer.Length);
                    dataList.Add(new Data() { Value = value });
                }

                var firstBrokeredMessage = brokeredMessages.First();

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
                    amqpMessage.MessageAnnotations.Map[AmqpMessageConverter.PartitionKeyName] = firstBrokeredMessage.PartitionKey;
                }
            }

            amqpMessage.Batchable = batchable;
            return amqpMessage;
        }


        public static void UpdateBrokeredMessageHeaderAndProperties(AmqpMessage amqpMessage, BrokeredMessage message)
        {
            SectionFlag sections = amqpMessage.Sections;
            if ((sections & SectionFlag.Header) != 0)
            {
                if (amqpMessage.Header.Ttl != null)
                {
                    message.TimeToLive = TimeSpan.FromMilliseconds(amqpMessage.Header.Ttl.Value);
                }
            }

            if ((sections & SectionFlag.Properties) != 0)
            {
                if (amqpMessage.Properties.MessageId != null)
                {
                    message.MessageId = amqpMessage.Properties.MessageId.ToString();
                }

                if (amqpMessage.Properties.CorrelationId != null)
                {
                    message.CorrelationId = amqpMessage.Properties.CorrelationId.ToString();
                }

                if (amqpMessage.Properties.ContentType.Value != null)
                {
                    message.ContentType = amqpMessage.Properties.ContentType.Value;
                }

                if (amqpMessage.Properties.Subject != null)
                {
                    message.Label = amqpMessage.Properties.Subject;
                }

                if (amqpMessage.Properties.To != null)
                {
                    message.To = amqpMessage.Properties.To.ToString();
                }

                if (amqpMessage.Properties.ReplyTo != null)
                {
                    message.ReplyTo = amqpMessage.Properties.ReplyTo.ToString();
                }

                if (amqpMessage.Properties.GroupId != null)
                {
                    message.CopySessionId(amqpMessage.Properties.GroupId);
                }

                if (amqpMessage.Properties.ReplyToGroupId != null)
                {
                    message.ReplyToSessionId = amqpMessage.Properties.ReplyToGroupId;
                }
            }

            if ((sections & SectionFlag.MessageAnnotations) != 0)
            {
                DateTime scheduledEnqueueTime;
                if (amqpMessage.MessageAnnotations.Map.TryGetValue<DateTime>(ScheduledEnqueueTimeUtcName, out scheduledEnqueueTime))
                {
                    message.ScheduledEnqueueTimeUtc = scheduledEnqueueTime;
                }

                string publisher;
                if (amqpMessage.MessageAnnotations.Map.TryGetValue<string>(PublisherName, out publisher))
                {
                    message.Publisher = publisher;
                }

                string partitionKey;
                if (amqpMessage.MessageAnnotations.Map.TryGetValue<string>(PartitionKeyName, out partitionKey))
                {
                    message.CopyPartitionKey(partitionKey);
                }
            }

            if ((sections & SectionFlag.ApplicationProperties) != 0)
            {
                foreach (KeyValuePair<MapKey, object> pair in amqpMessage.ApplicationProperties.Map)
                {
                    object netObject = null;
                    if (TryGetNetObjectFromAmqpObject(pair.Value, MappingType.ApplicationProperty, out netObject))
                    {
                        message.InternalProperties[pair.Key.ToString()] = netObject;
                    }
                }
            }
        }

        public static void UpdateAmqpMessageHeadersAndProperties(AmqpMessage message, BrokeredMessage brokeredMessage, bool amqpClient, bool stampPartitionIdToSequenceNumber)
        {
            BrokeredMessage.MessageMembers messageMembers = brokeredMessage.InitializedMembers;
            if ((messageMembers & BrokeredMessage.MessageMembers.DeliveryCount) != 0)
            {
                message.Header.DeliveryCount = (uint)(brokeredMessage.DeliveryCount - (amqpClient ? 1 : 0));
            }

            if ((messageMembers & BrokeredMessage.MessageMembers.TimeToLive) != 0 &&
                brokeredMessage.TimeToLive != TimeSpan.MaxValue)
            {
                message.Header.Ttl = (uint)brokeredMessage.TimeToLive.TotalMilliseconds;
            }

            if ((messageMembers & BrokeredMessage.MessageMembers.EnqueuedTimeUtc) != 0)
            {
                message.MessageAnnotations.Map[EnqueuedTimeUtcName] = brokeredMessage.EnqueuedTimeUtc;
            }

            if ((messageMembers & BrokeredMessage.MessageMembers.SequenceNumber) != 0)
            {
                //TODO: message.MessageAnnotations.Map[SequenceNumberName] = stampPartitionIdToSequenceNumber ? ScaledEntityPartitionResolver.StampPartitionIntoSequenceNumber(brokeredMessage.PartitionId, brokeredMessage.SequenceNumber) : brokeredMessage.SequenceNumber;
                message.MessageAnnotations.Map[SequenceNumberName] = brokeredMessage.SequenceNumber;
            }

            if ((messageMembers & BrokeredMessage.MessageMembers.PartitionId) != 0)
            {
                message.MessageAnnotations.Map[PartitionIdName] = brokeredMessage.PartitionId;
            }

            if ((messageMembers & BrokeredMessage.MessageMembers.PartitionKey) != 0)
            {
                // Only set partition key if session id is not set
                message.MessageAnnotations.Map[PartitionKeyName] = brokeredMessage.PartitionKey;
            }

            if (amqpClient && (messageMembers & BrokeredMessage.MessageMembers.LockedUntilUtc) != 0)
            {
                message.MessageAnnotations.Map[LockedUntilName] = brokeredMessage.LockedUntilUtc;
            }

            if (amqpClient && (messageMembers & BrokeredMessage.MessageMembers.Publisher) != 0)
            {
                message.MessageAnnotations.Map[PublisherName] = brokeredMessage.Publisher;
            }

            if (amqpClient && (messageMembers & BrokeredMessage.MessageMembers.DeadLetterSource) != 0)
            {
                message.MessageAnnotations.Map[DeadLetterSourceName] = brokeredMessage.DeadLetterSource;
            }

            if (brokeredMessage.ArePropertiesModifiedByBroker && brokeredMessage.Properties.Count > 0)
            {
                if (message.ApplicationProperties == null)
                {
                    message.ApplicationProperties = new ApplicationProperties();
                }

                foreach (var pair in brokeredMessage.Properties)
                {
                    object amqpObject = null;
                    if (TryGetAmqpObjectFromNetObject(pair.Value, MappingType.ApplicationProperty, out amqpObject))
                    {
                        message.ApplicationProperties.Map[pair.Key] = amqpObject;
                    }
                }
            }
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
                object netObject = null;
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

            brokeredMessage.MessageFormat = BrokeredMessageFormat.Amqp;
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
                    object netObject = null;
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
                            object netObject = null;
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
                object amqpObject = null;
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
                    //TODO:throw new InvalidOperationException(SRClient.CannotSerializeMessageWithPartiallyConsumedBodyStream);
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

        static Stream GetMessageBodyStream(AmqpMessage message)
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

        static void AddIfTrue(IDictionary<string, object> dictionary, Properties properties, Func<Properties, bool> condition, string key, Func<Properties, object> getValueFunc)
        {
            if (condition(properties))
            {
                dictionary.Add(key, getValueFunc(properties));
            }
        }

        public static bool TryGetAmqpObjectFromNetObject(object netObject, MappingType mappingType, out object amqpObject)
        {
            amqpObject = null;
            if (netObject == null)
            {
                return false;
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
                        //TODO: throw FxTrace.Exception.AsError(new SerializationException(SRClient.FailedToSerializeUnsupportedType(netObject.GetType().FullName)));
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
                return false;
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
                            if (symbol.Equals((AmqpSymbol)UriName))
                            {
                                netObject = new Uri((string)describedType.Value);
                            }
                            else if (symbol.Equals((AmqpSymbol)TimeSpanName))
                            {
                                netObject = new TimeSpan((long)describedType.Value);
                            }
                            else if (symbol.Equals((AmqpSymbol)DateTimeOffsetName))
                            {
                                netObject = new DateTimeOffset(new DateTime((long)describedType.Value, DateTimeKind.Utc));
                            }
                        }
                    }
                    else if (mappingType == MappingType.ApplicationProperty)
                    {
                        //TODO: throw FxTrace.Exception.AsError(new SerializationException(SRClient.FailedToSerializeUnsupportedType(amqpObject.GetType().FullName)));
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

        public static ArraySegment<byte> StreamToBytes(Stream stream)
        {
            MemoryStream memoryStream = new MemoryStream(512);
            stream.CopyTo(memoryStream, 512);

            // TryGetBuffer will always succeed unless we provide the byte[] when calling MemoryStream..ctor(byte[])
            ArraySegment<byte> buffer;
            if (!memoryStream.TryGetBuffer(out buffer))
            {
                buffer = new ArraySegment<byte>(memoryStream.ToArray());
            }

            return buffer;
        }
    }
}
