// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using Azure.Data.SchemaRegistry.Serialization;
using Moq;
using NUnit.Framework;
using TestSchema;

namespace Azure.Data.SchemaRegistry.Tests.Serialization
{
    public class SchemaRegistrySerializerTests
    {
        private static readonly string s_schema = "{\r\n  \"$schema\": \"http://json-schema.org/draft-04/schema#\",\r\n  \"title\": \"Employee\",\r\n  \"type\": \"object\",\r\n  \"additionalProperties\": false,\r\n  \"properties\": {\r\n    \"Age\": {\r\n      \"type\": \"integer\",\r\n      \"format\": \"int32\"\r\n    },\r\n    \"Name\": {\r\n      \"type\": [\r\n        \"null\",\r\n        \"string\"\r\n      ]\r\n    }\r\n  }\r\n}";
        private static readonly string s_customSchema = "Employee: { Age = int, Name = string }";
        private static readonly string s_avroschema = "{\"type\" : \"record\",\"namespace\" : \"TestSchema\",\"name\" : \"Employee\",\"fields\" : [{ \"name\" : \"Name\" , \"type\" : \"string\" },{ \"name\" : \"Age\", \"type\" : \"int\" }]}";

        [Test]
        public async Task SerializeWorks()
        {
            var mockClient = new Mock<SchemaRegistryClient>();
            mockClient
                .Setup(
                    client => client.GetSchemaPropertiesAsync(
                    "groupName",
                    nameof(Employee),
                    s_schema,
                    SchemaFormat.Json,
                    CancellationToken.None))
                .Returns(
                    Task.FromResult(
                        Response.FromValue(
                            SchemaRegistryModelFactory.SchemaProperties(SchemaFormat.Json, "SchemaId"), new MockResponse(200))));

            var serializer = new SchemaRegistrySerializer(mockClient.Object, new SampleJsonGenerator(), "groupName");
            var content = await serializer.SerializeAsync(new Employee { Age = 42, Name = "Caketown" }).ConfigureAwait(false);
            Assert.AreEqual("SchemaId", content.ContentType.ToString().Split('+')[1]);
        }

        [Test]
        public async Task SerializeDeserializeWorksWithCustomType()
        {
            var mockClient = new Mock<SchemaRegistryClient>();
            mockClient
                .Setup(
                    client => client.GetSchemaPropertiesAsync(
                    "groupName",
                    nameof(Employee),
                    s_customSchema,
                    SchemaFormat.Custom,
                    CancellationToken.None))
                .Returns(
                    Task.FromResult(
                        Response.FromValue(
                            SchemaRegistryModelFactory.SchemaProperties(SchemaFormat.Custom, "SchemaId"), new MockResponse(200))));

            var options = new SchemaRegistrySerializerOptions { Format = SchemaFormat.Custom, Serializer = new FakeSerializer() };

            var serializer = new SchemaRegistrySerializer(mockClient.Object, new SampleCustomGenerator(), "groupName", options);
            var content = await serializer.SerializeAsync(new Employee { Age = 25, Name = "Name" }).ConfigureAwait(false);
            Assert.AreEqual("SchemaId", content.ContentType.ToString().Split('+')[1]);

            // Test that the correct mime type was used
            Assert.AreEqual("text/plain", content.ContentType.ToString().Split('+')[0]);
        }

        [Test]
        public async Task SerializeDeserializeWorksWithAvro()
        {
            var mockClient = new Mock<SchemaRegistryClient>();
            mockClient
                .Setup(
                    client => client.GetSchemaPropertiesAsync(
                    "groupName",
                    nameof(Employee),
                    s_avroschema,
                    SchemaFormat.Avro,
                    CancellationToken.None))
                .Returns(
                    Task.FromResult(
                        Response.FromValue(
                            SchemaRegistryModelFactory.SchemaProperties(SchemaFormat.Avro, "SchemaId"), new MockResponse(200))));

            var fakeSerializerAvro = new FakeSerializer();
            fakeSerializerAvro.SchemaToUse = s_avroschema;
            var options = new SchemaRegistrySerializerOptions { Format = SchemaFormat.Avro, Serializer = fakeSerializerAvro };

            var sampleGeneratorAvro = new SampleCustomGenerator();
            sampleGeneratorAvro.SchemaToUse = s_avroschema;
            var serializer = new SchemaRegistrySerializer(mockClient.Object, sampleGeneratorAvro, "groupName", options);
            var content = await serializer.SerializeAsync(new Employee { Age = 25, Name = "Name" }).ConfigureAwait(false);
            Assert.AreEqual("SchemaId", content.ContentType.ToString().Split('+')[1]);

            // Test that the correct mime type was used
            Assert.AreEqual("avro/binary", content.ContentType.ToString().Split('+')[0]);
        }

        private class FakeSerializer : ObjectSerializer
        {
            public string SchemaToUse { get; set; } = s_customSchema;

            public override object Deserialize(Stream stream, Type returnType, CancellationToken cancellationToken)
            {
                return new Employee
                {
                    Age = 25,
                    Name = "Name"
                };
            }

            public override async ValueTask<object> DeserializeAsync(Stream stream, Type returnType, CancellationToken cancellationToken)
            {
                await Task.Yield();
                return new Employee
                {
                    Age = 25,
                    Name = "Name"
                };
            }

            public override void Serialize(Stream stream, object value, Type inputType, CancellationToken cancellationToken)
            {
                var data = new BinaryData(SchemaToUse);
                var dataArray = data.ToArray();
                stream.Write(dataArray, 0, dataArray.Length);
            }

            public override async ValueTask SerializeAsync(Stream stream, object value, Type inputType, CancellationToken cancellationToken)
            {
                var data = new BinaryData(SchemaToUse);
                var dataArray = data.ToArray();
                await stream.WriteAsync(dataArray, 0, dataArray.Length, cancellationToken).ConfigureAwait(false);
            }
        }

        private class SampleCustomGenerator : SchemaValidator
        {
            public string SchemaToUse { get; set; } = s_customSchema;

            public override string GenerateSchema(Type dataType)
            {
                return SchemaToUse;
            }

            public override bool TryValidate(object data, Type dataType, string schemaDefinition, out IEnumerable<Exception> validationErrors)
            {
                Assert.That(data, Is.TypeOf<Employee>());
                Assert.AreEqual(dataType.Name, "Employee");
                Assert.AreEqual(schemaDefinition, SchemaToUse);

                validationErrors = new List<Exception>();

                return true;
            }
        }

        private class SampleJsonGenerator : SchemaValidator
        {
            public override string GenerateSchema(Type dataType)
            {
                return s_schema;
            }

            public override bool TryValidate(object data, Type dataType, string schemaDefinition, out IEnumerable<Exception> validationErrors)
            {
                validationErrors = new List<Exception>();
                return true;
            }
        }
    }
}
