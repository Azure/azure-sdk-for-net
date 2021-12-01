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
using Azure.Messaging.ServiceBus;
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

            var encoder = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroObjectEncoderOptions { AutoRegisterSchemas = true });
            (string schemaId, BinaryData data) = await encoder.EncodeAsync(record, typeof(GenericRecord), CancellationToken.None);

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

            var serializer = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroObjectEncoderOptions { AutoRegisterSchemas = true });
            Assert.ThrowsAsync<ArgumentException>(async () => await serializer.DecodeAsync(new BinaryData(Array.Empty<byte>()), "fakeSchemaId", typeof(TimeZoneInfo), CancellationToken.None));
            await Task.CompletedTask;
        }

        [RecordedTest]
        public async Task CannotDeserializeWithNullSchemaId()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var serializer = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroObjectEncoderOptions { AutoRegisterSchemas = true });
            Assert.ThrowsAsync<ArgumentNullException>(async () => await serializer.DecodeAsync(new BinaryData(Array.Empty<byte>()), null, typeof(TimeZoneInfo), CancellationToken.None));
            await Task.CompletedTask;
        }

        [RecordedTest]
        public async Task CanUseEncoderWithEventData()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            #region Snippet:SchemaRegistryAvroEncodeEventData
            var encoder = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroObjectEncoderOptions { AutoRegisterSchemas = true });

            var employee = new Employee { Age = 42, Name = "Caketown" };
            EventData eventData = await encoder.EncodeMessageDataAsync<EventData>(employee);

#if SNIPPET
            // the schema Id will be included as a parameter of the content type
            Console.WriteLine(eventData.ContentType);

            // the serialized Avro data will be stored in the EventBody
            Console.WriteLine(eventData.EventBody);
#endif
            #endregion

            string[] contentType = eventData.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("avro/binary", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

#if SNIPPET
            #region Snippet:SchemaRegistryAvroDecodeEventData
            Employee deserialized = (Employee)await encoder.DecodeMessageDataAsync(eventData, typeof(Employee));
            Console.WriteLine(deserialized.Age);
            Console.WriteLine(deserialized.Name);
            #endregion
#endif

            // decoding should not alter the message
            contentType = eventData.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("avro/binary", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

            // verify the payload was decoded correctly
            Assert.IsNotNull(deserialized);
            Assert.AreEqual("Caketown", deserialized.Name);
            Assert.AreEqual(42, deserialized.Age);
        }

        [RecordedTest]
        public async Task CanUseEncoderWithEventDataUsingFunc()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var encoder = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroObjectEncoderOptions { AutoRegisterSchemas = true });

            var employee = new Employee { Age = 42, Name = "Caketown" };
            EventData message = await encoder.EncodeMessageDataAsync(employee, messageFactory: bd => new EventData(bd));

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

        [RecordedTest]
        public async Task CanUseEncoderWithServiceBusMessage()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var encoder = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroObjectEncoderOptions { AutoRegisterSchemas = true });

            var employee = new Employee { Age = 42, Name = "Caketown" };
            ServiceBusMessage message = await encoder.EncodeMessageDataAsync<ServiceBusMessage>(employee);

            string[] contentType = message.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("avro/binary", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

            ServiceBusReceivedMessage receivedMessage =
                ServiceBusModelFactory.ServiceBusReceivedMessage(body: message.Body, contentType: message.ContentType);

            Employee deserialized = (Employee)await encoder.DecodeMessageDataAsync(receivedMessage, typeof(Employee));

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

        [RecordedTest]
        public async Task CanUseEncoderWithServiceBusMessageUsingFunc()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var encoder = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroObjectEncoderOptions { AutoRegisterSchemas = true });

            var employee = new Employee { Age = 42, Name = "Caketown" };
            ServiceBusMessage message = await encoder.EncodeMessageDataAsync(employee, messageFactory: bd => new ServiceBusMessage(bd));

            string[] contentType = message.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("avro/binary", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

            ServiceBusReceivedMessage receivedMessage =
                ServiceBusModelFactory.ServiceBusReceivedMessage(body: message.Body, contentType: message.ContentType);

            Employee deserialized = (Employee)await encoder.DecodeMessageDataAsync(receivedMessage, typeof(Employee));

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
