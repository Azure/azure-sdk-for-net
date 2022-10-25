// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="BoundingRegion"/> class.
    /// </summary>
    internal class BoundingRegionTests
    {
        public void EqualsObjectReturnsFalseIfObjectIsNull()
        {
            BoundingRegion region = GetBoundingRegion(10, 50f, 60f, 70f, 80f);

            Assert.False(region.Equals(null));
        }

        [Test]
        public void EqualsObjectReturnsFalseIfObjectOfDifferentType()
        {
            BoundingRegion region = GetBoundingRegion(10, 50f, 60f, 70f, 80f);
            var list = new List<object>() { 10, 50f, 60f, 70f, 80f };

            Assert.False(region.Equals(list));
        }

        [Test]
        public void EqualsObjectReturnsFalseIfPageNumberDiffers()
        {
            BoundingRegion region = GetBoundingRegion(10, 50f, 60f, 70f, 80f);
            object objRegion = GetBoundingRegion(11, 50f, 60f, 70f, 80f);

            Assert.False(region.Equals(objRegion));
        }

        [Test]
        public void EqualsObjectReturnsFalseIfPointsCountDiffers()
        {
            BoundingRegion region = GetBoundingRegion(10, 50f, 50f, 50f, 50f);
            object objRegion = GetBoundingRegion(10, 50f, 50f);

            Assert.False(region.Equals(objRegion));
        }

        [Test]
        public void EqualsObjectReturnsFalseIfCoordinateDiffers()
        {
            BoundingRegion region = GetBoundingRegion(10, 50f, 60f, 70f, 80f);
            object objRegion = GetBoundingRegion(10, 50f, 60f, 70f, 85f);

            Assert.False(region.Equals(objRegion));
        }

        [Test]
        public void EqualsObjectReturnsTrueIfEqual()
        {
            BoundingRegion region = GetBoundingRegion(10, 50f, 60f, 70f, 80f);
            object objRegion = GetBoundingRegion(10, 50f, 60f, 70f, 80f);

            Assert.True(region.Equals(objRegion));
        }

        [Test]
        public void EqualsObjectReturnsTrueIfBoundingPolygonIsShifted()
        {
            BoundingRegion region = GetBoundingRegion(10, 50f, 60f, 70f, 80f, 90f, 100f);
            object objRegion = GetBoundingRegion(10, 90f, 100f, 50f, 60f, 70f, 80f);

            Assert.True(region.Equals(objRegion));
        }

        [Test]
        public void EqualsReturnsFalseIfPageNumberDiffers()
        {
            BoundingRegion region1 = GetBoundingRegion(10, 50f, 60f, 70f, 80f);
            BoundingRegion region2 = GetBoundingRegion(11, 50f, 60f, 70f, 80f);

            Assert.False(region1.Equals(region2));
        }

        [Test]
        public void EqualsReturnsFalseIfPointsCountDiffers()
        {
            BoundingRegion region1 = GetBoundingRegion(10, 50f, 50f, 50f, 50f);
            BoundingRegion region2 = GetBoundingRegion(10, 50f, 50f);

            Assert.False(region1.Equals(region2));
        }

        [Test]
        public void EqualsReturnsFalseIfCoordinateDiffers()
        {
            BoundingRegion region1 = GetBoundingRegion(10, 50f, 60f, 70f, 80f);
            BoundingRegion region2 = GetBoundingRegion(10, 50f, 60f, 70f, 85f);

            Assert.False(region1.Equals(region2));
        }

        [Test]
        public void EqualsReturnsTrueIfEqual()
        {
            BoundingRegion region1 = GetBoundingRegion(10, 50f, 60f, 70f, 80f);
            BoundingRegion region2 = GetBoundingRegion(10, 50f, 60f, 70f, 80f);

            Assert.True(region1.Equals(region2));
        }

        [Test]
        public void EqualsReturnsTrueIfBoundingPolygonIsShifted()
        {
            BoundingRegion region1 = GetBoundingRegion(10, 50f, 60f, 70f, 80f, 90f, 100f);
            BoundingRegion region2 = GetBoundingRegion(10, 90f, 100f, 50f, 60f, 70f, 80f);

            Assert.True(region1.Equals(region2));
        }

        [Test]
        public void GetHashCodeReturnsDifferentHashCodeIfPageNumberDiffers()
        {
            BoundingRegion region1 = GetBoundingRegion(10, 50f, 60f, 70f, 80f);
            BoundingRegion region2 = GetBoundingRegion(11, 50f, 60f, 70f, 80f);

            Assert.AreNotEqual(region1.GetHashCode(), region2.GetHashCode());
        }

        [Test]
        public void GetHashCodeReturnsDifferentHashCodeIfPointsCountDiffers()
        {
            BoundingRegion region1 = GetBoundingRegion(10, 50f, 50f, 50f, 50f);
            BoundingRegion region2 = GetBoundingRegion(10, 50f, 50f);

            Assert.AreNotEqual(region1.GetHashCode(), region2.GetHashCode());
        }

        [Test]
        public void GetHashCodeReturnsDifferentHashCodeIfCoordinateDiffers()
        {
            BoundingRegion region1 = GetBoundingRegion(10, 50f, 60f, 70f, 80f);
            BoundingRegion region2 = GetBoundingRegion(10, 50f, 60f, 70f, 85f);

            Assert.AreNotEqual(region1.GetHashCode(), region2.GetHashCode());
        }

        [Test]
        public void GetHashCodeReturnsSameHashCodeIfEqual()
        {
            BoundingRegion region1 = GetBoundingRegion(10, 50f, 60f, 70f, 80f);
            BoundingRegion region2 = GetBoundingRegion(10, 50f, 60f, 70f, 80f);

            Assert.AreEqual(region1.GetHashCode(), region2.GetHashCode());
        }

        [Test]
        public void GetHashCodeReturnsSameHashCodeIfBoundingPolygonIsShifted()
        {
            BoundingRegion region1 = GetBoundingRegion(10, 50f, 60f, 70f, 80f, 90f, 100f);
            BoundingRegion region2 = GetBoundingRegion(10, 90f, 100f, 50f, 60f, 70f, 80f);

            Assert.AreEqual(region1.GetHashCode(), region2.GetHashCode());
        }

        [Test]
        public void ToStringConvertsToExpectedFormat()
        {
            BoundingRegion region = GetBoundingRegion(10, 50f, 60f, 70f, 80f);

            Assert.AreEqual("Page: 10, Polygon: {X=50, Y=60},{X=70, Y=80}", region.ToString());
        }

        public BoundingRegion GetBoundingRegion(int pageNumber, float px, float py)
        {
            var points = new List<PointF>()
            {
                new PointF(px, py)
            };

            return new BoundingRegion(pageNumber, points);
        }

        public BoundingRegion GetBoundingRegion(int pageNumber, float p1x, float p1y, float p2x, float p2y)
        {
            var points = new List<PointF>()
            {
                new PointF(p1x, p1y),
                new PointF(p2x, p2y)
            };

            return new BoundingRegion(pageNumber, points);
        }

        public BoundingRegion GetBoundingRegion(int pageNumber, float p1x, float p1y, float p2x, float p2y, float p3x, float p3y)
        {
            var points = new List<PointF>()
            {
                new PointF(p1x, p1y),
                new PointF(p2x, p2y),
                new PointF(p3x, p3y)
            };

            return new BoundingRegion(pageNumber, points);
        }
    }
}
