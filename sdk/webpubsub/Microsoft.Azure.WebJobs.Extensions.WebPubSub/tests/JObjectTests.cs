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

            Assert.That(converted.ActionName.ToString(), Is.EqualTo(actionName));
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
            Assert.That(JObject.FromObject(converted)["data"].ToString(), Is.EqualTo("BinaryData"));
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
            Assert.That(ex.Message, Is.EqualTo($"Not supported WebPubSubOperation: {actionName}."));
        }

        [TestCase]
        public void TestBinaryDataConverter_String()
        {
            var input = @"{ actionName : ""sendToAll"", dataType: ""text"", data: ""2""}";

            var converted = JObject.Parse(input).ToObject<SendToAllAction>();

            Assert.That(converted.Data.ToString(), Is.EqualTo("2"));
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

            Assert.That(converted.ToString(), Is.EqualTo("BinaryData"));
        }

        [TestCase]
        public async Task ParseErrorResponse()
        {
            var test = @"{""code"":""unauthorized"",""errorMessage"":""not valid user.""}";

            var result = BuildResponse(test, RequestType.Connect);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));

            var stateExist = result.Headers.TryGetValues(Constants.Headers.CloudEvents.State, out var states);
            Assert.That(stateExist, Is.False);
            var message = await result.Content.ReadAsStringAsync();
            Assert.That(message, Is.EqualTo("not valid user."));
        }

        [TestCase]
        public async Task ParseConnectResponse_JSInvalidStatesNotMerge()
        {
            var test = @"{""userId"":""aaa"", ""states"": ""a""}";

            var result = BuildResponse(test, RequestType.Connect, true);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var stateExist = result.Headers.TryGetValues(Constants.Headers.CloudEvents.State, out var value);
            Assert.That(stateExist, Is.True);
            var states = value.SingleOrDefault().DecodeConnectionStates();
            Assert.That(states, Is.Not.Null);
            Assert.That(states.Count, Is.EqualTo(1));
            Assert.That(states.ContainsKey("testKey"), Is.True);

            var response = await result.Content.ReadAsStringAsync();
            var message = (JObject.Parse(response)).ToObject<ConnectEventResponse>();
            Assert.That(message.UserId, Is.EqualTo("aaa"));
        }

        [TestCase]
        public async Task ParseConnectResponseWithValidStates()
        {
            var test = @"{""userId"":""aaa"", ""states"": { ""a"": ""b"", ""a"": ""c"" }}";

            var result = BuildResponse(test, RequestType.Connect, false);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var stateExist = result.Headers.TryGetValues(Constants.Headers.CloudEvents.State, out var value);
            Assert.That(stateExist, Is.True);
            var states = value.SingleOrDefault().DecodeConnectionStates();
            Assert.That(states.ContainsKey("a"), Is.True);

            var response = await result.Content.ReadAsStringAsync();
            var message = (JObject.Parse(response)).ToObject<ConnectEventResponse>();
            Assert.That(message.UserId, Is.EqualTo("aaa"));
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

            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var message = await result.Content.ReadAsStringAsync();
            Assert.That(message, Is.EqualTo("test"));
            Assert.That(result.Content.Headers.ContentType.MediaType, Is.EqualTo(expectContentType));
        }

        [TestCase]
        public void ParseMessageResponse_InvalidJArrayReturnServerError()
        {
            // serialize agagin to stringify.
            var test = @"[""test"", ""dataType"", ""text""]";

            var result = BuildResponse(test, RequestType.User);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }

        [TestCase]
        public void ParseMessageResponse_InvalidEnumReturnServerError()
        {
            // datatype not valid.
            var test = @"{""data"":""test"", ""dataType"":""hello""}";

            var result = BuildResponse(test, RequestType.User);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }

        [TestCase]
        public async Task ParseConnectResponse_ContentMatches()
        {
            var test = @"{""test"":""test"",""errorMessage"":""not valid user.""}";
            var expected = JObject.FromObject(JsonConvert.DeserializeObject<ConnectEventResponse>(test));

            var result = BuildResponse(test, RequestType.Connect);
            var content = await result.Content.ReadAsStringAsync();
            var actual = JObject.Parse(content);

            Assert.That(result, Is.Not.Null);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void TestWebPubSubContext_ConnectedEvent()
        {
            var context = new WebPubSubConnectionContext(connectionId: "connectionId", userId: "userA", eventName: "connected", eventType: WebPubSubEventType.System, hub: null);
            var test = new WebPubSubContext(new ConnectedEventRequest(context));

            var serialize = JObject.FromObject(test);

            Assert.That(serialize["request"], Is.Not.Null);
            Assert.That(serialize["response"], Is.Not.Null);
            Assert.That(serialize["errorMessage"].Value<string>(), Is.EqualTo(null));
            Assert.That(serialize["hasError"].Value<bool>(), Is.EqualTo(false));
            Assert.That(serialize["isPreflight"].Value<bool>(), Is.EqualTo(false));
            Assert.That(serialize["request"]["connectionContext"]["eventType"].Value<string>(), Is.EqualTo("System"));
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

            Assert.That(request, Is.Not.Null);
            Assert.That(request["subprotocols"].ToObject<string[]>(), Is.EqualTo(subprotocol));
            Assert.That(serialize["response"], Is.Not.Null);
            Assert.That(serialize["errorMessage"].Value<string>(), Is.EqualTo(null));
            Assert.That(serialize["hasError"].Value<bool>(), Is.EqualTo(false));
            Assert.That(serialize["isPreflight"].Value<bool>(), Is.EqualTo(false));
        }

        [TestCase]
        public void TestWebPubSubContext_UserEvent()
        {
            var context = new WebPubSubConnectionContext(connectionId: "connectionId", userId: "userA", eventName: "connected", eventType: WebPubSubEventType.System, hub: null);
            var test = new WebPubSubContext(new UserEventRequest(context, BinaryData.FromString("test"), WebPubSubDataType.Text));

            var serialize = JObject.FromObject(test);
            var request = serialize["request"];

            Assert.That(request, Is.Not.Null);
            Assert.That(request["data"].Value<string>(), Is.EqualTo("test"));
            Assert.That(serialize["response"], Is.Not.Null);
            Assert.That(serialize["errorMessage"].Value<string>(), Is.EqualTo(null));
            Assert.That(serialize["hasError"].Value<bool>(), Is.EqualTo(false));
            Assert.That(serialize["isPreflight"].Value<bool>(), Is.EqualTo(false));
        }

        [TestCase]
        public void TestWebPubSubContext_DisconnectedEvent()
        {
            var test = new WebPubSubContext(new DisconnectedEventRequest(null, "dropped"));

            var serialize = JObject.FromObject(test);
            var request = serialize["request"];

            Assert.That(request, Is.Not.Null);
            Assert.That(request["reason"].Value<string>(), Is.EqualTo("dropped"));
            Assert.That(serialize["response"], Is.Not.Null);
            Assert.That(serialize["errorMessage"].Value<string>(), Is.EqualTo(null));
            Assert.That(serialize["hasError"].Value<bool>(), Is.EqualTo(false));
            Assert.That(serialize["isPreflight"].Value<bool>(), Is.EqualTo(false));
        }

        [TestCase]
        public void TestWebPubSubContext_ErrorResponse()
        {
            var test = new WebPubSubContext("Invalid Request", WebPubSubErrorCode.UserError);

            var serialize = JObject.FromObject(test);
            var response = serialize["response"];

            Assert.That(serialize["request"], Is.Null);
            Assert.That(response, Is.Not.Null);
            Assert.That(response["status"].Value<int>(), Is.EqualTo(400));
            Assert.That(response["body"].Value<string>(), Is.EqualTo("Invalid Request"));
            Assert.That(serialize["errorMessage"].Value<string>(), Is.EqualTo("Invalid Request"));
            Assert.That(serialize["hasError"].Value<bool>(), Is.EqualTo(true));
            Assert.That(serialize["isPreflight"].Value<bool>(), Is.EqualTo(false));
        }

        [TestCase]
        public void TestWebPubSubConnectionJsonSerialize()
        {
            var baseUrl = "wss://webpubsub.azure.com/";
            var accessToken = "test-token";
            var url = $"{baseUrl}?access_token={accessToken}";
            var connection = new WebPubSubConnection(new Uri(url));

            var json = JObject.FromObject(connection);

            Assert.That(json["baseUrl"].Value<Uri>().ToString(), Is.EqualTo(baseUrl));
            Assert.That(json["accessToken"].Value<string>(), Is.EqualTo(accessToken));
            Assert.That(json["url"].Value<Uri>().ToString(), Is.EqualTo(url));
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

            Assert.That(request, Is.Not.Null);
            Assert.That(request["data"].Value<string>(), Is.EqualTo("test"));
            Assert.That(jObj["response"], Is.Not.Null);
            Assert.That(jObj["errorMessage"].Value<string>(), Is.EqualTo(null));
            Assert.That(jObj["hasError"].Value<bool>(), Is.EqualTo(false));
            Assert.That(jObj["isPreflight"].Value<bool>(), Is.EqualTo(false));

            var context1 = request["connectionContext"];
            Assert.That(context1, Is.Not.Null);
            var states1 = context1["states"];
            Assert.That(states1, Is.Not.Null);
            Assert.That(states1["aKey"].Value<string>(), Is.EqualTo("\"aValue\""));
            Assert.That(states1, Is.Not.Null);
            Assert.That(states1["bKey"].Value<int>(), Is.EqualTo(123));
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
            Assert.That(request, Is.Not.Null);
            Assert.That(request["data"].Value<string>(), Is.EqualTo("test"));
            Assert.That(jObj["response"], Is.Not.Null);
            Assert.That(jObj["errorMessage"].Value<string>(), Is.EqualTo(null));
            Assert.That(jObj["hasError"].Value<bool>(), Is.EqualTo(false));
            Assert.That(jObj["isPreflight"].Value<bool>(), Is.EqualTo(false));
            var context1 = request["connectionContext"];
            Assert.That(context1, Is.Not.Null);
            var states1 = context1["states"];
            Assert.That(states1, Is.Not.Null);
            Assert.That(states1["aKey"].Value<string>(), Is.EqualTo("aValue"));
            Assert.That(states1["bKey"].Value<int>(), Is.EqualTo(123));
            var classStates = states1["cKey"];
            Assert.That(classStates, Is.Not.Null);
            Assert.That(classStates["Title"].Value<string>(), Is.EqualTo("GA"));
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

            Assert.That(ctx.ConnectionStates["aKey"], Is.InstanceOf<BinaryData>());
            Assert.That(ctx.States["aKey"], Is.InstanceOf<string>());
            Assert.That(ctx.ConnectionStates["aKey"].ToObjectFromJson<string>(), Is.EqualTo("aValue"));
            Assert.That(ctx.States["aKey"], Is.EqualTo("\"aValue\""));

            Assert.That(ctx.ConnectionStates["bKey"], Is.InstanceOf<BinaryData>());
            Assert.That(ctx.States["bKey"], Is.InstanceOf<string>());
            Assert.That(ctx.ConnectionStates["bKey"].ToObjectFromJson<int>(), Is.EqualTo(123));
            Assert.That(ctx.States["bKey"], Is.EqualTo("123"));

            Assert.That(ctx.ConnectionStates["cKey"], Is.InstanceOf<BinaryData>());
            Assert.That(ctx.States["cKey"], Is.InstanceOf<string>());
            Assert.That(ctx.ConnectionStates["cKey"].ToObjectFromJson<StateTestClass>().Version, Is.EqualTo(42));
            Assert.That((string)ctx.States["cKey"], Does.StartWith("{"));
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
            Assert.That(jCtx["states"]["aKey"].Value<string>(), Is.EqualTo("aValue"));
            Assert.That(jCtx["states"]["bKey"].Value<int>(), Is.EqualTo(123));
            Assert.That(jCtx["states"]["cKey"]["Title"].Value<string>(), Is.EqualTo("GA"));
            Assert.That(jCtx["states"]["cKey"]["Version"].Value<int>(), Is.EqualTo(1));
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
            Assert.That(ctx.States.Keys, Is.EquivalentTo(ctx.ConnectionStates.Keys));
            Assert.That(ctx.States["aKey"], Is.EqualTo(ctx.ConnectionStates["aKey"].ToString()));
            Assert.That(ctx.States["bKey"], Is.EqualTo(ctx.ConnectionStates["bKey"].ToString()));
            Assert.That(ctx.States["cKey"], Is.EqualTo(ctx.ConnectionStates["cKey"].ToString()));
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

            Assert.That(deserialized.Count, Is.EqualTo(3));
            Assert.That(deserialized["aKey"].ToString(), Is.EqualTo("aValue"));
            Assert.That(deserialized["bKey"].ToObjectFromJson<int>(), Is.EqualTo(123));
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

            Assert.That(deserialized, Is.Not.Null);
            Assert.That(deserialized.Count, Is.EqualTo(0));
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

            Assert.That(decoded.Count, Is.EqualTo(5));
            Assert.That(decoded["aKey"].ToString(), Is.EqualTo("aValue"));
            Assert.That(((BinaryData)decoded["bKey"]).ToObjectFromJson<int>(), Is.EqualTo(123));
            Assert.That(((BinaryData)decoded["cKey"]).ToObjectFromJson<StateTestClass>(), Is.Not.Null);
            Assert.That(((BinaryData)decoded["dKey"]).ToObjectFromJson<StateTestClass>(), Is.Not.Null);
            Assert.That(((BinaryData)decoded["eKey"]).ToObjectFromJson<DateTime>(), Is.EqualTo(testTime));
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
