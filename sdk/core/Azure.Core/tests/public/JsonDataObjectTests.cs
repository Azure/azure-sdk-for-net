// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Serialization;
using Microsoft.CSharp.RuntimeBinder;
using NUnit.Framework;

namespace Azure.Core.Tests.Public
{
    public class JsonDataObjectTests
    {
        #region Convert tests

        [Test]
        public void CannotConvertObjectToLeaf()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "value": 5 }""");

            Assert.Throws<InvalidCastException>(() => { var i = (int)data; });
            Assert.Throws<InvalidCastException>(() => { var b = (bool)data; });
            Assert.Throws<InvalidCastException>(() => { var s = (string)data; });
            Assert.Throws<InvalidCastException>(() => { var time = (DateTime)data; });
        }

        [Test]
        [Ignore("Disallowing POCO support in current version.")]
        public void CanConvertObjectToModel()
        {
            dynamic data = BinaryData.FromString(
                """
                {
                    "message": "Hi",
                    "number" : 5
                }
                """).ToDynamicFromJson(JsonPropertyNames.CamelCase);

            Assert.AreEqual(new SampleModel("Hi", 5), (SampleModel)data);
        }
        #endregion

        #region GetMember tests

        public void CanGetMemberOnObject()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "value": 5 }""");
            Assert.AreEqual(5, (int)data.value);
        }

        #endregion

        #region SetMember tests

        public void CanSetMemberOnObject()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "value": 5 }""");
            Assert.AreEqual(5, (int)data.value);

            data.value = 6;
            Assert.AreEqual(6, (int)data.value);
        }

        #endregion

        #region GetIndex tests

        public void CanGetIndexPropertyOnObject()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "value": "Hi" }""");
            string prop = data["value"];
            Assert.AreEqual("hi", prop);
        }

        [Test]
        public void CannotGetArrayIndexOnObject()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "value": "Hi" }""");
            Assert.Throws<InvalidOperationException>(() => { var x = data[0]; });
        }
        #endregion

        #region SetIndex tests

        public void CanSetIndexPropertyOnObject()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "value": "Hi" }""");
            data["value"] = "hello";
            Assert.AreEqual("hello", (string)data["value"]);
        }

        [Test]
        public void CannotSetArrayIndexOnObject()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "value": "Hi" }""");
            Assert.Throws<InvalidOperationException>(() => { data[0] = "invalid"; });
        }

        #endregion

        [Test]
        public void CanEnumerateObject()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "first": 1, "second": 2 }""");

            var expectedNames = new[] { "first", "second" };
            var expectedValues = new[] { 1, 2 };

            int i = 0;
            foreach (dynamic property in data)
            {
                Assert.AreEqual(expectedNames[i], property.Name);
                Assert.AreEqual(expectedValues[i], (int)property.Value);
                i++;
            }

            Assert.AreEqual(2, i);
        }

        [Test]
        public void UnsupportedPropertyAccessThrow()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "first": 1, "second": 2 }""");

            foreach (dynamic property in data)
            {
                Assert.Throws<ArgumentException>(() => { var value = property.InvalidName; });
            }
        }

        [Test]
        public void CannotCallGetDirectly()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "first": 1, "second": 2 }""");

            Assert.Throws<RuntimeBinderException>(() => data.Get("first"));
        }

        [Test]
        public void CannotGetArrayLength()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "first": 1, "second": 2 }""");

            Assert.IsNull(data.Length);
        }

        [Test]
        public void CanGetPropertyCalledLength()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "Foo": 1, "Length": 2 }""");
            int length = data.Length;

            Assert.AreEqual(2, length);
        }
    }
}
