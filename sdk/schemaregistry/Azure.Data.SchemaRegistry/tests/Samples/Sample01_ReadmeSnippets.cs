// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Data.SchemaRegistry.Tests.Samples
{
    public class Sample01_ReadmeSnippets : SamplesBase<SchemaRegistryClientTestEnvironment>
    {
#pragma warning disable IDE1006 // Naming Styles
        private SchemaRegistryClient client;
#pragma warning restore IDE1006 // Naming Styles
        private SchemaProperties _schemaProperties;
        private string _definition;

        [OneTimeSetUp]
        public void CreateSchemaRegistryClient()
        {
            string fullyQualifiedNamespace = TestEnvironment.SchemaRegistryEndpointAvro4;

            #region Snippet:SchemaRegistryCreateSchemaRegistryClient
            // Create a new SchemaRegistry client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            // For more information on Azure.Identity usage, see: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
            var client = new SchemaRegistryClient(fullyQualifiedNamespace: fullyQualifiedNamespace, credential: new DefaultAzureCredential());
            #endregion

            this.client = client;
        }

        [Test]
        [Order(1)]
        public void RegisterSchema()
        {
            string groupName = TestEnvironment.SchemaRegistryGroup;

            #region Snippet:SchemaRegistryRegisterSchema
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
        public void RetrieveSchemaId()
        {
            string groupName = TestEnvironment.SchemaRegistryGroup;

            #region Snippet:SchemaRegistryRetrieveSchemaId
            string name = "employeeSample";
            SchemaFormat format = SchemaFormat.Avro;
            // Example schema's content
            string content = @"
            {
               ""type"" : ""record"",
                ""namespace"" : ""TestSchema"",
                ""name"" : ""Employee"",
                ""fields"" : [
                { ""name"" : ""Name"" , ""type"" : ""string"" },
                { ""name"" : ""Age"", ""type"" : ""int"" }
                ]
            }";

            SchemaProperties schemaProperties = client.GetSchemaProperties(groupName, name, content, format);
            string schemaId = schemaProperties.Id;
            #endregion

            Assert.AreEqual(_schemaProperties.Id, schemaId);
        }

        [Test]
        [Order(3)]
        public void RetrieveSchema()
        {
            var schemaId = _schemaProperties.Id;

            #region Snippet:SchemaRegistryRetrieveSchema
            SchemaRegistrySchema schema = client.GetSchema(schemaId);
            string definition = schema.Definition;
            #endregion

            Assert.AreEqual(Regex.Replace(_definition, @"\s+", string.Empty), definition);
        }

        [Test]
        [Order(4)]
        public void RetrieveSchemaVersion()
        {
            string groupName = _schemaProperties.GroupName;
            string name = _schemaProperties.Name;
            int version = 1;

            #region Snippet:SchemaRegistryRetrieveSchemaVersion
            SchemaRegistrySchema schema = client.GetSchema(groupName, name, version);
            string definition = schema.Definition;
            #endregion

            Assert.AreEqual(Regex.Replace(_definition, @"\s+", string.Empty), definition);
        }
    }
}
