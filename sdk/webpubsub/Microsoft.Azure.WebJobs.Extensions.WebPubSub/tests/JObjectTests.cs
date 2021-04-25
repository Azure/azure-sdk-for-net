// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class JObjectTests
    {
        [Theory]
        [InlineData(nameof(SendToAll))]
        [InlineData(nameof(SendToConnection))]
        [InlineData(nameof(SendToGroup))]
        [InlineData(nameof(SendToUser))]
        [InlineData(nameof(AddConnectionToGroup))]
        [InlineData(nameof(AddUserToGroup))]
        [InlineData(nameof(RemoveConnectionFromGroup))]
        [InlineData(nameof(RemoveUserFromAllGroups))]
        [InlineData(nameof(RemoveUserFromGroup))]
        [InlineData(nameof(CloseClientConnection))]
        [InlineData(nameof(GrantGroupPermission))]
        [InlineData(nameof(RevokeGroupPermission))]
        public void TestOutputConvert(string operationKind)
        {
            var input = @"{ ""operationKind"":""{0}"",""userId"":""user"", ""group"":""group1"",""connectionId"":""connection"",""message"":""test"",""dataType"":""text"", ""reason"":""close""}";

            var replacedInput = input.Replace("{0}", operationKind);

            var jObject = JObject.Parse(replacedInput);

            var converted = JsonConvert.DeserializeObject<WebPubSubOperation>(replacedInput, new WebPubSubOperationJsonConverter());

            Assert.Equal(operationKind, converted.OperationKind.ToString());
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
