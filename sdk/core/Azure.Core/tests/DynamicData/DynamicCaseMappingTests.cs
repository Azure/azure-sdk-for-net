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

            Assert.That((int)value.camel, Is.EqualTo(1));
            Assert.That((string)value.Pascal, Is.EqualTo("hi"));
            Assert.That((bool)value.parentCamel.nestedCamel, Is.EqualTo(true));
            Assert.That((bool)value.parentCamel.NestedPascal, Is.EqualTo(false));
            Assert.That((string)value.ParentPascal.nestedCamel, Is.EqualTo("a"));
            Assert.That((string)value.ParentPascal.NestedPascal, Is.EqualTo("b"));
        }

        [Test]
        public void CannotGetPropertiesWithUnmatchedCasingWithNoCaseMapping()
        {
            dynamic value = new BinaryData(testJson).ToDynamicFromJson();

            Assert.That(value.Camel, Is.Null);
            Assert.That(value.pascal, Is.Null);
            Assert.That(value.ParentCamel, Is.Null);
            Assert.That(value.parentCamel.NestedCamel, Is.Null);
            Assert.That(value.parentCamel.nestedPascal, Is.Null);
            Assert.That(value.parentPascal, Is.Null);
            Assert.That(value.ParentPascal.NestedCamel, Is.Null);
            Assert.That(value.ParentPascal.nestedPascal, Is.Null);
        }

        [Test]
        public void CanGetPropertiesWithCamelCaseNamingConvention()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic value = new BinaryData(testJson).ToDynamicFromJson(options);

            Assert.That((int)value.camel, Is.EqualTo(1));
            Assert.That((int)value.Camel, Is.EqualTo(1));
            Assert.That((string)value.Pascal, Is.EqualTo("hi"));
            Assert.That((bool)value.parentCamel.nestedCamel, Is.EqualTo(true));
            Assert.That((bool)value.ParentCamel.NestedCamel, Is.EqualTo(true));
            Assert.That((bool)value.parentCamel.NestedPascal, Is.EqualTo(false));
            Assert.That((bool)value.ParentCamel.NestedPascal, Is.EqualTo(false));
            Assert.That((string)value.ParentPascal.nestedCamel, Is.EqualTo("a"));
            Assert.That((string)value.ParentPascal.NestedPascal, Is.EqualTo("b"));
        }

        [Test]
        public void CannotGetPropertiesWithUnmatchedCasingWithCamelCaseNamingConvention()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic value = new BinaryData(testJson).ToDynamicFromJson(options);

            Assert.That(value.pascal, Is.Null);
            Assert.That(value.parentCamel.nestedPascal, Is.Null);
            Assert.That(value.parentPascal, Is.Null);
            Assert.That(value.ParentPascal.nestedPascal, Is.Null);
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

            Assert.That((int)value.camel, Is.EqualTo(2));
            Assert.That((string)value.Pascal, Is.EqualTo("new"));
            Assert.That((bool)value.parentCamel.nestedCamel, Is.EqualTo(false));
            Assert.That((bool)value.parentCamel.NestedPascal, Is.EqualTo(true));
            Assert.That((string)value.ParentPascal.nestedCamel, Is.EqualTo("c"));
            Assert.That((string)value.ParentPascal.NestedPascal, Is.EqualTo("d"));
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

            Assert.That((int)value.camel, Is.EqualTo(1));
            Assert.That((string)value.Pascal, Is.EqualTo("hi"));
            Assert.That((bool)value.parentCamel.nestedCamel, Is.EqualTo(true));
            Assert.That((bool)value.parentCamel.NestedPascal, Is.EqualTo(false));
            Assert.That((string)value.ParentPascal.nestedCamel, Is.EqualTo("a"));
            Assert.That((string)value.ParentPascal.NestedPascal, Is.EqualTo("b"));

            Assert.That((int)value.Camel, Is.EqualTo(2));
            Assert.That((string)value.pascal, Is.EqualTo("new"));
            Assert.That((bool)value.parentCamel.NestedCamel, Is.EqualTo(false));
            Assert.That((bool)value.parentCamel.nestedPascal, Is.EqualTo(true));
            Assert.That((string)value.ParentPascal.NestedCamel, Is.EqualTo("c"));
            Assert.That((string)value.ParentPascal.nestedPascal, Is.EqualTo("d"));
        }

        [Test]
        public void CanSetExistingPropertiesWithCamelCaseNamingConvention()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic value = new BinaryData(testJson).ToDynamicFromJson(options);

            value.camel = 2;
            value.parentCamel.nestedCamel = false;
            value.ParentPascal.nestedCamel = "c";

            Assert.That((int)value.camel, Is.EqualTo(2));
            Assert.That((bool)value.parentCamel.nestedCamel, Is.EqualTo(false));
            Assert.That((string)value.ParentPascal.nestedCamel, Is.EqualTo("c"));

            value.Camel = 3;
            value.ParentCamel.NestedCamel = true;
            value.ParentPascal.NestedCamel = "d";

            Assert.That((int)value.Camel, Is.EqualTo(3));
            Assert.That((bool)value.ParentCamel.NestedCamel, Is.EqualTo(true));
            Assert.That((string)value.ParentPascal.NestedCamel, Is.EqualTo("d"));
        }

        [Test]
        public void SetGivesPrecedenceToCasingOfExistingProperties()
        {
            dynamic value = new BinaryData(testJson).ToDynamicFromJson(JsonPropertyNames.CamelCase);

            value.Pascal = "new";
            value.parentCamel.NestedPascal = true;
            value.ParentPascal.NestedPascal = "c";

            Assert.That((string)value.Pascal, Is.EqualTo("new"));
            Assert.That((bool)value.parentCamel.NestedPascal, Is.EqualTo(true));
            Assert.That((string)value.ParentPascal.NestedPascal, Is.EqualTo("c"));

            Assert.That((string)value.pascal, Is.Null);
            Assert.That((bool?)value.parentCamel.nestedPascal, Is.Null);
            Assert.That((string)value.ParentPascal.nestedPascal, Is.Null);
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

            Assert.That((int)value.camel, Is.EqualTo(1));
            Assert.That((string)value.Pascal, Is.EqualTo("hi"));
            Assert.That((bool)value.parentCamel.nestedCamel, Is.EqualTo(true));
            Assert.That((bool)value.parentCamel.NestedPascal, Is.EqualTo(false));
            Assert.That((string)value.ParentPascal.nestedCamel, Is.EqualTo("a"));
            Assert.That((string)value.ParentPascal.NestedPascal, Is.EqualTo("b"));
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

            Assert.That((int)value.camel, Is.EqualTo(1));
            Assert.That((string)value.Pascal, Is.EqualTo("hi"));
            Assert.That((bool)value.parentCamel.nestedCamel, Is.EqualTo(true));
            Assert.That((bool)value.parentCamel.NestedPascal, Is.EqualTo(false));
            Assert.That((string)value.ParentPascal.nestedCamel, Is.EqualTo("a"));
            Assert.That((string)value.ParentPascal.NestedPascal, Is.EqualTo("b"));

            // All sets are written camelCase.
            Assert.That((string)value.pascal, Is.EqualTo("hi"));
            Assert.That((bool)value.parentCamel.nestedPascal, Is.EqualTo(false));
            Assert.That((string)value.parentPascal.nestedCamel, Is.EqualTo("a"));
            Assert.That((string)value.parentPascal.nestedPascal, Is.EqualTo("b"));
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
            Assert.That(dynamicJson.root.child[0].item.leaf, Is.True);
            Assert.That(dynamicJson.Root.Child[0].Item.Leaf, Is.True);
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

            Assert.That(e.MoveNext(), Is.True);
            dynamic item = e.Current;
            Assert.That((string)item.Name, Is.EqualTo("a"));
            Assert.That((string)item.Value.description, Is.EqualTo("description of a"));
            Assert.That((int)item.Value.index, Is.EqualTo(1));

            Assert.That(e.MoveNext(), Is.True);
            item = e.Current;
            Assert.That((string)item.Name, Is.EqualTo("b"));
            Assert.That((string)item.Value.description, Is.EqualTo("description of b"));
            Assert.That((int)item.Value.index, Is.EqualTo(2));

            Assert.That(e.MoveNext(), Is.False);
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

            Assert.That(e.MoveNext(), Is.True);
            dynamic item = e.Current;
            Assert.That((string)item.Name, Is.EqualTo("a"));
            Assert.That((string)item.Value.Description, Is.EqualTo("description of a"));
            Assert.That((int)item.Value.Index, Is.EqualTo(1));

            Assert.That(e.MoveNext(), Is.True);
            item = e.Current;
            Assert.That((string)item.Name, Is.EqualTo("b"));
            Assert.That((string)item.Value.Description, Is.EqualTo("description of b"));
            Assert.That((int)item.Value.Index, Is.EqualTo(2));

            Assert.That(e.MoveNext(), Is.False);
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

            Assert.That(e.MoveNext(), Is.True);
            dynamic item = e.Current;
            Assert.That((string)item.foo, Is.EqualTo("a"));

            Assert.That(e.MoveNext(), Is.True);
            item = e.Current;
            Assert.That((string)item.foo, Is.EqualTo("b"));

            Assert.That(e.MoveNext(), Is.False);
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

            Assert.That(e.MoveNext(), Is.True);
            dynamic item = e.Current;
            Assert.That((string)item.Foo, Is.EqualTo("a"));

            Assert.That(e.MoveNext(), Is.True);
            item = e.Current;
            Assert.That((string)item.Foo, Is.EqualTo("b"));

            Assert.That(e.MoveNext(), Is.False);
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

            Assert.That((string)value.Pascal, Is.EqualTo("new"));
            Assert.That((bool)value.ParentCamel.NestedPascal, Is.EqualTo(true));
            Assert.That((string)value.ParentPascal.NestedPascal, Is.EqualTo("c"));

            Assert.That((string)value["Pascal"], Is.EqualTo("new"));
            Assert.That((bool)value.ParentCamel["NestedPascal"], Is.EqualTo(true));
            Assert.That((string)value.ParentPascal["NestedPascal"], Is.EqualTo("c"));
        }

        [Test]
        public void CamelCaseMappingWorksForConcerningCases()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic value = new BinaryData("""{}""").ToDynamicFromJson(options);

            value.PIICategories = "categories";
            value.IPAddress = "127.0.0.1";

            Assert.That((string)value.PIICategories, Is.EqualTo("categories"));
            Assert.That((string)value.IPAddress, Is.EqualTo("127.0.0.1"));

            Assert.That((string)value.piiCategories, Is.EqualTo("categories"));
            Assert.That((string)value.ipAddress, Is.EqualTo("127.0.0.1"));
        }

        [Test]
        public void CanMapToCamelViaResponseContentOptions()
        {
            dynamic value = new BinaryData("""{"foo": null}""").ToDynamicFromJson(JsonPropertyNames.CamelCase);

            // Existing property
            value.Foo = 1;

            // New property
            value.Bar = 2;

            Assert.That((int)value.Foo, Is.EqualTo(1));
            Assert.That((int)value.foo, Is.EqualTo(1));
            Assert.That((int)value.Bar, Is.EqualTo(2));
            Assert.That((int)value.bar, Is.EqualTo(2));

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
            Assert.That((int)value.Foo.A, Is.EqualTo(3));
            Assert.That((int)value.Bar.B, Is.EqualTo(4));

            // And that they serialized to camelCase
            Assert.That(value.Foo.ToString(), Is.EqualTo("""{"a":3}"""));
            Assert.That(value.Bar.ToString(), Is.EqualTo("""{"b":4}"""));
        }

        [Test]
        public void CannotMapToCamelViaDefaultResponseContentOptions()
        {
            dynamic value = new BinaryData("""{"foo": "orig"}""").ToDynamicFromJson();

            // Existing property
            value.Foo = 1;

            // New property
            value.Bar = 2;

            Assert.That((int)value.Foo, Is.EqualTo(1));
            Assert.That((string)value.foo, Is.EqualTo("orig"));
            Assert.That((int)value.Bar, Is.EqualTo(2));
            Assert.That(value.bar, Is.Null);

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
            Assert.That((int)value.Foo.A, Is.EqualTo(3));
            Assert.That((string)value.foo, Is.EqualTo("orig"));
            Assert.That((int)value.Bar.B, Is.EqualTo(4));
            Assert.That(value.bar, Is.Null);

            // And that they serialized to PascalCase
            Assert.That(value.Foo.ToString(), Is.EqualTo("""{"A":3}"""));
            Assert.That(value.Bar.ToString(), Is.EqualTo("""{"B":4}"""));
        }

        [Test]
        public void SerializedDynamicDataMaintainsFormatting()
        {
            dynamic a = BinaryData.FromString("""{"foo": null}""").ToDynamicFromJson(JsonPropertyNames.CamelCase, "x");
            dynamic b = BinaryData.FromString("""{"b": "b"}""").ToDynamicFromJson(JsonPropertyNames.CamelCase, "x");

            b.DateTime = new DateTimeOffset(2023, 10, 19, 10, 19, 10, 19, new TimeSpan(0));
            Assert.That((string)b.B, Is.EqualTo("b"));
            Assert.That((int)b.DateTime, Is.EqualTo(1697710750));

            a.Foo = b;
            a.Bar = b;

            Assert.That((string)a.Foo.B, Is.EqualTo("b"));
            Assert.That((string)a.Bar.B, Is.EqualTo("b"));
            Assert.That((int)a.Foo.DateTime, Is.EqualTo(1697710750));
            Assert.That((int)a.Bar.DateTime, Is.EqualTo(1697710750));

            a.Foo.DateTime = new DateTimeOffset(2023, 10, 20, 10, 20, 10, 20, new TimeSpan(0));
            a.Bar.DateTime = new DateTimeOffset(2023, 10, 20, 10, 20, 10, 20, new TimeSpan(0));
            a.Foo.UpdatedOn = new DateTimeOffset(2023, 10, 20, 10, 20, 10, 20, new TimeSpan(0));

            Assert.That((int)a.Foo.DateTime, Is.EqualTo(1697797210));
            Assert.That((int)a.Foo.UpdatedOn, Is.EqualTo(1697797210));
            Assert.That((int)a.Bar.DateTime, Is.EqualTo(1697797210));
        }
    }
}
