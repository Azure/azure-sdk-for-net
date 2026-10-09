// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias ResponseStatusCodeRange;

using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Azure;
using NUnit.Framework;
using ResponseStatusCodeRange::Response.StatusCodeRange;

namespace TestProjects.Spector.Tests.Http._Response.StatusCodeRange
{
    public class StatusCodeRangeTests : SpectorTestBase
    {
        private const string ErrorInRangeBody = """{"code":"request-header-too-large","message":"Request header too large"}""";
        private const string NotFoundErrorBody = """{"code":"not-found","resourceId":"resource1"}""";

        [SpectorTest]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public Task ErrorResponseStatusCodeInRange(bool async, bool protocol) => Test((host) =>
        {
            var client = new StatusCodeRangeClient(host, null);
            var exception = async
                ? Assert.ThrowsAsync<RequestFailedException>(async () =>
                {
                    using var response = protocol
                        ? await client.ErrorResponseStatusCodeInRangeAsync(new RequestContext())
                        : await client.ErrorResponseStatusCodeInRangeAsync();
                })
                : Assert.Throws<RequestFailedException>(() =>
                {
                    using var response = protocol
                        ? client.ErrorResponseStatusCodeInRange(new RequestContext())
                        : client.ErrorResponseStatusCodeInRange();
                });

            AssertError(exception!, 494, "request-header-too-large", ErrorInRangeBody);
            StringAssert.Contains("Request header too large", exception!.Message);
            return Task.CompletedTask;
        });

        [SpectorTest]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public Task ErrorResponseStatusCode404(bool async, bool protocol) => Test((host) =>
        {
            var client = new StatusCodeRangeClient(host, null);
            var exception = async
                ? Assert.ThrowsAsync<RequestFailedException>(async () =>
                {
                    using var response = protocol
                        ? await client.ErrorResponseStatusCode404Async(new RequestContext())
                        : await client.ErrorResponseStatusCode404Async();
                })
                : Assert.Throws<RequestFailedException>(() =>
                {
                    using var response = protocol
                        ? client.ErrorResponseStatusCode404(new RequestContext())
                        : client.ErrorResponseStatusCode404();
                });

            AssertError(exception!, 404, "not-found", NotFoundErrorBody);
            return Task.CompletedTask;
        });

        [SpectorTest]
        [TestCase(false)]
        [TestCase(true)]
        public Task ErrorResponseStatusCodeInRangeNoThrow(bool async) => Test(async (host) =>
        {
            var client = new StatusCodeRangeClient(host, null);
            var context = new RequestContext { ErrorOptions = ErrorOptions.NoThrow };
            using var response = async
                ? await client.ErrorResponseStatusCodeInRangeAsync(context)
                : client.ErrorResponseStatusCodeInRange(context);

            AssertErrorResponse(response, 494, ErrorInRangeBody);
        });

        [SpectorTest]
        [TestCase(false)]
        [TestCase(true)]
        public Task ErrorResponseStatusCode404NoThrow(bool async) => Test(async (host) =>
        {
            var client = new StatusCodeRangeClient(host, null);
            var context = new RequestContext { ErrorOptions = ErrorOptions.NoThrow };
            using var response = async
                ? await client.ErrorResponseStatusCode404Async(context)
                : client.ErrorResponseStatusCode404(context);

            AssertErrorResponse(response, 404, NotFoundErrorBody);
        });

        private static void AssertError(RequestFailedException exception, int status, string errorCode, string expectedBody)
        {
            Assert.AreEqual(status, exception.Status);
            Assert.AreEqual(errorCode, exception.ErrorCode);
            // Azure exposes error payloads through RequestFailedException rather than generated error models.
            using var response = exception.GetRawResponse();
            Assert.IsNotNull(response);
            AssertErrorResponse(response!, status, expectedBody);
        }

        private static void AssertErrorResponse(Response response, int status, string expectedBody)
        {
            Assert.AreEqual(status, response.Status);
            Assert.IsTrue(response.IsError);
            Assert.IsTrue(JsonNode.DeepEquals(
                JsonNode.Parse(expectedBody),
                JsonNode.Parse(response.Content.ToString())));
        }
    }
}
