// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.GeoJson;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Maps.Rendering.Tests
{
    public class GetCopyrightTests : RenderingClientLiveTestsBase
    {
        public GetCopyrightTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CanGetCopyrightFromBoundingBox()
        {
            var client = CreateClient();
            var copyright = await client.GetCopyrightFromBoundingBoxAsync(new GeoBoundingBox(4.84228, 52.41064, 4.84923, 52.41762));

            Assert.That(copyright.Value.FormatVersion, Is.EqualTo("0.0.1"));
            Assert.That(copyright.Value.GeneralCopyrights.Count, Is.EqualTo(3));
            Assert.That(copyright.Value.RegionalCopyrights.Count, Is.EqualTo(2));
            Assert.That(copyright.Value.RegionalCopyrights[0].Country.Iso3, Is.EqualTo("NLD"));
            Assert.That(copyright.Value.RegionalCopyrights[0].Country.Label, Is.EqualTo("Netherlands"));
            Assert.That(copyright.Value.RegionalCopyrights[0].Copyrights.Count, Is.EqualTo(9));
            Assert.That(copyright.Value.RegionalCopyrights[1].Country.Iso3, Is.EqualTo("ONL"));
            Assert.That(copyright.Value.RegionalCopyrights[1].Country.Label, Is.Empty);
            Assert.That(copyright.Value.RegionalCopyrights[1].Copyrights.Count, Is.EqualTo(4));
        }

        [RecordedTest]
        public async Task CanGetCopyrightForTile()
        {
            var client = CreateClient();
            var copyright = await client.GetCopyrightForTileAsync(new MapTileIndex(17439, 17439, 15));

            Assert.That(copyright.Value.FormatVersion, Is.EqualTo("0.0.1"));
            Assert.That(copyright.Value.GeneralCopyrights.Count, Is.EqualTo(3));
            Assert.That(copyright.Value.RegionalCopyrights.Count, Is.EqualTo(2));
            Assert.That(copyright.Value.RegionalCopyrights[0].Country.Iso3, Is.EqualTo("AGO"));
            Assert.That(copyright.Value.RegionalCopyrights[0].Country.Label, Is.EqualTo("Angola"));
            Assert.That(copyright.Value.RegionalCopyrights[0].Copyrights.Count, Is.EqualTo(4));
            Assert.That(copyright.Value.RegionalCopyrights[1].Country.Iso3, Is.EqualTo("OAT"));
            Assert.That(copyright.Value.RegionalCopyrights[1].Country.Label, Is.Empty);
            Assert.That(copyright.Value.RegionalCopyrights[1].Copyrights.Count, Is.EqualTo(4));
        }

        [RecordedTest]
        public async Task CanGetCopyrightForWorld()
        {
            var client = CreateClient();
            var copyright = await client.GetCopyrightForWorldAsync();

            Assert.That(copyright.Value.FormatVersion, Is.EqualTo("0.0.1"));
            Assert.That(copyright.Value.GeneralCopyrights.Count, Is.EqualTo(3));
            Assert.That(copyright.Value.RegionalCopyrights.Count >= 287, Is.True);
            Assert.That(copyright.Value.RegionalCopyrights[0].Country.Iso3, Is.EqualTo("ABW"));
            Assert.That(copyright.Value.RegionalCopyrights[0].Country.Label, Is.EqualTo("Aruba"));
            Assert.That(copyright.Value.RegionalCopyrights[0].Copyrights.Count, Is.EqualTo(4));
        }

        [Test]
        public void GetCopyrightForTileInvalidParameter()
        {
            var client = CreateClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.GetCopyrightForTileAsync(null));
        }

        [RecordedTest]
        public void CanGetCopyrightForTileError()
        {
            var client = CreateClient();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.GetCopyrightForTileAsync(new MapTileIndex(9999, 9999, 4))
            );
            Assert.That(ex.Status, Is.EqualTo(400));
        }
    }
}
