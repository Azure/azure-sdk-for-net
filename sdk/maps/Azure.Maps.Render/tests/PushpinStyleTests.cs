// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Drawing;
using NUnit.Framework;

// cspell:ignore fromargb udid
namespace Azure.Maps.Render.Tests
{
    public class PushpinStyleTests
    {
        [Test]
        public void TestPinPosition()
        {
            var pinPosition = new PinPosition(12.56, 22.56);
            var pinPositionWithLabel = new PinPosition(12.56, 22.56, "A label");
            var udidPin = new PinPosition("udid-29dc105a-dee7-409f-a3f9-22b066ae4713", "UDID");

            Assert.AreEqual("12.56 22.56", pinPosition.ToString());
            Assert.AreEqual("'A label'12.56 22.56", pinPositionWithLabel.ToString());
            Assert.AreEqual("'UDID'udid-29dc105a-dee7-409f-a3f9-22b066ae4713", udidPin.ToString());
        }

        [Test]
        public void TestPushpinStyle()
        {
            var pinPosition1 = new PinPosition(12.56, 22.56);
            var pinPosition2 = new PinPosition(14.561, 19.801);
            var pinPosition3 = new PinPosition(7.9, 44.0, "A label");
            var pinPosition4 = new PinPosition(11.73, 25.02, "B label");
            var pinPosition5 = new PinPosition("udid-29dc105a-dee7-409f-a3f9-22b066ae4713", "UDID");
            var simplePinStyle = new PushpinStyle(
                new System.Collections.Generic.List<PinPosition>() {
                    pinPosition1, pinPosition2, pinPosition3, pinPosition4
                }
            );
            var ComplexPinStyle1 = new PushpinStyle(
                new System.Collections.Generic.List<PinPosition>() {
                    pinPosition4, pinPosition2, pinPosition5, pinPosition1, pinPosition3
                }
            )
            {
                PinScale = 1.75,
                PinColor = Color.Beige,
                RotationInDegrees = -47,
                LabelScale = 1.1
            };
            var ComplexPinStyle2 = new PushpinStyle(
                new System.Collections.Generic.List<PinPosition>() {
                    pinPosition4, pinPosition3
                }
            )
            {
                PinAnchorShiftInPixels = new Point(4, -5),
                PinScale = 1.05,
                LabelColor = Color.FromArgb(47, 128, 45, 223), // A, R, G, B
                LabelScale = 0.9,
                LabelAnchorShiftInPixels = new Point(5, -6),
                CustomPinImage = new Uri("http://contoso.com/pushpins/red.png"),
            };

            Assert.AreEqual("default||12.56 22.56|14.561 19.801|'A label'7.9 44|'B label'11.73 25.02", simplePinStyle.ToString());
            Assert.AreEqual("default|coF5F5FF|sc1.75|ro-47|ls1.1||'B label'11.73 25.02|14.561 19.801|'UDID'udid-29dc105a-dee7-409f-a3f9-22b066ae4713|12.56 22.56|'A label'7.9 44", ComplexPinStyle1.ToString());
            Assert.AreEqual("custom|sc1.05|an4 -5|lc802DDF|ls0.9|la5 -6||'B label'11.73 25.02|'A label'7.9 44||http://contoso.com/pushpins/red.png", ComplexPinStyle2.ToString());
        }
    }
}
