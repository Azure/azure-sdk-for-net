// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Data.SchemaRegistry.Tests.Samples
{
    [Ignore("Only verifying that the sample builds")]
    public class Sample01_ReadmeSnippets : SamplesBase<SchemaRegistryClientTestEnvironment>
    {
        [Ignore("Only verifying that the sample builds")]
        [Test]
        public void CreateSchemaRegistryClient()
        {
            #region Snippet:SchemaRegistryCreateSchemaRegistryClient
            string endpoint = "<event_hubs_namespace_hostname>";
            var credentials = new ClientSecretCredential(
                "<tenant_id>",
                "<client_id>",
                "<client_secret>"
            );
            var client = new SchemaRegistryClient(endpoint, credentials);
            #endregion
        }

        [Ignore("Only verifying that the sample builds")]
        [Test]
        public void RegisterSchema()
        {
            var client = new SchemaRegistryClient(TestEnvironment.SchemaRegistryUri, TestEnvironment.Credential);

            #region Snippet:SchemaRegistryRegisterSchema
            string schemaName = "<schema_name>";
            string groupName = "<schema_group_name>";
            SerializationType schemaType = SerializationType.Avro;
            // Example schema's content
            string schemaContent = @"
            {
               ""type"" : ""record"",
                ""namespace"" : ""TestSchema"",
                ""name"" : ""Employee"",
                ""fields"" : [
                { ""name"" : ""Name"" , ""type"" : ""string"" },
                { ""name"" : ""Age"", ""type"" : ""int"" }
                ]
            }";

            Response<SchemaProperties> schemaProperties = client.RegisterSchema(groupName, schemaName, schemaType, schemaContent);
            #endregion
        }

        [Ignore("Only verifying that the sample builds")]
        [Test]
        public void RetrieveSchemaId()
        {
            var client = new SchemaRegistryClient(TestEnvironment.SchemaRegistryUri, TestEnvironment.Credential);

            #region Snippet:SchemaRegistryRetrieveSchemaId
            string schemaName = "<schema_name>";
            string groupName = "<schema_group_name>";
            SerializationType schemaType = SerializationType.Avro;
            // Example schema's content
            string schemaContent = @"
            {
               ""type"" : ""record"",
                ""namespace"" : ""TestSchema"",
                ""name"" : ""Employee"",
                ""fields"" : [
                { ""name"" : ""Name"" , ""type"" : ""string"" },
                { ""name"" : ""Age"", ""type"" : ""int"" }
                ]
            }";

            Response<SchemaProperties> schemaProperties = client.GetSchemaId(groupName, schemaName, schemaType, schemaContent);
            string schemaId = schemaProperties.Value.Id;
            #endregion
        }

        [Ignore("Only verifying that the sample builds")]
        [Test]
        public void RetrieveSchema()
        {
            var client = new SchemaRegistryClient(TestEnvironment.SchemaRegistryUri, TestEnvironment.Credential);

            #region Snippet:SchemaRegistryRetrieveSchema
            string schemaId = "<schema_id>";

            Response<SchemaProperties> schemaProperties = client.GetSchema(schemaId);
            string schemaContent = schemaProperties.Value.Content;
            #endregion
        }
    }
}
