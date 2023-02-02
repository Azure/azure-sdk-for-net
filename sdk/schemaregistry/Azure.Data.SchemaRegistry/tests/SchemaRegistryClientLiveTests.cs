// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Collections.Generic;

namespace Azure.Data.SchemaRegistry.Tests
{
    [ClientTestFixture(SchemaRegistryClientOptions.ServiceVersion.V2021_10, SchemaRegistryClientOptions.ServiceVersion.V2022_10)]
    public class SchemaRegistryClientLiveTests : RecordedTestBase<SchemaRegistryClientTestEnvironment>
    {
        private readonly SchemaRegistryClientOptions.ServiceVersion _serviceVersion;
        public SchemaRegistryClientLiveTests(bool isAsync, SchemaRegistryClientOptions.ServiceVersion version) : base(isAsync)
        {
            TestDiagnostics = false;
            _serviceVersion = version;
        }

        private SchemaRegistryClient CreateClient(string format, int group = 1)
        {
            string endpoint;
            switch (format)
            {
                case Json:
                    if (_serviceVersion == SchemaRegistryClientOptions.ServiceVersion.V2022_10)
                    {
                        endpoint = (group == 1) ? TestEnvironment.SchemaRegistryEndpointJson : TestEnvironment.SchemaRegistryEndpointJson2;
                    }
                    else
                    {
                        endpoint = (group == 1) ? TestEnvironment.SchemaRegistryEndpointJson2021 : TestEnvironment.SchemaRegistryEndpointJson2021_2;
                    }
                    break;
                case Avro:
                    if (_serviceVersion == SchemaRegistryClientOptions.ServiceVersion.V2022_10)
                    {
                        endpoint = (group == 1) ? TestEnvironment.SchemaRegistryEndpointAvro : TestEnvironment.SchemaRegistryEndpointAvro2;
                    }
                    else
                    {
                        endpoint = (group == 1) ? TestEnvironment.SchemaRegistryEndpointAvro2021 : TestEnvironment.SchemaRegistryEndpointAvro2021_2;
                    }
                    break;
                case Custom:
                    if (_serviceVersion == SchemaRegistryClientOptions.ServiceVersion.V2022_10)
                    {
                        endpoint = (group == 1) ? TestEnvironment.SchemaRegistryEndpointCustom : TestEnvironment.SchemaRegistryEndpointCustom2;
                    }
                    else
                    {
                        endpoint = (group == 1) ? TestEnvironment.SchemaRegistryEndpointCustom2021 : TestEnvironment.SchemaRegistryEndpointCustom2021_2;
                    }
                    break;
                default:
                    if (_serviceVersion == SchemaRegistryClientOptions.ServiceVersion.V2022_10)
                    {
                        endpoint = (group == 1) ? TestEnvironment.SchemaRegistryEndpointAvro : TestEnvironment.SchemaRegistryEndpointAvro2;
                    }
                    else
                    {
                        endpoint = (group == 1) ? TestEnvironment.SchemaRegistryEndpointAvro2021 : TestEnvironment.SchemaRegistryEndpointAvro2021_2;
                    }
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
        private const string Custom_SchemaContent = "Hello";
        private const string Custom_SchemaContent_V2 = "Hello_V2";

        private const string Avro = "Avro";
        private const string Json = "Json";
        private const string Custom = "Custom";

        [RecordedTest]
        [TestCase(Avro)]
        [TestCase(Json)]
        [TestCase(Custom)]
        public async Task CanRegisterSchema(string formatName)
        {
            var client = CreateClient(formatName);
            var schemaName = GenerateSchemaName();
            var groupName = (_serviceVersion == SchemaRegistryClientOptions.ServiceVersion.V2022_10) ? TestEnvironment.SchemaRegistryGroup : TestEnvironment.SchemaRegistryGroup2021;
            var format = StringToSchemaFormat(formatName);
            var content = StringToSchemaContent(formatName, 1);

            SchemaProperties registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, content, format);
            AssertSchemaProperties(registerProperties, schemaName, format);

            SchemaProperties schemaProperties = await client.GetSchemaPropertiesAsync(groupName, schemaName, content, format);
            AssertSchemaProperties(schemaProperties, schemaName, format);
            AssertPropertiesAreEqual(registerProperties, schemaProperties, format);
        }

        [RecordedTest]
        [TestCase(Avro)]
        [TestCase(Json)]
        [TestCase(Custom)]
        public async Task CanRegisterNewVersionOfSchema(string formatName)
        {
            var client = CreateClient(formatName);
            var schemaName = GenerateSchemaName();
            var groupName = (_serviceVersion == SchemaRegistryClientOptions.ServiceVersion.V2022_10) ? TestEnvironment.SchemaRegistryGroup : TestEnvironment.SchemaRegistryGroup2021;
            var format = StringToSchemaFormat(formatName);
            var content_V1 = StringToSchemaContent(formatName, 1);
            var content_V2 = StringToSchemaContent(formatName, 2);

            SchemaProperties registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, content_V1, format);
            AssertSchemaProperties(registerProperties, schemaName, format);

            SchemaProperties schemaProperties = await client.GetSchemaPropertiesAsync(groupName, schemaName, content_V1, format);
            AssertSchemaProperties(schemaProperties, schemaName, format);
            AssertPropertiesAreEqual(registerProperties, schemaProperties, format);

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
            var groupName = (_serviceVersion == SchemaRegistryClientOptions.ServiceVersion.V2022_10) ? TestEnvironment.SchemaRegistryGroup : TestEnvironment.SchemaRegistryGroup2021;
            var format = StringToSchemaFormat(formatName);
            var content = StringToSchemaContent(formatName, 1);

            SchemaProperties registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, content, format);
            AssertSchemaProperties(registerProperties, schemaName, format);

