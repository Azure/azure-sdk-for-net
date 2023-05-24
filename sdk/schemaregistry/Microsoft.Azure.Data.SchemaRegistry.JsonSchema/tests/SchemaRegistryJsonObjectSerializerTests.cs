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

namespace Microsoft.Azure.Data.SchemaRegistry.JsonSchema.Tests
{
    public class SchemaRegistryJsonObjectSerializerTests
    {
        private static readonly string _schema = "{\r\n  \"$schema\": \"http://json-schema.org/draft-04/schema#\",\r\n  \"title\": \"Employee\",\r\n  \"type\": \"object\",\r\n  \"additionalProperties\": false,\r\n  \"properties\": {\r\n    \"Age\": {\r\n      \"type\": \"integer\",\r\n      \"format\": \"int32\"\r\n    },\r\n    \"Name\": {\r\n      \"type\": [\r\n        \"null\",\r\n        \"string\"\r\n      ]\r\n    }\r\n  }\r\n}";

        [Test]
        public async Task SerializeWorks()
        {
            var mockClient = new Mock<SchemaRegistryClient>();
            mockClient
                .Setup(
                    client => client.GetSchemaPropertiesAsync(
                    "groupName",
                    nameof(Employee),
                    _schema,
                    SchemaFormat.Json,
                    CancellationToken.None))
                .Returns(
                    Task.FromResult(
                        Response.FromValue(
                            SchemaRegistryModelFactory.SchemaProperties(SchemaFormat.Json, "SchemaId"), new MockResponse(200))));

            var serializer = new SchemaRegistryJsonSerializer(mockClient.Object, "groupName", new SampleJsonGenerator());
            var content = await serializer.SerializeAsync(new Employee { Age = 42, Name = "Caketown" }).ConfigureAwait(false);
            Assert.AreEqual("SchemaId", content.ContentType.ToString().Split('+')[1]);
        }

        private class SampleJsonGenerator : SchemaRegistryJsonSchemaGenerator
        {
            public override string GenerateSchemaFromObject(Type dataType)
            {
                return _schema;
            }
        }
    }
}