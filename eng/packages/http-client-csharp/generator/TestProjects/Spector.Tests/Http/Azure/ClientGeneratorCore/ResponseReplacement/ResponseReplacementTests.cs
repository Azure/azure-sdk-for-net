// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using NUnit.Framework;
using Specs.Azure.ClientGenerator.Core.ResponseReplacement;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ResponseReplacement
{
    public class ResponseReplacementTests : SpectorTestBase
    {
        [SpectorTest]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public Task VoidResponse(bool async, bool protocol) => Test(async (host) =>
        {
            var client = new ResponseReplacementClient(host, null);
            Response response;
            if (protocol)
            {
                response = async
                    ? await client.VoidResponseAsync(new RequestContext())
                    : client.VoidResponse(new RequestContext());
            }
            else
            {
                response = async ? await client.VoidResponseAsync() : client.VoidResponse();
            }

            using (response)
            {
                Assert.AreEqual(200, response.Status);
                Assert.IsFalse(response.IsError);
                Assert.AreEqual("{\"name\":\"widget\"}", response.Content.ToString());
            }
        });

        [SpectorTest]
        [TestCase(false)]
        [TestCase(true)]
        public Task BytesResponse(bool async) => Test(async (host) =>
        {
            var client = new ResponseReplacementClient(host, null);
            Response<BinaryData> response = async ? await client.BytesResponseAsync() : client.BytesResponse();

            CollectionAssert.AreEqual(BinaryData.FromString("{\"name\":\"widget\"}").ToArray(), response.Value.ToArray());
            using var rawResponse = response.GetRawResponse();
            Assert.AreEqual(200, rawResponse.Status);
            Assert.IsFalse(rawResponse.IsError);
            Assert.IsTrue(rawResponse.Headers.TryGetValue("Content-Type", out var contentType));
            Assert.AreEqual("application/json; charset=utf-8", contentType);
        });

        [SpectorTest]
        [TestCase(false)]
        [TestCase(true)]
        public Task BytesResponseProtocol(bool async) => Test(async (host) =>
        {
            var client = new ResponseReplacementClient(host, null);
            using Response response = async
                ? await client.BytesResponseAsync(new RequestContext())
                : client.BytesResponse(new RequestContext());

            Assert.AreEqual(200, response.Status);
            Assert.IsFalse(response.IsError);
            Assert.IsTrue(response.Headers.TryGetValue("Content-Type", out var contentType));
            Assert.AreEqual("application/json; charset=utf-8", contentType);
            CollectionAssert.AreEqual(BinaryData.FromString("{\"name\":\"widget\"}").ToArray(), response.Content.ToArray());
        });
    }
}
