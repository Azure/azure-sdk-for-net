// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Data.SchemaRegistry.Tests
{
    public class SchemaFormatTests
    {
        private const string _jsonContentType = "application/json; serialization=Json";
        private const string _avroContentType = "application/json; serialization=Avro";
        private const string _customContentType = "text/plain; charset=utf-8";

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

        //[Test]
        //public void VerifyProtobufFormat()
        //{
        //    Assert.AreEqual("Protobuf", SchemaFormat.Protobuf.ToString());
        //}

        [Test]
        public void VerifyAvroToContentType()
        {
            Assert.AreEqual(_avroContentType, SchemaFormat.Avro.ToContentType());
        }

        [Test]
        public void VerifyJsonToContentType()
        {
            Assert.AreEqual(_jsonContentType, SchemaFormat.Json.ToContentType());
        }

        [Test]
        public void VerifyCustomToContentType()
        {
            Assert.AreEqual(_customContentType, SchemaFormat.Custom.ToContentType());
        }

        [Test]
        public void VerifyDefaultToContentType()
        {
            Assert.AreEqual("MyContent", new SchemaFormat("MyContent").ToContentType());
        }

        //[Test]
        //public void VerifyProtobufToContentType()
        //{
        //    Assert.AreEqual("text/vnd.ms.protobuf", SchemaFormat.Protobuf.ToContentType());
        //}

        [Test]
        public void VerifyAvroFromContentType()
        {
            var fromContentType = SchemaFormat.FromContentType(_avroContentType);
            Assert.AreEqual(SchemaFormat.Avro, fromContentType);
        }

        [Test]
        public void VerifyJsonFromContentType()
        {
            var fromContentType = SchemaFormat.FromContentType(_jsonContentType);
            Assert.AreEqual(SchemaFormat.Json, fromContentType);
        }

        [Test]
        public void VerifyCustomFromContentType()
        {
            var fromContentType = SchemaFormat.FromContentType(_customContentType);
            Assert.AreEqual(SchemaFormat.Custom, fromContentType);
        }

        [Test]
        public void VerifyDefaultFromContentType()
        {
            var fromContentType = SchemaFormat.FromContentType("MyContentType");
            Assert.AreEqual(new SchemaFormat("MyContentType"), fromContentType);
        }

        //[Test]
        //public void VerifyProtobufFromContentType()
        //{
        //    var fromContentType = SchemaFormat.FromContentType("text/vnd.ms.protobuf");
        //    Assert.AreEqual(SchemaFormat.Protobuf, fromContentType);
        //}
    }
}
