// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Data.SchemaRegistry.Tests.Samples
{
    public class Sample02_HelloWorld : SamplesBase<SchemaRegistryClientTestEnvironment>
    {
#pragma warning disable IDE1006 // Naming Styles
        private SchemaRegistryClient client;
#pragma warning restore IDE1006 // Naming Styles
        private SchemaProperties _schemaProperties;
        private string _definition;

        [OneTimeSetUp]
        public void CreateSchemaRegistryClient()
        {
            string fullyQualifiedNamespace = TestEnvironment.SchemaRegistryEndpointAvro;

            // Create a new SchemaRegistry client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            // For more information on Azure.Identity usage, see: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
            var client = new SchemaRegistryClient(fullyQualifiedNamespace: fullyQualifiedNamespace, credential: new DefaultAzureCredential());

            this.client = client;
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

            Response<SchemaProperties> schemaProperties = client.RegisterSchema(groupName, name, definition, format);
            #endregion

            Assert.NotNull(schemaProperties);
            _schemaProperties = schemaProperties.Value;
            _definition = definition;
        }

        [Test]
        [Order(2)]
        public void RetrieveSchemaAvro()
        {
            var schemaId = _schemaProperties.Id;

            #region Snippet:SchemaRegistryRetrieveSchemaAvro
            SchemaRegistrySchema schema = client.GetSchema(schemaId);
            string definition = schema.Definition;
            #endregion

            Assert.AreEqual(Regex.Replace(_definition, @"\s+", string.Empty), definition);
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
            },
            required: [""name"", ""favoriteNumber""],
            }";

            Response<SchemaProperties> schemaProperties = client.RegisterSchema(groupName, name, definition, format);
            #endregion

            Assert.NotNull(schemaProperties);
            _schemaProperties = schemaProperties.Value;
            _definition = definition;
        }

        [Test]
        [Order(4)]
        public void RetrieveSchemaJson()
        {
            var schemaId = _schemaProperties.Id;

            #region Snippet:SchemaRegistryRetrieveSchemaJson
            SchemaRegistrySchema schema = client.GetSchema(schemaId);
            string definition = schema.Definition;
            #endregion

            Assert.AreEqual(Regex.Replace(_definition, @"\s+", string.Empty), definition);
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

            Response<SchemaProperties> schemaProperties = client.RegisterSchema(groupName, name, definition, format);
            #endregion

            Assert.NotNull(schemaProperties);
            _schemaProperties = schemaProperties.Value;
            _definition = definition;
        }

        [Test]
        [Order(6)]
        public void RetrieveSchemaCustom()
        {
            var schemaId = _schemaProperties.Id;

            #region Snippet:SchemaRegistryRetrieveSchemaCustom
            SchemaRegistrySchema schema = client.GetSchema(schemaId);
            string definition = schema.Definition;
            #endregion

            Assert.AreEqual(Regex.Replace(_definition, @"\s+", string.Empty), definition);
        }
    }
}
