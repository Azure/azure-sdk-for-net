// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using Azure.Core.Dynamic;
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
        public void CanGetPropertiesWithPascalToCamelMapping()
        {
            DynamicDataOptions options = new() { NameConverter = NameConverter.CamelCase };
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
        public void CannotGetPropertiesWithUnmatchedCasingWithPascalToCamelMapping()
        {
            DynamicDataOptions options = new() { NameConverter = NameConverter.CamelCase };
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
        public void CanSetExistingPropertiesWithPascalToCamelMapping()
        {
            DynamicDataOptions options = new() { NameConverter = NameConverter.CamelCase };
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
        public void SettingExistingPropertiesWithUnmatchedCasingAddsNewPropertyWhenPascalToCamelMapping()
        {
            DynamicDataOptions options = new() { NameConverter = NameConverter.CamelCase };
            dynamic value = new BinaryData(testJson).ToDynamicFromJson(options);

            value.Pascal = "new";
            value.parentCamel.NestedPascal = true;
            value.ParentPascal.NestedPascal = "c";

            Assert.AreEqual("hi", (string)value.Pascal);
            Assert.AreEqual(false, (bool)value.parentCamel.NestedPascal);
            Assert.AreEqual("b", (string)value.ParentPascal.NestedPascal);

            Assert.AreEqual("new", (string)value.pascal);
            Assert.AreEqual(true, (bool)value.parentCamel.nestedPascal);
            Assert.AreEqual("c", (string)value.ParentPascal.nestedPascal);
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
        public void CanSetNewPropertiesWithPascalToCamelMapping()
        {
            DynamicDataOptions options = new() { NameConverter = NameConverter.CamelCase };
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

            DynamicDataOptions options = new() { NameConverter = NameConverter.CamelCase };
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
        public void CanEnumeratePropertiesPascalGettersWithPascalToCamelMapping()
        {
            DynamicDataOptions options = new() { NameConverter = NameConverter.CamelCase };
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
        public void CanEnumerateArrayPascalGettersWithPascalToCamelMapping()
        {
            DynamicDataOptions options = new() { NameConverter = NameConverter.CamelCase };
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
            DynamicDataOptions options = new() { NameConverter = NameConverter.CamelCase };
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
            DynamicDataOptions options = new() { NameConverter = NameConverter.CamelCase };
            dynamic value = new BinaryData("""{}""").ToDynamicFromJson(options);

            value.PIICategories = "categories";
            value.IPAddress = "127.0.0.1";

            Assert.AreEqual("categories", (string)value.PIICategories);
            Assert.AreEqual("127.0.0.1", (string)value.IPAddress);

            Assert.AreEqual("categories", (string)value.piiCategories);
            Assert.AreEqual("127.0.0.1", (string)value.ipAddress);
        }
    }
}
