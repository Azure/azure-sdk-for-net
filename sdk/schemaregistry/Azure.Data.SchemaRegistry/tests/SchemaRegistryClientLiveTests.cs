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
            AssertSchema(schema, schemaName);
            AssertPropertiesAreEqual(registerProperties, schema.Properties);
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
                Throws.InstanceOf<RequestFailedException>().And.Property(nameof(RequestFailedException.Status)).EqualTo(415));
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
                Throws.InstanceOf<RequestFailedException>().And.Property(nameof(RequestFailedException.Status)).EqualTo(415));
        }

        private void AssertSchema(SchemaRegistrySchema schema, string schemaName)
        {
            AssertSchemaProperties(schema.Properties, schemaName);
            Assert.AreEqual(
                Regex.Replace(SchemaContent, @"\s+", string.Empty),
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
