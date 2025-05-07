// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using Payload.ContentNegotiation;

namespace TestProjects.Spector.Tests.Http.Payload.ContentNegotiation
{
    public class ContentNegotiationTests : SpectorTestBase
    {
        private readonly string _samplePngPath = Path.Combine(SpectorServer.GetSpecDirectory(), "assets", "image.png");
        private readonly string _sampleJpgPath = Path.Combine(SpectorServer.GetSpecDirectory(), "assets", "image.jpg");

        [SpectorTest]
        public Task SameBody() => Test(async (host) =>
        {
            var response1 = await new ContentNegotiationClient(host, null).GetSameBodyClient().GetAvatarAsPngAsync();
            Assert.AreEqual(200, response1.GetRawResponse().Status);
            CollectionAssert.AreEqual(File.ReadAllBytes(_samplePngPath), response1.Value.ToArray());

            var response2 = await new ContentNegotiationClient(host, null).GetSameBodyClient().GetAvatarAsJpegAsync();
            Assert.AreEqual(200, response2.GetRawResponse().Status);
            CollectionAssert.AreEqual(File.ReadAllBytes(_sampleJpgPath), response2.Value.ToArray());
        });

        [SpectorTest]
        public Task DifferentBody() => Test(async (host) =>
        {
            var response1 = await new ContentNegotiationClient(host, null).GetDifferentBodyClient().GetAvatarAsPngAsync();
            Assert.AreEqual(200, response1.GetRawResponse().Status);
            CollectionAssert.AreEqual(File.ReadAllBytes(_samplePngPath), response1.Value.ToArray());

            var response2 = await new ContentNegotiationClient(host, null).GetDifferentBodyClient().GetAvatarAsJsonAsync();
            Assert.AreEqual(200, response2.GetRawResponse().Status);
            CollectionAssert.AreEqual(File.ReadAllBytes(_samplePngPath), response2.Value.Content.ToArray());
        });
    }
}