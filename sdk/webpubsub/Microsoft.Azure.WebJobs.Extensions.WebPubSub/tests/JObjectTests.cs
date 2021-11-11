// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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

            var message = await result.Content.ReadAsStringAsync();
            Assert.AreEqual("not valid user.", message);
        }

        [TestCase]
        public async Task ParseConnectResponse()
        {
            var test = @"{""userId"":""aaa""}";

            var result = BuildResponse(test, RequestType.Connect);

            Assert.NotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

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
            var context = new WebPubSubConnectionContext()
            {
                ConnectionId = "connectionId",
                UserId = "userA",
                EventName = "connected",
                EventType = WebPubSubEventType.System
            };
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
            var context = new WebPubSubConnectionContext()
            {
                ConnectionId = "connectionId",
                UserId = "userA",
                EventName = "connected",
                EventType = WebPubSubEventType.System
            };
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
            var context = new WebPubSubConnectionContext()
            {
                ConnectionId = "connectionId",
                UserId = "userA",
                EventName = "connected",
                EventType = WebPubSubEventType.System
            };
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
            var test = new WebPubSubContext(new DisconnectedEventRequest("dropped"));

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

        private static HttpResponseMessage BuildResponse(string input, RequestType requestType)
        {
            return Utilities.BuildValidResponse(input, requestType);
        }
    }
}
