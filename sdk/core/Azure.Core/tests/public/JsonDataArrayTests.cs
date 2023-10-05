﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Tests.Public
{
    public class JsonDataArrayTests
    {
        #region Convert tests

        [Test]
        public void CanConvertArrayToIEnumerable()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("[1, 2, 3]");

            // TODO: This is interesting - what is commented out below fails,
            // because apparently the type system has decided the IEnumerable
            // is holding JsonData, not dynamic, so the DMO callback is never called
            // and the explicit cast to int is not visible b/c JsonData is internal.
            //IEnumerable value = (IEnumerable)data;

            //int i = 1;
            //foreach (int item in value)
            //{
            //    Assert.AreEqual(i++, (int)item);
            //}

            int i = 1;
            foreach (int item in data)
            {
                Assert.AreEqual(i++, item);
            }
        }

        [Test]
        public void CanConvertArrayToArray()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("[1, 2, 3]");

            int[] array = data;

            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[1]);
            Assert.AreEqual(3, array[2]);
        }

        [Test]
        public void CannotConvertArrayToLeaf()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("[1, 2, 3]");

            Assert.Throws<InvalidCastException>(() => { var model = (int)data; });
            Assert.Throws<InvalidCastException>(() => { var model = (bool)data; });
            Assert.Throws<InvalidCastException>(() => { var model = (string)data; });
            Assert.Throws<InvalidCastException>(() => { var model = (DateTime)data; });
        }

        [Test]
        [Ignore("Disallowing POCO support in current version.")]
        public void CannotConvertArrayToModel()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("[1, 2, 3]");
            Assert.Throws<InvalidCastException>(() => { var model = (SampleModel)data; });
        }

        [Test]
        public void CannotConvertArrayPropertyToLeaf()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "value": [1, 2, 3] }""");

            Assert.Throws<InvalidCastException>(() => { var model = (int)data.value; });
            Assert.Throws<InvalidCastException>(() => { var model = (bool)data.value; });
            Assert.Throws<InvalidCastException>(() => { var model = (string)data.value; });
            Assert.Throws<InvalidCastException>(() => { var model = (double)data.value; });
            Assert.Throws<InvalidCastException>(() => { var model = (DateTime)data.value; });
        }

        [Test]
        [Ignore("Disallowing POCO support in current version.")]
        public void CannotConvertArrayPropertyToModel()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "value": [1, 2, 3] }""");
            Assert.Throws<InvalidCastException>(() => { var model = (SampleModel)data.value; });
        }

        #endregion

        #region GetMember tests

        [Test]
        public void CannotGetMemberOnArray()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("[1, 2, 3]");
            Assert.Throws<InvalidOperationException>(() => { var x = data.Property; });
        }

        [Test]
        public void CannotGetMemberOnArrayProperty()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "value": [1, 2, 3] }""");
            Assert.Throws<InvalidOperationException>(() => { var x = data.value.Property; });
        }

        #endregion

        #region SetMember tests

        [Test]
        public void CannotSetMemberOnArray()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("[1, 2, 3]");
            Assert.Throws<InvalidOperationException>(() => { data.Property = "invalid"; });
        }

        [Test]
        public void CannotSetMemberOnArrayProperty()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "value": [1, 2, 3] }""");
            Assert.Throws<InvalidOperationException>(() => { data.value.Property = "invalid"; });
        }

        #endregion

        #region GetIndex tests

        [Test]
        public void CannotGetIndexPropertyOnArray()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("[1, 2, 3]");
            Assert.Throws<InvalidOperationException>(() => { var x = data["Property"]; });
        }

        [Test]
        public void CannotGetIndexPropertyOnArrayProperty()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "value": [1, 2, 3] }""");
            Assert.Throws<InvalidOperationException>(() => { var x = data.value["Property"]; });
        }

        [Test]
        public void CanGetArrayIndex()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("[1, 2, 3]");

            Assert.AreEqual(1, (int)data[0]);
            Assert.AreEqual(2, (int)data[1]);
            Assert.AreEqual(3, (int)data[2]);
        }

        [Test]
        public void CanGetArrayPropertyIndex()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "value": [1, 2, 3] }""");

            Assert.AreEqual(1, (int)data.value[0]);
            Assert.AreEqual(2, (int)data.value[1]);
            Assert.AreEqual(3, (int)data.value[2]);
        }

        [Test]
        public void CanGetObjectMemberViaArrayIndex()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(
                """{ "value": [ { "tag": "tagValue" }, 2, 3] }"""
            );

            Assert.AreEqual("tagValue", (string)data.value[0].tag);
        }

        #endregion

        #region SetIndex tests

        [Test]
        public void CannotSetIndexPropertyOnArray()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("[1, 2, 3]");
            Assert.Throws<InvalidOperationException>(() => { data["Property"] = "invalid"; });
        }

        [Test]
        public void CannotSetIndexPropertyOnArrayProperty()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "value": [1, 2, 3] }""");
            Assert.Throws<InvalidOperationException>(() => { data.value["Property"] = "invalid"; });
        }

        [Test]
        public void CanSetArrayIndex()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("[1, 2, 3]");

            data[0] = 5;
            data[1] = "valid";
            data[2] = null;

            Assert.AreEqual(5, (int)data[0]);
            Assert.AreEqual("valid", (string)data[1]);
            Assert.IsTrue(data[2] == null);
            Assert.AreEqual(null, data[2]);
        }

        [Test]
        public void CanSetArrayPropertyIndex()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "value": [1, 2, 3] }""");

            data.value[0] = 5;
            data.value[1] = "valid";
            data.value[2] = null;

            Assert.AreEqual(5, (int)data.value[0]);
            Assert.IsTrue(5 == data.value[0]);
            Assert.AreEqual("valid", (string)data.value[1]);
            Assert.IsTrue(data.value[2] == null);
        }

        [Test]
        public void CanSetObjectMemberViaArrayIndex()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(
                """{ "value": [ { "tag": "tagValue" }, 2, 3] }"""
            );

            data.value[0].tag = "newValue";

            Assert.AreEqual("newValue", (string)data.value[0].tag);
        }

        #endregion

        #region Array behaviors tests

        [Test]
        public void CanGetArrayLength()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("[1, 2, 3]");
            Assert.AreEqual(3, data.Length);
        }

        [Test]
        public void CanGetArrayLengthWithChanges()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("[1, 2, 3]");

            data[0] = 4;
            data[1] = BinaryData.FromString("""{ "foo": 1 }""").ToDynamicFromJson();

            Assert.AreEqual(3, data.Length);
        }

        [Test]
        public void CanGetArrayPropertyLength()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "value": [1, 2, 3] }""");
            Assert.AreEqual(3, data.value.Length);
        }

        [Test]
        public void CanGetArrayPropertyLengthWithChanges()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "value": [1, 2, 3] }""");

            data.value[0] = 4;
            data.value[1] = BinaryData.FromString("""{ "foo": 1 }""").ToDynamicFromJson();

            Assert.AreEqual(3, data.value.Length);

            data.value = new int[] { 1, 2 };

            Assert.AreEqual(2, data.value.Length);

            data.value = BinaryData.FromString("""[1, 2, 3, 4]""").ToDynamicFromJson();

            Assert.AreEqual(4, data.value.Length);

            // Switch JsonKind
            data = BinaryData.FromString("""{ "foo": 1 }""").ToDynamicFromJson();
            data.foo = new int[] { 1, 2 };

            Assert.AreEqual(2, data.foo.Length);
        }

        [Test]
        public void CanEnumerateArray()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("[1, 2, 3]");

            int i = 1;
            foreach (int item in data)
            {
                Assert.AreEqual(i++, item);
            }
        }

        [Test]
        public void CanEnumerateArrayProperty()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("""{ "value": [1, 2, 3] }""");

            int i = 1;
            foreach (int item in data.value)
            {
                Assert.AreEqual(i++, item);
            }
        }

        #endregion
    }
}
