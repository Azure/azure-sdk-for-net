// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace Azure.Messaging.WebPubSub.Clients
{
    internal class WebPubSubJsonProtocolBase
    {
        private const string TypePropertyName = "type";
        private static readonly JsonEncodedText TypePropertyNameBytes = JsonEncodedText.Encode(TypePropertyName);
        private const string GroupPropertyName = "group";
        private static readonly JsonEncodedText GroupPropertyNameBytes = JsonEncodedText.Encode(GroupPropertyName);
        private const string AckIdPropertyName = "ackId";
        private static readonly JsonEncodedText AckIdPropertyNameBytes = JsonEncodedText.Encode(AckIdPropertyName);
        private const string DataTypePropertyName = "dataType";
        private static readonly JsonEncodedText DataTypePropertyNameBytes = JsonEncodedText.Encode(DataTypePropertyName);
        private const string DataPropertyName = "data";
        private static readonly JsonEncodedText DataPropertyNameBytes = JsonEncodedText.Encode(DataPropertyName);
        private const string EventPropertyName = "event";
        private static readonly JsonEncodedText EventPropertyNameBytes = JsonEncodedText.Encode(EventPropertyName);
        private const string NoEchoPropertyName = "noEcho";
        private static readonly JsonEncodedText NoEchoPropertyNameBytes = JsonEncodedText.Encode(NoEchoPropertyName);

        private const string SuccessPropertyName = "success";
        private static readonly JsonEncodedText SuccessPropertyNameBytes = JsonEncodedText.Encode(SuccessPropertyName);
        private const string MessagePropertyName = "message";
        private static readonly JsonEncodedText MessagePropertyNameBytes = JsonEncodedText.Encode(MessagePropertyName);
        private const string ErrorPropertyName = "error";
        private static readonly JsonEncodedText ErrorPropertyNameBytes = JsonEncodedText.Encode(ErrorPropertyName);
        private const string ErrorNamePropertyName = "name";
        private static readonly JsonEncodedText ErrorNamePropertyNameBytes = JsonEncodedText.Encode(ErrorNamePropertyName);
        private const string FromPropertyName = "from";
        private static readonly JsonEncodedText FromPropertyNameBytes = JsonEncodedText.Encode(FromPropertyName);
        private const string FromUserIdPropertyName = "fromUserId";
        private static readonly JsonEncodedText FromUserIdPropertyNameBytes = JsonEncodedText.Encode(FromUserIdPropertyName);
        private const string UserIdPropertyName = "userId";
        private static readonly JsonEncodedText UserIdPropertyNameBytes = JsonEncodedText.Encode(UserIdPropertyName);
        private const string ConnectionIdPropertyName = "connectionId";
        private static readonly JsonEncodedText ConnectionIdPropertyNameBytes = JsonEncodedText.Encode(ConnectionIdPropertyName);
        private const string ReconnectionTokenPropertyName = "reconnectionToken";
        private static readonly JsonEncodedText ReconnectionTokenPropertyNameBytes = JsonEncodedText.Encode(ReconnectionTokenPropertyName);
        private const string SequenceIdPropertyName = "sequenceId";
        private static readonly JsonEncodedText SequenceIdPropertyNameBytes = JsonEncodedText.Encode(SequenceIdPropertyName);

        private static readonly JsonEncodedText JoinGroupTypeBytes = JsonEncodedText.Encode("joinGroup");
        private static readonly JsonEncodedText LeaveGroupTypeBytes = JsonEncodedText.Encode("leaveGroup");
        private static readonly JsonEncodedText SendToGroupTypeBytes = JsonEncodedText.Encode("sendToGroup");
        private static readonly JsonEncodedText SendEventTypeBytes = JsonEncodedText.Encode("event");
        private static readonly JsonEncodedText SequenceAckTypeBytes = JsonEncodedText.Encode("sequenceAck");

        private const byte Quote = (byte)'"';
        private const byte KeyValueSeperator = (byte)':';
        private const byte ListSeparator = (byte)',';

        public ReadOnlyMemory<byte> GetMessageBytes(WebPubSubMessage message)
        {
            using var writer = new MemoryBufferWriter();
            WriteMessage(message, writer);
            return new Memory<byte>(writer.ToArray());
        }

        public virtual IReadOnlyList<WebPubSubMessage> ParseMessage(ReadOnlySequence<byte> input)
        {
            try
            {
                string type = null;
                DownstreamEventType eventType = DownstreamEventType.Ack;
                string group = null;
                string @event = null;
                SystemEventType systemEventType = SystemEventType.Connected;
                long? ackId = null;
                long? sequenceId = null;
                bool? success = null;
                string from = null;
                FromType fromType = FromType.Server;
                AckMessageError errorDetail = null;
                WebPubSubDataType dataType = WebPubSubDataType.Text;
                string userId = null;
                string connectionId = null;
                string reconnectionToken = null;
                string message = null;
                string fromUserId = null;

                var completed = false;
                bool hasDataToken = false;
                BinaryData data = null;
                SequencePosition dataStart = default;
                Utf8JsonReader dataReader = default;

                var reader = new Utf8JsonReader(input, isFinalBlock: true, state: default);

                reader.CheckRead();

                // We're always parsing a JSON object
                reader.EnsureObjectStart();

                do
                {
                    switch (reader.TokenType)
                    {
                        case JsonTokenType.PropertyName:
                            if (reader.ValueTextEquals(TypePropertyNameBytes.EncodedUtf8Bytes))
                            {
                                type = reader.ReadAsNullableString(TypePropertyName);
                                if (type == null)
                                {
                                    throw new InvalidDataException($"Expected '{TypePropertyName}' to be of type {JsonTokenType.String}.");
                                }
                                if (!Enum.TryParse(type, true, out eventType))
                                {
                                    throw new InvalidDataException($"Unknown '{TypePropertyName}': {type}.");
                                }
                            }
                            else if (reader.ValueTextEquals(GroupPropertyNameBytes.EncodedUtf8Bytes))
                            {
                                group = reader.ReadAsNullableString(GroupPropertyName);
                            }
                            else if (reader.ValueTextEquals(EventPropertyNameBytes.EncodedUtf8Bytes))
                            {
                                @event = reader.ReadAsNullableString(EventPropertyName);
                                if (!Enum.TryParse(@event, true, out systemEventType))
                                {
                                    throw new InvalidDataException($"Unknown '{EventPropertyName}': {@event}.");
                                }
                            }
                            else if (reader.ValueTextEquals(DataTypePropertyNameBytes.EncodedUtf8Bytes))
                            {
                                var dataTypeValue = reader.ReadAsNullableString(DataTypePropertyName);
                                if (!Enum.TryParse<WebPubSubDataType>(dataTypeValue, true, out dataType))
                                {
                                    throw new InvalidDataException($"Unknown '{DataTypePropertyName}': {dataTypeValue}.");
                                }
                            }
                            else if (reader.ValueTextEquals(AckIdPropertyNameBytes.EncodedUtf8Bytes))
                            {
                                try
                                {
                                    ackId = reader.ReadAsLongNonNegtive(AckIdPropertyName);
                                }
                                catch (FormatException)
                                {
                                    throw new InvalidDataException($"'{AckIdPropertyName}' is not a valid uint64 value.");
                                }
                            }
                            else if (reader.ValueTextEquals(DataPropertyNameBytes.EncodedUtf8Bytes))
                            {
                                hasDataToken = true;
                                dataStart = reader.Position;
                                reader.Skip();
                                dataReader = reader;
                            }
                            else if (reader.ValueTextEquals(SequenceIdPropertyNameBytes.EncodedUtf8Bytes))
                            {
                                try
                                {
                                    sequenceId = reader.ReadAsLongNonNegtive(SequenceIdPropertyName);
                                }
                                catch (FormatException)
                                {
                                    throw new InvalidDataException($"'{SequenceIdPropertyName}' is not a valid uint64 value.");
                                }
                            }
                            else if (reader.ValueTextEquals(SuccessPropertyNameBytes.EncodedUtf8Bytes))
                            {
                                success = reader.ReadAsBoolean(SuccessPropertyName);
                            }
                            else if (reader.ValueTextEquals(ErrorPropertyNameBytes.EncodedUtf8Bytes))
                            {
                                errorDetail = ReadErrorDetail(reader);
                            }
                            else if (reader.ValueTextEquals(FromPropertyNameBytes.EncodedUtf8Bytes))
                            {
                                from = reader.ReadAsNullableString(FromPropertyName);
                                if (!Enum.TryParse(from, true, out fromType))
                                {
                                    throw new InvalidDataException($"Unknown '{FromPropertyName}': {from}.");
                                }
                            }
                            else if (reader.ValueTextEquals(UserIdPropertyNameBytes.EncodedUtf8Bytes))
                            {
                                userId = reader.ReadAsNullableString(UserIdPropertyName);
                            }
                            else if (reader.ValueTextEquals(ConnectionIdPropertyNameBytes.EncodedUtf8Bytes))
                            {
                                connectionId = reader.ReadAsNullableString(ConnectionIdPropertyName);
                            }
                            else if (reader.ValueTextEquals(ReconnectionTokenPropertyNameBytes.EncodedUtf8Bytes))
                            {
                                reconnectionToken = reader.ReadAsNullableString(ReconnectionTokenPropertyName);
                            }
                            else if (reader.ValueTextEquals(MessagePropertyNameBytes.EncodedUtf8Bytes))
                            {
                                message = reader.ReadAsNullableString(MessagePropertyName);
                            }
                            else if (reader.ValueTextEquals(FromUserIdPropertyNameBytes.EncodedUtf8Bytes))
                            {
                                fromUserId = reader.ReadAsNullableString(FromUserIdPropertyName);
                            }
                            else
                            {
                                reader.CheckRead();
                                reader.Skip();
                            }
                            break;
                        case JsonTokenType.EndObject:
                            completed = true;
                            break;
                    }
                }
                while (!completed && reader.CheckRead());

                if (type == null)
                {
                    throw new InvalidDataException($"Missing required property '{TypePropertyName}'.");
                }

                if (hasDataToken)
                {
                    if (dataType == WebPubSubDataType.Binary ||
                        dataType == WebPubSubDataType.Protobuf ||
                        dataType == WebPubSubDataType.Text)
                    {
                        if (dataReader.TokenType != JsonTokenType.String)
                        {
                            throw new InvalidDataException($"'data' should be a string when 'dataType' is 'binary,text,protobuf'.");
                        }

                        if (dataType == WebPubSubDataType.Binary ||
                            dataType == WebPubSubDataType.Protobuf)
                        {
                            if (!dataReader.TryGetBytesFromBase64(out var bytes))
                            {
                                throw new InvalidDataException($"'data' is not a valid base64 encoded string.");
                            }
                            data = new BinaryData(bytes);
                        }
                        else
                        {
                            data = new BinaryData(dataReader.GetString());
                        }
                    }
                    else if (dataType == WebPubSubDataType.Json)
                    {
                        if (dataReader.TokenType == JsonTokenType.Null)
                        {
                            throw new InvalidDataException($"Invalid value for '{DataPropertyName}': null.");
                        }

                        var end = dataReader.Position;
                        data = new BinaryData(input.Slice(dataStart, end).ToArray());
                    }
                }

                switch (eventType)
                {
                    case DownstreamEventType.Ack:
                        AssertNotNull(ackId, AckIdPropertyName);
                        AssertNotNull(success, SuccessPropertyName);
                        return new List<WebPubSubMessage> { new AckMessage(ackId.Value, success.Value, errorDetail) };

                    case DownstreamEventType.Message:
                        AssertNotNull(from, FromPropertyName);
                        AssertNotNull(dataType, FromPropertyName);
                        AssertNotNull(data, DataPropertyName);
                        switch (fromType)
                        {
                            case FromType.Server:
                                return new List<WebPubSubMessage> { new ServerDataMessage(dataType, data, sequenceId) };
                            case FromType.Group:
                                AssertNotNull(group, GroupPropertyName);
                                return new List<WebPubSubMessage> { new GroupDataMessage(group, dataType, data, sequenceId, fromUserId) };
                            // Forward compatible
                            default:
                                return null;
                        }

                    case DownstreamEventType.System:
                        AssertNotNull(@event, EventPropertyName);

                        switch (systemEventType)
                        {
                            case SystemEventType.Connected:
                                return new List<WebPubSubMessage> { new ConnectedMessage(userId, connectionId, reconnectionToken) };
                            case SystemEventType.Disconnected:
                                return new List<WebPubSubMessage> { new DisconnectedMessage(message) };
                            // Forward compatible
                            default:
                                return null;
                        }
                    // Forward compatible
                    default:
                        return null;
                }
            }
            catch (JsonException ex)
            {
                throw new InvalidDataException("Error reading JSON.", ex);
            }
        }

        public virtual void WriteMessage(WebPubSubMessage message, IBufferWriter<byte> output)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var jsonWriterLease = ReusableUtf8JsonWriter.Get(output);

            try
            {
                var writer = jsonWriterLease.GetJsonWriter();

                writer.WriteStartObject();

                switch (message)
                {
                    case JoinGroupMessage joinGroupMessage:
                        writer.WriteString(TypePropertyNameBytes, JoinGroupTypeBytes);
                        writer.WriteString(GroupPropertyNameBytes, joinGroupMessage.Group);
                        if (joinGroupMessage.AckId != null)
                        {
                            writer.WriteNumber(AckIdPropertyNameBytes, joinGroupMessage.AckId.Value);
                        }
                        break;
                    case LeaveGroupMessage leaveGroupMessage:
                        writer.WriteString(TypePropertyNameBytes, LeaveGroupTypeBytes);
                        writer.WriteString(GroupPropertyNameBytes, leaveGroupMessage.Group);
                        if (leaveGroupMessage.AckId != null)
                        {
                            writer.WriteNumber(AckIdPropertyNameBytes, leaveGroupMessage.AckId.Value);
                        }
                        break;
                    case SendToGroupMessage sendToGroupMessage:
                        writer.WriteString(TypePropertyNameBytes, SendToGroupTypeBytes);
                        writer.WriteString(GroupPropertyNameBytes, sendToGroupMessage.Group);
                        if (sendToGroupMessage.AckId != null)
                        {
                            writer.WriteNumber(AckIdPropertyNameBytes, sendToGroupMessage.AckId.Value);
                        }
                        writer.WriteBoolean(NoEchoPropertyNameBytes, sendToGroupMessage.NoEcho);
                        writer.WriteString(DataTypePropertyNameBytes, sendToGroupMessage.DataType.ToString());
                        WriteData(output, writer, sendToGroupMessage.Data, sendToGroupMessage.DataType);
                        break;
                    case SendEventMessage sendEventMessage:
                        writer.WriteString(TypePropertyNameBytes, SendEventTypeBytes);
                        writer.WriteString(EventPropertyNameBytes, sendEventMessage.EventName);
                        if (sendEventMessage.AckId != null)
                        {
                            writer.WriteNumber(AckIdPropertyNameBytes, sendEventMessage.AckId.Value);
                        }
                        writer.WriteString(DataTypePropertyNameBytes, sendEventMessage.DataType.ToString());
                        WriteData(output, writer, sendEventMessage.Data, sendEventMessage.DataType);
                        break;
                    case SequenceAckMessage sequenceAckMessage:
                        writer.WriteString(TypePropertyNameBytes, SequenceAckTypeBytes);
                        writer.WriteNumber(SequenceIdPropertyNameBytes, sequenceAckMessage.SequenceId);
                        break;
                    default:
                        throw new InvalidDataException($"{message.GetType()} is not supported.");
                }

                writer.WriteEndObject();
                writer.Flush();
            }
            finally
            {
                ReusableUtf8JsonWriter.Return(jsonWriterLease);
            }
        }

        private static AckMessageError ReadErrorDetail(Utf8JsonReader reader)
        {
            string errorName = null;
            string errorMessage = null;

            var completed = false;
            reader.CheckRead();
            // Error detail should start with object
            reader.EnsureObjectStart();
            do
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.PropertyName:
                        if (reader.ValueTextEquals(ErrorNamePropertyNameBytes.EncodedUtf8Bytes))
                        {
                            errorName = reader.ReadAsNullableString(ErrorNamePropertyName);
                        }
                        else if (reader.ValueTextEquals(MessagePropertyNameBytes.EncodedUtf8Bytes))
                        {
                            errorMessage = reader.ReadAsNullableString(MessagePropertyName);
                        }
                        break;
                    case JsonTokenType.EndObject:
                        completed = true;
                        break;
                }
            }
            while (!completed && reader.CheckRead());

            return new AckMessageError(errorName, errorMessage);
        }

        private static void AssertNotNull<T>(T value, string propertyName)
        {
            if (value == null)
            {
                throw new InvalidDataException($"Missing required property '{propertyName}'.");
            }
        }

        private static void WriteData(IBufferWriter<byte> buffer, Utf8JsonWriter writer, BinaryData data, WebPubSubDataType dataType)
        {
            switch (dataType)
            {
                case WebPubSubDataType.Text:
                    writer.WriteString(DataPropertyNameBytes, data);
                    break;
                case WebPubSubDataType.Json:
                    writer.Flush();
                    var length = DataPropertyNameBytes.EncodedUtf8Bytes.Length + 4; // ListSeparator + Quota + DataPropertyNameBytes + Quota + KeyValueSeperator
                    var span = buffer.GetSpan(length);
                    span[0] = ListSeparator;
                    span[1] = Quote;
                    DataPropertyNameBytes.EncodedUtf8Bytes.CopyTo(span.Slice(2));
                    span[length - 2] = Quote;
                    span[length - 1] = KeyValueSeperator;
                    buffer.Advance(length);
                    buffer.Write(data.ToMemory().Span);
                    break;
                case WebPubSubDataType.Binary:
                case WebPubSubDataType.Protobuf:
                    writer.WriteBase64String(DataPropertyNameBytes, data);
                    break;
                default:
                    throw new InvalidDataException($"{dataType} is not a supported DataType");
            }
        }

        private enum DownstreamEventType
        {
            Ack,
            Message,
            System,
        }

        private enum FromType
        {
            Server,
            Group,
        }

        private enum SystemEventType
        {
            Connected,
            Disconnected,
        }
    }
}
