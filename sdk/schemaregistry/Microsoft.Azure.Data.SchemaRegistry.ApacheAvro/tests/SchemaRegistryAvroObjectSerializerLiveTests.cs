// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Avro;
using Avro.Generic;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Avro.Specific;
using Azure;
using Azure.Identity;
using Azure.Messaging;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
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

            #region Snippet:SchemaRegistryAvroEncodeDecodeMessageContent

            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });
            MessageContent content = await serializer.SerializeAsync<MessageContent, Employee>(employee);

            Employee deserializedEmployee = await serializer.DeserializeAsync<Employee>(content);
            #endregion

            Assert.IsNotNull(deserializedEmployee);
            Assert.AreEqual("Caketown", deserializedEmployee.Name);
            Assert.AreEqual(42, deserializedEmployee.Age);
        }

        [RecordedTest]
        public async Task CanSerializeAndDeserializeWithSeparateInstances()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new Employee { Age = 42, Name = "Caketown" };

            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });
            MessageContent content = await serializer.SerializeAsync<MessageContent, Employee>(employee);

            // validate that we can use the constructor that only takes the client when deserializing since groupName is not necessary
            serializer = new SchemaRegistryAvroSerializer(client);
            Employee deserializedEmployee = await serializer.DeserializeAsync<Employee>(content);

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
            var content = await serializer.SerializeAsync<MessageContent, Employee_V2>(employee);

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
            var employee = new Employee() { Age = 42, Name = "Caketown" };

            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });
            var content = await serializer.SerializeAsync<MessageContent, Employee>(employee);
            var schemaId = content.ContentType.ToString().Split('+')[1];

            // deserialize with the new schema, which is NOT backward compatible with the old schema as it adds a new field
            Assert.That(
                async () => await serializer.DeserializeAsync<Employee_V2>(content),
                Throws.InstanceOf<Exception>()
                    .And.Property(nameof(Exception.InnerException)).InstanceOf<AvroException>());
        }

        [RecordedTest]
        public void ThrowsAvroSerializationExceptionWhenSerializingWithInvalidAvroSchema()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var invalid = new InvalidAvroModel();

            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });
            Assert.That(
                async () => await serializer.SerializeAsync<MessageContent, InvalidAvroModel>(invalid),
                Throws.InstanceOf<Exception>().And.Property(nameof(Exception.InnerException)).InstanceOf<SchemaParseException>());
        }

        [RecordedTest]
        public async Task ThrowsAvroSerializationExceptionWhenDeserializingWithInvalidAvroSchema()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });
            var employee = new Employee { Age = 42, Name = "Caketown" };
            var content = await serializer.SerializeAsync<MessageContent, Employee>(employee);

            Assert.That(
                async () => await serializer.DeserializeAsync<InvalidAvroModel>(content),
                Throws.InstanceOf<Exception>()
                    .And.Property(nameof(Exception.InnerException)).InstanceOf<SchemaParseException>());
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
            var content = await serializer.SerializeAsync<MessageContent, GenericRecord>(record);

            var deserializedObject = await serializer.DeserializeAsync<GenericRecord>(content);
            Assert.IsNotNull(deserializedObject);
            Assert.AreEqual("Caketown", deserializedObject.GetValue(0));
            Assert.AreEqual(42, deserializedObject.GetValue(1));
        }

        [RecordedTest]
        public void CannotSerializeUnsupportedType()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var timeZoneInfo = TimeZoneInfo.Utc;

            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });
            Assert.ThrowsAsync<ArgumentException>(async () => await serializer.SerializeAsync<MessageContent, TimeZoneInfo>(timeZoneInfo));
        }

        [RecordedTest]
        public void CannotDeserializeUnsupportedType()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });
            var content = new MessageContent
            {
                Data = new BinaryData(Array.Empty<byte>()),
                ContentType = "avro/binary+234234"
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await serializer.DeserializeAsync<TimeZoneInfo>(content));
        }

        [RecordedTest]
        public void CannotDeserializeWithNullSchemaId()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });
            var content = new MessageContent
            {
                Data = new BinaryData(Array.Empty<byte>()),
                ContentType = null
            };
            Assert.ThrowsAsync<ArgumentNullException>(async () => await serializer.DeserializeAsync<TimeZoneInfo>(content));
        }

        [RecordedTest]
        [LiveOnly] // due to Event Hubs integration
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

            // construct a publisher and publish the events to our event hub
