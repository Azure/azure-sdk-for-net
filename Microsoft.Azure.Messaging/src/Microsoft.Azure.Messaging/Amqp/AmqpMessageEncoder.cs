// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.Messaging.Amqp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Xml;
    using Microsoft.Azure.Amqp;

    sealed class AmqpMessageEncoder : IBrokeredMessageEncoder
    {
        const string NullMessageId = "nil";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times",
            Justification = "Safe here. Any future behavior change is easy to detect")]
        public long WriteHeader(XmlWriter writer, BrokeredMessage brokeredMessage, SerializationTarget serializationTarget)
        {
            //using (BufferListStream stream = BufferListStream.Create(brokeredMessage.RawHeaderStream, AmqpConstants.SegmentSize))
            //{
            //    using (AmqpMessage header = AmqpMessage.CreateAmqpStreamMessageHeader(stream))
            //    {
            //        AmqpMessageEncoder.UpdateAmqpMessageHeadersAndProperties(brokeredMessage, header, serializationTarget);

            //        if (serializationTarget == SerializationTarget.Communication)
            //        {
            //            writer.WriteStartElement("MessageHeaders");
            //        }

            //        long count = header.Write(writer);

            //        if (serializationTarget == SerializationTarget.Communication)
            //        {
            //            writer.WriteEndElement();
            //        }

            //        return count;
            //    }
            //}

            throw new NotImplementedException();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times",
            Justification = "Safe here. Any future behavior change is easy to detect")]
        public long ReadHeader(XmlReader reader, BrokeredMessage brokeredMessage, SerializationTarget serializationTarget)
        {
            //List<ArraySegment<byte>> buffers = new List<ArraySegment<byte>>();
            //long length = 0;

            //if (serializationTarget == SerializationTarget.Communication)
            //{
            //    reader.ReadStartElement();
            //}

            //byte[] buffer;
            //do
            //{
            //    buffer = ReadBytes(reader, AmqpConstants.SegmentSize);
            //    length += buffer.Length;
            //    buffers.Add(new ArraySegment<byte>(buffer, 0, buffer.Length));
            //}
            //while (buffer.Length >= AmqpConstants.SegmentSize);

            //if (serializationTarget == SerializationTarget.Communication)
            //{
            //    reader.ReadEndElement();
            //}

            //using (BufferListStream stream = new BufferListStream(buffers.ToArray()))
            //{
            //    using (AmqpMessage header = AmqpMessage.CreateAmqpStreamMessageHeader(stream))
            //    {
            //        header.Deserialize(SectionFlag.NonBody);
            //        brokeredMessage.MessageId = NullMessageId;  // will be updated if set
            //        AmqpMessageEncoder.UpdateBrokeredMessageHeaderAndProperties(header, brokeredMessage, serializationTarget);
            //        brokeredMessage.RawHeaderStream = header.GetNonBodySectionsStream();

            //        return length;
            //    }
            //}
            throw new NotImplementedException();
        }

        static byte[] ReadBytes(XmlReader reader, int bytesToRead)
        {
            int bytesRead = 0;
            byte[] bytes = new byte[bytesToRead];
            while (bytesRead < bytesToRead)
            {
                int lastReadCount = reader.ReadContentAsBase64(bytes, bytesRead, bytes.Length - bytesRead);
                bytesRead += lastReadCount;
                if (lastReadCount == 0)
                {
                    break;
                }
            }

            if (bytesRead < bytesToRead)
            {
                byte[] bytes2 = new byte[bytesRead];
                Array.Copy(bytes, bytes2, bytes2.Length);

                return bytes2;
            }
            else
            {
                return bytes;
            }
        }

        static void UpdateAmqpMessageHeadersAndProperties(BrokeredMessage source, AmqpMessage target, SerializationTarget serializationTarget)
        {
            AmqpMessageConverter.UpdateAmqpMessageHeadersAndProperties(target, source, amqpClient: false, stampPartitionIdToSequenceNumber: false);

            BrokeredMessage.MessageMembers messageMembers = source.InitializedMembers;
            if ((messageMembers & BrokeredMessage.MessageMembers.PrefilteredHeaders) != 0)
            {
                target.DeliveryAnnotations.Map[AmqpMessageConverter.PrefilteredMessageHeadersName] = AmqpMessageConverter.StreamToBytes(source.PrefilteredHeaders);
            }

            if ((messageMembers & BrokeredMessage.MessageMembers.PrefilteredProperties) != 0)
            {
                target.DeliveryAnnotations.Map[AmqpMessageConverter.PrefilteredMessagePropertiesName] = AmqpMessageConverter.StreamToBytes(source.PrefilteredProperties);
            }

            if ((messageMembers & BrokeredMessage.MessageMembers.TransferDestination) != 0)
            {
                target.DeliveryAnnotations.Map[AmqpMessageConverter.TransferDestinationName] = source.TransferDestination;
            }

            if ((messageMembers & BrokeredMessage.MessageMembers.TransferSource) != 0)
            {
                target.DeliveryAnnotations.Map[AmqpMessageConverter.TransferSourceName] = source.TransferSource;
            }

            if ((messageMembers & BrokeredMessage.MessageMembers.TransferSequenceNumber) != 0)
            {
                target.DeliveryAnnotations.Map[AmqpMessageConverter.TransferSequenceNumberName] = source.TransferSequenceNumber;

                // Transfer session-id and session-id are swapped by HASend but we keep it this way to avoid
                // modifying original properties section (group-id)
                target.DeliveryAnnotations.Map[AmqpMessageConverter.TransferSessionName] = source.SessionId;
            }

            if ((messageMembers & BrokeredMessage.MessageMembers.TransferHopCount) != 0)
            {
                target.DeliveryAnnotations.Map[AmqpMessageConverter.TransferHopCountName] = source.TransferHopCount;
            }

            if ((messageMembers & BrokeredMessage.MessageMembers.TransferDestinationEntityId) != 0)
            {
                target.DeliveryAnnotations.Map[AmqpMessageConverter.TransferResourceName] = source.TransferDestinationResourceId;
            }

            if ((messageMembers & BrokeredMessage.MessageMembers.DeadLetterSource) != 0)
            {
                target.DeliveryAnnotations.Map[AmqpMessageConverter.DeadLetterSourceName] = source.DeadLetterSource;
            }

            if (serializationTarget == SerializationTarget.Communication && (messageMembers & BrokeredMessage.MessageMembers.LockToken) != 0)
            {
                target.DeliveryAnnotations.Map[AmqpMessageConverter.LockTokenName] = source.LockToken;
                target.MessageAnnotations.Map[AmqpMessageConverter.LockedUntilName] = source.LockedUntilUtc;
            }
        }

        static void UpdateBrokeredMessageHeaderAndProperties(AmqpMessage source, BrokeredMessage target, SerializationTarget serializationTarget)
        {
            AmqpMessageConverter.UpdateBrokeredMessageHeaderAndProperties(source, target);

            SectionFlag sections = source.Sections;
            if ((sections & SectionFlag.Header) != 0)
            {
                if (source.Header.DeliveryCount != null)
                {
                    target.DeliveryCount = (int)source.Header.DeliveryCount;
                }
            }

            if ((sections & SectionFlag.MessageAnnotations) != 0)
            {
                DateTime enqueuedTimeUtc;
                if (source.MessageAnnotations.Map.TryGetValue<DateTime>(AmqpMessageConverter.EnqueuedTimeUtcName, out enqueuedTimeUtc))
                {
                    target.EnqueuedTimeUtc = enqueuedTimeUtc;
                }

                long sequenceNumber;
                if (source.MessageAnnotations.Map.TryGetValue<long>(AmqpMessageConverter.SequenceNumberName, out sequenceNumber))
                {
                    target.SequenceNumber = sequenceNumber;
                }

                DateTime lockedUntil;
                if (source.MessageAnnotations.Map.TryGetValue<DateTime>(AmqpMessageConverter.LockedUntilName, out lockedUntil))
                {
                    target.LockedUntilUtc = lockedUntil;
                }

                short partitionId;
                if (source.MessageAnnotations.Map.TryGetValue<short>(AmqpMessageConverter.PartitionIdName, out partitionId))
                {
                    target.PartitionId = partitionId;
                }
            }

            if ((sections & SectionFlag.DeliveryAnnotations) != 0)
            {
                ArraySegment<byte> prefilterHeaders;
                if (source.DeliveryAnnotations.Map.TryGetValue<ArraySegment<byte>>(AmqpMessageConverter.PrefilteredMessageHeadersName, out prefilterHeaders))
                {
                    target.PrefilteredHeaders = new MemoryStream(prefilterHeaders.Array, prefilterHeaders.Offset, prefilterHeaders.Count);
                }

                ArraySegment<byte> prefilterProperties;
                if (source.DeliveryAnnotations.Map.TryGetValue<ArraySegment<byte>>(AmqpMessageConverter.PrefilteredMessageHeadersName, out prefilterProperties))
                {
                    target.PrefilteredProperties = new MemoryStream(prefilterProperties.Array, prefilterProperties.Offset, prefilterProperties.Count);
                }

                string transferDestination;
                if (source.DeliveryAnnotations.Map.TryGetValue(AmqpMessageConverter.TransferDestinationName, out transferDestination))
                {
                    target.TransferDestination = transferDestination;
                }

                string transferSource;
                if (source.DeliveryAnnotations.Map.TryGetValue(AmqpMessageConverter.TransferSourceName, out transferSource))
                {
                    target.TransferSource = transferSource;
                }

                long transferSeqNumber;
                if (source.DeliveryAnnotations.Map.TryGetValue(AmqpMessageConverter.TransferSequenceNumberName, out transferSeqNumber))
                {
                    target.TransferSequenceNumber = transferSeqNumber;
                }

                int transferHopCount;
                if (source.DeliveryAnnotations.Map.TryGetValue(AmqpMessageConverter.TransferHopCountName, out transferHopCount))
                {
                    target.TransferHopCount = transferHopCount;
                }

                long transferEntityId;
                if (source.DeliveryAnnotations.Map.TryGetValue(AmqpMessageConverter.TransferResourceName, out transferEntityId))
                {
                    target.TransferDestinationResourceId = transferEntityId;
                }

                string transferSession;
                if (source.DeliveryAnnotations.Map.TryGetValue(AmqpMessageConverter.TransferSessionName, out transferSession))
                {
                    // HA entity pump will swap them
                    target.CopySessionId(transferSession);
                    target.TransferSessionId = source.Properties == null ? null : source.Properties.GroupId;
                }

                string deadLetterSource;
                if (source.DeliveryAnnotations.Map.TryGetValue(AmqpMessageConverter.DeadLetterSourceName, out deadLetterSource))
                {
                    target.DeadLetterSource = deadLetterSource;
                }

                Guid lockToken;
                if (source.DeliveryAnnotations.Map.TryGetValue(AmqpMessageConverter.LockTokenName, out lockToken))
                {
                    target.LockToken = lockToken;
                }
            }
        }
    }
}
