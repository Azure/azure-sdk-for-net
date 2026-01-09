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
            Assert.That(response1.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response1.Value.ToArray(), Is.EqualTo(File.ReadAllBytes(_samplePngPath)).AsCollection);

            var response2 = await new ContentNegotiationClient(host, null).GetSameBodyClient().GetAvatarAsJpegAsync();
            Assert.That(response2.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response2.Value.ToArray(), Is.EqualTo(File.ReadAllBytes(_sampleJpgPath)).AsCollection);
        });

        [SpectorTest]
        public Task DifferentBody() => Test(async (host) =>
        {
            var response1 = await new ContentNegotiationClient(host, null).GetDifferentBodyClient().GetAvatarAsPngAsync();
            Assert.That(response1.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response1.Value.ToArray(), Is.EqualTo(File.ReadAllBytes(_samplePngPath)).AsCollection);

            var response2 = await new ContentNegotiationClient(host, null).GetDifferentBodyClient().GetAvatarAsJsonAsync();
            Assert.That(response2.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response2.Value.Content.ToArray(), Is.EqualTo(File.ReadAllBytes(_samplePngPath)).AsCollection);
        });
    }
}