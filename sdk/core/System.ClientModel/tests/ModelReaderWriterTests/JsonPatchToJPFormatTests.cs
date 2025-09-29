// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    internal class JsonPatchToJPFormatTests
    {
        [Test]
        public void Add_Primitive()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "value");

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual("[{\"op\":\"add\",\"path\":\"/property\",\"value\":\"value\"}]", jp.ToString());
        }

        [Test]
        public void Add_Multiple()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "value");
            jp.Set("$.x.y.property2"u8, "value");

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual("[{\"op\":\"add\",\"path\":\"/property\",\"value\":\"value\"},{\"op\":\"add\",\"path\":\"/x\",\"value\":{\"y\":{\"property2\":\"value\"}}}]", jp.ToString());
        }

        [Test]
        public void Add_AppendToArray()
        {
            JsonPatch jp = new();

            jp.Append("$"u8, "value");

            Assert.AreEqual("[{\"op\":\"add\",\"path\":\"/-\",\"value\":\"value\"}]", jp.ToString());
        }

        [Test]
        public void Add_IndexedArrayItem()
        {
            JsonPatch jp = new();

            jp.Set("$.x[0].y"u8, "value");

            Assert.AreEqual("[{\"op\":\"add\",\"path\":\"/x\",\"value\":[{\"y\":\"value\"}]}]", jp.ToString());
        }

        [Test]
        public void Add_AppendToIndexedArrayItem()
        {
            JsonPatch jp = new();

            jp.Append("$.x[0].y"u8, "value");

            Assert.AreEqual("[{\"op\":\"add\",\"path\":\"/x\",\"value\":[{\"y\":[\"value\"]}]}]", jp.ToString());
        }

        [Test]
        public void Replace_Primitive()
        {
            JsonPatch jp = new("{\"property\":\"value\"}"u8.ToArray());

            jp.Set("$.property"u8, "value2");

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual("[{\"op\":\"replace\",\"path\":\"/property\",\"value\":\"value2\"}]", jp.ToString());
        }

        [Test]
        public void Replace_Multiple()
        {
            JsonPatch jp = new("{\"property\":\"value\",\"x\":{\"y\":{\"property2\":\"value\"}}}"u8.ToArray());

            jp.Set("$.property"u8, "value2");
            jp.Set("$.x.y.property2"u8, "value2");

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual("[{\"op\":\"replace\",\"path\":\"/property\",\"value\":\"value2\"},{\"op\":\"replace\",\"path\":\"/x/y/property2\",\"value\":\"value2\"}]", jp.ToString());
        }

        [Test]
        public void Replace_IndexedArrayItem()
        {
            JsonPatch jp = new("{\"x\":[{\"y\":\"value\"}]}"u8.ToArray());

            jp.Set("$.x[0].y"u8, "value2");

            Assert.AreEqual("[{\"op\":\"replace\",\"path\":\"/x/0/y\",\"value\":\"value2\"}]", jp.ToString());
        }

        [Test]
        public void SetValueButNoChange()
        {
            JsonPatch jp = new("{\"x\":[{\"y\":\"value\"}]}"u8.ToArray());

            jp.Set("$.x[0].y"u8, "value");

            Assert.AreEqual("[]", jp.ToString());
        }

        [Test]
        public void JsonPatch_ToString_JP_PathEscaping()
        {
            JsonPatch jp = new();

            jp.Set("$['a~b/c']"u8, "v");

            Assert.AreEqual("[{\"op\":\"add\",\"path\":\"/a~0b~1c\",\"value\":\"v\"}]", jp.ToString());
        }

        [Test]
        public void JsonPatch_ToString_JP_ArrayAppendRoot()
        {
            JsonPatch jp = new();

            jp.Append("$"u8, 5);

            Assert.AreEqual("[{\"op\":\"add\",\"path\":\"/-\",\"value\":5}]", jp.ToString());
        }

        [Test]
        public void Remove_Primitive()
        {
            JsonPatch jp = new("{\"property\":\"value\"}"u8.ToArray());

            jp.Remove("$.property"u8);

            Assert.AreEqual("[{\"op\":\"remove\",\"path\":\"/property\"}]", jp.ToString());
        }

        [Test]
        public void Remove_IndexedArrayItem()
        {
            JsonPatch jp = new("{\"x\":[{\"y\":\"value\"}]}"u8.ToArray());

            jp.Remove("$.x[0]"u8);

            Assert.AreEqual("[{\"op\":\"remove\",\"path\":\"/x/0\"}]", jp.ToString());
        }

        [Test]
        public void Remove_IndexedArrayItem_Property()
        {
            JsonPatch jp = new("{\"x\":[{\"y\":\"value\"}]}"u8.ToArray());

            jp.Remove("$.x[0].y"u8);

            Assert.AreEqual("[{\"op\":\"remove\",\"path\":\"/x/0/y\"}]", jp.ToString());
        }
    }
}
