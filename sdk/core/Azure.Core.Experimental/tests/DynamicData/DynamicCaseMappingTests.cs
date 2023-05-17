// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core.Dynamic;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class DynamicCaseMappingTests
    {
        #region Tests of strict naming, CaseMapping.None
        [Test]
        public void CannotGetPascalCasePropertyCamelCase()
        {
            string json = """{ "Foo" : 1 }""";

            dynamic dynamicJson = new BinaryData(json).ToDynamicFromJson();

            Assert.AreEqual(null, dynamicJson.foo);
            Assert.AreEqual(1, (int)dynamicJson.Foo);
        }

        [Test]
        public void CanSetCamelCaseProperties()
        {
            string json = """{ "foo": 1 }""";

            dynamic dynamicJson = new BinaryData(json).ToDynamicFromJson();

            // Existing property access
            dynamicJson.foo = 2;

            // New property access
            dynamicJson.bar = 3;

            Assert.AreEqual(2, (int)dynamicJson.foo);
            Assert.AreEqual(3, (int)dynamicJson.bar);

            // Pascal case properties don't clobber camel case ones.
            dynamicJson["Foo"] = 4;
            dynamicJson["Bar"] = 5;

            Assert.AreEqual(2, (int)dynamicJson.foo);
            Assert.AreEqual(4, (int)dynamicJson.Foo);
            Assert.AreEqual(3, (int)dynamicJson.bar);
            Assert.AreEqual(5, (int)dynamicJson.Bar);
        }

        [Test]
        public void CanSetPascalCaseProperties()
        {
            string json = """{ "Foo": 1 }""";

            dynamic dynamicJson = new BinaryData(json).ToDynamicFromJson();

            // Existing property access does not add a camelCase property.
            dynamicJson.Foo = 2;

            // New property is created as camelCase
            dynamicJson.Bar = 3;

            Assert.AreEqual(null, dynamicJson.foo);
            Assert.AreEqual(2, (int)dynamicJson.Foo);
            Assert.AreEqual(3, (int)dynamicJson.bar);
            Assert.AreEqual(3, (int)dynamicJson.Bar);
        }
        #endregion

        #region Tests of PascalCase naming, CaseMapping.PascalToCamel

        [Test]
        public void CanGetCamelCasePropertyEitherCase()
        {
            string json = """{ "foo" : 1 }""";

            dynamic dynamicJson = new BinaryData(json).ToDynamicFromJson(DynamicCaseMapping.PascalToCamel);

            Assert.AreEqual(1, (int)dynamicJson.foo);
            Assert.AreEqual(1, (int)dynamicJson.Foo);
        }

        [Test]
        public void CanSetCamelCasePropertiesWithPascalCaseNames()
        {
            string json = """{ "foo": 1 }""";

            dynamic dynamicJson = new BinaryData(json).ToDynamicFromJson(DynamicCaseMapping.PascalToCamel);

            // Existing property access
            dynamicJson.foo = 2;

            // New property is created as camelCase
            dynamicJson.bar = 3;

            Assert.AreEqual(2, (int)dynamicJson.foo);
            Assert.AreEqual(2, (int)dynamicJson.Foo);
            Assert.AreEqual(3, (int)dynamicJson.bar);
            Assert.AreEqual(3, (int)dynamicJson.Bar);

            // PascalCase getters find camelCase properties and sets them.
            dynamicJson.Foo = 4;
            dynamicJson.Bar = 5;

            // New property is created as camelCase
            dynamicJson.Baz = 6;

            Assert.AreEqual(4, (int)dynamicJson.foo);
            Assert.AreEqual(4, (int)dynamicJson.Foo);
            Assert.AreEqual(5, (int)dynamicJson.bar);
            Assert.AreEqual(5, (int)dynamicJson.Bar);
            Assert.AreEqual(6, (int)dynamicJson.baz);
            Assert.AreEqual(6, (int)dynamicJson.Baz);
        }

        [Test]
        public void CanMixPascalCaseAndCamelCaseNames()
        {
            string json = """{ "Foo": 1 }""";

            dynamic dynamicJson = new BinaryData(json).ToDynamicFromJson(DynamicCaseMapping.PascalToCamel);

            // This adds a new camelCase property, since it doesn't find `Foo`.
            dynamicJson.foo = 2;

            // This creates a new camelCase property.
            dynamicJson.bar = 3;

            Assert.AreEqual(2, (int)dynamicJson.foo);
            Assert.AreEqual(1, (int)dynamicJson.Foo);
            Assert.AreEqual(3, (int)dynamicJson.bar);
            Assert.AreEqual(3, (int)dynamicJson.Bar);
            Assert.Throws<KeyNotFoundException>(() => _ = dynamicJson["Bar"]);

            // This updates the PascalCase property and not the camelCase one.
            dynamicJson.Foo = 4;

            // This creates a new PascalCase property.
            dynamicJson["Bar"] = 5;

            Assert.AreEqual(2, (int)dynamicJson.foo);
            Assert.AreEqual(4, (int)dynamicJson.Foo);
            Assert.AreEqual(3, (int)dynamicJson.bar);
            Assert.AreEqual(5, (int)dynamicJson.Bar);
        }

        [Test]
        public void CanGetPascalCaseNestedProperties()
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

            dynamic dynamicJson = BinaryData.FromString(json).ToDynamicFromJson(DynamicCaseMapping.PascalToCamel);
            Assert.IsTrue(dynamicJson.root.child[0].item.leaf);
            Assert.IsTrue(dynamicJson.Root.Child[0].Item.Leaf);
        }

        [Test]
        public void CanEnumeratePropertiesCamelGetters()
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
                """).ToDynamicFromJson(DynamicCaseMapping.PascalToCamel);

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
        public void CanEnumeratePropertiesPascalGetters()
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
                """).ToDynamicFromJson(DynamicCaseMapping.PascalToCamel);

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
        public void CanEnumerateArrayCamelGetters()
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
                """).ToDynamicFromJson(DynamicCaseMapping.PascalToCamel);

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
        public void CanEnumerateArrayPascalGetters()
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
                """).ToDynamicFromJson(DynamicCaseMapping.PascalToCamel);

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

        #endregion
    }
}
