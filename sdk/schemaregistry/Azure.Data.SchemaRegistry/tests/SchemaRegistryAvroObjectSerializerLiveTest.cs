// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Data.SchemaRegistry.Avro;
using NUnit.Framework;
using TestSchema;

namespace Azure.Data.SchemaRegistry.Tests
{
    public class SchemaRegistryAvroObjectSerializerLiveTest : RecordedTestBase<SchemaRegistryClientTestEnvironment>
    {
        public SchemaRegistryAvroObjectSerializerLiveTest(bool isAsync) : base(isAsync)
        {
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

        [Test]
        public async Task CanSerializeAndDeserialize()
        {
            var client = CreateClient();
            var groupName = "miyanni_srgroup";
            var employee = new Employee { Age = 42, Name = "Caketown" };

            var memoryStream = new MemoryStream();
            var serializer = new SchemaRegistryAvroObjectSerializer(client, groupName, new SchemaRegistryAvroObjectSerializerOptions { AutoRegisterSchemas = true });
            await serializer.SerializeAsync(memoryStream, employee, typeof(Employee), CancellationToken.None);

            var deserializedObject = await serializer.DeserializeAsync(memoryStream, typeof(Employee), CancellationToken.None);
            var readEmployee = deserializedObject as Employee;
            Assert.IsNotNull(readEmployee);
            Assert.AreEqual("Caketown", readEmployee.Name);
            Assert.AreEqual(42, readEmployee.Age);
        }
    }
}
