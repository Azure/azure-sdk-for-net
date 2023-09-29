// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using Azure.Core.Json;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    internal class MutableJsonElementTests
    {
        [Test]
        public void ToStringWorksWithNoChanges()
        {
            string json = """
                {
                  "Bar" : "Hi!",
                  "Foo" : "\"+"
                }
                """;

            MutableJsonElement element = MutableJsonDocument.Parse(json).RootElement;

            ValidateToString(json, element);
        }

        [Test]
        public void ToStringWorksWithChanges()
        {
            string json = """
                {
                  "Bar" : "Hi!"
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            mdoc.RootElement.GetProperty("Bar").Set(null);

            string expected = """
                {
                  "Bar" : null
                }
                """;

            ValidateToString(expected, mdoc.RootElement);
        }

        [Test]
        public void ChangesToElementAppearInToString()
        {
            string json = """
                {
                  "Bar" : "Hi!"
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("Bar").Set("hello");

            string expected = """
                {
                  "Bar" : "hello"
                }
                """;

            ValidateToString(expected, mdoc.RootElement);
        }

        [Test]
        public void ChangesToElementAppearInJsonElement()
        {
            string json = """
                {
                  "Bar" : "Hi!"
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("Bar").Set("hello");

            JsonElement barElement = mdoc.RootElement.GetProperty("Bar").GetJsonElement();
            Assert.AreEqual("hello", barElement.GetString());

            JsonElement rootElement = mdoc.RootElement.GetJsonElement();

            string expected = """
                {
                  "Bar" : "hello"
                }
                """;

            Assert.AreEqual(
                MutableJsonDocumentTests.RemoveWhiteSpace(expected),
                MutableJsonDocumentTests.RemoveWhiteSpace(rootElement.ToString())
            );
        }

        [Test]
        public void CanGetNullElement()
        {
            string json = """
                {
                  "Bar" : null
                }
                """;

            var jd = MutableJsonDocument.Parse(json);

            MutableJsonElement bar = jd.RootElement.GetProperty("Bar");

            Assert.AreEqual(JsonValueKind.Null, bar.ValueKind);
        }

        [Test]
        public void ValueKindReflectsChanges()
        {
            string json = """
                {
                  "Bar" : "Hi!"
                }
            """;

            var jd = MutableJsonDocument.Parse(json);

            Assert.AreEqual(JsonValueKind.String, jd.RootElement.GetProperty("Bar").ValueKind);

            jd.RootElement.GetProperty("Bar").Set(1.2);

            Assert.AreEqual(JsonValueKind.Number, jd.RootElement.GetProperty("Bar").ValueKind);

            jd.RootElement.GetProperty("Bar").Set(null);

            Assert.AreEqual(JsonValueKind.Null, jd.RootElement.GetProperty("Bar").ValueKind);
        }

        [Test]
        public void CanEnumerateArray()
        {
            string json = "[0, 1, 2, 3]";

            MutableJsonDocument jd = MutableJsonDocument.Parse(json);

            MutableJsonElement.ArrayEnumerator enumerator = jd.RootElement.EnumerateArray();

            int expected = 0;
            foreach (MutableJsonElement el in enumerator)
            {
                Assert.AreEqual(expected++, el.GetInt32());
            }

            Assert.AreEqual(4, expected);
        }

        [Test]
        public void CanEnumerateArrayWithChanges()
        {
            string json = "[0, 1, 2, 3]";

            MutableJsonDocument jd = MutableJsonDocument.Parse(json);

            for (int i = 0; i < 4; i++)
            {
                jd.RootElement.GetIndexElement(i).Set(i + 1);
            }

            MutableJsonElement.ArrayEnumerator enumerator = jd.RootElement.EnumerateArray();

            int expected = 1;
            foreach (MutableJsonElement el in enumerator)
            {
                Assert.AreEqual(expected++, el.GetInt32());
            }

            Assert.AreEqual(5, expected);
        }

        [Test]
        public void EnumeratedArrayValueCanBeChanged()
        {
            string json = "[0, 1, 2, 3]";

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            MutableJsonElement.ArrayEnumerator enumerator = mdoc.RootElement.EnumerateArray();

            MutableJsonElement value = default;
            foreach (MutableJsonElement item in enumerator)
            {
                value = item;
            }

            value.Set(5);
            Assert.AreEqual(5, value.GetInt32());
            Assert.AreEqual(5, mdoc.RootElement.GetIndexElement(3).GetInt32());
        }

        [Test]
        public void CanEnumerateObject()
        {
            string json = """
                {
                  "Zero" : 0,
                  "One" : 1,
                  "Two" : 2,
                  "Three" : 3
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            MutableJsonElement.ObjectEnumerator enumerator = mdoc.RootElement.EnumerateObject();

            int expected = 0;
            string[] expectedNames = new string[] { "Zero", "One", "Two", "Three" };

            foreach ((string Name, MutableJsonElement Value) property in enumerator)
            {
                Assert.AreEqual(expectedNames[expected], property.Name);
                Assert.AreEqual(expected, property.Value.GetInt32());
                expected++;
            }

            Assert.AreEqual(4, expected);
        }

        [Test]
        public void CanEnumerateObjectWithChanges()
        {
            string json = """
                {
                  "Zero" : 0,
                  "One" : 1,
                  "Two" : 2,
                  "Three" : 3
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            string[] expectedNames = new string[] { "Zero", "One", "Two", "Three" };

            for (int i = 0; i < 4; i++)
            {
                mdoc.RootElement.GetProperty(expectedNames[i]).Set(i + 1);
            }

            MutableJsonElement.ObjectEnumerator enumerator = mdoc.RootElement.EnumerateObject();

            int index = 0;
            foreach ((string Name, MutableJsonElement Value) property in enumerator)
            {
                Assert.AreEqual(expectedNames[index], property.Name);
                Assert.AreEqual(index + 1, property.Value.GetInt32());
                index++;
            }

            Assert.AreEqual(4, index);
        }

        [Test]
        public void EnumeratedPropertyValueCanBeChanged()
        {
            string json = """
                {
                  "Foo" : 0,
                  "Bar" : 1
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            MutableJsonElement.ObjectEnumerator enumerator = mdoc.RootElement.EnumerateObject();

            int index = 0;
            MutableJsonElement value = default;
            foreach ((string Name, MutableJsonElement Value) property in enumerator)
            {
                value = property.Value;
                index++;
            }

            value.Set(5);

            Assert.AreEqual(5, value.GetInt32());
            Assert.AreEqual(5, mdoc.RootElement.GetProperty("Bar").GetInt32());
        }

        [Test]
        public void PropertyEnumeratorIncludesAddedProperties()
        {
            MutableJsonDocument mdoc = MutableJsonDocument.Parse("""
                {
                    "object" : {   
                        "zero" : 0,
                        "one" : 1,
                        "two" : 2
                    }
                }
                """);

            mdoc.RootElement.GetProperty("object").SetProperty("three", 3);
            MutableJsonElement.ObjectEnumerator enumerator = mdoc.RootElement.GetProperty("object").EnumerateObject();

            int expected = 0;
            string[] expectedNames = new string[] { "zero", "one", "two", "three" };

            foreach ((string Name, MutableJsonElement Value) property in enumerator)
            {
                Assert.AreEqual(expectedNames[expected], property.Name);
                Assert.AreEqual(expected, property.Value.GetInt32());
                expected++;
            }
        }

        [Test]
        public void PropertyEnumeratorExcludesRemovedProperties()
        {
            MutableJsonDocument mdoc = MutableJsonDocument.Parse("""
                {
                    "object" : {   
                        "zero" : 0,
                        "one" : 1,
                        "two" : 2
                    }
                }
                """);

            mdoc.RootElement.GetProperty("object").RemoveProperty("zero");
            MutableJsonElement.ObjectEnumerator enumerator = mdoc.RootElement.GetProperty("object").EnumerateObject();

            int expected = 0;
            string[] expectedNames = new string[] { "one", "two" };

            foreach ((string Name, MutableJsonElement Value) property in enumerator)
            {
                Assert.AreEqual(expectedNames[expected], property.Name);
                Assert.AreEqual(++expected, property.Value.GetInt32());
            }
        }

        [Test]
        public void CanGetByte()
        {
            string json = """
                {
                  "foo" : 42
                }
                """;

            // Get from parsed JSON
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            Assert.IsTrue(mdoc.RootElement.GetProperty("foo").TryGetByte(out byte b));
            Assert.AreEqual((byte)42, b);
            Assert.AreEqual((byte)42, mdoc.RootElement.GetProperty("foo").GetByte());

            // Get from assigned existing value
            byte newValue = 43;
            mdoc.RootElement.GetProperty("foo").Set(newValue);

            Assert.IsTrue(mdoc.RootElement.GetProperty("foo").TryGetByte(out b));
            Assert.AreEqual(newValue, b);
            Assert.AreEqual(newValue, mdoc.RootElement.GetProperty("foo").GetByte());

            // Get from added value
            mdoc.RootElement.SetProperty("bar", (byte)44);
            Assert.IsTrue(mdoc.RootElement.GetProperty("bar").TryGetByte(out b));
            Assert.AreEqual((byte)44, b);
            Assert.AreEqual((byte)44, mdoc.RootElement.GetProperty("bar").GetByte());

            // Doesn't work if number change is outside byte range
            mdoc.RootElement.GetProperty("foo").Set(256);
            Assert.IsFalse(mdoc.RootElement.GetProperty("foo").TryGetByte(out b));
            Assert.Throws<FormatException>(() => mdoc.RootElement.GetProperty("foo").GetByte());

            // Doesn't work for non-number change
            mdoc.RootElement.GetProperty("foo").Set("string");
            Assert.Throws<InvalidOperationException>(() => mdoc.RootElement.GetProperty("foo").TryGetByte(out b));
            Assert.Throws<InvalidOperationException>(() => mdoc.RootElement.GetProperty("foo").GetByte());
        }

        [TestCaseSource(nameof(NumberValues))]
        public void CanGetNumber<T, U>(string serializedX, T x, T y, T z, U invalid,
            Func<MutableJsonElement, (bool TryGet, T Value)> tryGet,
            Func<MutableJsonElement, T> get,
            Action<MutableJsonDocument, string, T> set,
            Func<MutableJsonDocument, string, T, MutableJsonElement> setProperty)
        {
            string json = $"{{\"foo\" : {serializedX}}}";

            // Get from parsed JSON
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            Assert.IsTrue(tryGet(mdoc.RootElement.GetProperty("foo")).TryGet);
            Assert.AreEqual(x, tryGet(mdoc.RootElement.GetProperty("foo")).Value);
            Assert.AreEqual(x, get(mdoc.RootElement.GetProperty("foo")));

            // Get from assigned existing value
            set(mdoc, "foo", y);
            Assert.IsTrue(tryGet(mdoc.RootElement.GetProperty("foo")).TryGet);
            Assert.AreEqual(y, tryGet(mdoc.RootElement.GetProperty("foo")).Value);
            Assert.AreEqual(y, get(mdoc.RootElement.GetProperty("foo")));

            // Get from added value
            setProperty(mdoc, "bar", z);
            Assert.IsTrue(tryGet(mdoc.RootElement.GetProperty("bar")).TryGet);
            Assert.AreEqual(z, tryGet(mdoc.RootElement.GetProperty("bar")).Value);
            Assert.AreEqual(z, get(mdoc.RootElement.GetProperty("bar")));

            // Doesn't work if number change is outside range
            if (invalid is bool testRange && testRange)
            {
                mdoc.RootElement.GetProperty("foo").Set(testRange);
                Assert.IsFalse(tryGet(mdoc.RootElement.GetProperty("foo")).TryGet);
                Assert.Throws<FormatException>(() => get(mdoc.RootElement.GetProperty("foo")));
            }

            // Doesn't work for non-number change
            mdoc.RootElement.GetProperty("foo").Set("string");
            Assert.Throws<InvalidOperationException>(() => tryGet(mdoc.RootElement.GetProperty("foo")));
            Assert.Throws<InvalidOperationException>(() => get(mdoc.RootElement.GetProperty("foo")));
        }

        [Test]
        public void CanGetGuid()
        {
            Guid guid = Guid.NewGuid();
            string json = $"{{\"foo\" : \"{guid}\"}}";

            // Get from parsed JSON
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            Assert.IsTrue(mdoc.RootElement.GetProperty("foo").TryGetGuid(out Guid g));
            Assert.AreEqual(guid, g);
            Assert.AreEqual(guid, mdoc.RootElement.GetProperty("foo").GetGuid());

            // Get from assigned existing value
            Guid fooValue = Guid.NewGuid();
            mdoc.RootElement.GetProperty("foo").Set(fooValue);

            Assert.IsTrue(mdoc.RootElement.GetProperty("foo").TryGetGuid(out g));
            Assert.AreEqual(fooValue, g);
            Assert.AreEqual(fooValue, mdoc.RootElement.GetProperty("foo").GetGuid());

            // Get from newly added value
            Guid barValue = Guid.NewGuid();
            mdoc.RootElement.SetProperty("bar", barValue);

            Assert.IsTrue(mdoc.RootElement.GetProperty("bar").TryGetGuid(out g));
            Assert.AreEqual(barValue, g);
            Assert.AreEqual(barValue, mdoc.RootElement.GetProperty("bar").GetGuid());

            // Can get them as a strings, too
            Assert.AreEqual(JsonValueKind.String, mdoc.RootElement.GetProperty("foo").ValueKind);
            Assert.AreEqual(fooValue.ToString(), mdoc.RootElement.GetProperty("foo").GetString());
            Assert.AreEqual(JsonValueKind.String, mdoc.RootElement.GetProperty("bar").ValueKind);
            Assert.AreEqual(barValue.ToString(), mdoc.RootElement.GetProperty("bar").GetString());

            // Doesn't work for non-string change
            mdoc.RootElement.GetProperty("foo").Set(true);
            Assert.Throws<InvalidOperationException>(() => mdoc.RootElement.GetProperty("foo").TryGetGuid(out g));
            Assert.Throws<InvalidOperationException>(() => mdoc.RootElement.GetProperty("foo").GetGuid());
        }

        [Test]
        public void CanGetDateTime()
        {
            DateTime dateTime = DateTime.Parse("2023-05-07T21:04:45.1657010-07:00");
            string dateTimeString = FormatDateTime(dateTime);
            string json = $"{{\"foo\" : \"{dateTimeString}\"}}";

            // Get from parsed JSON
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            Assert.IsTrue(mdoc.RootElement.GetProperty("foo").TryGetDateTime(out DateTime d));
            Assert.AreEqual(dateTime, d);
            Assert.AreEqual(dateTime, mdoc.RootElement.GetProperty("foo").GetDateTime());

            // Get from assigned existing value
            DateTime fooValue = dateTime.AddDays(1);
            mdoc.RootElement.GetProperty("foo").Set(fooValue);

            Assert.IsTrue(mdoc.RootElement.GetProperty("foo").TryGetDateTime(out d));
            Assert.AreEqual(fooValue, d);
            Assert.AreEqual(fooValue, mdoc.RootElement.GetProperty("foo").GetDateTime());

            // Get from newly added value
            DateTime barValue = dateTime.AddDays(2);
            mdoc.RootElement.SetProperty("bar", barValue);

            Assert.IsTrue(mdoc.RootElement.GetProperty("bar").TryGetDateTime(out d));
            Assert.AreEqual(barValue, d);
            Assert.AreEqual(barValue, mdoc.RootElement.GetProperty("bar").GetDateTime());

            // Can get them as a strings, too
            Assert.AreEqual(JsonValueKind.String, mdoc.RootElement.GetProperty("foo").ValueKind);
            Assert.AreEqual(FormatDateTime(fooValue), mdoc.RootElement.GetProperty("foo").GetString());
            Assert.AreEqual(JsonValueKind.String, mdoc.RootElement.GetProperty("bar").ValueKind);
            Assert.AreEqual(FormatDateTime(barValue), mdoc.RootElement.GetProperty("bar").GetString());

            // Doesn't work for non-string change
            mdoc.RootElement.GetProperty("foo").Set(true);
            Assert.Throws<InvalidOperationException>(() => mdoc.RootElement.GetProperty("foo").TryGetDateTime(out d));
            Assert.Throws<InvalidOperationException>(() => mdoc.RootElement.GetProperty("foo").GetDateTime());
        }

        [Test]
        public void CanGetDateTimeOffset()
        {
            DateTimeOffset dateTime = DateTimeOffset.Now;
            string dateTimeString = FormatDateTimeOffset(dateTime);
            string json = $"{{\"foo\" : \"{dateTimeString}\"}}";

            // Get from parsed JSON
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            Assert.IsTrue(mdoc.RootElement.GetProperty("foo").TryGetDateTimeOffset(out DateTimeOffset d));
            Assert.AreEqual(dateTime, d);
            Assert.AreEqual(dateTime, mdoc.RootElement.GetProperty("foo").GetDateTimeOffset());

            // Get from assigned existing value
            DateTimeOffset fooValue = DateTimeOffset.Now.AddDays(1);
            mdoc.RootElement.GetProperty("foo").Set(fooValue);

            Assert.IsTrue(mdoc.RootElement.GetProperty("foo").TryGetDateTimeOffset(out d));
            Assert.AreEqual(fooValue, d);
            Assert.AreEqual(fooValue, mdoc.RootElement.GetProperty("foo").GetDateTimeOffset());

            // Get from newly added value
            DateTimeOffset barValue = DateTimeOffset.Now.AddDays(2);
            mdoc.RootElement.SetProperty("bar", barValue);

            Assert.IsTrue(mdoc.RootElement.GetProperty("bar").TryGetDateTimeOffset(out d));
            Assert.AreEqual(barValue, d);
            Assert.AreEqual(barValue, mdoc.RootElement.GetProperty("bar").GetDateTimeOffset());

            // Can get them as a strings, too
            Assert.AreEqual(JsonValueKind.String, mdoc.RootElement.GetProperty("foo").ValueKind);
            Assert.AreEqual(FormatDateTimeOffset(fooValue), mdoc.RootElement.GetProperty("foo").GetString());
            Assert.AreEqual(JsonValueKind.String, mdoc.RootElement.GetProperty("bar").ValueKind);
            Assert.AreEqual(FormatDateTimeOffset(barValue), mdoc.RootElement.GetProperty("bar").GetString());

            // Doesn't work for non-string change
            mdoc.RootElement.GetProperty("foo").Set(true);
            Assert.Throws<InvalidOperationException>(() => mdoc.RootElement.GetProperty("foo").TryGetDateTimeOffset(out d));
            Assert.Throws<InvalidOperationException>(() => mdoc.RootElement.GetProperty("foo").GetDateTimeOffset());
        }

        [Test]
        public void StaticMethodsAreSameAsExpected()
        {
            var expectedMethods = new List<string> { "GetString", "GetFormatExceptionText", "SerializeToJsonElement", "ParseFromBytes", "GetReaderForElement", "GetFirstSegment", "GetLastSegment", "CopyTo" };
            var actualMethods = Type.GetType("Azure.Core.Json.MutableJsonElement, Azure.Core").GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            var message = $"There are {expectedMethods.Count} static methods expected in MutableJsonElement. If adding a new static method, ensure it is compatible with trimming or is annotated correctly.";

            foreach (var method in actualMethods)
            {
                var isExpected = expectedMethods.Contains(method.Name);
                Assert.IsTrue(isExpected, message);
            }
        }

        [Test]
        public void NestedTypesAreSameAsExpected()
        {
            var expectedNestedTypes = new List<string> { "MutableJsonElementConverter", "ArrayEnumerator", "ObjectEnumerator" };
            var actualNestedTypes = Type.GetType("Azure.Core.Json.MutableJsonElement, Azure.Core").GetNestedTypes(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            var message = $"There are {expectedNestedTypes.Count} nested types expected in MutableJsonElement. If adding a new nested type, ensure it is compatible with trimming or is annotated correctly.";

            foreach (var nestedType in actualNestedTypes)
            {
                var isExpected = expectedNestedTypes.Contains(nestedType.Name);
                Assert.IsTrue(isExpected, message);
            }
        }

        #region Helpers

        internal static void ValidateToString(string json, MutableJsonElement element)
        {
            Assert.AreEqual(
                MutableJsonDocumentTests.RemoveWhiteSpace(json),
                MutableJsonDocumentTests.RemoveWhiteSpace(element.ToString()));
        }

        internal static string FormatDateTime(DateTime d)
        {
            return MutableJsonElement.SerializeToJsonElement(d).GetString();
        }

        internal static string FormatDateTimeOffset(DateTimeOffset d)
        {
            return MutableJsonElement.SerializeToJsonElement(d).GetString();
        }

        public static IEnumerable<object[]> NumberValues()
        {
            // Valid ranges:
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
            yield return new object[] { "42", (byte)42, (byte)43, (byte)44, 256,
                (MutableJsonElement e) => (e.TryGetByte(out byte b), b),
                (MutableJsonElement e) => e.GetByte(),
                (MutableJsonDocument mdoc, string name, byte value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, byte value) => mdoc.RootElement.SetProperty(name, value) };
            yield return new object[] { "42", (sbyte)42, (sbyte)43, (sbyte)44, 128,
                (MutableJsonElement e) => (e.TryGetSByte(out sbyte b), b),
                (MutableJsonElement e) => e.GetSByte(),
                (MutableJsonDocument mdoc, string name, sbyte value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, sbyte value) => mdoc.RootElement.SetProperty(name, value) };
            yield return new object[] { "42", (short)42, (short)43, (short)44, 32768,
                (MutableJsonElement e) => (e.TryGetInt16(out short i), i),
                (MutableJsonElement e) => e.GetInt16(),
                (MutableJsonDocument mdoc, string name, short value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, short value) => mdoc.RootElement.SetProperty(name, value) };
            yield return new object[] { "42", (ushort)42, (ushort)43, (ushort)44, 65536,
                (MutableJsonElement e) => (e.TryGetUInt16(out ushort i), i),
                (MutableJsonElement e) => e.GetUInt16(),
                (MutableJsonDocument mdoc, string name, ushort value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, ushort value) => mdoc.RootElement.SetProperty(name, value) };
            yield return new object[] { "42", 42, 43, 44, 2147483648,
                (MutableJsonElement e) => (e.TryGetInt32(out int i), i),
                (MutableJsonElement e) => e.GetInt32(),
                (MutableJsonDocument mdoc, string name, int value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, int value) => mdoc.RootElement.SetProperty(name, value) };
            yield return new object[] { "42", 42u, 43u, 44u, 4294967296,
                (MutableJsonElement e) => (e.TryGetUInt32(out uint i), i),
                (MutableJsonElement e) => e.GetUInt32(),
                (MutableJsonDocument mdoc, string name, uint value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, uint value) => mdoc.RootElement.SetProperty(name, value) };
            yield return new object[] { "42", 42L, 43L, 44L, 9223372036854775808,
                (MutableJsonElement e) => (e.TryGetInt64(out long i), i),
                (MutableJsonElement e) => e.GetInt64(),
                (MutableJsonDocument mdoc, string name, long value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, long value) => mdoc.RootElement.SetProperty(name, value) };
            yield return new object[] { "42", 42ul, 43ul, 44ul, -1,
                (MutableJsonElement e) => (e.TryGetUInt64(out ulong i), i),
                (MutableJsonElement e) => e.GetUInt64(),
                (MutableJsonDocument mdoc, string name, ulong value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, ulong value) => mdoc.RootElement.SetProperty(name, value) };
            yield return new object[] { "42.1", 42.1f, 43.1f, 44.1f, false, /*don't do range check*/
                (MutableJsonElement e) => (e.TryGetSingle(out float d), d),
                (MutableJsonElement e) => e.GetSingle(),
                (MutableJsonDocument mdoc, string name, float value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, float value) => mdoc.RootElement.SetProperty(name, value) };
            yield return new object[] { "42.1", 42.1d, 43.1d, 44.1d, false,  /*don't do range check*/
                (MutableJsonElement e) => (e.TryGetDouble(out double d), d),
                (MutableJsonElement e) => e.GetDouble(),
                (MutableJsonDocument mdoc, string name, double value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, double value) => mdoc.RootElement.SetProperty(name, value) };
            yield return new object[] { "42.1", 42.1m, 43.1m, 44.1m, false,  /*don't do range check*/
                (MutableJsonElement e) => (e.TryGetDecimal(out decimal d), d),
                (MutableJsonElement e) => e.GetDecimal(),
                (MutableJsonDocument mdoc, string name, decimal value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, decimal value) => mdoc.RootElement.SetProperty(name, value)  };
        }

        #endregion
    }
}
