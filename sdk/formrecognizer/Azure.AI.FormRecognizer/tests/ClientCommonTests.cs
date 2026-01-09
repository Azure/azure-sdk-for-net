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
            Assert.That(ClientCommon.ConvertToListOfPointF(null), Is.Empty);
        }

        [Test]
        public void CovertToListOfPointFReturnsEmptyWhenCoordinatesIsEmpty()
        {
            Assert.That(ClientCommon.ConvertToListOfPointF(Array.Empty<float>()), Is.Empty);
        }

        [Test]
        public void CovertToListOfPointFConvertsFloatsToPointF()
        {
            var floatPoints = new List<float>() { 1.0f, 1.5f, 2.0f, 2.5f, 3.0f, 3.5f, 4.0f, 4.5f };
            IReadOnlyList<PointF> points = ClientCommon.ConvertToListOfPointF(floatPoints);

            Assert.That(points, Has.Count.EqualTo(4));
            Assert.Multiple(() =>
            {
                Assert.That(points[0].X, Is.EqualTo(1.0f));
                Assert.That(points[0].Y, Is.EqualTo(1.5f));
                Assert.That(points[1].X, Is.EqualTo(2.0f));
                Assert.That(points[1].Y, Is.EqualTo(2.5f));
                Assert.That(points[2].X, Is.EqualTo(3.0f));
                Assert.That(points[2].Y, Is.EqualTo(3.5f));
                Assert.That(points[3].X, Is.EqualTo(4.0f));
                Assert.That(points[3].Y, Is.EqualTo(4.5f));
            });
        }
    }
}
