// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Messaging.WebPubSub.Clients;
using NUnit.Framework;

namespace Azure.Messaging.WebPubSub.Client.Tests.Protocols
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class JsonProtocolTests
    {
        private class JsonData
        {
            public string Value { get; set; }
        }

        public static IEnumerable<object[]> GetParsingTestData()
        {
            static object[] GetData(object jsonPayload, Action<WebPubSubMessage> assert)
            {
                var converter = JsonSerializer.Serialize(jsonPayload);
                return new object[] { Encoding.UTF8.GetBytes(converter), assert };
            }

            yield return GetData(new { type="ack", ackId = 123, success=true }, message =>
            {
                Assert.That(message is AckMessage, Is.True);
                var ackMessage = message as AckMessage;
                Assert.Multiple(() =>
                {
                    Assert.That(ackMessage.AckId, Is.EqualTo(123u));
                    Assert.That(ackMessage.Success, Is.True);
                    Assert.That(ackMessage.Error, Is.Null);
                });
            });
            yield return GetData(new { type = "ack", ackId = 123, success = false, error = new { name = "Forbidden", message = "message"} }, message =>
            {
                Assert.That(message is AckMessage, Is.True);
                var ackMessage = message as AckMessage;
                Assert.Multiple(() =>
                {
                    Assert.That(ackMessage.AckId, Is.EqualTo(123u));
                    Assert.That(ackMessage.Success, Is.False);
                    Assert.That(ackMessage.Error.Name, Is.EqualTo("Forbidden"));
                    Assert.That(ackMessage.Error.Message, Is.EqualTo("message"));
                });
            });
            yield return GetData(new { sequenceId = 738476327894u, type = "message", from = "group", group = "groupname", dataType = "text", data = "xyz", fromUserId = "user" }, message =>
            {
                Assert.That(message is GroupDataMessage, Is.True);
                var groupDataMessage = message as GroupDataMessage;
                Assert.Multiple(() =>
                {
                    Assert.That(groupDataMessage.Group, Is.EqualTo("groupname"));
                    Assert.That(groupDataMessage.SequenceId, Is.EqualTo(738476327894u));
                    Assert.That(groupDataMessage.DataType, Is.EqualTo(WebPubSubDataType.Text));
                    Assert.That(groupDataMessage.FromUserId, Is.EqualTo("user"));
                    Assert.That(groupDataMessage.Data.ToString(), Is.EqualTo("xyz"));
                });
            });
            yield return GetData(new { type = "message", from = "group", group = "groupname", dataType = "json", data = new JsonData { Value = "xyz" } }, message =>
            {
                Assert.That(message is GroupDataMessage, Is.True);
                var groupDataMessage = message as GroupDataMessage;
                Assert.Multiple(() =>
                {
                    Assert.That(groupDataMessage.Group, Is.EqualTo("groupname"));
                    Assert.That(groupDataMessage.SequenceId, Is.Null);
                    Assert.That(groupDataMessage.DataType, Is.EqualTo(WebPubSubDataType.Json));
                });
                var obj = groupDataMessage.Data.ToObjectFromJson<JsonData>();
                Assert.That(obj.Value, Is.EqualTo("xyz"));
            });
            yield return GetData(new { type = "message", from = "group", group = "groupname", dataType = "binary", data = "eHl6" }, message =>
            {
                Assert.That(message is GroupDataMessage, Is.True);
                var groupDataMessage = message as GroupDataMessage;
                Assert.Multiple(() =>
                {
                    Assert.That(groupDataMessage.Group, Is.EqualTo("groupname"));
                    Assert.That(groupDataMessage.SequenceId, Is.Null);
                    Assert.That(groupDataMessage.DataType, Is.EqualTo(WebPubSubDataType.Binary));
                    Assert.That(Convert.ToBase64String(groupDataMessage.Data.ToArray()), Is.EqualTo("eHl6"));
                });
            });
            yield return GetData(new { sequenceId = 738476327894u, type = "message", from = "server", dataType = "text", data = "xyz" }, message =>
            {
                Assert.That(message is ServerDataMessage, Is.True);
                var dataMessage = message as ServerDataMessage;
                Assert.Multiple(() =>
                {
                    Assert.That(dataMessage.SequenceId, Is.EqualTo(738476327894u));
                    Assert.That(dataMessage.DataType, Is.EqualTo(WebPubSubDataType.Text));
                    Assert.That(dataMessage.Data.ToString(), Is.EqualTo("xyz"));
                });
            });
            yield return GetData(new { type = "message", from = "server", dataType = "json", data = new JsonData { Value = "xyz" } }, message =>
            {
                Assert.That(message is ServerDataMessage, Is.True);
                var dataMessage = message as ServerDataMessage;;
                Assert.Multiple(() =>
                {
                    Assert.That(dataMessage.SequenceId, Is.Null);
                    Assert.That(dataMessage.DataType, Is.EqualTo(WebPubSubDataType.Json));
                });
                var obj = dataMessage.Data.ToObjectFromJson<JsonData>();
                Assert.That(obj.Value, Is.EqualTo("xyz"));
            });
            yield return GetData(new { type = "message", from = "server", dataType = "binary", data = "eHl6" }, message =>
            {
                Assert.That(message is ServerDataMessage, Is.True);
                var dataMessage = message as ServerDataMessage;
                Assert.Multiple(() =>
                {
                    Assert.That(dataMessage.SequenceId, Is.Null);
                    Assert.That(dataMessage.DataType, Is.EqualTo(WebPubSubDataType.Binary));
                    Assert.That(Convert.ToBase64String(dataMessage.Data.ToArray()), Is.EqualTo("eHl6"));
                });
            });
            yield return GetData(new { type = "system", @event = "connected", userId = "user", connectionId = "connection" }, message =>
            {
                Assert.That(message is ConnectedMessage, Is.True);
                var connectedMessage = message as ConnectedMessage;
                Assert.Multiple(() =>
                {
                    Assert.That(connectedMessage.UserId, Is.EqualTo("user"));
                    Assert.That(connectedMessage.ConnectionId, Is.EqualTo("connection"));
                    Assert.That(connectedMessage.ReconnectionToken, Is.Null);
                });
            });
            yield return GetData(new { type = "system", @event = "connected", userId = "user", connectionId = "connection", reconnectionToken = "rec" }, message =>
            {
                Assert.That(message is ConnectedMessage, Is.True);
                var connectedMessage = message as ConnectedMessage;
                Assert.Multiple(() =>
                {
                    Assert.That(connectedMessage.UserId, Is.EqualTo("user"));
                    Assert.That(connectedMessage.ConnectionId, Is.EqualTo("connection"));
                    Assert.That(connectedMessage.ReconnectionToken, Is.EqualTo("rec"));
                });
            });
            yield return GetData(new { type = "system", @event = "disconnected", message = "msg" }, message =>
            {
                Assert.That(message is DisconnectedMessage, Is.True);
                var disconnectedMessage = message as DisconnectedMessage;
                Assert.That(disconnectedMessage.Reason, Is.EqualTo("msg"));
            });
        }

        public static IEnumerable<object[]> GetSerializingTestData()
        {
            static object[] GetData(WebPubSubMessage message, object json)
            {
                return new object[] { message, JsonSerializer.Serialize(json)};
            }

            yield return GetData(new JoinGroupMessage("group", null), new { type = "joinGroup", group = "group" });
            yield return GetData(new JoinGroupMessage("group", 738476327894), new { type = "joinGroup", group = "group", ackId = 738476327894u });
            yield return GetData(new LeaveGroupMessage("group", null), new { type = "leaveGroup", group = "group" });
            yield return GetData(new LeaveGroupMessage("group", 738476327894), new { type = "leaveGroup", group = "group", ackId = 738476327894u });
            yield return GetData(new SendToGroupMessage("group", BinaryData.FromString("xzy"), WebPubSubDataType.Text, null, false), new { type = "sendToGroup", group = "group", noEcho = false, dataType = "Text", data = "xzy" });
            yield return GetData(new SendToGroupMessage("group", BinaryData.FromObjectAsJson(new JsonData { Value = "xyz"}), WebPubSubDataType.Json, 738476327894, true), new { type = "sendToGroup", group = "group", ackId = 738476327894u, noEcho = true, dataType = "Json", data = new { Value = "xyz" } });
            yield return GetData(new SendToGroupMessage("group", BinaryData.FromBytes(Convert.FromBase64String("eHl6")), WebPubSubDataType.Binary, 738476327894, true), new { type = "sendToGroup", group = "group", ackId = 738476327894u, noEcho = true, dataType = "Binary", data = "eHl6" });
            yield return GetData(new SendToGroupMessage("group", BinaryData.FromBytes(Convert.FromBase64String("eHl6")), WebPubSubDataType.Protobuf, 738476327894, true), new { type = "sendToGroup", group = "group", ackId = 738476327894u, noEcho = true, dataType = "Protobuf", data = "eHl6" });
            yield return GetData(new SendEventMessage("event", BinaryData.FromString("xzy"), WebPubSubDataType.Text, null), new { type = "event", @event = "event", dataType = "Text", data = "xzy" });
            yield return GetData(new SendEventMessage("event", BinaryData.FromObjectAsJson(new JsonData { Value = "xyz" }), WebPubSubDataType.Json, 738476327894), new { type = "event", @event = "event", ackId = 738476327894u,dataType = "Json", data = new { Value = "xyz" } });
            yield return GetData(new SendEventMessage("event", BinaryData.FromBytes(Convert.FromBase64String("eHl6")), WebPubSubDataType.Binary, 738476327894), new { type = "event", @event = "event", ackId = 738476327894u, dataType = "Binary", data = "eHl6" });
            yield return GetData(new SendEventMessage("event", BinaryData.FromBytes(Convert.FromBase64String("eHl6")), WebPubSubDataType.Protobuf, 738476327894), new { type = "event", @event = "event", ackId = 738476327894u, dataType = "Protobuf", data = "eHl6" });
            yield return GetData(new SequenceAckMessage(123), new { type = "sequenceAck", sequenceId = 123 });
            yield return GetData(new SequenceAckMessage(738476327894), new { type = "sequenceAck", sequenceId = 738476327894u });
        }

        [TestCaseSource(nameof(GetParsingTestData))]
        public void ParseMessageTest(byte[] payload, Action<WebPubSubMessage> messageAssert)
        {
            var protocol = new WebPubSubJsonProtocol();
            var resolvedMessage = protocol.ParseMessage(new ReadOnlySequence<byte>(payload));
            messageAssert(resolvedMessage[0]);
        }

        [TestCaseSource(nameof(GetSerializingTestData))]
        public void SerializeMessageTest(WebPubSubMessage message, string serializedPayload)
        {
            var protocol = new WebPubSubJsonProtocol();
            Assert.That(Encoding.UTF8.GetString(protocol.GetMessageBytes(message).ToArray()), Is.EqualTo(serializedPayload));
        }

        [Test]
        public void ProtocolPropertyTest()
        {
            var jsonProtocol = new WebPubSubJsonProtocol();
            Assert.Multiple(() =>
            {
                Assert.That(jsonProtocol.IsReliable, Is.False);
                Assert.That(jsonProtocol.Name, Is.EqualTo("json.webpubsub.azure.v1"));
            });

            var jsonReliableProtocol = new WebPubSubJsonReliableProtocol();
            Assert.Multiple(() =>
            {
                Assert.That(jsonReliableProtocol.IsReliable, Is.True);
                Assert.That(jsonReliableProtocol.Name, Is.EqualTo("json.reliable.webpubsub.azure.v1"));
            });
        }
    }
}
