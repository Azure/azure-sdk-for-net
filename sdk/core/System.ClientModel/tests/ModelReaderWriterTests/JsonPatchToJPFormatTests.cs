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

            Assert.That(jp.Contains("$.property"u8), Is.True);

            Assert.That(jp.ToString(), Is.EqualTo("[{\"op\":\"add\",\"path\":\"/property\",\"value\":\"value\"}]"));
        }

        [Test]
        public void Add_Multiple()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "value");
            jp.Set("$.x.y.property2"u8, "value");

            Assert.That(jp.Contains("$.property"u8), Is.True);

            Assert.That(jp.ToString(), Is.EqualTo("[{\"op\":\"add\",\"path\":\"/property\",\"value\":\"value\"},{\"op\":\"add\",\"path\":\"/x\",\"value\":{\"y\":{\"property2\":\"value\"}}}]"));
        }

        [Test]
        public void Add_AppendToArray()
        {
            JsonPatch jp = new();

            jp.Append("$"u8, "value");

            Assert.That(jp.ToString(), Is.EqualTo("[{\"op\":\"add\",\"path\":\"/-\",\"value\":\"value\"}]"));
        }

        [Test]
        public void Add_IndexedArrayItem()
        {
            JsonPatch jp = new();

            jp.Set("$.x[0].y"u8, "value");

            Assert.That(jp.ToString(), Is.EqualTo("[{\"op\":\"add\",\"path\":\"/x\",\"value\":[{\"y\":\"value\"}]}]"));
        }

        [Test]
        public void Add_AppendToIndexedArrayItem()
        {
            JsonPatch jp = new();

            jp.Append("$.x[0].y"u8, "value");

            Assert.That(jp.ToString(), Is.EqualTo("[{\"op\":\"add\",\"path\":\"/x\",\"value\":[{\"y\":[\"value\"]}]}]"));
        }

        [Test]
        public void Replace_Primitive()
        {
            JsonPatch jp = new("{\"property\":\"value\"}"u8.ToArray());

            jp.Set("$.property"u8, "value2");

            Assert.That(jp.Contains("$.property"u8), Is.True);

            Assert.That(jp.ToString(), Is.EqualTo("[{\"op\":\"replace\",\"path\":\"/property\",\"value\":\"value2\"}]"));
        }

        [Test]
        public void Replace_Multiple()
        {
            JsonPatch jp = new("{\"property\":\"value\",\"x\":{\"y\":{\"property2\":\"value\"}}}"u8.ToArray());

            jp.Set("$.property"u8, "value2");
            jp.Set("$.x.y.property2"u8, "value2");

            Assert.That(jp.Contains("$.property"u8), Is.True);

            Assert.That(jp.ToString(), Is.EqualTo("[{\"op\":\"replace\",\"path\":\"/property\",\"value\":\"value2\"},{\"op\":\"replace\",\"path\":\"/x/y/property2\",\"value\":\"value2\"}]"));
        }

        [Test]
        public void Replace_IndexedArrayItem()
        {
            JsonPatch jp = new("{\"x\":[{\"y\":\"value\"}]}"u8.ToArray());

            jp.Set("$.x[0].y"u8, "value2");

            Assert.That(jp.ToString(), Is.EqualTo("[{\"op\":\"replace\",\"path\":\"/x/0/y\",\"value\":\"value2\"}]"));
        }

        [Test]
        public void SetValueButNoChange()
        {
            JsonPatch jp = new("{\"x\":[{\"y\":\"value\"}]}"u8.ToArray());

            jp.Set("$.x[0].y"u8, "value");

            Assert.That(jp.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void JsonPatch_ToString_JP_PathEscaping()
        {
            JsonPatch jp = new();

            jp.Set("$['a~b/c']"u8, "v");

            Assert.That(jp.ToString(), Is.EqualTo("[{\"op\":\"add\",\"path\":\"/a~0b~1c\",\"value\":\"v\"}]"));
        }

        [Test]
        public void JsonPatch_ToString_JP_ArrayAppendRoot()
        {
            JsonPatch jp = new();

            jp.Append("$"u8, 5);

            Assert.That(jp.ToString(), Is.EqualTo("[{\"op\":\"add\",\"path\":\"/-\",\"value\":5}]"));
        }

        [Test]
        public void Remove_Primitive()
        {
            JsonPatch jp = new("{\"property\":\"value\"}"u8.ToArray());

            jp.Remove("$.property"u8);

            Assert.That(jp.ToString(), Is.EqualTo("[{\"op\":\"remove\",\"path\":\"/property\"}]"));
        }

        [Test]
        public void Remove_IndexedArrayItem()
        {
            JsonPatch jp = new("{\"x\":[{\"y\":\"value\"}]}"u8.ToArray());

            jp.Remove("$.x[0]"u8);

            Assert.That(jp.ToString(), Is.EqualTo("[{\"op\":\"remove\",\"path\":\"/x/0\"}]"));
        }

        [Test]
        public void Remove_IndexedArrayItem_Property()
        {
            JsonPatch jp = new("{\"x\":[{\"y\":\"value\"}]}"u8.ToArray());

            jp.Remove("$.x[0].y"u8);

            Assert.That(jp.ToString(), Is.EqualTo("[{\"op\":\"remove\",\"path\":\"/x/0/y\"}]"));
        }
    }
}
