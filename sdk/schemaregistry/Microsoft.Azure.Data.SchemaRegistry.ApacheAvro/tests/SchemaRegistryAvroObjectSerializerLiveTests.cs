// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Avro;
using Avro.Generic;
using Azure.Core.TestFramework;
using Azure.Data.SchemaRegistry;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Messaging;
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

            #region Snippet:SchemaRegistryAvroEncodeDecodeMessageWithMetadata
            var encoder = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroEncoderOptions { AutoRegisterSchemas = true });
            MessageWithMetadata messageData = await encoder.EncodeMessageDataAsync<MessageWithMetadata, Employee>(employee);

            Employee decodedEmployee = await encoder.DecodeMessageDataAsync<Employee>(messageData);
            #endregion

            Assert.IsNotNull(decodedEmployee);
            Assert.AreEqual("Caketown", decodedEmployee.Name);
            Assert.AreEqual(42, decodedEmployee.Age);
        }

        [RecordedTest]
        public async Task CanSerializeAndDeserializeWithCompatibleSchema()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new Employee_V2 { Age = 42, Name = "Caketown", City = "Redmond" };

            var encoder = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroEncoderOptions { AutoRegisterSchemas = true });
            var messageData = await encoder.EncodeMessageDataAsync<MessageWithMetadata, Employee_V2>(employee);

            // deserialize using the old schema, which is forward compatible with the new schema
            // if you swap the old schema and the new schema in your mind, then this can also be thought as a backwards compatible test
            var deserializedObject = await encoder.DecodeMessageDataAsync<Employee>(messageData);
            var readEmployee = deserializedObject as Employee;
            Assert.IsNotNull(readEmployee);
            Assert.AreEqual("Caketown", readEmployee.Name);
            Assert.AreEqual(42, readEmployee.Age);

            // deserialize using the new schema to make sure we are respecting it
            var readEmployeeV2 = await encoder.DecodeMessageDataAsync<Employee_V2>(messageData);
            Assert.IsNotNull(readEmployee);
            Assert.AreEqual("Caketown", readEmployeeV2.Name);
            Assert.AreEqual(42, readEmployeeV2.Age);
            Assert.AreEqual("Redmond", readEmployeeV2.City);
        }

        [RecordedTest]
        public async Task CannotDeserializeIntoNonCompatibleType()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new Employee() { Age = 42, Name = "Caketown"};

            var encoder = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroEncoderOptions { AutoRegisterSchemas = true });
            var messageData = await encoder.EncodeMessageDataAsync<MessageWithMetadata, Employee>(employee);

            // deserialize with the new schema, which is NOT backward compatible with the old schema as it adds a new field
            Assert.That(
                async () => await encoder.DecodeMessageDataAsync<Employee_V2>(messageData),
                Throws.InstanceOf<AvroException>());
        }

        [RecordedTest]
        public async Task CanSerializeAndDeserializeGenericRecord()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var record = new GenericRecord((RecordSchema)Employee._SCHEMA);
            record.Add("Name", "Caketown");
            record.Add("Age", 42);

            var encoder = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroEncoderOptions { AutoRegisterSchemas = true });
            var messageData = await encoder.EncodeMessageDataAsync<MessageWithMetadata, GenericRecord>(record);

            var deserializedObject = await encoder.DecodeMessageDataAsync<GenericRecord>(messageData);
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

            var encoder = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroEncoderOptions { AutoRegisterSchemas = true });
            Assert.ThrowsAsync<ArgumentException>(async () => await encoder.EncodeMessageDataAsync<MessageWithMetadata, TimeZoneInfo>(timeZoneInfo));
            await Task.CompletedTask;
        }

        [RecordedTest]
        public async Task CannotDeserializeUnsupportedType()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var encoder = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroEncoderOptions { AutoRegisterSchemas = true });
            var messageData = new MessageWithMetadata
            {
                Data = new BinaryData(Array.Empty<byte>()),
                ContentType = "avro/binary+234234"
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await encoder.DecodeMessageDataAsync<TimeZoneInfo>(messageData));
            await Task.CompletedTask;
        }

        [RecordedTest]
        public async Task CannotDeserializeWithNullSchemaId()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var encoder = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroEncoderOptions { AutoRegisterSchemas = true });
            var messageData = new MessageWithMetadata
            {
                Data = new BinaryData(Array.Empty<byte>()),
                ContentType = null
            };
            Assert.ThrowsAsync<ArgumentNullException>(async () => await encoder.DecodeMessageDataAsync<TimeZoneInfo>(messageData));
            await Task.CompletedTask;
        }

        [RecordedTest]
        public async Task CanUseEncoderWithEventData()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            #region Snippet:SchemaRegistryAvroEncodeEventData
            var encoder = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroEncoderOptions { AutoRegisterSchemas = true });

            var employee = new Employee { Age = 42, Name = "Caketown" };
            EventData eventData = (EventData) await encoder.EncodeMessageDataAsync(employee, messageType: typeof(EventData));

