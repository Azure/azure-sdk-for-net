// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Payload.Head;

namespace TestProjects.Spector.Tests.Http.Payload.Head
{
    public class HeadTests : SpectorTestBase
    {
        [SpectorTest]
        public Task ContentTypeHeaderInResponse() => Test(async (host) =>
        {
            var response = await new HeadClient(host, null).ContentTypeHeaderInResponseAsync();
            Assert.AreEqual(200, response.Status);
            Assert.IsTrue(response.Headers.TryGetValue("Content-Type", out var contentType));
            Assert.AreEqual("text/plain; charset=utf-8", contentType);
            Assert.IsTrue(response.Headers.TryGetValue("x-ms-meta", out var metadata));
            Assert.AreEqual("hello", metadata);
        });
    }
}
