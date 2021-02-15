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
    public class Sample01_ReadmeSnippets : SamplesBase<SchemaRegistryClientTestEnvironment>
    {
#pragma warning disable IDE1006 // Naming Styles
        private SchemaRegistryClient schemaRegistryClient;
#pragma warning restore IDE1006 // Naming Styles
        private byte[] _memoryStreamBytes;

        [OneTimeSetUp]
        public void CreateSchemaRegistryClient()
        {
            string endpoint = TestEnvironment.SchemaRegistryEndpoint;

            #region Snippet:SchemaRegistryAvroCreateSchemaRegistryClient
            // Create a new SchemaRegistry client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            // For more information on Azure.Identity usage, see: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
            var schemaRegistryClient = new SchemaRegistryClient(endpoint: endpoint, credential: new DefaultAzureCredential());
            #endregion

            this.schemaRegistryClient = schemaRegistryClient;
        }

        [Test]
        [Order(1)]
        public void Serialize()
        {
            string groupName = TestEnvironment.SchemaRegistryGroup;

            #region Snippet:SchemaRegistryAvroSerialize
            var employee = new Employee { Age = 42, Name = "John Doe" };

            using var memoryStream = new MemoryStream();
            var serializer = new SchemaRegistryAvroObjectSerializer(schemaRegistryClient, groupName, new SchemaRegistryAvroObjectSerializerOptions { AutoRegisterSchemas = true });
            serializer.Serialize(memoryStream, employee, typeof(Employee), CancellationToken.None);
            #endregion

            Assert.IsTrue(memoryStream.Length > 0);
            _memoryStreamBytes = memoryStream.ToArray();
        }

        [Test]
        [Order(2)]
        public void Deserialize()
        {
            using var memoryStream = new MemoryStream(_memoryStreamBytes);
            string groupName = TestEnvironment.SchemaRegistryGroup;

            #region Snippet:SchemaRegistryAvroDeserialize
            var serializer = new SchemaRegistryAvroObjectSerializer(schemaRegistryClient, groupName, new SchemaRegistryAvroObjectSerializerOptions { AutoRegisterSchemas = true });
            memoryStream.Position = 0;
            Employee employee = (Employee)serializer.Deserialize(memoryStream, typeof(Employee), CancellationToken.None);
            #endregion

            Assert.AreEqual(42, employee.Age);
            Assert.AreEqual("John Doe", employee.Name);
        }
    }
}
