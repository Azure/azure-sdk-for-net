// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class JObjectTests
    {
        public static IEnumerable<object[]> MessageTestData =>
            new List<object[]>
            {
                new object[] {new WebPubSubMessage("Hello"), MessageDataType.Binary, "Hello" },
                new object[] {new WebPubSubMessage("Hello"), MessageDataType.Json, "Hello" },
                new object[] {new WebPubSubMessage("Hello"), MessageDataType.Text, "Hello" },
                new object[] {new WebPubSubMessage(Encoding.UTF8.GetBytes("Hello")) , MessageDataType.Binary, "Hello" },
                new object[] {new WebPubSubMessage(Encoding.UTF8.GetBytes("Hello")), MessageDataType.Json, "Hello" },
                new object[] {new WebPubSubMessage(Encoding.UTF8.GetBytes("Hello")), MessageDataType.Text, "Hello" },
                new object[] {new WebPubSubMessage(new MemoryStream(Encoding.UTF8.GetBytes("Hello"))), MessageDataType.Binary, "Hello" },
                new object[] {new WebPubSubMessage(new MemoryStream(Encoding.UTF8.GetBytes("Hello"))), MessageDataType.Json, "Hello" },
                new object[] {new WebPubSubMessage(new MemoryStream(Encoding.UTF8.GetBytes("Hello"))), MessageDataType.Text, "Hello" }
            };

        [Fact]
        public void TestConvertFromJObject()
        {
            var wpsEvent = @"{
                ""operation"":""sendToUser"",
                ""userId"": ""abc"",
                ""message"": ""test"",
                ""dataType"": ""text""
                }";

            var jsevent = JObject.Parse(wpsEvent);

            var result = jsevent.ToObject<WebPubSubEvent>();

            Assert.Equal("test", result.Message.ToString());
            Assert.Equal(MessageDataType.Text, result.DataType);
            Assert.Equal(WebPubSubOperation.SendToUser, result.Operation);
            Assert.Equal("abc", result.UserId);
        }

        [Theory]
        [MemberData(nameof(MessageTestData))]
        public void TestConvertMessageToAndFromJObject(WebPubSubMessage message, MessageDataType dataType, string expected)
        {
            var wpsEvent = new WebPubSubEvent
            {
                Operation = WebPubSubOperation.SendToConnection,
                ConnectionId = "abc",
                Message = message,
                DataType = dataType
            };

            var jsObject = JObject.FromObject(wpsEvent);

            Assert.Equal("sendToConnection", jsObject["operation"].ToString());
            Assert.Equal("abc", jsObject["connectionId"].ToString());
            Assert.Equal(expected, jsObject["message"].ToString());

            var result = jsObject.ToObject<WebPubSubEvent>();

            Assert.Equal(expected, result.Message.ToString());
            Assert.Equal(dataType, result.DataType);
            Assert.Equal(WebPubSubOperation.SendToConnection, result.Operation);
            Assert.Equal("abc", result.ConnectionId);
        }

        [Fact]
        public async Task ParseErrorResponse()
        {
            var test = @"{""code"":""unauthorized"",""errorMessage"":""not valid user.""}";

            var result = BuildResponse(test, RequestType.Connect);

            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.Unauthorized, result.StatusCode);

            var message = await result.Content.ReadAsStringAsync();
            Assert.Equal("not valid user.", message);
        }

        [Fact]
        public async Task ParseConnectResponse()
        {
            var test = @"{""userId"":""aaa""}";

            var result = BuildResponse(test, RequestType.Connect);

            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            var response = await result.Content.ReadAsStringAsync();
            var message = (JObject.Parse(response)).ToObject<ConnectResponse>();
            Assert.Equal("aaa", message.UserId);
        }

        [Fact]
        public async Task ParseMessageResponse()
        {
            var test = @"{""message"":""test"", ""dataType"":""text""}";

            var result = BuildResponse(test, RequestType.User);

            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            var message = await result.Content.ReadAsStringAsync();
            Assert.Equal("test", message);
            Assert.Equal(Constants.ContentTypes.PlainTextContentType, result.Content.Headers.ContentType.MediaType);
        }

        [Fact]
        public void ParseMessageResponse_InvalidReturnNull()
        {
            var test = @"{""message"":""test"", ""dataType"":""hello""}";

            var result = BuildResponse(test, RequestType.User);

            Assert.Null(result);
        }

        [Fact]
        public async Task ParseConnectResponse_ContentMatches()
        {
            var test = @"{""test"":""test"",""errorMessage"":""not valid user.""}";
            var expected = JObject.Parse(test);

            var result = BuildResponse(test, RequestType.Connect);
            var content = await result.Content.ReadAsStringAsync();
            var actual = JObject.Parse(content);

            Assert.NotNull(result);
            Assert.Equal(expected, actual);
        }

        private static HttpResponseMessage BuildResponse(string input, RequestType requestType)
        {
            return WebPubSubTriggerDispatcher.BuildValidResponse(input, requestType);
        }
    }
}
