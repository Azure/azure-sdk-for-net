// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure;
using NUnit.Framework;
using Specs.Azure.ClientGenerator.Core.ResponseAsBool;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ResponseAsBool
{
    public class ResponseAsBoolTests : SpectorTestBase
    {
        [SpectorTest]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public Task Exists(bool async, bool protocol) => Test(async (host) =>
        {
            var client = new ResponseAsBoolClient(host, null).GetHeadAsBooleanClient();
            Response<bool> response;
            if (protocol)
            {
                response = async
                    ? await client.ExistsAsync(new RequestContext())
                    : client.Exists(new RequestContext());
            }
            else
            {
                response = async ? await client.ExistsAsync() : client.Exists();
            }

            Assert.IsTrue(response.Value);
            using var rawResponse = response.GetRawResponse();
            Assert.AreEqual(204, rawResponse.Status);
            Assert.IsFalse(rawResponse.IsError);
        });

        [SpectorTest]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public Task NotExists(bool async, bool protocol) => Test(async (host) =>
        {
            var client = new ResponseAsBoolClient(host, null).GetHeadAsBooleanClient();
            Response<bool> response;
            if (protocol)
            {
                response = async
                    ? await client.NotExistsAsync(new RequestContext())
                    : client.NotExists(new RequestContext());
            }
            else
            {
                response = async ? await client.NotExistsAsync() : client.NotExists();
            }

            Assert.IsFalse(response.Value);
            using var rawResponse = response.GetRawResponse();
            Assert.AreEqual(404, rawResponse.Status);
            Assert.IsFalse(rawResponse.IsError);
        });
    }
}
