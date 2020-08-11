// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using Azure.Amqp;
    using Azure.Amqp.Encoding;
    using Azure.Amqp.Framing;
    using Framing;
    using Primitives;
    using SBMessage = Message;

    static class AmqpMessageConverter
    {
        const string EnqueuedTimeUtcName = "x-opt-enqueued-time";
        const string ScheduledEnqueueTimeUtcName = "x-opt-scheduled-enqueue-time";
        const string SequenceNumberName = "x-opt-sequence-number";
        const string EnqueueSequenceNumberName = "x-opt-enqueue-sequence-number";
        const string LockedUntilName = "x-opt-locked-until";
        const string PublisherName = "x-opt-publisher";
        const string PartitionKeyName = "x-opt-partition-key";
        const string PartitionIdName = "x-opt-partition-id";
        const string ViaPartitionKeyName = "x-opt-via-partition-key";
        const string DeadLetterSourceName = "x-opt-deadletter-source";
        const string TimeSpanName = AmqpConstants.Vendor + ":timespan";
        const string UriName = AmqpConstants.Vendor + ":uri";
        const string DateTimeOffsetName = AmqpConstants.Vendor + ":datetime-offset";
        const int GuidSize = 16;

        public static AmqpMessage BatchSBMessagesAsAmqpMessage(IEnumerable<SBMessage> sbMessages)
        {
            if (sbMessages == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(sbMessages));
            }

            AmqpMessage amqpMessage;
            AmqpMessage firstAmqpMessage = null;
            SBMessage firstMessage = null;
            List<Data> dataList = null;
            var messageCount = 0;
            foreach (var sbMessage in sbMessages)
            {
                messageCount++;

                amqpMessage = AmqpMessageConverter.SBMessageToAmqpMessage(sbMessage);
                if (firstAmqpMessage == null)
                {
                    firstAmqpMessage = amqpMessage;
                    firstMessage = sbMessage;
                    continue;
                }

                if (dataList == null)
                {
                    dataList = new List<Data> { ToData(firstAmqpMessage) };
                }

                dataList.Add(ToData(amqpMessage));
            }

            if (messageCount == 1 && firstAmqpMessage != null)
            {
                firstAmqpMessage.Batchable = true;
                return firstAmqpMessage;
            }

            amqpMessage = AmqpMessage.Create(dataList);
            amqpMessage.MessageFormat = AmqpConstants.AmqpBatchedMessageFormat;

            if (firstMessage.MessageId != null)
            {
                amqpMessage.Properties.MessageId = firstMessage.MessageId;
            }
            if (firstMessage.SessionId != null)
            {
                amqpMessage.Properties.GroupId = firstMessage.SessionId;
            }

            if (firstMessage.PartitionKey != null)
            {
                amqpMessage.MessageAnnotations.Map[AmqpMessageConverter.PartitionKeyName] =
                    firstMessage.PartitionKey;
            }

            if (firstMessage.ViaPartitionKey != null)
            {
                amqpMessage.MessageAnnotations.Map[AmqpMessageConverter.ViaPartitionKeyName] =
                    firstMessage.ViaPartitionKey;
            }

            amqpMessage.Batchable = true;
            return amqpMessage;
        }

        public static AmqpMessage SBMessageToAmqpMessage(SBMessage sbMessage)
        {
            var amqpMessage = sbMessage.Body == null ? AmqpMessage.Create() : AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(sbMessage.Body) });

            amqpMessage.Properties.MessageId = sbMessage.MessageId;
            amqpMessage.Properties.CorrelationId = sbMessage.CorrelationId;
            amqpMessage.Properties.ContentType = sbMessage.ContentType;
            amqpMessage.Properties.Subject = sbMessage.Label;
            amqpMessage.Properties.To = sbMessage.To;
            amqpMessage.Properties.ReplyTo = sbMessage.ReplyTo;
            amqpMessage.Properties.GroupId = sbMessage.SessionId;
            amqpMessage.Properties.ReplyToGroupId = sbMessage.ReplyToSessionId;

            if (sbMessage.TimeToLive != TimeSpan.MaxValue)
            {
                amqpMessage.Header.Ttl = sbMessage.TimeToLive.TotalMilliseconds < UInt32.MaxValue ? (uint)sbMessage.TimeToLive.TotalMilliseconds : UInt32.MaxValue;
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

            if ((sbMessage.ScheduledEnqueueTimeUtc != null) && sbMessage.ScheduledEnqueueTimeUtc > DateTime.MinValue)
            {
                amqpMessage.MessageAnnotations.Map.Add(ScheduledEnqueueTimeUtcName, sbMessage.ScheduledEnqueueTimeUtc);
            }

            if (sbMessage.PartitionKey != null)
            {
                amqpMessage.MessageAnnotations.Map.Add(PartitionKeyName, sbMessage.PartitionKey);
            }

            if (sbMessage.ViaPartitionKey != null)
            {
                amqpMessage.MessageAnnotations.Map.Add(ViaPartitionKeyName, sbMessage.ViaPartitionKey);
            }

            if (sbMessage.UserProperties != null && sbMessage.UserProperties.Count > 0)
            {
                if (amqpMessage.ApplicationProperties == null)
                {
                    amqpMessage.ApplicationProperties = new ApplicationProperties();
                }

                foreach (var pair in sbMessage.UserProperties)
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

        public static SBMessage AmqpMessageToSBMessage(AmqpMessage amqpMessage, bool isPeeked = false)
        {
            if (amqpMessage == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(amqpMessage));
            }

            SBMessage sbMessage;

            if ((amqpMessage.BodyType & SectionFlag.AmqpValue) != 0
                && amqpMessage.ValueBody.Value != null)
            {
                sbMessage = new SBMessage();

                if (TryGetNetObjectFromAmqpObject(amqpMessage.ValueBody.Value, MappingType.MessageBody, out var dotNetObject))
                {
                    sbMessage.SystemProperties.BodyObject = dotNetObject;
                }
                else
                {
                    sbMessage.SystemProperties.BodyObject = amqpMessage.ValueBody.Value;
                }
            }
            else if ((amqpMessage.BodyType & SectionFlag.Data) != 0
                && amqpMessage.DataBody != null)
            {
                var dataSegments = new List<byte>();
                foreach (var data in amqpMessage.DataBody)
                {
                    if (data.Value is byte[] byteArrayValue)
                    {
                        dataSegments.AddRange(byteArrayValue);
                    }
                    else if (data.Value is ArraySegment<byte> arraySegmentValue)
                    {
                        byte[] byteArray;
                        if (arraySegmentValue.Count == arraySegmentValue.Array.Length)
                        {
                            byteArray = arraySegmentValue.Array;
                        }
                        else
                        {
                            byteArray = new byte[arraySegmentValue.Count];
                            Array.ConstrainedCopy(arraySegmentValue.Array, arraySegmentValue.Offset, byteArray, 0, arraySegmentValue.Count);
                        }
                        dataSegments.AddRange(byteArray);
                    }
                }
                sbMessage = new SBMessage(dataSegments.ToArray());
            }
            else
            {
                sbMessage = new SBMessage();
            }

            var sections = amqpMessage.Sections;
            if ((sections & SectionFlag.Header) != 0)
            {
                if (amqpMessage.Header.Ttl != null)
                {
                    sbMessage.TimeToLive = TimeSpan.FromMilliseconds(amqpMessage.Header.Ttl.Value);
                }

                if (amqpMessage.Header.DeliveryCount != null)
                {
                    sbMessage.SystemProperties.DeliveryCount = isPeeked ? (int)(amqpMessage.Header.DeliveryCount.Value) : (int)(amqpMessage.Header.DeliveryCount.Value + 1);
                }
            }

            if ((sections & SectionFlag.Properties) != 0)
            {
                if (amqpMessage.Properties.MessageId != null)
                {
                    sbMessage.MessageId = amqpMessage.Properties.MessageId.ToString();
                }

                if (amqpMessage.Properties.CorrelationId != null)
                {
                    sbMessage.CorrelationId = amqpMessage.Properties.CorrelationId.ToString();
                }

                if (amqpMessage.Properties.ContentType.Value != null)
                {
                    sbMessage.ContentType = amqpMessage.Properties.ContentType.Value;
                }

                if (amqpMessage.Properties.Subject != null)
                {
                    sbMessage.Label = amqpMessage.Properties.Subject;
                }

                if (amqpMessage.Properties.To != null)
                {
                    sbMessage.To = amqpMessage.Properties.To.ToString();
                }

                if (amqpMessage.Properties.ReplyTo != null)
                {
                    sbMessage.ReplyTo = amqpMessage.Properties.ReplyTo.ToString();
                }

                if (amqpMessage.Properties.GroupId != null)
                {
                    sbMessage.SessionId = amqpMessage.Properties.GroupId;
                }

                if (amqpMessage.Properties.ReplyToGroupId != null)
                {
                    sbMessage.ReplyToSessionId = amqpMessage.Properties.ReplyToGroupId;
                }

                if (amqpMessage.Properties.CreationTime.HasValue && amqpMessage.Properties.AbsoluteExpiryTime.HasValue)
                {
                    // Overwrite TimeToLive from AbsoluteExpiryTime
                    sbMessage.TimeToLive = amqpMessage.Properties.AbsoluteExpiryTime.Value - amqpMessage.Properties.CreationTime.Value;
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
                        sbMessage.UserProperties[pair.Key.ToString()] = netObject;
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
                        case EnqueuedTimeUtcName:
                            sbMessage.SystemProperties.EnqueuedTimeUtc = (DateTime)pair.Value;
                            break;
                        case ScheduledEnqueueTimeUtcName:
                            sbMessage.ScheduledEnqueueTimeUtc = (DateTime)pair.Value;
                            break;
                        case SequenceNumberName:
                            sbMessage.SystemProperties.SequenceNumber = (long)pair.Value;
                            break;
                        case EnqueueSequenceNumberName:
                            sbMessage.SystemProperties.EnqueuedSequenceNumber = (long)pair.Value;
                            break;
                        case LockedUntilName:
                            sbMessage.SystemProperties.LockedUntilUtc = (DateTime)pair.Value;
                            break;
                        case PartitionKeyName:
                            sbMessage.PartitionKey = (string)pair.Value;
                            break;
                        case PartitionIdName:
                            sbMessage.SystemProperties.PartitionId = (short)pair.Value;
                            break;
                        case ViaPartitionKeyName:
                            sbMessage.ViaPartitionKey = (string)pair.Value;
                            break;
                        case DeadLetterSourceName:
                            sbMessage.SystemProperties.DeadLetterSource = (string)pair.Value;
                            break;
                        default:
                            if (TryGetNetObjectFromAmqpObject(pair.Value, MappingType.ApplicationProperty, out var netObject))
                            {
                                sbMessage.UserProperties[key] = netObject;
                            }
                            break;
                    }
                }
            }

            if (amqpMessage.DeliveryTag.Count == GuidSize)
            {
                var guidBuffer = new byte[GuidSize];
                Buffer.BlockCopy(amqpMessage.DeliveryTag.Array, amqpMessage.DeliveryTag.Offset, guidBuffer, 0, GuidSize);
                sbMessage.SystemProperties.LockTokenGuid = new Guid(guidBuffer);
            }

            amqpMessage.Dispose();

            return sbMessage;
        }

        public static AmqpMap GetRuleDescriptionMap(RuleDescription description)
        {
            var ruleDescriptionMap = new AmqpMap();

            switch (description.Filter)
            {
                case SqlFilter sqlFilter:
                    var filterMap = GetSqlFilterMap(sqlFilter);
                    ruleDescriptionMap[ManagementConstants.Properties.SqlFilter] = filterMap;
                    break;
                case CorrelationFilter correlationFilter:
                    var correlationFilterMap = GetCorrelationFilterMap(correlationFilter);
                    ruleDescriptionMap[ManagementConstants.Properties.CorrelationFilter] = correlationFilterMap;
                    break;
                default:
                    throw new NotSupportedException(
                        Resources.RuleFilterNotSupported.FormatForUser(
                            description.Filter.GetType(),
                            nameof(SqlFilter),
                            nameof(CorrelationFilter)));
            }

            var amqpAction = GetRuleActionMap(description.Action as SqlRuleAction);
            ruleDescriptionMap[ManagementConstants.Properties.SqlRuleAction] = amqpAction;
            ruleDescriptionMap[ManagementConstants.Properties.RuleName] = description.Name;

            return ruleDescriptionMap;
        }

        public static RuleDescription GetRuleDescription(AmqpRuleDescriptionCodec amqpDescription)
        {
            var filter = GetFilter(amqpDescription.Filter);
            var ruleAction = GetRuleAction(amqpDescription.Action);

            var ruleDescription = new RuleDescription(amqpDescription.RuleName, filter)
            {
                Action = ruleAction
            };

            return ruleDescription;
        }

        public static Filter GetFilter(AmqpFilterCodec amqpFilter)
        {
            Filter filter;

            switch (amqpFilter.DescriptorCode)
            {
                case AmqpSqlFilterCodec.Code:
                    var amqpSqlFilter = (AmqpSqlFilterCodec)amqpFilter;
                    filter = new SqlFilter(amqpSqlFilter.Expression);
                    break;

                case AmqpTrueFilterCodec.Code:
                    filter = new TrueFilter();
                    break;

                case AmqpFalseFilterCodec.Code:
                    filter = new FalseFilter();
                    break;

                case AmqpCorrelationFilterCodec.Code:
                    var amqpCorrelationFilter = (AmqpCorrelationFilterCodec)amqpFilter;
                    var correlationFilter = new CorrelationFilter
                    {
                        CorrelationId = amqpCorrelationFilter.CorrelationId,
                        MessageId = amqpCorrelationFilter.MessageId,
                        To = amqpCorrelationFilter.To,
                        ReplyTo = amqpCorrelationFilter.ReplyTo,
                        Label = amqpCorrelationFilter.Label,
                        SessionId = amqpCorrelationFilter.SessionId,
                        ReplyToSessionId = amqpCorrelationFilter.ReplyToSessionId,
                        ContentType = amqpCorrelationFilter.ContentType
                    };

                    foreach (var property in amqpCorrelationFilter.Properties)
                    {
                        correlationFilter.Properties.Add(property.Key.Key.ToString(), property.Value);
                    }

                    filter = correlationFilter;
                    break;

                default:
                    throw new NotSupportedException($"Unknown filter descriptor code: {amqpFilter.DescriptorCode}");
            }

            return filter;
        }

        static RuleAction GetRuleAction(AmqpRuleActionCodec amqpAction)
        {
            RuleAction action;

            if (amqpAction.DescriptorCode == AmqpEmptyRuleActionCodec.Code)
            {
                action = null;
            }
            else if (amqpAction.DescriptorCode == AmqpSqlRuleActionCodec.Code)
            {
                var amqpSqlAction = (AmqpSqlRuleActionCodec)amqpAction;
                var sqlAction = new SqlRuleAction(amqpSqlAction.SqlExpression);

                action = sqlAction;
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
                    amqpObject = new DescribedType((AmqpSymbol)UriName, ((Uri)netObject).AbsoluteUri);
                    break;
                case PropertyValueType.DateTimeOffset:
                    amqpObject = new DescribedType((AmqpSymbol)DateTimeOffsetName, ((DateTimeOffset)netObject).UtcTicks);
                    break;
                case PropertyValueType.TimeSpan:
                    amqpObject = new DescribedType((AmqpSymbol)TimeSpanName, ((TimeSpan)netObject).Ticks);
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
                        throw Fx.Exception.AsError(new SerializationException(Resources.FailedToSerializeUnsupportedType.FormatForUser(netObject.GetType().FullName)));
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

        static bool TryGetNetObjectFromAmqpObject(object amqpObject, MappingType mappingType, out object netObject)
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
                            if (amqpSymbol.Equals((AmqpSymbol)UriName))
                            {
                                netObject = new Uri((string)amqpObjectAsDescribedType.Value);
                            }
                            else if (amqpSymbol.Equals((AmqpSymbol)TimeSpanName))
                            {
                                netObject = new TimeSpan((long)amqpObjectAsDescribedType.Value);
                            }
                            else if (amqpSymbol.Equals((AmqpSymbol)DateTimeOffsetName))
                            {
                                netObject = new DateTimeOffset(new DateTime((long)amqpObjectAsDescribedType.Value, DateTimeKind.Utc));
                            }
                        }
                    }
                    else if (mappingType == MappingType.ApplicationProperty)
                    {
                        throw Fx.Exception.AsError(new SerializationException(Resources.FailedToSerializeUnsupportedType.FormatForUser(amqpObject.GetType().FullName)));
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

        static ArraySegment<byte> StreamToBytes(Stream stream)
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

        static AmqpMap GetSqlFilterMap(SqlFilter sqlFilter)
        {
            var amqpFilterMap = new AmqpMap
            {
                [ManagementConstants.Properties.Expression] = sqlFilter.SqlExpression
            };
            return amqpFilterMap;
        }

        static AmqpMap GetCorrelationFilterMap(CorrelationFilter correlationFilter)
        {
            var correlationFilterMap = new AmqpMap
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