// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.SchemaRegistry.Tests
{
    public class SchemaRegistryClientLiveTests : RecordedTestBase<SchemaRegistryClientTestEnvironment>
    {
        public SchemaRegistryClientLiveTests(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        private SchemaRegistryClient CreateClient() =>
            InstrumentClient(new SchemaRegistryClient(
                TestEnvironment.SchemaRegistryEndpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new SchemaRegistryClientOptions())
            ));

        private string GenerateSchemaName() => Recording.GenerateId("test-", 10);

        private const string SchemaContent = "{\"type\" : \"record\",\"namespace\" : \"TestSchema\",\"name\" : \"Employee\",\"fields\" : [{ \"name\" : \"Name\" , \"type\" : \"string\" },{ \"name\" : \"Age\", \"type\" : \"int\" }]}";
        private const string SchemaContent_V2 = "{\"type\" : \"record\",\"namespace\" : \"TestSchema\",\"name\" : \"Employee_V2\",\"fields\" : [{ \"name\" : \"Name\" , \"type\" : \"string\" },{ \"name\" : \"Age\", \"type\" : \"int\" }]}";

        [RecordedTest]
        public async Task CanRegisterSchema()
        {
            var client = CreateClient();
            var schemaName = GenerateSchemaName();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var format = SchemaFormat.Avro;

            SchemaProperties registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, SchemaContent, format);
            AssertSchemaProperties(registerProperties, schemaName);

            SchemaProperties schemaProperties = await client.GetSchemaPropertiesAsync(groupName, schemaName, SchemaContent, format);
            AssertSchemaProperties(schemaProperties, schemaName);
            AssertPropertiesAreEqual(registerProperties, schemaProperties);
        }

        [RecordedTest]
        public async Task CanRegisterNewVersionOfSchema()
        {
            var client = CreateClient();
            var schemaName = GenerateSchemaName();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var format = SchemaFormat.Avro;

            SchemaProperties registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, SchemaContent, format);
            AssertSchemaProperties(registerProperties, schemaName);

            SchemaProperties schemaProperties = await client.GetSchemaPropertiesAsync(groupName, schemaName, SchemaContent, format);
            AssertSchemaProperties(schemaProperties, schemaName);
            AssertPropertiesAreEqual(registerProperties, schemaProperties);

            SchemaProperties newVersion = await client.RegisterSchemaAsync(schemaProperties.GroupName, schemaProperties.Name, SchemaContent_V2, schemaProperties.Format);
            AssertSchemaProperties(newVersion, schemaName);
            Assert.AreNotEqual(registerProperties.Id, newVersion.Id);
        }

        [RecordedTest]
        public async Task CanGetSchemaId()
        {
            var client = CreateClient();
            var schemaName = GenerateSchemaName();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var format = SchemaFormat.Avro;

            SchemaProperties registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, SchemaContent, format);
            AssertSchemaProperties(registerProperties, schemaName);

            SchemaProperties schemaProperties = await client.GetSchemaPropertiesAsync(groupName, schemaName, SchemaContent, format);
            AssertSchemaProperties(schemaProperties, schemaName);
            AssertPropertiesAreEqual(registerProperties, schemaProperties);
        }

        [RecordedTest]
        public async Task CanGetSchema()
        {
            var client = CreateClient();
            var schemaName = GenerateSchemaName();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var format = SchemaFormat.Avro;

            var registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, SchemaContent, format);
            AssertSchemaProperties(registerProperties, schemaName);

            SchemaRegistrySchema schema = await client.GetSchemaAsync(registerProperties.Value.Id);
            AssertSchema(schema, schemaName, SchemaContent);
            AssertPropertiesAreEqual(registerProperties, schema.Properties);
        }

        [RecordedTest]
        public async Task CanGetSchemaByVersion()
        {
            var client = CreateClient();
            var schemaName = GenerateSchemaName();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var format = SchemaFormat.Avro;

            var registerPropertiesv1 = await client.RegisterSchemaAsync(groupName, schemaName, SchemaContent, format);
            AssertSchemaProperties(registerPropertiesv1, schemaName);

            var registerPropertiesv2 = await client.RegisterSchemaAsync(groupName, schemaName, SchemaContent_V2, format);
            AssertSchemaProperties(registerPropertiesv2, schemaName);

            SchemaRegistrySchema schemav1 = await client.GetSchemaAsync(groupName, schemaName, 1);
            AssertSchema(schemav1, schemaName, SchemaContent);
            AssertPropertiesAreEqual(registerPropertiesv1, schemav1.Properties);

            SchemaRegistrySchema schemav2 = await client.GetSchemaAsync(groupName, schemaName, 2);
            AssertSchema(schemav2, schemaName, SchemaContent_V2);
            AssertPropertiesAreEqual(registerPropertiesv2, schemav2.Properties);
        }

        [RecordedTest]
        public void CanCreateRegisterRequestForUnknownFormatType()
        {
            var client = CreateClient();
            var schemaName = GenerateSchemaName();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var format = new SchemaFormat("JSON");
            Assert.That(
                async () => await client.RegisterSchemaAsync(groupName, schemaName, SchemaContent, format),
                Throws.InstanceOf<RequestFailedException>().And.Property(nameof(RequestFailedException.Status)).EqualTo(415)
                    .And.Property(nameof(RequestFailedException.ErrorCode)).EqualTo("InvalidSchemaType"));
        }

        [RecordedTest]
        public void CanCreateGetSchemaPropertiesRequestForUnknownFormatType()
        {
            var client = CreateClient();
            var schemaName = GenerateSchemaName();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var format = new SchemaFormat("JSON");
            Assert.That(
                async () => await client.GetSchemaPropertiesAsync(groupName, schemaName, SchemaContent, format),
                Throws.InstanceOf<RequestFailedException>().And.Property(nameof(RequestFailedException.Status)).EqualTo(415)
                    .And.Property(nameof(RequestFailedException.ErrorCode)).EqualTo("InvalidSchemaType"));
        }

        [RecordedTest]
        public void GetSchemaForNonexistentSchemaIdReturnsItemNotFoundErrorCode()
        {
            var client = CreateClient();
            Assert.That(
                async () => await client.GetSchemaAsync(Recording.Random.NewGuid().ToString()),
                Throws.InstanceOf<RequestFailedException>().And.Property(nameof(RequestFailedException.Status)).EqualTo(404)
                    .And.Property(nameof(RequestFailedException.ErrorCode)).EqualTo("ItemNotFound"));
        }

        [RecordedTest]
        public void GetSchemaPropertiesForNonexistentSchemaReturnsItemNotFoundErrorCode()
        {
            var client = CreateClient();
            var schemaName = GenerateSchemaName();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            Assert.That(
                async () => await client.GetSchemaPropertiesAsync(schemaName, groupName, SchemaContent, SchemaFormat.Avro),
                Throws.InstanceOf<RequestFailedException>().And.Property(nameof(RequestFailedException.Status)).EqualTo(404)
                    .And.Property(nameof(RequestFailedException.ErrorCode)).EqualTo("ItemNotFound"));
        }

        private void AssertSchema(SchemaRegistrySchema schema, string expectedSchemaName, string expectedSchemaContent)
        {
            AssertSchemaProperties(schema.Properties, expectedSchemaName);
            Assert.AreEqual(
                Regex.Replace(expectedSchemaContent, @"\s+", string.Empty),
                Regex.Replace(schema.Definition, @"\s+", string.Empty));
        }

        private void AssertSchemaProperties(SchemaProperties properties, string schemaName)
        {
            Assert.IsNotNull(properties);
            Assert.IsNotNull(properties.Id);
            Assert.IsTrue(Guid.TryParse(properties.Id, out Guid _));
            Assert.AreEqual(SchemaFormat.Avro, properties.Format);
            Assert.AreEqual(schemaName, properties.Name);
            Assert.AreEqual(TestEnvironment.SchemaRegistryGroup, properties.GroupName);
        }

        private void AssertPropertiesAreEqual(SchemaProperties registeredSchema, SchemaProperties schema)
        {
            Assert.AreEqual(registeredSchema.Id, schema.Id);
            Assert.AreEqual(registeredSchema.Format, schema.Format);
            Assert.AreEqual(registeredSchema.GroupName, schema.GroupName);
            Assert.AreEqual(registeredSchema.Name, schema.Name);
        }
    }
}
