// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            string json = @"{ ""foo"" : 1 }";

            dynamic dynamicJson = new BinaryData(json).ToDynamic();

            Assert.AreEqual(1, (int)dynamicJson.foo);
            Assert.AreEqual(1, (int)dynamicJson.Foo);
        }

        [Test]
        public void CanGetCamelCasePropertyStrictCasing()
        {
            string json = @"{ ""foo"" : 1 }";

            DynamicJsonOptions options = new()
            {
                PropertyCasing = new DynamicJsonPropertyCasing()
                {
                    ExistingPropertyAccess = ExistingPropertyCasing.CaseSensitive,
                    NewPropertyAccess = NewPropertyCasing.CaseSensitive
                }
            };

            dynamic dynamicJson = new BinaryData(json).ToDynamic(options);

            Assert.AreEqual(1, (int)dynamicJson.foo);
            Assert.AreEqual(null, dynamicJson.Foo);
        }

        [Test]
        public void CannotGetPascalCasePropertyEitherCase()
        {
            string json = @"{ ""Foo"" : 1 }";

            dynamic dynamicJson = new BinaryData(json).ToDynamic();

            Assert.AreEqual(1, (int)dynamicJson.Foo);
            Assert.AreEqual(null, dynamicJson.foo);
        }

        [Test]
        public void CanSetPascalCaseStrictCasing()
        {
            string json = @"{ ""Foo"" : 1 }";

            DynamicJsonOptions options = new()
            {
                PropertyCasing = new DynamicJsonPropertyCasing()
                {
                    ExistingPropertyAccess = ExistingPropertyCasing.CaseSensitive,
                    NewPropertyAccess = NewPropertyCasing.CaseSensitive
                }
            };
            dynamic dynamicJson = new BinaryData(json).ToDynamic(options);

            dynamicJson.foo = 2;

            Assert.AreEqual(2, (int)dynamicJson.foo);
            Assert.AreEqual(null, dynamicJson.Foo);

            dynamicJson.Foo = 3;

            Assert.AreEqual(2, (int)dynamicJson.foo);
            Assert.AreEqual(3, (int)dynamicJson.Foo);
        }

        [Test]
        public void CanSetPascalCasePropertyEitherCase()
        {
            string json = @"{ ""Foo"" : 1 }";

            DynamicJsonOptions options = new();
            dynamic dynamicJson = new BinaryData(json).ToDynamic(options);

            dynamicJson.foo = 2;

            Assert.AreEqual(2, (int)dynamicJson.foo);
            Assert.AreEqual(2, (int)dynamicJson.Foo);

            dynamicJson.Foo = 3;

            Assert.AreEqual(3, (int)dynamicJson.foo);
            Assert.AreEqual(3, (int)dynamicJson.Foo);
        }

        #region Helpers
        internal static dynamic GetDynamicJson(string json)
        {
            return new BinaryData(json).ToDynamic();
        }

        internal class CustomType
        {
        }
        #endregion
    }
}
