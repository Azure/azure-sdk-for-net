// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json;
#if EXPERIMENTAL_SPATIAL
using Azure.Core.Spatial;
#endif
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class SearchDocumentTests
    {
        #region Utilities
        private static void AssertCollectionEqual(IEnumerable expected, IEnumerable actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual);
                return;
            }
            Assert.IsNotNull(actual);

            IEnumerator exp = expected.GetEnumerator();
            IEnumerator act = actual.GetEnumerator();
            int moved = 0;
            do
            {
                moved = (exp.MoveNext(), act.MoveNext()) switch
                {
                    (true, true) => 2,
                    (true, false) => 1,
                    (false, true) => 2,
                    (false, false) => 0
                };
                if (moved == 2)
                {
                    SearchTestBase.AssertApproximate(exp.Current, act.Current);
                }
            } while (moved == 2);
            Assert.Zero(moved);
        }

        private static string ToJson(string value, string name = "Value") =>
            $"{{\"{name}\":{value}}}";

        private static SearchDocument FromJson(string json) =>
            JsonSerializer.Deserialize<SearchDocument>(json);

        private static SearchDocument ToDocument(string value, string name = "Value") =>
            FromJson(ToJson(value, name));

        public class TestValue<T>
        {
            public string JsonValue { get; private set; }
            public T Expected { get; set; }
            public bool CanReadDictionary { get; set; }
            public bool CanReadDynamic { get; set; }
            public bool CanReadGetter { get; set; }

            private TestValue(string json, T expected, bool dict, bool dyn, bool getter)
            {
                JsonValue = json;
                Expected = expected;
                CanReadDictionary = dict;
                CanReadDynamic = dyn;
                CanReadGetter = getter;
            }

            public static TestValue<T> Exact(string jsonValue, T expected) =>
                new TestValue<T>(jsonValue, expected, dict: true, dyn: true, getter: true);

            public static TestValue<T> Convert(string jsonValue, T expected) =>
                new TestValue<T>(jsonValue, expected, dict: false, dyn: true, getter: true);

            public static TestValue<T> Fail(string jsonValue) =>
                new TestValue<T>(jsonValue, default, dict: false, dyn: false, getter: false);

            public override string ToString()
            {
                string operation = (CanReadDictionary, CanReadDynamic, CanReadGetter) switch
                {
                    (true, true, true) => "Exact",
                    (false, true, true) => "Convert",
                    _ => "Fail"
                };
                return $"{operation}: {JsonValue}";
            }

            public TestValue<U> As<U>() =>
                new TestValue<U>(JsonValue, (U)(object)Expected, CanReadDictionary, CanReadDynamic, CanReadGetter);

            private static bool IsCollection<U>() =>
                typeof(U).IsGenericType &&
                typeof(U).GetGenericTypeDefinition() == typeof(IReadOnlyList<>);

            public void Check(Func<SearchDocument, string, T> getter = null)
            {
                SearchDocument doc = null;
                try { doc = ToDocument(JsonValue, "Value"); }
                catch (Exception ex) { Assert.Fail($"Failed to parse {JsonValue}: {ex}"); }

                if (CanReadDictionary)
                {
                    AssertReadDictionary(doc);
                }
                else
                {
                    AssertReadDictionaryFails(doc);
                }

#if EXPERIMENTAL_DYNAMIC
                if (CanReadDynamic)
                {
                    AssertReadDynamic(doc);
                }
                else
                {
                    AssertReadDynamicFails(doc);
                }
#endif

                if (getter != null)
                {
                    if (CanReadGetter)
                    {
                        AssertReadGetter(doc, getter);
                    }
                    else if (getter != null)
                    {
                        AssertReadGetterFails(doc, getter);
                    }
                }
            }

            private void AssertReadDictionary(SearchDocument doc)
            {
                object actual = doc["Value"];

                bool isCollection = IsCollection<T>();
                if (actual != null)
                {
                    if (!isCollection)
                    {
                        Assert.IsInstanceOf<T>(actual);
                    }
                    else
                    {
                        // Note: Arrays returned by the indexer are object[], not T[]
                        Assert.IsInstanceOf<object[]>(actual);
                    }
                }

                if (!isCollection)
                {
                    SearchTestBase.AssertApproximate(Expected, actual);
                }
                else
                {
                    if (actual != null)
                    {
                        CollectionAssert.AllItemsAreInstancesOfType(actual as IEnumerable, typeof(T).GetGenericArguments()[0]);
                    }
                    AssertCollectionEqual(Expected as IEnumerable, actual as IEnumerable);
                }
            }

            private static void AssertReadDictionaryFails(SearchDocument doc)
            {
                if (!IsCollection<T>())
                {
                    object actual = doc["Value"];
                    Assert.IsNotInstanceOf<T>(actual);
                }
                else if (doc["Value"] is object[] actual && actual?.Length > 0)
                {
                    Assert.IsTrue(actual.Any(e => !(e is T)));
                }
            }

            private void AssertReadDynamic(SearchDocument doc)
            {
                dynamic dyn = doc;
                if (!IsCollection<T>())
                {
                    T actual = dyn.Value;
                    SearchTestBase.AssertApproximate(Expected, actual);
                }
                else
                {
                    // TODO: Change from object[] to T when DynamicData has better conversions
                    object[] actual = dyn.Value;
                    AssertCollectionEqual(Expected as IEnumerable, actual as IEnumerable);
                }
            }

            private static void AssertReadDynamicFails(SearchDocument doc)
            {
                dynamic dyn = doc;
                object actual = dyn.Value;
                if (actual != null && IsCollection<T>())
                {
                    Assert.IsNotInstanceOf<T>(actual);
                }
                // TODO: Change from object[] to T when DynamicData has better conversions
                else if (actual is object[] values && values?.Length > 0)
                {
                    Assert.IsTrue(values.Any(e => !(e is T)));
                }
            }

            private void AssertReadGetter(SearchDocument doc, Func<SearchDocument, string, T> getter)
            {
                Assert.IsNotNull(getter);
                T actual = getter(doc, "Value");
                if (!IsCollection<T>())
                {
                    SearchTestBase.AssertApproximate(Expected, actual);
                }
                else
                {
                    AssertCollectionEqual(Expected as IEnumerable, actual as IEnumerable);
                }
            }

            private static void AssertReadGetterFails(SearchDocument doc, Func<SearchDocument, string, T> getter)
            {
                Assert.IsNotNull(getter);
                bool throws = false;
                try
                {
                    getter(doc, "Value");
                }
                catch (Exception)
                {
                    throws = true;
                }
                Assert.IsTrue(throws, "Expected an exception to be thrown!");
            }
        }

        private static TestValue<T?>[] GetNullableValues<T>(TestValue<T>[] values) where T : struct
        {
            List<TestValue<T?>> cases = new List<TestValue<T?>>();
            foreach (TestValue<T> original in values)
            {
                TestValue<T?> test = original.As<T?>();
                if (test.JsonValue == "null")
                {
                    test.Expected = null;
                    test.CanReadDictionary = true;
                    test.CanReadDynamic = true;
                    test.CanReadGetter = true;
                }
                cases.Add(test);
            }
            return cases.ToArray();
        }

        private static TestValue<IReadOnlyList<T>>[] GetCollectionValues<T>(params TestValue<IReadOnlyList<T>>[] values)
        {
            var common = new[]
            {
                TestValue<IReadOnlyList<T>>.Exact("[]", new T[] { }),
                TestValue<IReadOnlyList<T>>.Exact("null", null),

                TestValue<IReadOnlyList<T>>.Fail("true"),
                TestValue<IReadOnlyList<T>>.Fail("false"),
                TestValue<IReadOnlyList<T>>.Fail("\"\""),
                TestValue<IReadOnlyList<T>>.Fail("\"hello\""),
                TestValue<IReadOnlyList<T>>.Fail("{}"),
                TestValue<IReadOnlyList<T>>.Fail("0"),
                TestValue<IReadOnlyList<T>>.Fail("1"),
                TestValue<IReadOnlyList<T>>.Fail("0.5"),
            };

            List<TestValue<IReadOnlyList<T>>> cases = new List<TestValue<IReadOnlyList<T>>>();
            cases.AddRange(values);
            cases.AddRange(common);
            return cases.ToArray();
        }
        #endregion

        [TestCaseSource(nameof(BooleanValues))]
        public void GetBools(TestValue<bool> test) => test.Check((d, n) => d.GetBoolean(n).Value);
        private static TestValue<bool>[] BooleanValues =>
            new[]
            {
                TestValue<bool>.Exact("true", true),
                TestValue<bool>.Exact("false", false),

                TestValue<bool>.Fail("null"),
                TestValue<bool>.Fail("\"\""),
                TestValue<bool>.Fail("\"true\""),
                TestValue<bool>.Fail("\"false\""),
                TestValue<bool>.Fail("\"True\""),
                TestValue<bool>.Fail("\"False\""),
                TestValue<bool>.Fail("{}"),
                TestValue<bool>.Fail("[]"),
                TestValue<bool>.Fail("0"),
                TestValue<bool>.Fail("1"),
                TestValue<bool>.Fail("0.5"),
            };

        [TestCaseSource(nameof(NullableBooleanValues))]
        public void GetNullableBools(TestValue<bool?> test) => test.Check((d,n) => d.GetBoolean(n));
        private static TestValue<bool?>[] NullableBooleanValues => GetNullableValues(BooleanValues);

        [TestCaseSource(nameof(BooleanCollectionValues))]
        public void GetBoolCollections(TestValue<IReadOnlyList<bool>> test) => test.Check((d, n) => d.GetBooleanCollection(n));
        private static TestValue<IReadOnlyList<bool>>[] BooleanCollectionValues =>
            GetCollectionValues(
                TestValue<IReadOnlyList<bool>>.Exact("[true]", new bool[] { true }),
                TestValue<IReadOnlyList<bool>>.Exact("[false]", new bool[] { false }),
                TestValue<IReadOnlyList<bool>>.Exact("[true, false]", new bool[] { true, false }));

        [TestCaseSource(nameof(StringValues))]
        public void GetStrings(TestValue<string> test) => test.Check((d, n) => d.GetString(n));
        private static TestValue<string>[] StringValues =>
            new[]
            {
                TestValue<string>.Exact("null", null),
                TestValue<string>.Exact("\"\"", ""),
                TestValue<string>.Exact("\"a\"", "a"),
                TestValue<string>.Exact("\"1\"", "1"),
                TestValue<string>.Exact("\"Hello\"", "Hello"),
                TestValue<string>.Exact("\"\\\"\"", "\""),
                TestValue<string>.Exact("\"\\\"\\\"\"", "\"\""),
                TestValue<string>.Exact("\"\\\"Hi!\\\"\"", "\"Hi!\""),

                TestValue<string>.Fail("true"),
                TestValue<string>.Fail("false"),
                TestValue<string>.Fail("{}"),
                TestValue<string>.Fail("[]"),
                TestValue<string>.Fail("0"),
                TestValue<string>.Fail("1"),
                TestValue<string>.Fail("0.5")
            };

        [TestCaseSource(nameof(StringCollectionValues))]
        public void GetStringCollections(TestValue<IReadOnlyList<string>> test) => test.Check((d, n) => d.GetStringCollection(n));
        private static TestValue<IReadOnlyList<string>>[] StringCollectionValues =>
            GetCollectionValues(
                TestValue<IReadOnlyList<string>>.Exact("[\"a\"]", new string[] { "a" }),
                TestValue<IReadOnlyList<string>>.Exact("[\"\"]", new string[] { "" }),
                TestValue<IReadOnlyList<string>>.Exact("[\"a\", \"b\", \"\"]", new string[] { "a", "b", "" }));

        [TestCaseSource(nameof(Int32Values))]
        public void GetInt32s(TestValue<int> test) => test.Check((d,n) => d.GetInt32(n).Value);
        private static TestValue<int>[] Int32Values =>
            new[]
            {
                TestValue<int>.Exact("0", 0),
                TestValue<int>.Exact("1", 1),
                TestValue<int>.Exact("-1", -1),
                TestValue<int>.Exact("2", 2),
                TestValue<int>.Exact("10", 10),
                TestValue<int>.Exact("100", 100),
                TestValue<int>.Exact("10000", 10000),
                TestValue<int>.Exact("2147483647", int.MaxValue),
                TestValue<int>.Exact("-2147483648", int.MinValue),

                TestValue<int>.Fail("null"),
                TestValue<int>.Fail("true"),
                TestValue<int>.Fail("false"),
                TestValue<int>.Fail("{}"),
                TestValue<int>.Fail("[]"),
                TestValue<int>.Fail("\"\""),
                TestValue<int>.Fail("\"1\""),
                TestValue<int>.Fail("0.5"),
                TestValue<int>.Fail("2147483648"),
                TestValue<int>.Fail("-2147483649")
            };

        [TestCaseSource(nameof(NullableInt32Values))]
        public void GetNullableInt32s(TestValue<int?> test) => test.Check((d, n) => d.GetInt32(n));
        private static TestValue<int?>[] NullableInt32Values => GetNullableValues(Int32Values);

        [TestCaseSource(nameof(Int32CollectionValues))]
        public void GetInt32Collections(TestValue<IReadOnlyList<int>> test) => test.Check((d, n) => d.GetInt32Collection(n));
        private static TestValue<IReadOnlyList<int>>[] Int32CollectionValues =>
            GetCollectionValues(
                TestValue<IReadOnlyList<int>>.Exact("[0]", new int[] { 0 }),
                TestValue<IReadOnlyList<int>>.Exact("[10]", new int[] { 10 }),
                TestValue<IReadOnlyList<int>>.Exact("[1, 2, 3]", new int[] { 1, 2, 3 }),
                TestValue<IReadOnlyList<int>>.Exact("[-1, -2, -3]", new int[] { -1, -2, -3 }),
                TestValue<IReadOnlyList<int>>.Exact("[0, 2147483647, -2147483648]", new int[] { 0, int.MaxValue, int.MinValue }),
                TestValue<IReadOnlyList<int>>.Fail("[0, 2147483648, -2147483649]"));

        [TestCaseSource(nameof(Int64Values))]
        public void GetInt64s(TestValue<long> test) => test.Check((d, n) => d.GetInt64(n).Value);
        private static TestValue<long>[] Int64Values =>
            new[]
            {
                TestValue<long>.Exact("2147483648", (long)int.MaxValue + 1L),
                TestValue<long>.Exact("-2147483649", (long)int.MinValue - 1L),
                TestValue<long>.Exact("9223372036854775807", long.MaxValue),
                TestValue<long>.Exact("-9223372036854775808", long.MinValue),

                TestValue<long>.Convert("0", 0),
                TestValue<long>.Convert("1", 1),
                TestValue<long>.Convert("-1", -1),
                TestValue<long>.Convert("2", 2),
                TestValue<long>.Convert("10", 10),
                TestValue<long>.Convert("100", 100),
                TestValue<long>.Convert("10000", 10000),
                TestValue<long>.Convert("2147483647", (long)int.MaxValue),
                TestValue<long>.Convert("-2147483648", (long)int.MinValue),

                TestValue<long>.Fail("null"),
                TestValue<long>.Fail("true"),
                TestValue<long>.Fail("false"),
                TestValue<long>.Fail("{}"),
                TestValue<long>.Fail("[]"),
                TestValue<long>.Fail("\"\""),
                TestValue<long>.Fail("\"1\""),
                TestValue<long>.Fail("0.5"),
                TestValue<long>.Fail("9223372036854775808"),
                TestValue<long>.Fail("-9223372036854775809"),
            };

        [TestCaseSource(nameof(NullableInt64Values))]
        public void GetNullableInt64s(TestValue<long?> test) => test.Check((d, n) => d.GetInt64(n));
        private static TestValue<long?>[] NullableInt64Values => GetNullableValues(Int64Values);

        [TestCaseSource(nameof(Int64CollectionValues))]
        public void GetInt64Collections(TestValue<IReadOnlyList<long>> test) => test.Check((d, n) => d.GetInt64Collection(n));
        private static TestValue<IReadOnlyList<long>>[] Int64CollectionValues =>
            GetCollectionValues(
                TestValue<IReadOnlyList<long>>.Exact("[2147483648]", new long[] { int.MaxValue + 1L }),
                TestValue<IReadOnlyList<long>>.Exact("[-2147483649]", new long[] { int.MinValue - 1L }),
                TestValue<IReadOnlyList<long>>.Exact("[2147483648, -2147483649]", new long[] { int.MaxValue + 1L, int.MinValue - 1L }),
                TestValue<IReadOnlyList<long>>.Convert("[1]", new long[] { 1 }),
                TestValue<IReadOnlyList<long>>.Convert("[1, 2, 3]", new long[] { 1, 2, 3 }),
                TestValue<IReadOnlyList<long>>.Convert("[0, 2147483648, -2147483649]", new long[] { 0L, int.MaxValue + 1L, int.MinValue - 1L }),
                TestValue<IReadOnlyList<long>>.Fail("[0, 9223372036854775808, -9223372036854775809]"));

        [TestCaseSource(nameof(DoubleValues))]
        public void GetDoubles(TestValue<double> test) => test.Check((d, n) => d.GetDouble(n).Value);
        private static TestValue<double>[] DoubleValues =>
            new[]
            {
                TestValue<double>.Exact("0.0", 0),
                TestValue<double>.Exact("1.0", 1),
                TestValue<double>.Exact("1e0", 1),
                TestValue<double>.Exact("1.5e1", 15),
                TestValue<double>.Exact("1.55e1", 15.5),
                TestValue<double>.Exact("1.55e2", 155),
                TestValue<double>.Exact("1.5", 1.5),
                TestValue<double>.Exact("-1.5", -1.5),
                TestValue<double>.Exact("-1e0", -1),
                TestValue<double>.Exact("-1.5e1", -15),
                TestValue<double>.Exact("-1.55e2", -155),
                TestValue<double>.Exact("9.2233720368547758E+18", long.MaxValue),
                TestValue<double>.Exact("-9.2233720368547758E+18", long.MinValue),

                TestValue<double>.Convert("\"NaN\"", double.NaN),
                TestValue<double>.Convert("\"INF\"", double.PositiveInfinity),
                TestValue<double>.Convert("\"-INF\"", double.NegativeInfinity),
                TestValue<double>.Convert("0", 0),
                TestValue<double>.Convert("1", 1),
                TestValue<double>.Convert("-1", -1),
                TestValue<double>.Convert("2", 2),
                TestValue<double>.Convert("10", 10),
                TestValue<double>.Convert("100", 100),
                TestValue<double>.Convert("10000", 10000),
                TestValue<double>.Convert("2147483647", int.MaxValue),
                TestValue<double>.Convert("-2147483648", int.MinValue),

                TestValue<double>.Fail("null"),
                TestValue<double>.Fail("true"),
                TestValue<double>.Fail("false"),
                TestValue<double>.Fail("{}"),
                TestValue<double>.Fail("[]"),
                TestValue<double>.Fail("\"\""),
                TestValue<double>.Fail("\"1\""),
            };

        [TestCaseSource(nameof(NullableDoubleValues))]
        public void GetNullableDoubles(TestValue<double?> test) => test.Check((d, n) => d.GetDouble(n));
        private static TestValue<double?>[] NullableDoubleValues => GetNullableValues(DoubleValues);

        [TestCaseSource(nameof(DoubleCollectionValues))]
        public void GetDoubleCollections(TestValue<IReadOnlyList<double>> test) => test.Check((d, n) => d.GetDoubleCollection(n));
        private static TestValue<IReadOnlyList<double>>[] DoubleCollectionValues =>
            GetCollectionValues(
                TestValue<IReadOnlyList<double>>.Exact("[0.5]", new double[] { 0.5 }),
                TestValue<IReadOnlyList<double>>.Exact("[0.0, 0.5, 1.0]", new double[] { 0.0, 0.5, 1.0 }),
                TestValue<IReadOnlyList<double>>.Convert("[0, 0.5, 1]", new double[] { 0.0, 0.5, 1.0 }));

        [TestCaseSource(nameof(DateTimeOffsetValues))]
        public void GetDateTimeOffsets(TestValue<DateTimeOffset> test) => test.Check((d, n) => d.GetDateTimeOffset(n).Value);
        private static TestValue<DateTimeOffset>[] DateTimeOffsetValues =>
            new[]
            {
                TestValue<DateTimeOffset>.Convert(
                    "\"2020-01-20T15:50:00+00:00\"",
                    new DateTimeOffset(2020, 1, 20, 15, 50, 0, TimeSpan.Zero)),
                TestValue<DateTimeOffset>.Convert(
                    "\"2020-01-20T15:50:00+00:00\"",
                    new DateTimeOffset(2020, 1, 20, 15, 50, 0, TimeSpan.Zero).ToUniversalTime()),
                TestValue<DateTimeOffset>.Convert(
                    "\"2017-01-13T14:03:00-08:00\"",
                    new DateTimeOffset(2017, 1, 13, 14, 3, 0, 0, TimeSpan.FromHours(-8))),
                TestValue<DateTimeOffset>.Convert(
                    "\"2017-01-13T22:03:00+00:00\"",
                    new DateTimeOffset(2017, 1, 13, 14, 3, 0, 0, TimeSpan.FromHours(-8)).ToUniversalTime()),
                TestValue<DateTimeOffset>.Fail("null"),
                TestValue<DateTimeOffset>.Fail("true"),
                TestValue<DateTimeOffset>.Fail("false"),
                TestValue<DateTimeOffset>.Fail("{}"),
                TestValue<DateTimeOffset>.Fail("[]"),
                TestValue<DateTimeOffset>.Fail("\"\""),
                TestValue<DateTimeOffset>.Fail("\"1\""),
                TestValue<DateTimeOffset>.Fail("0.5")
            };

        [TestCaseSource(nameof(NullableDateTimeOffsetValues))]
        public void GetNullableDateTimeOffsets(TestValue<DateTimeOffset?> test) => test.Check((d, n) => d.GetDateTimeOffset(n));
        private static TestValue<DateTimeOffset?>[] NullableDateTimeOffsetValues => GetNullableValues(DateTimeOffsetValues);

        [TestCaseSource(nameof(DateTimeOffsetCollectionValues))]
        public void GetDateTimeOffsetCollections(TestValue<IReadOnlyList<DateTimeOffset>> test) => test.Check((d, n) => d.GetDateTimeOffsetCollection(n));
        private static TestValue<IReadOnlyList<DateTimeOffset>>[] DateTimeOffsetCollectionValues =>
            GetCollectionValues(
                TestValue<IReadOnlyList<DateTimeOffset>>.Convert(
                    "[\"2020-01-20T15:50:00+00:00\"]",
                    new DateTimeOffset[] { new DateTimeOffset(2020, 1, 20, 15, 50, 0, TimeSpan.Zero) }),
                TestValue<IReadOnlyList<DateTimeOffset>>.Convert(
                    "[\"2017-01-13T14:03:00-08:00\"]",
                    new DateTimeOffset[] { new DateTimeOffset(2017, 1, 13, 14, 3, 0, 0, TimeSpan.FromHours(-8)) }),
                TestValue<IReadOnlyList<DateTimeOffset>>.Convert(
                    "[\"2020-01-20T15:50:00+00:00\", \"2017-01-13T14:03:00-08:00\", \"2017-01-13T22:03:00+00:00\"]",
                    new DateTimeOffset[]
                    {
                        new DateTimeOffset(2020, 1, 20, 15, 50, 0, TimeSpan.Zero),
                        new DateTimeOffset(2017, 1, 13, 14, 3, 0, 0, TimeSpan.FromHours(-8)),
                        new DateTimeOffset(2017, 1, 13, 14, 3, 0, 0, TimeSpan.FromHours(-8)).ToUniversalTime()
                    }));