#if SNIPPET
            // the schema Id will be included as a parameter of the content type
            Console.WriteLine(eventData.ContentType);

            // the serialized Avro data will be stored in the EventBody
            Console.WriteLine(eventData.EventBody);
#endif
            #endregion

            Assert.IsFalse(((MessageWithMetadata) eventData).IsReadOnly);
            string[] contentType = eventData.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("avro/binary", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

            #region Snippet:SchemaRegistryAvroDecodeEventData
            Employee deserialized = (Employee) await encoder.DecodeMessageDataAsync(eventData, typeof(Employee));
#if SNIPPET
            Console.WriteLine(deserialized.Age);
            Console.WriteLine(deserialized.Name);
#endif
            #endregion

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
        public async Task CanUseEncoderWithEventDataUsingGenerics()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            #region Snippet:SchemaRegistryAvroEncodeEventDataGenerics
            var encoder = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroEncoderOptions { AutoRegisterSchemas = true });

            var employee = new Employee { Age = 42, Name = "Caketown" };
            EventData eventData = await encoder.EncodeMessageDataAsync<EventData, Employee>(employee);

#if SNIPPET
            // the schema Id will be included as a parameter of the content type
            Console.WriteLine(eventData.ContentType);

            // the serialized Avro data will be stored in the EventBody
            Console.WriteLine(eventData.EventBody);
#endif
            #endregion

            Assert.IsFalse(((MessageWithMetadata) eventData).IsReadOnly);
            string[] contentType = eventData.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("avro/binary", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

            #region Snippet:SchemaRegistryAvroDecodeEventDataGenerics
            Employee deserialized = (Employee) await encoder.DecodeMessageDataAsync<Employee>(eventData);
#if SNIPPET
            Console.WriteLine(deserialized.Age);
            Console.WriteLine(deserialized.Name);
#endif
            #endregion

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
        public async Task CanDecodePreamble()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var encoder = new SchemaRegistryAvroEncoder(client, groupName, new SchemaRegistryAvroEncoderOptions { AutoRegisterSchemas = true });

            var employee = new Employee { Age = 42, Name = "Caketown" };
            EventData eventData = await encoder.EncodeMessageDataAsync<EventData, Employee>(employee);
            string schemaId = eventData.ContentType.Split('+')[1];
            eventData.ContentType = "avro/binary";

            using var stream = new MemoryStream();
            stream.Write(new byte[] { 0, 0, 0, 0 }, 0, 4);
            var encoding = new UTF8Encoding(false);
            stream.Write(encoding.GetBytes(schemaId), 0, 32);
            stream.Write(eventData.Body.ToArray(), 0, eventData.Body.Length);
            stream.Position = 0;
            eventData.EventBody = BinaryData.FromStream(stream);

            Employee deserialized = await encoder.DecodeMessageDataAsync<Employee>(eventData);

            // decoding should not alter the message
            Assert.AreEqual("avro/binary", eventData.ContentType);

            // verify the payload was decoded correctly
            Assert.IsNotNull(deserialized);
            Assert.AreEqual("Caketown", deserialized.Name);
            Assert.AreEqual(42, deserialized.Age);
        }
    }
}
