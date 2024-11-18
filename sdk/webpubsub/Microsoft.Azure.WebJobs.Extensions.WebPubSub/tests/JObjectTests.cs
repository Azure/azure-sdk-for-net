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

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class JObjectTests
    {
        public JObjectTests()
        {
            WebPubSubConfigProvider.RegisterJsonConverter();
        }

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
            var input = @"{ actionName : ""sendToAll"", dataType: ""text"", data: ""2""}";

            var converted = JObject.Parse(input).ToObject<SendToAllAction>();

            Assert.AreEqual("2", converted.Data.ToString());
        }

        [TestCase]
        public void TestBinaryDataConverter_NonStringThrows()
        {
            var input = @"{ actionName : ""sendToAll"", dataType: ""text"", data: 2}";

            Assert.Throws<ArgumentException>(() => JObject.Parse(input).ToObject<SendToAllAction>(), "Message data should be string, please stringify object.");
        }

        [TestCase]
        public void TestBinaryDataConvertFromByteArray_Newtonsoft()
        {
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

        [TestCase(@"""binary""", Constants.ContentTypes.BinaryContentType)]
        [TestCase("0", Constants.ContentTypes.BinaryContentType)]
        [TestCase(@"""Json""", Constants.ContentTypes.JsonContentType)]
        [TestCase("1", Constants.ContentTypes.JsonContentType)]
        [TestCase(@"""text""", Constants.ContentTypes.PlainTextContentType)]
        [TestCase("2", Constants.ContentTypes.PlainTextContentType)]
        public async Task ParseMessageResponse(string dataType, string expectContentType)
        {
            var test = @"{""data"":""test"", ""dataType"":{0}}";
            test = test.Replace("{0}", dataType);

            var result = BuildResponse(test, RequestType.User);

            Assert.NotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

            var message = await result.Content.ReadAsStringAsync();
            Assert.AreEqual("test", message);
            Assert.AreEqual(expectContentType, result.Content.Headers.ContentType.MediaType);
        }

        [TestCase]
        public void ParseMessageResponse_InvalidJArrayReturnServerError()
        {
            // serialize agagin to stringify.
            var test = @"[""test"", ""dataType"", ""text""]";

            var result = BuildResponse(test, RequestType.User);

            Assert.NotNull(result);
            Assert.AreEqual(HttpStatusCode.InternalServerError, result.StatusCode);
        }

        [TestCase]
        public void ParseMessageResponse_InvalidEnumReturnServerError()
        {
            // datatype not valid.
            var test = @"{""data"":""test"", ""dataType"":""hello""}";

            var result = BuildResponse(test, RequestType.User);

            Assert.NotNull(result);
            Assert.AreEqual(HttpStatusCode.InternalServerError, result.StatusCode);
        }

        [TestCase]
        public async Task ParseConnectResponse_ContentMatches()
        {
            var test = @"{""test"":""test"",""errorMessage"":""not valid user.""}";
            var expected = JObject.FromObject(JsonConvert.DeserializeObject<ConnectEventResponse>(test));

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
            Assert.AreEqual(null, serialize["errorMessage"].Value<string>());
            Assert.AreEqual(false, serialize["hasError"].Value<bool>());
            Assert.AreEqual(false, serialize["isPreflight"].Value<bool>());
            Assert.AreEqual("System", serialize["request"]["connectionContext"]["eventType"].Value<string>());
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
            Assert.AreEqual(null, serialize["errorMessage"].Value<string>());
            Assert.AreEqual(false, serialize["hasError"].Value<bool>());
            Assert.AreEqual(false, serialize["isPreflight"].Value<bool>());
        }

        [TestCase]
        public void TestWebPubSubContext_UserEvent()
        {
            var context = new WebPubSubConnectionContext(connectionId: "connectionId", userId: "userA", eventName: "connected", eventType: WebPubSubEventType.System, hub: null);
            var test = new WebPubSubContext(new UserEventRequest(context, BinaryData.FromString("test"), WebPubSubDataType.Text));

            var serialize = JObject.FromObject(test);
            var request = serialize["request"];

            Assert.NotNull(request);
            Assert.AreEqual("test", request["data"].Value<string>());
            Assert.NotNull(serialize["response"]);
            Assert.AreEqual(null, serialize["errorMessage"].Value<string>());
            Assert.AreEqual(false, serialize["hasError"].Value<bool>());
            Assert.AreEqual(false, serialize["isPreflight"].Value<bool>());
        }

        [TestCase]
        public void TestWebPubSubContext_DisconnectedEvent()
        {
            var test = new WebPubSubContext(new DisconnectedEventRequest(null, "dropped"));

            var serialize = JObject.FromObject(test);
            var request = serialize["request"];

            Assert.NotNull(request);
            Assert.AreEqual("dropped", request["reason"].Value<string>());
            Assert.NotNull(serialize["response"]);
            Assert.AreEqual(null, serialize["errorMessage"].Value<string>());
            Assert.AreEqual(false, serialize["hasError"].Value<bool>());
            Assert.AreEqual(false, serialize["isPreflight"].Value<bool>());
        }

        [TestCase]
        public void TestWebPubSubContext_ErrorResponse()
        {
            var test = new WebPubSubContext("Invalid Request", WebPubSubErrorCode.UserError);

            var serialize = JObject.FromObject(test);
            var response = serialize["response"];

            Assert.Null(serialize["request"]);
            Assert.NotNull(response);
            Assert.AreEqual(400, response["status"].Value<int>());
            Assert.AreEqual("Invalid Request", response["body"].Value<string>());
            Assert.AreEqual("Invalid Request", serialize["errorMessage"].Value<string>());
            Assert.AreEqual(true, serialize["hasError"].Value<bool>());
            Assert.AreEqual(false, serialize["isPreflight"].Value<bool>());
        }

        [TestCase]
        public void TestWebPubSubConnectionJsonSerialize()
        {
            var baseUrl = "wss://webpubsub.azure.com/";
            var accessToken = "test-token";
            var url = $"{baseUrl}?access_token={accessToken}";
            var connection = new WebPubSubConnection(new Uri(url));

            var json = JObject.FromObject(connection);

            Assert.AreEqual(baseUrl, json["baseUrl"].Value<Uri>().ToString());
            Assert.AreEqual(accessToken, json["accessToken"].Value<string>());
            Assert.AreEqual(url, json["url"].Value<Uri>().ToString());
        }

        [TestCase]
        public void TestWebPubSubContext_UserEventStates_Legacy()
        {
            var states =
                new Dictionary<string, object>
                {
                    { "aKey", "aValue"},
                    { "bKey", 123 },
                    { "cKey", new StateTestClass() }
                };

            // Use the Dictionary<string, object> states .ctor overload
            var context = new WebPubSubConnectionContext(
                WebPubSubEventType.System,
                "connected",
                "hub",
                "connectionId",
                "userA",
                null,
                null,
                states,
                null);
            var test = new WebPubSubContext(new UserEventRequest(context, BinaryData.FromString("test"), WebPubSubDataType.Text));

            var jObj = JObject.FromObject(test);
            var request = jObj["request"];

            Assert.NotNull(request);
            Assert.AreEqual("test", request["data"].Value<string>());
            Assert.NotNull(jObj["response"]);
            Assert.AreEqual(null, jObj["errorMessage"].Value<string>());
            Assert.AreEqual(false, jObj["hasError"].Value<bool>());
            Assert.AreEqual(false, jObj["isPreflight"].Value<bool>());

            var context1 = request["connectionContext"];
            Assert.NotNull(context1);
            var states1 = context1["states"];
            Assert.NotNull(states1);
            Assert.AreEqual("\"aValue\"", states1["aKey"].Value<string>());
            Assert.NotNull(states1);
            Assert.AreEqual(123, states1["bKey"].Value<int>());
        }

        [TestCase]
        public void TestWebPubSubContext_UserEventStates()
        {
            var states =
                new Dictionary<string, object>
                {
                    { "aKey", "aValue"},
                    { "bKey", 123 },
                    { "cKey", new StateTestClass() }
                }.EncodeConnectionStates().DecodeConnectionStates().ToDictionary(p => p.Key, p => (BinaryData)p.Value);

            // Use the Dictionary<string, BinaryData> connectionStates .ctor overload
            var context = new WebPubSubConnectionContext(
                eventType: WebPubSubEventType.System,
                eventName: "connected",
                hub: null,
                connectionId: "connectionId",
                userId: "userA",
                connectionStates: states);
            var test = new WebPubSubContext(new UserEventRequest(context, BinaryData.FromString("test"), WebPubSubDataType.Text));

            var jObj = JObject.Parse(JsonConvert.SerializeObject(test));
            var request = jObj["request"];
            Assert.NotNull(request);
            Assert.AreEqual("test", request["data"].Value<string>());
            Assert.NotNull(jObj["response"]);
            Assert.AreEqual(null, jObj["errorMessage"].Value<string>());
            Assert.AreEqual(false, jObj["hasError"].Value<bool>());
            Assert.AreEqual(false, jObj["isPreflight"].Value<bool>());
            var context1 = request["connectionContext"];
            Assert.NotNull(context1);
            var states1 = context1["states"];
            Assert.NotNull(states1);
            Assert.AreEqual("aValue", states1["aKey"].Value<string>());
            Assert.AreEqual(123, states1["bKey"].Value<int>());
            var classStates = states1["cKey"];
            Assert.NotNull(classStates);
            Assert.AreEqual("GA", classStates["Title"].Value<string>());
        }

        [TestCase]
        public void TestWebPubSubContext_UserEventStates_AllBinaryData()
        {
            var ctx = new WebPubSubConnectionContext(
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
                    { "cKey", new StateTestClass(DateTime.Now, "Test", 42) }
                },
                headers: null);

            Assert.IsInstanceOf<BinaryData>(ctx.ConnectionStates["aKey"]);
            Assert.IsInstanceOf<string>(ctx.States["aKey"]);
            Assert.AreEqual("aValue", ctx.ConnectionStates["aKey"].ToObjectFromJson<string>());
            Assert.AreEqual("\"aValue\"", ctx.States["aKey"]);

            Assert.IsInstanceOf<BinaryData>(ctx.ConnectionStates["bKey"]);
            Assert.IsInstanceOf<string>(ctx.States["bKey"]);
            Assert.AreEqual(123, ctx.ConnectionStates["bKey"].ToObjectFromJson<int>());
            Assert.AreEqual("123", ctx.States["bKey"]);

            Assert.IsInstanceOf<BinaryData>(ctx.ConnectionStates["cKey"]);
            Assert.IsInstanceOf<string>(ctx.States["cKey"]);
            Assert.AreEqual(42, ctx.ConnectionStates["cKey"].ToObjectFromJson<StateTestClass>().Version);
            StringAssert.StartsWith("{", (string)ctx.States["cKey"]);
        }

        [TestCase]
        public void TestWebPubSubContext_UserEventStates_NotDoubleSerialized()
        {
            var states =
                new Dictionary<string, object>
                {
                    { "aKey", "aValue"},
                    { "bKey", 123 },
                    { "cKey", new StateTestClass() }
                }
                .EncodeConnectionStates()
                .DecodeConnectionStates()
                .ToDictionary(p => p.Key, p => (BinaryData)p.Value);
            string json = JsonConvert.SerializeObject(
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
            var states =
                new Dictionary<string, object>
                {
                    { "aKey", "aValue"},
                    { "bKey", 123 },
                    { "cKey", new StateTestClass() }
                }
                .EncodeConnectionStates()
                .DecodeConnectionStates()
                .ToDictionary(p => p.Key, p => (BinaryData)p.Value);
            var ctx = new WebPubSubConnectionContext(
                eventType: WebPubSubEventType.System,
                eventName: "connected",
                hub: null,
                connectionId: "connectionId",
                userId: "userA",
                connectionStates: states);
            CollectionAssert.AreEquivalent(ctx.ConnectionStates.Keys, ctx.States.Keys);
            Assert.AreEqual(ctx.ConnectionStates["aKey"].ToString(), ctx.States["aKey"]);
            Assert.AreEqual(ctx.ConnectionStates["bKey"].ToString(), ctx.States["bKey"]);
            Assert.AreEqual(ctx.ConnectionStates["cKey"].ToString(), ctx.States["cKey"]);
        }

        [TestCase]
        public void TestConnectionStatesConverter_SystemText()
        {
            var jsonOption = new SystemJson.JsonSerializerOptions();
            jsonOption.Converters.Add(new ConnectionStatesConverter());
            IReadOnlyDictionary<string, BinaryData> input =
                new Dictionary<string, BinaryData>
                {
                    { "aKey", BinaryData.FromString("aValue") },
                    { "bKey", BinaryData.FromObjectAsJson(123) },
                    { "cKey", BinaryData.FromObjectAsJson(new StateTestClass()) }
                };
            var serialized = SystemJson.JsonSerializer.Serialize(input, jsonOption);
            var deserialized = SystemJson.JsonSerializer.Deserialize<IReadOnlyDictionary<string, BinaryData>>(serialized, jsonOption);

            Assert.AreEqual(3, deserialized.Count);
            Assert.AreEqual("aValue", deserialized["aKey"].ToString());
            Assert.AreEqual(123, deserialized["bKey"].ToObjectFromJson<int>());
        }

        [TestCase]
        public void TestConnectionStatesConverter_SystemText_InvalidReturnEmpty()
        {
            var jsonOption = new SystemJson.JsonSerializerOptions();
            jsonOption.Converters.Add(new ConnectionStatesConverter());
            var input = new Dictionary<string, string>
                {
                    { "aKey", "aValue" },
                    { "bKey", "123" },
                    { "cKey", DateTime.Now.ToString() }
                };
            var serialized = SystemJson.JsonSerializer.Serialize(input);
            var deserialized = SystemJson.JsonSerializer.Deserialize<IReadOnlyDictionary<string, BinaryData>>(serialized, jsonOption);

            Assert.NotNull(deserialized);
            Assert.AreEqual(0, deserialized.Count);
        }

        [TestCase]
        public void TestConnectionStatesEncodeDecode()
        {
            var testTime = DateTime.Parse("2021-11-10 4:23:55");
            var input =
                new Dictionary<string, object>
                {
                    { "aKey", BinaryData.FromString("aValue") },
                    { "bKey", BinaryData.FromObjectAsJson(123) },
                    { "cKey", BinaryData.FromObjectAsJson(new StateTestClass()) },
                    { "dKey", JObject.FromObject(new StateTestClass()) },
                    { "eKey", BinaryData.FromObjectAsJson(testTime) }
                };
            var encoded = input.EncodeConnectionStates();
            var decoded = encoded.DecodeConnectionStates();

            Assert.AreEqual(5, decoded.Count);
            Assert.AreEqual("aValue", decoded["aKey"].ToString());
            Assert.AreEqual(123, ((BinaryData)decoded["bKey"]).ToObjectFromJson<int>());
            Assert.NotNull(((BinaryData)decoded["cKey"]).ToObjectFromJson<StateTestClass>());
            Assert.NotNull(((BinaryData)decoded["dKey"]).ToObjectFromJson<StateTestClass>());
            Assert.AreEqual(testTime, ((BinaryData)decoded["eKey"]).ToObjectFromJson<DateTime>());
        }

        private static HttpResponseMessage BuildResponse(string input, RequestType requestType, bool hasTestStates = false)
        {
            Dictionary<string, object> states = null;
            if (hasTestStates)
            {
                states =
                    new Dictionary<string, object>
                    {
                        { "testKey", BinaryData.FromString("value") }
                    };
            }
            var context = new WebPubSubConnectionContext(WebPubSubEventType.System, "connect", "testhub", "Connection-Id1", null, null, null, states, null);
            return Utilities.BuildValidResponse(JToken.Parse(input), requestType, context);
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
