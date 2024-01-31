// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Data.SchemaRegistry.Tests
{
    public class SchemaFormatTests
    {
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
        public void VerifyProtobufFormat()
        {
            Assert.AreEqual("Protobuf", SchemaFormat.Protobuf.ToString());
        }

        [Test]
        public void VerifyAvroToContentType()
        {
            Assert.AreEqual(ContentType.Avro, SchemaFormat.Avro.ToContentType());
        }

        [Test]
        public void VerifyJsonToContentType()
        {
            Assert.AreEqual(ContentType.Json, SchemaFormat.Json.ToContentType());
        }

        [Test]
        public void VerifyCustomToContentType()
        {
            Assert.AreEqual(ContentType.Custom, SchemaFormat.Custom.ToContentType());
        }

        [Test]
        public void VerifyProtobufToContentType()
        {
            Assert.AreEqual(ContentType.Protobuf, SchemaFormat.Protobuf.ToContentType());
        }

        [Test]
        public void VerifyAvroFromContentType()
        {
            var fromContentType = SchemaFormat.FromContentType("application/json; serialization=Avro");
            Assert.AreEqual(SchemaFormat.Avro, fromContentType);
        }

        [Test]
        public void VerifyJsonFromContentType()
        {
            var fromContentType = SchemaFormat.FromContentType("application/json; serialization=Json");
            Assert.AreEqual(SchemaFormat.Json, fromContentType);
        }

        [Test]
        public void VerifyCustomFromContentType()
        {
            var fromContentType = SchemaFormat.FromContentType("text/plain; charset=utf-8");
            Assert.AreEqual(SchemaFormat.Custom, fromContentType);
        }

        [Test]
        public void VerifyProtobufFromContentType()
        {
            var fromContentType = SchemaFormat.FromContentType("text/vnd.ms.protobuf");
            Assert.AreEqual(SchemaFormat.Protobuf, fromContentType);
        }
    }
}
