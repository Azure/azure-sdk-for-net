// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
#if EXPERIMENTAL_SPATIAL
using Azure.Core.Spatial;
#endif
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

#if EXPERIMENTAL_SPATIAL
        [Test]
        public void Points()
        {
            GeometryPosition position = new GeometryPosition(2.0, 3.0);
            Assert.AreEqual("geo.distance(geography'POINT(2 3)', Foo) < 3", SearchFilter.Create($"geo.distance({position}, Foo) < 3"));
            Assert.AreEqual("geo.distance(geography'POINT(2 3)', Foo) < 3", SearchFilter.Create($"geo.distance({new GeometryPosition(2.0, 3.0, 5.0)}, Foo) < 3"));
            Assert.AreEqual("geo.distance(geography'POINT(2 3)', Foo) < 3", SearchFilter.Create($"geo.distance({new PointGeometry(position)}, Foo) < 3"));
        }

        [Test]
        public void Polygons()
        {
            LineGeometry line = new LineGeometry(
                new[]
                {
                    new GeometryPosition(0, 0),
                    new GeometryPosition(0, 1),
                    new GeometryPosition(1, 1),
                    new GeometryPosition(0, 0),
                });
            Assert.AreEqual(
                "geo.intersects(Foo, geography'POLYGON((0 0,0 1,1 1,0 0))')",
                SearchFilter.Create($"geo.intersects(Foo, {line})"));

            PolygonGeometry polygon = new PolygonGeometry(new[] { line });
            Assert.AreEqual(
                "geo.intersects(Foo, geography'POLYGON((0 0,0 1,1 1,0 0))')",
                SearchFilter.Create($"geo.intersects(Foo, {polygon})"));

            Assert.Throws<ArgumentException>(() => SearchFilter.Create(
                $"{new LineGeometry(new[] { new GeometryPosition(0, 0) })}"));
            Assert.Throws<ArgumentException>(() => SearchFilter.Create(
                $"{new LineGeometry(new[] { new GeometryPosition(0, 0), new GeometryPosition(0, 0), new GeometryPosition(0, 0), new GeometryPosition(1, 1) })}"));
            Assert.Throws<ArgumentException>(() => SearchFilter.Create(
                $"{new PolygonGeometry(new[] { line, line })}"));
        }
#endif

        [Test]
        public void OtherThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => SearchFilter.Create($"Foo eq {new string[] { }}"));
            Assert.AreEqual("Unable to convert argument 0 from type System.String[] to an OData literal.", ex.Message);
        }
    }
}
