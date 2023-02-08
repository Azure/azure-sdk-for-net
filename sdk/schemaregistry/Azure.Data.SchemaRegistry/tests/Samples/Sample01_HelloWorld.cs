// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;
using static Azure.Data.SchemaRegistry.SchemaRegistryClientOptions;

namespace Azure.Data.SchemaRegistry.Tests.Samples
{
    public class Sample01_HelloWorld : SamplesBase<SchemaRegistryClientTestEnvironment>
    {
#pragma warning disable IDE1006 // Naming Styles
        private SchemaRegistryClient avroClient;
        private SchemaRegistryClient jsonClient;
        private SchemaRegistryClient customClient;
#pragma warning restore IDE1006 // Naming Styles

        private SchemaProperties _avroSchemaProperties;
        private string _avroDefinition;

        private SchemaProperties _jsonSchemaProperties;
        private string _jsonDefinition;

        private SchemaProperties _customSchemaProperties;
        private string _customDefinition;

        private const string _avro = "Avro";
        private const string _json = "Json";
        private const string _custom = "Custom";

        [OneTimeSetUp]
        public void CreateSchemaRegistryClients()
        {
            avroClient = CreateClient(_avro);
            jsonClient = CreateClient(_json);
            customClient = CreateClient(_custom);
        }

        private SchemaRegistryClient CreateClient(string format)
        {
            string endpoint;
            switch (format)
            {
                case _json:
                    endpoint = TestEnvironment.SchemaRegistryEndpointJson4;
                    break;
                case _custom:
                    endpoint = TestEnvironment.SchemaRegistryEndpointCustom4;
                    break;
                default:
                    endpoint = TestEnvironment.SchemaRegistryEndpointAvro4;
                    break;
            }

            // Create a new SchemaRegistry client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            // For more information on Azure.Identity usage, see: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
            return new SchemaRegistryClient(fullyQualifiedNamespace: endpoint, credential: new DefaultAzureCredential());
        }

        [Test]
        [Order(1)]
        public void RegisterSchemaAvro()
        {
            string groupName = TestEnvironment.SchemaRegistryGroup;

            #region Snippet:SchemaRegistryRegisterSchemaAvro
            string name = "employeeSample";
            SchemaFormat format = SchemaFormat.Avro;
            // Example schema's definition
            string definition = @"
            {
               ""type"" : ""record"",
                ""namespace"" : ""TestSchema"",
                ""name"" : ""Employee"",
                ""fields"" : [
                { ""name"" : ""Name"" , ""type"" : ""string"" },
                { ""name"" : ""Age"", ""type"" : ""int"" }
                ]
            }";

            Response<SchemaProperties> schemaProperties = avroClient.RegisterSchema(groupName, name, definition, format);
            #endregion

            Assert.NotNull(schemaProperties);
            _avroSchemaProperties = schemaProperties.Value;
            _avroDefinition = definition;
        }

        [Test]
        [Order(2)]
        public void RetrieveSchemaAvro()
        {
            var schemaId = _avroSchemaProperties.Id;

            #region Snippet:SchemaRegistryRetrieveSchemaAvro
            SchemaRegistrySchema schema = avroClient.GetSchema(schemaId);
            string definition = schema.Definition;
            #endregion

            Assert.AreEqual(Regex.Replace(_avroDefinition, @"\s+", string.Empty), definition);
        }

        [Test]
        [Order(3)]
        public void RegisterSchemaJson()
        {
            string groupName = TestEnvironment.SchemaRegistryGroup;

            #region Snippet:SchemaRegistryRegisterSchemaJson
            string name = "employeeSample";
            SchemaFormat format = SchemaFormat.Json;
            // Example schema's definition
            string definition = @"
            {
                $schema: ""https://json-schema.org/draft/2020-12/schema"",
                $id: ""https://example.com/product.schema.json"",
                title: ""Product"",
                description: ""A product from the catalog"",
                type: ""object"",
                properties: {
                    name: {
                        type: ""string"",
                        required: true,
                    },
                    favoriteNumber: {
                        type: ""integer"",
                        required: true,
                    },
                }
            }";

            Response<SchemaProperties> schemaProperties = jsonClient.RegisterSchema(groupName, name, definition, format);
            #endregion

            Assert.NotNull(schemaProperties);
            _jsonSchemaProperties = schemaProperties.Value;
            _jsonDefinition = definition;
        }

        [Test]
        [Order(4)]
        public void RetrieveSchemaJson()
        {
            var schemaId = _jsonSchemaProperties.Id;

            #region Snippet:SchemaRegistryRetrieveSchemaJson
            SchemaRegistrySchema schema = jsonClient.GetSchema(schemaId);
            string definition = schema.Definition;
            #endregion

            Assert.AreEqual(_jsonDefinition, definition);
        }

        [Test]
        [Order(5)]
        public void RegisterSchemaCustom()
        {
            string groupName = TestEnvironment.SchemaRegistryGroup;

            #region Snippet:SchemaRegistryRegisterSchemaCustom
            string name = "employeeSample";
            SchemaFormat format = SchemaFormat.Custom;
            // Example schema's definition
            string definition = @"
            {
                NAME: string
                OCCUPATION: string
                EMAIL: string
            }";

            Response<SchemaProperties> schemaProperties = customClient.RegisterSchema(groupName, name, definition, format);
            #endregion

            Assert.NotNull(schemaProperties);
            _customSchemaProperties = schemaProperties.Value;
            _customDefinition = definition;
        }

        [Test]
        [Order(6)]
        public void RetrieveSchemaCustom()
        {
            var schemaId = _customSchemaProperties.Id;

            #region Snippet:SchemaRegistryRetrieveSchemaCustom
            SchemaRegistrySchema schema = customClient.GetSchema(schemaId);
            string definition = schema.Definition;
            #endregion

            Assert.AreEqual(_customDefinition, definition);
        }
    }
}
