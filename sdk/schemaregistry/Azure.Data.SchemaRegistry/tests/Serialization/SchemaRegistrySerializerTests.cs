// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using Azure.Data.SchemaRegistry;
using Moq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using TestSchema;
using Azure.Core.Serialization;
using Azure.Data.SchemaRegistry.Serialization;

namespace Azure.Data.SchemaRegistry.Tests.Serialization
{
    public class SchemaRegistrySerializerTests
    {
        private static readonly string s_schema = "{\r\n  \"$schema\": \"http://json-schema.org/draft-04/schema#\",\r\n  \"title\": \"Employee\",\r\n  \"type\": \"object\",\r\n  \"additionalProperties\": false,\r\n  \"properties\": {\r\n    \"Age\": {\r\n      \"type\": \"integer\",\r\n      \"format\": \"int32\"\r\n    },\r\n    \"Name\": {\r\n      \"type\": [\r\n        \"null\",\r\n        \"string\"\r\n      ]\r\n    }\r\n  }\r\n}";

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

            var serializer = new SchemaRegistrySerializer(mockClient.Object, "groupName", new SampleJsonGenerator());
            var content = await serializer.SerializeAsync(new Employee { Age = 42, Name = "Caketown" }).ConfigureAwait(false);
            Assert.AreEqual("SchemaId", content.ContentType.ToString().Split('+')[1]);
        }

        private class SampleJsonGenerator : SchemaValidator
        {
            public override string GenerateSchema(Type dataType)
            {
                return s_schema;
            }

            public override void Validate(object data, Type dataType, string schemaDefinition)
            {
                return;
            }
        }
    }
}
