// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class JObjectTests
    {
        [TestCase(nameof(SendToAll))]
        [TestCase(nameof(SendToConnection))]
        [TestCase(nameof(SendToGroup))]
        [TestCase(nameof(SendToUser))]
        [TestCase(nameof(AddConnectionToGroup))]
        [TestCase(nameof(AddUserToGroup))]
        [TestCase(nameof(RemoveConnectionFromGroup))]
        [TestCase(nameof(RemoveUserFromAllGroups))]
        [TestCase(nameof(RemoveUserFromGroup))]
        [TestCase(nameof(CloseClientConnection))]
        [TestCase(nameof(GrantGroupPermission))]
        [TestCase(nameof(RevokeGroupPermission))]
        public void TestOutputConvert(string operationKind)
        {
            WebPubSubConfigProvider.RegisterJsonConverter();

            var input = @"{ ""operationKind"":""{0}"",""userId"":""user"", ""group"":""group1"",""connectionId"":""connection"",""message"":""test"",""dataType"":""text"", ""reason"":""close""}";

            var replacedInput = input.Replace("{0}", operationKind);

            var jObject = JObject.Parse(replacedInput);

            var converted = WebPubSubConfigProvider.ConvertToWebPubSubOperation(jObject);

            Assert.AreEqual(operationKind, converted.OperationKind.ToString());
        }

        [TestCase]
        public void TestBinaryDataConvertFromByteArray()
        {
            var testData = @"{""type"":""Buffer"", ""data"": [66, 105, 110, 97, 114, 121, 68, 97, 116, 97]}";

            var converted = JsonConvert.DeserializeObject<BinaryData>(testData, new BinaryDataJsonConverter());

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
            var message = (JObject.Parse(response)).ToObject<ConnectResponse>();
            Assert.AreEqual("aaa", message.UserId);
        }

        [TestCase]
        public async Task ParseMessageResponse()
        {
            var test = @"{""message"":""test"", ""dataType"":""text""}";

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

        private static HttpResponseMessage BuildResponse(string input, RequestType requestType)
        {
            return WebPubSubTriggerDispatcher.BuildValidResponse(input, requestType);
        }
    }
}
