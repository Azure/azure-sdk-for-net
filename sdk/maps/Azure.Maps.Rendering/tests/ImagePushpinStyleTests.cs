// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Drawing;
using NUnit.Framework;

// cspell:ignore fromargb
namespace Azure.Maps.Rendering.Tests
{
    public class ImagePushpinStyleTests
    {
        [Test]
        public void TestPushpinPosition()
        {
            var pushpinPosition = new PushpinPosition(12.56, 22.56);
            var pushpinPositionWithLabel = new PushpinPosition(12.56, 22.56, "A label");

            Assert.AreEqual("12.56 22.56", pushpinPosition.ToQueryString());
            Assert.AreEqual("'A label'12.56 22.56", pushpinPositionWithLabel.ToQueryString());
        }

        [Test]
        public void TestPushpinStyle()
        {
            var pinPosition1 = new PushpinPosition(12.56, 22.56);
            var pinPosition2 = new PushpinPosition(14.561, 19.801);
            var pinPosition3 = new PushpinPosition(7.9, 44.0, "A label");
            var pinPosition4 = new PushpinPosition(11.73, 25.02, "B label");
            var simplePinStyle = new ImagePushpinStyle(
                new System.Collections.Generic.List<PushpinPosition>()
                {
                    pinPosition1, pinPosition2, pinPosition3, pinPosition4
                }
            );
            var complexPinStyle1 = new ImagePushpinStyle(
                new System.Collections.Generic.List<PushpinPosition>()
                {
                    pinPosition4, pinPosition2, pinPosition1, pinPosition3
                }
            )
            {
                PushpinScaleRatio = 1.75,
                PushpinColor = Color.Beige,
                RotationInDegrees = -47,
                LabelScaleRatio = 1.1
            };
            var complexPinStyle2 = new ImagePushpinStyle(
                new System.Collections.Generic.List<PushpinPosition>()
                {
                    pinPosition4, pinPosition3
                }
            )
            {
                PushpinAnchorShiftInPixels = new Point(4, -5),
                PushpinScaleRatio = 1.05,
                LabelColor = Color.FromArgb(47, 128, 45, 223), // A, R, G, B
                LabelScaleRatio = 0.9,
                LabelAnchorShiftInPixels = new Point(5, -6),
                CustomPushpinImageUri = new Uri("http://contoso.com/pushpins/red.png"),
            };

            Assert.AreEqual("default||12.56 22.56|14.561 19.801|'A label'7.9 44|'B label'11.73 25.02", simplePinStyle.ToQueryString());
            Assert.AreEqual("default|coF5F5DC|sc1.75|ro-47|ls1.1||'B label'11.73 25.02|14.561 19.801|12.56 22.56|'A label'7.9 44", complexPinStyle1.ToQueryString());
            Assert.AreEqual("custom|sc1.05|an4 -5|lc802DDF|ls0.9|la5 -6||'B label'11.73 25.02|'A label'7.9 44||http://contoso.com/pushpins/red.png", complexPinStyle2.ToQueryString());
        }
    }
}
