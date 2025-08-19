// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.IO;
using System.Text;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    internal class JsonPatchTests
    {
        [Test]
        public void AddPrimitive_String()
        {
            JsonPatch jp = new();
            jp.Set("$.property"u8, "value");
            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.AreEqual("value", jp.GetString("$.property"u8));

            using var stream = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            jp.Write(writer);
            writer.Flush();

            Assert.AreEqual("{\"property\":\"value\"}", GetJsonString(stream));
        }

        [Test]
        public void AddPrimitive_StringAndInt()
        {
            JsonPatch jp = new();
            jp.Set("$.property"u8, "value");
            jp.Set("$.property2"u8, 10);
            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.AreEqual("value", jp.GetString("$.property"u8));
            Assert.AreEqual(10, jp.GetInt32("$.property2"u8));

            using var stream = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            jp.Write(writer);
            writer.Flush();

            Assert.AreEqual("{\"property\":\"value\",\"property2\":10}", GetJsonString(stream));
        }

        [Test]
        public void AddRootArray_String()
        {
            JsonPatch jp = new();
            jp.Set("$[-]"u8, "value");
            Assert.IsTrue(jp.Contains("$[-]"u8));
            Assert.AreEqual("[\"value\"]"u8.ToArray(), jp.GetJson("$[-]"u8).ToArray());
            Assert.AreEqual("value", jp.GetString("$[0]"u8));

            using var stream = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            jp.Write(writer);
            writer.Flush();

            Assert.AreEqual("[\"value\"]", GetJsonString(stream));
        }

        [Test]
        public void AddRootArray_Property_String()
        {
            JsonPatch jp = new();
            jp.Set("$[0].property"u8, "value");

            Assert.IsTrue(jp.Contains("$[-]"u8));
            Assert.AreEqual("[{\"property\":\"value\"}]"u8.ToArray(), jp.GetJson("$[-]"u8).ToArray());
            Assert.AreEqual("{\"property\":\"value\"}"u8.ToArray(), jp.GetJson("$[0]"u8).ToArray());
            Assert.AreEqual("value", jp.GetString("$[0].property"u8));

            using var stream = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            jp.Write(writer);
            writer.Flush();

            Assert.AreEqual("[{\"property\":\"value\"}]", GetJsonString(stream));
        }

        [Test]
        [Ignore("Not implemented")]
        public void TryGetJson_RemovedProperty_EntryExists()
        {
        }

        [Test]
        [Ignore("Not implemented")]
        public void TryGetJson_RemovedProperty_EntryDoesNotExist()
        {
        }

        [Test]
        public void AddPropertyNameWithDot()
        {
            JsonPatch jp = new();
            jp.Set("$['pro.perty']"u8, "value");
            Assert.IsTrue(jp.Contains("$['pro.perty']"u8));
            Assert.AreEqual("value", jp.GetString("$['pro.perty']"u8));

            using var stream = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            jp.Write(writer);
            writer.Flush();

            Assert.AreEqual("{\"pro.perty\":\"value\"}", GetJsonString(stream));
        }

        private static string GetJsonString(MemoryStream stream)
        {
            return Encoding.UTF8.GetString(stream.GetBuffer().AsSpan().Slice(0, (int)stream.Position).ToArray());
        }
    }
}
