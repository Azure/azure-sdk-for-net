// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Text;
using Azure.Core.GeoJson;
using Microsoft.Spatial;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class SearchFilterTests
    {
        [Test]
        public void NoArguments()
        {
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq 2"));
        }

        [Test]
        public void OneArgument()
        {
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {2}"));
        }

        [Test]
        public void ManyArguments()
        {
            Assert.AreEqual("Foo eq 2 and Bar eq 3",
                SearchFilter.Create($"Foo eq {2} and Bar eq {3}"));
            Assert.AreEqual("Foo eq 2 and Bar eq 3 and Baz eq 4",
                SearchFilter.Create($"Foo eq {2} and Bar eq {3} and Baz eq {4}"));
            Assert.AreEqual("Foo eq 2 and Bar eq 3 and Baz eq 4 and Qux eq 5",
                SearchFilter.Create($"Foo eq {2} and Bar eq {3} and Baz eq {4} and Qux eq {5}"));
            Assert.AreEqual("Foo eq 2 and Bar eq 3 and Baz eq 4 and Qux eq 5 and Quux eq 6",
                SearchFilter.Create($"Foo eq {2} and Bar eq {3} and Baz eq {4} and Qux eq {5} and Quux eq {6}"));
        }

        [Test]
        public void Null()
        {
            Assert.AreEqual("Foo eq null", SearchFilter.Create($"Foo eq {null}"));
        }

        [Test]
        public void Bool()
        {
            bool x = true;
            Assert.AreEqual("Foo eq true", SearchFilter.Create($"Foo eq {x}"));
            Assert.AreEqual("Foo eq true", SearchFilter.Create($"Foo eq {true}"));

            x = false;
            Assert.AreEqual("Foo eq false", SearchFilter.Create($"Foo eq {x}"));
            Assert.AreEqual("Foo eq false", SearchFilter.Create($"Foo eq {false}"));
        }

        [Test]
        public void Zero()
        {
            Assert.AreEqual("Foo eq 0", SearchFilter.Create($"Foo eq {(sbyte)0}"));
            Assert.AreEqual("Foo eq 0", SearchFilter.Create($"Foo eq {(byte)0}"));
            Assert.AreEqual("Foo eq 0", SearchFilter.Create($"Foo eq {(short)0}"));
            Assert.AreEqual("Foo eq 0", SearchFilter.Create($"Foo eq {(ushort)0}"));
            Assert.AreEqual("Foo eq 0", SearchFilter.Create($"Foo eq {(int)0}"));
            Assert.AreEqual("Foo eq 0", SearchFilter.Create($"Foo eq {(uint)0}"));
            Assert.AreEqual("Foo eq 0", SearchFilter.Create($"Foo eq {(long)0}"));
            Assert.AreEqual("Foo eq 0", SearchFilter.Create($"Foo eq {(ulong)0}"));
            Assert.AreEqual("Foo eq 0", SearchFilter.Create($"Foo eq {(decimal)0}"));
            Assert.AreEqual("Foo eq 0", SearchFilter.Create($"Foo eq {(float)0}"));
            Assert.AreEqual("Foo eq 0", SearchFilter.Create($"Foo eq {(double)0}"));
        }

        [Test]
        public void Positive()
        {
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {(sbyte)2}"));
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {(byte)2}"));
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {(short)2}"));
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {(ushort)2}"));
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {(int)2}"));
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {(uint)2}"));
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {(long)2}"));
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {(ulong)2}"));
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {(decimal)2}"));
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {(float)2}"));
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {(double)2}"));
        }

        [Test]
        public void Negative()
        {
            Assert.AreEqual("Foo eq -2", SearchFilter.Create($"Foo eq {(sbyte)-2}"));
            Assert.AreEqual("Foo eq -2", SearchFilter.Create($"Foo eq {(short)-2}"));
            Assert.AreEqual("Foo eq -2", SearchFilter.Create($"Foo eq {(int)-2}"));
            Assert.AreEqual("Foo eq -2", SearchFilter.Create($"Foo eq {(long)-2}"));
            Assert.AreEqual("Foo eq -2", SearchFilter.Create($"Foo eq {(decimal)-2}"));
            Assert.AreEqual("Foo eq -2", SearchFilter.Create($"Foo eq {(float)-2}"));
            Assert.AreEqual("Foo eq -2", SearchFilter.Create($"Foo eq {(double)-2}"));
        }

        [Test]
        public void Decimals()
        {
            Assert.AreEqual("Foo eq 2.5", SearchFilter.Create($"Foo eq {(decimal)2.5}"));
            Assert.AreEqual("Foo eq 2.5", SearchFilter.Create($"Foo eq {(float)2.5}"));
            Assert.AreEqual("Foo eq 2.5", SearchFilter.Create($"Foo eq {(double)2.5}"));
        }

        [Test]
        public void Exponents()
        {
            Assert.AreEqual("Foo eq 2.5e+10", SearchFilter.Create($"Foo eq {(float)2.5e10}"));
            Assert.AreEqual("Foo eq 2.5e+20", SearchFilter.Create($"Foo eq {(double)2.5e20}"));
        }

        [Test]
        public void Limits()
        {
            Assert.AreEqual("Foo eq NaN", SearchFilter.Create($"Foo eq {float.NaN}"));
            Assert.AreEqual("Foo eq NaN", SearchFilter.Create($"Foo eq {double.NaN}"));

            Assert.AreEqual("Foo eq INF", SearchFilter.Create($"Foo eq {float.PositiveInfinity}"));
            Assert.AreEqual("Foo eq INF", SearchFilter.Create($"Foo eq {double.PositiveInfinity}"));

            Assert.AreEqual("Foo eq -INF", SearchFilter.Create($"Foo eq {float.NegativeInfinity}"));
            Assert.AreEqual("Foo eq -INF", SearchFilter.Create($"Foo eq {double.NegativeInfinity}"));
        }

        [Test]
        public void Dates()
        {
            Assert.AreEqual("Alan eq 1912-06-23T11:59:59.0000000+00:00",
                SearchFilter.Create($"Alan eq {new DateTime(1912, 6, 23, 11, 59, 59)}"));
            Assert.AreEqual("Alan eq 1912-06-23T11:59:59.0000000+00:00",
                SearchFilter.Create($"Alan eq {new DateTimeOffset(1912, 6, 23, 11, 59, 59, TimeSpan.Zero)}"));
        }

        [Test]
        public void Text()
        {
            Assert.AreEqual("Foo eq 'x'", SearchFilter.Create($"Foo eq {'x'}"));
            Assert.AreEqual("Foo eq ''''", SearchFilter.Create($"Foo eq {'\''}"));
            Assert.AreEqual("Foo eq '\"'", SearchFilter.Create($"Foo eq {'"'}"));

            Assert.AreEqual("Foo eq 'bar'", SearchFilter.Create($"Foo eq {"bar"}"));
            Assert.AreEqual("Foo eq 'bar''s'", SearchFilter.Create($"Foo eq {"bar's"}"));
            Assert.AreEqual("Foo eq '\"bar\"'", SearchFilter.Create($"Foo eq {"\"bar\""}"));

            StringBuilder sb = new StringBuilder("bar");
            Assert.AreEqual("Foo eq 'bar'", SearchFilter.Create($"Foo eq {sb}"));
        }

        [Test]
        public void Points()
        {
            GeoPosition position = new GeoPosition(2.0, 3.0);
            Assert.AreEqual("geo.distance(geography'POINT(2 3)', Foo) < 3", SearchFilter.Create($"geo.distance({position}, Foo) < 3"));
            Assert.AreEqual("geo.distance(geography'POINT(2 3)', Foo) < 3", SearchFilter.Create($"geo.distance({new GeoPosition(2.0, 3.0, 5.0)}, Foo) < 3"));
            Assert.AreEqual("geo.distance(geography'POINT(2 3)', Foo) < 3", SearchFilter.Create($"geo.distance({new GeoPoint(position)}, Foo) < 3"));
        }

        [Test]
        public void Polygons()
        {
            GeoLineString line = new GeoLineString(
                new[]
                {
                    new GeoPosition(0, 0),
                    new GeoPosition(0, 1),
                    new GeoPosition(1, 1),
                    new GeoPosition(0, 0),
                });
            Assert.AreEqual(
                "geo.intersects(Foo, geography'POLYGON((0 0,0 1,1 1,0 0))')",
                SearchFilter.Create($"geo.intersects(Foo, {line})"));

            GeoPolygon polygon = new GeoPolygon(line.Coordinates);
            Assert.AreEqual(
                "geo.intersects(Foo, geography'POLYGON((0 0,0 1,1 1,0 0))')",
                SearchFilter.Create($"geo.intersects(Foo, {polygon})"));

            Assert.Throws<ArgumentException>(() => SearchFilter.Create(
                $"{new GeoLineString(new[] { new GeoPosition(0, 0) })}"));
            Assert.Throws<ArgumentException>(() => SearchFilter.Create(
                $"{new GeoLineString(new[] { new GeoPosition(0, 0), new GeoPosition(0, 0), new GeoPosition(0, 0), new GeoPosition(1, 1) })}"));
            Assert.Throws<ArgumentException>(() => SearchFilter.Create(
                $"{new GeoPolygon(new[] { new GeoLinearRing(line.Coordinates), new GeoLinearRing(line.Coordinates) })}"));
        }

        [TestCaseSource(nameof(GetMicrosoftSpatialPointsData))]
        public void MicrosoftSpatialPoints(string filter) =>
            Assert.AreEqual("geo.distance(geography'POINT(2 3)', Foo) < 3", filter);

        private static IEnumerable GetMicrosoftSpatialPointsData()
        {
            GeographyPoint point = GeographyPoint.Create(3.0, 2.0);

            yield return new TestCaseData(SearchFilter.Create($"geo.distance({point}, Foo) < 3"));
            yield return new TestCaseData(SearchFilter.Create($"geo.distance({GeographyPoint.Create(3.0, 2.0, 5.0)}, Foo) < 3"));
        }

        [TestCaseSource(nameof(GetMicrosoftSpatialPolygonsData))]
        public string MicrosoftSpatialPolygons(object geography) =>
            SearchFilter.Create($"geo.intersects(Foo, {geography})");

        private static IEnumerable GetMicrosoftSpatialPolygonsData()
        {
            GeographyLineString line = GeographyFactory
                .LineString(0, 0)
                .LineTo(1, 0)
                .LineTo(1, 1)
                .LineTo(0, 0);

            yield return new TestCaseData(line).Returns("geo.intersects(Foo, geography'POLYGON((0 0,0 1,1 1,0 0))')");

            GeographyPolygon polygon = GeographyFactory
                .Polygon()
                .Ring(0, 0)
                .LineTo(1, 0)
                .LineTo(1, 1)
                .LineTo(0, 0);

            yield return new TestCaseData(polygon).Returns("geo.intersects(Foo, geography'POLYGON((0 0,0 1,1 1,0 0))')");
        }

        [TestCaseSource(nameof(GetMicrosoftSpatialPolygonsThrowsData))]
        public void MicrosoftSpatialPolygonsThrows(object geography, string expectedException)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => SearchFilter.Create($"{geography}"));
            StringAssert.StartsWith(expectedException, ex.Message);
        }

        private static IEnumerable GetMicrosoftSpatialPolygonsThrowsData()
        {
            // Require >= 4 points.
            GeographyLineString line = GeographyFactory
                .LineString(0, 0)
                .LineTo(1, 1);

            yield return new TestCaseData(
                line,
                "A GeographyLineString must have at least four Points to form a searchable polygon.");

            // Requires that first and last points are the same.
            line = GeographyFactory
                .LineString(0, 0)
                .LineTo(0, 0)
                .LineTo(0, 0)
                .LineTo(1, 1);

            yield return new TestCaseData(
                line,
                "A GeographyLineString must have matching first and last Points to form a searchable polygon.");

            // Require that polygons define exactly 1 ring.
           GeographyPolygon polygon = GeographyFactory
                .Polygon()
                .Ring(0, 0)
                .LineTo(0, 1)
                .LineTo(1, 1)
                .LineTo(0, 0)
                .Ring(2, 2)
                .LineTo(2, 3)
                .LineTo(3, 3)
                .LineTo(2, 2);

            yield return new TestCaseData(
                polygon,
                "A GeographyPolygon must have exactly one Rings to form a searchable polygon.");
        }

        [Test]
        public void OtherThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => SearchFilter.Create($"Foo eq {new string[] { }}"));
            Assert.AreEqual("Unable to convert argument 0 from type System.String[] to an OData literal.", ex.Message);
        }
    }
}