#if EXPERIMENTAL_SPATIAL
        [TestCaseSource(nameof(PointValues))]
        public void GetPoints(TestValue<PointGeometry> test) => test.Check((d, n) => d.GetPoint(n));
        private static TestValue<PointGeometry>[] PointValues =>
            new[]
            {
                TestValue<PointGeometry>.Exact(
                    "{\"type\":\"Point\",\"coordinates\":[0, 0]}",
                    new PointGeometry(new GeometryPosition(0, 0))),
                TestValue<PointGeometry>.Exact(
                    "{\"type\":\"Point\",\"coordinates\":[2, 3]}",
                    new PointGeometry(new GeometryPosition(2, 3))),
                TestValue<PointGeometry>.Exact(
                    "{\"type\":\"Point\",\"coordinates\":[2, 3, 5]}",
                    new PointGeometry(new GeometryPosition(2, 3, 5))),
                TestValue<PointGeometry>.Exact("null", null),

                TestValue<PointGeometry>.Fail("true"),
                TestValue<PointGeometry>.Fail("false"),
                TestValue<PointGeometry>.Fail("{}"),
                TestValue<PointGeometry>.Fail("[]"),
                TestValue<PointGeometry>.Fail("0"),
                TestValue<PointGeometry>.Fail("1"),
                TestValue<PointGeometry>.Fail("0.5")
            };

        [TestCaseSource(nameof(PointCollectionValues))]
        public void GetPointCollections(TestValue<IReadOnlyList<PointGeometry>> test) => test.Check((d, n) => d.GetPointCollection(n));
        private static TestValue<IReadOnlyList<PointGeometry>>[] PointCollectionValues =>
            GetCollectionValues(
                TestValue<IReadOnlyList<PointGeometry>>.Exact(
                    "[{\"type\":\"Point\",\"coordinates\":[0, 1]}]",
                    new[] { new PointGeometry(new GeometryPosition(0, 1)) }),
                TestValue<IReadOnlyList<PointGeometry>>.Exact(
                    "[{\"type\":\"Point\",\"coordinates\":[0, 1]},{\"type\":\"Point\",\"coordinates\":[2, 3]}]",
                    new[]
                    {
                        new PointGeometry(new GeometryPosition(0, 1)),
                        new PointGeometry(new GeometryPosition(2, 3))
                    }));
