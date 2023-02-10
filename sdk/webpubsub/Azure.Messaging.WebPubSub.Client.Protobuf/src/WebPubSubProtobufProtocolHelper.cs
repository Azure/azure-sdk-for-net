// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Linq;
using System.Text;
using Azure.Core;
using Azure.Messaging.WebPubSub.Clients;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;

namespace Azure.Messaging.WebPubSub.Client.Protobuf
{
    /// <summary>
    /// The helper class for protobuf protocol
    /// </summary>
    internal class WebPubSubProtobufProtocolHelper
    {
        /// <inheritdoc/>
        public static ReadOnlyMemory<byte> GetMessageBytes(WebPubSubMessage message)
        {
            var writer = new ArrayBufferWriter<byte>();
            WriteMessage(message, writer);
            return writer.WrittenMemory;
        }

        /// <inheritdoc/>
        public static WebPubSubMessage ParseMessage(ReadOnlySequence<byte> input)
        {
            var downstreamMessage = DownstreamMessage.Parser.ParseFrom(input);
            switch (downstreamMessage.MessageCase)
            {
                case DownstreamMessage.MessageOneofCase.AckMessage:
                    AckMessageError error = null;
                    if (downstreamMessage.AckMessage.Error!= null)
                    {
                        error = new AckMessageError(downstreamMessage.AckMessage.Error.Name, downstreamMessage.AckMessage.Error.Message);
                    }
                    return new AckMessage(downstreamMessage.AckMessage.AckId, downstreamMessage.AckMessage.Success, error);

                case DownstreamMessage.MessageOneofCase.DataMessage:
                    var from = downstreamMessage.DataMessage.From;
                    var sequenceId = downstreamMessage.DataMessage.SequenceId;
                    if (!TryParseMessageData(downstreamMessage.DataMessage.Data, out var dataType, out var binaryData))
                    {
                        return null;
                    }
                    if (from == "group")
                    {
                        var group = downstreamMessage.DataMessage.Group;
                        return new GroupDataMessage(group, dataType, binaryData, sequenceId, null);
                    }
                    else if (from == "server")
                    {
                        return new ServerDataMessage(dataType, binaryData, sequenceId);
                    }
                    else
                    {
                        return null;
                    }

                case DownstreamMessage.MessageOneofCase.SystemMessage:
                    switch (downstreamMessage.SystemMessage.MessageCase)
                    {
                        case DownstreamMessage.Types.SystemMessage.MessageOneofCase.ConnectedMessage:
                            var connectedMsg = downstreamMessage.SystemMessage.ConnectedMessage;
                            return new ConnectedMessage(connectedMsg.UserId, connectedMsg.ConnectionId, connectedMsg.ReconnectionToken);

                        case DownstreamMessage.Types.SystemMessage.MessageOneofCase.DisconnectedMessage:
                            var disconnectedMsg = downstreamMessage.SystemMessage.DisconnectedMessage;
                            return new DisconnectedMessage(disconnectedMsg.Reason);
                        default:
                            return null;
                    }
                default:
                    return null;
            }
        }

        /// <inheritdoc/>
        public static void WriteMessage(WebPubSubMessage message, IBufferWriter<byte> output)
        {
            switch (message)
            {
                case SequenceAckMessage sequenceAck:
                    new UpstreamMessage { SequenceAckMessage = new UpstreamMessage.Types.SequenceAckMessage { SequenceId = sequenceAck.SequenceId } }.WriteTo(output);
                    break;

                case JoinGroupMessage joinGroupMessage:
                    var joinGroup = new UpstreamMessage.Types.JoinGroupMessage { Group = joinGroupMessage.Group };
                    if (joinGroupMessage.AckId.HasValue)
                    {
                        joinGroup.AckId = joinGroupMessage.AckId.Value;
                    }
                    new UpstreamMessage { JoinGroupMessage = joinGroup}.WriteTo(output);
                    break;
                case LeaveGroupMessage leaveGroupMessage:
                    var leaveGroup = new UpstreamMessage.Types.LeaveGroupMessage { Group = leaveGroupMessage.Group };
                    if (leaveGroupMessage.AckId.HasValue)
                    {
                        leaveGroup.AckId = leaveGroupMessage.AckId.Value;
                    }
                    new UpstreamMessage { LeaveGroupMessage = leaveGroup}.WriteTo(output);
                    break;
                case SendToGroupMessage sendToGroupMessage:
                    var groupMessage = new UpstreamMessage.Types.SendToGroupMessage { Group = sendToGroupMessage.Group, NoEcho = sendToGroupMessage.NoEcho };
                    if (sendToGroupMessage.AckId.HasValue)
                    {
                        groupMessage.AckId = sendToGroupMessage.AckId.Value;
                    }
                    groupMessage.Data = WriteData(sendToGroupMessage.DataType, sendToGroupMessage.Data);
                    new UpstreamMessage {  SendToGroupMessage= groupMessage}.WriteTo(output);
                    break;
                case SendEventMessage sendEventMessage:
                    var eventMessage = new UpstreamMessage.Types.EventMessage { Event = sendEventMessage.EventName};
                    if (sendEventMessage.AckId.HasValue)
                    {
                        eventMessage.AckId = sendEventMessage.AckId.Value;
                    }
                    eventMessage.Data = WriteData(sendEventMessage.DataType, sendEventMessage.Data);
                    new UpstreamMessage { EventMessage = eventMessage }.WriteTo(output);
                    break;
            }
        }

        private static bool TryParseMessageData(MessageData data, out WebPubSubDataType type, out BinaryData binaryData)
        {
            switch (data.DataCase)
            {
                case MessageData.DataOneofCase.TextData:
                    type = WebPubSubDataType.Text;
                    binaryData = BinaryData.FromString(data.TextData);
                    return true;
                case MessageData.DataOneofCase.JsonData:
                    type = WebPubSubDataType.Json;
                    binaryData = BinaryData.FromString(data.JsonData);
                    return true;
                case MessageData.DataOneofCase.BinaryData:
                    type = WebPubSubDataType.Binary;
                    binaryData = BinaryData.FromBytes(data.BinaryData.ToArray());
                    return true;
                case MessageData.DataOneofCase.ProtobufData:
                    type = WebPubSubDataType.Protobuf;
                    binaryData = BinaryData.FromBytes(data.ProtobufData.ToByteArray());
                    return true;
                default:
                    type = default;
                    binaryData = default;
                    return false;
            }
        }

        private static MessageData WriteData(WebPubSubDataType dataType, BinaryData data)
        {
            switch (dataType)
            {
                case WebPubSubDataType.Binary:
                    return new MessageData
                    {
                        BinaryData = UnsafeByteOperations.UnsafeWrap(data),
                    };

                case WebPubSubDataType.Text:
                case WebPubSubDataType.Json:
                    return new MessageData
                    {
                        TextData = data.ToString(),
                    };

                case WebPubSubDataType.Protobuf:
                    var any = Any.Parser.ParseFrom(new ReadOnlySequence<byte>(data));
                    return new MessageData
                    {
                        ProtobufData = any,
                    };

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
