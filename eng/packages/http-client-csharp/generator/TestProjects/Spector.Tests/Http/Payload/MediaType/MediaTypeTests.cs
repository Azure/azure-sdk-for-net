// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Payload.MediaType;

namespace TestProjects.Spector.Tests.Http.Payload.MediaType
{
    public class MediaTypeTests : SpectorTestBase
    {
        [SpectorTest]
        public Task SendAsText() => Test(async (host) =>
        {
            var response1 = await new MediaTypeClient(host, null).GetStringBodyClient().SendAsTextAsync("{cat}");
            Assert.That(response1.Status, Is.EqualTo(200));
        });

        [SpectorTest]
        public Task GetAsText() => Test(async (host) =>
        {
            var response2 = await new MediaTypeClient(host, null).GetStringBodyClient().GetAsTextAsync();
            Assert.That(response2.Value, Is.EqualTo("{cat}"));
        });

        [SpectorTest]
        public Task SendAsJson() => Test(async (host) =>
        {
            var response3 = await new MediaTypeClient(host, null).GetStringBodyClient().SendAsJsonAsync("foo");
            Assert.That(response3.Status, Is.EqualTo(200));
        });

        [SpectorTest]
        public Task GetAsJson() => Test(async (host) =>
        {
            var response4 = await new MediaTypeClient(host, null).GetStringBodyClient().GetAsJsonAsync();
            Assert.That(response4.Value, Is.EqualTo("foo"));
        });
    }
}