#endif

        public class Complex
        {
            public int A { get; set; }
            public bool B { get; set; }
            public string C { get; set; }
            public Complex() : this(0, false, null) { }
            public Complex(int a, bool b, string c) { A = a; B = b; C = c; }
            public string ToJson() => JsonSerializer.Serialize(this);
            public SearchDocument ToDocument() => FromJson(ToJson());
        }

        public class ComplexNullable
        {
            public int? X { get; set; }
            public bool? Y { get; set; }
            public string Z { get; set; }
            public ComplexNullable() : this(null, null, null) { }
            public ComplexNullable(int? x, bool? y, string z) { X = x; Y = y; Z = z; }
            public string ToJson() => JsonSerializer.Serialize(this);
            public SearchDocument ToDocument() => FromJson(ToJson());
        }

        public class NestedComplex
        {
            public Complex Nested { get; set; }
            public NestedComplex() : this(null) { }
            public NestedComplex(int a, bool b, string c) : this(new Complex(a, b, c)) { }
            public NestedComplex(Complex nested) { Nested = nested; }
            public string ToJson() => JsonSerializer.Serialize(this);
            public SearchDocument ToDocument() => FromJson(ToJson());
        }

        [TestCaseSource(nameof(ComplexValues))]
        public void GetComplex(TestValue<SearchDocument> test) => test.Check((d, n) => d.GetObject(n));
        private static TestValue<SearchDocument>[] ComplexValues =>
            new[]
            {
                TestValue<SearchDocument>.Exact("null", null),
                TestValue<SearchDocument>.Exact("{ }", new SearchDocument()),

                TestValue<SearchDocument>.Exact(
                    new Complex().ToJson(),
                    new Complex().ToDocument()),
                TestValue<SearchDocument>.Exact(
                    new Complex(12, true, "hello").ToJson(),
                    new Complex(12, true, "hello").ToDocument()),
                TestValue<SearchDocument>.Exact(
                    new Complex(-3, false, "bye").ToJson(),
                    new Complex(-3, false, "bye").ToDocument()),

                TestValue<SearchDocument>.Exact(
                    new ComplexNullable().ToJson(),
                    new ComplexNullable().ToDocument()),
                TestValue<SearchDocument>.Exact(
                    new ComplexNullable(12, true, "hello").ToJson(),
                    new ComplexNullable(12, true, "hello").ToDocument()),
                TestValue<SearchDocument>.Exact(
                    new ComplexNullable(null, null, "bye").ToJson(),
                    new ComplexNullable(null, null, "bye").ToDocument()),

                TestValue<SearchDocument>.Exact(
                    new NestedComplex().ToJson(),
                    new NestedComplex().ToDocument()),
                TestValue<SearchDocument>.Exact(
                    new NestedComplex(1, true, "hi").ToJson(),
                    new NestedComplex(1, true, "hi").ToDocument()),

                TestValue<SearchDocument>.Fail("true"),
                TestValue<SearchDocument>.Fail("false"),
                TestValue<SearchDocument>.Fail("\"\""),
                TestValue<SearchDocument>.Fail("\"hello\""),
                TestValue<SearchDocument>.Fail("[]"),
                TestValue<SearchDocument>.Fail("0"),
                TestValue<SearchDocument>.Fail("1"),
                TestValue<SearchDocument>.Fail("0.5"),
            };

        [TestCaseSource(nameof(ComplexCollectionValues))]
        public void GetComplexCollections(TestValue<IReadOnlyList<SearchDocument>> test) => test.Check((d, n) => d.GetObjectCollection(n));
        private static TestValue<IReadOnlyList<SearchDocument>>[] ComplexCollectionValues =>
            GetCollectionValues(
                TestValue<IReadOnlyList<SearchDocument>>.Exact(
                    "[{ }]",
                    new[] { new SearchDocument() }),
                TestValue<IReadOnlyList<SearchDocument>>.Exact(
                    $"[{new Complex().ToJson()}]",
                    new[] { new Complex().ToDocument() }),
                TestValue<IReadOnlyList<SearchDocument>>.Exact(
                    $"[{new Complex(1, true, "hi").ToJson()}, {new Complex(2, false, "bye").ToJson()}]",
                    new[] { new Complex(1, true, "hi").ToDocument(), new Complex(2, false, "bye").ToDocument() }),
                TestValue<IReadOnlyList<SearchDocument>>.Exact(
                    $"[{new ComplexNullable(1, true, "hi").ToJson()}, {new ComplexNullable(2, false, "bye").ToJson()}]",
                    new[] { new ComplexNullable(1, true, "hi").ToDocument(), new ComplexNullable(2, false, "bye").ToDocument() }),
                TestValue<IReadOnlyList<SearchDocument>>.Exact(
                    $"[{new Complex().ToJson()}, {new ComplexNullable().ToJson()}]",
                    new[] { new Complex().ToDocument(), new ComplexNullable().ToDocument() }));

