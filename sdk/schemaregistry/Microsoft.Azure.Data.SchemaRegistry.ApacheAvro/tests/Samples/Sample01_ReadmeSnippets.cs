// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Data.SchemaRegistry;
using Azure.Identity;
using NUnit.Framework;
using System.IO;
using System.Threading;
using TestSchema;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.Tests.Samples
{
    [Ignore("Only verifying that the sample builds")]
    public class Sample01_ReadmeSnippets : SamplesBase<SchemaRegistryClientTestEnvironment>
    {
        [Ignore("Only verifying that the sample builds")]
        [Test]
        public void CreateSchemaRegistryClient()
        {
            #region Snippet:SchemaRegistryAvroCreateSchemaRegistryClient
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
        public void Serialize()
        {
            var client = new SchemaRegistryClient(TestEnvironment.SchemaRegistryUri, TestEnvironment.Credential);

            #region Snippet:SchemaRegistryAvroSerialize
            var employee = new Employee { Age = 42, Name = "John Doe" };
            string groupName = "<schema_group_name>";

            using var memoryStream = new MemoryStream();
            var serializer = new SchemaRegistryAvroObjectSerializer(client, groupName, new SchemaRegistryAvroObjectSerializerOptions { AutoRegisterSchemas = true });
            serializer.Serialize(memoryStream, employee, typeof(Employee), CancellationToken.None);
            #endregion
        }

        [Ignore("Only verifying that the sample builds")]
        [Test]
        public void Deserialize()
        {
            var client = new SchemaRegistryClient(TestEnvironment.SchemaRegistryUri, TestEnvironment.Credential);
            using var memoryStream = new MemoryStream();

            #region Snippet:SchemaRegistryAvroDeserialize
            string groupName = "<schema_group_name>";

            var serializer = new SchemaRegistryAvroObjectSerializer(client, groupName, new SchemaRegistryAvroObjectSerializerOptions { AutoRegisterSchemas = true });
            memoryStream.Position = 0;
            Employee employee = (Employee)serializer.Deserialize(memoryStream, typeof(Employee), CancellationToken.None);
            #endregion
        }
    }
}
