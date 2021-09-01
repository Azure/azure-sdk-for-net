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

            SchemaProperties registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, schemaType, SchemaContent);
            AssertSchemaProperties(registerProperties);

            // this should be a cached lookup
            var schemaProperties = await client.GetSchemaIdAsync(groupName, schemaName, schemaType, SchemaContent);
            AssertSchemaProperties(schemaProperties);
            AssertPropertiesAreEqual(registerProperties, schemaProperties);

            // this should be an uncached lookup
            var client2 = CreateClient();
            schemaProperties = await client2.GetSchemaIdAsync(groupName, schemaName, schemaType, SchemaContent);
            AssertSchemaProperties(schemaProperties);
            AssertPropertiesAreEqual(registerProperties, schemaProperties);

            // this should be a cached lookup
            schemaProperties = await client2.GetSchemaIdAsync(groupName, schemaName, schemaType, SchemaContent);
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

            SchemaProperties registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, schemaType, SchemaContent);
            AssertSchemaProperties(registerProperties);

            // this should be a cached lookup
            var schemaProperties = await client.GetSchemaIdAsync(groupName, schemaName, schemaType, SchemaContent);
            AssertSchemaProperties(schemaProperties);
            AssertPropertiesAreEqual(registerProperties, schemaProperties);

            // this should be an uncached lookup
            var client2 = CreateClient();
            schemaProperties = await client2.GetSchemaIdAsync(groupName, schemaName, schemaType, SchemaContent);
            AssertSchemaProperties(schemaProperties);
            AssertPropertiesAreEqual(registerProperties, schemaProperties);

            // this should be a cached lookup
            schemaProperties = await client2.GetSchemaIdAsync(groupName, schemaName, schemaType, SchemaContent);
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

            var registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, schemaType, SchemaContent);
            AssertSchemaProperties(registerProperties);

            // this should be a cached lookup
            var schemaProperties = await client.GetSchemaAsync(registerProperties.Value.Id);
            AssertSchemaProperties(schemaProperties);
            AssertPropertiesAreEqual(registerProperties, schemaProperties);

            // this should be an uncached lookup
            var client2 = CreateClient();
            schemaProperties = await client2.GetSchemaAsync(registerProperties.Value.Id);
            AssertSchemaProperties(schemaProperties);
            AssertPropertiesAreEqual(registerProperties, schemaProperties);

            // this should be a cached lookup
            schemaProperties = await client2.GetSchemaAsync(registerProperties.Value.Id);
            AssertSchemaProperties(schemaProperties);
            AssertPropertiesAreEqual(registerProperties, schemaProperties);
        }

        private void AssertSchemaProperties(SchemaProperties properties)
        {
            Assert.IsNotNull(properties);
            Assert.IsNotNull(properties.Id);
            Assert.IsTrue(Guid.TryParse(properties.Id, out Guid _));
            Assert.AreEqual(
                Regex.Replace(SchemaContent, @"\s+", string.Empty),
                Regex.Replace(properties.Content, @"\s+", string.Empty));
        }

        private void AssertPropertiesAreEqual(SchemaProperties registerProperties, SchemaProperties schemaProperties)
        {
            Assert.AreEqual(
                Regex.Replace(registerProperties.Content, @"\s+", string.Empty),
                Regex.Replace(schemaProperties.Content, @"\s+", string.Empty));
            Assert.AreEqual(registerProperties.Id, schemaProperties.Id);
        }
    }
}
