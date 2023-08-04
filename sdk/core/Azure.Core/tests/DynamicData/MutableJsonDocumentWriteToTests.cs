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

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(data);
            mdoc.RootElement.GetProperty("foo").Set("hi");

            MutableJsonDocumentTests.ValidateWriteTo(data, mdoc);
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

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

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

            mdoc.RootElement.SetProperty("Baz", new int[] { 1, 2, 3 });

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

            var value = new
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
            };

            mdoc.RootElement.Set(value);

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

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

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

            mdoc.RootElement.GetProperty("Bar").Set(new int[] { 0, 1, 2, 3 });
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
            var value = mdoc.RootElement.EnumerateObject().First().Value;
            mdoc.RootElement.GetProperty(name).Set(value);

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
        public void CanWriteNumber<T>(string serializedX, T x, T y, T z)
        {
            string json = $"{{\"foo\" : {serializedX}}}";

            // Get from parsed JSON
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            // Get from parsed JSON
            Assert.AreEqual($"{x}", mdoc.RootElement.GetProperty("foo").ToString());
            MutableJsonDocumentTests.ValidateWriteTo(json, mdoc);

            // Get from assigned existing value
            mdoc.RootElement.GetProperty("foo").Set(y);
            Assert.AreEqual($"{y}", mdoc.RootElement.GetProperty("foo").ToString());
            MutableJsonDocumentTests.ValidateWriteTo($"{{\"foo\" : {y}}}", mdoc);

            // Get from added value
            mdoc.RootElement.SetProperty("bar", z);
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
        public void CanWriteDateTimeOffset()
        {
            DateTimeOffset dateTime = DateTimeOffset.Now;
            string dateTimeString = MutableJsonElementTests.FormatDateTimeOffset(dateTime);
            string json = $"{{\"foo\" : \"{dateTimeString}\"}}";

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            // Get from parsed JSON
            Assert.AreEqual(dateTimeString, mdoc.RootElement.GetProperty("foo").ToString());
            MutableJsonDocumentTests.ValidateWriteTo(json, mdoc);

            // Get from assigned existing value
            DateTimeOffset fooValue = DateTimeOffset.Now.AddDays(1);
            string fooString = MutableJsonElementTests.FormatDateTimeOffset(fooValue);
            mdoc.RootElement.GetProperty("foo").Set(fooValue);
            Assert.AreEqual(fooString, mdoc.RootElement.GetProperty("foo").ToString());
            MutableJsonDocumentTests.ValidateWriteTo($"{{\"foo\" : \"{fooString}\"}}", mdoc);

            // Get from added value
            DateTimeOffset barValue = DateTimeOffset.Now.AddDays(2);
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

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson("""{"foo": 2}""", actual);
        }

        [Test]
        public void CanWritePatchChangeRootOnePropertyChangesAnotherDoesnt()
        {
            string json = """{"foo": 1, "bar": "a"}""";
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("foo").Set(2);

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson("""{"foo": 2}""", actual);
        }

        [Test]
        public void CanWritePatchChangeRootChangeMultipleProperties()
        {
            string json = """{"foo": 1, "bar": "a"}""";
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("foo").Set(2);
            mdoc.RootElement.GetProperty("bar").Set("b");

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            // TODO: does order matter?  This fails:
            //AreEqualJson("""{"foo": 2, "bar": "b"}""", actual);

            AreEqualJson("""{"bar": "b", "foo": 2}""", actual);
        }

        [Test]
        public void CanWritePatchChangeRootMultipleChangesSameProperty()
        {
            string json = """{"foo": 1, "bar": "a"}""";
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("foo").Set(2);
            mdoc.RootElement.GetProperty("foo").Set(3);

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson("""{"foo": 3}""", actual);
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

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson("""{"parent": {"child": false}}""", actual);
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

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson("""{"a": {"b": {"c": 2}}}""", actual);
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

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson("""{"a": {"b": {"c": 2}}, "d": {"e": {"f": 3}}}""", actual);
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

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson("""{"a": {"b": {"c": 2}, "bb": {"cc": 3}}, "d": {"e": {"f": 4}}}""", actual);
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

            string expected = """
                {
                    "a": {
                        "aa": 5,
                        "ab": 4
                    },
                    "b": {
                        "ba": "4"
                    }
                }
                """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
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
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("a").GetProperty("aa").Set(3);
            mdoc.RootElement.GetProperty("b").GetProperty("ba").Set("3");
            mdoc.RootElement.GetProperty("b").Set(new { ba = "3", bb = "4" });
            mdoc.RootElement.GetProperty("a").GetProperty("ab").Set(4);
            mdoc.RootElement.GetProperty("b").GetProperty("ba").Set("5");
            mdoc.RootElement.GetProperty("a").GetProperty("aa").Set(5);

            string expected = """
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
                """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
        }

        [Test]
        public void CanWritePatchToArrayElement()
        {
            // For an array, if any element has changed, the entire array is replaced.

            string json = """[0, 1, 2]""";

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            mdoc.RootElement.GetIndexElement(0).Set(3);

            string expected = """[3, 1, 2]""";

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
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

            string expected = """
            {
                "a": [2, 1]
            }
            """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
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

            string expected = """
            {
                "a": {
                    "b": [0, 2]
                }
            }
            """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
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

            string expected = """
            {
                "a": {
                    "b": [2, 3]
                }
            }
            """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
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

            string expected = """
            {
                "a":
                [
                    { "b": 4 },
                    { "c": 2 },
                    { "d": 5 }
                ]
            }
            """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
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

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            mdoc.RootElement.GetProperty("a").GetProperty("aa").GetIndexElement(0).Set(2);
            mdoc.RootElement.GetProperty("b").GetProperty("bb").GetProperty("bbb").GetIndexElement(1).Set(true);
            mdoc.RootElement.GetProperty("c").GetIndexElement(1).Set(new { cd = "cd" });

            string expected = """
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
            """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
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

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);
            mdoc.RootElement.GetProperty("a").GetProperty("aa").GetIndexElement(0).Set(2);
            mdoc.RootElement.GetProperty("b").GetProperty("bb").GetProperty("bbb").GetIndexElement(1).Set(true);
            mdoc.RootElement.GetProperty("a").GetProperty("aa").GetIndexElement(0).Set(3);
            mdoc.RootElement.GetProperty("c").GetIndexElement(1).Set(new { cd = "cd" });
            mdoc.RootElement.GetProperty("a").GetProperty("aa").GetIndexElement(1).Set(4);

            string expected = """
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
            """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
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
            mdoc.RootElement.GetProperty("a").GetProperty("aa").Set(new int[] { 2, 3 });
            mdoc.RootElement.GetProperty("c").GetIndexElement(1).Set(new { cd = "cd" });
            mdoc.RootElement.GetProperty("a").GetProperty("aa").GetIndexElement(1).Set(4);

            string expected = """
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
            """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
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
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("a").Set(new { aa = 3, ab = 4 });

            string expected = """
                {
                    "a": {
                        "aa": 3,
                        "ab": 4
                    }
                }
                """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
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
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("a").Set(new { ac = 3 });

            string expected = """
                {
                    "a": {
                        "aa": null,
                        "ab": null,
                        "ac": 3
                    }
                }
                """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
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

            string expected = """
                {
                    "c": 3
                }
                """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
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

            string expected = """
                {
                    "b": {
                        "bc": "3"
                    }
                }
                """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
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
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.SetProperty("c", new { ca = true, cb = false });

            string expected = """
                {
                    "c": {
                        "ca": true,
                        "cb": false
                    }
                }
                """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
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

            string expected = """
                {
                    "a": {
                        "aa": null
                    }
                }
                """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
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

            string expected = """
                {
                    "a": {
                        "aa": null
                    }
                }
                """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
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

            string expected = """
                {
                    "b": null
                }
                """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
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

            string expected = """
                {
                    "b": null
                }
                """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
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

            string expectedRoot = """
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
                """;

            using Stream streamRoot = new MemoryStream();
            mdoc.WriteTo(streamRoot, "P");
            streamRoot.Flush();
            streamRoot.Position = 0;

            string actual = BinaryData.FromStream(streamRoot).ToString();

            AreEqualJson(expectedRoot, actual);

            string expectedA = """
                {
                    "ab": {
                        "abc": 3
                    }
                }
                """;

            using Stream streamA = new MemoryStream();
            using Utf8JsonWriter writerA = new Utf8JsonWriter(streamA);
            mdoc.RootElement.GetProperty("a").WriteTo(writerA, "P");
            writerA.Flush();
            streamA.Position = 0;

            string actualA = BinaryData.FromStream(streamA).ToString();

            AreEqualJson(expectedA, actualA);

            string expectedB = """
                {
                    "ba": "3"
                }
                """;

            using Stream streamB = new MemoryStream();
            using Utf8JsonWriter writerB = new Utf8JsonWriter(streamB);
            mdoc.RootElement.GetProperty("b").WriteTo(writerB, "P");
            writerB.Flush();
            streamB.Position = 0;

            string actualB = BinaryData.FromStream(streamB).ToString();

            AreEqualJson(expectedB, actualB);
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

            string expected = """
                {
                  "a":"z",
                  "c": {
                    "f": null
                  }
                }
                """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
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
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            mdoc.RootElement.GetProperty("title").Set("Hello!");
            mdoc.RootElement.SetProperty("phoneNumber", "+01-123-456-7890");
            mdoc.RootElement.GetProperty("author").RemoveProperty("familyName");
            mdoc.RootElement.SetProperty("tags", new string[] { "example" });

            string expected = """
                {
                  "author": {
                    "familyName": null
                  },
                  "phoneNumber": "+01-123-456-7890",
                  "tags": [ "example" ],
                  "title": "Hello!"
                }
                """;

            using Stream stream = new MemoryStream();
            mdoc.WriteTo(stream, "P");
            stream.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
        }

        #endregion

        #region Helpers
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
            yield return new object[] { "42", (byte)42, (byte)43, (byte)44 };
            yield return new object[] { "42", (sbyte)42, (sbyte)43, (sbyte)44 };
            yield return new object[] { "42", (short)42, (short)43, (short)44 };
            yield return new object[] { "42", (ushort)42, (ushort)43, (ushort)44 };
            yield return new object[] { "42", 42, 43, 44 };
            yield return new object[] { "42", 42u, 43u, 44u };
            yield return new object[] { "42", 42L, 43L, 44L };
            yield return new object[] { "42", 42ul, 43ul, 44ul };
#if NETCOREAPP
            yield return new object[] { "42.1", 42.1f, 43.1f, 44.1f };
            yield return new object[] { "42.1", 42.1d, 43.1d, 44.1d };
#endif
            yield return new object[] { "42.1", 42.1m, 43.1m, 44.1m };
        }
        #endregion
    }
}
