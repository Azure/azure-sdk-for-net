// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Drawing;
using NUnit.Framework;
using Azure.Core.GeoJson;

// cspell:ignore fromargb udid
namespace Azure.Maps.Render.Tests
{
    public class PathStyleTests
    {
        [Test]
        public void TestPathStyle()
        {
            var position1 = new GeoPosition(12.56, 22.56);
            var position2 = new GeoPosition(14.561, 19.801);

            var simplePathStyle = new PathStyle(
                new System.Collections.Generic.List<GeoPosition>() {
                    position1, position2
                }
            );
            var ComplexPathStyle = new PathStyle(
                new System.Collections.Generic.List<GeoPosition>() {
                    position1, position2
                }
            )
            {
                LineColor = Color.Beige,
                LineWidthInPixels = 5
            };
            var ComplexPathStyleWithUdid = new PathStyle(
                "udid-29dc105a-dee7-409f-a3f9-22b066ae4713"
            )
            {
                LineColor = Color.FromArgb(200, 128, 45, 223), // A, R, G, B
                LineWidthInPixels = 4,
                FillColor = Color.FromArgb(230, 30, 211, 117)
            };

            Assert.AreEqual("||12.56 22.56|14.561 19.801", simplePathStyle.ToString());
            Assert.AreEqual("lcF5F5FF|lw5||12.56 22.56|14.561 19.801", ComplexPathStyle.ToString());
            Assert.AreEqual("lc802DC8|la0.784|fc1ED3E6|fa0.902|lw4||udid-29dc105a-dee7-409f-a3f9-22b066ae4713", ComplexPathStyleWithUdid.ToString());
        }
    }
}
