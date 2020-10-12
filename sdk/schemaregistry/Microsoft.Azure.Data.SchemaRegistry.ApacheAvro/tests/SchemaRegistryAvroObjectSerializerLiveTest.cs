// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Avro;
using Avro.Generic;
using Azure.Core.TestFramework;
using Azure.Data.SchemaRegistry;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TestSchema;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.Tests
{
    public class SchemaRegistryAvroObjectSerializerLiveTest : RecordedTestBase<SchemaRegistryClientTestEnvironment>
    {
        public SchemaRegistryAvroObjectSerializerLiveTest(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        private SchemaRegistryClient CreateClient() =>
            InstrumentClient(new SchemaRegistryClient(
                TestEnvironment.SchemaRegistryUri,
                TestEnvironment.Credential,
                InstrumentClientOptions(new SchemaRegistryClientOptions())
            ));

        [Test]
        [PlaybackOnly("Service not provisioned to all regions yet.")]
        public async Task CanSerializeAndDeserialize()
        {
            var client = CreateClient();
            var groupName = "miyanni_srgroup";
            var employee = new Employee { Age = 42, Name = "Caketown" };

            using var memoryStream = new MemoryStream();
            var serializer = new SchemaRegistryAvroObjectSerializer(client, groupName, new SchemaRegistryAvroObjectSerializerOptions { AutoRegisterSchemas = true });
            await serializer.SerializeAsync(memoryStream, employee, typeof(Employee), CancellationToken.None);

            memoryStream.Position = 0;
            var deserializedObject = await serializer.DeserializeAsync(memoryStream, typeof(Employee), CancellationToken.None);
            var readEmployee = deserializedObject as Employee;
            Assert.IsNotNull(readEmployee);
            Assert.AreEqual("Caketown", readEmployee.Name);
            Assert.AreEqual(42, readEmployee.Age);
        }

        [Test]
        [PlaybackOnly("Service not provisioned to all regions yet.")]
        public async Task CanSerializeAndDeserializeGenericRecord()
        {
            var client = CreateClient();
            var groupName = "miyanni_srgroup";
            var record = new GenericRecord((RecordSchema)Employee._SCHEMA);
            record.Add("Name", "Caketown");
            record.Add("Age", 42);

            using var memoryStream = new MemoryStream();
            var serializer = new SchemaRegistryAvroObjectSerializer(client, groupName, new SchemaRegistryAvroObjectSerializerOptions { AutoRegisterSchemas = true });
            await serializer.SerializeAsync(memoryStream, record, typeof(GenericRecord), CancellationToken.None);

            memoryStream.Position = 0;
            var deserializedObject = await serializer.DeserializeAsync(memoryStream, typeof(GenericRecord), CancellationToken.None);
            var readRecord = deserializedObject as GenericRecord;
            Assert.IsNotNull(readRecord);
            Assert.AreEqual("Caketown", readRecord.GetValue(0));
            Assert.AreEqual(42, readRecord.GetValue(1));
        }

        [Test]
        [PlaybackOnly("Service not provisioned to all regions yet.")]
        public async Task CannotSerializeUnsupportedType()
        {
            var client = CreateClient();
            var groupName = "miyanni_srgroup";
            var timeZoneInfo = TimeZoneInfo.Utc;

            using var memoryStream = new MemoryStream();
            var serializer = new SchemaRegistryAvroObjectSerializer(client, groupName, new SchemaRegistryAvroObjectSerializerOptions { AutoRegisterSchemas = true });
            Assert.ThrowsAsync<ArgumentException>(async () => await serializer.SerializeAsync(memoryStream, timeZoneInfo, typeof(TimeZoneInfo), CancellationToken.None));
            await Task.CompletedTask;
        }

        [Test]
        [PlaybackOnly("Service not provisioned to all regions yet.")]
        public async Task CannotDeserializeUnsupportedType()
        {
            var client = CreateClient();
            var groupName = "miyanni_srgroup";

            using var memoryStream = new MemoryStream();
            var serializer = new SchemaRegistryAvroObjectSerializer(client, groupName, new SchemaRegistryAvroObjectSerializerOptions { AutoRegisterSchemas = true });
            Assert.ThrowsAsync<ArgumentException>(async () => await serializer.DeserializeAsync(memoryStream, typeof(TimeZoneInfo), CancellationToken.None));
            await Task.CompletedTask;
        }
    }
}