#if EXPERIMENTAL_DYNAMIC
        [Test]
#endif
        public void Index()
        {
            dynamic doc = ToDocument("12");
            int value = doc.Value;
            SearchTestBase.AssertApproximate(12, value);
        }

#if EXPERIMENTAL_DYNAMIC
        [Test]
#endif
        public void IndexComplex()
        {
            dynamic doc = ToDocument(new Complex(1, true, "hi").ToJson());

            int a = doc.Value.A;
            SearchTestBase.AssertApproximate(1, a);

            bool b = doc.Value.B;
            SearchTestBase.AssertApproximate(true, b);

            string c = doc.Value.C;
            SearchTestBase.AssertApproximate("hi", c);
        }

#if EXPERIMENTAL_DYNAMIC
        [Test]
#endif
        public void IndexNestedComplex()
        {
            dynamic doc = ToDocument(new NestedComplex(1, true, "hi").ToJson());

            int a = doc.Value.Nested.A;
            SearchTestBase.AssertApproximate(1, a);

            bool b = doc.Value.Nested.B;
            SearchTestBase.AssertApproximate(true, b);

            string c = doc.Value.Nested.C;
            SearchTestBase.AssertApproximate("hi", c);
        }

        [Test]
        public void Equality()
        {
            SearchTestBase.AssertApproximate(
                new SearchDocument(),
                new SearchDocument());

            Assert.AreNotEqual(
                new SearchDocument(),
                new Complex().ToDocument());
            SearchTestBase.AssertApproximate(
                new Complex().ToDocument(),
                new Complex().ToDocument());

            Assert.AreNotEqual(
                new Complex(1, false, "hi").ToDocument(),
                new NestedComplex(1, false, "hi").ToDocument());
            SearchTestBase.AssertApproximate(
                new NestedComplex(1, false, "hi").ToDocument(),
                new NestedComplex(1, false, "hi").ToDocument());
            SearchTestBase.AssertApproximate(
                new Complex(1, false, "hi").ToDocument(),
                new NestedComplex(1, false, "hi").Nested.ToDocument());
        }

#if EXPERIMENTAL_DYNAMIC
        [Test]
#endif
        public void NoDynamicObjectMembers()
        {
            Assert.IsInstanceOf<IDynamicMetaObjectProvider>(new SearchDocument());
            Assert.IsNotInstanceOf<DynamicObject>(new SearchDocument());
        }

        [Test]
        public void TooDeepToParse()
        {
            string Wrap(string value) => "{\"x\":" + value + ",\"y\":[1,2,3]}";

            // Push it to the limit
            string json = "1";
            for (int i = 0; i < 63; i++)
            {
                json = Wrap(json);
            }
            JsonSerializer.Deserialize<SearchDocument>(json);

            // Go just a little too far
            json = Wrap(json);
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<SearchDocument>(json));
        }
    }
}
