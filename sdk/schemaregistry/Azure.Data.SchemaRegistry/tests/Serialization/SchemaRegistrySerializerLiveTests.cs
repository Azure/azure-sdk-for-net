// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using Azure.Data.SchemaRegistry.Serialization;
using Azure.Messaging;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;
using TestSchema;

namespace Azure.Data.SchemaRegistry.Tests.Serialization
{
    public class SchemaRegistrySerializerLiveTests : SchemaRegistrySerializerLiveTestBase
    {
        private static readonly string s_schema = "{\r\n  \"$schema\": \"http://json-schema.org/draft-04/schema#\",\r\n  \"title\": \"Employee\",\r\n  \"type\": \"object\",\r\n  \"additionalProperties\": false,\r\n  \"properties\": {\r\n    \"Age\": {\r\n      \"type\": \"integer\",\r\n      \"format\": \"int32\"\r\n    },\r\n    \"Name\": {\r\n      \"type\": [\r\n        \"null\",\r\n        \"string\"\r\n      ]\r\n    }\r\n  }\r\n}";
        private static readonly string s_customSchema = "Employee: { Age = int, Name = string }";

        public SchemaRegistrySerializerLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CanSerializeAndDeserialize()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new Employee { Age = 62, Name = "Bob" };

            await client.RegisterSchemaAsync(groupName, (typeof(Employee)).Name, s_schema, SchemaFormat.Json, CancellationToken.None).ConfigureAwait(false);

            var serializer = new SchemaRegistrySerializer(client, new SampleJsonGenerator(), groupName);
            MessageContent content = await serializer.SerializeAsync<MessageContent, Employee>(employee);

            Employee deserializedEmployee = await serializer.DeserializeAsync<Employee>(content);

            Assert.That(deserializedEmployee, Is.Not.Null);
            Assert.That(deserializedEmployee.Name, Is.EqualTo("Bob"));
            Assert.That(deserializedEmployee.Age, Is.EqualTo(62));
        }

        [RecordedTest]
        public async Task CanSerializeAndDeserializeWithNewtonsoft()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new Employee { Age = 62, Name = "Bob" };

            await client.RegisterSchemaAsync(groupName, (typeof(Employee)).Name, s_schema, SchemaFormat.Json, CancellationToken.None).ConfigureAwait(false);

            var serializerOptions = new SchemaRegistrySerializerOptions
            {
                Serializer = new NewtonsoftJsonObjectSerializer()
            };
            var serializer = new SchemaRegistrySerializer(client, new SampleJsonGenerator(), groupName, serializerOptions);
            MessageContent content = await serializer.SerializeAsync<MessageContent, Employee>(employee);

            Employee deserializedEmployee = await serializer.DeserializeAsync<Employee>(content);

