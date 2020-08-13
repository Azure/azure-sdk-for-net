// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Data.SchemaRegistry.Models;
using NUnit.Framework;

namespace Azure.Data.SchemaRegistry.Tests
{
    public class SchemaRegistryClientLiveTest : RecordedTestBase<SchemaRegistryClientTestEnvironment>
    {
        public SchemaRegistryClientLiveTest(bool isAsync) : base(isAsync)
        {
            //TODO: https://github.com/Azure/autorest.csharp/issues/689
            TestDiagnostics = false;
        }

        private SchemaRegistryClient CreateClient()
        {
            return InstrumentClient(new SchemaRegistryClient(
                TestEnvironment.SchemaRegistryUri,
                TestEnvironment.Credential,
                Recording.InstrumentClientOptions(new SchemaRegistryClientOptions())
            ));
        }

        //[Test]
        //public async Task CanGetSecret()
        //{
        //    var client = CreateClient();

        //    var secret = await client.GetSecretAsync("TestSecret");

        //    Assert.AreEqual("Very secret value", secret.Value.Value);
        //}

        [Test]
        public async Task CanRegisterSchema()
        {
            var client = CreateClient();

            var schema = @"
{
   ""type"" : ""record"",
    ""namespace"" : ""TestSchema"",
    ""name"" : ""Employee"",
    ""fields"" : [
    { ""name"" : ""Name"" , ""type"" : ""string"" },
    { ""name"" : ""Age"", ""type"" : ""int"" }
    ]
}";

            var schemaProperties = await client.RegisterSchemaAsync("miyanni_srgroup", "test1", schema, SerializationType.Avro);

            Assert.IsNotNull(schemaProperties.Value);
            Assert.AreEqual("test1", schemaProperties.Value.Name);
            Assert.AreEqual("miyanni_srgroup", schemaProperties.Value.GroupName);
            Assert.AreEqual(SerializationType.Avro, schemaProperties.Value.Type);
            Assert.AreEqual(1, schemaProperties.Value.Version);
            Assert.IsNotNull(schemaProperties.Value.Id);
            Assert.IsTrue(Guid.TryParse(schemaProperties.Value.Id, out Guid _));
        }
    }
}
