// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using Azure.Core.Dynamic;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class DynamicJsonTests
    {
        [Test]
        public void CanGetIntProperty()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "Foo" : 1
                }
            """);

            int value = jsonData.Foo;

            Assert.AreEqual(1, value);
        }

        [Test]
        public void CanGetNestedIntProperty()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "Foo" : {
                    "Bar" : 1
                  }
                }
                """);

            int value = jsonData.Foo.Bar;

            Assert.AreEqual(1, value);
        }

        [Test]
        public void CanSetIntProperty()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "Foo" : 1
                }
                """);

            jsonData.Foo = 2;

            Assert.AreEqual(2, (int)jsonData.Foo);
        }

        [Test]
        public void CanSetNestedIntProperty()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "Foo" : {
                    "Bar" : 1
                  }
                }
                """);

            jsonData.Foo.Bar = 2;

            Assert.AreEqual(2, (int)jsonData.Foo.Bar);
        }

        [Test]
        public void CanGetArrayValue()
        {
            dynamic jsonData = GetDynamicJson("""[0, 1, 2]""");

            Assert.AreEqual(0, (int)jsonData[0]);
            Assert.AreEqual(1, (int)jsonData[1]);
            Assert.AreEqual(2, (int)jsonData[2]);
        }

        [Test]
        public void CanGetNestedArrayValue()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "Foo": [0, 1, 2]
                }
                """);

            Assert.AreEqual(0, (int)jsonData.Foo[0]);
            Assert.AreEqual(1, (int)jsonData.Foo[1]);
            Assert.AreEqual(2, (int)jsonData.Foo[2]);
        }

        [Test]
        public void CanGetPropertyViaIndexer()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "Foo" : 1
                }
                """);

            Assert.AreEqual(1, (int)jsonData["Foo"]);
        }

        [Test]
        public void CanGetNestedPropertyViaIndexer()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "Foo" : {
                    "Bar" : 1
                  }
                }
                """);

            Assert.AreEqual(1, (int)jsonData.Foo["Bar"]);
        }

        [Test]
        public void CanSetArrayValues()
        {
            dynamic jsonData = GetDynamicJson("""[0, 1, 2]""");

            jsonData[0] = 4;
            jsonData[1] = 5;
            jsonData[2] = 6;

            Assert.AreEqual(4, (int)jsonData[0]);
            Assert.AreEqual(5, (int)jsonData[1]);
            Assert.AreEqual(6, (int)jsonData[2]);
        }

        [Test]
        public void CanSetNestedArrayValues()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "Foo": [0, 1, 2]
                }
                """);

            jsonData.Foo[0] = 4;
            jsonData.Foo[1] = 5;
            jsonData.Foo[2] = 6;

            Assert.AreEqual(4, (int)jsonData.Foo[0]);
            Assert.AreEqual(5, (int)jsonData.Foo[1]);
            Assert.AreEqual(6, (int)jsonData.Foo[2]);
        }

        [Test]
        public void CanSetArrayValuesToDifferentTypes()
        {
            dynamic jsonData = GetDynamicJson("""[0, 1, 2, 3]""");

            jsonData[1] = 4;
            jsonData[2] = true;
            jsonData[3] = "string";

            Assert.AreEqual(0, (int)jsonData[0]);
            Assert.AreEqual(4, (int)jsonData[1]);
            Assert.AreEqual(true, (bool)jsonData[2]);
            Assert.AreEqual("string", (string)jsonData[3]);
        }

        [Test]
        public void CanSetNestedArrayValuesToDifferentTypes()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "Foo": [0, 1, 2, 3]
                }
                """);

            jsonData.Foo[1] = 4;
            jsonData.Foo[2] = true;
            jsonData.Foo[3] = "string";

            Assert.AreEqual(0, (int)jsonData.Foo[0]);
            Assert.AreEqual(4, (int)jsonData.Foo[1]);
            Assert.AreEqual(true, (bool)jsonData.Foo[2]);
            Assert.AreEqual("string", (string)jsonData.Foo[3]);
        }

        [Test]
        public void CanGetNullPropertyValue()
        {
            dynamic jsonData = GetDynamicJson("""{ "Foo" : null }""");

            Assert.IsNull((CustomType)jsonData.Foo);
            Assert.IsNull((int?)jsonData.Foo);
        }

        [Test]
        public void CanGetNullArrayValue()
        {
            dynamic jsonData = GetDynamicJson("""[ null ]""");

            Assert.IsNull((CustomType)jsonData[0]);
            Assert.IsNull((int?)jsonData[0]);
        }

        [Test]
        public void CanSetPropertyValueToNull()
        {
            dynamic jsonData = GetDynamicJson("""{ "Foo" : null }""");

            jsonData.Foo = null;

            Assert.IsNull((CustomType)jsonData.Foo);
            Assert.IsNull((int?)jsonData.Foo);
        }

        [Test]
        public void CanSetArrayValueToNull()
        {
            dynamic jsonData = GetDynamicJson("""[0]""");

            jsonData[0] = null;

            Assert.IsNull((CustomType)jsonData[0]);
            Assert.IsNull((int?)jsonData[0]);
        }

        [Test]
        public void CanSetPropertyViaIndexer()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "Foo" : 1
                }
                """);

            jsonData["Foo"] = 4;

            Assert.AreEqual(4, (int)jsonData["Foo"]);
        }

        [Test]
        public void CanSetNestedPropertyViaIndexer()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "Foo" : {
                    "Bar" : 1
                  }
                }
                """);

            jsonData["Foo"]["Bar"] = 4;

            Assert.AreEqual(4, (int)jsonData.Foo["Bar"]);
        }

        [Test]
        public void CanAddNewProperty()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "Foo" : 1
                }
                """);

            jsonData.Bar = 2;

            Assert.AreEqual(1, (int)jsonData.Foo);
            Assert.AreEqual(2, (int)jsonData.Bar);
        }

        [Test]
        public void CanMakeChangesAndAddNewProperty()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "Foo" : 1
                }
                """);

            Assert.AreEqual(1, (int)jsonData.Foo);

            jsonData.Foo = "hi";

            Assert.AreEqual("hi", (string)jsonData.Foo);

            jsonData.Bar = 2;

            Assert.AreEqual("hi", (string)jsonData.Foo);
            Assert.AreEqual(2, (int)jsonData.Bar);
        }

        [Test]
        public void CanCheckOptionalProperty()
        {
            dynamic json = GetDynamicJson("""
                {
                  "Foo" : "foo"
                }
                """);

            // Property is present
            Assert.IsFalse(json.Foo == null);

            // Property is absent
            Assert.IsTrue(json.Bar == null);
        }

        [Test]
        public void CanCheckOptionalPropertyWithChanges()
        {
            dynamic json = GetDynamicJson("""
                {
                  "Foo" : "foo",
                  "Bar" : {
                    "A" : "a"
                  }
                }
            """);

            // Add property Baz
            json.Baz = "baz";

            // Remove property A
            json.Bar = new { B = "b" };

            // Properties are present
            Assert.IsFalse(json.Foo == null);
            Assert.IsFalse(json.Bar.B == null);
            Assert.IsFalse(json.Baz == null);

            // Properties are absent
            Assert.IsTrue(json.Bar.A == null);
        }

        [Test]
        public void CanSetOptionalProperty()
        {
            dynamic json = GetDynamicJson("""
                {
                  "Foo" : "foo"
                }
                """);

            // Property is absent
            Assert.IsTrue(json.OptionalValue == null);

            json.OptionalValue = 5;

            // Property is present
            Assert.IsFalse(json.OptionalValue == null);
            Assert.AreEqual(5, (int)json.OptionalValue);
        }

        [Test]
        public void CanDispose()
        {
            dynamic json = GetDynamicJson("""
                {
                  "Foo" : "Hello"
                }
                """);

            json.Dispose();

            Assert.Throws<ObjectDisposedException>(() => { var foo = json.Foo; });
        }

        [Test]
        public void CanDisposeViaUsing()
        {
            string json = """
                {
                  "Foo" : "Hello"
                }
                """;

            dynamic outer = default;
            using (dynamic jsonData = GetDynamicJson(json))
            {
                Assert.IsTrue(jsonData.Foo == "Hello");
                outer = jsonData;

                Assert.IsTrue(outer.Foo == "Hello");
            }

            Assert.Throws<ObjectDisposedException>(() => { var foo = outer.Foo; });
        }

        [Test]
        public void DisposingAChildDisposesTheParent()
        {
            dynamic json = GetDynamicJson("""
                {
                  "Foo" : {
                    "A": "Hello"
                  }
                }
                """);

            dynamic child = json.Foo.A;
            child.Dispose();

            Assert.Throws<ObjectDisposedException>(() => { var foo = json.Foo; });
        }

        [Test]
        public void CanGetCamelCasePropertyEitherCase()
        {
            string json = """{ "foo" : 1 }""";

            dynamic dynamicJson = new BinaryData(json).ToDynamic(DynamicJsonOptions.AzureDefault);

            Assert.AreEqual(1, (int)dynamicJson.foo);
            Assert.AreEqual(1, (int)dynamicJson.Foo);
        }

        [Test]
        public void CanGetCamelCasePropertyNoMapping()
        {
            string json = """{ "foo" : 1 }""";

            dynamic dynamicJson = new BinaryData(json).ToDynamic();

            Assert.AreEqual(1, (int)dynamicJson.foo);
            Assert.AreEqual(null, dynamicJson.Foo);
        }

        [Test]
        public void CanGetCamelCasePropertyPascalGetters()
        {
            string json = """{ "foo" : 1 }""";

            DynamicJsonOptions options = new()
            {
                PropertyNameCasing = DynamicJsonNameMapping.PascalCaseGetters
            };

            dynamic dynamicJson = new BinaryData(json).ToDynamic(options);

            Assert.AreEqual(1, (int)dynamicJson.foo);
            Assert.AreEqual(1, (int)dynamicJson.Foo);
        }

        [Test]
        public void CanGetCamelCasePropertyPascalGettersCamelSetters()
        {
            string json = """{ "foo" : 1 }""";

            dynamic dynamicJson = new BinaryData(json).ToDynamic(DynamicJsonOptions.AzureDefault);

            Assert.AreEqual(1, (int)dynamicJson.foo);
            Assert.AreEqual(1, (int)dynamicJson.Foo);
        }

        [Test]
        public void CanGetPascalCasePropertyNoMapping()
        {
            string json = """{ "Foo" : 1 }""";

            dynamic dynamicJson = new BinaryData(json).ToDynamic();

            Assert.AreEqual(null, dynamicJson.foo);
            Assert.AreEqual(1, (int)dynamicJson.Foo);
        }

        [Test]
        public void CanGetPascalCasePropertyPascalGetters()
        {
            string json = """{ "Foo" : 1 }""";

            DynamicJsonOptions options = new()
            {
                PropertyNameCasing = DynamicJsonNameMapping.PascalCaseGetters
            };

            dynamic dynamicJson = new BinaryData(json).ToDynamic(options);

            Assert.AreEqual(null, dynamicJson.foo);
            Assert.AreEqual(1, (int)dynamicJson.Foo);
        }

        [Test]
        public void CanGetPascalCasePropertyPascalGettersCamelSetters()
        {
            string json = """{ "Foo" : 1 }""";

            dynamic dynamicJson = new BinaryData(json).ToDynamic(DynamicJsonOptions.AzureDefault);

            Assert.AreEqual(null, dynamicJson.foo);
            Assert.AreEqual(1, (int)dynamicJson.Foo);
        }

        [Test]
        public void CanSetCamelCaseNoMapping()
        {
            string json = """{ "foo": 1 }""";

            dynamic dynamicJson = new BinaryData(json).ToDynamic();

            // Existing property access
            dynamicJson.foo = 2;

            // New property access
            dynamicJson.bar = 3;

            Assert.AreEqual(2, (int)dynamicJson.foo);
            Assert.AreEqual(null, dynamicJson.Foo);
            Assert.AreEqual(3, (int)dynamicJson.bar);
            Assert.AreEqual(null, dynamicJson.Bar);

            dynamicJson.Foo = 4;
            dynamicJson.Bar = 5;

            Assert.AreEqual(2, (int)dynamicJson.foo);
            Assert.AreEqual(4, (int)dynamicJson.Foo);
            Assert.AreEqual(3, (int)dynamicJson.bar);
            Assert.AreEqual(5, (int)dynamicJson.Bar);
        }

        [Test]
        public void CanSetCamelCasePascalGetters()
        {
            string json = """{ "foo": 1 }""";

            DynamicJsonOptions options = new()
            {
                PropertyNameCasing = DynamicJsonNameMapping.PascalCaseGetters
            };
            dynamic dynamicJson = new BinaryData(json).ToDynamic(options);

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

            // New property is created as PascalCase
            dynamicJson.Baz = 6;

            Assert.AreEqual(4, (int)dynamicJson.foo);
            Assert.AreEqual(4, (int)dynamicJson.Foo);
            Assert.AreEqual(5, (int)dynamicJson.bar);
            Assert.AreEqual(5, (int)dynamicJson.Bar);
            Assert.AreEqual(null, dynamicJson.baz);
            Assert.AreEqual(6, (int)dynamicJson.Baz);
        }

        [Test]
        public void CanSetCamelCasePascalGettersCamelSetters()
        {
            string json = """{ "foo": 1 }""";

            dynamic dynamicJson = new BinaryData(json).ToDynamic(DynamicJsonOptions.AzureDefault);

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
        public void CanSetPascalCaseNoMapping()
        {
            string json = """{ "Foo": 1 }""";

            dynamic dynamicJson = new BinaryData(json).ToDynamic();

            // This adds a new property, since it doesn't find `Foo`.
            dynamicJson.foo = 2;

            // New property access
            dynamicJson.bar = 3;

            Assert.AreEqual(2, (int)dynamicJson.foo);
            Assert.AreEqual(1, (int)dynamicJson.Foo);
            Assert.AreEqual(3, (int)dynamicJson.bar);
            Assert.AreEqual(null, dynamicJson.Bar);

            // This updates the PascalCase property and not the camelCase one.
            dynamicJson.Foo = 4;

            // This creates a new PascalCase property.
            dynamicJson.Bar = 5;

            Assert.AreEqual(2, (int)dynamicJson.foo);
            Assert.AreEqual(4, (int)dynamicJson.Foo);
            Assert.AreEqual(3, (int)dynamicJson.bar);
            Assert.AreEqual(5, (int)dynamicJson.Bar);
        }

        [Test]
        public void CanSetPascalCasePascalGetters()
        {
            string json = """{ "Foo": 1 }""";

            DynamicJsonOptions options = new()
            {
                PropertyNameCasing = DynamicJsonNameMapping.PascalCaseGetters
            };
            dynamic dynamicJson = new BinaryData(json).ToDynamic(options);

            // This property doesn't exist, so it creates a new camelCase property.
            dynamicJson.foo = 2;

            // New property is created as camelCase
            dynamicJson.bar = 3;

            Assert.AreEqual(2, (int)dynamicJson.foo);
            Assert.AreEqual(1, (int)dynamicJson.Foo);
            Assert.AreEqual(3, (int)dynamicJson.bar);
            Assert.AreEqual(3, (int)dynamicJson.Bar);

            // This updates the PascalCase property and not the camelCase one.
            dynamicJson.Foo = 4;

            // The PascalCase getter finds `bar`, so it updates the camelCase property.
            dynamicJson.Bar = 5;

            // New property is created as PascalCase
            dynamicJson.Baz = 6;

            Assert.AreEqual(2, (int)dynamicJson.foo);
            Assert.AreEqual(4, (int)dynamicJson.Foo);
            Assert.AreEqual(5, (int)dynamicJson.bar);
            Assert.AreEqual(5, (int)dynamicJson.Bar);
            Assert.AreEqual(null, dynamicJson.baz);
            Assert.AreEqual(6, (int)dynamicJson.Baz);
        }

        [Test]
        public void CanSetPascalCasePascalGettersCamelSetters()
        {
            string json = """{ "Foo": 1 }""";

            dynamic dynamicJson = new BinaryData(json).ToDynamic(DynamicJsonOptions.AzureDefault);

            // Existing property access does not add a camelCase property.
            dynamicJson.Foo = 2;

            // New property is created as camelCase
            dynamicJson.Bar = 3;

            Assert.AreEqual(null, dynamicJson.foo);
            Assert.AreEqual(2, (int)dynamicJson.Foo);
            Assert.AreEqual(3, (int)dynamicJson.bar);
            Assert.AreEqual(3, (int)dynamicJson.Bar);
        }

        [Test]
        public void CanPassPropertyNameCasingEnumDirectly()
        {
            string json = """{ "foo" : 1 }""";

            dynamic dynamicJson = new BinaryData(json).ToDynamic(DynamicJsonNameMapping.None);

            Assert.AreEqual(1, (int)dynamicJson.foo);
            Assert.AreEqual(null, dynamicJson.Foo);
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

            dynamic dynamicJson = BinaryData.FromString(json).ToDynamic(DynamicJsonOptions.AzureDefault);
            Assert.IsTrue(dynamicJson.root.child[0].item.leaf);
            Assert.IsTrue(dynamicJson.Root.Child[0].Item.Leaf);
        }

        [Test]
        public void CanEnumerateArrayCamelGetters()
        {
            dynamic jsonData = GetDynamicJson("""
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
                """);

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
            dynamic jsonData = GetDynamicJson("""
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
                """, DynamicJsonNameMapping.PascalCaseGetters);

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
        public void CanEnumeratePropertiesCamelGetters()
        {
            dynamic jsonData = GetDynamicJson("""
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
                """);

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
            dynamic jsonData = GetDynamicJson("""
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
                """, DynamicJsonNameMapping.PascalCaseGetters);

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

        #region Helpers
        internal static dynamic GetDynamicJson(string json, DynamicJsonNameMapping propertyNameCasing = default)
        {
            return new BinaryData(json).ToDynamic(propertyNameCasing);
        }

        internal class CustomType
        {
        }
        #endregion
    }
}