            Assert.That(deserializedEmployee, Is.Not.Null);
            Assert.That(deserializedEmployee.Name, Is.EqualTo("Bob"));
            Assert.That(deserializedEmployee.Age, Is.EqualTo(62));
        }

        [RecordedTest]
        public async Task CanSerializeAndDeserializeWithCustomSerializer()
        {
            var client = CreateCustomClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new Employee { Age = 25, Name = "Name" };

            await client.RegisterSchemaAsync(groupName, (typeof(Employee)).Name, s_customSchema, SchemaFormat.Custom, CancellationToken.None).ConfigureAwait(false);

            var serializerOptions = new SchemaRegistrySerializerOptions
            {
                Serializer = new FakeCustomSerializer(),
                Format = SchemaFormat.Custom
            };
            var serializer = new SchemaRegistrySerializer(client, new SampleCustomGenerator(), groupName, serializerOptions);
            MessageContent content = await serializer.SerializeAsync<MessageContent, Employee>(employee);

            Employee deserializedEmployee = await serializer.DeserializeAsync<Employee>(content);

            Assert.That(deserializedEmployee, Is.Not.Null);
            Assert.That(deserializedEmployee.Name, Is.EqualTo("Name"));
            Assert.That(deserializedEmployee.Age, Is.EqualTo(25));
        }

        [RecordedTest]
        public async Task CanSerializeAndDeserializeWithSeparateInstances()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new Employee { Age = 42, Name = "Caketown" };

            await client.RegisterSchemaAsync(groupName, (typeof(Employee)).Name, s_schema, SchemaFormat.Json, CancellationToken.None).ConfigureAwait(false);

            var serializer = new SchemaRegistrySerializer(client, new SampleJsonGenerator(), groupName);
            MessageContent content = await serializer.SerializeAsync<MessageContent, Employee>(employee);

            // validate that we can use the constructor that only takes the client when deserializing since groupName is not necessary
            serializer = new SchemaRegistrySerializer(client, new SampleJsonGenerator());
            Employee deserializedEmployee = await serializer.DeserializeAsync<Employee>(content);

            Assert.That(deserializedEmployee, Is.Not.Null);
            Assert.That(deserializedEmployee.Name, Is.EqualTo("Caketown"));
            Assert.That(deserializedEmployee.Age, Is.EqualTo(42));
        }

        [RecordedTest]
        public async Task CanSerializeAndDeserializeWithCompatibleSchema()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new EmployeeV2 { Age = 42, Name = "Caketown", City = "Redmond" };

            await client.RegisterSchemaAsync(groupName, (typeof(EmployeeV2)).Name, s_schema, SchemaFormat.Json, CancellationToken.None).ConfigureAwait(false);

            var serializer = new SchemaRegistrySerializer(client, new SampleJsonGenerator(), groupName);
            var content = await serializer.SerializeAsync<MessageContent, EmployeeV2>(employee);

            // deserialize using the old schema, which is forward compatible with the new schema
            // if you swap the old schema and the new schema in your mind, then this can also be thought as a backwards compatible test

            var deserializedObject = await serializer.DeserializeAsync<Employee>(content);
            var readEmployee = deserializedObject as Employee;
            Assert.That(readEmployee, Is.Not.Null);
            Assert.That(readEmployee.Name, Is.EqualTo("Caketown"));
            Assert.That(readEmployee.Age, Is.EqualTo(42));

            // deserialize using the new schema to make sure we are respecting it
            var readEmployeeV2 = await serializer.DeserializeAsync<EmployeeV2>(content);
            Assert.That(readEmployee, Is.Not.Null);
            Assert.That(readEmployeeV2.Name, Is.EqualTo("Caketown"));
            Assert.That(readEmployeeV2.Age, Is.EqualTo(42));
            Assert.That(readEmployeeV2.City, Is.EqualTo("Redmond"));
        }

        [RecordedTest]
        public async Task CanDeserializeIntoNonCompatibleType()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new Employee() { Age = 42, Name = "Caketown" };

            await client.RegisterSchemaAsync(groupName, (typeof(Employee)).Name, s_schema, SchemaFormat.Json, CancellationToken.None).ConfigureAwait(false);

            var serializer = new SchemaRegistrySerializer(client, new SampleJsonGenerator(), groupName);
            var content = await serializer.SerializeAsync<MessageContent, Employee>(employee);

            // Since the serializer does not have built-in validation, deserialize is able to fill undefined properties with null values.
            var deserialized = await serializer.DeserializeAsync<EmployeeV2>(content);
            Assert.That(deserialized, Is.Not.Null);
            Assert.That(deserialized.Name, Is.EqualTo("Caketown"));
            Assert.That(deserialized.Age, Is.EqualTo(42));
            Assert.That(deserialized.City, Is.EqualTo(null));
        }

        [RecordedTest]
        public void CannotDeserializeWithNullSchemaId()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var serializer = new SchemaRegistrySerializer(client, new SampleJsonGenerator(), groupName);
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

            await client.RegisterSchemaAsync(groupName, (typeof(Employee)).Name, s_schema, SchemaFormat.Json, CancellationToken.None).ConfigureAwait(false);

            var serializer = new SchemaRegistrySerializer(client, new SampleJsonGenerator(), groupName);

            var employee = new Employee { Age = 42, Name = "Caketown" };
            EventData eventData = (EventData)await serializer.SerializeAsync(employee, messageType: typeof(EventData));

            // construct a publisher and publish the events to our event hub
            var fullyQualifiedNamespace = TestEnvironment.SchemaRegistryEventHubEndpoint;
            var eventHubName = TestEnvironment.SchemaRegistryEventHubName;
            var credential = TestEnvironment.Credential;

            await using var producer = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential);
            await producer.SendAsync(new EventData[] { eventData });

            Assert.That(eventData.IsReadOnly, Is.False);
            string[] contentType = eventData.ContentType.Split('+');
            Assert.That(contentType.Length, Is.EqualTo(2));
            Assert.That(contentType[0], Is.EqualTo("application/json"));
            Assert.That(contentType[1], Is.Not.Empty);

            // construct a consumer and consume the event from our event hub
            await using var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, fullyQualifiedNamespace, eventHubName, credential);
            await foreach (PartitionEvent receivedEvent in consumer.ReadEventsAsync())
            {
                Employee deserialized = (Employee)await serializer.DeserializeAsync(eventData, typeof(Employee));

                // decoding should not alter the message
                contentType = eventData.ContentType.Split('+');
                Assert.That(contentType.Length, Is.EqualTo(2));
                Assert.That(contentType[0], Is.EqualTo("application/json"));
                Assert.That(contentType[1], Is.Not.Empty);

                // verify the payload was decoded correctly
                Assert.That(deserialized, Is.Not.Null);
                Assert.That(deserialized.Name, Is.EqualTo("Caketown"));
                Assert.That(deserialized.Age, Is.EqualTo(42));
                break;
            }
        }

        [RecordedTest]
        public async Task CanUseEncoderWithEventDataUsingGenerics()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var serializer = new SchemaRegistrySerializer(client, new SampleJsonGenerator(), groupName);

            await client.RegisterSchemaAsync(groupName, (typeof(Employee)).Name, s_schema, SchemaFormat.Json, CancellationToken.None).ConfigureAwait(false);

            var employee = new Employee { Age = 42, Name = "Caketown" };
            EventData eventData = await serializer.SerializeAsync<EventData, Employee>(employee);

            Assert.That(eventData.IsReadOnly, Is.False);
            string[] contentType = eventData.ContentType.Split('+');
            Assert.That(contentType.Length, Is.EqualTo(2));
            Assert.That(contentType[0], Is.EqualTo("application/json"));
            Assert.That(contentType[1], Is.Not.Empty);

            Employee deserialized = await serializer.DeserializeAsync<Employee>(eventData);

            // decoding should not alter the message
            contentType = eventData.ContentType.Split('+');
            Assert.That(contentType.Length, Is.EqualTo(2));
            Assert.That(contentType[0], Is.EqualTo("application/json"));
            Assert.That(contentType[1], Is.Not.Empty);

            // verify the payload was decoded correctly
            Assert.That(deserialized, Is.Not.Null);
            Assert.That(deserialized.Name, Is.EqualTo("Caketown"));
            Assert.That(deserialized.Age, Is.EqualTo(42));
        }

        [RecordedTest]
        public void SerializingToMessageTypeWithoutConstructorThrows()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var serializer = new SchemaRegistrySerializer(client, new SampleJsonGenerator(), groupName);
            Assert.ThrowsAsync<InvalidOperationException>(
                async () => await serializer.SerializeAsync(new Employee { Age = 42, Name = "Caketown" }, messageType: typeof(MessageContentWithNoConstructor)));
        }

        [RecordedTest]
        public void SchemaGeneratorWithValidationExceptionThrows()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var serializer = new SchemaRegistrySerializer(client, new ValidateThrowsGenerator(), groupName);

            Assert.That(
                async () => await serializer.SerializeAsync(new Employee { Age = 42, Name = "Caketown" }), Throws.InstanceOf<AggregateException>());
        }

        [RecordedTest]
        public void SerializingThrowsForNonExistentSchema()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var serializer = new SchemaRegistrySerializer(client, new SampleJsonGenerator(), groupName);
            Assert.ThrowsAsync<RequestFailedException>(async () => await serializer.SerializeAsync(new UnregisteredEmployee { Age = 42, Name = "Caketown" }));
        }

        [RecordedTest]
        public void SerializingWithoutGroupNameThrows()
        {
            var client = CreateClient();

            var serializer = new SchemaRegistrySerializer(client, new SampleJsonGenerator());
            Assert.ThrowsAsync<InvalidOperationException>(
                async () => await serializer.SerializeAsync(new Employee { Age = 42, Name = "Caketown" }));
        }

        public class UnregisteredEmployee
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class MessageContentWithNoConstructor : MessageContent
        {
            internal MessageContentWithNoConstructor()
            {
            }
        }

        private class SampleJsonGenerator : SchemaValidator
        {
            public override string GenerateSchema(Type dataType)
            {
                return s_schema;
            }

            public override bool TryValidate(object data, Type dataType, string schemaDefinition, out IEnumerable<Exception> validationErrors)
            {
                validationErrors = new List<Exception>();
                return true;
            }
        }

        private class ValidateThrowsGenerator : SchemaValidator
        {
            public override string GenerateSchema(Type dataType)
            {
                return s_schema;
            }

            public override bool TryValidate(object data, Type dataType, string schemaDefinition, out IEnumerable<Exception> validationErrors)
            {
                var errors = new List<Exception>();
                errors.Add(new Exception("Incorrect schema."));
                validationErrors = errors;

                return false;
            }
        }

        private class SampleCustomGenerator : SchemaValidator
        {
            public override string GenerateSchema(Type dataType)
            {
                return s_customSchema;
            }

            public override bool TryValidate(object data, Type dataType, string schemaDefinition, out IEnumerable<Exception> validationErrors)
            {
                Assert.That(data, Is.TypeOf<Employee>());
                Assert.That(dataType.Name, Is.EqualTo("Employee"));
                Assert.That(s_customSchema, Is.EqualTo(schemaDefinition));

                validationErrors = new List<Exception>();

                return true;
            }
        }

        private class FakeCustomSerializer : ObjectSerializer
        {
            public override object Deserialize(Stream stream, Type returnType, CancellationToken cancellationToken)
            {
                return new Employee
                {
                    Age = 25,
                    Name = "Name"
                };
            }

            public override async ValueTask<object> DeserializeAsync(Stream stream, Type returnType, CancellationToken cancellationToken)
            {
                await Task.Yield();
                return new Employee
                {
                    Age = 25,
                    Name = "Name"
                };
            }

            public override void Serialize(Stream stream, object value, Type inputType, CancellationToken cancellationToken)
            {
                var data = new BinaryData(s_customSchema);
                var dataArray = data.ToArray();
                stream.Write(dataArray, 0, dataArray.Length);
            }

            public override async ValueTask SerializeAsync(Stream stream, object value, Type inputType, CancellationToken cancellationToken)
            {
                var data = new BinaryData(s_customSchema);
                var dataArray = data.ToArray();
                await stream.WriteAsync(dataArray, 0, dataArray.Length, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
