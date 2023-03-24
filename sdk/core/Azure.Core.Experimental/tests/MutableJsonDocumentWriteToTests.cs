// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
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
        public void CanWriteDateTime_Utf8Bytes()
        {
            ReadOnlySpan<byte> json = """
                {
                    "foo": "hi",
                    "last_modified":"2023-03-23T16:34:34+00:00"
                }
                """u8;
            BinaryData data = new(json.ToArray());

            MutableJsonDocument jd = MutableJsonDocument.Parse(data);
            jd.RootElement.GetProperty("foo").Set("hi");

            WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(RemoveWhiteSpace(data.ToString()), RemoveWhiteSpace(jsonString));
        }

        [Test]
        public void CanWriteDateTime_String()
        {
            string json = """
                {
                    "foo": "hi",
                    "last_modified":"2023-03-23T16:34:34+00:00"
                }
                """;

            MutableJsonDocument jd = MutableJsonDocument.Parse(json);

            // Make a change to force it to go through our custom WriteTo() op.
            jd.RootElement.GetProperty("foo").Set("hi");

            WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(RemoveWhiteSpace(json), RemoveWhiteSpace(jsonString));
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
