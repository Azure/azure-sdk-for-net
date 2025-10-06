// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using System;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;
using Payload.JsonMergePatch;

namespace TestProjects.Spector.Tests.Http.Payload.JsonMergePatch
{
    public class JsonMergePatchTests : SpectorTestBase
    {
        [SpectorTest]
        public Task CreateResource() => Test(async (host) =>
        {
            var response = await new JsonMergePatchClient(host, null).CreateResourceAsync(new Resource("Madge")
                {
                    Description = "desc",
                    Map = { { "key", new InnerModel { Name = "InnerMadge", Description = "innerDesc" } } },
                    Array = { new InnerModel { Name = "InnerMadge", Description = "innerDesc" } },
                    IntValue = 1,
                    FloatValue = 1.25f,
                    InnerModel = new InnerModel { Name = "InnerMadge", Description = "innerDesc" },
                    IntArray = { 1, 2, 3 }
                });
            Assert.AreEqual(200, response.GetRawResponse().Status);
        });

        [SpectorTest]
        public Task UpdateOptionalResource() => Test(async (host) =>
        {
            var response = await new JsonMergePatchClient(host, null).UpdateOptionalResourceAsync(RequestContent.Create(
                new BinaryData(
                    new
                    {
                        description = (string?)null,
                        map = new { key = new { description = (string?)null }, key2 = (string?)null },
                        array = (object[]?)null,
                        intValue = (int?)null,
                        floatValue = (float?)null,
                        innerModel = (InnerModel?)null,
                        intArray = (int[]?)null
                    })));
            Assert.AreEqual(200, response.Status);
        });

        [SpectorTest]
        public Task UpdateResource() => Test(async (host) =>
        {
            var response = await new JsonMergePatchClient(host, null).UpdateResourceAsync(RequestContent.Create(
                new BinaryData(
                    new
                    {
                        description = (string?)null,
                        map = new { key = new { description = (string?)null }, key2 = (string?)null },
                        array = (object[]?)null,
                        intValue = (int?)null,
                        floatValue = (float?)null,
                        innerModel = (InnerModel?)null,
                        intArray = (int[]?)null
                    })));
            Assert.AreEqual(200, response.Status);
        });
    }
}