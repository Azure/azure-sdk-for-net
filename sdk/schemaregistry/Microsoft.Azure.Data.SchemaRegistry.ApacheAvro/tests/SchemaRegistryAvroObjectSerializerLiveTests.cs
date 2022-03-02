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
    public class SchemaRegistryAvroObjectSerializerLiveTests : SchemaRegistryAvroObjectSerializerLiveTestBase
    {
        public SchemaRegistryAvroObjectSerializerLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CanSerializeAndDeserialize()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new Employee { Age = 42, Name = "Caketown" };

            #region Snippet:SchemaRegistryAvroEncodeDecodeBinaryContent
            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });
            BinaryContent content = await serializer.SerializeAsync<BinaryContent, Employee>(employee);

            Employee deserializedEmployee = await serializer.DeserializeAsync<Employee>(content);
            #endregion

            Assert.IsNotNull(deserializedEmployee);
            Assert.AreEqual("Caketown", deserializedEmployee.Name);
            Assert.AreEqual(42, deserializedEmployee.Age);
        }

        [RecordedTest]
        public async Task CanSerializeAndDeserializeWithCompatibleSchema()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new Employee_V2 { Age = 42, Name = "Caketown", City = "Redmond" };

            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });
            var content = await serializer.SerializeAsync<BinaryContent, Employee_V2>(employee);

            // deserialize using the old schema, which is forward compatible with the new schema
            // if you swap the old schema and the new schema in your mind, then this can also be thought as a backwards compatible test
            var deserializedObject = await serializer.DeserializeAsync<Employee>(content);
            var readEmployee = deserializedObject as Employee;
            Assert.IsNotNull(readEmployee);
            Assert.AreEqual("Caketown", readEmployee.Name);
            Assert.AreEqual(42, readEmployee.Age);

            // deserialize using the new schema to make sure we are respecting it
            var readEmployeeV2 = await serializer.DeserializeAsync<Employee_V2>(content);
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

            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });
            var content = await serializer.SerializeAsync<BinaryContent, Employee>(employee);

            // deserialize with the new schema, which is NOT backward compatible with the old schema as it adds a new field
            Assert.That(
                async () => await serializer.DeserializeAsync<Employee_V2>(content),
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

            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });
            var content = await serializer.SerializeAsync<BinaryContent, GenericRecord>(record);

            var deserializedObject = await serializer.DeserializeAsync<GenericRecord>(content);
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

            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });
            Assert.ThrowsAsync<ArgumentException>(async () => await serializer.SerializeAsync<BinaryContent, TimeZoneInfo>(timeZoneInfo));
            await Task.CompletedTask;
        }

        [RecordedTest]
        public async Task CannotDeserializeUnsupportedType()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });
            var content = new BinaryContent
            {
                Data = new BinaryData(Array.Empty<byte>()),
                ContentType = "avro/binary+234234"
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await serializer.DeserializeAsync<TimeZoneInfo>(content));
            await Task.CompletedTask;
        }

        [RecordedTest]
        public async Task CannotDeserializeWithNullSchemaId()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });
            var content = new BinaryContent
            {
                Data = new BinaryData(Array.Empty<byte>()),
                ContentType = null
            };
            Assert.ThrowsAsync<ArgumentNullException>(async () => await serializer.DeserializeAsync<TimeZoneInfo>(content));
            await Task.CompletedTask;
        }

        [RecordedTest]
        public async Task CanUseEncoderWithEventData()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            #region Snippet:SchemaRegistryAvroEncodeEventData
            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });

            var employee = new Employee { Age = 42, Name = "Caketown" };
            EventData eventData = (EventData) await serializer.SerializeAsync(employee, messageType: typeof(EventData));

#if SNIPPET
            // the schema Id will be included as a parameter of the content type
            Console.WriteLine(eventData.ContentType);

            // the serialized Avro data will be stored in the EventBody
            Console.WriteLine(eventData.EventBody);
#endif
            #endregion

            Assert.IsFalse(((BinaryContent) eventData).IsReadOnly);
            string[] contentType = eventData.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("avro/binary", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

            #region Snippet:SchemaRegistryAvroDecodeEventData
            Employee deserialized = (Employee) await serializer.DeserializeAsync(eventData, typeof(Employee));
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
            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });

            var employee = new Employee { Age = 42, Name = "Caketown" };
            EventData eventData = await serializer.SerializeAsync<EventData, Employee>(employee);

#if SNIPPET
            // the schema Id will be included as a parameter of the content type
            Console.WriteLine(eventData.ContentType);

            // the serialized Avro data will be stored in the EventBody
            Console.WriteLine(eventData.EventBody);
#endif
            #endregion

            Assert.IsFalse(eventData.IsReadOnly);
            string[] contentType = eventData.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("avro/binary", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

            #region Snippet:SchemaRegistryAvroDecodeEventDataGenerics
            Employee deserialized = await serializer.DeserializeAsync<Employee>(eventData);
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

            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });

            var employee = new Employee { Age = 42, Name = "Caketown" };
            EventData eventData = await serializer.SerializeAsync<EventData, Employee>(employee);
            string schemaId = eventData.ContentType.Split('+')[1];
            eventData.ContentType = "avro/binary";

            using var stream = new MemoryStream();
            stream.Write(new byte[] { 0, 0, 0, 0 }, 0, 4);
            var encoding = new UTF8Encoding(false);
            stream.Write(encoding.GetBytes(schemaId), 0, 32);
            stream.Write(eventData.Body.ToArray(), 0, eventData.Body.Length);
            stream.Position = 0;
            eventData.EventBody = BinaryData.FromStream(stream);

            Employee deserialized = await serializer.DeserializeAsync<Employee>(eventData);

            // decoding should not alter the message
            Assert.AreEqual("avro/binary", eventData.ContentType);

            // verify the payload was decoded correctly
            Assert.IsNotNull(deserialized);
            Assert.AreEqual("Caketown", deserialized.Name);
            Assert.AreEqual(42, deserialized.Age);
        }
    }
}
