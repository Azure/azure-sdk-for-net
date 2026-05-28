// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Data.SchemaRegistry.Tests
{
    public class SchemaFormatTests
    {
        private const string AvroContentType = "application/json; serialization=Avro";
        private const string JsonContentType = "application/json; serialization=Json";
        private const string CustomContentType = "text/plain; charset=utf-8";
        private const string ProtobufContentType = "text/vnd.ms.protobuf";

        [Test]
        public void VerifyAvroFormat()
        {
            Assert.AreEqual("Avro", SchemaFormat.Avro.ToString());
        }

        [Test]
        public void VerifyJsonFormat()
        {
            Assert.AreEqual("JSON", SchemaFormat.Json.ToString());
        }

        [Test]
        public void VerifyCustomFormat()
        {
            Assert.AreEqual("Custom", SchemaFormat.Custom.ToString());
        }

        [Test]
        public void VerifyDefault()
        {
            Assert.AreEqual("MyValue", (new SchemaFormat("MyValue")).ToString());
        }

        //[Test]
        //public void VerifyProtobufFormat()
        //{
        //    Assert.AreEqual("Protobuf", SchemaFormat.Protobuf.ToString());
        //}

        [Test]
        public void VerifyAvroToContentType()
        {
            Assert.AreEqual(AvroContentType, SchemaFormat.Avro.ContentType);
        }

        [Test]
        public void VerifyJsonToContentType()
        {
            Assert.AreEqual(JsonContentType, SchemaFormat.Json.ContentType);
        }

        [Test]
        public void VerifyCustomToContentType()
        {
            Assert.AreEqual(CustomContentType, SchemaFormat.Custom.ContentType);
        }

        [Test]
        public void VerifyDefaultToContentType()
        {
            Assert.AreEqual("application/json; serialization=MyValue", (new SchemaFormat("MyValue")).ContentType);
        }

        //[Test]
        //public void VerifyProtobufToContentType()
        //{
        //    Assert.AreEqual(ContentType.Protobuf, SchemaFormat.Protobuf.ToContentType());
        //}

        [Test]
        public void VerifyAvroFromContentType()
        {
            var fromContentType = SchemaFormat.FromContentType(AvroContentType);
            Assert.AreEqual(SchemaFormat.Avro, fromContentType);
        }

        [Test]
        public void VerifyJsonFromContentType()
        {
            var fromContentType = SchemaFormat.FromContentType(JsonContentType);
            Assert.AreEqual(SchemaFormat.Json, fromContentType);
        }

        [Test]
        public void VerifyCustomFromContentType()
        {
            var fromContentType = SchemaFormat.FromContentType(CustomContentType);
            Assert.AreEqual(SchemaFormat.Custom, fromContentType);
        }

        [Test]
        public void VerifyDefaultFromContentType()
        {
            var fromContentType = SchemaFormat.FromContentType("MyValue");
            Assert.AreEqual(new SchemaFormat("MyValue"), fromContentType);
        }

        //[Test]
        //public void VerifyProtobufFromContentType()
        //{
        //    var fromContentType = SchemaFormat.FromContentType("text/vnd.ms.protobuf");
        //    Assert.AreEqual(SchemaFormat.Protobuf, fromContentType);
        //}
    }
}