#if SNIPPET
            var fullyQualifiedNamespace = "<< FULLY-QUALIFIED EVENT HUBS NAMESPACE (like something.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = TestEnvironment.SchemaRegistryEndpoint;
            var eventHubName = TestEnvironment.SchemaRegistryEventHubName;
            var credential = TestEnvironment.Credential;
#endif

            // It is recommended that you cache the Event Hubs clients for the lifetime of your
            // application, closing or disposing when application ends.  This example disposes
            // after the immediate scope for simplicity.

            await using var producer = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential);
            await producer.SendAsync(new EventData[] { eventData });
            #endregion

            Assert.IsFalse(eventData.IsReadOnly);
            string[] contentType = eventData.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("avro/binary", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

            #region Snippet:SchemaRegistryAvroDecodeEventData
            // construct a consumer and consume the event from our event hub

            // It is recommended that you cache the Event Hubs clients for the lifetime of your
            // application, closing or disposing when application ends.  This example disposes
            // after the immediate scope for simplicity.

            await using var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, fullyQualifiedNamespace, eventHubName, credential);
            await foreach (PartitionEvent receivedEvent in consumer.ReadEventsAsync())
            {
                Employee deserialized = (Employee) await serializer.DeserializeAsync(eventData, typeof(Employee));
#if SNIPPET
                Console.WriteLine(deserialized.Age);
                Console.WriteLine(deserialized.Name);
#else
                // decoding should not alter the message
                contentType = eventData.ContentType.Split('+');
                Assert.AreEqual(2, contentType.Length);
                Assert.AreEqual("avro/binary", contentType[0]);
                Assert.IsNotEmpty(contentType[1]);

                // verify the payload was decoded correctly
                Assert.IsNotNull(deserialized);
                Assert.AreEqual("Caketown", deserialized.Name);
                Assert.AreEqual(42, deserialized.Age);
#endif
                break;
            }
            #endregion
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
        public void SerializingToMessageTypeWithoutConstructorThrows()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });
            Assert.ThrowsAsync<InvalidOperationException>(
                async () => await serializer.SerializeAsync(new Employee { Age = 42, Name = "Caketown" }, messageType: typeof(MessageContentWithNoConstructor)));
        }

        [RecordedTest]
        public void SerializingWithoutAutoRegisterThrowsForNonExistentSchema()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var serializer = new SchemaRegistryAvroSerializer(client, groupName);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await serializer.SerializeAsync(new Employee_Unregistered { Age = 42, Name = "Caketown"}));
        }

        [RecordedTest]
        public void SerializingWithoutGroupNameThrows()
        {
            var client = CreateClient();

            var serializer = new SchemaRegistryAvroSerializer(client);
            Assert.ThrowsAsync<InvalidOperationException>(
                async () => await serializer.SerializeAsync(new Employee { Age = 42, Name = "Caketown" }));
        }

        private class InvalidAvroModel : ISpecificRecord
        {
            // the schema is invalid because it doesn't contain any fields
            public virtual Schema Schema => Schema.Parse("{\"type\":\"record\",\"name\":\"Invalid\"}");

            public virtual object Get(int fieldPos) => throw new NotImplementedException();

            public virtual void Put(int fieldPos, object fieldValue) => throw new NotImplementedException();
        }

        public class MessageContentWithNoConstructor : MessageContent
        {
            internal MessageContentWithNoConstructor()
            {
            }
        }
    }
}
