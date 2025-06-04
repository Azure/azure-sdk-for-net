// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using Azure.Data.SchemaRegistry.Serialization;
using Azure.Messaging.EventHubs;
using NUnit.Framework;
using TestSchema;

namespace Azure.Data.SchemaRegistry.Tests.Serialization
{
    [NonParallelizable]
    public class SerializationEventSourceLiveTests : SchemaRegistrySerializerLiveTestBase
    {
        private static readonly string _schema = "{\r\n  \"$schema\": \"http://json-schema.org/draft-04/schema#\",\r\n  \"title\": \"Employee\",\r\n  \"type\": \"object\",\r\n  \"additionalProperties\": false,\r\n  \"properties\": {\r\n    \"Age\": {\r\n      \"type\": \"integer\",\r\n      \"format\": \"int32\"\r\n    },\r\n    \"Name\": {\r\n      \"type\": [\r\n        \"null\",\r\n        \"string\"\r\n      ]\r\n    }\r\n  }\r\n}";
        private static readonly string _schemaV2 = "{\r\n  \"$schema\": \"http://json-schema.org/draft-04/schema#\",\r\n  \"title\": \"Employee\",\r\n  \"type\": \"object\",\r\n  \"additionalProperties\": false,\r\n  \"properties\": {\r\n    \"Age\": {\r\n      \"type\": \"integer\",\r\n      \"format\": \"int32\"\r\n    },\r\n    \"City\": {\r\n      \"type\": [\r\n        \"null\",\r\n        \"string\"\r\n      ]\r\n    },\r\n    \"Name\": {\r\n      \"type\": [\r\n        \"null\",\r\n        \"string\"\r\n      ]\r\n    }\r\n  }\r\n}";
        private TestEventListener _listener;

        public SerializationEventSourceLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup()
        {
            _listener = new TestEventListener();
            _listener.EnableEvents(SchemaRegistrySerializationEventSource.Log, EventLevel.Verbose);
        }

        [TearDown]
        public void TearDown()
        {
            _listener.Dispose();
        }

        [RecordedTest]
        public async Task UpdatingCacheLogsEvents()
        {
            using var logger = AzureEventSourceListener.CreateConsoleLogger(EventLevel.Verbose);
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var serializer = new SchemaRegistrySerializer(client, new SampleJsonGenerator(), groupName);

            var employee = new Employee { Age = 42, Name = "Caketown" };

            await client.RegisterSchemaAsync(groupName, (typeof(Employee)).Name, _schema, SchemaFormat.Json, CancellationToken.None).ConfigureAwait(false);
            await client.RegisterSchemaAsync(groupName, (typeof(EmployeeV2)).Name, _schemaV2, SchemaFormat.Json, CancellationToken.None).ConfigureAwait(false);

            EventData eventData = await serializer.SerializeAsync<EventData, Employee>(employee);

            Assert.IsFalse(eventData.IsReadOnly);
            string[] contentType = eventData.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("application/json", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

            Employee deserialized = await serializer.DeserializeAsync<Employee>(eventData);

            // decoding should not alter the message
            contentType = eventData.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("application/json", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

            // verify the payload was decoded correctly
            Assert.IsNotNull(deserialized);
            Assert.AreEqual("Caketown", deserialized.Name);
            Assert.AreEqual(42, deserialized.Age);

            // Use different schema so we can see the cache updated
            eventData = await serializer.SerializeAsync<EventData, EmployeeV2>(new EmployeeV2 { Age = 42, Name = "Caketown", City = "Redmond" });

            Assert.IsFalse(eventData.IsReadOnly);
            eventData.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("application/json", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

            await serializer.DeserializeAsync<Employee>(eventData);

            // decoding should not alter the message
            contentType = eventData.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("application/json", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

            // verify the payload was decoded correctly
            Assert.IsNotNull(deserialized);
            Assert.AreEqual("Caketown", deserialized.Name);
            Assert.AreEqual(42, deserialized.Age);

            var events = _listener.EventsById(SchemaRegistrySerializationEventSource.CacheUpdatedEvent).ToArray();
            Assert.AreEqual(2, events.Length);

            // first log entry should have 2 as the total number of entries as we maintain two caches for each schema
            Assert.AreEqual(2, events[0].Payload[0]);
            // the second payload element is the total schema length
            Assert.AreEqual(640, events[0].Payload[1]);

            // second entry will include both V1 and V2 schemas - so 4 total entries
            Assert.AreEqual(4, events[1].Payload[0]);
            Assert.AreEqual(1448, events[1].Payload[1]);
        }

        private class SampleJsonGenerator : SchemaValidator
        {
            public override string GenerateSchema(Type dataType)
            {
                if (dataType == typeof(Employee))
                {
                    return _schema;
                }
                return _schemaV2;
            }

            public override bool TryValidate(object data, Type dataType, string schemaDefinition, out IEnumerable<Exception> validationErrors)
            {
                validationErrors = new List<Exception>();
                return true;
            }
        }
    }
}
