// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RequestContentHelperTests
    {
        public static IEnumerable<TestCaseData> GetTimeSpanData()
        {
            yield return new TestCaseData(XmlConvert.ToTimeSpan("P123DT22H14M12.011S"), XmlConvert.ToTimeSpan("P163DT22H14M12.011S"));
        }

        public static IEnumerable<TestCaseData> GetDateTimeData()
        {
            yield return new TestCaseData(DateTimeOffset.Parse("2022-08-26T18:38:00Z"), DateTimeOffset.Parse("2022-09-26T18:38:00Z"));
        }

        public static IEnumerable<TestCaseData> GetOneDateTimeData()
        {
            yield return new TestCaseData(DateTimeOffset.Parse("2022-08-26T18:38:00Z"));
        }

        public static object[] BinaryDataCases =
        {
            new object[] { BinaryData.FromString("\"test\"") },
            new object[] { new BinaryData(1)},
            new object[] { new BinaryData(1.1)},
            new object[] { new BinaryData(true)},
            new object[] { BinaryData.FromObjectAsJson(new {name="a", age=1})},
            new object[] { new BinaryData(DateTimeOffset.Parse("2022-08-26T18:38:00Z"))}
        };

        [TestCase(1, 2)]
        [TestCase("a", "b")]
        [TestCase(true, false)]
        [TestCaseSource("GetTimeSpanData")]
        [TestCaseSource("GetDateTimeData")]
        public void TestGenericFromEnumerable<T>(T expectedValue1, T expectedValue2)
        {
            var expectedList = new List<T> { expectedValue1, expectedValue2 };
            var content = RequestContentHelper.FromEnumerable<T>(expectedList);

            var stream = new MemoryStream();
            content.WriteTo(stream, default);
            stream.Position = 0;

            var document = JsonDocument.Parse(stream);
            int count = 0;
            foreach (var property in document.RootElement.EnumerateArray())
            {
                if (typeof(T) == typeof(int))
                {
                    Assert.AreEqual(expectedList[count++], property.GetInt32());
                }
                else if (typeof(T) == typeof(string))
                {
                    Assert.AreEqual(expectedList[count++], property.GetString());
                }
                else if (typeof(T) == typeof(bool))
                {
                    Assert.AreEqual(expectedList[count++], property.GetBoolean());
                }
            }
        }

        [Test]
        public void TestBinaryDataFromEnumerable()
        {
            var expectedList = new List<BinaryData> { new BinaryData(1), new BinaryData("\"hello\""), null };
            var content = RequestContentHelper.FromEnumerable(expectedList);

            var stream = new MemoryStream();
            content.WriteTo(stream, default);
            stream.Position = 0;

            var document = JsonDocument.Parse(stream);
            int count = 0;
            foreach (var property in document.RootElement.EnumerateArray())
            {
                if (property.ValueKind == JsonValueKind.Null)
                {
                    Assert.IsNull(expectedList[count++]);
                }
                else
                {
                    Assert.AreEqual(expectedList[count++].ToObjectFromJson(), BinaryData.FromString(property.GetRawText()).ToObjectFromJson());
                }
            }
        }

        [TestCase(1, 2)]
        [TestCase("a", "b")]
        [TestCase(true, false)]
        [TestCaseSource("GetTimeSpanData")]
        [TestCaseSource("GetDateTimeData")]
        public void TestGenericFromDictionary<T>(T expectedValue1, T expectedValue2)
        {
            var expectedDictionary = new Dictionary<string, T>()
            {
                {"k1", expectedValue1 },
                {"k2", expectedValue2 }
            };
            var content = RequestContentHelper.FromDictionary(expectedDictionary);

            var stream = new MemoryStream();
            content.WriteTo(stream, default);
            stream.Position = 0;

            var document = JsonDocument.Parse(stream);
            int count = 1;
            foreach (var property in document.RootElement.EnumerateObject())
            {
                if (typeof(T) == typeof(int))
                {
                    Assert.AreEqual(expectedDictionary["k" + count++], property.Value.GetInt32());
                }
                else if (typeof(T) == typeof(string))
                {
                    Assert.AreEqual(expectedDictionary["k" + count++], property.Value.GetString());
                }
                else if (typeof(T) == typeof(bool))
                {
                    Assert.AreEqual(expectedDictionary["k" + count++], property.Value.GetBoolean());
                }
            }
        }

        [Test]
        public void TestBinaryDataFromDictionary()
        {
            var expectedDictionary = new Dictionary<string, BinaryData>()
            {
                {"k1", new BinaryData(1) },
                {"k2", new BinaryData("\"hello\"") },
                {"k3", null }
            };

            var content = RequestContentHelper.FromDictionary(expectedDictionary);

            var stream = new MemoryStream();
            content.WriteTo(stream, default);
            stream.Position = 0;

            var document = JsonDocument.Parse(stream);
            int count = 1;
            foreach (var property in document.RootElement.EnumerateObject())
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    Assert.IsNull(expectedDictionary["k" + count++]);
                }
                else
                {
                    Assert.AreEqual(expectedDictionary["k" + count++].ToObjectFromJson(), BinaryData.FromString(property.Value.GetRawText()).ToObjectFromJson());
                }
            }
        }

        [TestCase("a")]
        [TestCase(true)]
        [TestCase(1)]
        [TestCase(1.0)]
        [TestCaseSource("GetOneDateTimeData")]
        public void TestFromObject<T>(T value)
        {
            var content = RequestContentHelper.FromObject(value);
            var stream = new MemoryStream();
            content.WriteTo(stream, default);
            stream.Position = 0;
            var document = JsonDocument.Parse(stream);
            switch (value)
            {
                case string:
                    Assert.AreEqual(JsonValueKind.String, document.RootElement.ValueKind);
                    Assert.AreEqual($"\"{value}\"", document.RootElement.GetRawText());
                    break;
                case bool:
                    Assert.AreEqual(value, document.RootElement.GetBoolean());
                    break;
                case int:
                    Assert.AreEqual(value, document.RootElement.GetInt32());
                    break;
                case double:
                    Assert.AreEqual(value, document.RootElement.GetDouble());
                    break;
                case DateTimeOffset:
                    Assert.AreEqual(JsonValueKind.String, document.RootElement.ValueKind);
                    Assert.AreEqual(value, DateTimeOffset.Parse(document.RootElement.GetString()));
                    break;
            }
        }

        [TestCaseSource(nameof(BinaryDataCases))]
        public void TestFromObjectForBinaryData(BinaryData value)
        {
            var content = RequestContentHelper.FromObject(value);
            var stream = new MemoryStream();
            content.WriteTo(stream, default);
            stream.Position = 0;
            var document = JsonDocument.Parse(stream);
            Assert.AreEqual(value.ToObjectFromJson(), BinaryData.FromString(document.RootElement.GetRawText()).ToObjectFromJson());
        }
    }
}
