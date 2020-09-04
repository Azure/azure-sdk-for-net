// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Data.SchemaRegistry.Tests.Samples
{
#pragma warning disable SA1649 // File name should match first type name
    public class SchemaRegistryReadmeSnippets : SamplesBase<SchemaRegistryClientTestEnvironment>
#pragma warning restore SA1649 // File name should match first type name
    {
        [Ignore("Only verifying that the sample builds")]
        [Test]
        public void CreateSchemaRegistryClient()
        {
            #region Snippet:CreateSchemaRegistryClient
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

            #region Snippet:RegisterSchema
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
        public void GetSchemaId()
        {
            var client = new SchemaRegistryClient(TestEnvironment.SchemaRegistryUri, TestEnvironment.Credential);

            #region Snippet:GetSchemaId
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
        public void GetSchema()
        {
            var client = new SchemaRegistryClient(TestEnvironment.SchemaRegistryUri, TestEnvironment.Credential);

            #region Snippet:GetSchema
            string schemaId = "<schema_id>";

            Response<SchemaProperties> schemaProperties = client.GetSchema(schemaId);
            string schemaContent = schemaProperties.Value.Content;
            #endregion
        }
    }
}
