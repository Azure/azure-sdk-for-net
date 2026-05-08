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
            Assert.That(SchemaFormat.Avro.ToString(), Is.EqualTo("Avro"));
        }

        [Test]
        public void VerifyJsonFormat()
        {
            Assert.That(SchemaFormat.Json.ToString(), Is.EqualTo("JSON"));
        }

        [Test]
        public void VerifyCustomFormat()
        {
            Assert.That(SchemaFormat.Custom.ToString(), Is.EqualTo("Custom"));
        }

        [Test]
        public void VerifyDefault()
        {
            Assert.That((new SchemaFormat("MyValue")).ToString(), Is.EqualTo("MyValue"));
        }

        //[Test]
        //public void VerifyProtobufFormat()
        //{
        //    Assert.AreEqual("Protobuf", SchemaFormat.Protobuf.ToString());
        //}

        [Test]
        public void VerifyAvroToContentType()
        {
            Assert.That(SchemaFormat.Avro.ContentType, Is.EqualTo(AvroContentType));
        }

        [Test]
        public void VerifyJsonToContentType()
        {
            Assert.That(SchemaFormat.Json.ContentType, Is.EqualTo(JsonContentType));
        }

        [Test]
        public void VerifyCustomToContentType()
        {
            Assert.That(SchemaFormat.Custom.ContentType, Is.EqualTo(CustomContentType));
        }

        [Test]
        public void VerifyDefaultToContentType()
        {
            Assert.That((new SchemaFormat("MyValue")).ContentType, Is.EqualTo("application/json; serialization=MyValue"));
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
            Assert.That(fromContentType, Is.EqualTo(SchemaFormat.Avro));
        }

        [Test]
        public void VerifyJsonFromContentType()
        {
            var fromContentType = SchemaFormat.FromContentType(JsonContentType);
            Assert.That(fromContentType, Is.EqualTo(SchemaFormat.Json));
        }

        [Test]
        public void VerifyCustomFromContentType()
        {
            var fromContentType = SchemaFormat.FromContentType(CustomContentType);
            Assert.That(fromContentType, Is.EqualTo(SchemaFormat.Custom));
        }

        [Test]
        public void VerifyDefaultFromContentType()
        {
            var fromContentType = SchemaFormat.FromContentType("MyValue");
            Assert.That(fromContentType, Is.EqualTo(new SchemaFormat("MyValue")));
        }

        //[Test]
        //public void VerifyProtobufFromContentType()
        //{
        //    var fromContentType = SchemaFormat.FromContentType("text/vnd.ms.protobuf");
        //    Assert.AreEqual(SchemaFormat.Protobuf, fromContentType);
        //}
    }
}
