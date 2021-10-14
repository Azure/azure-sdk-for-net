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

        private const string SchemaContent = "{\"type\" : \"record\",\"namespace\" : \"TestSchema\",\"name\" : \"Employee\",\"fields\" : [{ \"name\" : \"Name\" , \"type\" : \"string\" },{ \"name\" : \"Age\", \"type\" : \"int\" }]}";

        [RecordedTest]
        public async Task CanRegisterSchema()
        {
            var client = CreateClient();
            var schemaName = "test1";
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var schemaType = SerializationType.Avro;

            SchemaProperties registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, SchemaContent, schemaType);
            AssertSchemaProperties(registerProperties);

            // this should be a cached lookup
            var schemaProperties = await client.GetSchemaPropertiesAsync(groupName, schemaName, SchemaContent, schemaType);
            AssertSchemaProperties(schemaProperties);
            AssertPropertiesAreEqual(registerProperties, schemaProperties);

            // this should be an uncached lookup
            var client2 = CreateClient();
            schemaProperties = await client2.GetSchemaPropertiesAsync(groupName, schemaName, SchemaContent, schemaType);
            AssertSchemaProperties(schemaProperties);
            AssertPropertiesAreEqual(registerProperties, schemaProperties);

            // this should be a cached lookup
            schemaProperties = await client2.GetSchemaPropertiesAsync(groupName, schemaName, SchemaContent, schemaType);
            AssertSchemaProperties(schemaProperties);
            AssertPropertiesAreEqual(registerProperties, schemaProperties);
        }

        [RecordedTest]
        public async Task CanGetSchemaId()
        {
            var client = CreateClient();
            var schemaName = "test1";
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var schemaType = SerializationType.Avro;

            SchemaProperties registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, SchemaContent, schemaType);
            AssertSchemaProperties(registerProperties);

            // this should be a cached lookup
            var schemaProperties = await client.GetSchemaPropertiesAsync(groupName, schemaName, SchemaContent, schemaType);
            AssertSchemaProperties(schemaProperties);
            AssertPropertiesAreEqual(registerProperties, schemaProperties);

            // this should be an uncached lookup
            var client2 = CreateClient();
            schemaProperties = await client2.GetSchemaPropertiesAsync(groupName, schemaName, SchemaContent, schemaType);
            AssertSchemaProperties(schemaProperties);
            AssertPropertiesAreEqual(registerProperties, schemaProperties);

            // this should be a cached lookup
            schemaProperties = await client2.GetSchemaPropertiesAsync(groupName, schemaName, SchemaContent, schemaType);
            AssertSchemaProperties(schemaProperties);
            AssertPropertiesAreEqual(registerProperties, schemaProperties);
        }

        [RecordedTest]
        public async Task CanGetSchema()
        {
            var client = CreateClient();
            var schemaName = "test1";
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var schemaType = SerializationType.Avro;

            var registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, SchemaContent, schemaType);
            AssertSchemaProperties(registerProperties);

            // this should be an uncached lookup as we only cache the schema value when it comes back from the service
            var schema = await client.GetSchemaAsync(registerProperties.Value.Id);
            AssertSchema(schema);
            AssertPropertiesAreEqual(registerProperties, schema.Properties);
        }

        private void AssertSchema(SchemaRegistrySchema schema)
        {
            AssertSchemaProperties(schema.Properties);
            Assert.AreEqual(
                Regex.Replace(SchemaContent, @"\s+", string.Empty),
                Regex.Replace(schema.Content, @"\s+", string.Empty));
        }

        private void AssertSchemaProperties(SchemaProperties properties)
        {
            Assert.IsNotNull(properties);
            Assert.IsNotNull(properties.Id);
            Assert.IsTrue(Guid.TryParse(properties.Id, out Guid _));
        }

        private void AssertPropertiesAreEqual(SchemaProperties registeredSchema, SchemaProperties schema)
        {
            Assert.AreEqual(registeredSchema.Id, schema.Id);
        }
    }
}
