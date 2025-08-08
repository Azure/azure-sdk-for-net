// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.IO;
using System.Text;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    internal class AdditionalPropertiesTests
    {
        [Test]
        public void AddPrimitive_String()
        {
            AdditionalProperties ap = new();
            ap.Set("$.property"u8, "value");
            Assert.IsTrue(ap.Contains("$.property"u8));
            Assert.AreEqual("value", ap.GetString("$.property"u8));

            using var stream = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            ap.Write(writer);
            writer.Flush();

            Assert.AreEqual("{\"property\":\"value\"}", GetJsonString(stream));
        }

        [Test]
        public void AddRootArray_String()
        {
            AdditionalProperties ap = new();
            ap.Set("$[-]"u8, "value");
            Assert.IsTrue(ap.Contains("$[-]"u8));
            Assert.AreEqual("[\"value\"]"u8.ToArray(), ap.GetJson("$[-]"u8).ToArray());
            Assert.AreEqual("value", ap.GetString("$[0]"u8));

            using var stream = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            ap.Write(writer);
            writer.Flush();

            Assert.AreEqual("[\"value\"]", GetJsonString(stream));
        }

        [Test]
        [Ignore("WIP")]
        public void AddRootArray_Property_String()
        {
            AdditionalProperties ap = new();
            //should I be able to project that there is an array, it has 1 item and that item has a property?
            //perhaps propagate to _properties on Set like we propagate to the model?
            ap.Set("$[0].property"u8, "value");
            Assert.IsTrue(ap.Contains("$[0].property"u8));
            // wont' exist because the array and object in that array are projected
            //Assert.AreEqual("[{\"property\":\"value\"}]"u8.ToArray(), ap.GetJson("$"u8).ToArray());
            //Assert.AreEqual("{\"property\":\"value\"}"u8.ToArray(), ap.GetJson("$[0]"u8).ToArray());
            Assert.AreEqual("value", ap.GetString("$[0].property"u8));

            using var stream = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            ap.Write(writer);
            writer.Flush();

            Assert.AreEqual("[{\"property\":\"value\"}]", GetJsonString(stream));
        }

        private static string GetJsonString(MemoryStream stream)
        {
            return Encoding.UTF8.GetString(stream.GetBuffer().AsSpan().Slice(0, (int)stream.Position).ToArray());
        }
    }
}
