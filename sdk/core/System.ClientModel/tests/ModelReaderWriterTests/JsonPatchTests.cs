// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    internal class JsonPatchTests
    {
        [Test]
        public void AddPrimitive_StringAndInt()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "value");
            jp.Set("$.property2"u8, 10);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.AreEqual("value", jp.GetString("$.property"u8));
            Assert.AreEqual(10, jp.GetInt32("$.property2"u8));

            Assert.AreEqual("{\"property\":\"value\",\"property2\":10}", GetJsonString(jp));
        }

        [Test]
        public void AddRootArray_String()
        {
            JsonPatch jp = new();

            jp.Append("$"u8, "value");

            Assert.AreEqual("[\"value\"]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("value", jp.GetString("$[0]"u8));

            Assert.AreEqual("[\"value\"]", GetJsonString(jp));
        }

        [Test]
        public void AddRootArray_Property_String()
        {
            JsonPatch jp = new();

            jp.Set("$[0].property"u8, "value");

            Assert.AreEqual("[{\"property\":\"value\"}]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("{\"property\":\"value\"}", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value", jp.GetString("$[0].property"u8));

            Assert.AreEqual("[{\"property\":\"value\"}]", GetJsonString(jp));
        }

        [Test]
        public void TryGetJson_RemovedProperty_EntryExists()
        {
            JsonPatch jp = new();

            jp.Set("$[0].property1"u8, "value1");
            jp.Set("$[0].property2"u8, "value2");

            Assert.AreEqual("[{\"property1\":\"value1\",\"property2\":\"value2\"}]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("{\"property1\":\"value1\",\"property2\":\"value2\"}", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0].property1"u8));
            Assert.AreEqual("value2", jp.GetString("$[0].property2"u8));

            Assert.AreEqual("[{\"property1\":\"value1\",\"property2\":\"value2\"}]", GetJsonString(jp));

            jp.Remove("$[0].property1"u8);

            Assert.AreEqual("[{\"property2\":\"value2\"}]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("{\"property2\":\"value2\"}", jp.GetJson("$[0]"u8).ToString());
            var ex = Assert.Throws<Exception>(() => jp.GetString("$[0].property1"u8));
            Assert.AreEqual("$[0].property1 was not found in the JSON structure.", ex!.Message);
            Assert.AreEqual("value2", jp.GetString("$[0].property2"u8));

            Assert.AreEqual("[{\"property2\":\"value2\"}]", GetJsonString(jp));
        }

        [Test]
        public void TryGetJson_RemovedProperty_EntryDoesNotExist()
        {
            JsonPatch jp = new();
            jp.Set("$[0].property1"u8, "value1");
            jp.Set("$[0].property2"u8, "value2");

            Assert.AreEqual("[{\"property1\":\"value1\",\"property2\":\"value2\"}]", jp.GetJson("$"u8).ToString());
            Assert.AreEqual("{\"property1\":\"value1\",\"property2\":\"value2\"}", jp.GetJson("$[0]"u8).ToString());
            Assert.AreEqual("value1", jp.GetString("$[0].property1"u8));
            Assert.AreEqual("value2", jp.GetString("$[0].property2"u8));

            Assert.AreEqual("[{\"property1\":\"value1\",\"property2\":\"value2\"}]", GetJsonString(jp));

            var ex = Assert.Throws<Exception>(() => jp.Remove("$[0].property3"u8));
            Assert.AreEqual("$[0].property3 was not found in the JSON structure.", ex!.Message);
        }

        [Test]
        public void ProjectMultipleJsons()
        {
            JsonPatch jp = new();
            jp.Set("$.x.y[2]['z']"u8, 5);

            Assert.AreEqual("{\"y\":[null,null,{\"z\":5}]}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[null,null,{\"z\":5}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("null", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("null", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"z\":5}", jp.GetJson("$.x.y[2]"u8).ToString());
            Assert.AreEqual(5, jp.GetInt32("$.x.y[2]['z']"u8));

            Assert.AreEqual("{\"x\":{\"y\":[null,null,{\"z\":5}]}}", GetJsonString(jp));

            jp.Set("$.x.z.a[0].b"u8, 10);

            Assert.AreEqual("{\"y\":[null,null,{\"z\":5}],\"z\":{\"a\":[{\"b\":10}]}}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("[null,null,{\"z\":5}]", jp.GetJson("$.x.y"u8).ToString());
            Assert.AreEqual("null", jp.GetJson("$.x.y[0]"u8).ToString());
            Assert.AreEqual("null", jp.GetJson("$.x.y[1]"u8).ToString());
            Assert.AreEqual("{\"z\":5}", jp.GetJson("$.x.y[2]"u8).ToString());
            Assert.AreEqual(5, jp.GetInt32("$.x.y[2]['z']"u8));
            Assert.AreEqual("{\"a\":[{\"b\":10}]}", jp.GetJson("$.x.z"u8).ToString());
            Assert.AreEqual("[{\"b\":10}]", jp.GetJson("$.x.z.a"u8).ToString());
            Assert.AreEqual("{\"b\":10}", jp.GetJson("$.x.z.a[0]"u8).ToString());
            Assert.AreEqual(10, jp.GetInt32("$.x.z.a[0].b"u8));

            Assert.AreEqual("{\"x\":{\"y\":[null,null,{\"z\":5}],\"z\":{\"a\":[{\"b\":10}]}}}", GetJsonString(jp));
        }

        [Test]
        public void AddPropertyNameWithDot()
        {
            JsonPatch jp = new();
            jp.Set("$['pro.perty']"u8, "value");
            Assert.IsTrue(jp.Contains("$['pro.perty']"u8));
            Assert.AreEqual("value", jp.GetString("$['pro.perty']"u8));

            Assert.AreEqual("{\"pro.perty\":\"value\"}", GetJsonString(jp));
        }

        public static string GetJsonString(JsonPatch patch)
        {
            using var stream = new MemoryStream();
            JsonWriterOptions options = new();
            // this stops it from escaping things like + int \u002B to make the expected strings nice to read.
            options.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            Utf8JsonWriter writer = new Utf8JsonWriter(stream, options);
            patch.Write(writer);
            writer.Flush();
            return Encoding.UTF8.GetString(stream.GetBuffer().AsSpan().Slice(0, (int)stream.Position).ToArray());
        }
    }
}
