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

            Assert.AreEqual("0.0.1", copyright.Value.FormatVersion);
            Assert.AreEqual(3, copyright.Value.GeneralCopyrights.Count);
            Assert.AreEqual(2, copyright.Value.RegionalCopyrights.Count);
            Assert.AreEqual("NLD", copyright.Value.RegionalCopyrights[0].Country.Iso3);
            Assert.AreEqual("Netherlands", copyright.Value.RegionalCopyrights[0].Country.Label);
            Assert.AreEqual(9, copyright.Value.RegionalCopyrights[0].Copyrights.Count);
            Assert.AreEqual("ONL", copyright.Value.RegionalCopyrights[1].Country.Iso3);
            Assert.AreEqual(string.Empty, copyright.Value.RegionalCopyrights[1].Country.Label);
            Assert.AreEqual(4, copyright.Value.RegionalCopyrights[1].Copyrights.Count);
        }

        [RecordedTest]
        public async Task CanGetCopyrightForTile()
        {
            var client = CreateClient();
            var copyright = await client.GetCopyrightForTileAsync(new MapTileIndex(17439, 17439, 15));

            Assert.AreEqual("0.0.1", copyright.Value.FormatVersion);
            Assert.AreEqual(3, copyright.Value.GeneralCopyrights.Count);
            Assert.AreEqual(2, copyright.Value.RegionalCopyrights.Count);
            Assert.AreEqual("AGO", copyright.Value.RegionalCopyrights[0].Country.Iso3);
            Assert.AreEqual("Angola", copyright.Value.RegionalCopyrights[0].Country.Label);
            Assert.AreEqual(4, copyright.Value.RegionalCopyrights[0].Copyrights.Count);
            Assert.AreEqual("OAT", copyright.Value.RegionalCopyrights[1].Country.Iso3);
            Assert.AreEqual(string.Empty, copyright.Value.RegionalCopyrights[1].Country.Label);
            Assert.AreEqual(4, copyright.Value.RegionalCopyrights[1].Copyrights.Count);
        }

        [RecordedTest]
        public async Task CanGetCopyrightForWorld()
        {
            var client = CreateClient();
            var copyright = await client.GetCopyrightForWorldAsync();

            Assert.AreEqual("0.0.1", copyright.Value.FormatVersion);
            Assert.AreEqual(3, copyright.Value.GeneralCopyrights.Count);
            Assert.IsTrue(copyright.Value.RegionalCopyrights.Count >= 287);
            Assert.AreEqual("ABW", copyright.Value.RegionalCopyrights[0].Country.Iso3);
            Assert.AreEqual("Aruba", copyright.Value.RegionalCopyrights[0].Country.Label);
            Assert.AreEqual(4, copyright.Value.RegionalCopyrights[0].Copyrights.Count);
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
            Assert.AreEqual(400, ex.Status);
        }
    }
}
