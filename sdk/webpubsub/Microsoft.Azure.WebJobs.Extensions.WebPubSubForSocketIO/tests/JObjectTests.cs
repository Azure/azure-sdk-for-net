// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebPubSub.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

using SystemJson = System.Text.Json;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Tests
{
    public class JObjectTests
    {
        public JObjectTests()
        {
            WebPubSubForSocketIOConfigProvider.RegisterJsonConverter();
        }

        [TestCase(nameof(SendToNamespaceAction))]
        [TestCase(nameof(SendToRoomsAction))]
        [TestCase(nameof(SendToSocketAction))]
        [TestCase(nameof(AddSocketToRoomAction))]
        [TestCase(nameof(RemoveSocketFromRoomAction))]
        [TestCase(nameof(DisconnectSocketsAction))]
        public void TestOutputConvert(string actionName)
        {
            var input = @"{ ""actionName"":""{0}"",""namespace"":""ns"", ""data"":[""test""]}";

            var replacedInput = input.Replace("{0}", actionName.Substring(0, actionName.IndexOf("Action")));

            var jObject = JObject.Parse(replacedInput);

            var converted = WebPubSubForSocketIOConfigProvider.ConvertToSocketIOAction(jObject);

            Assert.That(converted.ActionName.ToString(), Is.EqualTo(actionName));
        }

        [TestCase("SocketIOAction")]
        [TestCase("unknown")]
        public void TestInvalidSocketIOActionConvert(string actionName)
        {
            var input = @"{ ""actionName"":""{0}"",""userId"":""user"", ""group"":""group1"",""connectionId"":""connection"",""data"":""test"",""dataType"":""text"", ""reason"":""close"", ""excluded"":[""aa"",""bb""]}";

            var replacedInput = input.Replace("{0}", actionName);

            var jObject = JObject.Parse(replacedInput);

            // Throws excpetion of not able to de-serialize to abstract class.
            var ex = Assert.Throws<ArgumentException>(() => WebPubSubForSocketIOConfigProvider.ConvertToSocketIOAction(jObject));
            Assert.That(ex.Message, Is.EqualTo($"Not supported SocketIOAction: {actionName}."));
        }

        [TestCase]
        public void TestSendToNamespace_Valid()
        {
            var input = @"{ actionName : ""sendToNamespace"", eventName: ""event"", parameters: [""data1"", ""data2""]}";
            var converted = (SendToNamespaceAction)WebPubSubForSocketIOConfigProvider.ConvertToSocketIOAction(JObject.Parse(input));

            Assert.Multiple(() =>
            {
                Assert.That(converted.EventName, Is.EqualTo("event"));
                Assert.That(converted.Parameters[0], Is.EqualTo("data1"));
                Assert.That(converted.Parameters[1], Is.EqualTo("data2"));
            });
        }

        [TestCase]
        public void TestSendToNamespace_ValidComplexData()
        {
            var input = @"{ actionName : ""sendToNamespace"",  eventName: ""event"", parameters: [1, ""2"", {""a"":true}]}";
            var converted = (SendToNamespaceAction)WebPubSubForSocketIOConfigProvider.ConvertToSocketIOAction(JObject.Parse(input));

            Assert.Multiple(() =>
            {
                Assert.That(converted.EventName, Is.EqualTo("event"));
                Assert.That(converted.Parameters[0], Is.EqualTo(1));
                Assert.That(converted.Parameters[1], Is.EqualTo("2"));
                Assert.That((bool)((JObject)converted.Parameters[2])["a"], Is.EqualTo(true));
            });
        }

        [TestCase]
        public void TestSendToNamespace_InvalidData()
        {
            var input = @"{ actionName : ""sendToNamespace"",  eventName: ""event"", parameters: 2}";
            var jObject = JObject.Parse(input);

            Assert.Throws<ArgumentException>(() => WebPubSubForSocketIOConfigProvider.ConvertToSocketIOAction(jObject));
        }

        [TestCase]
        public void TestSendToRooms_Valid()
        {
            var input = @"{ actionName : ""sendToRooms"", rooms: [""rma"", ""rmb""], eventName: ""event"", parameters: [1, ""2"", {""a"":true}]}";
            var converted = (SendToRoomsAction)WebPubSubForSocketIOConfigProvider.ConvertToSocketIOAction(JObject.Parse(input));

            Assert.Multiple(() =>
            {
                Assert.That(converted.EventName, Is.EqualTo("event"));
                Assert.That(converted.Rooms[0], Is.EqualTo("rma"));
                Assert.That(converted.Rooms[1], Is.EqualTo("rmb"));
                Assert.That(converted.Parameters[0], Is.EqualTo(1));
                Assert.That(converted.Parameters[1], Is.EqualTo("2"));
                Assert.That((bool)((JObject)converted.Parameters[2])["a"], Is.EqualTo(true));
            });
        }

        [TestCase]
        public void TestSendToRooms_InvalidRoom()
        {
            var input = @"{ actionName : ""sendToRooms"", rooms: ""abc"", eventName: ""event"", parameters: [""data1"", ""data2""]}";
            var jObject = JObject.Parse(input);
            Assert.Throws<ArgumentException>(() => WebPubSubForSocketIOConfigProvider.ConvertToSocketIOAction(jObject));
        }

        [TestCase]
        public void TestSendToSocket_Valid()
        {
            var input = @"{ actionName : ""sendToSocket"", socketId: ""sid"", eventName: ""event"", parameters: [""data1"", ""data2""]}";
            var converted = (SendToSocketAction)WebPubSubForSocketIOConfigProvider.ConvertToSocketIOAction(JObject.Parse(input));

            Assert.Multiple(() =>
            {
                Assert.That(converted.EventName, Is.EqualTo("event"));
                Assert.That(converted.SocketId, Is.EqualTo("sid"));
                Assert.That(converted.Parameters[0], Is.EqualTo("data1"));
                Assert.That(converted.Parameters[1], Is.EqualTo("data2"));
            });
        }

        [TestCase]
        public void AddSocketToRoom_Valid()
        {
            var input = @"{ actionName : ""addSocketToRoom"", socketId: ""sid"", room: ""rm1"", namespace: ""ns""}";
            var converted = (AddSocketToRoomAction)WebPubSubForSocketIOConfigProvider.ConvertToSocketIOAction(JObject.Parse(input));

            Assert.Multiple(() =>
            {
                Assert.That(converted.SocketId, Is.EqualTo("sid"));
                Assert.That(converted.Room, Is.EqualTo("rm1"));
                Assert.That(converted.Namespace, Is.EqualTo("ns"));
            });
        }

        [TestCase]
        public void RemoveSocketFromRoom_Valid()
        {
            var input = @"{ actionName : ""removeSocketFromRoom"", socketId: ""sid"", room: ""rm1"", namespace: ""ns""}";
            var converted = (RemoveSocketFromRoomAction)WebPubSubForSocketIOConfigProvider.ConvertToSocketIOAction(JObject.Parse(input));

            Assert.Multiple(() =>
            {
                Assert.That(converted.SocketId, Is.EqualTo("sid"));
                Assert.That(converted.Room, Is.EqualTo("rm1"));
                Assert.That(converted.Namespace, Is.EqualTo("ns"));
            });
        }

        [TestCase]
        public void DisconnectSocket_Valid()
        {
            var input = @"{ actionName : ""disconnectSockets"", rooms: [ ""rm1"", ""rm2""], namespace: ""ns""}";
            var converted = (DisconnectSocketsAction)WebPubSubForSocketIOConfigProvider.ConvertToSocketIOAction(JObject.Parse(input));

            Assert.Multiple(() =>
            {
                Assert.That(converted.Namespace, Is.EqualTo("ns"));
                Assert.That(converted.Rooms[0], Is.EqualTo("rm1"));
                Assert.That(converted.Rooms[1], Is.EqualTo("rm2"));
            });
        }
    }
}
