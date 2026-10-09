// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias ResponseBodyOrNoContent;

using System;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Azure;
using NUnit.Framework;
using ResponseBodyOrNoContent::Response.BodyOrNoContent;

namespace TestProjects.Spector.Tests.Http._Response.BodyOrNoContent
{
    public class BodyOrNoContentTests : SpectorTestBase
    {
        [SpectorTest]
        [TestCase(false)]
        [TestCase(true)]
        public Task GetBody(bool async) => Test(async (host) =>
        {
            var client = new BodyOrNoContentClient(host, null);
            var response = async ? await client.GetBodyAsync() : client.GetBody();

            Assert.IsTrue(response.HasValue);
            Assert.IsNotNull(response.Value);
            Assert.AreEqual("hello", response.Value!.Content);
            using var rawResponse = response.GetRawResponse();
            AssertBodyResponse(rawResponse);
        });

        [SpectorTest]
        [TestCase(false)]
        [TestCase(true)]
        public Task GetNoContent(bool async) => Test(async (host) =>
        {
            var client = new BodyOrNoContentClient(host, null);
            var response = async ? await client.GetNoContentAsync() : client.GetNoContent();

            Assert.IsFalse(response.HasValue);
            Assert.Throws<InvalidOperationException>(() => _ = response.Value);
            using var rawResponse = response.GetRawResponse();
            AssertNoContentResponse(rawResponse);
        });

        [SpectorTest]
        [TestCase(false)]
        [TestCase(true)]
        public Task GetBodyProtocol(bool async) => Test(async (host) =>
        {
            var client = new BodyOrNoContentClient(host, null);
            using var response = async
                ? await client.GetBodyAsync(new RequestContext())
                : client.GetBody(new RequestContext());

            AssertBodyResponse(response);
        });

        [SpectorTest]
        [TestCase(false)]
        [TestCase(true)]
        public Task GetNoContentProtocol(bool async) => Test(async (host) =>
        {
            var client = new BodyOrNoContentClient(host, null);
            using var response = async
                ? await client.GetNoContentAsync(new RequestContext())
                : client.GetNoContent(new RequestContext());

            AssertNoContentResponse(response);
        });

        private static void AssertBodyResponse(Response response)
        {
            Assert.AreEqual(200, response.Status);
            Assert.IsFalse(response.IsError);
            Assert.IsTrue(response.Headers.TryGetValue("x-ms-request-id", out var requestId));
            Assert.AreEqual("body-request", requestId);
            Assert.IsTrue(JsonNode.DeepEquals(
                new JsonObject { ["content"] = "hello" },
                JsonNode.Parse(response.Content.ToString())));
        }

        private static void AssertNoContentResponse(Response response)
        {
            Assert.AreEqual(204, response.Status);
            Assert.IsFalse(response.IsError);
            Assert.IsTrue(response.Headers.TryGetValue("x-ms-request-id", out var requestId));
            Assert.AreEqual("no-content-request", requestId);
            Assert.IsEmpty(response.Content.ToArray());
        }
    }
}
