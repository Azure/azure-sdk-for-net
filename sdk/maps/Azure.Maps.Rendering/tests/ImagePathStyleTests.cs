// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Drawing;
using NUnit.Framework;
using Azure.Core.GeoJson;

// cspell:ignore fromargb
namespace Azure.Maps.Rendering.Tests
{
    public class ImagePathStyleTests
    {
        [Test]
        public void TestImagePathStyle()
        {
            var position1 = new GeoPosition(12.56, 22.56);
            var position2 = new GeoPosition(14.561, 19.801);

            var simplePathStyle = new ImagePathStyle(
                new System.Collections.Generic.List<GeoPosition>() { position1, position2 }
            );
            var complexPathStyle1 = new ImagePathStyle(
                new System.Collections.Generic.List<GeoPosition>() { position1, position2 }
            )
            {
                LineColor = Color.Beige,
                LineWidthInPixels = 5
            };
            var complexPathStyle2 = new ImagePathStyle(
                new System.Collections.Generic.List<GeoPosition>() { position2, position1 }
            )
            {
                LineColor = Color.FromArgb(200, 128, 45, 223), // A, R, G, B
                LineWidthInPixels = 4,
                FillColor = Color.FromArgb(230, 30, 211, 117)
            };

            Assert.AreEqual("||12.56 22.56|14.561 19.801", simplePathStyle.ToQueryString());
            Assert.AreEqual("lcF5F5FF|lw5||12.56 22.56|14.561 19.801", complexPathStyle1.ToQueryString());
            Assert.AreEqual("lc802DC8|la0.784|fc1ED3E6|fa0.902|lw4||14.561 19.801|12.56 22.56", complexPathStyle2.ToQueryString());
        }
    }
}
