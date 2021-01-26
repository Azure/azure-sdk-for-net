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

        [Test]
        public async Task CanRegisterSchema()
        {
            var client = CreateClient();
            var schemaName = "test1";
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var schemaType = SerializationType.Avro;

            var schemaProperties = await client.RegisterSchemaAsync(groupName, schemaName, schemaType, SchemaContent);
            Assert.IsNotNull(schemaProperties.Value);
            Assert.IsNotNull(schemaProperties.Value.Id);
            Assert.IsTrue(Guid.TryParse(schemaProperties.Value.Id, out Guid _));
            Assert.AreEqual(SchemaContent, schemaProperties.Value.Content);
        }

        [Test]
        public async Task CanGetSchemaId()
        {
            var client = CreateClient();
            var schemaName = "test1";
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var schemaType = SerializationType.Avro;

            await client.RegisterSchemaAsync(groupName, schemaName, schemaType, SchemaContent);
            var schemaProperties = await client.GetSchemaIdAsync(groupName, schemaName, schemaType, SchemaContent);
            Assert.IsNotNull(schemaProperties.Value);
            Assert.IsNotNull(schemaProperties.Value.Id);
            Assert.IsTrue(Guid.TryParse(schemaProperties.Value.Id, out Guid _));
            Assert.AreEqual(SchemaContent, schemaProperties.Value.Content);
        }

        [Test]
        public async Task CanGetSchema()
        {
            var client = CreateClient();
            var schemaName = "test1";
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var schemaType = SerializationType.Avro;

            var registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, schemaType, SchemaContent);
            Assert.IsNotNull(registerProperties.Value.Id);
            Assert.IsTrue(Guid.TryParse(registerProperties.Value.Id, out Guid _));

            var schemaProperties = await client.GetSchemaAsync(registerProperties.Value.Id);
            Assert.IsNotNull(schemaProperties.Value);
            Assert.IsNotNull(schemaProperties.Value.Id);
            Assert.IsTrue(Guid.TryParse(schemaProperties.Value.Id, out Guid _));
            Assert.AreEqual(Regex.Replace(SchemaContent, @"\s+", string.Empty), schemaProperties.Value.Content);
        }
    }
}
