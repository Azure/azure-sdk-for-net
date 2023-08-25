// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Azure.Core.Json;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    internal class MutableJsonDocumentWriteToTests
    {
        [Test]
        public void CanWriteBoolean()
        {
            string jsonTrue = "true";
            string jsonFalse = "false";

            MutableJsonDocument jdTrue = MutableJsonDocument.Parse(jsonTrue);
            MutableJsonDocument jdFalse = MutableJsonDocument.Parse(jsonFalse);

            MutableJsonDocumentTests.ValidateWriteTo(jsonTrue, jdTrue);
            MutableJsonDocumentTests.ValidateWriteTo(jsonFalse, jdFalse);
        }

        [Test]
        public void CanWriteString()
        {
            string json = """ "Hi!" """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            MutableJsonDocumentTests.ValidateWriteTo(json, mdoc);
        }

        [Test]
        public void CanWriteDateTimeAppConfigValue()
        {
            ReadOnlySpan<byte> json = """
                {
                    "foo": "hi",
                    "last_modified":"2023-03-23T16:34:34+00:00"
                }
                """u8;
            BinaryData data = new(json.ToArray());

            using MutableJsonDocument mdoc = MutableJsonDocument.Parse(data);
            mdoc.RootElement.GetProperty("foo").Set("hi");

            MutableJsonDocumentTests.ValidateWriteTo(data, mdoc);

            ReadOnlySpan<byte> json2 = """
                {
                    "foo": "hi",
                    "last_modified":"2023-03-23T16:35:35+00:00"
                }
                """u8;
            BinaryData data2 = new(json2.ToArray());
            mdoc.RootElement.GetProperty("last_modified").Set("2023-03-23T16:35:35+00:00");

            MutableJsonDocumentTests.ValidateWriteTo(data2, mdoc);
            MutableJsonDocumentTests.ValidateWriteTo(data2.ToString(), mdoc);
        }

        [Test]
        public void CanWriteQuote()
        {
            string json = """
                {
                    "foo": "hi",
                    "value":"aa\"bb"
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            // Make a change to force it to go through our custom WriteTo() op.
            mdoc.RootElement.GetProperty("foo").Set("hi");

            MutableJsonDocumentTests.ValidateWriteTo(json, mdoc);
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

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            MutableJsonDocumentTests.ValidateWriteTo(json, mdoc);
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

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("Bar").Set(2);

            string expected = """
                {
                  "Foo" : true,
                  "Bar" : 2
                }
                """;

            MutableJsonDocumentTests.ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanWriteBooleanObjectPropertyWithChangesToBool()
        {
            string json = """
                {
                  "Foo" :  true
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("Foo").Set(false);

            string expected = """
                {
                  "Foo" :  false
                }
            """;

            MutableJsonDocumentTests.ValidateWriteTo(expected, mdoc);
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

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            BinaryData buffer = MutableJsonDocumentTests.GetWriteToBuffer(mdoc);

            TestClass testClass = JsonSerializer.Deserialize<TestClass>(buffer);
            Assert.AreEqual(mdoc.RootElement.GetProperty("StringProperty").GetString(), testClass.StringProperty);
            Assert.AreEqual(mdoc.RootElement.GetProperty("IntProperty").GetInt32(), testClass.IntProperty);
            Assert.AreEqual(mdoc.RootElement.GetProperty("DoubleProperty").GetDouble(), testClass.DoubleProperty);
            Assert.AreEqual(mdoc.RootElement.GetProperty("ObjectProperty").GetProperty("StringProperty").GetString(), testClass.ObjectProperty.StringProperty);
            Assert.AreEqual(mdoc.RootElement.GetProperty("ObjectProperty").GetProperty("IntProperty").GetInt32(), testClass.ObjectProperty.IntProperty);
            Assert.AreEqual(mdoc.RootElement.GetProperty("ObjectProperty").GetProperty("DoubleProperty").GetDouble(), testClass.ObjectProperty.DoubleProperty);

            MutableJsonDocumentTests.ValidateWriteTo(json, mdoc);
        }

        [Test]
        public void CanWriteInt()
        {
            string json = "16";

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            MutableJsonDocumentTests.ValidateWriteTo(json, mdoc);
        }

        [Test]
        public void CanWriteDouble()
        {
            string json = "16.56";

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            MutableJsonDocumentTests.ValidateWriteTo(json, mdoc);
        }

        [Test]
        public void CanWriteNumberArray()
        {
            string json = "[ 1, 2.2, 3, -4]";

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            MutableJsonDocumentTests.ValidateWriteTo(json, mdoc);
        }

        [Test]
        public void CanWriteStringArray()
        {
            string json = """[ "one", "two", "three"]""";

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            MutableJsonDocumentTests.ValidateWriteTo(json, mdoc);
        }

        [Test]
        public void CanWriteObjectWhereTwoPrimitivePropertiesChanged()
        {
            string json = """
                {
                  "Foo" :  true,
                  "Bar" : {
                      "a" : 1.1,
                      "b" : 2
                  }
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            // Change two primitives in Bar
            mdoc.RootElement.GetProperty("Bar").GetProperty("a").Set(1.2);
            mdoc.RootElement.GetProperty("Bar").GetProperty("b").Set(3);

            string expected = """
                {
                  "Foo" :  true,
                  "Bar" : {
                      "a" : 1.2,
                      "b" : 3
                  }
                }
                """;

            MutableJsonDocumentTests.ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanWriteObjectWithPropertyAddedAtRoot()
        {
            string json = """
                {
                  "Foo" :  true
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            // Add a property to the root element
            mdoc.RootElement.SetProperty("Bar", "new");

            string expected = """
                {
                  "Foo" :  true,
                  "Bar" : "new"
                }
                """;

            MutableJsonDocumentTests.ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanWriteObjectWithAddedProperty()
        {
            string json = """
                {
                  "Foo" :  true,
                  "Bar" : {
                      "a" : 1.1,
                      "b" : 2
                  }
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            // Add a property to Bar
            mdoc.RootElement.GetProperty("Bar").SetProperty("c", "new");

            string expected = """
                {
                  "Foo" :  true,
                  "Bar" : {
                      "a" : 1.1,
                      "b" : 2,
                      "c" : "new"
                  }
                }
                """;

            MutableJsonDocumentTests.ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanWriteObjectWithChangesAndAdditions()
        {
            string json = """
                {
                  "Foo" :  true,
                  "Bar" : {
                      "a" : 1.1,
                      "b" : 2
                  }
                }
                """;

            using MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("Bar").SetProperty("c", "new");
            mdoc.RootElement.GetProperty("Bar").GetProperty("a").Set(1.2);

            string expected = """
                {
                  "Foo" :  true,
                  "Bar" : {
                      "a" : 1.2,
                      "b" : 2,
                      "c" : "new"
                  }
                }
                """;

            MutableJsonDocumentTests.ValidateWriteTo(expected, mdoc);

            JsonElement element = MutableJsonElement.SerializeToJsonElement(new int[] { 1, 2, 3 });
            mdoc.RootElement.SetProperty("Baz", element);

            expected = """
                {
                  "Foo" :  true,
                  "Bar" : {
                      "a" : 1.2,
                      "b" : 2,
                      "c" : "new"
                  },
                  "Baz" : [ 1, 2, 3 ]
                }
                """;

            MutableJsonDocumentTests.ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanWriteChangesInterleavedAcrossBranches()
        {
            string json = """
                {
                  "Foo" : {
                    "a" : 1,
                    "b" : 2
                  },
                  "Bar" : {
                    "a" : 1,
                    "b" : 2
                  }
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("Bar").SetProperty("c", "new");
            mdoc.RootElement.GetProperty("Bar").GetProperty("a").Set(1.2);

            mdoc.RootElement.GetProperty("Foo").GetProperty("b").Set(3);

            mdoc.RootElement.GetProperty("Bar").GetProperty("b").Set(4);

            string expected = """
                {
                  "Foo" :  {
                    "a" : 1,
                    "b" : 3
                  },
                  "Bar" : {
                      "a" : 1.2,
                      "b" : 4,
                      "c" : "new"
                  }
                }
                """;

            MutableJsonDocumentTests.ValidateWriteTo(expected, mdoc);
            JsonElement element = MutableJsonElement.SerializeToJsonElement(new
            {
                Foo = new
                {
                    a = 6
                },
                Bar = new
                {
                    b = 4,
                    c = "new"
                }
            });

            mdoc.RootElement.Set(element);

            expected = """
                {
                  "Foo" :  {
                    "a" : 6
                  },
                  "Bar" : {
                      "b" : 4,
                      "c" : "new"
                  }
                }
                """;

            MutableJsonDocumentTests.ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanWriteArrayWithChangedElements()
        {
            string json = """
                {
                  "Foo" :  true,
                  "Bar" : [ 0, 1, 2 ]
                }
                """;

            using MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("Bar").GetIndexElement(0).Set(2);
            mdoc.RootElement.GetProperty("Bar").GetIndexElement(1).Set(4);
            mdoc.RootElement.GetProperty("Bar").GetIndexElement(2).Set(6);

            string expected = """
                {
                  "Foo" :  true,
                  "Bar" : [ 2, 4, 6 ]
                }
                """;

            MutableJsonDocumentTests.ValidateWriteTo(expected, mdoc);

            JsonElement element = MutableJsonElement.SerializeToJsonElement(new int[] { 0, 1, 2, 3 });
            mdoc.RootElement.GetProperty("Bar").Set(element);
            mdoc.RootElement.GetProperty("Bar").GetIndexElement(3).Set(4);

            expected = """
                {
                  "Foo" :  true,
                  "Bar" : [ 0, 1, 2, 4 ]
                }
                """;

            MutableJsonDocumentTests.ValidateWriteTo(expected, mdoc);
        }

        [Test]
        public void CanWriteToStream()
        {
            string json = """{ "foo" : 1 }""";
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream);
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            Assert.AreEqual(json, actual);
        }

        [Test]
        public void CanWriteToStreamWithJsonFormat()
        {
            string json = """{ "foo" : 1 }""";
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "J");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            Assert.AreEqual(json, actual);
        }

        [Test]
        public void CanWriteToStreamWithPatchFormat()
        {
            string json = """{"foo":1}""";
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("foo").Set(2);

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            Assert.AreEqual("""{"foo":2}""", actual);
        }

        [Test]
        public void CannotWriteToStreamWithUnknownFormat()
        {
            string json = """{ "foo" : 1 }""";
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            Stream stream = new MemoryStream();
            Assert.Throws<FormatException>(() => mdoc.WriteTo(stream, "U"));
        }

        [TestCaseSource(nameof(TestCases))]
        public void WriteToBehaviorMatchesJsonDocument(dynamic json)
        {
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            // Validate before changes to MutableJsonDocument
            MutableJsonDocumentTests.ValidateWriteTo(json, mdoc);

            // Mutate a value
            string name = mdoc.RootElement.EnumerateObject().First().Name;
            MutableJsonElement value = mdoc.RootElement.EnumerateObject().First().Value;
            JsonElement element = MutableJsonElement.SerializeToJsonElement(value);
            mdoc.RootElement.GetProperty(name).Set(element);

            // Validate after changes.
            MutableJsonDocumentTests.ValidateWriteTo(json, mdoc);
        }

        [Test]
        public void CanWriteByte()
        {
            string json = """
                {
                  "foo" : 42
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            // Get from parsed JSON
            Assert.AreEqual($"{42}", mdoc.RootElement.GetProperty("foo").ToString());

            // Get from assigned existing value
            byte newValue = 43;
            mdoc.RootElement.GetProperty("foo").Set(newValue);
            Assert.AreEqual($"{newValue}", mdoc.RootElement.GetProperty("foo").ToString());

            // Get from added value
            mdoc.RootElement.SetProperty("bar", (byte)44);
            Assert.AreEqual($"{44}", mdoc.RootElement.GetProperty("bar").ToString());
        }

        [TestCaseSource(nameof(NumberValues))]
        public void CanWriteNumber<T>(string serializedX, T x, T y, T z,
            Action<MutableJsonDocument, string, T> set,
            Func<MutableJsonDocument, string, T, MutableJsonElement> setProperty)
        {
            string json = $"{{\"foo\" : {serializedX}}}";

            // Get from parsed JSON
            using MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            // Get from parsed JSON
            Assert.AreEqual($"{x}", mdoc.RootElement.GetProperty("foo").ToString());
            MutableJsonDocumentTests.ValidateWriteTo(json, mdoc);

            // Get from assigned existing value
            set(mdoc, "foo", y);
            Assert.AreEqual($"{y}", mdoc.RootElement.GetProperty("foo").ToString());
            MutableJsonDocumentTests.ValidateWriteTo($"{{\"foo\" : {y}}}", mdoc);

            // Get from added value
            setProperty(mdoc, "bar", z);
            Assert.AreEqual($"{z}", mdoc.RootElement.GetProperty("bar").ToString());
            MutableJsonDocumentTests.ValidateWriteTo($"{{\"foo\":{y},\"bar\":{z}}}", mdoc);
        }

        [Test]
        public void CanWriteGuid()
        {
            Guid guid = Guid.NewGuid();
            string json = $"{{\"foo\" : \"{guid}\"}}";

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            // Get from parsed JSON
            Assert.AreEqual($"{guid}", mdoc.RootElement.GetProperty("foo").ToString());
            MutableJsonDocumentTests.ValidateWriteTo(json, mdoc);

            // Get from assigned existing value
            Guid fooValue = Guid.NewGuid();
            mdoc.RootElement.GetProperty("foo").Set(fooValue);
            Assert.AreEqual($"{fooValue}", mdoc.RootElement.GetProperty("foo").ToString());
            MutableJsonDocumentTests.ValidateWriteTo($"{{\"foo\" : \"{fooValue}\"}}", mdoc);

            // Get from added value
            Guid barValue = Guid.NewGuid();
            mdoc.RootElement.SetProperty("bar", barValue);
            Assert.AreEqual($"{barValue}", mdoc.RootElement.GetProperty("bar").ToString());
            MutableJsonDocumentTests.ValidateWriteTo($"{{\"foo\":\"{fooValue}\",\"bar\":\"{barValue}\"}}", mdoc);
        }

        [Test]
        [Ignore("Investigating possible issue in Utf8JsonWriter.")]
        public void CanWriteDateTime()
        {
            DateTime dateTime = DateTime.Parse("2023-05-07T21:04:45.1657010-07:00");
            string dateTimeString = MutableJsonElementTests.FormatDateTime(dateTime);
            string json = $"{{\"foo\" : \"{dateTimeString}\"}}";

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            // Get from parsed JSON
            Assert.AreEqual(dateTimeString, mdoc.RootElement.GetProperty("foo").ToString());
            MutableJsonDocumentTests.ValidateWriteTo(json, mdoc);

            // Get from assigned existing value
            DateTime fooValue = dateTime.AddDays(1);
            string fooString = MutableJsonElementTests.FormatDateTime(fooValue);
            mdoc.RootElement.GetProperty("foo").Set(fooValue);
            Assert.AreEqual(fooString, mdoc.RootElement.GetProperty("foo").ToString());
            MutableJsonDocumentTests.ValidateWriteTo($"{{\"foo\" : \"{fooString}\"}}", mdoc);

            // Get from added value
            DateTime barValue = dateTime.AddDays(2);
            string barString = MutableJsonElementTests.FormatDateTime(barValue);
            mdoc.RootElement.SetProperty("bar", barValue);
            Assert.AreEqual(barString, mdoc.RootElement.GetProperty("bar").ToString());
            MutableJsonDocumentTests.ValidateWriteTo($"{{\"foo\":\"{fooString}\",\"bar\":\"{barString}\"}}", mdoc);
        }

        [Test]
        [Ignore("Investigating possible issue in Utf8JsonWriter.")]
        public void CanWriteDateTimeOffset()
        {
            DateTimeOffset dateTime = DateTimeOffset.Parse("2023-08-17T10:36:42.5482841+07:00");
            string dateTimeString = MutableJsonElementTests.FormatDateTimeOffset(dateTime);
            string json = $"{{\"foo\" : \"{dateTimeString}\"}}";

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            // Get from parsed JSON
            Assert.AreEqual(dateTimeString, mdoc.RootElement.GetProperty("foo").ToString());
            MutableJsonDocumentTests.ValidateWriteTo(json, mdoc);

            // Get from assigned existing value
            DateTimeOffset fooValue = dateTime.AddDays(1);
            string fooString = MutableJsonElementTests.FormatDateTimeOffset(fooValue);
            mdoc.RootElement.GetProperty("foo").Set(fooValue);
            Assert.AreEqual(fooString, mdoc.RootElement.GetProperty("foo").ToString());
            MutableJsonDocumentTests.ValidateWriteTo($"{{\"foo\" : \"{fooString}\"}}", mdoc);

            // Get from added value
            DateTimeOffset barValue = dateTime.AddDays(2);
            string barString = MutableJsonElementTests.FormatDateTimeOffset(barValue);
            mdoc.RootElement.SetProperty("bar", barValue);
            Assert.AreEqual(barString, mdoc.RootElement.GetProperty("bar").ToString());
            MutableJsonDocumentTests.ValidateWriteTo($"{{\"foo\":\"{fooString}\",\"bar\":\"{barString}\"}}", mdoc);
        }

        #region JSON Merge Patch

        [Test]
        public void CanWritePatchChangeRoot()
        {
            string json = """{"foo": 1}""";
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("foo").Set(2);

            ValidatePatch("""{"foo": 2}""", mdoc);
        }

        [Test]
        public void CanWritePatchChangeRootOnePropertyChangesAnotherDoesnt()
        {
            string json = """{"foo": 1, "bar": "a"}""";
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("foo").Set(2);

            ValidatePatch("""{"foo": 2}""", mdoc);
        }

        [Test]
        public void CanWritePatchChangeRootChangeMultipleProperties()
        {
            string json = """{"foo": 1, "bar": "a"}""";
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("foo").Set(2);
            mdoc.RootElement.GetProperty("bar").Set("b");

            // TODO: does order matter?  This fails:
            //AreEqualJson("""{"foo": 2, "bar": "b"}""", actual);

            ValidatePatch("""{"bar": "b", "foo": 2}""", mdoc);
        }

        [Test]
        public void CanWritePatchChangeRootMultipleChangesSameProperty()
        {
            string json = """{"foo": 1, "bar": "a"}""";
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("foo").Set(2);
            mdoc.RootElement.GetProperty("foo").Set(3);

            ValidatePatch("""{"foo": 3}""", mdoc);
        }

        [Test]
        public void CanWritePatchForChangeToNonRootElement()
        {
            string json = """
                {
                    "parent": {
                        "child": true
                    }
                }
                """;
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("parent").GetProperty("child").Set(false);

            ValidatePatch("""{"parent": {"child": false}}""", mdoc);
        }

        [Test]
        public void CanWritePatch_ThreeLevels()
        {
            string json = """
                {
                    "a": {
                        "b": {
                            "c": 1
                        }
                    }
                }
                """;
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("a").GetProperty("b").GetProperty("c").Set(2);

            ValidatePatch("""{"a": {"b": {"c": 2}}}""", mdoc);
        }

        [Test]
        public void CanWritePatch_ThreeLevelPeers()
        {
            string json = """
                {
                    "a": {
                        "b": {
                            "c": 1
                        }
                    },
                    "d": {
                        "e": {
                            "f": 1
                        }
                    }
                }
                """;
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("a").GetProperty("b").GetProperty("c").Set(2);
            mdoc.RootElement.GetProperty("d").GetProperty("e").GetProperty("f").Set(3);

            ValidatePatch("""{"a": {"b": {"c": 2}}, "d": {"e": {"f": 3}}}""", mdoc);
        }

        [Test]
        public void CanWritePatch_ThreeLevelsNested()
        {
            string json = """
                {
                    "a": {
                        "b": {
                            "c": 1
                        },
                        "bb": {
                            "cc": 1
                        }
                    },
                    "d": {
                        "e": {
                            "f": 1
                        }
                    }
                }
                """;
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("a").GetProperty("b").GetProperty("c").Set(2);
            mdoc.RootElement.GetProperty("a").GetProperty("bb").GetProperty("cc").Set(3);
            mdoc.RootElement.GetProperty("d").GetProperty("e").GetProperty("f").Set(4);

            ValidatePatch("""{"a": {"b": {"c": 2}, "bb": {"cc": 3}}, "d": {"e": {"f": 4}}}""", mdoc);
        }

        [Test]
        public void CanWritePatchInterleaveChildObjectChanges()
        {
            string json = """
                {
                    "a": {
                        "aa": 1,
                        "ab": 2
                    },
                    "b": {
                        "ba": "1",
                        "bb": "2"
                    }
                }
                """;
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("a").GetProperty("aa").Set(3);
            mdoc.RootElement.GetProperty("b").GetProperty("ba").Set("3");
            mdoc.RootElement.GetProperty("a").GetProperty("ab").Set(4);
            mdoc.RootElement.GetProperty("b").GetProperty("ba").Set("4");
            mdoc.RootElement.GetProperty("a").GetProperty("aa").Set(5);

            ValidatePatch("""
                {
                    "a": {
                        "aa": 5,
                        "ab": 4
                    },
                    "b": {
                        "ba": "4"
                    }
                }
                """, mdoc);
        }

        [Test]
        public void CanWritePatchInterleaveParentAndChildChanges()
        {
            string json = """
                {
                    "a": {
                        "aa": 1,
                        "ab": 2
                    },
                    "b": {
                        "ba": "1",
                        "bb": "2"
                    }
                }
                """;
            using MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("a").GetProperty("aa").Set(3);
            mdoc.RootElement.GetProperty("b").GetProperty("ba").Set("3");
            JsonElement element = MutableJsonElement.SerializeToJsonElement(new { ba = "3", bb = "4" });
            mdoc.RootElement.GetProperty("b").Set(element);
            mdoc.RootElement.GetProperty("a").GetProperty("ab").Set(4);
            mdoc.RootElement.GetProperty("b").GetProperty("ba").Set("5");
            mdoc.RootElement.GetProperty("a").GetProperty("aa").Set(5);

            ValidatePatch("""
                {
                    "a": {
                        "aa": 5,
                        "ab": 4
                    },
                    "b": {
                        "ba": "5",
                        "bb": "4"
                    }
                }
                """, mdoc);
        }

        [Test]
        public void CanWritePatchToArrayElement()
        {
            // For an array, if any element has changed, the entire array is replaced.

            string json = """[0, 1, 2]""";

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            mdoc.RootElement.GetIndexElement(0).Set(3);

            ValidatePatch("""[3, 1, 2]""", mdoc);
        }

        [Test]
        public void CanWritePatchToArrayObjectProperty()
        {
            // For an array, if any element has changed, the entire array is replaced.

            string json = """
            {
                "a": [0, 1]
            }
            """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            mdoc.RootElement.GetProperty("a").GetIndexElement(0).Set(2);

            ValidatePatch("""
            {
                "a": [2, 1]
            }
            """, mdoc);
        }

        [Test]
        public void CanWritePatchForNestedArray()
        {
            // For an array, if any element has changed, the entire array is replaced.

            string json = """
            {
                "a": {
                    "b": [0, 1]
                }
            }
            """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            mdoc.RootElement.GetProperty("a").GetProperty("b").GetIndexElement(1).Set(2);

            ValidatePatch("""
            {
                "a": {
                    "b": [0, 2]
                }
            }
            """, mdoc);
        }

        [Test]
        public void CanWritePatchForNestedArrayMultipleChanges()
        {
            // For an array, if any element has changed, the entire array is replaced.

            string json = """
            {
                "a": {
                    "b": [0, 1]
                }
            }
            """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            mdoc.RootElement.GetProperty("a").GetProperty("b").GetIndexElement(0).Set(2);
            mdoc.RootElement.GetProperty("a").GetProperty("b").GetIndexElement(1).Set(3);

            ValidatePatch("""
            {
                "a": {
                    "b": [2, 3]
                }
            }
            """, mdoc);
        }

        [Test]
        public void CanWritePatchForArrayOfObjects()
        {
            // For an array, if any element has changed, the entire array is replaced.

            string json = """
            {
                "a":
                [
                    { "b": 1 },
                    { "c": 2 },
                    { "d": 3 }
                ]
            }
            """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            mdoc.RootElement.GetProperty("a").GetIndexElement(0).GetProperty("b").Set(4);
            mdoc.RootElement.GetProperty("a").GetIndexElement(2).GetProperty("d").Set(5);

            ValidatePatch("""
            {
                "a":
                [
                    { "b": 4 },
                    { "c": 2 },
                    { "d": 5 }
                ]
            }
            """, mdoc);
        }

        [Test]
        public void CanWritePatchForArraysAtDifferentLevels()
        {
            // For an array, if any element has changed, the entire array is replaced.

            string json = """
            {
                "a": {
                    "aa": [0, 1]
                },
                "b": {
                    "bb":
                    {
                        "bbb": [true, false]
                    }
                },
                "c": [null, null, {"cc": "hi"}]
            }
            """;

            using MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            mdoc.RootElement.GetProperty("a").GetProperty("aa").GetIndexElement(0).Set(2);
            mdoc.RootElement.GetProperty("b").GetProperty("bb").GetProperty("bbb").GetIndexElement(1).Set(true);
            JsonElement element = MutableJsonElement.SerializeToJsonElement(new { cd = "cd" });
            mdoc.RootElement.GetProperty("c").GetIndexElement(1).Set(element);

            ValidatePatch("""
            {
                "a": {
                    "aa": [2, 1]
                },
                "b": {
                    "bb":
                    {
                        "bbb": [true, true]
                    }
                },
                "c": [null, {"cd": "cd"}, {"cc": "hi"}]
            }
            """, mdoc);
        }

        [Test]
        public void CanWritePatchInterleaveArrayChanges()
        {
            // For an array, if any element has changed, the entire array is replaced.

            string json = """
            {
                "a": {
                    "aa": [0, 1]
                },
                "b": {
                    "bb":
                    {
                        "bbb": [true, false]
                    }
                },
                "c": [null, null, {"cc": "hi"}]
            }
            """;

            using MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            mdoc.RootElement.GetProperty("a").GetProperty("aa").GetIndexElement(0).Set(2);
            mdoc.RootElement.GetProperty("b").GetProperty("bb").GetProperty("bbb").GetIndexElement(1).Set(true);
            mdoc.RootElement.GetProperty("a").GetProperty("aa").GetIndexElement(0).Set(3);
            JsonElement element = MutableJsonElement.SerializeToJsonElement(new { cd = "cd" });
            mdoc.RootElement.GetProperty("c").GetIndexElement(1).Set(element);
            mdoc.RootElement.GetProperty("a").GetProperty("aa").GetIndexElement(1).Set(4);

            ValidatePatch("""
            {
                "a": {
                    "aa": [3, 4]
                },
                "b": {
                    "bb":
                    {
                        "bbb": [true, true]
                    }
                },
                "c": [null, {"cd": "cd"}, {"cc": "hi"}]
            }
            """, mdoc);
        }

        [Test]
        public void CanWritePatchInterleaveParentAndChildArrayChanges()
        {
            // For an array, if any element has changed, the entire array is replaced.

            string json = """
            {
                "a": {
                    "aa": [0, 1]
                },
                "b": {
                    "bb":
                    {
                        "bbb": [true, false]
                    }
                },
                "c": [null, null, {"cc": "hi"}]
            }
            """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            mdoc.RootElement.GetProperty("a").GetProperty("aa").GetIndexElement(0).Set(2);
            mdoc.RootElement.GetProperty("b").GetProperty("bb").GetProperty("bbb").GetIndexElement(1).Set(true);
            JsonElement element = MutableJsonElement.SerializeToJsonElement(new int[] { 2, 3 });
            mdoc.RootElement.GetProperty("a").GetProperty("aa").Set(element);
            element = MutableJsonElement.SerializeToJsonElement(new { cd = "cd" });
            mdoc.RootElement.GetProperty("c").GetIndexElement(1).Set(element);
            mdoc.RootElement.GetProperty("a").GetProperty("aa").GetIndexElement(1).Set(4);

            ValidatePatch("""
            {
                "a": {
                    "aa": [2, 4]
                },
                "b": {
                    "bb":
                    {
                        "bbb": [true, true]
                    }
                },
                "c": [null, {"cd": "cd"}, {"cc": "hi"}]
            }
            """, mdoc);
        }

        [Test]
        public void CanWritePatchReplaceObject()
        {
            string json = """
                {
                    "a": {
                        "aa": 1,
                        "ab": 2
                    },
                    "b": {
                        "ba": "1",
                        "bb": "2"
                    }
                }
                """;
            using MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            JsonElement element = MutableJsonElement.SerializeToJsonElement(new { aa = 3, ab = 4 });
            mdoc.RootElement.GetProperty("a").Set(element);

            ValidatePatch("""
                {
                    "a": {
                        "aa": 3,
                        "ab": 4
                    }
                }
                """, mdoc);
        }

        [Test]
        public void CanWritePatchReplaceObject_Deletions()
        {
            string json = """
                {
                    "a": {
                        "aa": 1,
                        "ab": 2
                    },
                    "b": {
                        "ba": "1",
                        "bb": "2"
                    }
                }
                """;
            using MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            JsonElement element = MutableJsonElement.SerializeToJsonElement(new { ac = 3 });
            mdoc.RootElement.GetProperty("a").Set(element);

            ValidatePatch("""
                {
                    "a": {
                        "aa": null,
                        "ab": null,
                        "ac": 3
                    }
                }
                """, mdoc);
        }

        [Test]
        public void CanWritePatchAddProperty()
        {
            string json = """
                {
                    "a": {
                        "aa": 1,
                        "ab": 2
                    },
                    "b": {
                        "ba": "1",
                        "bb": "2"
                    }
                }
                """;
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.SetProperty("c", 3);

            ValidatePatch("""
                {
                    "c": 3
                }
                """, mdoc);
        }

        [Test]
        public void CanWritePatchAddNestedProperty()
        {
            string json = """
                {
                    "a": {
                        "aa": 1,
                        "ab": 2
                    },
                    "b": {
                        "ba": "1",
                        "bb": "2"
                    }
                }
                """;
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("b").SetProperty("bc", "3");

            ValidatePatch("""
                {
                    "b": {
                        "bc": "3"
                    }
                }
                """, mdoc);
        }

        [Test]
        public void CanWritePatchAddObject()
        {
            string json = """
                {
                    "a": {
                        "aa": 1,
                        "ab": 2
                    },
                    "b": {
                        "ba": "1",
                        "bb": "2"
                    }
                }
                """;
            using MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            JsonElement element = MutableJsonElement.SerializeToJsonElement(new { ca = true, cb = false });
            mdoc.RootElement.SetProperty("c", element);

            ValidatePatch("""
                {
                    "c": {
                        "ca": true,
                        "cb": false
                    }
                }
                """, mdoc);
        }

        [Test]
        public void CanWritePatchDeleteProperty_SetNull()
        {
            string json = """
                {
                    "a": {
                        "aa": 1,
                        "ab": 2
                    },
                    "b": {
                        "ba": "1",
                        "bb": "2"
                    }
                }
                """;
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("a").GetProperty("aa").Set(null);

            ValidatePatch("""
                {
                    "a": {
                        "aa": null
                    }
                }
                """, mdoc);
        }

        [Test]
        public void CanWritePatchDeleteProperty()
        {
            string json = """
                {
                    "a": {
                        "aa": 1,
                        "ab": 2
                    },
                    "b": {
                        "ba": "1",
                        "bb": "2"
                    }
                }
                """;
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("a").RemoveProperty("aa");

            ValidatePatch("""
                {
                    "a": {
                        "aa": null
                    }
                }
                """, mdoc);
        }

        [Test]
        public void CanWritePatchDeleteObject()
        {
            string json = """
                {
                    "a": {
                        "aa": 1,
                        "ab": 2
                    },
                    "b": {
                        "ba": "1",
                        "bb": "2"
                    }
                }
                """;
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.RemoveProperty("b");

            ValidatePatch("""
                {
                    "b": null
                }
                """, mdoc);
        }

        [Test]
        public void CanWritePatchDeleteObject_SetNull()
        {
            string json = """
                {
                    "a": {
                        "aa": 1,
                        "ab": 2
                    },
                    "b": {
                        "ba": "1",
                        "bb": "2"
                    }
                }
                """;
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("b").Set(null);

            ValidatePatch("""
                {
                    "b": null
                }
                """, mdoc);
        }

        [Test]
        public void CanWritePatchForNonRootElement()
        {
            string json = """
                {
                    "a": {
                        "aa": 1,
                        "ab": {
                            "abc": 2
                        }
                    },
                    "b": {
                        "ba": "1",
                        "bb": "2"
                    }
                }
                """;
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("a").GetProperty("ab").GetProperty("abc").Set(3);
            mdoc.RootElement.GetProperty("b").GetProperty("ba").Set("3");

            // Validate the root writes the full patch
            ValidatePatch("""
                {
                    "a": {
                        "ab": {
                            "abc": 3
                        }
                    },
                    "b": {
                        "ba": "3"
                    }
                }
                """, mdoc);

            // Validate element "a" writes just the patch for that subtree
            ValidatePatch("""
                {
                    "ab": {
                        "abc": 3
                    }
                }
                """, mdoc.RootElement.GetProperty("a"));

            // Validate element "b" writes just the patch for that subtree
            ValidatePatch("""
                {
                    "ba": "3"
                }
                """, mdoc.RootElement.GetProperty("b"));
        }

        [Test]
        public void CanWritePatchRfc7396FirstExample()
        {
            string json = """
                {
                  "a": "b",
                  "c": {
                    "d": "e",
                    "f": "g"
                  }
                }
                """;
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("a").Set("z");
            mdoc.RootElement.GetProperty("c").RemoveProperty("f");

            ValidatePatch("""
                {
                  "a":"z",
                  "c": {
                    "f": null
                  }
                }
                """, mdoc);
        }

        [Test]
        public void CanWritePatchRfc7396SecondExample()
        {
            string json = """
                {
                  "title": "Goodbye!",
                  "author" : {
                    "givenName" : "John",
                    "familyName" : "Doe"
                  },
                  "tags":[ "example", "sample" ],
                  "content": "This will be unchanged"
                }
                """;
            using MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("title").Set("Hello!");
            mdoc.RootElement.SetProperty("phoneNumber", "+01-123-456-7890");
            mdoc.RootElement.GetProperty("author").RemoveProperty("familyName");
            JsonElement element = MutableJsonElement.SerializeToJsonElement(new string[] { "example" });
            mdoc.RootElement.SetProperty("tags", element);

            ValidatePatch("""
                {
                  "author": {
                    "familyName": null
                  },
                  "phoneNumber": "+01-123-456-7890",
                  "tags": [ "example" ],
                  "title": "Hello!"
                }
                """, mdoc);
        }

        #endregion

        #region Helpers
        private static void ValidatePatch(string expected, MutableJsonDocument mdoc)
        {
            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
        }

        private static void ValidatePatch(string expected, MutableJsonElement mje)
        {
            using Stream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            mje.WriteTo(writer, "P");
            writer.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
        }

        private static void AreEqualJson(string expected, string actual)
        {
            JsonDocument doc = JsonDocument.Parse(expected);
            BinaryData buffer = MutableJsonDocumentTests.GetWriteToBuffer(doc);
            Assert.AreEqual(buffer.ToString(), actual);
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

            yield return """
                {
                "foo" :
                [
                    "Once upon a midnight dreary",
                    42,
                    1e400,
                    3.141592653589793238462643383279,
                    false,
                    true,
                    null,
                    "Escaping is not requ\u0069red",
                    "Some th\u0069ngs get lost in the m\u00EAl\u00E9e",
                    [ 2, 3, 5, 7, 9, 11 ],
                    [ { "obj": [ 21, {
                              "deep obj": [
                                "Once upon a midnight dreary",
                                42,
                                1e400,
                                3.141592653589793238462643383279,
                                false,
                                true,
                                null,
                                "Escaping is not required",
                                "Some things get lost in the m\u00EAl\u00E9e" ],
                              "more deep": false }, 12 ], "second property": null } ],
                    { "obj": [ 21, {
                          "deep obj": [
                            "Once upon a midnight dreary",
                            42,
                            1e400,
                            3.141592653589793238462643383279,
                            false,
                            true,
                            null,
                            "Escaping is not required",
                            "Some things get lost in the m\u00EAl\u00E9e" ],
                          "more deep": false }, 12 ], "second property": null } ]
                }
                """;
        }

        private class TestClass
        {
            public string StringProperty { get; set; }
            public int IntProperty { get; set; }
            public double DoubleProperty { get; set; }
            public TestClass ObjectProperty { get; set; }
            public TestClass[] ArrayProperty { get; set; }
        }

        public static IEnumerable<object[]> NumberValues()
        {
            // Valid ranges:
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
            yield return new object[] { "42", (byte)42, (byte)43, (byte)44,
                (MutableJsonDocument mdoc, string name, byte value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, byte value) => mdoc.RootElement.SetProperty(name, value) };
            yield return new object[] { "42", (sbyte)42, (sbyte)43, (sbyte)44,
                (MutableJsonDocument mdoc, string name, sbyte value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, sbyte value) => mdoc.RootElement.SetProperty(name, value) };
            yield return new object[] {"42", (short)42, (short)43, (short)44,
                (MutableJsonDocument mdoc, string name, short value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, short value) => mdoc.RootElement.SetProperty(name, value) };
            yield return new object[] {"42", (ushort)42, (ushort)43, (ushort)44,
                (MutableJsonDocument mdoc, string name, ushort value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, ushort value) => mdoc.RootElement.SetProperty(name, value) };
            yield return new object[] { "42", 42, 43, 44,
                (MutableJsonDocument mdoc, string name, int value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, int value) => mdoc.RootElement.SetProperty(name, value) };
            yield return new object[] { "42", 42u, 43u, 44u,
                (MutableJsonDocument mdoc, string name, uint value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, uint value) => mdoc.RootElement.SetProperty(name, value) };
            yield return new object[] { "42", 42L, 43L, 44L,
                (MutableJsonDocument mdoc, string name, long value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, long value) => mdoc.RootElement.SetProperty(name, value) };
            yield return new object[] { "42", 42ul, 43ul, 44ul,
                (MutableJsonDocument mdoc, string name, ulong value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, ulong value) => mdoc.RootElement.SetProperty(name, value) };
#if NETCOREAPP
            yield return new object[] { "42.1", 42.1f, 43.1f, 44.1f,
                (MutableJsonDocument mdoc, string name, float value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, float value) => mdoc.RootElement.SetProperty(name, value) };
            yield return new object[] { "42.1", 42.1d, 43.1d, 44.1d,
                (MutableJsonDocument mdoc, string name, double value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, double value) => mdoc.RootElement.SetProperty(name, value) };
#endif
            yield return new object[] { "42.1", 42.1m, 43.1m, 44.1m,
                (MutableJsonDocument mdoc, string name, decimal value) => mdoc.RootElement.GetProperty(name).Set(value),
                (MutableJsonDocument mdoc, string name, decimal value) => mdoc.RootElement.SetProperty(name, value) };
        }
        #endregion
    }
}
