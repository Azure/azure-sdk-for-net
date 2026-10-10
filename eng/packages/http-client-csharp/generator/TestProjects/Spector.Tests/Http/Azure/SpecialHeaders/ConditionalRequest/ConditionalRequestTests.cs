// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure;
using Azure.SpecialHeaders.ConditionalRequest;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.SpecialHeaders.ConditionalRequest
{
    public class ConditionalRequestTests : SpectorTestBase
    {
        [SpectorTest]
        public Task PostIfMatch() => Test(async (host) =>
        {
            Response response = await new ConditionalRequestClient(host, null).PostIfMatchAsync(new ETag("valid"));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task PostIfNoneMatch() => Test(async (host) =>
        {
            Response response = await new ConditionalRequestClient(host, null).PostIfNoneMatchAsync(new ETag("invalid"));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task PostCustomIfMatch() => Test(async (host) =>
        {
            Response response = await new ConditionalRequestClient(host, null).PostCustomIfMatchAsync(new ETag("valid"));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task PostCustomIfNoneMatch() => Test(async (host) =>
        {
            Response response = await new ConditionalRequestClient(host, null).PostCustomIfNoneMatchAsync(new ETag("invalid"));
            Assert.AreEqual(204, response.Status);
        });
    }
}
