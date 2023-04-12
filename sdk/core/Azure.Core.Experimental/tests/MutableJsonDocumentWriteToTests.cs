// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core.Json;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
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
        public void CanWriteDateTime()
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

        #region Helpers
        private class TestClass
        {
            public string StringProperty { get; set; }
            public int IntProperty { get; set; }
            public double DoubleProperty { get; set; }
            public TestClass ObjectProperty { get; set; }
            public TestClass[] ArrayProperty { get; set; }
        }
        #endregion
    }
}
