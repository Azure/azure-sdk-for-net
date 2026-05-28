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
                Assert.True(message is AckMessage);
                var ackMessage = message as AckMessage;
                Assert.AreEqual(123u, ackMessage.AckId);
                Assert.True(ackMessage.Success);
                Assert.Null(ackMessage.Error);
            });
            yield return GetData(new { type = "ack", ackId = 123, success = false, error = new { name = "Forbidden", message = "message"} }, message =>
            {
                Assert.True(message is AckMessage);
                var ackMessage = message as AckMessage;
                Assert.AreEqual(123u, ackMessage.AckId);
                Assert.False(ackMessage.Success);
                Assert.AreEqual("Forbidden", ackMessage.Error.Name);
                Assert.AreEqual("message", ackMessage.Error.Message);
            });
            yield return GetData(new { sequenceId = 738476327894u, type = "message", from = "group", group = "groupname", dataType = "text", data = "xyz", fromUserId = "user" }, message =>
            {
                Assert.True(message is GroupDataMessage);
                var groupDataMessage = message as GroupDataMessage;
                Assert.AreEqual("groupname", groupDataMessage.Group);
                Assert.AreEqual(738476327894u, groupDataMessage.SequenceId);
                Assert.AreEqual(WebPubSubDataType.Text, groupDataMessage.DataType);
                Assert.AreEqual("user", groupDataMessage.FromUserId);
                Assert.AreEqual("xyz", groupDataMessage.Data.ToString());
            });
            yield return GetData(new { type = "message", from = "group", group = "groupname", dataType = "json", data = new JsonData { Value = "xyz" } }, message =>
            {
                Assert.True(message is GroupDataMessage);
                var groupDataMessage = message as GroupDataMessage;
                Assert.AreEqual("groupname", groupDataMessage.Group);
                Assert.Null(groupDataMessage.SequenceId);
                Assert.AreEqual(WebPubSubDataType.Json, groupDataMessage.DataType);
                var obj = groupDataMessage.Data.ToObjectFromJson<JsonData>();
                Assert.AreEqual("xyz", obj.Value);
            });
            yield return GetData(new { type = "message", from = "group", group = "groupname", dataType = "binary", data = "eHl6" }, message =>
            {
                Assert.True(message is GroupDataMessage);
                var groupDataMessage = message as GroupDataMessage;
                Assert.AreEqual("groupname", groupDataMessage.Group);
                Assert.Null(groupDataMessage.SequenceId);
                Assert.AreEqual(WebPubSubDataType.Binary, groupDataMessage.DataType);
                Assert.AreEqual("eHl6", Convert.ToBase64String(groupDataMessage.Data.ToArray()));
            });
            yield return GetData(new { sequenceId = 738476327894u, type = "message", from = "server", dataType = "text", data = "xyz" }, message =>
            {
                Assert.True(message is ServerDataMessage);
                var dataMessage = message as ServerDataMessage;
                Assert.AreEqual(738476327894u, dataMessage.SequenceId);
                Assert.AreEqual(WebPubSubDataType.Text, dataMessage.DataType);
                Assert.AreEqual("xyz", dataMessage.Data.ToString());
            });
            yield return GetData(new { type = "message", from = "server", dataType = "json", data = new JsonData { Value = "xyz" } }, message =>
            {
                Assert.True(message is ServerDataMessage);
                var dataMessage = message as ServerDataMessage;;
                Assert.Null(dataMessage.SequenceId);
                Assert.AreEqual(WebPubSubDataType.Json, dataMessage.DataType);
                var obj = dataMessage.Data.ToObjectFromJson<JsonData>();
                Assert.AreEqual("xyz", obj.Value);
            });
            yield return GetData(new { type = "message", from = "server", dataType = "binary", data = "eHl6" }, message =>
            {
                Assert.True(message is ServerDataMessage);
                var dataMessage = message as ServerDataMessage;
                Assert.Null(dataMessage.SequenceId);
                Assert.AreEqual(WebPubSubDataType.Binary, dataMessage.DataType);
                Assert.AreEqual("eHl6", Convert.ToBase64String(dataMessage.Data.ToArray()));
            });
            yield return GetData(new { type = "system", @event = "connected", userId = "user", connectionId = "connection" }, message =>
            {
                Assert.True(message is ConnectedMessage);
                var connectedMessage = message as ConnectedMessage;
                Assert.AreEqual("user", connectedMessage.UserId);
                Assert.AreEqual("connection", connectedMessage.ConnectionId);
                Assert.Null(connectedMessage.ReconnectionToken);
            });
            yield return GetData(new { type = "system", @event = "connected", userId = "user", connectionId = "connection", reconnectionToken = "rec" }, message =>
            {
                Assert.True(message is ConnectedMessage);
                var connectedMessage = message as ConnectedMessage;
                Assert.AreEqual("user", connectedMessage.UserId);
                Assert.AreEqual("connection", connectedMessage.ConnectionId);
                Assert.AreEqual("rec", connectedMessage.ReconnectionToken);
            });
            yield return GetData(new { type = "system", @event = "disconnected", message = "msg" }, message =>
            {
                Assert.True(message is DisconnectedMessage);
                var disconnectedMessage = message as DisconnectedMessage;
                Assert.AreEqual("msg", disconnectedMessage.Reason);
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
            Assert.AreEqual(serializedPayload, Encoding.UTF8.GetString(protocol.GetMessageBytes(message).ToArray()));
        }

        [Test]
        public void ProtocolPropertyTest()
        {
            var jsonProtocol = new WebPubSubJsonProtocol();
            Assert.False(jsonProtocol.IsReliable);
            Assert.AreEqual("json.webpubsub.azure.v1", jsonProtocol.Name);

            var jsonReliableProtocol = new WebPubSubJsonReliableProtocol();
            Assert.True(jsonReliableProtocol.IsReliable);
            Assert.AreEqual("json.reliable.webpubsub.azure.v1", jsonReliableProtocol.Name);
        }
    }
}
