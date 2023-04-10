// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Azure.Core.Json;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    internal class MutableJsonDocumentWriteToTests
    {
        // TODO: Add tests for both with and without changes.

        [Test]
        public void CanWriteBoolean()
        {
            string jsonTrue = "true";
            string jsonFalse = "false";

            MutableJsonDocument jdTrue = MutableJsonDocument.Parse(jsonTrue);
            MutableJsonDocument jdFalse = MutableJsonDocument.Parse(jsonFalse);

            WriteToAndParse(jdTrue, out string jsonTrueString);
            WriteToAndParse(jdFalse, out string jsonFalseString);

            Assert.AreEqual(RemoveWhiteSpace(jsonTrue), RemoveWhiteSpace(jsonTrueString));
            Assert.AreEqual(RemoveWhiteSpace(jsonFalse), RemoveWhiteSpace(jsonFalseString));
        }

        [Test]
        public void CanWriteString()
        {
            string json = """ "Hi!" """;

            MutableJsonDocument jd = MutableJsonDocument.Parse(json);

            WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(RemoveWhiteSpace(json), RemoveWhiteSpace(jsonString));
        }

        [Test]
        public void CanWriteDateTime()
        {
            ReadOnlySpan<byte> json = """
                {
                    "foo": "hi",
                    "last_modified":"2023-03-23T16:34:34+00:00"
                }
                """u8;
            BinaryData data = new(json.ToArray());

            JsonDocument doc = JsonDocument.Parse(data);
            using MemoryStream m1 = new();
            using Utf8JsonWriter w1 = new(m1);
            doc.WriteTo(w1);
            w1.Flush();
            m1.Position = 0;
            BinaryData jdocData = BinaryData.FromStream(m1);

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(data);
            mdoc.RootElement.GetProperty("foo").Set("hi");

            // Write the MutableJsonDocument with changes and validate.
            using MemoryStream m3 = new();
            using Utf8JsonWriter w3 = new(m3);
            mdoc.WriteTo(w3);
            w3.Flush();
            m3.Position = 0;
            BinaryData mdocData = BinaryData.FromStream(m3);

            Assert.AreEqual(jdocData.ToString(), mdocData.ToString());
            Assert.IsTrue(jdocData.ToMemory().Span.SequenceEqual(mdocData.ToMemory().Span),
                "JsonDocument buffer does not match MutableJsonDocument buffer.");
        }

        [Test]
        public void CanWriteQuote()
        {
            string json = """
                {
                    "foo": "hi",
                    "value":"aa\"b+b"
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            // Make a change to force it to go through our custom WriteTo() op.
            mdoc.RootElement.GetProperty("foo").Set("hi");

            // Our goal is that MutableJsonDocument.WriteTo() will have the same behavior
            // as JsonDocument.WriteTo(). Confirm that below.

            JsonDocument doc = JsonDocument.Parse(json);
            using MemoryStream m1 = new();
            using Utf8JsonWriter w1 = new(m1);
            doc.WriteTo(w1);
            w1.Flush();
            m1.Position = 0;

            using MemoryStream m2 = new();
            using Utf8JsonWriter w2 = new(m2);
            mdoc.WriteTo(w2);
            w2.Flush();
            m2.Position = 0;

            string docAsString = BinaryData.FromStream(m1).ToString();
            string mdocAsString = BinaryData.FromStream(m2).ToString();

            Assert.AreEqual(docAsString, mdocAsString);
        }

        [Test]
        public void CanWriteBooleanObjectProperty()
        {
            string json = """
                {
                  "Foo" :  true,
                  "Bar" :  false
                }
                """;

            MutableJsonDocument jd = MutableJsonDocument.Parse(json);

            WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(RemoveWhiteSpace(json), RemoveWhiteSpace(jsonString));
        }

        [Test]
        public void CanWriteBooleanObjectPropertyWithChangesToOtherBranches()
        {
            string json = """
                {
                  "Foo" : true,
                  "Bar" : 1
                }
                """;

            MutableJsonDocument jd = MutableJsonDocument.Parse(json);

            jd.RootElement.GetProperty("Bar").Set(2);

            WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(RemoveWhiteSpace("""
                {
                  "Foo" : true,
                  "Bar" : 2
                }
                """),
                RemoveWhiteSpace(jsonString));
        }

        [Test]
        public void CanWriteBooleanObjectPropertyWithChangesToBool()
        {
            string json = """
                {
                  "Foo" :  true
                }
                """;

            MutableJsonDocument jd = MutableJsonDocument.Parse(json);

            jd.RootElement.GetProperty("Foo").Set(false);

            WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(RemoveWhiteSpace("""
                {
                  "Foo" :  false
                }
            """),
                RemoveWhiteSpace(jsonString));
        }

        [Test]
        public void CanWriteObject()
        {
            string json = """
                {
                  "StringProperty" :  "Hi!",
                  "IntProperty" :  16,
                  "DoubleProperty" :  16.56,
                  "ObjectProperty" : {
                      "StringProperty" :  "Nested",
                      "IntProperty" :  22,
                      "DoubleProperty" :  22.22
                  },
                  "ArrayProperty" : [
                      {
                          "StringProperty" :  "First",
                          "IntProperty" :  1,
                          "DoubleProperty" :  1.1
                      },
                      {
                          "StringProperty" :  "Second",
                          "IntProperty" :  2,
                          "DoubleProperty" :  2.2
                      },
                      {
                          "StringProperty" :  "Third",
                          "IntProperty" :  3,
                          "DoubleProperty" :  3.3
                      }
                  ]
                }
                """;

            MutableJsonDocument jd = MutableJsonDocument.Parse(json);

            WriteToAndParse(jd, out string jsonString);

            TestClass testClass = JsonSerializer.Deserialize<TestClass>(jsonString);
            Assert.AreEqual(jd.RootElement.GetProperty("StringProperty").GetString(), testClass.StringProperty);
            Assert.AreEqual(jd.RootElement.GetProperty("IntProperty").GetInt32(), testClass.IntProperty);
            Assert.AreEqual(jd.RootElement.GetProperty("DoubleProperty").GetDouble(), testClass.DoubleProperty);
            Assert.AreEqual(jd.RootElement.GetProperty("ObjectProperty").GetProperty("StringProperty").GetString(), testClass.ObjectProperty.StringProperty);
            Assert.AreEqual(jd.RootElement.GetProperty("ObjectProperty").GetProperty("IntProperty").GetInt32(), testClass.ObjectProperty.IntProperty);
            Assert.AreEqual(jd.RootElement.GetProperty("ObjectProperty").GetProperty("DoubleProperty").GetDouble(), testClass.ObjectProperty.DoubleProperty);

            Assert.AreEqual(RemoveWhiteSpace(json), RemoveWhiteSpace(jsonString));
        }

        [Test]
        public void CanWriteInt()
        {
            string json = "16";

            MutableJsonDocument jd = MutableJsonDocument.Parse(json);

            WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(RemoveWhiteSpace(json), RemoveWhiteSpace(jsonString));
        }

        [Test]
        public void CanWriteDouble()
        {
            string json = "16.56";

            MutableJsonDocument jd = MutableJsonDocument.Parse(json);

            WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(RemoveWhiteSpace(json), RemoveWhiteSpace(jsonString));
        }

        [Test]
        public void CanWriteNumberArray()
        {
            string json = "[ 1, 2.2, 3, -4]";

            MutableJsonDocument jd = MutableJsonDocument.Parse(json);

            WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(RemoveWhiteSpace(json), RemoveWhiteSpace(jsonString));
        }

        [Test]
        public void CanWriteStringArray()
        {
            string json = """[ "one", "two", "three"]""";

            MutableJsonDocument jd = MutableJsonDocument.Parse(json);

            WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(RemoveWhiteSpace(json), RemoveWhiteSpace(jsonString));
        }

        [TestCaseSource(nameof(TestCases))]
        public void WriteToBehaviorMatchesJsonDocument(dynamic json)
        {
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            JsonDocument doc = JsonDocument.Parse(json);
            using MemoryStream m1 = new();
            using Utf8JsonWriter w1 = new(m1);
            doc.WriteTo(w1);
            w1.Flush();
            m1.Position = 0;
            BinaryData jdocData = BinaryData.FromStream(m1);

            // Write the MutableJsonDocument using Stream overload and validate.
            using Stream s1 = new MemoryStream();
            mdoc.WriteTo(s1);
            s1.Flush();
            s1.Position = 0;
            BinaryData mdocData = BinaryData.FromStream(s1);

            Assert.AreEqual(jdocData.ToString(), mdocData.ToString());
            Assert.IsTrue(jdocData.ToMemory().Span.SequenceEqual(mdocData.ToMemory().Span),
                "JsonDocument buffer does not match MutableJsonDocument buffer.");

            // Write the MutableJsonDocument without changes and validate.
            using MemoryStream m2 = new();
            using Utf8JsonWriter w2 = new(m2);
            mdoc.WriteTo(w2);
            w2.Flush();
            m2.Position = 0;
            mdocData = BinaryData.FromStream(m2);

            Assert.AreEqual(jdocData.ToString(), mdocData.ToString());
            Assert.IsTrue(jdocData.ToMemory().Span.SequenceEqual(mdocData.ToMemory().Span),
                "JsonDocument buffer does not match MutableJsonDocument buffer.");

            // Make a change to force it to go through our custom WriteTo() op.
            string name = mdoc.RootElement.EnumerateObject().First().Name;
            var value = mdoc.RootElement.EnumerateObject().First().Value;
            mdoc.RootElement.GetProperty(name).Set(value);

            // Our goal is that MutableJsonDocument.WriteTo() will have the same behavior
            // as JsonDocument.WriteTo(). Confirm that below.

            // Write the MutableJsonDocument with changes and validate.
            using MemoryStream m3 = new();
            using Utf8JsonWriter w3 = new(m3);
            mdoc.WriteTo(w3);
            w3.Flush();
            m3.Position = 0;
            mdocData = BinaryData.FromStream(m3);

            Assert.AreEqual(jdocData.ToString(), mdocData.ToString());
            Assert.IsTrue(jdocData.ToMemory().Span.SequenceEqual(mdocData.ToMemory().Span),
                "JsonDocument buffer does not match MutableJsonDocument buffer.");
        }

        public static IEnumerable<dynamic> TestCases()
        {
            yield return """
                {
                    "foo": "hi",
                    "bar": "aabb"
                }
                """;

            yield return """
                {
                    "foo": "hi",
                    "bar": 2
                }
                """;

            yield return """
                {
                    "foo": "hi",
                    "bar": "a+b" 
                }
                """;

            yield return """
                {
                    "foo": "hi",
                    "bar": "a\"b" 
                }
                """;

            yield return """
                {
                    "foo": "hi",
                    "bar": true
                }
                """;

            yield return """
                {
                    "foo": "hi",
                    "bar": 2.5
                }
                """;

            yield return """
                {
                    "foo": "hi",
                    "bar": [ true, null, 6, 1.2, "hello" ]
                }
                """;

            yield return """
                {
                    "foo": "hi",
                    "bar": {
                        "one" : 1,
                        "two" : "2"
                    }
                }
                """;

            yield return """
                {
                    "foo": "hi",
                    "bar\"+": "~!@#$%^&*()_+\\\"'"
                }
                """;

            ReadOnlySpan<byte> json = """
                {
                    "foo": "hi",
                    "last_modified":"2023-03-23T16:34:34+00:00"
                }
                """u8;
            yield return new BinaryData(json.ToArray());
        }

        #region Helpers
        private class TestClass
        {
            public string StringProperty { get; set; }
            public int IntProperty { get; set; }
            public double DoubleProperty { get; set; }
            public TestClass ObjectProperty { get; set; }
            public TestClass[] ArrayProperty { get; set; }
        }

        internal static string RemoveWhiteSpace(string value)
        {
            return value.Replace(" ", "").Replace("\r", "").Replace("\n", "");
        }

        internal static JsonDocument WriteToAndParse(MutableJsonDocument data, out string json)
        {
            using MemoryStream stream = new();
            data.WriteTo(stream);
            stream.Position = 0;
            json = BinaryData.FromStream(stream).ToString();
            return JsonDocument.Parse(json);
        }

        #endregion
    }
}
