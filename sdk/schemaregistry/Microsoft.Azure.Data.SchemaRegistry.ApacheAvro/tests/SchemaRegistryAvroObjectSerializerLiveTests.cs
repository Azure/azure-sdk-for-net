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
using Azure.Messaging.EventHubs;
using TestSchema;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.Tests
{
    public class SchemaRegistryAvroObjectSerializerLiveTests : RecordedTestBase<SchemaRegistryClientTestEnvironment>
    {
        public SchemaRegistryAvroObjectSerializerLiveTests(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        private SchemaRegistryClient CreateClient() =>
            InstrumentClient(new SchemaRegistryClient(
                TestEnvironment.SchemaRegistryEndpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new SchemaRegistryClientOptions())
            ));

        [RecordedTest]
        public async Task CanSerializeAndDeserialize()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new Employee { Age = 42, Name = "Caketown" };

            var encoder = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroObjectEncoderOptions() { AutoRegisterSchemas = true });
            (string schemaId, BinaryData data) = await encoder.EncodeAsync(employee, typeof(Employee), CancellationToken.None);

            var deserializedObject = await encoder.DecodeAsync(data, schemaId, typeof(Employee), CancellationToken.None);
            var readEmployee = deserializedObject as Employee;
            Assert.IsNotNull(readEmployee);
            Assert.AreEqual("Caketown", readEmployee.Name);
            Assert.AreEqual(42, readEmployee.Age);
        }

        [RecordedTest]
        public async Task CanSerializeAndDeserializeGenericRecord()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var record = new GenericRecord((RecordSchema)Employee._SCHEMA);
            record.Add("Name", "Caketown");
            record.Add("Age", 42);

            using var memoryStream = new MemoryStream();
            var encoder = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroObjectEncoderOptions { AutoRegisterSchemas = true });
            (string schemaId, BinaryData data) = await encoder.EncodeAsync(record, typeof(GenericRecord), CancellationToken.None);

            memoryStream.Position = 0;
            var deserializedObject = await encoder.DecodeAsync(data, schemaId, typeof(GenericRecord), CancellationToken.None);
            var readRecord = deserializedObject as GenericRecord;
            Assert.IsNotNull(readRecord);
            Assert.AreEqual("Caketown", readRecord.GetValue(0));
            Assert.AreEqual(42, readRecord.GetValue(1));
        }

        [RecordedTest]
        public async Task CannotSerializeUnsupportedType()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var timeZoneInfo = TimeZoneInfo.Utc;

            var encoder = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroObjectEncoderOptions { AutoRegisterSchemas = true });
            Assert.ThrowsAsync<ArgumentException>(async () => await encoder.EncodeAsync(timeZoneInfo, typeof(TimeZoneInfo), CancellationToken.None));
            await Task.CompletedTask;
        }

        [RecordedTest]
        public async Task CannotDeserializeUnsupportedType()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            using var memoryStream = new MemoryStream();
            var serializer = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroObjectEncoderOptions { AutoRegisterSchemas = true });
            Assert.ThrowsAsync<ArgumentException>(async () => await serializer.DecodeAsync(new BinaryData(Array.Empty<byte>()), "fakeSchemaId", typeof(TimeZoneInfo), CancellationToken.None));
            await Task.CompletedTask;
        }

        [RecordedTest]
        public async Task CannotDeserializeWithNullSchemaId()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            using var memoryStream = new MemoryStream();
            var serializer = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroObjectEncoderOptions { AutoRegisterSchemas = true });
            Assert.ThrowsAsync<ArgumentNullException>(async () => await serializer.DecodeAsync(new BinaryData(Array.Empty<byte>()), null, typeof(TimeZoneInfo), CancellationToken.None));
            await Task.CompletedTask;
        }

        [RecordedTest]
        public async Task CanUseEncoderWithEventData()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            using var memoryStream = new MemoryStream();
            var encoder = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroObjectEncoderOptions { AutoRegisterSchemas = true });

            var employee = new Employee { Age = 42, Name = "Caketown" };
            var message = new EventData();
            await encoder.EncodeMessageDataAsync(message, employee);

            string[] contentType = message.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("avro/binary", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

            Employee deserialized = (Employee)await encoder.DecodeMessageDataAsync(message, typeof(Employee));

            // decoding should not alter the message
            contentType = message.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("avro/binary", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

            // verify the payload was decoded correctly
            Assert.IsNotNull(deserialized);
            Assert.AreEqual("Caketown", deserialized.Name);
            Assert.AreEqual(42, deserialized.Age);
        }
    }
}
