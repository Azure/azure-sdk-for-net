// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using Azure.Data.SchemaRegistry;
using Moq;
using NUnit.Framework;
using TestSchema;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.Tests
{
    public class SchemaRegistryAvroObjectSerializerTests
    {
        [Test]
        public async Task SerializeWorksWithNoOptions()
        {
            var mockClient = new Mock<SchemaRegistryClient>();
            mockClient
                .Setup(
                    client => client.GetSchemaPropertiesAsync(
                        "groupName",
                        Employee._SCHEMA.Fullname,
                        Employee._SCHEMA.ToString(),
                        SchemaFormat.Avro,
                        CancellationToken.None))
                .Returns(
                    Task.FromResult(
                        Response.FromValue(
                            SchemaRegistryModelFactory.SchemaProperties(SchemaFormat.Avro, "schemaId"), new MockResponse(200))));

           var serializer = new SchemaRegistryAvroSerializer(mockClient.Object, "groupName");
           var content = await serializer.SerializeAsync(new Employee {Age = 42, Name = "Caketown"});
            Assert.That(content.ContentType.ToString().Split('+')[1], Is.EqualTo("schemaId"));

           // also validate explicitly passing null
           serializer = new SchemaRegistryAvroSerializer(mockClient.Object, "groupName", null);
           content = await serializer.SerializeAsync(new Employee {Age = 42, Name = "Caketown"});
            Assert.That(content.ContentType.ToString().Split('+')[1], Is.EqualTo("schemaId"));
        }

        [Test]
        public void CloneCopiesAllProperties()
        {
            var options = new SchemaRegistryAvroSerializerOptions() { AutoRegisterSchemas = true };
            Assert.That(options.AutoRegisterSchemas, Is.True);

            var cloned = options.Clone();
            Assert.That(cloned.AutoRegisterSchemas, Is.EqualTo(options.AutoRegisterSchemas));
        }
    }
}