            SchemaProperties schemaProperties = await client.GetSchemaPropertiesAsync(groupName, schemaName, content, format);
            AssertSchemaProperties(schemaProperties, schemaName, format);
            AssertPropertiesAreEqual(registerProperties, schemaProperties, format);
        }

        [RecordedTest]
        [TestCase(Avro)]
        [TestCase(Json)]
        [TestCase(Custom)]
        public async Task CanGetSchema(string formatName)
        {
            var client = CreateClient(formatName, 2);
            var schemaName = GenerateSchemaName();
            var groupName = (_serviceVersion == SchemaRegistryClientOptions.ServiceVersion.V2022_10) ? TestEnvironment.SchemaRegistryGroup2 : TestEnvironment.SchemaRegistryGroup2021_2;
            var format = StringToSchemaFormat(formatName);
            var content = StringToSchemaContent(formatName, 1);

            var registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, content, format);
            AssertSchemaProperties(registerProperties, schemaName, format, 2);

            SchemaRegistrySchema schema = await client.GetSchemaAsync(registerProperties.Value.Id);
            AssertSchema(schema, schemaName, content, format, 2);
            AssertPropertiesAreEqual(registerProperties, schema.Properties, format);
        }

        [RecordedTest]
        [TestCase(Avro)]
        [TestCase(Json)]
        [TestCase(Custom)]
        public async Task CanGetSchemaByVersion(string formatName)
        {
            var client = CreateClient(formatName, 2);
            var schemaName = GenerateSchemaName();
            var groupName = (_serviceVersion == SchemaRegistryClientOptions.ServiceVersion.V2022_10) ? TestEnvironment.SchemaRegistryGroup2 : TestEnvironment.SchemaRegistryGroup2021_2;
            var format = StringToSchemaFormat(formatName);
            var content_V1 = StringToSchemaContent(formatName, 1);
            var content_V2 = StringToSchemaContent(formatName, 2);

            var registerPropertiesv1 = await client.RegisterSchemaAsync(groupName, schemaName, content_V1, format);
            AssertSchemaProperties(registerPropertiesv1, schemaName, format, 2);

            var registerPropertiesv2 = await client.RegisterSchemaAsync(groupName, schemaName, content_V2, format);
            AssertSchemaProperties(registerPropertiesv2, schemaName, format, 2);

            SchemaRegistrySchema schemav1 = await client.GetSchemaAsync(groupName, schemaName, 1);
            AssertSchema(schemav1, schemaName, content_V1, format, 2);
            AssertPropertiesAreEqual(registerPropertiesv1, schemav1.Properties, format);

            SchemaRegistrySchema schemav2 = await client.GetSchemaAsync(groupName, schemaName, 2);
            AssertSchema(schemav2, schemaName, content_V2, format, 2);
            AssertPropertiesAreEqual(registerPropertiesv2, schemav2.Properties, format);
        }

        [RecordedTest]

        public void CanCreateRegisterRequestForUnknownFormatType()
        {
            var client = CreateClient("Avro", 2);
            var schemaName = GenerateSchemaName();
            var groupName = (_serviceVersion == SchemaRegistryClientOptions.ServiceVersion.V2022_10) ? TestEnvironment.SchemaRegistryGroup2 : TestEnvironment.SchemaRegistryGroup2021_2;
            var format = new SchemaFormat("UnknownType");
            Assert.That(
                async () => await client.RegisterSchemaAsync(groupName, schemaName, "Hello", format),
                Throws.InstanceOf<RequestFailedException>().And.Property(nameof(RequestFailedException.Status)).EqualTo(403)
                    .And.Property(nameof(RequestFailedException.ErrorCode)).EqualTo("NotAvaliable"));
        }

        [RecordedTest]
        public void CanCreateGetSchemaPropertiesRequestForUnknownFormatType()
        {
            var client = CreateClient("Avro");
            var schemaName = GenerateSchemaName();
            var groupName = (_serviceVersion == SchemaRegistryClientOptions.ServiceVersion.V2022_10) ? TestEnvironment.SchemaRegistryGroup : TestEnvironment.SchemaRegistryGroup2021;
            var format = new SchemaFormat("UnknownType");
            Assert.That(
                async () => await client.GetSchemaPropertiesAsync(groupName, schemaName, "Hello", format),
                Throws.InstanceOf<RequestFailedException>().And.Property(nameof(RequestFailedException.Status)).EqualTo(404)
                    .And.Property(nameof(RequestFailedException.ErrorCode)).EqualTo("ItemNotFound"));
        }

        [RecordedTest]
        public void GetSchemaForNonexistentSchemaIdReturnsItemNotFoundErrorCode()
        {
            var client = CreateClient("Avro");
            Assert.That(
                async () => await client.GetSchemaAsync(Recording.Random.NewGuid().ToString()),
                Throws.InstanceOf<RequestFailedException>().And.Property(nameof(RequestFailedException.Status)).EqualTo(404)
                    .And.Property(nameof(RequestFailedException.ErrorCode)).EqualTo("ItemNotFound"));
        }

        [RecordedTest]
        public void GetSchemaPropertiesForNonexistentSchemaReturnsItemNotFoundErrorCode()
        {
            var client = CreateClient("Avro");
            var schemaName = GenerateSchemaName();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            Assert.That(
                async () => await client.GetSchemaPropertiesAsync(schemaName, groupName, "Hello", SchemaFormat.Avro),
                Throws.InstanceOf<RequestFailedException>().And.Property(nameof(RequestFailedException.Status)).EqualTo(404)
                    .And.Property(nameof(RequestFailedException.ErrorCode)).EqualTo("ItemNotFound"));
        }

        private void AssertSchema(SchemaRegistrySchema schema, string expectedSchemaName, string expectedSchemaContent, SchemaFormat schemaFormat, int group = 1)
        {
            if (_serviceVersion.Equals(SchemaRegistryClientOptions.ServiceVersion.V2021_10) && !schemaFormat.Equals(SchemaFormat.Avro))
            {
                return;
            }
            AssertSchemaProperties(schema.Properties, expectedSchemaName, schemaFormat, group);
            Assert.AreEqual(
                Regex.Replace(expectedSchemaContent, @"\s+", string.Empty),
                Regex.Replace(schema.Definition, @"\s+", string.Empty));
        }

        private void AssertSchemaProperties(SchemaProperties properties, string schemaName, SchemaFormat schemaFormat, int group = 1)
        {
            if (_serviceVersion.Equals(SchemaRegistryClientOptions.ServiceVersion.V2021_10) && !schemaFormat.Equals(SchemaFormat.Avro))
            {
                return;
            }
            Assert.IsNotNull(properties);
            Assert.IsNotNull(properties.Id);
            Assert.IsTrue(Guid.TryParse(properties.Id, out Guid _));
            Assert.AreEqual(schemaFormat, properties.Format);
            Assert.AreEqual(schemaName, properties.Name);
            string expectedGroupName;
            if (_serviceVersion.Equals(SchemaRegistryClientOptions.ServiceVersion.V2022_10))
            {
                expectedGroupName = (group == 1) ? TestEnvironment.SchemaRegistryGroup : TestEnvironment.SchemaRegistryGroup2;
            }
            else
            {
                expectedGroupName = (group == 1) ? TestEnvironment.SchemaRegistryGroup2021 : TestEnvironment.SchemaRegistryGroup2021_2;
            }

            Assert.AreEqual(expectedGroupName, properties.GroupName);
        }

        private void AssertPropertiesAreEqual(SchemaProperties registeredSchema, SchemaProperties schema, SchemaFormat schemaFormat)
        {
            if (_serviceVersion.Equals(SchemaRegistryClientOptions.ServiceVersion.V2021_10) && !schemaFormat.Equals(SchemaFormat.Avro))
            {
                return;
            }
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
                    if (version == 1)
                    {
                        return Custom_SchemaContent;
                    }
                    return Custom_SchemaContent_V2;
                default:
                    throw new ArgumentException("Format name was invalid.");
            }
        }
    }
}
