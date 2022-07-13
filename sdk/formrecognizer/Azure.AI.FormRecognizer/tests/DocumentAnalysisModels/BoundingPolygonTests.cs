// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="BoundingPolygon"/> struct.
    /// </summary>
    public class BoundingPolygonTests
    {
        [Test]
        public void IndexerThrowsWhenBoundingPolygonIsDefault()
        {
            BoundingPolygon boundingPolygon = default;
            Assert.Throws<IndexOutOfRangeException>(() => { var _ = boundingPolygon[0]; });
        }

        [Test]
        public void IndexerThrowsWhenBoundingPolygonIsEmpty()
        {
            BoundingPolygon boundingPolygon = new BoundingPolygon(new List<float>());
            Assert.Throws<IndexOutOfRangeException>(() => { var _ = boundingPolygon[0]; });
        }

        [Test]
        public void ToStringDoesNotThrowWhenBoundingPolygonIsDefault()
        {
            BoundingPolygon boundingPolygon = default;
            Assert.DoesNotThrow(() => boundingPolygon.ToString());
        }

        [Test]
        public void ToStringDoesNotThrowWhenBoundingPolygonIsEmpty()
        {
            BoundingPolygon boundingPolygon = new BoundingPolygon(new List<float>());
            Assert.DoesNotThrow(() => boundingPolygon.ToString());
        }
    }
}
