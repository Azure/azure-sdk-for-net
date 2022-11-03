﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.SchemaRegistry.Models;

namespace Azure.Data.SchemaRegistry.Tests
{
    public class SchemaRegistryClientLiveTests : RecordedTestBase<SchemaRegistryClientTestEnvironment>
    {
        public SchemaRegistryClientLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
            TestDiagnostics = false;
        }

        private SchemaRegistryClient CreateClient(string format)
        {
            string endpoint;
            switch (format)
            {
                case "JSON":
                    endpoint = TestEnvironment.SchemaRegistryEndpointJson;
                    break;
                case "Avro":
                    endpoint = TestEnvironment.SchemaRegistryEndpointAvro;
                    break;
                case "Custom":
                    endpoint = TestEnvironment.SchemaRegistryEndpointCustom;
                    break;
                default:
                    endpoint = TestEnvironment.SchemaRegistryEndpointAvro;
                    break;
            }

            return InstrumentClient(new SchemaRegistryClient(
                endpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new SchemaRegistryClientOptions())));
        }

        private string GenerateSchemaName() => Recording.GenerateId("test-", 10);

        private const string SchemaContent = "{\"type\" : \"record\",\"namespace\" : \"TestSchema\",\"name\" : \"Employee\",\"fields\" : [{ \"name\" : \"Name\" , \"type\" : \"string\" },{ \"name\" : \"Age\", \"type\" : \"int\" }]}";
        private const string SchemaContent_V2 = "{\"type\" : \"record\",\"namespace\" : \"TestSchema\",\"name\" : \"Employee_V2\",\"fields\" : [{ \"name\" : \"Name\" , \"type\" : \"string\" },{ \"name\" : \"Age\", \"type\" : \"int\" }]}";
        private const string Json_SchemaContent = "{\r\n  \"$id\": \"1\",\r\n  \"$schema\": \"Json\",\r\n  \"title\": \"Person\",\r\n  \"type\": \"object\",\r\n  \"properties\": {\r\n    \"firstName\": {\r\n      \"type\": \"string\",\r\n      \"description\": \"The person's first name.\"\r\n    },\r\n    \"lastName\": {\r\n      \"type\": \"string\",\r\n      \"description\": \"The person's last name.\"\r\n    },\r\n    \"age\": {\r\n      \"description\": \"Age in years which must be equal to or greater than zero.\",\r\n      \"type\": \"integer\",\r\n      \"minimum\": 0\r\n    }\r\n  }\r\n}";
        private const string Json_SchemaContent_V2 = "{\r\n  \"$id\": \"2\",\r\n  \"$schema\": \"Json\",\r\n  \"title\": \"Person_V2\",\r\n  \"type\": \"object\",\r\n  \"properties\": {\r\n    \"firstName\": {\r\n      \"type\": \"string\",\r\n      \"description\": \"The person's first name.\"\r\n    },\r\n    \"lastName\": {\r\n      \"type\": \"string\",\r\n      \"description\": \"The person's last name.\"\r\n    },\r\n    \"age\": {\r\n      \"description\": \"Age in years which must be equal to or greater than zero.\",\r\n      \"type\": \"integer\",\r\n      \"minimum\": 0\r\n    }\r\n  }\r\n}";
        // private BinaryData Custom_SchemaContent = BinaryData.FromString("Hello"); TODO: update after new swagger
        // private BinaryData Custom_SchemaContent_V2 = BinaryData.FromString("Hello_V2"); TODO: update after new swagger

        private const string Avro = "Avro";
        private const string Json = "JSON";
        private const string Custom = "Custom";

        [RecordedTest]
        [TestCase(Avro)]
        [TestCase(Json)]
        [TestCase(Custom)]
        public async Task CanRegisterSchema(string formatName)
        {
            var client = CreateClient(formatName);
            var schemaName = GenerateSchemaName();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var format = StringToSchemaFormat(formatName);
            var content = StringToSchemaContent(formatName, 1);

            SchemaProperties registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, content, format);
            AssertSchemaProperties(registerProperties, schemaName, format);

            SchemaProperties schemaProperties = await client.GetSchemaPropertiesAsync(groupName, schemaName, content, format);
            AssertSchemaProperties(schemaProperties, schemaName, format);
            AssertPropertiesAreEqual(registerProperties, schemaProperties);
        }

        [RecordedTest]
        [TestCase(Avro)]
        [TestCase(Json)]
        [TestCase(Custom)]
        public async Task CanRegisterNewVersionOfSchema(string formatName)
        {
            var client = CreateClient(formatName);
            var schemaName = GenerateSchemaName();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var format = StringToSchemaFormat(formatName);
            var content_V1 = StringToSchemaContent(formatName, 1);
            var content_V2 = StringToSchemaContent(formatName, 2);

            SchemaProperties registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, content_V1, format);
            AssertSchemaProperties(registerProperties, schemaName, format);

            SchemaProperties schemaProperties = await client.GetSchemaPropertiesAsync(groupName, schemaName, content_V1, format);
            AssertSchemaProperties(schemaProperties, schemaName, format);
            AssertPropertiesAreEqual(registerProperties, schemaProperties);

            SchemaProperties newVersion = await client.RegisterSchemaAsync(schemaProperties.GroupName, schemaProperties.Name, content_V2, schemaProperties.Format);
            AssertSchemaProperties(newVersion, schemaName, format);
            Assert.AreNotEqual(registerProperties.Id, newVersion.Id);
        }

        [RecordedTest]
        [TestCase(Avro)]
        [TestCase(Json)]
        [TestCase(Custom)]
        public async Task CanGetSchemaId(string formatName)
        {
            var client = CreateClient(formatName);
            var schemaName = GenerateSchemaName();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var format = StringToSchemaFormat(formatName);
            var content = StringToSchemaContent(formatName, 1);

            SchemaProperties registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, content, format);
            AssertSchemaProperties(registerProperties, schemaName, format);

            SchemaProperties schemaProperties = await client.GetSchemaPropertiesAsync(groupName, schemaName, content, format);
            AssertSchemaProperties(schemaProperties, schemaName, format);
            AssertPropertiesAreEqual(registerProperties, schemaProperties);
        }

        [RecordedTest]
        [TestCase(Avro)]
        [TestCase(Json)]
        [TestCase(Custom)]
        public async Task CanGetSchema(string formatName)
        {
            var client = CreateClient(formatName);
            var schemaName = GenerateSchemaName();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var format = StringToSchemaFormat(formatName);
            var content = StringToSchemaContent(formatName, 1);

            var registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, content, format);
            AssertSchemaProperties(registerProperties, schemaName, format);

            SchemaRegistrySchema schema = await client.GetSchemaAsync(registerProperties.Value.Id);
            AssertSchema(schema, schemaName, content, format);
            AssertPropertiesAreEqual(registerProperties, schema.Properties);
        }

        [RecordedTest]
        [TestCase(Avro)]
        [TestCase(Json)]
        [TestCase(Custom)]
        public async Task CanGetSchemaByVersion(string formatName)
        {
            var client = CreateClient(formatName);
            var schemaName = GenerateSchemaName();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var format = StringToSchemaFormat(formatName);
            var content_V1 = StringToSchemaContent(formatName, 1);
            var content_V2 = StringToSchemaContent(formatName, 2);

            var registerPropertiesv1 = await client.RegisterSchemaAsync(groupName, schemaName, content_V1, format);
            AssertSchemaProperties(registerPropertiesv1, schemaName, format);

            var registerPropertiesv2 = await client.RegisterSchemaAsync(groupName, schemaName, content_V2, format);
            AssertSchemaProperties(registerPropertiesv2, schemaName, format);

            SchemaRegistrySchema schemav1 = await client.GetSchemaAsync(groupName, schemaName, 1);
            AssertSchema(schemav1, schemaName, content_V1, format);
            AssertPropertiesAreEqual(registerPropertiesv1, schemav1.Properties);

            SchemaRegistrySchema schemav2 = await client.GetSchemaAsync(groupName, schemaName, 2);
            AssertSchema(schemav2, schemaName, content_V2, format);
            AssertPropertiesAreEqual(registerPropertiesv2, schemav2.Properties);
        }

        [RecordedTest]

        public void CanCreateRegisterRequestForUnknownFormatType()
        {
            var client = CreateClient();
            var schemaName = GenerateSchemaName();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var format = new SchemaFormat("NOTJSON");
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
            var format = new SchemaFormat("NOTJSON");
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

        private void AssertSchema(SchemaRegistrySchema schema, string expectedSchemaName, string expectedSchemaContent, SchemaFormat schemaFormat)
        {
            AssertSchemaProperties(schema.Properties, expectedSchemaName, schemaFormat);
            Assert.AreEqual(
                Regex.Replace(expectedSchemaContent, @"\s+", string.Empty),
                Regex.Replace(schema.Definition, @"\s+", string.Empty));
        }

        private void AssertSchemaProperties(SchemaProperties properties, string schemaName, SchemaFormat schemaFormat)
        {
            Assert.IsNotNull(properties);
            Assert.IsNotNull(properties.Id);
            Assert.IsTrue(Guid.TryParse(properties.Id, out Guid _));
            Assert.AreEqual(schemaFormat, properties.Format);
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

        private SchemaFormat StringToSchemaFormat(string formatName)
        {
            switch (formatName)
            {
                case Avro:
                    return SchemaFormat.Avro;
                case Json:
                    return SchemaFormat.Json;
                case Custom:
                    return SchemaFormat.Custom;
                default:
                    throw new ArgumentException("Format name was invalid.");
            }
        }

        private string StringToSchemaContent(string formatName, int version)
        {
            switch (formatName)
            {
                case Avro:
                    if (version == 1)
                    {
                        return SchemaContent;
                    }
                    return SchemaContent_V2;
                case Json:
                    if (version == 1)
                    {
                        return Json_SchemaContent;
                    }
                    return Json_SchemaContent_V2;
                case Custom:
                    return "TODO";
                default:
                    throw new ArgumentException("Format name was invalid.");
            }
        }
    }
}
