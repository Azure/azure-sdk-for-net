// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Azure.WebPubSub.Common;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

using SystemJson = System.Text.Json;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class JObjectTests
    {
        [TestCase(nameof(SendToAllAction))]
        [TestCase(nameof(SendToConnectionAction))]
        [TestCase(nameof(SendToGroupAction))]
        [TestCase(nameof(SendToUserAction))]
        [TestCase(nameof(AddConnectionToGroupAction))]
        [TestCase(nameof(AddUserToGroupAction))]
        [TestCase(nameof(RemoveConnectionFromGroupAction))]
        [TestCase(nameof(RemoveUserFromAllGroupsAction))]
        [TestCase(nameof(RemoveUserFromGroupAction))]
        [TestCase(nameof(CloseAllConnectionsAction))]
        [TestCase(nameof(CloseClientConnectionAction))]
        [TestCase(nameof(CloseGroupConnectionsAction))]
        [TestCase(nameof(GrantPermissionAction))]
        [TestCase(nameof(RevokePermissionAction))]
        public void TestOutputConvert(string actionName)
        {
            WebPubSubConfigProvider.RegisterJsonConverter();

            var input = @"{ ""actionName"":""{0}"",""userId"":""user"", ""group"":""group1"",""connectionId"":""connection"",""data"":""test"",""dataType"":""text"", ""reason"":""close"", ""excluded"":[""aa"",""bb""]}";

            var replacedInput = input.Replace("{0}", actionName.Substring(0, actionName.IndexOf("Action")));

            var jObject = JObject.Parse(replacedInput);

            var converted = WebPubSubConfigProvider.ConvertToWebPubSubOperation(jObject);

            Assert.AreEqual(actionName, converted.ActionName.ToString());
        }

        [TestCase(nameof(SendToAllAction))]
        [TestCase(nameof(SendToConnectionAction))]
        [TestCase(nameof(SendToGroupAction))]
        [TestCase(nameof(SendToUserAction))]
        public void TestInvalidSendConvert(string actionName)
        {
            WebPubSubConfigProvider.RegisterJsonConverter();

            var input = @"{ ""actionName"":""{0}"",""userId"":""user"", ""group"":""group1"",""connectionId"":""connection"",""data"": {""type"":""binary"", ""data"": [66, 105, 110, 97, 114, 121, 68, 97, 116, 97]} ,""dataType"":""binary"", ""reason"":""close"", ""excluded"":[""aa"",""bb""]}";

            var replacedInput = input.Replace("{0}", actionName);

            var jObject = JObject.Parse(replacedInput);

            Assert.Throws<ArgumentException>(() => WebPubSubConfigProvider.ConvertToWebPubSubOperation(jObject));
        }

        [TestCase(typeof(SendToAllAction))]
        [TestCase(typeof(SendToConnectionAction))]
        [TestCase(typeof(SendToGroupAction))]
        [TestCase(typeof(SendToUserAction))]
        public void TestValidSendBinaryConvert(Type actionName)
        {
            WebPubSubConfigProvider.RegisterJsonConverter();

            var input = @"{ ""actionName"":""{0}"",""userId"":""user"", ""group"":""group1"",""connectionId"":""connection"",""data"": {""type"":""Buffer"", ""data"": [66, 105, 110, 97, 114, 121, 68, 97, 116, 97]} ,""dataType"":""binary"", ""reason"":""close"", ""excluded"":[""aa"",""bb""]}";

            var replacedInput = input.Replace("{0}", actionName.Name.Substring(0, actionName.Name.IndexOf("Action")));

            var jObject = JObject.Parse(replacedInput);

            var converted = WebPubSubConfigProvider.ConvertToWebPubSubOperation(jObject);

            // Use json format for message value validation.
            Assert.AreEqual("BinaryData", JObject.FromObject(converted)["data"].ToString());
        }

        [TestCase("webpubsuboperation")]
        [TestCase("unknown")]
        public void TestInvalidWebPubSubOperationConvert(string actionName)
        {
            WebPubSubConfigProvider.RegisterJsonConverter();

            var input = @"{ ""actionName"":""{0}"",""userId"":""user"", ""group"":""group1"",""connectionId"":""connection"",""data"":""test"",""dataType"":""text"", ""reason"":""close"", ""excluded"":[""aa"",""bb""]}";

            var replacedInput = input.Replace("{0}", actionName);

            var jObject = JObject.Parse(replacedInput);

            // Throws excpetion of not able to de-serialize to abstract class.
            var ex = Assert.Throws<ArgumentException>(() => WebPubSubConfigProvider.ConvertToWebPubSubOperation(jObject));
            Assert.AreEqual($"Not supported WebPubSubOperation: {actionName}.", ex.Message);
        }

        [TestCase]
        public void TestBinaryDataConverter_String()
        {
            WebPubSubConfigProvider.RegisterJsonConverter();

            var input = @"{ actionName : ""sendToAll"", dataType: ""text"", data: ""2""}";

            var converted = JObject.Parse(input).ToObject<SendToAllAction>();

            Assert.AreEqual("2", converted.Data.ToString());
        }

        [TestCase]
        public void TestBinaryDataConverter_NonStringThrows()
        {
            WebPubSubConfigProvider.RegisterJsonConverter();

            var input = @"{ actionName : ""sendToAll"", dataType: ""text"", data: 2}";

            Assert.Throws<ArgumentException>(() => JObject.Parse(input).ToObject<SendToAllAction>(), "Message data should be string, please stringify object.");
        }

        [TestCase]
        public void TestBinaryDataConvertFromByteArray_SystemJson()
        {
            var testData = @"{""type"":""Buffer"", ""data"": [66, 105, 110, 97, 114, 121, 68, 97, 116, 97]}";

            var options = new SystemJson.JsonSerializerOptions();
            options.Converters.Add(new System.BinaryDataJsonConverter());

            var converted = SystemJson.JsonSerializer.Deserialize<BinaryData>(testData, options);

            Assert.AreEqual("BinaryData", converted.ToString());
        }

        [TestCase]
        public void TestBinaryDataConvertFromByteArray_Newtonsoft()
        {
            WebPubSubConfigProvider.RegisterJsonConverter();
            var testData = @"{""type"":""Buffer"", ""data"": [66, 105, 110, 97, 114, 121, 68, 97, 116, 97]}";

            var converted = JObject.Parse(testData).ToObject<BinaryData>();

            Assert.AreEqual("BinaryData", converted.ToString());
        }

        [TestCase]
        public async Task ParseErrorResponse()
        {
            var test = @"{""code"":""unauthorized"",""errorMessage"":""not valid user.""}";

            var result = BuildResponse(test, RequestType.Connect);
            Assert.NotNull(result);
            Assert.AreEqual(HttpStatusCode.Unauthorized, result.StatusCode);

            var stateExist = result.Headers.TryGetValues(Constants.Headers.CloudEvents.State, out var states);
            Assert.False(stateExist);
            var message = await result.Content.ReadAsStringAsync();
            Assert.AreEqual("not valid user.", message);
        }

        [TestCase]
        public async Task ParseConnectResponse_JSInvalidStatesNotMerge()
        {
            var test = @"{""userId"":""aaa"", ""states"": ""a""}";

            var result = BuildResponse(test, RequestType.Connect, true);

            Assert.NotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

            var stateExist = result.Headers.TryGetValues(Constants.Headers.CloudEvents.State, out var value);
            Assert.True(stateExist);
            var states = value.SingleOrDefault().DecodeConnectionStates();
            Assert.NotNull(states);
            Assert.AreEqual(1, states.Count);
            Assert.True(states.ContainsKey("testKey"));

            var response = await result.Content.ReadAsStringAsync();
            var message = (JObject.Parse(response)).ToObject<ConnectEventResponse>();
            Assert.AreEqual("aaa", message.UserId);
        }

        [TestCase]
        public async Task ParseConnectResponseWithValidStates()
        {
            var test = @"{""userId"":""aaa"", ""states"": { ""a"": ""b"", ""a"": ""c"" }}";

            var result = BuildResponse(test, RequestType.Connect, false);

            Assert.NotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

            var stateExist = result.Headers.TryGetValues(Constants.Headers.CloudEvents.State, out var value);
            Assert.True(stateExist);
            var states = value.SingleOrDefault().DecodeConnectionStates();
            Assert.True(states.ContainsKey("a"));

            var response = await result.Content.ReadAsStringAsync();
            var message = (JObject.Parse(response)).ToObject<ConnectEventResponse>();
            Assert.AreEqual("aaa", message.UserId);
        }

        [TestCase]
        public async Task ParseMessageResponse()
        {
            var test = @"{""data"":""test"", ""dataType"":""text""}";

            var result = BuildResponse(test, RequestType.User);

            Assert.NotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

            var message = await result.Content.ReadAsStringAsync();
            Assert.AreEqual("test", message);
            Assert.AreEqual(Constants.ContentTypes.PlainTextContentType, result.Content.Headers.ContentType.MediaType);
        }

        [TestCase]
        public void ParseMessageResponse_InvalidReturnNull()
        {
            var test = @"{""message"":""test"", ""dataType"":""hello""}";

            var result = BuildResponse(test, RequestType.User);

            Assert.Null(result);
        }

        [TestCase]
        public async Task ParseConnectResponse_ContentMatches()
        {
            var test = @"{""test"":""test"",""errorMessage"":""not valid user.""}";
            var expected = JObject.Parse(test);

            var result = BuildResponse(test, RequestType.Connect);
            var content = await result.Content.ReadAsStringAsync();
            var actual = JObject.Parse(content);

            Assert.NotNull(result);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void TestWebPubSubContext_ConnectedEvent()
        {
            var context = new WebPubSubConnectionContext(connectionId: "connectionId", userId: "userA", eventName: "connected", eventType: WebPubSubEventType.System, hub: null);
            var test = new WebPubSubContext(new ConnectedEventRequest(context));

            var serialize = JObject.FromObject(test);

            Assert.NotNull(serialize["request"]);
            Assert.NotNull(serialize["response"]);
            Assert.AreEqual("", serialize["errorMessage"].ToString());
            Assert.AreEqual("False", serialize["hasError"].ToString());
            Assert.AreEqual("False", serialize["isPreflight"].ToString());
        }

        [TestCase]
        public void TestWebPubSubContext_ConnectEvent()
        {
            var context = new WebPubSubConnectionContext(connectionId: "connectionId", userId: "userA", eventName: "connected", eventType: WebPubSubEventType.System, hub: null);

            var claims = new Dictionary<string, string[]>
            {
                { "aa", new string[]{"aa1, aa2"} },
                { "bb", new string[]{"bb, bb2"} },
            };
            var subprotocol = new string[] { "sub1", "sub2" };
            var test = new WebPubSubContext(new ConnectEventRequest(context, claims, null, subprotocol, null));

            var serialize = JObject.FromObject(test);
            var request = serialize["request"];

            Assert.NotNull(request);
            Assert.AreEqual(subprotocol, request["subprotocols"].ToObject<string[]>());
            Assert.NotNull(serialize["response"]);
            Assert.AreEqual("", serialize["errorMessage"].ToString());
            Assert.AreEqual("False", serialize["hasError"].ToString());
            Assert.AreEqual("False", serialize["isPreflight"].ToString());
        }

        [TestCase]
        public void TestWebPubSubContext_UserEvent()
        {
            var context = new WebPubSubConnectionContext(connectionId: "connectionId", userId: "userA", eventName: "connected", eventType: WebPubSubEventType.System, hub: null);
            var test = new WebPubSubContext(new UserEventRequest(context, BinaryData.FromString("test"), WebPubSubDataType.Text));

            var serialize = JObject.FromObject(test);
            var request = serialize["request"];

            Assert.NotNull(request);
            Assert.AreEqual("test", request["data"].ToString());
            Assert.NotNull(serialize["response"]);
            Assert.AreEqual("", serialize["errorMessage"].ToString());
            Assert.AreEqual("False", serialize["hasError"].ToString());
            Assert.AreEqual("False", serialize["isPreflight"].ToString());
        }

        [TestCase]
        public void TestWebPubSubContext_DisconnectedEvent()
        {
            var test = new WebPubSubContext(new DisconnectedEventRequest(null, "dropped"));

            var serialize = JObject.FromObject(test);
            var request = serialize["request"];

            Assert.NotNull(request);
            Assert.AreEqual("dropped", request["reason"].ToString());
            Assert.NotNull(serialize["response"]);
            Assert.AreEqual("", serialize["errorMessage"].ToString());
            Assert.AreEqual("False", serialize["hasError"].ToString());
            Assert.AreEqual("False", serialize["isPreflight"].ToString());
        }

        [TestCase]
        public void TestWebPubSubContext_ErrorResponse()
        {
            var test = new WebPubSubContext("Invalid Request", WebPubSubErrorCode.UserError);

            var serialize = JObject.FromObject(test);
            var response = serialize["response"];

            Assert.Null(serialize["request"]);
            Assert.NotNull(response);
            Assert.AreEqual("400", response["status"].ToString());
            Assert.AreEqual("Invalid Request", response["body"].ToString());
            Assert.AreEqual("Invalid Request", serialize["errorMessage"].ToString());
            Assert.AreEqual("True", serialize["hasError"].ToString());
            Assert.AreEqual("False", serialize["isPreflight"].ToString());
        }

        [TestCase]
        public void TestWebPubSubConnectionJsonSerialize()
        {
            var baseUrl = "wss://webpubsub.azure.com/";
            var accessToken = "test-token";
            var url = $"{baseUrl}?access_token={accessToken}";
            var connection = new WebPubSubConnection(new Uri(url));

            var json = JObject.FromObject(connection);

            Assert.AreEqual(baseUrl, json["baseUrl"].ToString());
            Assert.AreEqual(accessToken, json["accessToken"].ToString());
            Assert.AreEqual(url, json["url"].ToString());
        }

        [TestCase]
        public void TestWebPubSubContext_UserEventStates_Legacy()
        {
            WebPubSubConfigProvider.RegisterJsonConverter();
            var states =
                new Dictionary<string, object>
                {
                    { "aKey", "aValue"},
                    { "bKey", 123 },
                    { "cKey", new StateTestClass() }
                }
                .EncodeConnectionStates()
                .DecodeConnectionStates();

            // Use the Dictionary<string, object> states .ctor overload
            var context = new WebPubSubConnectionContext(
                eventType: WebPubSubEventType.System,
                eventName: "connected",
                hub: null,
                connectionId: "connectionId",
                userId: "userA",
                signature: null,
                origin: null,
                states: states,
                headers: null);
            var test = new WebPubSubContext(new UserEventRequest(context, BinaryData.FromString("test"), WebPubSubDataType.Text));

            var jObj = JObject.FromObject(test);
            var request = jObj["request"];

            Assert.NotNull(request);
            Assert.AreEqual("test", request["data"].ToString());
            Assert.NotNull(jObj["response"]);
            Assert.AreEqual("", jObj["errorMessage"].ToString());
            Assert.AreEqual("False", jObj["hasError"].ToString());
            Assert.AreEqual("False", jObj["isPreflight"].ToString());

            var context1 = request["connectionContext"];
            Assert.NotNull(context1);
            var states1 = context1["states"].ToObject<IReadOnlyDictionary<string, object>>();
            Assert.NotNull(states1);
            Assert.AreEqual("aValue", states1["aKey"]);
            Assert.NotNull(states1);
            Assert.AreEqual(123, states1["bKey"]);
        }

        [TestCase]
        public void TestWebPubSubContext_UserEventStates()
        {
            WebPubSubConfigProvider.RegisterJsonConverter();
            var states =
                new Dictionary<string, object>
                {
                    { "aKey", "aValue"},
                    { "bKey", 123 },
                    { "cKey", new StateTestClass() }
                }
                .EncodeConnectionStates()
                .DecodeConnectionStates()
                .ToDictionary(p => p.Key, p => (string)p.Value);

            // Use the Dictionary<string, JsonElement> connectionStates .ctor overload
            var context = new WebPubSubConnectionContext(
                eventType: WebPubSubEventType.System,
                eventName: "connected",
                hub: null,
                connectionId: "connectionId",
                userId: "userA",
                connectionStates: states);
            var test = new WebPubSubContext(new UserEventRequest(context, BinaryData.FromString("test"), WebPubSubDataType.Text));

            var jObj = JObject.FromObject(test);
            var request = jObj["request"];

            Assert.NotNull(request);
            Assert.AreEqual("test", request["data"].ToString());
            Assert.NotNull(jObj["response"]);
            Assert.AreEqual("", jObj["errorMessage"].ToString());
            Assert.AreEqual("False", jObj["hasError"].ToString());
            Assert.AreEqual("False", jObj["isPreflight"].ToString());

            var context1 = request["connectionContext"];
            Assert.NotNull(context1);
            var states1 = context1["states"].ToObject<IReadOnlyDictionary<string, object>>();
            Assert.NotNull(states1);
            Assert.AreEqual("aValue", states1["aKey"]);
            Assert.NotNull(states1);
            Assert.AreEqual(123, states1["bKey"]);
        }

        [TestCase]
        public void TestWebPubSubContext_UserEventStates_AllJsonElement()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new WebPubSubConnectionContext(
                    eventType: WebPubSubEventType.System,
                    eventName: "connected",
                    hub: null,
                    connectionId: "connectionId",
                    userId: "userA",
                    signature: null,
                    origin: null,
                    states: new Dictionary<string, object>
                    {
                        { "aKey", "aValue"},
                        { "bKey", 123 },
                        { "cKey", new StateTestClass() }
                    },
                    headers: null));
            Assert.AreEqual("states", ex.ParamName);
            StringAssert.Contains("string", ex.Message);
        }

        [TestCase]
        public void TestWebPubSubContext_UserEventStates_NotDoubleSerialized()
        {
            WebPubSubConfigProvider.RegisterJsonConverter();
            var states =
                new Dictionary<string, object>
                {
                    { "aKey", "aValue"},
                    { "bKey", 123 },
                    { "cKey", new StateTestClass() }
                }
                .EncodeConnectionStates()
                .DecodeConnectionStates()
                .ToDictionary(p => p.Key, p => (string)p.Value);
            string json = JsonSerializer.Serialize(
                new WebPubSubConnectionContext(
                    eventType: WebPubSubEventType.System,
                    eventName: "connected",
                    hub: null,
                    connectionId: "connectionId",
                    userId: "userA",
                    connectionStates: states));
            var jCtx = JObject.Parse(json);
            Assert.AreEqual("aValue", jCtx["states"]["aKey"].Value<string>());
            Assert.AreEqual(123, jCtx["states"]["bKey"].Value<int>());
            Assert.AreEqual("GA", jCtx["states"]["cKey"]["Title"].Value<string>());
            Assert.AreEqual(1, jCtx["states"]["cKey"]["Version"].Value<int>());
        }

        [TestCase]
        public void TestWebPubSubContext_UserEventStates_CollectionsInSync()
        {
            WebPubSubConfigProvider.RegisterJsonConverter();
            var states =
                new Dictionary<string, object>
                {
                    { "aKey", "aValue"},
                    { "bKey", 123 },
                    { "cKey", new StateTestClass() }
                }
                .EncodeConnectionStates()
                .DecodeConnectionStates()
                .ToDictionary(p => p.Key, p => (string)p.Value);
            var ctx = new WebPubSubConnectionContext(
                eventType: WebPubSubEventType.System,
                eventName: "connected",
                hub: null,
                connectionId: "connectionId",
                userId: "userA",
                connectionStates: states);
            CollectionAssert.AreEquivalent(ctx.ConnectionStates.Keys, ctx.States.Keys);
            Assert.AreEqual(ctx.ConnectionStates["aKey"], ctx.States["aKey"]);
            Assert.AreEqual(ctx.ConnectionStates["bKey"], ctx.States["bKey"]);
            Assert.AreEqual(ctx.ConnectionStates["cKey"], ctx.States["cKey"]);
        }

        private static HttpResponseMessage BuildResponse(string input, RequestType requestType, bool hasTestStates = false)
        {
            Dictionary<string, object> states = null;
            if (hasTestStates)
            {
                states =
                    new Dictionary<string, object>
                    {
                        { "testKey", "value1" },
                    }
                    .EncodeConnectionStates().DecodeConnectionStates(); // Required now that we enforce string
            }
            var context = new WebPubSubConnectionContext(WebPubSubEventType.System, "connect", "testhub", "Connection-Id1", states: states, userId: null, signature: null, origin: null, headers: null);
            return Utilities.BuildValidResponse(input, requestType, context);
        }

        private sealed class StateTestClass
        {
            public DateTime Timestamp { get; set; }

            public string Title { get; set; }

            public int Version { get; set; }

            public StateTestClass()
            {
                Timestamp = DateTime.Parse("2021-11-10");
                Title = "GA";
                Version = 1;
            }

            public StateTestClass(DateTime timestamp, string title, int version)
            {
                Timestamp = timestamp;
                Title = title;
                Version = version;
            }
        }
    }
}
