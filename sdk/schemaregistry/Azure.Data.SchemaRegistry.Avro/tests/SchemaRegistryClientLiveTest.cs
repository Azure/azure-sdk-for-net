// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Data.SchemaRegistry.Tests
{
    public class SchemaRegistryClientLiveTest : RecordedTestBase<SchemaRegistryClientTestEnvironment>
    {
        public SchemaRegistryClientLiveTest(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        //        private SchemaRegistryClient CreateClient()
        //        {
        //            return InstrumentClient(new SchemaRegistryClient(
        //                TestEnvironment.SchemaRegistryUri,
        //                TestEnvironment.Credential,
        //                Recording.InstrumentClientOptions(new SchemaRegistryClientOptions())
        //            ));
        //        }

        //        [Test]
        //        public async Task CanRegisterSchema()
        //        {
        //            var client = CreateClient();
        //            var schemaName = "test1";
        //            var groupName = "miyanni_srgroup";
        //            var schemaType = SerializationType.Avro;
        //            var schema = @"
        //{
        //   ""type"" : ""record"",
        //    ""namespace"" : ""TestSchema"",
        //    ""name"" : ""Employee"",
        //    ""fields"" : [
        //    { ""name"" : ""Name"" , ""type"" : ""string"" },
        //    { ""name"" : ""Age"", ""type"" : ""int"" }
        //    ]
        //}";

        //            var schemaProperties = await client.RegisterSchemaAsync(groupName, schemaName, schema, schemaType);
        //            Assert.IsNotNull(schemaProperties.Value);
        //            Assert.AreEqual(schemaName, schemaProperties.Value.Name);
        //            Assert.AreEqual(groupName, schemaProperties.Value.GroupName);
        //            Assert.AreEqual(schemaType, schemaProperties.Value.Type);
        //            Assert.IsNotNull(schemaProperties.Value.Version);
        //            Assert.IsNotNull(schemaProperties.Value.Id);
        //            Assert.IsTrue(Guid.TryParse(schemaProperties.Value.Id, out Guid _));
        //        }


        //        [Test]
        //        public async Task CanGetSchemaViaContent()
        //        {
        //            var client = CreateClient();
        //            var schemaName = "test1";
        //            var groupName = "miyanni_srgroup";
        //            var schemaType = SerializationType.Avro;
        //            var schema = @"
        //{
        //   ""type"" : ""record"",
        //    ""namespace"" : ""TestSchema"",
        //    ""name"" : ""Employee"",
        //    ""fields"" : [
        //    { ""name"" : ""Name"" , ""type"" : ""string"" },
        //    { ""name"" : ""Age"", ""type"" : ""int"" }
        //    ]
        //}";

        //            await client.RegisterSchemaAsync(groupName, schemaName, schema, schemaType);
        //            var schemaProperties = await client.GetSchemaAsync(groupName, schemaName, schema, schemaType);
        //            Assert.IsNotNull(schemaProperties.Value);
        //            Assert.AreEqual(schemaName, schemaProperties.Value.Name);
        //            Assert.AreEqual(groupName, schemaProperties.Value.GroupName);
        //            Assert.AreEqual(schemaType, schemaProperties.Value.Type);
        //            Assert.IsNotNull(schemaProperties.Value.Version);
        //            Assert.IsNotNull(schemaProperties.Value.Id);
        //            Assert.IsTrue(Guid.TryParse(schemaProperties.Value.Id, out Guid _));
        //        }

        //        [Test]
        //        public async Task CanGetSchemaViaId()
        //        {
        //            var client = CreateClient();
        //            var schemaName = "test1";
        //            var groupName = "miyanni_srgroup";
        //            var schemaType = SerializationType.Avro;
        //            var schema = @"
        //{
        //   ""type"" : ""record"",
        //    ""namespace"" : ""TestSchema"",
        //    ""name"" : ""Employee"",
        //    ""fields"" : [
        //    { ""name"" : ""Name"" , ""type"" : ""string"" },
        //    { ""name"" : ""Age"", ""type"" : ""int"" }
        //    ]
        //}";

        //            var registerProperties = await client.RegisterSchemaAsync(groupName, schemaName, schema, schemaType);
        //            Assert.IsNotNull(registerProperties.Value.Id);
        //            Assert.IsTrue(Guid.TryParse(registerProperties.Value.Id, out Guid _));

        //            var schemaProperties = await client.GetSchemaAsync(registerProperties.Value.Id);
        //            Assert.IsNotNull(schemaProperties.Value);
        //            Assert.AreEqual(schemaName, schemaProperties.Value.Name);
        //            Assert.AreEqual(groupName, schemaProperties.Value.GroupName);
        //            Assert.AreEqual(schemaType, schemaProperties.Value.Type);
        //            Assert.IsNotNull(schemaProperties.Value.Version);
        //            Assert.IsNotNull(schemaProperties.Value.Id);
        //            Assert.IsTrue(Guid.TryParse(schemaProperties.Value.Id, out Guid _));
        //        }
    }
}
