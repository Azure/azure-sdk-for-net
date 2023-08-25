// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="ClientCommon"/> class.
    /// </summary>
    public class ClientCommonTests
    {
        [Test]
        public void CovertToListOfPointFReturnsEmptyWhenCoordinatesIsNull()
        {
            Assert.IsEmpty(ClientCommon.ConvertToListOfPointF(null));
        }

        [Test]
        public void CovertToListOfPointFReturnsEmptyWhenCoordinatesIsEmpty()
        {
            Assert.IsEmpty(ClientCommon.ConvertToListOfPointF(Array.Empty<float>()));
        }

        [Test]
        public void CovertToListOfPointFConvertsFloatsToPointF()
        {
            var floatPoints = new List<float>() { 1.0f, 1.5f, 2.0f, 2.5f, 3.0f, 3.5f, 4.0f, 4.5f };
            IReadOnlyList<PointF> points = ClientCommon.ConvertToListOfPointF(floatPoints);

            Assert.AreEqual(4, points.Count);
            Assert.AreEqual(1.0f, points[0].X);
            Assert.AreEqual(1.5f, points[0].Y);
            Assert.AreEqual(2.0f, points[1].X);
            Assert.AreEqual(2.5f, points[1].Y);
            Assert.AreEqual(3.0f, points[2].X);
            Assert.AreEqual(3.5f, points[2].Y);
            Assert.AreEqual(4.0f, points[3].X);
            Assert.AreEqual(4.5f, points[3].Y);
        }
    }
}
