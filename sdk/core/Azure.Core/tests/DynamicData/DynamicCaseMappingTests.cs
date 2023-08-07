// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using Azure.Core.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class DynamicCaseMappingTests
    {
        private static readonly string testJson = """
                {
                    "camel" : 1,
                    "Pascal" : "hi",
                    "parentCamel" :
                    {
                        "nestedCamel" : true,
                        "NestedPascal" : false
                    },
                    "ParentPascal" :
                    {
                        "nestedCamel" : "a",
                        "NestedPascal" : "b"
                    }
                }
                """;

        [Test]
        public void CanGetPropertiesWithNoCaseMapping()
        {
            dynamic value = new BinaryData(testJson).ToDynamicFromJson();

            Assert.AreEqual(1, (int)value.camel);
            Assert.AreEqual("hi", (string)value.Pascal);
            Assert.AreEqual(true, (bool)value.parentCamel.nestedCamel);
            Assert.AreEqual(false, (bool)value.parentCamel.NestedPascal);
            Assert.AreEqual("a", (string)value.ParentPascal.nestedCamel);
            Assert.AreEqual("b", (string)value.ParentPascal.NestedPascal);
        }

        [Test]
        public void CannotGetPropertiesWithUnmatchedCasingWithNoCaseMapping()
        {
            dynamic value = new BinaryData(testJson).ToDynamicFromJson();

            Assert.IsNull(value.Camel);
            Assert.IsNull(value.pascal);
            Assert.IsNull(value.ParentCamel);
            Assert.IsNull(value.parentCamel.NestedCamel);
            Assert.IsNull(value.parentCamel.nestedPascal);
            Assert.IsNull(value.parentPascal);
            Assert.IsNull(value.ParentPascal.NestedCamel);
            Assert.IsNull(value.ParentPascal.nestedPascal);
        }

        [Test]
        public void CanGetPropertiesWithCamelCaseNamingConvention()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic value = new BinaryData(testJson).ToDynamicFromJson(options);

            Assert.AreEqual(1, (int)value.camel);
            Assert.AreEqual(1, (int)value.Camel);
            Assert.AreEqual("hi", (string)value.Pascal);
            Assert.AreEqual(true, (bool)value.parentCamel.nestedCamel);
            Assert.AreEqual(true, (bool)value.ParentCamel.NestedCamel);
            Assert.AreEqual(false, (bool)value.parentCamel.NestedPascal);
            Assert.AreEqual(false, (bool)value.ParentCamel.NestedPascal);
            Assert.AreEqual("a", (string)value.ParentPascal.nestedCamel);
            Assert.AreEqual("b", (string)value.ParentPascal.NestedPascal);
        }

        [Test]
        public void CannotGetPropertiesWithUnmatchedCasingWithCamelCaseNamingConvention()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic value = new BinaryData(testJson).ToDynamicFromJson(options);

            Assert.IsNull(value.pascal);
            Assert.IsNull(value.parentCamel.nestedPascal);
            Assert.IsNull(value.parentPascal);
            Assert.IsNull(value.ParentPascal.nestedPascal);
        }

        [Test]
        public void CanSetExistingPropertiesWithNoCaseMapping()
        {
            dynamic value = new BinaryData(testJson).ToDynamicFromJson();

            value.camel = 2;
            value.Pascal = "new";
            value.parentCamel.nestedCamel = false;
            value.parentCamel.NestedPascal = true;
            value.ParentPascal.nestedCamel = "c";
            value.ParentPascal.NestedPascal = "d";

            Assert.AreEqual(2, (int)value.camel);
            Assert.AreEqual("new", (string)value.Pascal);
            Assert.AreEqual(false, (bool)value.parentCamel.nestedCamel);
            Assert.AreEqual(true, (bool)value.parentCamel.NestedPascal);
            Assert.AreEqual("c", (string)value.ParentPascal.nestedCamel);
            Assert.AreEqual("d", (string)value.ParentPascal.NestedPascal);
        }

        [Test]
        public void SettingExistingPropertiesWithUnmatchedCasingAddsNewPropertyWhenNoCaseMapping()
        {
            dynamic value = new BinaryData(testJson).ToDynamicFromJson();

            value.Camel = 2;
            value.pascal = "new";
            value.parentCamel.NestedCamel = false;
            value.parentCamel.nestedPascal = true;
            value.ParentPascal.NestedCamel = "c";
            value.ParentPascal.nestedPascal = "d";

            Assert.AreEqual(1, (int)value.camel);
            Assert.AreEqual("hi", (string)value.Pascal);
            Assert.AreEqual(true, (bool)value.parentCamel.nestedCamel);
            Assert.AreEqual(false, (bool)value.parentCamel.NestedPascal);
            Assert.AreEqual("a", (string)value.ParentPascal.nestedCamel);
            Assert.AreEqual("b", (string)value.ParentPascal.NestedPascal);

            Assert.AreEqual(2, (int)value.Camel);
            Assert.AreEqual("new", (string)value.pascal);
            Assert.AreEqual(false, (bool)value.parentCamel.NestedCamel);
            Assert.AreEqual(true, (bool)value.parentCamel.nestedPascal);
            Assert.AreEqual("c", (string)value.ParentPascal.NestedCamel);
            Assert.AreEqual("d", (string)value.ParentPascal.nestedPascal);
        }

        [Test]
        public void CanSetExistingPropertiesWithCamelCaseNamingConvention()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic value = new BinaryData(testJson).ToDynamicFromJson(options);

            value.camel = 2;
            value.parentCamel.nestedCamel = false;
            value.ParentPascal.nestedCamel = "c";

            Assert.AreEqual(2, (int)value.camel);
            Assert.AreEqual(false, (bool)value.parentCamel.nestedCamel);
            Assert.AreEqual("c", (string)value.ParentPascal.nestedCamel);

            value.Camel = 3;
            value.ParentCamel.NestedCamel = true;
            value.ParentPascal.NestedCamel = "d";

            Assert.AreEqual(3, (int)value.Camel);
            Assert.AreEqual(true, (bool)value.ParentCamel.NestedCamel);
            Assert.AreEqual("d", (string)value.ParentPascal.NestedCamel);
        }

        [Test]
        public void SetGivesPrecedenceToCasingOfExistingProperties()
        {
            dynamic value = new BinaryData(testJson).ToDynamicFromJson(JsonPropertyNames.CamelCase);

            value.Pascal = "new";
            value.parentCamel.NestedPascal = true;
            value.ParentPascal.NestedPascal = "c";

            Assert.AreEqual("new", (string)value.Pascal);
            Assert.AreEqual(true, (bool)value.parentCamel.NestedPascal);
            Assert.AreEqual("c", (string)value.ParentPascal.NestedPascal);

            Assert.IsNull((string)value.pascal);
            Assert.IsNull((bool?)value.parentCamel.nestedPascal);
            Assert.IsNull((string)value.ParentPascal.nestedPascal);
        }

        [Test]
        public void CanSetNewPropertiesWithNoCaseMapping()
        {
            dynamic value = new BinaryData("""{}""").ToDynamicFromJson();

            value.camel = 1;
            value.Pascal = "hi";
            value.parentCamel = new { };
            value.parentCamel.nestedCamel = true;
            value.parentCamel.NestedPascal = false;
            value.ParentPascal = new { };
            value.ParentPascal.nestedCamel = "a";
            value.ParentPascal.NestedPascal = "b";

            Assert.AreEqual(1, (int)value.camel);
            Assert.AreEqual("hi", (string)value.Pascal);
            Assert.AreEqual(true, (bool)value.parentCamel.nestedCamel);
            Assert.AreEqual(false, (bool)value.parentCamel.NestedPascal);
            Assert.AreEqual("a", (string)value.ParentPascal.nestedCamel);
            Assert.AreEqual("b", (string)value.ParentPascal.NestedPascal);
        }

        [Test]
        public void CanSetNewPropertiesWithCamelCaseNamingConvention()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic value = new BinaryData("""{}""").ToDynamicFromJson(options);

            value.camel = 1;
            value.Pascal = "hi";
            value.parentCamel = new { };
            value.parentCamel.nestedCamel = true;
            value.parentCamel.NestedPascal = false;
            value.ParentPascal = new { };
            value.ParentPascal.nestedCamel = "a";
            value.ParentPascal.NestedPascal = "b";

            Assert.AreEqual(1, (int)value.camel);
            Assert.AreEqual("hi", (string)value.Pascal);
            Assert.AreEqual(true, (bool)value.parentCamel.nestedCamel);
            Assert.AreEqual(false, (bool)value.parentCamel.NestedPascal);
            Assert.AreEqual("a", (string)value.ParentPascal.nestedCamel);
            Assert.AreEqual("b", (string)value.ParentPascal.NestedPascal);

            // All sets are written camelCase.
            Assert.AreEqual("hi", (string)value.pascal);
            Assert.AreEqual(false, (bool)value.parentCamel.nestedPascal);
            Assert.AreEqual("a", (string)value.parentPascal.nestedCamel);
            Assert.AreEqual("b", (string)value.parentPascal.nestedPascal);
        }

        [Test]
        public void CanGetPascalCaseNestedPropertiesIncludeArrays()
        {
            string json = """
                {
                    "root" : {
                        "child" : [
                            {
                                "item": {
                                    "leaf" : true
                                }
                            }
                        ]
                    }
                }
                """;

            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic dynamicJson = BinaryData.FromString(json).ToDynamicFromJson(options);
            Assert.IsTrue(dynamicJson.root.child[0].item.leaf);
            Assert.IsTrue(dynamicJson.Root.Child[0].Item.Leaf);
        }

        [Test]
        public void CanEnumeratePropertiesCamelGettersWithNoCaseMapping()
        {
            dynamic jsonData = BinaryData.FromString("""
                {
                    "a": {
                        "description": "description of a",
                        "index": 1
                    },
                    "b": {
                        "description": "description of b",
                        "index": 2
                    }
                }
                """).ToDynamicFromJson();

            IEnumerable ary = (IEnumerable)jsonData;
            IEnumerator e = ary.GetEnumerator();

            Assert.IsTrue(e.MoveNext());
            dynamic item = e.Current;
            Assert.AreEqual("a", (string)item.Name);
            Assert.AreEqual("description of a", (string)item.Value.description);
            Assert.AreEqual(1, (int)item.Value.index);

            Assert.IsTrue(e.MoveNext());
            item = e.Current;
            Assert.AreEqual("b", (string)item.Name);
            Assert.AreEqual("description of b", (string)item.Value.description);
            Assert.AreEqual(2, (int)item.Value.index);

            Assert.IsFalse(e.MoveNext());
        }

        [Test]
        public void CanEnumeratePropertiesPascalGettersWithCamelCaseNamingConvention()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic jsonData = BinaryData.FromString("""
                {
                    "a": {
                        "description": "description of a",
                        "index": 1
                    },
                    "b": {
                        "description": "description of b",
                        "index": 2
                    }
                }
                """).ToDynamicFromJson(options);

            IEnumerable ary = (IEnumerable)jsonData;
            IEnumerator e = ary.GetEnumerator();

            Assert.IsTrue(e.MoveNext());
            dynamic item = e.Current;
            Assert.AreEqual("a", (string)item.Name);
            Assert.AreEqual("description of a", (string)item.Value.Description);
            Assert.AreEqual(1, (int)item.Value.Index);

            Assert.IsTrue(e.MoveNext());
            item = e.Current;
            Assert.AreEqual("b", (string)item.Name);
            Assert.AreEqual("description of b", (string)item.Value.Description);
            Assert.AreEqual(2, (int)item.Value.Index);

            Assert.IsFalse(e.MoveNext());
        }

        [Test]
        public void CanEnumerateArrayCamelGettersWithNoCaseMapping()
        {
            dynamic jsonData = BinaryData.FromString("""
                {
                    "array": [
                        {
                            "foo": "a"
                        },
                        {
                            "foo": "b"
                        }
                    ]
                }
                """).ToDynamicFromJson();

            IEnumerable ary = (IEnumerable)jsonData.array;
            IEnumerator e = ary.GetEnumerator();

            Assert.IsTrue(e.MoveNext());
            dynamic item = e.Current;
            Assert.AreEqual("a", (string)item.foo);

            Assert.IsTrue(e.MoveNext());
            item = e.Current;
            Assert.AreEqual("b", (string)item.foo);

            Assert.IsFalse(e.MoveNext());
        }

        [Test]
        public void CanEnumerateArrayPascalGettersWithCamelCaseNamingConvention()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic jsonData = BinaryData.FromString("""
                {
                    "array": [
                        {
                            "foo": "a"
                        },
                        {
                            "foo": "b"
                        }
                    ]
                }
                """).ToDynamicFromJson(options);

            IEnumerable ary = (IEnumerable)jsonData.Array;
            IEnumerator e = ary.GetEnumerator();

            Assert.IsTrue(e.MoveNext());
            dynamic item = e.Current;
            Assert.AreEqual("a", (string)item.Foo);

            Assert.IsTrue(e.MoveNext());
            item = e.Current;
            Assert.AreEqual("b", (string)item.Foo);

            Assert.IsFalse(e.MoveNext());
        }

        [Test]
        public void CanBypassNameMappingWithIndexers()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic value = new BinaryData(testJson).ToDynamicFromJson(options);

            // Set PascalCase values without converting to camelCase
            value["Pascal"] = "new";
            value.ParentCamel["NestedPascal"] = true;
            value.ParentPascal["NestedPascal"] = "c";

            Assert.AreEqual("new", (string)value.Pascal);
            Assert.AreEqual(true, (bool)value.ParentCamel.NestedPascal);
            Assert.AreEqual("c", (string)value.ParentPascal.NestedPascal);

            Assert.AreEqual("new", (string)value["Pascal"]);
            Assert.AreEqual(true, (bool)value.ParentCamel["NestedPascal"]);
            Assert.AreEqual("c", (string)value.ParentPascal["NestedPascal"]);
        }

        [Test]
        public void CamelCaseMappingWorksForConcerningCases()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic value = new BinaryData("""{}""").ToDynamicFromJson(options);

            value.PIICategories = "categories";
            value.IPAddress = "127.0.0.1";

            Assert.AreEqual("categories", (string)value.PIICategories);
            Assert.AreEqual("127.0.0.1", (string)value.IPAddress);

            Assert.AreEqual("categories", (string)value.piiCategories);
            Assert.AreEqual("127.0.0.1", (string)value.ipAddress);
        }

        [Test]
        public void CanMapToCamelViaResponseContentOptions()
        {
            dynamic value = new BinaryData("""{"foo": null}""").ToDynamicFromJson(JsonPropertyNames.CamelCase);

            // Existing property
            value.Foo = 1;

            // New property
            value.Bar = 2;

            Assert.AreEqual(1, (int)value.Foo);
            Assert.AreEqual(1, (int)value.foo);
            Assert.AreEqual(2, (int)value.Bar);
            Assert.AreEqual(2, (int)value.bar);

            // Serialized model - existing property
            value.Foo = new
            {
                A = 3
            };

            // Serialized model - new property
            value.Bar = new
            {
                B = 4
            };

            // Show they can be accessed with PascalCase
            Assert.AreEqual(3, (int)value.Foo.A);
            Assert.AreEqual(4, (int)value.Bar.B);

            // And that they serialized to camelCase
            Assert.AreEqual("""{"a":3}""", value.Foo.ToString());
            Assert.AreEqual("""{"b":4}""", value.Bar.ToString());
        }

        [Test]
        public void CannotMapToCamelViaDefaultResponseContentOptions()
        {
            dynamic value = new BinaryData("""{"foo": "orig"}""").ToDynamicFromJson();

            // Existing property
            value.Foo = 1;

            // New property
            value.Bar = 2;

            Assert.AreEqual(1, (int)value.Foo);
            Assert.AreEqual("orig", (string)value.foo);
            Assert.AreEqual(2, (int)value.Bar);
            Assert.IsNull(value.bar);

            // Serialized model - existing property
            value.Foo = new
            {
                A = 3
            };

            // Serialized model - new property
            value.Bar = new
            {
                B = 4
            };

            // Show what happens with PascalCase
            Assert.AreEqual(3, (int)value.Foo.A);
            Assert.AreEqual("orig", (string)value.foo);
            Assert.AreEqual(4, (int)value.Bar.B);
            Assert.IsNull(value.bar);

            // And that they serialized to PascalCase
            Assert.AreEqual("""{"A":3}""", value.Foo.ToString());
            Assert.AreEqual("""{"B":4}""", value.Bar.ToString());
        }

        [Test]
        public void SerializedDynamicDataMaintainsFormatting()
        {
            dynamic a = BinaryData.FromString("""{"foo": null}""").ToDynamicFromJson(JsonPropertyNames.CamelCase, "x");
            dynamic b = BinaryData.FromString("""{"b": "b"}""").ToDynamicFromJson(JsonPropertyNames.CamelCase, "x");

            b.DateTime = new DateTimeOffset(2023, 10, 19, 10, 19, 10, 19, new TimeSpan(0));
            Assert.AreEqual("b", (string)b.B);
            Assert.AreEqual(1697710750, (int)b.DateTime);

            a.Foo = b;
            a.Bar = b;

            Assert.AreEqual("b", (string)a.Foo.B);
            Assert.AreEqual("b", (string)a.Bar.B);
            Assert.AreEqual(1697710750, (int)a.Foo.DateTime);
            Assert.AreEqual(1697710750, (int)a.Bar.DateTime);

            a.Foo.DateTime = new DateTimeOffset(2023, 10, 20, 10, 20, 10, 20, new TimeSpan(0));
            a.Bar.DateTime = new DateTimeOffset(2023, 10, 20, 10, 20, 10, 20, new TimeSpan(0));
            a.Foo.UpdatedOn = new DateTimeOffset(2023, 10, 20, 10, 20, 10, 20, new TimeSpan(0));

            Assert.AreEqual(1697797210, (int)a.Foo.DateTime);
            Assert.AreEqual(1697797210, (int)a.Foo.UpdatedOn);
            Assert.AreEqual(1697797210, (int)a.Bar.DateTime);
        }
    }
}
