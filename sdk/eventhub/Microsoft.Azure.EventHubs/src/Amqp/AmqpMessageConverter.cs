// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Amqp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Encoding;
    using Microsoft.Azure.Amqp.Framing;
    using Microsoft.Azure.EventHubs.Primitives;

    static class AmqpMessageConverter
    {
        const SectionFlag ClientAmqpPropsSetOnSendToEventHub =
            SectionFlag.ApplicationProperties |
            SectionFlag.MessageAnnotations |
            SectionFlag.DeliveryAnnotations |
            SectionFlag.Properties;

        public const string TimeSpanName = AmqpConstants.Vendor + ":timespan";
        public const string UriName = AmqpConstants.Vendor + ":uri";
        public const string DateTimeOffsetName = AmqpConstants.Vendor + ":datetime-offset";

        public static EventData AmqpMessageToEventData(AmqpMessage amqpMessage)
        {
            Guard.ArgumentNotNull(nameof(amqpMessage), amqpMessage);
            EventData eventData = new EventData(StreamToBytes(amqpMessage.BodyStream));
            UpdateEventDataHeaderAndProperties(amqpMessage, eventData);
            return eventData;
        }

        public static AmqpMessage EventDatasToAmqpMessage(IEnumerable<EventData> eventDatas, string partitionKey)
        {
            Guard.ArgumentNotNull(nameof(eventDatas), eventDatas);

            AmqpMessage returnMessage = null;
            var dataCount = eventDatas.Count();
            if (dataCount > 1)
            {
                IList<Data> bodyList = new List<Data>();
                EventData firstEvent = null;
                foreach (EventData data in eventDatas)
                {
                    if (firstEvent == null)
                    {
                        firstEvent = data;
                    }

                    // Create AMQP message if not created yet. We might have created AmqpMessage while building the EventDataBatch. 
                    AmqpMessage amqpMessage = data.AmqpMessage;
                    data.AmqpMessage = null; // Retry on the same message should create a new AmqpMessage
                    if (amqpMessage == null)
                    {
                        amqpMessage = EventDataToAmqpMessage(data);
                    }

                    UpdateAmqpMessagePartitionKey(amqpMessage, partitionKey);
                    amqpMessage.Batchable = true;

                    if ((amqpMessage.Sections & ClientAmqpPropsSetOnSendToEventHub) == 0 && data.Body.Array == null)
                    {
                        throw new InvalidOperationException(Resources.CannotSendAnEmptyEvent.FormatForUser(data.GetType().Name));
                    }

                    ArraySegment<byte> buffer = StreamToBytes(amqpMessage.ToStream());
                    bodyList.Add(new Data { Value = buffer });
                }

                returnMessage = AmqpMessage.Create(bodyList);
                returnMessage.MessageFormat = AmqpConstants.AmqpBatchedMessageFormat;
                UpdateAmqpMessageHeadersAndProperties(returnMessage, null, firstEvent, copyUserProperties: false);
            }
            else if (dataCount == 1) // ??? can't be null
            {
                var data = eventDatas.First();

                // Create AMQP message if not created yet. We might have created AmqpMessage while building the EventDataBatch. 
                returnMessage = data.AmqpMessage;
                data.AmqpMessage = null; // Retry on the same message should create a new AmqpMessage
                if (returnMessage == null)
                {
                    returnMessage = EventDataToAmqpMessage(data);
                }

                if ((returnMessage.Sections & ClientAmqpPropsSetOnSendToEventHub) == 0 && data.Body.Array == null)
                {
                    throw new InvalidOperationException(Resources.CannotSendAnEmptyEvent.FormatForUser(data.GetType().Name));
                }
            }

            returnMessage.Batchable = true;
            UpdateAmqpMessagePartitionKey(returnMessage, partitionKey);

            return returnMessage;
        }

        public static AmqpMessage EventDataToAmqpMessage(EventData eventData)
        {
            AmqpMessage amqpMessage = AmqpMessage.Create(new Data { Value = eventData.Body });
            UpdateAmqpMessageHeadersAndProperties(amqpMessage, null, eventData, true);

            return amqpMessage;
        }

        public static void UpdateAmqpMessagePartitionKey(AmqpMessage message, string partitionKey)
        {
            if (partitionKey != null)
            {
                message.MessageAnnotations.Map[ClientConstants.PartitionKeyName] = partitionKey;
            }
        }

        static void UpdateAmqpMessageHeadersAndProperties(
            AmqpMessage message,
            string publisher,
            EventData eventData,
            bool copyUserProperties = true)
        {
            if (!string.IsNullOrEmpty(publisher))
            {
                message.MessageAnnotations.Map[ClientConstants.PublisherName] = publisher;
            }

            if (copyUserProperties && eventData.Properties != null && eventData.Properties.Count > 0)
            {
                if (message.ApplicationProperties == null)
                {
                    message.ApplicationProperties = new ApplicationProperties();
                }

                foreach (var pair in eventData.Properties)
                {
                    object amqpObject;
                    if (TryGetAmqpObjectFromNetObject(pair.Value, MappingType.ApplicationProperty, out amqpObject))
                    {
                        message.ApplicationProperties.Map[pair.Key] = amqpObject;
                    }
                }
            }

            if (eventData.ContentType != null)
            {
                message.Properties.ContentType = eventData.ContentType;
            }
        }

        static void UpdateEventDataHeaderAndProperties(AmqpMessage amqpMessage, EventData data)
        {
            SectionFlag sections = amqpMessage.Sections;

            if ((sections & SectionFlag.MessageAnnotations) != 0)
            {
                if (data.SystemProperties == null)
                {
                    data.SystemProperties = new EventData.SystemPropertiesCollection();
                }

                foreach (var keyValuePair in amqpMessage.MessageAnnotations.Map)
                {
                    object netObject;
                    if (TryGetNetObjectFromAmqpObject(keyValuePair.Value, MappingType.ApplicationProperty, out netObject))
                    {
                        data.SystemProperties[keyValuePair.Key.ToString()] = netObject;
                    }
                }
            }

            if ((sections & SectionFlag.DeliveryAnnotations) != 0)
            {
                long lastSequenceNumber;
                if (amqpMessage.DeliveryAnnotations.Map.TryGetValue(AmqpClientConstants.ManagementPartitionLastEnqueuedSequenceNumber, out lastSequenceNumber))
                {
                    data.LastSequenceNumber = lastSequenceNumber;
                }

                string lastEnqueuedOffset;
                if (amqpMessage.DeliveryAnnotations.Map.TryGetValue(AmqpClientConstants.ManagementPartitionLastEnqueuedOffset, out lastEnqueuedOffset))
                {
                    data.LastEnqueuedOffset = lastEnqueuedOffset;
                }

                DateTime lastEnqueuedTime;
                if (amqpMessage.DeliveryAnnotations.Map.TryGetValue(AmqpClientConstants.ManagementPartitionLastEnqueuedTimeUtc, out lastEnqueuedTime))
                {
                    data.LastEnqueuedTime = lastEnqueuedTime;
                }

                DateTime retrievalTime;
                if (amqpMessage.DeliveryAnnotations.Map.TryGetValue(AmqpClientConstants.ManagementPartitionRuntimeInfoRetrievalTimeUtc, out retrievalTime))
                {
                    data.RetrievalTime = retrievalTime;
                }
            }

            if ((sections & SectionFlag.ApplicationProperties) != 0)
            {
                foreach (KeyValuePair<MapKey, object> pair in amqpMessage.ApplicationProperties.Map)
                {
                    if (data.Properties == null)
                    {
                        data.Properties = new Dictionary<string, object>();
                    }

                    object netObject;
                    if (TryGetNetObjectFromAmqpObject(pair.Value, MappingType.ApplicationProperty, out netObject))
                    {
                        data.Properties[pair.Key.ToString()] = netObject;
                    }
                }
            }

            if ((sections & SectionFlag.Properties) != 0)
            {
                if (data.SystemProperties == null)
                {
                    data.SystemProperties = new EventData.SystemPropertiesCollection();
                }

                if (amqpMessage.Properties != null)
                {
                    AddFieldToSystemProperty(amqpMessage.Properties.MessageId != null, data.SystemProperties, Properties.MessageIdName, amqpMessage.Properties.MessageId);
                    AddFieldToSystemProperty(amqpMessage.Properties.UserId.Array != null, data.SystemProperties, Properties.UserIdName, amqpMessage.Properties.UserId);
                    AddFieldToSystemProperty(amqpMessage.Properties.To != null, data.SystemProperties, Properties.ToName, amqpMessage.Properties.To);
                    AddFieldToSystemProperty(amqpMessage.Properties.Subject != null, data.SystemProperties, Properties.SubjectName, amqpMessage.Properties.Subject);
                    AddFieldToSystemProperty(amqpMessage.Properties.ReplyTo != null, data.SystemProperties, Properties.ReplyToName, amqpMessage.Properties.ReplyTo);
                    AddFieldToSystemProperty(amqpMessage.Properties.CorrelationId != null, data.SystemProperties, Properties.CorrelationIdName, amqpMessage.Properties.CorrelationId);
                    AddFieldToSystemProperty(amqpMessage.Properties.ContentType.Value != null, data.SystemProperties, Properties.ContentTypeName, amqpMessage.Properties.ContentType);
                    AddFieldToSystemProperty(amqpMessage.Properties.ContentEncoding.Value != null, data.SystemProperties, Properties.ContentEncodingName, amqpMessage.Properties.ContentEncoding);
                    AddFieldToSystemProperty(amqpMessage.Properties.AbsoluteExpiryTime != null, data.SystemProperties, Properties.AbsoluteExpiryTimeName, amqpMessage.Properties.AbsoluteExpiryTime);
                    AddFieldToSystemProperty(amqpMessage.Properties.CreationTime != null, data.SystemProperties, Properties.CreationTimeName, amqpMessage.Properties.CreationTime);
                    AddFieldToSystemProperty(amqpMessage.Properties.GroupId != null, data.SystemProperties, Properties.GroupIdName, amqpMessage.Properties.GroupId);
                    AddFieldToSystemProperty(amqpMessage.Properties.GroupSequence != null, data.SystemProperties, Properties.GroupSequenceName, amqpMessage.Properties.GroupSequence);
                    AddFieldToSystemProperty(amqpMessage.Properties.ReplyToGroupId != null, data.SystemProperties, Properties.ReplyToGroupIdName, amqpMessage.Properties.ReplyToGroupId);
                    data.ContentType = amqpMessage.Properties.ContentType.Value;
                }
            }
        }

        private static void AddFieldToSystemProperty(bool condition, EventData.SystemPropertiesCollection systemProperties, string propertyName, object value)
        {
            if (condition)
            {
                systemProperties[propertyName] = value;
            }
        }

        static ArraySegment<byte> StreamToBytes(Stream stream)
        {
            ArraySegment<byte> buffer;

            if (stream == null)
            {
                buffer = new ArraySegment<byte>();
            }
            else
            {
                MemoryStream memoryStream = new MemoryStream(512);
                stream.CopyTo(memoryStream, 512);
                buffer = new ArraySegment<byte>(memoryStream.ToArray());
            }

            return buffer;
        }

        static bool TryGetAmqpObjectFromNetObject(object netObject, MappingType mappingType, out object amqpObject)
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
                        throw Fx.Exception.AsError(new SerializationException(Resources.FailedToSerializeUnsupportedType.FormatForUser(netObject.GetType().FullName)));
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
                        throw Fx.Exception.AsError(new SerializationException(Resources.FailedToSerializeUnsupportedType.FormatForUser(amqpObject.GetType().FullName)));
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
            }

            return netObject != null;
        }
    }
}
