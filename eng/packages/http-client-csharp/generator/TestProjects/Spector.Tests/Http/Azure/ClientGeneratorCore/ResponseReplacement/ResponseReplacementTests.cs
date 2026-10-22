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
        public Task Azure_ClientGenerator_Core_ResponseReplacement_VoidResponse() => Test(async host =>
        {
            var client = new ResponseReplacementClient(host, null);

            Response response = client.VoidResponse();
            Assert.AreEqual(200, response.Status);
            Assert.AreEqual("{\"name\":\"widget\"}", response.Content.ToString());

            Response asyncResponse = await client.VoidResponseAsync();
            Assert.AreEqual(200, asyncResponse.Status);
            Assert.AreEqual("{\"name\":\"widget\"}", asyncResponse.Content.ToString());
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ResponseReplacement_BytesResponse() => Test(async host =>
        {
            var client = new ResponseReplacementClient(host, null);

            Response<BinaryData> response = client.BytesResponse();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("{\"name\":\"widget\"}", response.Value.ToString());

            Response<BinaryData> asyncResponse = await client.BytesResponseAsync();
            Assert.AreEqual(200, asyncResponse.GetRawResponse().Status);
            Assert.AreEqual("{\"name\":\"widget\"}", asyncResponse.Value.ToString());
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ResponseReplacement_VoidResponseProtocol() => Test(async host =>
        {
            var client = new ResponseReplacementClient(host, null);

            Response response = client.VoidResponse(new RequestContext());
            Assert.AreEqual(200, response.Status);
            Assert.AreEqual("{\"name\":\"widget\"}", response.Content.ToString());

            Response asyncResponse = await client.VoidResponseAsync(new RequestContext());
            Assert.AreEqual(200, asyncResponse.Status);
            Assert.AreEqual("{\"name\":\"widget\"}", asyncResponse.Content.ToString());
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ResponseReplacement_BytesResponseProtocol() => Test(async host =>
        {
            var client = new ResponseReplacementClient(host, null);

            Response response = client.BytesResponse(new RequestContext());
            Assert.AreEqual(200, response.Status);
            Assert.AreEqual("{\"name\":\"widget\"}", response.Content.ToString());

            Response asyncResponse = await client.BytesResponseAsync(new RequestContext());
            Assert.AreEqual(200, asyncResponse.Status);
            Assert.AreEqual("{\"name\":\"widget\"}", asyncResponse.Content.ToString());
        });
    }
}
